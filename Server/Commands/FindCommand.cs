using System.Collections.Generic;

namespace Tizen.Appium
{
    internal class FindCommand : ICommand
    {
        public string Command => Commands.Find;

        public Result Run(Request req)
        {
            var strategy = req.Params.Strategy;
            var elementId = req.Params.ElementId;

            Log.Debug("Run: Find with " + strategy);

            var result = new Result();
            List<ObjectInfo> list = new List<ObjectInfo>();

            if (strategy == "automationId")
            {
                var obj = AppAdapter.Instance.ObjectList.Get(elementId);
                if (obj != null)
                {
                    list.Add(new ObjectInfo(elementId));
                }
            }
            else
            {
                var ids = AppAdapter.Instance.ObjectList.GetIdsByName(elementId);
                foreach (var id in ids)
                {
                    list.Add(new ObjectInfo(id));
                }
            }

            result.Value = list;
            return result;
        }
    }
}