using System.Windows.Forms;

namespace DataGridComponent
{
    public class UpdateInfo
    {
        public static STBInfo UpdateRow(STBInfo stbInfo,Form form)
        {
            foreach (Control c in form.Controls)
            {
                if (c.Name == "nameTextBox")
                {
                     stbInfo.Name= c.Text;
                }
                else if (c.Name == "ipAddressTextBox")
                {
                     stbInfo.IPAddress=c.Text;
                }
            }

            return stbInfo;
        }
    }
}