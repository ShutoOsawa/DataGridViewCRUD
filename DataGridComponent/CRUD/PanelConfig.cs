using System.Collections.Generic;

namespace DataGridComponent
{
    public class PanelConfig
    {

        public static List<Dictionary<string, object>> SetPanelConfig(Dictionary<string, object> panelDict)
        {
            var panelDictList = new List<Dictionary<string, object>>();
            var namePanelDict = new Dictionary<string, object>()
            {
                {"Left",20},
                {"Top",250},
                {"Width",300},
                {"Height",20},
                {"Form", panelDict["Form"]},
                {"Name", "NamePanel"}
            };
            panelDictList.Add(namePanelDict);

            var ipAddressPanelDict = new Dictionary<string, object>()
            {
                {"Left",20},
                {"Top",300},
                {"Width",300},
                {"Height",20},
                {"Form", panelDict["Form"]},
                {"Name", "IPAddressPanel"}
            };
            panelDictList.Add(ipAddressPanelDict);

            var locationPanelDict = new Dictionary<string, object>()
            {
                {"Left",20},
                {"Top",350},
                {"Width",300},
                {"Height",20},
                {"Form", panelDict["Form"]},
                {"Name", "LocationPanel"}
            };
            panelDictList.Add(locationPanelDict);

            return panelDictList;
        }
    }
}