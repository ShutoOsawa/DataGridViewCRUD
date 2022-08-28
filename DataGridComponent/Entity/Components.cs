using System;
using System.Windows.Forms;

namespace DataGridComponent
{
    public class Components
    {
        public static Label LabelComponent(LabelConfig config)
        {
            var label = new Label();
            label.Top = config.Top;
            label.Left = config.Left;
            label.Text = config.Text;
            return label;
        }

        public static TextBox TextBoxComponent(TextBoxConfig config)
        {
            var textBox = new TextBox();
            textBox.Top = config.Top;
            textBox.Left = config.Left;
            textBox.Width = config.Width;
            textBox.Height = config.Height;
            return textBox;
        }
        public static Button ButtonComponent(ButtonConfig config)
        {
            var button = new Button();
            button.Name = config.Name;
            button.Text = config.Text;
            button.Top = config.Top;
            button.Left = config.Left;
            var dlg = Delegate.CreateDelegate(typeof(EventHandler), config.ParentControl, config.EventHandler.Method);
            button.GetType().GetEvent("Click").AddEventHandler(button,dlg);
            return button;
        }

        public static Panel PanelComponent(PanelConfig config)
        {
            var panel = new Panel();
            panel.Name = config.Name;
            panel.Top = config.Top;
            panel.Left = config.Left;
            panel.Width = config.Width;
            panel.Height = config.Height;
            return panel;
        }
    }
}