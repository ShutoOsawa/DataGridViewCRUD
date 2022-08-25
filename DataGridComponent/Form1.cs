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
        
        public List<STBInfo> stbList = new List<STBInfo>();
        DataGridView dataGridView = new DataGridView();
        private TextBox nameTextBox;
        private Label nameLabel;
        private TextBox ipAddressTextBox;
        private Button createRowButton;
        private Button deleteRowButton;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(dataGridView);
            nameLabel = Components.LabelComponent("Name",300, 0); 
            this.Controls.Add(nameLabel);
            nameTextBox = Components.TextBoxComponent(300, 100);
            this.Controls.Add(nameTextBox);
            nameLabel = Components.LabelComponent("IP Address",400, 0); 
            this.Controls.Add(nameLabel);
            ipAddressTextBox = Components.TextBoxComponent(400, 100);
            this.Controls.Add(ipAddressTextBox);
            createRowButton = Components.ButtonComponent("Create",300,300,this,Button_Clicked_Create);
            this.Controls.Add(createRowButton);
            deleteRowButton = Components.ButtonComponent("Delete",400,300,this,Button_Clicked_Delete);
            this.Controls.Add(deleteRowButton);
        }
        
        private void Button_Clicked_Delete(object sender, EventArgs e)
        {
            if (stbList.Count > 0)
            {
                stbList = Delete.DeleteRow(dataGridView.CurrentCell.RowIndex, stbList);
                dataGridView.DataSource = null;
                dataGridView.DataSource = stbList;
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                {
                    tb.Text = String.Empty;
                }
            }
        }
        private void Button_Clicked_Create(object sender, EventArgs e)
        {
            stbList = Create.CreateRow(new STBInfo(nameTextBox.Text,ipAddressTextBox.Text),stbList);
            dataGridView.DataSource = null;
            dataGridView.DataSource = stbList;
            foreach ( TextBox tb in this.Controls.OfType<TextBox>()) {
               tb.Text = String.Empty; 
            } 
        }
    }
}


