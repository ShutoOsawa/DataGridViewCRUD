using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace DataGridComponent
{
    public class STBInfo
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public STBInfo(string name,string ipAddress)
        {
            this.Name = name;
            this.IPAddress = ipAddress;
        }
    }
}