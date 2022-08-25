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
        private Label ipAddressLabel;
        private TextBox ipAddressTextBox;
        private Button createRowButton;
        private Button deleteRowButton;
        private Button updateRowButton;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(dataGridView);
            dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClicked);

            nameLabel = Components.LabelComponent("Name",300, 0);
            nameLabel.Name = "nameLabel";
            this.Controls.Add(nameLabel);

            nameTextBox = Components.TextBoxComponent(300, 100);
            nameTextBox.Name = "nameTextBox";
            this.Controls.Add(nameTextBox);

            ipAddressLabel = Components.LabelComponent("IP Address",400, 0);
            ipAddressLabel.Name = "ipAddressLabel";
            this.Controls.Add(ipAddressLabel);

            ipAddressTextBox = Components.TextBoxComponent(400, 100);
            ipAddressTextBox.Name = "ipAddressTextBox";
            this.Controls.Add(ipAddressTextBox);

            createRowButton = Components.ButtonComponent("Create",300,300,this,Button_Clicked_Create);
            createRowButton.Name = "createRowButton";
            this.Controls.Add(createRowButton);

            deleteRowButton = Components.ButtonComponent("Delete",350,300,this,Button_Clicked_Delete);
            deleteRowButton.Name = "deleteRowButton";
            this.Controls.Add(deleteRowButton);

            updateRowButton = Components.ButtonComponent("Update", 400, 300, this, Button_Clicked_Update);
            updateRowButton.Name = "updateRowButton";
            this.Controls.Add(updateRowButton);
        }

        private void DataGridView_CellClicked(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;
            Read.ReadRow(stbList[index], this);
        }

        private void Button_Clicked_Delete(object sender, EventArgs e)
        {
            if (stbList.Count > 0)
            {
                stbList = Delete.DeleteRow(dataGridView.CurrentCell.RowIndex, stbList);
                UpdateDataGridView(stbList);
                UpdateTextBoxes();
            }
        }
        
        private void Button_Clicked_Create(object sender, EventArgs e)
        {
            stbList = Create.CreateRow(new STBInfo(nameTextBox.Text,ipAddressTextBox.Text),stbList);
            UpdateDataGridView(stbList);
            UpdateTextBoxes();
        }

        private void Button_Clicked_Update(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;
            STBInfo stb = stbList[index];
            stb = UpdateInfo.UpdateRow(stb,this);
            UpdateDataGridView(stbList);
        }

        public void UpdateDataGridView(List<STBInfo> stbList)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = stbList;
        }

        public void UpdateTextBoxes()
        {
            foreach ( TextBox tb in this.Controls.OfType<TextBox>()) {
                tb.Text = String.Empty; 
            } 
        }

      
    }
}


