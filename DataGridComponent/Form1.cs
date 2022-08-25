using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridComponent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataGridView dataGridView = new DataGridView();
        private TextBox nameTextBox;
        private TextBox ipAddressTextBox;
        private Button createRowButton;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(dataGridView);
            nameTextBox = TextBoxComponent(300, 0);
            this.Controls.Add(nameTextBox);
            ipAddressTextBox = TextBoxComponent(400, 0);
            this.Controls.Add(ipAddressTextBox);
            createRowButton = ButtonComponent("Create",300,300,Button_Clicked);
            this.Controls.Add(createRowButton);
        }

        public TextBox TextBoxComponent(int top, int left)
        {
            var textBox = new TextBox();
            textBox.Top = top;
            textBox.Left = left;
            return textBox;
        }
        public Button ButtonComponent(string textName,int top,int left,EventHandler execute)
        {
            var button = new Button();
            button.Text = textName;
            button.Top = top;
            button.Left = left;
            var dlg = Delegate.CreateDelegate(typeof(EventHandler), this, execute.Method);
            button.GetType().GetEvent("Click").AddEventHandler(button,dlg);
            return button;
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            CreateRow(new STBInfo(nameTextBox.Text,ipAddressTextBox.Text));
            foreach ( TextBox tb in this.Controls.OfType<TextBox>()) {
               tb.Text = String.Empty; 
            } 
        }

        public List<STBInfo> stbList = new List<STBInfo>();

        public void CreateRow(STBInfo stbInfo)
        {
            stbList.Add(stbInfo);
            dataGridView.DataSource = null;
            dataGridView.DataSource = stbList;
        }

        public void ReadRow()
        {
            
        }

        public void UpdateRow()
        {
            
        }

        public void DeleteRow()
        {
            
        }
    }

    public class STBInfo
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public STBInfo(string name,string ipAddress)
        {
            this.Name = name;
            this.IPAddress = ipAddress;
        }
    }
}
