using BCiProt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCiProt.HelperClasses
{
    /// <summary>
    /// This class holds all the general methods that are used in the GUI.
    /// This class is static and all of it's methods are static.
    /// 
    /// </summary>
    public static class GUIHelper
    {
        /// <summary>
        /// This method takes a tree such as the data tree and finds if the value exists
        /// </summary>
        /// <param name="list">a list of TreeModel</param>
        /// <param name="nodeValue">string of the property that changes, e.g. a value</param>
        /// <returns></returns>
        public static bool findSingleNodeValueOnTree(List<TreeModel> list, string nodeValue)
        {
            bool result = false;
            foreach (var item in list)
            {
                if(item.Nodes.Count() == 0)
                {
                    return result;
                }
                else
                {
                    foreach (var i in item.Nodes)
                    {
                        if (i.controlValue == nodeValue)
                        {
                            Console.WriteLine("found node! " + i.controlType + " value: " + i.controlValue);
                            result = true;
                            return result;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Clears all the nodes from the TreeModel's ObservableCollection of TreeNodes.
        /// </summary>
        /// <param name="list"></param>
        public static void ClearTreeNodes(List<TreeModel> list)
        {
            foreach (TreeModel tm in list)
            {
                tm.Nodes.Clear();
            }
        }

        //private static List<TreeModel> modelsToRemove = new List<TreeModel>();

        //public static void clearTree(List<TreeModel> tree)
        //{
        //    Console.WriteLine("Initial: " + tree.Count());

        //    foreach (TreeModel tm in tree)
        //    {
        //        if (tm.Nodes.Count > 0)
        //        {
        //            tm.Nodes.Clear();
        //        }
        //        modelsToRemove.Add(tm);
        //    }

        //    foreach (TreeModel nodeToRemove in modelsToRemove)
        //    {
        //        tree.Remove(nodeToRemove);
        //    }
        //    Console.WriteLine("Final: " + tree.Count());
        //}
    }
}
