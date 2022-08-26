using System.Collections.Generic;

namespace DataGridComponent
{
    public class Create
    {
        public static List<ItemInfo> CreateRow(ItemInfo itemInfo, List<ItemInfo> itemList)
        {
            itemList.Add(itemInfo);
            return itemList;
        }

    }
}