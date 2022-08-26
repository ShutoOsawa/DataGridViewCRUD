using System.Collections.Generic;
using System.Windows.Forms;

namespace DataGridComponent
{
    public class ItemInfo
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        /*public STBInfo(string name, string ipAddress)
        {
            this.Name = name;
            this.IPAddress = ipAddress;
        }*/

        /*public STBInfo(List<TextBox> textBoxes)
        {
            foreach (TextBox tb in textBoxes)
            {
                AddItem(tb.Text, tb.Name);
            }
        }

        public void AddItem(string name, object item)
        {
            this.InfoDictionary.Add(item, name);
        }

        public Dictionary<object, string> InfoDictionary { get; set; } = new Dictionary<object, string>();
        */

    }

    public class PanelInfo
    {
        public List<ItemInfo> ItemList { get; set; } = new List<ItemInfo>();
        public List<Panel> PanelList { get; set; } = new List<Panel>();
    }
}