using BCiProt.Model;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;

namespace BCiProt.HelperClasses
{
    public static class TreeViewToXml
    {
        //TreeView treeview
        //string filename;
        //#region Treeview Population

        ////Open the XML file, and start to populate the treeview
        //private void populateTreeview()
        //{
        //    OpenFileDialog dlg = new OpenFileDialog();
        //    dlg.Title = "Open XML Document";
        //    dlg.Filter = "XML Files (*.xml)|*.xml";
        //    dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    if (dlg.ShowDialog() == true)
        //    {
        //        filename = dlg.FileName.ToString();
        //        try
        //        {
        //            //Just a good practice -- change the cursor to a wait cursor while the nodes populate
        //           // this.Cursor = Cursors.WaitCursor;

        //            //First, we'll load the Xml document
        //            XmlDocument xDoc = new XmlDocument();
        //            xDoc.Load(dlg.FileName);

        //            //Now, clear out the treeview, and add the first (root) node
        //            treeview1.Nodes.Clear();
        //            treeview1.Nodes.Add(new TreeNode(xDoc.DocumentElement.Name));
        //            TreeNode tNode = new TreeNode();
        //            tNode = (TreeNode)treeView1.Nodes[0];

        //            //We make a call to AddNode, where we'll add all of our nodes
        //            addTreeNode(xDoc.DocumentElement, tNode);

        //            //Expand the treeview to show all nodes
        //            treeView1.ExpandAll();

        //        }
        //        catch (XmlException xExc) //Exception is thrown is there is an error in the Xml
        //        {
        //            MessageBox.Show(xExc.Message);
        //        }
        //        catch (Exception ex) //General exception
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //        finally
        //        {
        //            this.Cursor = Cursors.Default; //Change the cursor back
        //        }
        //    }
        //}

        ////This function is called recursively until all nodes are loaded
        //private void addTreeNode(XmlNode xmlNode, TreeNode treeNode)
        //{
        //    XmlNode xNode;
        //    TreeNode tNode;
        //    XmlNodeList xNodeList;

        //    if (xmlNode.HasChildNodes) //The current node has children
        //    {
        //        xNodeList = xmlNode.ChildNodes;

        //        for (int x = 0; x <= xNodeList.Count - 1; x++) //Loop through the child nodes
        //        {
        //            xNode = xmlNode.ChildNodes[x];
        //            treeNode.Nodes.Add(new TreeNode(xNode.Name));
        //            tNode = treeNode.Nodes[x];
        //            addTreeNode(xNode, tNode);
        //        }
        //    }
        //    else //No children, so add the outer xml (trimming off whitespace)
        //        treeNode.Text = xmlNode.OuterXml.Trim();
        //}

        //#endregion

        //#region XML Writer Methods

        //private void serializeTreeview2()
        //{
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    dlg.FileName = this.treeView1.Nodes[0].Text + ".xml";
        //    dlg.Filter = "XML Files (*.xml)|*.xml";
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        exportToXml2(treeView1, dlg.FileName);
        //    }
        //}

        ////We use this in the exportToXml2 and the saveNode2 functions, though it's only instantiated once.
        //private XmlTextWriter xr;

        //public void exportToXml2(TreeView tv, string filename)
        //{
        //    xr = new XmlTextWriter(filename, System.Text.Encoding.UTF8);

        //    xr.WriteStartDocument();
        //    //Write our root node
        //    xr.WriteStartElement(treeView1.Nodes[0].Text);
        //    foreach (TreeNode node in tv.Nodes)
        //    {
        //        saveNode2(node.Nodes);
        //    }
        //    //Close the root node
        //    xr.WriteEndElement();
        //    xr.Close();
        //}

        //private void saveNode2(TreeNodeCollection tnc)
        //{
        //    foreach (TreeNode node in tnc)
        //    {
        //        //If we have child nodes, we'll write a parent node, then iterrate through
        //        //the children
        //        if (node.Nodes.Count > 0)
        //        {
        //            xr.WriteStartElement(node.Text);
        //            saveNode2(node.Nodes);
        //            xr.WriteEndElement();
        //        }
        //        else //No child nodes, so we just write the text
        //        {
        //            xr.WriteString(node.Text);
        //        }
        //    }
        //}

        //#endregion

        //#region Stream Writer Methods

        ////Opens a save file dialog so we know where to save the XML. This method uses a streamwriter.
        //private void serializeTreeview()
        //{
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    dlg.FileName = this.treeView1.Nodes[0].Text + ".xml";
        //    dlg.Filter = "XML Files (*.xml)|*.xml";
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        exportToXml(treeView1, dlg.FileName);
        //    }
        //}

        ////We use this in the export and the saveNode functions, though it's only instantiated once.
        //private StreamWriter sr;

        //public void exportToXml(TreeView tv, string filename)
        //{
        //    sr = new StreamWriter(filename, false, System.Text.Encoding.UTF8);
        //    //Write the header
        //    sr.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        //    //Write our root node
        //    sr.WriteLine("<" + treeView1.Nodes[0].Text + ">");
        //    foreach (TreeNode node in tv.Nodes)
        //    {
        //        saveNode(node.Nodes);
        //    }
        //    //Close the root node
        //    sr.WriteLine("</" + treeView1.Nodes[0].Text + ">");
        //    sr.Close();
        //}

        //private void saveNode(TreeNodeCollection tnc)
        //{
        //    foreach (TreeNode node in tnc)
        //    {
        //        //If we have child nodes, we'll write a parent node, then iterrate through
        //        //the children
        //        if (node.Nodes.Count > 0)
        //        {
        //            sr.WriteLine("<" + node.Text + ">");
        //            saveNode(node.Nodes);
        //            sr.WriteLine("</" + node.Text + ">");
        //        }
        //        else //No child nodes, so we just write the text
        //        {
        //            sr.WriteLine(node.Text);
        //        }
        //    }
        //}

        //#endregion


        //static XmlDocument xmlDocument;


        //public static void treeviewToXml(List<TreeModel> tv, string path)
        //{
        //    xmlDocument = new XmlDocument();
        //    xmlDocument.AppendChild(xmlDocument.CreateElement("ROOT"));

        //    //XmlRekursivExport(xmlDocument.DocumentElement, tv, path);
        //    xmlDocument.Save(path);
        //}

        //[System.Xml.Serialization.XmlInclude(typeof(TreeModel))] // type and nodes<>
        //[System.Xml.Serialization.XmlInclude(typeof(TreeNode))] //controltype, controlvalue, filepath

        //public static void SerializeObjectToXML<T>(string FilePath, List<TreeModel> treeNodeCollection)
        //{
        //    foreach (var item in treeNodeCollection)
        //    {
        //        if (item.Nodes.Count() == 0)
        //        {
        //            xmlDocument.AppendChild(xmlDocument.CreateElement(item.Type));
        //        }
        //        else
        //        {
        //            using (StreamWriter wr = new StreamWriter(FilePath))
        //            {
        //                xs.Serialize(wr, item);
        //            }
        //        }
        //    }
        //}

    }
}