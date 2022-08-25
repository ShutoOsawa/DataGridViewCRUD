using System.Collections.Generic;

namespace DataGridComponent
{
    public class Create
    {
        public static List<STBInfo> CreateRow(STBInfo stbInfo,List<STBInfo> stbList)
        {
            stbList.Add(stbInfo);
            return stbList;
        }

    }
}