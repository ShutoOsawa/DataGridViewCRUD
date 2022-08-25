using System.Collections.Generic;

namespace DataGridComponent
{
    public class Delete
    {
        public static List<STBInfo> DeleteRow(int index,List<STBInfo> stbList)
        {
            if (stbList.Count > 0)
            {
                stbList.RemoveAt(index);
            }
            return stbList;
        }
    }
}