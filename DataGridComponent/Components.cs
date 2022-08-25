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
        public static Button ButtonComponent(string textName,int top,int left,Form form,EventHandler execute)
        {
            var button = new Button();
            button.Text = textName;
            button.Top = top;
            button.Left = left;
            var dlg = Delegate.CreateDelegate(typeof(EventHandler), form, execute.Method);
            button.GetType().GetEvent("Click").AddEventHandler(button,dlg);
            return button;
        }
    }
}