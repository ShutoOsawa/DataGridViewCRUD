using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataGridComponent
{
    public class UpdateInfo
    {
        public static ItemInfo UpdateRow(ItemInfo itemInfo, PanelInfo panelInfo)
        {

            ItemInfo prevItemInfo = new ItemInfo();

            foreach (Panel panel in panelInfo.PanelList)
            {
                foreach (var textBox in panel.Controls.OfType<TextBox>())
                {
                    string value = (string)itemInfo.GetType().GetProperty(textBox.Name).GetValue(itemInfo);
                    prevItemInfo.GetType().GetProperty(textBox.Name).SetValue(prevItemInfo, value);
                    itemInfo.GetType().GetProperty(textBox.Name).SetValue(itemInfo, textBox.Text);
                }
            }

            var errMsg = itemInfo.Validation();

            if (errMsg != "")
            {
                MessageBox.Show("please fill out all the boxes.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                itemInfo = prevItemInfo;
            }

            return itemInfo;
        }
    }

    public class ButtonConfig
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Form Form { get; set; }
        public EventHandler EventHandler { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }

        public ButtonConfig(Dictionary<string,object> configList)
        {
            Name = (string)configList["Name"];
            Text = (string)configList["Text"];
            Form = (Form)configList["Form"];
            EventHandler = (EventHandler)configList["EventHandler"];
            Top = (int)configList["Top"];
            Left = (int)configList["Left"];

        }
    }
}