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

    public class BaseConfig
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
    
    public class ButtonConfig:BaseConfig
    {
        public EventHandler EventHandler { get; set; }
        public Form ParentControl { get; set; }
        public ButtonConfig(Dictionary<string,object> configList)
        {
            Name = (string)configList["Name"];
            Text = (string)configList["Text"];
            ParentControl = (Form)configList["Form"];
            EventHandler = (EventHandler)configList["EventHandler"];
            Top = (int)configList["Top"];
            Left = (int)configList["Left"];
        }
    }

    public class PanelConfig:BaseConfig
    {
        public Form ParentControl { get; set; }
        public PanelConfig(Dictionary<string, object> configList)
        {
            Name = (string)configList["Name"];
            ParentControl = (Form)configList["Form"];
            Top = (int)configList["Top"];
            Left = (int)configList["Left"];
            Width = (int)configList["Width"];
            Height = (int)configList["Height"];
        }
    }

    public class TextBoxConfig : BaseConfig
    {
        public Panel ParentControl { get; set; }

        public TextBoxConfig(Dictionary<string, object> configList)
        {
            Name = (string)configList["Name"];
            ParentControl = (Panel)configList["Panel"];
            Top = (int)configList["Top"];
            Left = (int)configList["Left"];
            Width = (int)configList["Width"];
            Height = (int)configList["Height"];
        }
    }

    public class LabelConfig : BaseConfig
    {
        public Panel ParentControl { get; set; }

        public LabelConfig(Dictionary<string, object> configList)
        {
            Name = (string)configList["Name"];
            ParentControl = (Panel)configList["Panel"];
            Top = (int)configList["Top"];
            Left = (int)configList["Left"];
            Width = (int)configList["Width"];
            Height = (int)configList["Height"];
            Text = (string)configList["Text"];
        }
    }

}