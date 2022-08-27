using System;
using System.Windows.Forms;

namespace DataGridComponent
{
    public class Components
    {
        public static Label LabelComponent(string text,int top, int left)
        {
            var label = new Label();
            label.Top = top;
            label.Left = left;
            label.Text = text;
            return label;
        }

        public static TextBox TextBoxComponent(int top, int left)
        {
            var textBox = new TextBox();
            textBox.Top = top;
            textBox.Left = left;
            return textBox;
        }
        public static Button ButtonComponent(ButtonConfig config)
        {
            var button = new Button();
            button.Name = config.Name;
            button.Text = config.Text;
            button.Top = config.Top;
            button.Left = config.Left;
            var dlg = Delegate.CreateDelegate(typeof(EventHandler), config.Form, config.EventHandler.Method);
            button.GetType().GetEvent("Click").AddEventHandler(button,dlg);
            return button;
        }

        public static Panel PanelComponent(int top, int left, int width, int height)
        {
            var panel = new Panel();
            panel.Top = top;
            panel.Left = left;
            panel.Width = width;
            panel.Height = height;
            return panel;
        }
    }
}