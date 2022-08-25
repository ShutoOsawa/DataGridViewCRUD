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
        private TextBox nameTextBox = new TextBox();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(dataGridView);
            nameTextBox.Top = 300;
            this.Controls.Add(nameTextBox);
            
            Button createRowButton = ButtonComponent(new EventHandler(Button_Clicked));
            
            this.Controls.Add(createRowButton);
        }
        public Button ButtonComponent(EventHandler execute)
        {
            Button button = new Button();
            button.Text = "Create";
            button.Top = 300;
            button.Left = 300;
            var dlg = Delegate.CreateDelegate(typeof(EventHandler), this, execute.Method);
            button.GetType().GetEvent("Click").AddEventHandler(button,dlg);
            return button;
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            CreateRow(new STBInfo(nameTextBox.Text));
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

        public STBInfo(string name)
        {
            this.Name = name;
        }
    }
}
