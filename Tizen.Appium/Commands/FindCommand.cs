using System.Collections.Generic;

namespace Tizen.Appium
{
    public class FindCommand : ICommand
    {
        public string Command => Commands.Find;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            var strategy = req.Params.Strategy;
            var elementId = req.Params.ElementId;

            Log.Debug("Run: Find with " + strategy);

            var result = new Result();
            List<Result.Element> list = new List<Result.Element>();

            if (strategy == "automationId")
            {
                var obj = objectList.Get(elementId);
                if (obj != null)
                {
                    list.Add(new Result.Element(elementId));
                }
            }
            else if (strategy == "focused")
            {
                var ids = objectList.GetFocusedElementIds();
                foreach (var id in ids)
                {
                    list.Add(new Result.Element(id));
                }
            }
            else
            {
                var ids = objectList.GetIdsByName(elementId);
                foreach (var id in ids)
                {
                    list.Add(new Result.Element(id));
                }
            }

            result.Value = list;
            return result;
        }
    }
}