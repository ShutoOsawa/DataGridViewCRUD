using System;
using System.Collections.Generic;

namespace DataGridComponent
{
    public class ButtonConfig
    {
        public static List<Dictionary<string, object>> SetButtonConfig(Dictionary<string,object> eventDict)
        {
            var buttonDictList = new List<Dictionary<string, object>>();
            var createButtonDict = new Dictionary<string, object>()
            {
                {"Left",300},
                {"Top",250},
                {"Form", eventDict["Form"]},
                {"EventHandler",(EventHandler)eventDict["Create"]},
                {"Text", "Create"},
                {"Name", "createRowButton"}
            };
            buttonDictList.Add(createButtonDict);

            var deleteButtonDict = new Dictionary<string, object>()
            {
                {"Left",300},
                {"Top",300},
                {"Form", eventDict["Form"]},
                {"EventHandler",eventDict["Delete"]},
                {"Text", "Delete"},
                {"Name", "deleteRowButton"}
            };
            buttonDictList.Add(deleteButtonDict);

            var updateButtonDict = new Dictionary<string, object>()
            {
                {"Left",300},
                {"Top",350},
                {"Form", eventDict["Form"]},
                {"EventHandler",eventDict["Update"]},
                {"Text", "Update"},
                {"Name", "updateRowButton"}
            };
            buttonDictList.Add(updateButtonDict);

            var saveButtonDict = new Dictionary<string, object>()
            {
                {"Left",400},
                {"Top",300},
                {"Form", eventDict["Form"]},
                {"EventHandler",eventDict["Save"]},
                {"Text", "Save"},
                {"Name", "saveRowButton"}
            };
            buttonDictList.Add(saveButtonDict);

            var loadButtonDict = new Dictionary<string, object>()
            {
                {"Left",400},
                {"Top",350},
                {"Form", eventDict["Form"]},
                {"EventHandler",(EventHandler)eventDict["Load"]},
                {"Text", "Load"},
                {"Name", "loadRowButton"}
            };
            buttonDictList.Add(loadButtonDict);
            return buttonDictList;
        }
    }
}