using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataGridComponent
{
    public class Components
    {
        public static Label LabelComponent(Dictionary<string, object> dict)
        {
            var label = new Label();
            label.Top = (int)dict["Top"];
            label.Left = (int)dict["Left"];
            label.Text = (string)dict["Text"];
            label.Name = (string)dict["Name"];
            return label;
        }

        public static TextBox TextBoxComponent(Dictionary<string, object> dict)
        {
            var textBox = new TextBox();
            textBox.Top = (int)dict["Top"];
            textBox.Left = (int)dict["Left"];
            textBox.Width = (int)dict["Width"];
            textBox.Height = (int)dict["Height"];
            textBox.Name = (string)dict["Name"];
            return textBox;
        }
        public static Button ButtonComponent(Dictionary<string, object> dict)
        {
            var button = new Button();
            button.Name = (string)dict["Name"];
            button.Text = (string)dict["Text"];
            button.Top = (int)dict["Top"];
            button.Left = (int)dict["Left"];
            var eventHandler = (EventHandler)dict["EventHandler"];
            var dlg = Delegate.CreateDelegate(typeof(EventHandler), dict["Form"], eventHandler.Method);
            button.GetType().GetEvent("Click").AddEventHandler(button,dlg);
            return button;
        }

        public static Panel PanelComponent(Dictionary<string, object> dict)
        {
            var panel = new Panel();
            panel.Name = (string)dict["Name"];
            panel.Top = (int)dict["Top"];
            panel.Left = (int)dict["Left"];
            panel.Width = (int)dict["Width"];
            panel.Height = (int)dict["Height"];
            return panel;
        }
    }
}