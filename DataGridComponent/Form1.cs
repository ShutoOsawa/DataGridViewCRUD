using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

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
            dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClicked);
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

            Panel namePanel = Components.PanelComponent(300, 20, 250, 20);

            this.Controls.Add(namePanel);
            panelInfo.PanelList.Add(namePanel);

            Label nameLabel = Components.LabelComponent("Name", 0, 0);
            nameLabel.Name = "nameLabel";
            namePanel.Controls.Add(nameLabel);

            TextBox nameTextBox = Components.TextBoxComponent(0, 100);
            nameTextBox.Name = "Name";
            namePanel.Controls.Add(nameTextBox);
            textBoxList.Add(nameTextBox);

            Panel ipAddressPanel = Components.PanelComponent(350, 20, 250, 20);

            this.Controls.Add(ipAddressPanel);
            panelInfo.PanelList.Add(ipAddressPanel);

            Label ipAddressLabel = Components.LabelComponent("IP Address", 0, 0);
            ipAddressLabel.Name = "ipAddressLabel";
            ipAddressPanel.Controls.Add(ipAddressLabel);

            TextBox ipAddressTextBox = Components.TextBoxComponent(0, 100);
            ipAddressTextBox.Name = "IPAddress";
            ipAddressPanel.Controls.Add(ipAddressTextBox);
            textBoxList.Add(ipAddressTextBox);

            Panel locationPanel = Components.PanelComponent(250, 20, 250, 20);

            this.Controls.Add(locationPanel);
            panelInfo.PanelList.Add(locationPanel);

            Label locationLabel = Components.LabelComponent("Location", 0, 0);
            locationLabel.Name = "locationLabel";
            locationPanel.Controls.Add(locationLabel);

            TextBox locationTextBox = Components.TextBoxComponent(0, 100);
            locationTextBox.Name = "Location";
            locationPanel.Controls.Add(locationTextBox);
            textBoxList.Add(locationTextBox);

            CreateButtons();

            
        }

        
        public void CreateButtons()
        {
            var createButtonDict = new Dictionary<string, object>()
            {
                {"Left",300},
                {"Top",250},
                {"Form", this},
                {"EventHandler",(EventHandler)Button_Clicked_Create},
                {"Text", "Create"},
                {"Name", "createRowButton"}
            };
            var createButtonConfig = new ButtonConfig(createButtonDict);
            
            Button createRowButton = Components.ButtonComponent(createButtonConfig);
            this.Controls.Add(createRowButton);

            var deleteButtonDict = new Dictionary<string, object>()
            {
                {"Left",300},
                {"Top",300},
                {"Form", this},
                {"EventHandler",(EventHandler)Button_Clicked_Delete},
                {"Text", "Delete"},
                {"Name", "deleteRowButton"}
            };
            var deleteButtonConfig = new ButtonConfig(deleteButtonDict);
            var deleteRowButton = Components.ButtonComponent(deleteButtonConfig);
            this.Controls.Add(deleteRowButton);

            var updateButtonDict = new Dictionary<string, object>()
            {
                {"Left",300},
                {"Top",350},
                {"Form", this},
                {"EventHandler",(EventHandler)Button_Clicked_Update},
                {"Text", "Update"},
                {"Name", "updateRowButton"}
            };
            var updateButtonConfig = new ButtonConfig(updateButtonDict);
            var updateRowButton = Components.ButtonComponent(updateButtonConfig);
            this.Controls.Add(updateRowButton);

            var saveButtonDict = new Dictionary<string, object>()
            {
                {"Left",400},
                {"Top",300},
                {"Form", this},
                {"EventHandler",(EventHandler)Button_Clicked_Save},
                {"Text", "Save"},
                {"Name", "saveRowButton"}
            };
            var saveButtonConfig = new ButtonConfig(saveButtonDict);
            var saveRowButton = Components.ButtonComponent(saveButtonConfig);
            this.Controls.Add(saveRowButton);

            var loadButtonDict = new Dictionary<string, object>()
            {
                {"Left",400},
                {"Top",350},
                {"Form", this},
                {"EventHandler",(EventHandler)Button_Clicked_Load},
                {"Text", "Load"},
                {"Name", "loadRowButton"}
            };
            var loadButtonConfig = new ButtonConfig(loadButtonDict);
            var loadRowButton = Components.ButtonComponent(loadButtonConfig);
            this.Controls.Add(loadRowButton);
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
            if (panelInfo.ItemList.Count > 0 || panelInfo.ItemList != null)
            {
                panelInfo.ItemList = Delete.DeleteRow(dataGridView.CurrentCell.RowIndex, panelInfo.ItemList);
                UpdateDataGridView(panelInfo.ItemList);
                UpdateTextBoxes();
            }
        }

        private void Button_Clicked_Load(object sender, EventArgs e)
        {
            panelInfo.ItemList = XMLload();
            UpdateDataGridView(panelInfo.ItemList);
        }

        public List<ItemInfo> XMLload()
        {
            List<ItemInfo> itemInfoList = new List<ItemInfo>();
            try
            {
                string projectPath = xmlPath;
                XmlSerializer panelSerializerinfo = new XmlSerializer(typeof(List<ItemInfo>));

                StreamReader panelStreamReaderinfo = new StreamReader(projectPath);

                itemInfoList =
                    (List<ItemInfo>)panelSerializerinfo.Deserialize(panelStreamReaderinfo);
                panelStreamReaderinfo.Close();
            }
            catch (System.IO.DirectoryNotFoundException)
            {

            }
            catch (System.IO.FileNotFoundException)
            {

            }
            return itemInfoList;

        }

        private string xmlFileName = "test.xml";
        private string xmlDirectoryName = @"C:\ProgramData\XMLData\";
        private string xmlPath = @"C:\ProgramData\XMLData\test.xml";
        public void XMLSave()
        {
            try
            {
                
                XmlSerializer serialiserinfo = new XmlSerializer(typeof(List<ItemInfo>));
                TextWriter Filestreaminfo = new StreamWriter(xmlPath);
                serialiserinfo.Serialize(Filestreaminfo, panelInfo.ItemList);
                Filestreaminfo.Close();
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                Directory.CreateDirectory(xmlDirectoryName);
            }
            catch (System.IO.FileNotFoundException)
            {

            }
        }

        private void Button_Clicked_Save(object sender, EventArgs e)
        {
            XMLSave();
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
            if (panelInfo.ItemList.Count() > 0)
            {
                int index = dataGridView.CurrentCell.RowIndex;
                ItemInfo item = panelInfo.ItemList[index];
                item = UpdateInfo.UpdateRow(item, panelInfo);
                panelInfo.ItemList[index] = item;
                UpdateDataGridView(panelInfo.ItemList);
            }
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

    public static class ValidateExt
    {
        public static string Validation<T>(this T obj) where T : class
        {
            var msg = new StringBuilder();
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                foreach (var attr in prop.GetCustomAttributes())
                {
                    switch (attr)
                    {
                        case Required at:
                            if (prop.GetValue(obj) == null || prop.GetValue(obj) == "")
                                msg.AppendLine($"{prop.Name}:error");
                            break;

                        case StringMaximum at:
                            if (prop.GetValue(obj).ToString().Length > at.Maximum)
                                msg.AppendLine($"{prop.Name}:error");
                            break;
                    }
                }
            }

            return msg.ToString();
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


