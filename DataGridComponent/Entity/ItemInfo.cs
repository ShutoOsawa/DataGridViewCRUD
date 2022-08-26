using System.Collections.Generic;
using System.Windows.Forms;

namespace DataGridComponent
{
    public class ItemInfo
    {
        [Required]
        public string Location { get; set; }

        [Required]
        [StringMaximum(4)]
        public string Name { get; set; }

        [Required]
        public string IPAddress { get; set; }

    }


    public class PanelInfo
    {
        public List<ItemInfo> ItemList { get; set; } = new List<ItemInfo>();
        public List<Panel> PanelList { get; set; } = new List<Panel>();
    }
}