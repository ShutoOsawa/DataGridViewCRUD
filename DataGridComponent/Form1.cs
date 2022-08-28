using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

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
        public void DataGridViewConfig()
        {
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.CellClick += DataGridView_CellClicked;
            dataGridView.Width = 500;
            dataGridView.Height = 200;
            dataGridView.ReadOnly = true;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.ColumnHeadersVisible = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.DataSource = null;
            dataGridView.DataSource = new List<ItemInfo>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Controls.Add(dataGridView);
            DataGridViewConfig();

            //TextBoxName and Object Property Variable Name needs to match
            //Panel namePanel = Components.PanelComponent(300, 20, 250, 20);
            //this.Controls.Add(namePanel);
            //panelInfo.PanelList.Add(namePanel);

            //Label nameLabel = Components.LabelComponent("Name", 0, 0);
            //nameLabel.Name = "nameLabel";
            //namePanel.Controls.Add(nameLabel);

            //TextBox nameTextBox = Components.TextBoxComponent(0, 100);
            //nameTextBox.Name = "Name";
            //namePanel.Controls.Add(nameTextBox);
            //textBoxList.Add(nameTextBox);

            //Panel ipAddressPanel = Components.PanelComponent(350, 20, 250, 20);

            //this.Controls.Add(ipAddressPanel);
            //panelInfo.PanelList.Add(ipAddressPanel);

            //Label ipAddressLabel = Components.LabelComponent("IP Address", 0, 0);
            //ipAddressLabel.Name = "ipAddressLabel";
            //ipAddressPanel.Controls.Add(ipAddressLabel);

            //TextBox ipAddressTextBox = Components.TextBoxComponent(0, 100);
            //ipAddressTextBox.Name = "IPAddress";
            //ipAddressPanel.Controls.Add(ipAddressTextBox);
            //textBoxList.Add(ipAddressTextBox);

            //Panel locationPanel = Components.PanelComponent(250, 20, 250, 20);

            //this.Controls.Add(locationPanel);
            //panelInfo.PanelList.Add(locationPanel);

            //Label locationLabel = Components.LabelComponent("Location", 0, 0);
            //locationLabel.Name = "locationLabel";
            //locationPanel.Controls.Add(locationLabel);

            //TextBox locationTextBox = Components.TextBoxComponent(0, 100);
            //locationTextBox.Name = "Location";
            //locationPanel.Controls.Add(locationTextBox);
            //textBoxList.Add(locationTextBox);

            ButtonComponents(SetButtonConfig());

            PanelComponents(SetPanelConfig());

            TextBoxComponents(SetTextBoxConfig());

            LabelComponents(SetLabelConfig());

        }


        public List<Dictionary<string, object>> SetTextBoxConfig()
        {
            var dictList = new List<Dictionary<string, object>>();
            var nameTextBoxDict = new Dictionary<string, object>()
            {
                {"Left",100},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["NamePanel"]},
                {"Name", "NameTextBox"}
            };
            dictList.Add(nameTextBoxDict);

            var ipAddressTextBoxDict = new Dictionary<string, object>()
            {
                {"Left",100},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["IPAddressPanel"]},
                {"Name", "IPAddressTextBox"}
            };
            dictList.Add(ipAddressTextBoxDict);
            var locationTextBoxDict = new Dictionary<string, object>()
            {
                {"Left",100},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["LocationPanel"]},
                {"Name", "LocationTextBox"}
            };
            dictList.Add(locationTextBoxDict);

            return dictList;
        }

        public List<Dictionary<string, object>> SetLabelConfig()
        {
            var dictList = new List<Dictionary<string, object>>();
            var nameLabelDict = new Dictionary<string, object>()
            {
                {"Left",0},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["NamePanel"]},
                {"Name", "NameLabel"},
                {"Text","Name"}
            };
            dictList.Add(nameLabelDict);

            var ipAddressLabelDict = new Dictionary<string, object>()
            {
                {"Left",0},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["IPAddressPanel"]},
                {"Name", "IPAddressLabel"},
                {"Text","IP Address"}
            };
            dictList.Add(ipAddressLabelDict);
            var locationTextBoxDict = new Dictionary<string, object>()
            {
                {"Left",0},
                {"Top",0},
                {"Width",200},
                {"Height",20},
                {"Panel", panelDict["LocationPanel"]},
                {"Name", "LocationLabel"},
                {"Text","Location"}
            };
            dictList.Add(locationTextBoxDict);

            return dictList;
        }

        public List<Dictionary<string, object>> SetPanelConfig()
        {
            var panelDictList = new List<Dictionary<string, object>>();
            var namePanelDict = new Dictionary<string, object>()
            {
                {"Left",20},
                {"Top",250},
                {"Width",300},
                {"Height",20},
                {"Form", this},
                {"Name", "NamePanel"}
            };
            panelDictList.Add(namePanelDict);

            var ipAddressPanelDict = new Dictionary<string, object>()
            {
                {"Left",20},
                {"Top",300},
                {"Width",300},
                {"Height",20},
                {"Form", this},
                {"Name", "IPAddressPanel"}
            };
            panelDictList.Add(ipAddressPanelDict);

            var locationPanelDict = new Dictionary<string, object>()
            {
                {"Left",20},
                {"Top",350},
                {"Width",300},
                {"Height",20},
                {"Form", this},
                {"Name", "LocationPanel"}
            };
            panelDictList.Add(locationPanelDict);

            return panelDictList;
        }


        public List<Dictionary<string, object>> SetButtonConfig()
        {
            var buttonDictList = new List<Dictionary<string, object>>();
            var createButtonDict = new Dictionary<string, object>()
            {
                {"Left",300},
                {"Top",250},
                {"Form", this},
                {"EventHandler",(EventHandler)Button_Clicked_Create},
                {"Text", "Create"},
                {"Name", "createRowButton"}
            };
            buttonDictList.Add(createButtonDict);

            var deleteButtonDict = new Dictionary<string, object>()
            {
                {"Left",300},
                {"Top",300},
                {"Form", this},
                {"EventHandler",(EventHandler)Button_Clicked_Delete},
                {"Text", "Delete"},
                {"Name", "deleteRowButton"}
            };
            buttonDictList.Add(deleteButtonDict);

            var updateButtonDict = new Dictionary<string, object>()
            {
                {"Left",300},
                {"Top",350},
                {"Form", this},
                {"EventHandler",(EventHandler)Button_Clicked_Update},
                {"Text", "Update"},
                {"Name", "updateRowButton"}
            };
            buttonDictList.Add(updateButtonDict);

            var saveButtonDict = new Dictionary<string, object>()
            {
                {"Left",400},
                {"Top",300},
                {"Form", this},
                {"EventHandler",(EventHandler)Button_Clicked_Save},
                {"Text", "Save"},
                {"Name", "saveRowButton"}
            };
            buttonDictList.Add(saveButtonDict);

            var loadButtonDict = new Dictionary<string, object>()
            {
                {"Left",400},
                {"Top",350},
                {"Form", this},
                {"EventHandler",(EventHandler)Button_Clicked_Load},
                {"Text", "Load"},
                {"Name", "loadRowButton"}
            };
            buttonDictList.Add(loadButtonDict);
            return buttonDictList;
        }

        public void PanelComponents(List<Dictionary<string, object>> panelDictList)
        {
            foreach (var item in panelDictList)
            {
                var config = new PanelConfig(item);
                var panel = Components.PanelComponent(config);
                panel.BackColor = Color.Aqua;
                this.Controls.Add(panel);
                panelDict[panel.Name] = panel;
            }
        }

        private Dictionary<string, Panel> panelDict = new Dictionary<string, Panel>(); 
        public void ButtonComponents(List<Dictionary<string, object>> buttonDictList)
        {
            foreach (var item in buttonDictList)
            {
                var config = new ButtonConfig(item);
                var button = Components.ButtonComponent(config);
                this.Controls.Add(button);
            }
        }

        public void TextBoxComponents(List<Dictionary<string, object>> textBoxDictList)
        {
            foreach (var item in textBoxDictList)
            {
                var config = new TextBoxConfig(item);
                var textBox = Components.TextBoxComponent(config);
                config.ParentControl.Controls.Add(textBox);
            }
        }

        public void LabelComponents(List<Dictionary<string, object>> labelDictList)
        {
            foreach (var item in labelDictList)
            {
                var config = new LabelConfig(item);
                var label = Components.LabelComponent(config);
                config.ParentControl.Controls.Add(label);
            }
        }

        private void DataGridView_CellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (panelInfo.ItemList.Count > 0)
            {
                int index = dataGridView.CurrentCell.RowIndex;
                Read.ReadRow(panelInfo.ItemList[index], panelInfo);
            }
        }

        private void Button_Clicked_Delete(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                panelInfo.ItemList = Delete.DeleteRow(dataGridView.CurrentCell.RowIndex, panelInfo.ItemList);
                UpdateDataGridView(panelInfo);
                UpdateTextBoxes();
            }
        }

        private void Button_Clicked_Load(object sender, EventArgs e)
        {
            panelInfo.ItemList = XmlManipulation.XMLload();
            UpdateDataGridView(panelInfo);
        }

        private void Button_Clicked_Save(object sender, EventArgs e)
        {
            XmlManipulation.XMLSave(panelInfo);
        }

        private void Button_Clicked_Create(object sender, EventArgs e)
        {
            CreateDictionary();
            ItemInfo itemInfo = DictionaryToObject<ItemInfo>(dictList[dictList.Count - 1]);
            panelInfo.ItemList = Create.CreateRow(itemInfo, panelInfo.ItemList);
            UpdateDataGridView(panelInfo);
            UpdateTextBoxes();
        }

        private void Button_Clicked_Update(object sender, EventArgs e)
        {
            if (panelInfo.ItemList.Count > 0)
            {
                int index = dataGridView.CurrentCell.RowIndex;
                ItemInfo item = panelInfo.ItemList[index];
                item = UpdateInfo.UpdateRow(item, panelInfo);
                panelInfo.ItemList[index] = item;
                UpdateDataGridView(panelInfo);
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

        public void UpdateDataGridView(PanelInfo panelInfo)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = panelInfo.ItemList;
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

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class Required : Attribute { }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class StringMaximum : Attribute
    {
        public int Maximum { get; set; }
        public StringMaximum(int max)
        {
            Maximum = max;
        }
    }
}


