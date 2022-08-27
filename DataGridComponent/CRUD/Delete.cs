using System.Collections.Generic;

namespace DataGridComponent
{
    public class Delete
    {
        public static List<ItemInfo> DeleteRow(int index, List<ItemInfo> itemList)
        {
            if (itemList.Count > 0 || itemList!=null)
            {
                itemList.RemoveAt(index);
            }
            return itemList;
        }
    }
}