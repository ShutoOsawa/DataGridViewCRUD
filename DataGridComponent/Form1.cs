using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
        private Dictionary<string, object> panelDict = new Dictionary<string, object>();
        public void DataGridViewConfig()
        {
            this.Controls.Add(dataGridView);
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
            DataGridViewConfig();

            var buttonDict = new Dictionary<string, object>()
            {
                { "Create", (EventHandler)Button_Clicked_Create },
                { "Delete", (EventHandler)Button_Clicked_Delete },
                { "Update", (EventHandler)Button_Clicked_Update },
                { "Save", (EventHandler)Button_Clicked_Save },
                { "Load", (EventHandler)Button_Clicked_Load },
                { "Form", this }
            };

            ButtonComponents(ButtonConfig.SetButtonConfig(buttonDict));
            panelDict["Form"] = this;
            PanelComponents(PanelConfig.SetPanelConfig(panelDict));
            TextBoxComponents(TextBoxConfig.SetTextBoxConfig(panelDict));
            LabelComponents(LabelConfig.SetLabelConfig(panelDict));
        }

        public void PanelComponents(List<Dictionary<string, object>> panelDictList)
        {
            foreach (var item in panelDictList)
            {
                var panel = Components.PanelComponent(item);
                this.Controls.Add(panel);
                panelDict[panel.Name] = panel;
                panelInfo.PanelList.Add(panel);
            }
        }

        public void ButtonComponents(List<Dictionary<string, object>> buttonDictList)
        {
            foreach (var item in buttonDictList)
            {
                var button = Components.ButtonComponent(item);
                this.Controls.Add(button);
            }
        }

        public void TextBoxComponents(List<Dictionary<string, object>> textBoxDictList)
        {
            foreach (var item in textBoxDictList)
            {
                var textBox = Components.TextBoxComponent(item);
                Panel panel = (Panel)item["Panel"];
                panel.Controls.Add(textBox);
            }
        }

        public void LabelComponents(List<Dictionary<string, object>> labelDictList)
        {
            foreach (var item in labelDictList)
            {
                var label = Components.LabelComponent(item);
                Panel panel = (Panel)item["Panel"];
                panel.Controls.Add(label);
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
                UpdateTextBoxes(panelInfo);
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
            ItemInfo itemInfo = DictionaryToObject(CreateDictionary());
            panelInfo.ItemList = Create.CreateRow(itemInfo, panelInfo.ItemList);
            UpdateDataGridView(panelInfo);
            UpdateTextBoxes(panelInfo);
        }
        private Dictionary<string, string> CreateDictionary()
        {
            var dict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, object> item in panelDict)
            {
                if (item.Key != "Form")
                {
                    Panel panel = (Panel)item.Value;
                    foreach (var textBox in panel.Controls.OfType<TextBox>())
                    {
                        //dict.Add(textBox.Name, textBox.Text);
                        dict[textBox.Name] = textBox.Text;
                    }
                }
            }
            return dict;
        }

        private void Button_Clicked_Update(object sender, EventArgs e)
        {
            if (panelInfo.ItemList.Count > 0 && dataGridView.CurrentCell!=null)
            {
                int index = dataGridView.CurrentCell.RowIndex;
                ItemInfo item = panelInfo.ItemList[index];
                item = UpdateInfo.UpdateRow(item, panelInfo);
                panelInfo.ItemList[index] = item;
                UpdateDataGridView(panelInfo);
            }
        }


        private ItemInfo DictionaryToObject(IDictionary<string, string> dict)
        {
            var itemInfo = new ItemInfo();
            PropertyInfo[] properties = itemInfo.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (!dict.Any(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                    continue;

                KeyValuePair<string, string> item = dict.First(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));

                // Find which property type (int, string, double? etc) the CURRENT property is...
                Type tPropertyType = itemInfo.GetType().GetProperty(property.Name).PropertyType;

                // Fix nullables...
                Type newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;

                // ...and change the type
                object newA = Convert.ChangeType(item.Value, newT);
                itemInfo.GetType().GetProperty(property.Name).SetValue(itemInfo, newA, null);
            }
            return itemInfo;
        }

        public void UpdateDataGridView(PanelInfo panelInfo)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = panelInfo.ItemList;
        }

        public void UpdateTextBoxes(PanelInfo panelInfo)
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


