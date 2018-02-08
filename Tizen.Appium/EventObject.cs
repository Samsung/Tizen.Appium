using System;
using System.Collections.Generic;
using ElmSharp;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using System.Linq;

namespace Tizen.Appium
{
    public class EventObject
    {
        static Dictionary<string, EventObject> _eventObjectTable = new Dictionary<string, EventObject>();

        EvasObjectEvent _evaObjEvent = null;
        SmartEvent _smartEvent = null;
        Action _action;

        public string Id { get; private set; }

        public string ElementId { get; private set; }

        public EventType EventType { get; private set; }

        public string EventName { get; private set; }

        public bool Once { get; private set; }

        public static EventObject CreateEventObject(string id, string elmId, string evtName, bool once, Action action)
        {
            if (_eventObjectTable.ContainsKey(id))
            {
                return null;
            }

            try
            {
                var obj = new EventObject(id: id, elementId: elmId, eventName: evtName, once: once, action: action);
                _eventObjectTable.Add(id, obj);
                return obj;
            }
            catch (ArgumentException)
            {
                Log.Debug(TizenAppium.Tag, "Not available event name");
                return null;
            }
            catch (Exception e)
            {
                Log.Debug(TizenAppium.Tag, "It is failed to create event object" + e);
                return null;
            }
        }

        //for debugging
        public static void RemoveAll()
        {
            foreach (var item in _eventObjectTable.ToList())
            {
                (item.Value as EventObject)?.Unsubscribe();
            }
            _eventObjectTable.Clear();
            Log.Debug(TizenAppium.Tag, " _eventObjectTable.count: " + _eventObjectTable.Count);
        }

        public static EventObject GetEventObject(string id)
        {
            if (_eventObjectTable.ContainsKey(id))
            {
                return _eventObjectTable[id];
            }
            else
            {
                return null;
            }
        }

        public static void RemoveEventObject(string id)
        {
            if (_eventObjectTable.ContainsKey(id))
            {
                _eventObjectTable.Remove(id);
            }
        }

        EventObject(string id, string elementId, string eventName, bool once, Action action)
        {
            Id = id;
            ElementId = elementId;
            EventName = eventName;
            Once = once;
            _action = action;

            if (Enum.GetNames(typeof(EvasObjectCallbackType)).Contains(eventName))
            {
                EventType = EventType.EvasObjectEvent;
            }
            else
            {
                EventType = EventType.SmartEvent;
            }
        }

        void EventHandler(object sender, EventArgs args)
        {
            _action?.Invoke();
            if (Once)
            {
                Unsubscribe();
            }
        }

        public bool Subscribe()
        {
            Log.Debug(TizenAppium.Tag, " ### [Subscribe] elementId: " + ElementId + ", subscriptionId: " + Id);

            var ve = ElementUtils.GetTestableElement(ElementId) as VisualElement;
            if (ve != null)
            {
                var evasObj = Platform.GetOrCreateRenderer(ve).NativeView;

                //TBD It conflicts with behavior of renderer.
                evasObj.PropagateEvents = true;

                if (EventType == EventType.EvasObjectEvent)
                {
                    var type = EvasObjectCallbackType.Parse<EvasObjectCallbackType>(EventName);
                    _evaObjEvent = new EvasObjectEvent(evasObj, type);
                    _evaObjEvent.On += EventHandler;
                }
                else
                {
                    _smartEvent = new SmartEvent(evasObj, EventName);
                    _smartEvent.On += EventHandler;
                }

                return true;
            }

            var item = ElementUtils.GetTestableElement(ElementId) as ItemObject;
            if (item != null)
            {
                // TODO
                //Log.Debug(TizenAppium.Tag, "evas object: " + ElementId);
                //_eventObj = new EvasObjectEvent(evasObj, EvasObjectEventType);
                //_eventObj.On += EventHandler;
                //return true;

                // TODO : to be removed. It is a temporaty solution for item pressed event. because of bug in TrackObject.
                Log.Debug(TizenAppium.Tag, "evas object: " + ElementId);
                item.SetPressCallback(ElementId, EventHandler);
                return true;
            }

            Log.Debug(TizenAppium.Tag, "### Not Found Element");
            return false;
        }

        public bool Unsubscribe()
        {
            Log.Debug(TizenAppium.Tag, " ### [Unsubscribe] elementId: " + ElementId + ", subscriptionId: " + Id);

            if (_evaObjEvent != null)
            {
                _evaObjEvent.On -= EventHandler;
            }

            if (_smartEvent != null)
            {
                _smartEvent.On -= EventHandler;
            }

            // TODO : to be removed. It is a temporaty solution for item pressed event. because of bug in TrackObject.
            var item = ElementUtils.GetTestableElement(ElementId) as ItemObject;
            if (item != null)
            {
                item.UnsetPressCallback(ElementId);
            }

            EventObject.RemoveEventObject(Id);

            return true;
        }
    }
}
