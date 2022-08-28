using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DataGridComponent
{
    public class XmlManipulation
    {
        public static List<ItemInfo> XMLload()
        {
            List<ItemInfo> itemInfoList = new List<ItemInfo>();
            try
            {
                string xmlPath = @"C:\ProgramData\XMLData\test.xml";
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

        public static void XMLSave(PanelInfo panelInfo)
        {
            try
            {                
                string xmlPath = @"C:\ProgramData\XMLData\test.xml";
                XmlSerializer serialiserinfo = new XmlSerializer(typeof(List<ItemInfo>));
                TextWriter Filestreaminfo = new StreamWriter(xmlPath);
                serialiserinfo.Serialize(Filestreaminfo, panelInfo.ItemList);
                Filestreaminfo.Close();
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                string xmlDirectoryName = @"C:\ProgramData\XMLData\";
                Directory.CreateDirectory(xmlDirectoryName);
            }
            catch (System.IO.FileNotFoundException)
            {

            }
        }
    }
}