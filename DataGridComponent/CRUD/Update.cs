using System.Linq;
using System.Windows.Forms;

namespace DataGridComponent
{
    public class UpdateInfo
    {
        public static ItemInfo UpdateRow(ItemInfo itemInfo, PanelInfo panelInfo)
        {

            foreach (Panel panel in panelInfo.PanelList)
            {
                foreach (var textBox in panel.Controls.OfType<TextBox>())
                {
                    itemInfo.GetType().GetProperty(textBox.Name).SetValue(itemInfo, textBox.Text);
                }
            }
            return itemInfo;
        }
    }
}