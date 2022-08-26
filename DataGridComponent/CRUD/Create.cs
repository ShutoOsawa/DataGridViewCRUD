using System.Collections.Generic;
using System.Windows.Forms;

namespace DataGridComponent
{
    public class Create
    {
        public static List<ItemInfo> CreateRow(ItemInfo itemInfo, List<ItemInfo> itemList)
        {
            var errMsg = itemInfo.Validation();

            if (errMsg != "")
            {
                MessageBox.Show("�������l����͂��Ă��������B",
                    "�G���[",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                itemList.Add(itemInfo);
            }

            return itemList;
        }

    }
}