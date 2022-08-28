using System.Collections.Generic;

namespace DataGridComponent
{
    public class LabelConfig
    {
        public static List<Dictionary<string, object>> SetLabelConfig(Dictionary<string, object> panelDict)
        {
            var dictList = new List<Dictionary<string, object>>();
            var nameLabelDict = new Dictionary<string, object>()
            {
                {"Left",0},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["NamePanel"]},
                {"Name", "NameLabel"},
                {"Text","Name"}
            };
            dictList.Add(nameLabelDict);

            var ipAddressLabelDict = new Dictionary<string, object>()
            {
                {"Left",0},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["IPAddressPanel"]},
                {"Name", "IPAddressLabel"},
                {"Text","IP Address"}
            };
            dictList.Add(ipAddressLabelDict);
            var locationTextBoxDict = new Dictionary<string, object>()
            {
                {"Left",0},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["LocationPanel"]},
                {"Name", "LocationLabel"},
                {"Text","Location"}
            };
            dictList.Add(locationTextBoxDict);

            return dictList;
        }
    }
}