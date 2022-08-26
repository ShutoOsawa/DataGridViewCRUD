using System;
using System.Linq;
using System.Windows.Forms;

namespace DataGridComponent
{
    public class Read
    {
        public static void ReadRow(ItemInfo itemInfo, PanelInfo panelInfo)
        {

            foreach (Panel panel in panelInfo.PanelList)
            {
                foreach (var textBox in panel.Controls.OfType<TextBox>())
                {
                    Object propValue = GetPropValue(itemInfo, textBox.Name);
                    textBox.Text = propValue.ToString();
                }
            }
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}