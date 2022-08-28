using System.Collections.Generic;

namespace DataGridComponent
{
    public class TextBoxConfig 
    {

        //TextBox name needs to be the same as property name;
        public static List<Dictionary<string, object>> SetTextBoxConfig(Dictionary<string, object> panelDict)
        {
            var dictList = new List<Dictionary<string, object>>();
            var nameTextBoxDict = new Dictionary<string, object>()
            {
                {"Left",100},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["NamePanel"]},
                {"Name", "Name"}
            };
            dictList.Add(nameTextBoxDict);

            var ipAddressTextBoxDict = new Dictionary<string, object>()
            {
                {"Left",100},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["IPAddressPanel"]},
                {"Name", "IPAddress"}
            };
            dictList.Add(ipAddressTextBoxDict);
            var locationTextBoxDict = new Dictionary<string, object>()
            {
                {"Left",100},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["LocationPanel"]},
                {"Name", "Location"}
            };
            dictList.Add(locationTextBoxDict);

            return dictList;
        }
    }
}