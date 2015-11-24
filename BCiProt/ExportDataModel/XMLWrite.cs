using BCiProt.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace BCiProt.ExportDataModel
{
    public class XMLWrite
    {
        // At the moment this will remain standar, so as I can test the xml easily.
        static string path = "C:\\Users\\Elisavet\\Desktop\\elly.xml";

        public static void WriteToXML(TreeModel t)
        {
            try
            {
                StringWriterUtf8 sw = new StringWriterUtf8();
                XmlTextWriter XMLtw = new XmlTextWriter(path, Encoding.UTF8);

                XMLtw.Formatting = Formatting.Indented;
                XMLtw.Indentation = 2;
                XMLtw.WriteStartDocument();
                XMLtw.WriteStartElement("Profile");
                foreach (var i in t.Nodes)
                {
                    XMLtw.WriteAttributeString(i.controlType, i.controlValue);
                }
                XMLtw.WriteStartElement("Video_Profile");
                XMLtw.WriteEndElement();
                XMLtw.WriteStartElement("Transport");
                XMLtw.WriteEndElement();
                XMLtw.WriteEndElement();
                XMLtw.WriteEndDocument();
                XMLtw.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Something went so wrong !" + exc.Message);
            }
        }
    }

	public class StringWriterUtf8 : System.IO.StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}


//OR
//XmlWriter xmlWriter = XmlWriter.Create(path);

//xmlWriter.WriteStartDocument();
//xmlWriter.WriteStartElement("users");

//xmlWriter.WriteStartElement("user");
//xmlWriter.WriteAttributeString("age", "42");
//xmlWriter.WriteString("John Doe");
//xmlWriter.WriteEndElement();

//xmlWriter.WriteStartElement("user");
//xmlWriter.WriteAttributeString("age", "39");
//xmlWriter.WriteString("Jane Doe");

//xmlWriter.WriteEndDocument();
//xmlWriter.Close();

//OR
//XmlDocument xmlDoc = new XmlDocument();
//XmlNode rootNode = xmlDoc.CreateElement("users");
//xmlDoc.AppendChild(rootNode);

//XmlNode userNode = xmlDoc.CreateElement("user");
//XmlAttribute attribute = xmlDoc.CreateAttribute("age");
//attribute.Value = "42";
//userNode.Attributes.Append(attribute);
//userNode.InnerText = "John Doe";
//rootNode.AppendChild(userNode);

//userNode = xmlDoc.CreateElement("user");
//attribute = xmlDoc.CreateAttribute("age");
//attribute.Value = "39";
//userNode.Attributes.Append(attribute);
//userNode.InnerText = "Jane Doe";
//rootNode.AppendChild(userNode);

//xmlDoc.Save(path);