using System;
using System.Collections.Generic;
using ElmSharp;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

namespace Tizen.Appium
{
    public class EventObject
    {
        static Dictionary<string, EventObject> _eventObjectTable = new Dictionary<string, EventObject>();

        EvasObjectEvent _eventObj;
        Action _action;

        public string Id { get; private set; }

        public string ElementId { get; private set; }

        public EvasObjectCallbackType EventType { get; private set; }

        public bool Once { get; private set; }

        public static EventObject CreateEventObject(string id, string elmId, string evtName, bool once, Action action)
        {
            if (_eventObjectTable.ContainsKey(id))
            {
                return null;
            }

            try
            {
                var eventType = EvasObjectCallbackType.Parse<EvasObjectCallbackType>(evtName);
                var obj = new EventObject(id: id, elementId: elmId, eventType: eventType, once: once, action: action);
                _eventObjectTable.Add(id, obj);
                return obj;
            }
            catch (ArgumentException)
            {
                Log.Debug(TizenAppium.Tag,"Not available event name");
                return null;
            }
            catch (Exception e)
            {
                Log.Debug(TizenAppium.Tag,"It is failed to create event object"+e);
                return null;
            }
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

        EventObject(string id, string elementId, EvasObjectCallbackType eventType, bool once, Action action)
        {
            Id = id;
            ElementId = elementId;
            EventType = eventType;
            Once = once;
            _action = action;
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
            Log.Debug(TizenAppium.Tag," ### [Subscribe] elementId: "+ ElementId + ", subscriptionId: "+Id);

            var ve = ElementUtils.GetTestableElement(ElementId) as VisualElement;
            if (ve == null)
            {
                Log.Debug(TizenAppium.Tag,"### Not Found Element");
                return false;
            }

            _eventObj = new EvasObjectEvent(Platform.GetOrCreateRenderer(ve).NativeView, EventType);

            _eventObj.On += EventHandler;

            return true;
        }

        public bool Unsubscribe()
        {
            Log.Debug(TizenAppium.Tag," ### [Unsubscribe] elementId: "+ ElementId + ", subscriptionId: "+Id);

            _eventObj.On -= EventHandler;
            EventObject.RemoveEventObject(Id);

            return true;
        }
    }
}
