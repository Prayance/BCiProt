using BCiProt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace BCiProt.HelperClasses
{
    /// <summary>
    /// This class holds all the general methods that are used in the GUI.
    /// This class is static and all of it's methods are static.
    /// 
    /// </summary>
    public static class GUIHelper
    {
        #region tree
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

        #endregion

        #region cursor
        /// <summary>
        ///   A value indicating whether the UI is currently busy
        /// </summary>
        private static bool IsBusy;

        /// <summary>
        /// Sets the busystate as busy.
        /// </summary>
        public static void SetBusyState()
        {
            SetBusyState(true);
        }

        /// <summary>
        /// Sets the busystate to busy or not busy.
        /// </summary>
        /// <param name="busy">if set to <c>true</c> the application is now busy.</param>
        private static void SetBusyState(bool busy)
        {
            if (busy != IsBusy)
            {
                IsBusy = busy;
                Mouse.OverrideCursor = busy ? Cursors.Wait : null;

                if (IsBusy)
                {
                    new DispatcherTimer(TimeSpan.FromSeconds(0), DispatcherPriority.ApplicationIdle, dispatcherTimer_Tick, Application.Current.Dispatcher);
                }
            }
        }

        /// <summary>
        /// Handles the Tick event of the dispatcherTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private static void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var dispatcherTimer = sender as DispatcherTimer;
            if (dispatcherTimer != null)
            {
                SetBusyState(false);
                dispatcherTimer.Stop();
            }
        }
        #endregion

        #region Parcestring

        /// <summary>
        /// This method, parces a string of numbers separated by comma to a list of ints.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static IEnumerable<int> StringToIntList(string str)
        {
            if (String.IsNullOrEmpty(str))
                yield break;

            foreach (var s in str.Split(','))
            {
                int num;
                if (int.TryParse(s, out num))
                    yield return num;
            }
        }

        public static string[] StringToStringList(string str)
        {
            char[] commaSeparator = new char[] { ',' };
            string[] result = str.Split(commaSeparator, StringSplitOptions.None);
            return result;
        }

        #endregion
    }
}
