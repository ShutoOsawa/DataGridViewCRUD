using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DataGridComponent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public PanelInfo panelInfo = new PanelInfo();
        DataGridView dataGridView = new DataGridView();
        public List<TextBox> textBoxList = new List<TextBox>();
        private TextBox nameTextBox;
        private Label nameLabel;
        private Label ipAddressLabel;
        private TextBox ipAddressTextBox;
        private Button createRowButton;
        private Button deleteRowButton;
        private Button updateRowButton;
        private Panel namePanel;
        private Panel ipAddressPanel;

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Controls.Add(dataGridView);
            dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClicked);

            namePanel = Components.PanelComponent(300, 0, 250, 20);
            namePanel.BackColor = Color.Aqua;
            this.Controls.Add(namePanel);
            panelInfo.PanelList.Add(namePanel);

            nameLabel = Components.LabelComponent("Name", 0, 0);
            nameLabel.Name = "nameLabel";
            namePanel.Controls.Add(nameLabel);

            nameTextBox = Components.TextBoxComponent(0, 100);
            nameTextBox.Name = "Name";
            namePanel.Controls.Add(nameTextBox);
            textBoxList.Add(nameTextBox);

            ipAddressPanel = Components.PanelComponent(350, 0, 250, 20);
            ipAddressPanel.BackColor = Color.Aqua;
            this.Controls.Add(ipAddressPanel);
            panelInfo.PanelList.Add(ipAddressPanel);

            ipAddressLabel = Components.LabelComponent("IP Address", 0, 0);
            ipAddressLabel.Name = "ipAddressLabel";
            ipAddressPanel.Controls.Add(ipAddressLabel);

            ipAddressTextBox = Components.TextBoxComponent(0, 100);
            ipAddressTextBox.Name = "IPAddress";
            ipAddressPanel.Controls.Add(ipAddressTextBox);
            textBoxList.Add(ipAddressTextBox);

            CreateButtons();
        }


        public void CreateButtons()
        {
            createRowButton = Components.ButtonComponent("Create", 300, 300, this, Button_Clicked_Create);
            createRowButton.Name = "createRowButton";
            this.Controls.Add(createRowButton);

            deleteRowButton = Components.ButtonComponent("Delete", 350, 300, this, Button_Clicked_Delete);
            deleteRowButton.Name = "deleteRowButton";
            this.Controls.Add(deleteRowButton);

            updateRowButton = Components.ButtonComponent("Update", 400, 300, this, Button_Clicked_Update);
            updateRowButton.Name = "updateRowButton";
            this.Controls.Add(updateRowButton);
        }

        private void DataGridView_CellClicked(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;
            Read.ReadRow(panelInfo.ItemList[index], panelInfo);
        }

        private void Button_Clicked_Delete(object sender, EventArgs e)
        {
            if (panelInfo.ItemList.Count > 0)
            {
                panelInfo.ItemList = Delete.DeleteRow(dataGridView.CurrentCell.RowIndex, panelInfo.ItemList);
                UpdateDataGridView(panelInfo.ItemList);
                UpdateTextBoxes();
            }
        }

        private List<Dictionary<string, string>> dictList = new List<Dictionary<string, string>>();
        private void CreateDictionary()
        {
            var dict = new Dictionary<string, string>();
            foreach (Panel panel in panelInfo.PanelList)
            {
                foreach (var textBox in panel.Controls.OfType<TextBox>())
                {
                    dict.Add(textBox.Name, textBox.Text);
                }
            }
            dictList.Add(dict);
        }

        private static T DictionaryToObject<T>(IDictionary<string, string> dict) where T : new()
        {
            var t = new T();
            PropertyInfo[] properties = t.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (!dict.Any(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                    continue;

                KeyValuePair<string, string> item = dict.First(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));

                // Find which property type (int, string, double? etc) the CURRENT property is...
                Type tPropertyType = t.GetType().GetProperty(property.Name).PropertyType;

                // Fix nullables...
                Type newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;

                // ...and change the type
                object newA = Convert.ChangeType(item.Value, newT);
                t.GetType().GetProperty(property.Name).SetValue(t, newA, null);
            }
            return t;
        }


        private void Button_Clicked_Create(object sender, EventArgs e)
        {
            CreateDictionary();
            ItemInfo itemInfo = DictionaryToObject<ItemInfo>(dictList[dictList.Count - 1]);
            panelInfo.ItemList = Create.CreateRow(itemInfo, panelInfo.ItemList);
            UpdateDataGridView(panelInfo.ItemList);
            UpdateTextBoxes();
        }

        private void Button_Clicked_Update(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;
            ItemInfo item = panelInfo.ItemList[index];
            item = UpdateInfo.UpdateRow(item, panelInfo);
            UpdateDataGridView(panelInfo.ItemList);
        }

        public void UpdateDataGridView(List<ItemInfo> itemList)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = itemList;
        }

        public void UpdateTextBoxes()
        {
            foreach (Panel panel in panelInfo.PanelList)
            {
                foreach (var textBox in panel.Controls.OfType<TextBox>())
                {
                    textBox.Text = String.Empty;
                }
            }
        }


    }
}


