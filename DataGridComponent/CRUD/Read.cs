using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataGridComponent
{
    public class Read
    {
        public static void ReadRow(STBInfo stbInfo, Form form)
        {
            foreach (Control c in form.Controls)
            {
                if (c.Name == "nameTextBox")
                {
                    c.Text = stbInfo.Name;
                }
                else if (c.Name == "ipAddressTextBox")
                {
                    c.Text = stbInfo.IPAddress;
                }
            }
        }
    }
}