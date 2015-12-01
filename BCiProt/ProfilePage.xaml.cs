using BCiProt.ExportDataModel;
using BCiProt.HelperClasses;
using BCiProt.Model;
using BCiProt.SettingsManagement;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Xceed.Wpf.Toolkit; // this is from the extended WPF toolkit community edition 

namespace BCiProt
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {

        public ObservableCollection<string> myList = new ObservableCollection<string>();
        protected string fontSizeCB = ""; // my font size editable's combobox value

        public ProfilePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds all the MSDN languages on the myList
        /// </summary>
        private void populateLanguages()
        {
            CultureInfo[] cultureInfos = CultureInfo.GetCultures(CultureTypes.AllCultures);
            for (int i = 0; i < cultureInfos.Length; i++)
            {
                myList.Add(cultureInfos[i].EnglishName);
            }
        }


        /// <summary>
        /// The code below is based on testing.
        /// On the selection changed even I want the treeview to remain there. 
        /// And to be able to modified again by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int a = 0;
            foreach (var i in e.AddedItems)
            {
                Console.WriteLine(a + ": " + i + "To string: " + i.ToString());
                a++;
            }
            int b = 0;
            foreach (var k in e.RemovedItems)
            {
                Console.WriteLine(b + ": " + k + "To string: " + k.ToString());
                b++;
            }
            Console.WriteLine("My Data tree has: " + tree.Count + "Nodes. And the tmBasic has " + tmBasic.Nodes.Count + " node count.");
        }

        #region GeneralProfile

        #region generalVars
        private bool gVidEnable;
        private bool gAudEnable;
        private bool gMarkOut;
        private bool gMarkIn;
        private bool gAudioPassThrough;
        private bool gcopyDataFromSource;
        private bool goverwriteOutput;
        private bool gmetaDataEnabled;
        private bool ggenerateThumbnail;
        private string gprName;
        private string gprVersion;
        private string gselectVideoFilter;
        private string gvideoFilter;
        private string gselectAudioFilter;
        private string gaudioFilter;
        private string gchecksumType;
        private string gMarkOutType;
        private string gMarkOutFrame;
        private string gMarkOutTime;
        private string gMarkInType;
        private string gMarkInFrame;
        private string gMarkInTime;

        private bool gproceed = false;

        private TreeModel gtm = new TreeModel();
        #endregion

        /// <summary>
        /// This method initializes all the general profile global variables.
        /// It also checks if the obligatory textboxes are filled.
        /// </summary>
        private void getGeneralProfileData()
        {
            gprName = string.IsNullOrWhiteSpace(prName.Text) ? "0" : prName.Text.Trim(); //must
            gprVersion = string.IsNullOrWhiteSpace(prVersion.Text) ? "0" : prVersion.Text.Trim(); //must
            gselectVideoFilter = string.IsNullOrWhiteSpace(selectVideoFilter.Text) ? "" : selectVideoFilter.Text.Trim();
            gvideoFilter = string.IsNullOrWhiteSpace(videoFilter.Text) ? "" : videoFilter.Text.Trim();
            gselectAudioFilter = string.IsNullOrWhiteSpace(selectAudioFilter.Text) ? "" : selectAudioFilter.Text.Trim();
            gaudioFilter = string.IsNullOrWhiteSpace(audioFilter.Text) ? "" : audioFilter.Text.Trim();
            gchecksumType = string.IsNullOrWhiteSpace(checksumType.Text) ? "" : checksumType.Text.Trim();
            gMarkOutType = string.IsNullOrWhiteSpace(MarkOutType.Text) ? "" : MarkOutType.Text.Trim();
            gMarkOutFrame = string.IsNullOrWhiteSpace(MarkOutFrame.Text) ? "" : MarkOutFrame.Text.Trim();
            gMarkOutTime = string.IsNullOrWhiteSpace(MarkOutTime.Text) ? "" : MarkOutTime.Text.Trim();
            gMarkInType = string.IsNullOrWhiteSpace(MarkInType.Text) ? "" : MarkInType.Text.Trim();
            gMarkInFrame = string.IsNullOrWhiteSpace(MarkInFrame.Text) ? "" : MarkInFrame.Text.Trim();
            gMarkInTime = string.IsNullOrWhiteSpace(MarkInTime.Text) ? "" : MarkInTime.Text.Trim();

            if (gprName == "0" || gprVersion == "0")
                System.Windows.MessageBox.Show("Please fill all the boxes that have a red star next to them!", "Data Missing", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                gproceed = true;
            }
        }

        /// <summary>
        /// Adds all the general variables to the treeview, so as it can be saved to xml.
        /// </summary>
        private void intoGeneralTree()
        {
            if (gproceed)
            {
                gtm.Nodes.Add(new TreeNode() { controlType = "Name", controlValue = gprName });
                gtm.Nodes.Add(new TreeNode() { controlType = "Version", controlValue = gprVersion });
                gtm.Nodes.Add(new TreeNode() { controlType = "Select_Video_Filter", controlValue = gselectVideoFilter });
                gtm.Nodes.Add(new TreeNode() { controlType = "Select_Video_Filter_Type", controlValue = gvideoFilter });
                gtm.Nodes.Add(new TreeNode() { controlType = "Select_Audio_Filter", controlValue = gselectAudioFilter });
                gtm.Nodes.Add(new TreeNode() { controlType = "Select_Audio_Filter_Type", controlValue = gaudioFilter });
                gtm.Nodes.Add(new TreeNode() { controlType = "Checksum_Type", controlValue = gchecksumType });
                gtm.Nodes.Add(new TreeNode() { controlType = "Select_Video_Enabled", controlValue = gVidEnable.ToString() });
                gtm.Nodes.Add(new TreeNode() { controlType = "Select_Audio_Enabled", controlValue = gAudEnable.ToString() });
                gtm.Nodes.Add(new TreeNode() { controlType = "Mark_Out", controlValue = gMarkOut.ToString() });
                gtm.Nodes.Add(new TreeNode() { controlType = "Mark_In", controlValue = gMarkIn.ToString() });
                gtm.Nodes.Add(new TreeNode() { controlType = "Generate_Thumbnail", controlValue = ggenerateThumbnail.ToString() });
                gtm.Nodes.Add(new TreeNode() { controlType = "Metadata_Enabled", controlValue = gmetaDataEnabled.ToString() });

            }
        }

        private void selectVideoEnabled_Checked(object sender, RoutedEventArgs e)
        {
            selectVideoFilter.IsEnabled = true;
            videoFilter.IsEnabled = true;
        }

        private void selectVideoEnabled_Unchecked(object sender, RoutedEventArgs e)
        {
            selectVideoFilter.IsEnabled = false;
            videoFilter.IsEnabled = false;
        }

        private void selectAudioEnabled_Checked(object sender, RoutedEventArgs e)
        {
            selectAudioFilter.IsEnabled = true;
            audioFilter.IsEnabled = true;
        }

        private void selectAudioEnabled_Unchecked(object sender, RoutedEventArgs e)
        {
            selectAudioFilter.IsEnabled = false;
            audioFilter.IsEnabled = false;
        }

        private void MarkOut_Checked(object sender, RoutedEventArgs e)
        {
            MarkOutPanel.Visibility = Visibility.Visible;
            MarkOutPanel2.Visibility = Visibility.Visible;
            MarkOutPanel3.Visibility = Visibility.Visible;
        }

        private void MarkOut_Unchecked(object sender, RoutedEventArgs e)
        {
            MarkOutPanel.Visibility = Visibility.Hidden;
            MarkOutPanel2.Visibility = Visibility.Hidden;
            MarkOutPanel3.Visibility = Visibility.Hidden;
        }

        private void MarkIn_Checked(object sender, RoutedEventArgs e)
        {
            MarkInPanel.Visibility = Visibility.Visible;
        }

        private void MarkIn_Unchecked(object sender, RoutedEventArgs e)
        {
            MarkInPanel.Visibility = Visibility.Hidden;
        }

        private void audioPassThrough_Checked(object sender, RoutedEventArgs e)
        {
            selectAudioEnabled.IsEnabled = false;
            audio.IsEnabled = false;
        }

        private void audioPassThrough_Unchecked(object sender, RoutedEventArgs e)
        {
            selectAudioEnabled.IsEnabled = true;
            audio.IsEnabled = true;

            if (selectAudioEnabled.IsChecked == true)
            {
                selectAudioFilter.IsEnabled = true;
                audioFilter.IsEnabled = true;
            }
        }

        private void copyDataFromSource_Checked(object sender, RoutedEventArgs e)
        {
            gcopyDataFromSource = true;
        }

        private void copyDataFromSource_Unchecked(object sender, RoutedEventArgs e)
        {
            gcopyDataFromSource = false;
        }

        private void overwriteOutput_Checked(object sender, RoutedEventArgs e)
        {
            goverwriteOutput = true;
        }

        private void overwriteOutput_Unchecked(object sender, RoutedEventArgs e)
        {
            goverwriteOutput = false;
        }

        private void metaDataEnabled_Checked(object sender, RoutedEventArgs e)
        {
            gmetaDataEnabled = true;
        }

        private void metaDataEnabled_Unchecked(object sender, RoutedEventArgs e)
        {
            gmetaDataEnabled = false;
        }

        private void generateThumbnail_Checked(object sender, RoutedEventArgs e)
        {
            ggenerateThumbnail = true;
        }

        private void generateThumbnail_Unchecked(object sender, RoutedEventArgs e)
        {
            ggenerateThumbnail = false;
        }
        #endregion

        #region DataProfile

        #region DataVars
        private List<TreeModel> tree = new List<TreeModel>();
        private string path = ""; // my data location
        private string subpath = ""; // my subtitle file location
        private string dataSubCodec;
        private string dataSubCharEncoding;
        private string dataSubLanguage;
        private string dataCodec;
        private string dataBitRate;
        private string subFilename;
        private string dataFilename;
        private TreeModel tmBasic = new TreeModel() { Type = "Basic Properties:" }; // root1
        private TreeModel tmS = new TreeModel() { Type = "Subtitle Settings:" }; // root2
        private TreeModel tmSec = new TreeModel() { Type = "Secondary Properties:" }; // root3
        #endregion

        /// <summary>
        /// Adds the Subtitle's selection of the user in the treeview and save them as a tree data structure.
        /// Checks if the subtitle exists, if it is accurate and if the subtitle file has been used before. 
        /// It notifies the user for 'all' errors.
        /// It allows the user to re-upload a subtitle file with different subtitle properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSubtitle_Click(object sender, RoutedEventArgs e)
        {
            // used in the check of duplicate subtitle triplet of properties.
            bool toAdd = false;

            // get the user's selection
            dataCodec = CodecCB.Text;
            TreeNode t0 = new TreeNode() { controlType = DCodecLabel.Content.ToString(), controlValue = dataCodec };

            // Gets the data from the subtitle panel
            dataSubCodec = string.IsNullOrWhiteSpace(subCodecCB.Text) ? "0" : subCodecCB.Text;
            dataSubCharEncoding = string.IsNullOrWhiteSpace(subtitleCharacterEncoding.Text) ? "0" : subtitleCharacterEncoding.Text;
            dataSubLanguage = string.IsNullOrWhiteSpace(SubtitleLanguage.Text) ? "0" : SubtitleLanguage.Text;

            // check that the user's selection is valid
            if (dataSubCodec == "0" || dataSubCharEncoding == "0" || dataSubLanguage == "0")
            {
                System.Windows.MessageBox.Show("Please Choose a Subtitle Codec, Encoding and Language to Proceed.", "Information Needed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                TreeNode t1 = new TreeNode() { controlType = subCLabel.Content.ToString(), controlValue = dataSubCodec };
                TreeNode t2 = new TreeNode() { controlType = subCELabel.Content.ToString(), controlValue = dataSubCharEncoding };
                TreeNode t3 = new TreeNode() { controlType = subLLabel.Content.ToString(), controlValue = dataSubLanguage };
                TreeNode t4 = new TreeNode() { controlType = "Subtitle File", controlValue = subFilename, fullFileLocation = subpath };

                // check if the nodes already exist
                for (int i = 0; i < tree.Count(); i++)
                {
                    if ((tree[i].Nodes.Count) != 0)
                    {
                        for (int j = 0; j < (tree[i].Nodes.Count); j = j + 3)
                        {
                            if (tree[i].Nodes[j].controlValue == dataSubCodec && tree[i].Nodes[j + 1].controlValue == dataSubCharEncoding && tree[i].Nodes[j + 2].controlValue == dataSubLanguage)
                            {
                                toAdd = false;
                                break;
                            }
                            else
                            {
                                toAdd = true;
                            }
                        }
                    }
                    else
                    {
                        toAdd = true;
                    }
                }
                //if subtitle exists, inform the user and exit without entering any nodes
                if (toAdd == false)
                {
                    System.Windows.MessageBox.Show("The subtitle you chose has already been entered in the subtitle list.", "Already Exists!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // if the subtitle file is invalid or unexisted
                    if (subFilename == "0" || string.IsNullOrWhiteSpace(subtitleLocation.Content.ToString()))
                    {
                        System.Windows.MessageBox.Show("Please Choose a Subtitle File to Upload.", "Information Needed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        // if the same subtitle file has already been used, ask the user if he wants to proceed anyway
                        if (GUIHelper.findSingleNodeValueOnTree(tree, subFilename) == true)
                        {
                            MessageBoxResult result = System.Windows.MessageBox.Show("The subtitle file you chose has already been entered in the subtitle list. Would you like to Proceed Anyway?", "Proceed Anyway?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            // if the user wants to proceed anyway then enter the nodes in Tree
                            if (result == MessageBoxResult.Yes)
                            {
                                tmS.Nodes.Add(t1);
                                tmS.Nodes.Add(t2);
                                tmS.Nodes.Add(t3);
                                tmS.Nodes.Add(t4);
                                tmBasic.Nodes.Add(t0);
                            }
                        }
                        else
                        {
                            // if all good => happily enter the nodes in tree
                            tmS.Nodes.Add(t1);
                            tmS.Nodes.Add(t2);
                            tmS.Nodes.Add(t3);
                            tmS.Nodes.Add(t4);
                            tmBasic.Nodes.Add(t0);
                        }
                    }
                }
            }
            // add tree as itemsource to the data profile's treeview
            dataTree.ItemsSource = tree;
        }

        /// <summary>
        /// Play with IsEnabled property. 
        /// Depending on the user's selection, different buttons/ textboxes etc are enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodecCB_DropDownClosed(object sender, EventArgs e)
        {
            // index = 1 is the subtitle value's index
            if (CodecCB.SelectedIndex == 1)
            {
                subCodecCB.IsEnabled = true;
                subtitleCharacterEncoding.IsEnabled = true;
                SubtitleLanguage.IsEnabled = true;
                subFileChoose.IsEnabled = true;
                AddSubtitle.IsEnabled = true;

                bitRate.IsEnabled = false;
                dataLocationButton.IsEnabled = false;
                AddPrivateData.IsEnabled = false;
            }
            // index = 2 is the private data value's index
            else if (CodecCB.SelectedIndex == 2)
            {
                bitRate.IsEnabled = true;
                dataLocationButton.IsEnabled = true;
                AddPrivateData.IsEnabled = true;

                subFileChoose.IsEnabled = false;
                subCodecCB.IsEnabled = false;
                subtitleCharacterEncoding.IsEnabled = false;
                SubtitleLanguage.IsEnabled = false;
                AddSubtitle.IsEnabled = false;
            }
            else
            {
                bitRate.IsEnabled = false;
                subCodecCB.IsEnabled = false;
                subtitleCharacterEncoding.IsEnabled = false;
                SubtitleLanguage.IsEnabled = false;
                dataLocationButton.IsEnabled = false;
                AddPrivateData.IsEnabled = false;
                AddSubtitle.IsEnabled = false;
                subFileChoose.IsEnabled = false;
            }
        }

        private void SaveDataProfile_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        /// <summary>
        /// Adds the user's selection of private data in the treeview and save them as a tree data structure.
        /// Check if the same data exists
        /// It notifies the user for 'all' errors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPrivateData_Click(object sender, RoutedEventArgs e)
        {
            bool toAdd = true;

            // get the user's selection
            dataCodec = CodecCB.Text;
            TreeNode t0 = new TreeNode() { controlType = DCodecLabel.Content.ToString(), controlValue = dataCodec };

            //gets secondary data - aka bit rate (secondary = not subtitle and not obligatory to add)
            dataBitRate = string.IsNullOrWhiteSpace(bitRate.Text) ? "0" : bitRate.Text.Trim();

            // error messages if the databitrate is not valid or there is no data file
            if (string.IsNullOrWhiteSpace(dataLocation.Content.ToString()) || dataFilename == "0")
            {
                System.Windows.MessageBox.Show("Please Choose a Data File to Upload.", "Information Needed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                toAdd = false;
            }
            else if (dataBitRate == "0")
            {
                System.Windows.MessageBox.Show("Please Enter a Valid Data Bit Rate value.", "Information Needed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                toAdd = false;
            }

            if (toAdd)
            {
                // create the child node
                TreeNode t1 = new TreeNode() { controlType = DBitLabel.Content.ToString(), controlValue = dataBitRate };
                TreeNode t2 = new TreeNode() { controlType = "Data File ", controlValue = dataFilename, fullFileLocation = path };

                // check that the bit rate node does not already exists
                // TODO: Why does this return true?
                if (GUIHelper.findSingleNodeValueOnTree(tree, dataFilename) == false && GUIHelper.findSingleNodeValueOnTree(tree, dataBitRate) == false)
                {
                    tmBasic.Nodes.Add(t0);
                    tmSec.Nodes.Add(t1);
                    tmSec.Nodes.Add(t2);
                }
                else
                {
                    System.Windows.MessageBox.Show("Duplicate Value. You have already entered the specified bit rate.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Console.WriteLine("tmBasic has " + tmBasic.Nodes.Count + " Node count from the method itself.");
            dataTree.ItemsSource = tree;
        }

        /// <summary>
        /// Opens a dialog to get the subtitle file location.
        /// Depended on the subtitle's user selection, the subtitle location filter changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void subFileChoose_Click(object sender, RoutedEventArgs e)
        {
            dataSubCodec = string.IsNullOrWhiteSpace(subCodecCB.Text) ? "0" : subCodecCB.Text;

            if (dataSubCodec != "0")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Subtitle File Location";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "Subtitle Files (*." + dataSubCodec + ")|*." + dataSubCodec;

                if (openFileDialog.ShowDialog() == true)
                {
                    subpath = openFileDialog.FileName.ToString();
                    subFilename = string.IsNullOrWhiteSpace(openFileDialog.SafeFileName) ? "0" : openFileDialog.SafeFileName;
                    subtitleLocation.Content = subpath;
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Please choose a valid Subtitle codec first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Opens a dialog to get the data file location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataLocationButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Data File Location";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // TODO: openFileDialog.Filter = maybe extensions? or? 
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName.ToString();
                dataFilename = string.IsNullOrWhiteSpace(openFileDialog.SafeFileName) ? "0" : openFileDialog.SafeFileName;
                dataLocation.Content = path;
            }
        }

        /// <summary>
        /// Cancels all the changes, resets tree data structure, treeview, fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelData_Click(object sender, RoutedEventArgs e)
        {
            // GUIHelper.RemoveCheckedNodes(tree);
            GUIHelper.ClearTreeNodes(tree);
            Console.WriteLine("now my tree has: " + tree.Count());

            //dataTree.ItemsSource = tree;
        }

        #endregion

        #region AudioProfile

        #region AudioVars
        private string audioProfileName;
        private string audioSampleType;
        private string audioSampleRate;
        private string audioMaxFrequency;
        private string audioMinFrequency;
        private string audioCodec; //dropdown
        private string audioLayout;
        private string audioLanguage;
        private string audioBitRateText;
        private bool audioPassthrough;
        private bool audioGain;
        // private string audioProfileotherName;
        private string audioGainTarget;
        private string audioChannelText;
        private string[] audioChannelList;
        private List<TreeChannelModel> audioT = new List<TreeChannelModel>();
        private TreeChannelModel aTBasic = new TreeChannelModel();
        private TreeChannelModel AC3Basic = new TreeChannelModel();
        private bool aproceed = false;

        private string ac3codingMode;
        private string ac3audioBitRateTarget;
        private string ac3adConverter;
        private string ac3roomType;
        private string ac3mixMode;
        private string ac3dialogLevel;
        private string ac3ltRTmix;
        private string ac3ltRtsurmix;
        private string ac3loRosurmix;
        private string ac3loRomix;
        private string ac3SurroundMode;
        private string ac3bitStreamMode;
        private string ac3lineCompression;
        private string ac3rfCompression;
        private bool ac3PhaseShift;
        private bool ac3SurroundAttenuation;
        private bool ac3PeakLevel;
        private bool ac3DCFilter;
        private bool ac3LFEFilter;
        private bool ac3Copyright;
        private bool ac3Deemphasis;
        private bool ac3Bandwidth;
        private bool ac3LFEChannel;
        private bool aceDDEmeta;
        private bool ac3Original;

        private bool isItFirstTime = true;
        private bool eproceed = false;
        #endregion

        /// <summary>
        /// initializes the audio profile's common global variables
        /// </summary>
        private void getAudioStandardData()
        {
            // make sure that the audio channel list is empty before the window loads.
            audioChannelList = null;

            audioProfileName = string.IsNullOrWhiteSpace(AudioName.Text) ? "0" : AudioName.Text.Trim(); //must
            audioSampleType = string.IsNullOrWhiteSpace(sampleType.Text) ? "0" : sampleType.Text.Trim(); //must
            audioChannelText = string.IsNullOrWhiteSpace(MSC.Text) ? "0" : MSC.Text.Trim(); //must
            audioCodec = string.IsNullOrWhiteSpace(codec.Text) ? "0" : codec.Text.Trim(); //must
            audioLayout = string.IsNullOrWhiteSpace(layout.Text) ? "0" : layout.Text.Trim(); //must
            audioLanguage = string.IsNullOrWhiteSpace(language.Text) ? "0" : language.Text.Trim(); //must
            audioBitRateText = string.IsNullOrWhiteSpace(audioBitRate.Text) ? "0" : audioBitRate.Text.Trim(); //must
            audioGainTarget = string.IsNullOrWhiteSpace(GainTarget.Text) ? "" : GainTarget.Text.Trim();
            audioSampleRate = string.IsNullOrWhiteSpace(sampleRate.Text) ? "" : sampleRate.Text.Trim();
            audioMaxFrequency = string.IsNullOrWhiteSpace(maxFrequency.Text) ? "" : maxFrequency.Text.Trim();
            audioMinFrequency = string.IsNullOrWhiteSpace(minFrequency.Text) ? "" : minFrequency.Text.Trim();

            if (audioProfileName == "0" || audioSampleType == "0" || audioCodec == "0" || audioLayout == "0" ||
                audioLanguage == "0" || audioBitRateText == "0" || audioChannelText == "0")
                System.Windows.MessageBox.Show("Please fill all the boxes that have a red star next to them!", "Data Missing", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                audioChannelList = GUIHelper.StringToStringList(audioChannelText);
                aproceed = true;
            }
        }

        /// <summary>
        /// initializes the audio profile's AC3 variables
        /// </summary>
        private void getAudioExtraData()
        {
            ac3codingMode = string.IsNullOrWhiteSpace(codingMode.Text) ? "0" : codingMode.Text; //must
            ac3audioBitRateTarget = string.IsNullOrWhiteSpace(audioBitRateTarget.Text) ? "0" : audioBitRateTarget.Text; //must
            ac3adConverter = string.IsNullOrWhiteSpace(adConverter.Text) ? "0" : adConverter.Text; //must
            ac3roomType = string.IsNullOrWhiteSpace(roomType.Text) ? "0" : roomType.Text; //must
            ac3mixMode = string.IsNullOrWhiteSpace(mixMode.Text) ? "0" : mixMode.Text; //must
            ac3dialogLevel = string.IsNullOrWhiteSpace(dialogLevel.Text) ? "0" : dialogLevel.Text; //must
            ac3ltRTmix = string.IsNullOrWhiteSpace(ltRTmix.Text) ? "0" : ltRTmix.Text; //must
            ac3ltRtsurmix = string.IsNullOrWhiteSpace(ltRtsurmix.Text) ? "0" : ltRtsurmix.Text; //must
            ac3loRosurmix = string.IsNullOrWhiteSpace(loRosurmix.Text) ? "0" : loRosurmix.Text; //must
            ac3loRomix = string.IsNullOrWhiteSpace(loRomix.Text) ? "0" : loRomix.Text; //must
            ac3SurroundMode = string.IsNullOrWhiteSpace(SurroundMode.Text) ? "0" : SurroundMode.Text; //must
            ac3bitStreamMode = string.IsNullOrWhiteSpace(bitStreamMode.Text) ? "0" : bitStreamMode.Text; //must
            ac3lineCompression = string.IsNullOrWhiteSpace(lineCompression.Text) ? "0" : lineCompression.Text; //must
            ac3rfCompression = string.IsNullOrWhiteSpace(rfCompression.Text) ? "0" : rfCompression.Text; //must

            if (ac3codingMode == "0" || ac3audioBitRateTarget == "0" || ac3adConverter == "0" || ac3roomType == "0" ||
                ac3mixMode == "0" || ac3dialogLevel == "0" || ac3ltRTmix == "0" || ac3ltRtsurmix == "0" || ac3loRosurmix == "0" ||
                ac3loRomix == "0" || ac3SurroundMode == "0" || ac3bitStreamMode == "0" || ac3lineCompression == "0" || ac3rfCompression == "0")
                System.Windows.MessageBox.Show("Please fill all the boxes that have a red star next to them!", "Data Missing", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                eproceed = true;
        }

        /// <summary>
        /// When the audio profile is loaded, the AC3Profile textbox gets the text specified below as
        /// context.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AC3Profile_Loaded(object sender, RoutedEventArgs e)
        {
            AC3Profile.Text = "If the profile is an AC3 one, please click the Proceed to AC3 profile button below." +
               "Otherwise click on the Save as Other audio profile button below.";
        }

        /// <summary>
        /// This is the AC3 button. On click the AC3 stackpanels with all the extra options, become visible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AC3proceed_Click(object sender, RoutedEventArgs e)
        {
            GUIHelper.SetBusyState();
            getAudioStandardData();
            if (aproceed)
            {
                WhatProfile.Visibility = Visibility.Hidden;
                AC3UpperLeft.Visibility = Visibility.Visible;
                AC3UpperMiddle.Visibility = Visibility.Visible;
                AC3UpperRight.Visibility = Visibility.Visible;
                AC3BottomLeft.Visibility = Visibility.Visible;
                AC3BottomMiddle.Visibility = Visibility.Visible;
                AC3BottomRight.Visibility = Visibility.Visible;
                AC3WhatProfile.Visibility = Visibility.Visible;
                AC3Add.Visibility = Visibility.Visible;
                AC3Save.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Save as diffrent profile button. On click the popup becomes visible with the final attribute called Profile (string).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveOther_Click(object sender, RoutedEventArgs e)
        {
            GUIHelper.SetBusyState();
            getAudioStandardData();
            if (aproceed)
            {
                // display dialog message 
                MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure that you want to save this profile as other?", "Save as Other", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    clearStandardDataFields();
                    aTBasic.Name = audioProfileName;
                    AudioName.IsEnabled = false;
                    populateBasicAudioNode();
                    audioTree.ItemsSource = audioT;
                }
            }
        }

        /// <summary>
        /// Resets all fields and adds this channel + options to AC3 profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddChannel_Click(object sender, RoutedEventArgs e)
        {
            GUIHelper.SetBusyState();
            getAudioExtraData();
            if (eproceed)
            {
                if (isItFirstTime)
                {
                    getAudioStandardData();
                    if (aproceed)
                    {
                        AC3Basic.Name = audioProfileName;
                        populateAC3BasicAudioNode();
                        disableStandardFields();
                    }
                }
                MSC.Text = "";
                populateExtraNode();
                audioTree.ItemsSource = audioT;
            }
        }

        /// <summary>
        /// Has TODO. 
        /// Saves the current AC3 profile & resets all fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAC3Profile_Click(object sender, RoutedEventArgs e)
        {
            AC3Basic.Name = audioProfileName;
            AC3Basic.Mode = "AC3 Profile";
            getAudioStandardData();
            populateBasicAudioNode();
            populateExtraNode();
            // reset treeview 
            audioTree.ItemsSource = audioT;
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure that you want to complete the AC3 Audio profile?", "Save as Audio Profile", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                AutoClosingMessageBox.Show("Saved!", "Audio Profile", 1000);
                myTab.SelectedItem = video;
            }
            else if (result == MessageBoxResult.No)
            {
                MessageBoxResult mr = System.Windows.MessageBox.Show("Would you like to keep editing the Audio profile? If you click no ALL your audio profile changes will be lost!", "Keep Editing", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mr == MessageBoxResult.No)
                {
                    enableStandardFields();
                }
            }
        }

        /// <summary>
        /// This method will virtually clear all Standard data fields.
        /// It will NOT reset and saved data.
        /// It will NOT clear extra AC3 or other profile fields.
        /// It will NOT clear the Audio Profile Name field.
        /// </summary>
        private void clearStandardDataFields()
        {
            // AudioName.Text = "";
            sampleType.Text = "";
            MSC.Text = "";
            codec.Text = "";
            layout.Text = "";
            language.Text = "";
            audioBitRate.Text = "";
            GainTarget.Text = "";
            sampleRate.Text = "";
            maxFrequency.Text = "";
            minFrequency.Text = "";
            Passthrough.IsChecked = false;
            Gain.IsChecked = false;
        }

        private void clearAC3Fields()
        {
            ac3codingMode = "";
            ac3audioBitRateTarget = "";
            ac3adConverter = "";
            ac3roomType = "";
            ac3mixMode = "";
            ac3dialogLevel = "";
            ac3ltRTmix = "";
            ac3ltRtsurmix = "";
            ac3loRosurmix = "";
            ac3loRomix = "";
            ac3SurroundMode = "";
            ac3bitStreamMode = "";
            ac3lineCompression = "";
            ac3rfCompression = "";
        }

        /// <summary>
        /// This method disables all the Standard Audio Fields
        /// It does NOT disable the MSC channel selection.
        /// </summary>
        private void disableStandardFields()
        {
            AudioName.IsEnabled = false;
            sampleType.IsEnabled = false;
            //MSC.IsEnabled = false;
            codec.IsEnabled = false;
            layout.IsEnabled = false;
            language.IsEnabled = false;
            audioBitRate.IsEnabled = false;
            GainTarget.IsEnabled = false;
            sampleRate.IsEnabled = false;
            maxFrequency.IsEnabled = false;
            minFrequency.IsEnabled = false;
            Gain.IsEnabled = false;
            Passthrough.IsEnabled = false;
        }

        /// <summary>
        /// This method enables all the Standard Audio Fields.
        /// It will NOT enable the Audio Profile Name Field
        /// </summary>
        private void enableStandardFields()
        {
            // AudioName.IsEnabled = true;
            sampleType.IsEnabled = true;
            MSC.IsEnabled = true;
            codec.IsEnabled = true;
            layout.IsEnabled = true;
            language.IsEnabled = true;
            audioBitRate.IsEnabled = true;
            GainTarget.IsEnabled = true;
            sampleRate.IsEnabled = true;
            maxFrequency.IsEnabled = true;
            minFrequency.IsEnabled = true;
            Gain.IsEnabled = true;
            Passthrough.IsEnabled = true;
        }

        /// <summary>
        /// remember to call this method AFTER the getAudioStandardData() one.
        /// It populates all the standard nodes
        /// using: aTBasic.BasicNodes.Add(new ChannelBasicType node)
        /// </summary>
        /// <returns></returns>
        private void populateBasicAudioNode()
        {
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = aPName.Content.ToString(), basicValue = audioProfileName, imageSource = "/Images/AudioTreeViewImages/1448054041_domain_name_investment.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = aChannel.Content.ToString(), basicValue = audioChannelText, imageSource = "/Images/AudioTreeViewImages/channel.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = aSType.Content.ToString(), basicValue = audioSampleType, imageSource = "/Images/AudioTreeViewImages/1448054383_3d_objects.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = aSRTarget.Content.ToString(), basicValue = audioSampleRate, imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = maxF.Content.ToString(), basicValue = audioMaxFrequency, imageSource = "/Images/AudioTreeViewImages/1448054094_Black_tag.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = minF.Content.ToString(), basicValue = audioMinFrequency, imageSource = "/Images/AudioTreeViewImages/1448054094_Black_tag.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = aACodec.Content.ToString(), basicValue = audioCodec, imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = aLType.Content.ToString(), basicValue = audioLayout, imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = Gain.Content.ToString(), basicValue = audioGain.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054094_Black_tag.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = aGTarget.Content.ToString(), basicValue = audioGainTarget, imageSource = "/Images/AudioTreeViewImages/1448054094_Black_tag.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = aLanguage.Content.ToString(), basicValue = audioLanguage, imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = aBRate.Content.ToString(), basicValue = audioBitRateText, imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            aTBasic.BasicNodes.Add(new ChannelBasicType() { basicType = PassthroughText.Text, basicValue = audioPassthrough.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            isItFirstTime = false;
        }

        /// <summary>
        /// remember to call this method AFTER the getAudioStandardData() one.
        /// It populates all the standard nodes
        /// using: aTBasic.BasicNodes.Add(new ChannelBasicType node)
        /// </summary>
        /// <returns></returns>
        private void populateAC3BasicAudioNode()
        {
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aPName.Content.ToString(), basicValue = audioProfileName, imageSource = "/Images/AudioTreeViewImages/1448054041_domain_name_investment.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aChannel.Content.ToString(), basicValue = audioChannelText, imageSource = "/Images/AudioTreeViewImages/channel.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aSType.Content.ToString(), basicValue = audioSampleType, imageSource = "/Images/AudioTreeViewImages/1448054383_3d_objects.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aSRTarget.Content.ToString(), basicValue = audioSampleRate, imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = maxF.Content.ToString(), basicValue = audioMaxFrequency, imageSource = "/Images/AudioTreeViewImages/1448054094_Black_tag.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = minF.Content.ToString(), basicValue = audioMinFrequency, imageSource = "/Images/AudioTreeViewImages/1448054094_Black_tag.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aACodec.Content.ToString(), basicValue = audioCodec, imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aLType.Content.ToString(), basicValue = audioLayout, imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = Gain.Content.ToString(), basicValue = audioGain.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054094_Black_tag.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aGTarget.Content.ToString(), basicValue = audioGainTarget, imageSource = "/Images/AudioTreeViewImages/1448054094_Black_tag.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aLanguage.Content.ToString(), basicValue = audioLanguage, imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aBRate.Content.ToString(), basicValue = audioBitRateText, imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = PassthroughText.Text, basicValue = audioPassthrough.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054097_Green_tag.png", isBasic = true });
            isItFirstTime = false;
        }

        /// <summary>
        /// remember to call this method AFTER the getAudioStandardData() one.
        /// It populates all the extra nodes for AC3 profile
        /// using: aTBasic.ExtraNodes.Add(new ExtraBasicType node)
        /// </summary>
        private void populateExtraNode()
        {
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = apShift.Text, basicValue = ac3PhaseShift.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aSAttenuation.Text, basicValue = ac3SurroundAttenuation.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aPLevel.Text, basicValue = ac3PeakLevel.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aDCFilter.Text, basicValue = ac3DCFilter.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aLFEFilter.Text, basicValue = ac3LFEFilter.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aAC3CMode.Content.ToString(), basicValue = ac3codingMode, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aBRTarget.Content.ToString(), basicValue = ac3audioBitRateTarget, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aadConverter.Content.ToString(), basicValue = ac3adConverter, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aRType.Content.ToString(), basicValue = ac3roomType, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aMMode.Content.ToString(), basicValue = ac3mixMode, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aDLevel.Content.ToString(), basicValue = ac3dialogLevel, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aLRCMix.Content.ToString(), basicValue = ac3ltRTmix, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aLRSMix.Content.ToString(), basicValue = ac3ltRtsurmix, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aLRSoMix.Content.ToString(), basicValue = ac3loRosurmix, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aLRCoMix.Content.ToString(), basicValue = ac3loRomix, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aSMode.Content.ToString(), basicValue = ac3SurroundMode, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aBSMode.Content.ToString(), basicValue = ac3bitStreamMode, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aLCompression.Content.ToString(), basicValue = ac3lineCompression, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aRFCompression.Content.ToString(), basicValue = ac3rfCompression, imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = Copyright.Content.ToString(), basicValue = ac3Copyright.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054044_Blue_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aDeemphasis.Text, basicValue = ac3Deemphasis.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aBandwidth.Text, basicValue = ac3Bandwidth.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = aLFEChannel.Text, basicValue = ac3LFEChannel.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054098_Yellow_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = DDEmeta.Content.ToString(), basicValue = aceDDEmeta.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054044_Blue_tag.png", isBasic = false });
            AC3Basic.BasicNodes.Add(new ChannelBasicType() { basicType = Original.Content.ToString(), basicValue = ac3Original.ToString(), imageSource = "/Images/AudioTreeViewImages/1448054044_Blue_tag.png", isBasic = false });
        }

        /// <summary>
        /// sets the audioPassthrough to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Passthrough_Checked(object sender, RoutedEventArgs e)
        {
            audioPassthrough = true;
        }

        /// <summary>
        /// sets the audioPassthrough to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Passthrough_Unchecked(object sender, RoutedEventArgs e)
        {
            audioPassthrough = false;
        }

        /// <summary>
        /// sets the audioGain to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gain_Checked(object sender, RoutedEventArgs e)
        {
            audioGain = true;
        }

        /// <summary>
        /// sets the audioGain to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gain_Unchecked(object sender, RoutedEventArgs e)
        {
            audioGain = false;
        }

        /// <summary>
        /// sets the phaseshift check to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhaseShift_Checked(object sender, RoutedEventArgs e)
        {
            ac3PhaseShift = true;
        }

        /// <summary>
        /// sets the phaseshift check to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhaseShift_Unchecked(object sender, RoutedEventArgs e)
        {
            ac3PhaseShift = false;
        }

        /// <summary>
        /// sets the Surround Attenuation to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurroundAttenuation_Checked(object sender, RoutedEventArgs e)
        {
            ac3SurroundAttenuation = true;
        }

        /// <summary>
        /// sets the Surround Attenuation to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurroundAttenuation_Unchecked(object sender, RoutedEventArgs e)
        {
            ac3SurroundAttenuation = false;
        }

        /// <summary>
        /// sets the Peak Level to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeakLevel_Checked(object sender, RoutedEventArgs e)
        {
            ac3PeakLevel = true;
        }

        /// <summary>
        /// sets the Peak Level to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeakLevel_Unchecked(object sender, RoutedEventArgs e)
        {
            ac3PeakLevel = false;
        }

        /// <summary>
        /// sets the DC Filter to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCFilter_Checked(object sender, RoutedEventArgs e)
        {
            ac3DCFilter = true;
        }

        /// <summary>
        /// sets the DC Filter to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            ac3DCFilter = false;
        }

        /// <summary>
        /// sets the LFE Filter to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LFEFilter_Checked(object sender, RoutedEventArgs e)
        {
            ac3LFEFilter = true;
        }

        /// <summary>
        /// sets the LFE Filter to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LFEFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            ac3LFEFilter = false;
        }

        /// <summary>
        /// Sets the copyright value to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Copyright_Checked(object sender, RoutedEventArgs e)
        {
            ac3Copyright = true;
        }

        /// <summary>
        /// Sets the copyright value to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Copyright_Unchecked(object sender, RoutedEventArgs e)
        {
            ac3Copyright = false;
        }

        /// <summary>
        /// sets the Deemphasis value to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Deemphasis_Checked(object sender, RoutedEventArgs e)
        {
            ac3Deemphasis = true;
        }

        /// <summary>
        /// sets the Deemphasis value to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Deemphasis_Unchecked(object sender, RoutedEventArgs e)
        {
            ac3Deemphasis = false;
        }

        /// <summary>
        /// sets the Bandwidth value to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bandwidth_Checked(object sender, RoutedEventArgs e)
        {
            ac3Bandwidth = true;
        }

        /// <summary>
        /// sets the Bandwidth value to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bandwidth_Unchecked(object sender, RoutedEventArgs e)
        {
            ac3Bandwidth = false;
        }

        /// <summary>
        /// sets the LFE Channel value to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LFEChannel_Checked(object sender, RoutedEventArgs e)
        {
            ac3LFEChannel = true;
        }

        /// <summary>
        /// sets the LFE Channel value to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LFEChannel_Unchecked(object sender, RoutedEventArgs e)
        {
            ac3LFEChannel = false;
        }

        /// <summary>
        /// sets the DDE meta value to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DDEmeta_Checked(object sender, RoutedEventArgs e)
        {
            aceDDEmeta = true;
        }

        /// <summary>
        /// sets the DDE meta value to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DDEmeta_Unchecked(object sender, RoutedEventArgs e)
        {
            aceDDEmeta = false;
        }

        /// <summary>
        /// sets the Original value to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Original_Checked(object sender, RoutedEventArgs e)
        {
            ac3Original = true;
        }

        /// <summary>
        /// sets the Original value to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Original_Unchecked(object sender, RoutedEventArgs e)
        {
            ac3Original = false;
        }

        #endregion

        #region VideoProfile

        #region videoVars
        private string vvideoCodec;
        private string vprofile;
        private string vRateControl;
        private string vformat;
        private string vframeCount;
        private string vframeType;
        private string vframeRate;
        private string vheight;
        private string vwidth;
        private string vaspectRatio;
        private string vcolorimetry;
        private string vdeinterlaceMethod;
        private string vsliceNumber;
        private string vlevel;
        private string vfieldOrder;
        private string vpacketCount;
        private bool vdeblockingFilter;
        private bool vderingingFilter;
        private bool vframeRatecb;
        private bool vframeSize;
        private bool vDisplayAspecRatio;
        private string vvideoBitRateTarget;
        private string vvidBitRateMin;
        private string vvidBitRateMax;
        private string vbitAvgMin;
        private string vbitAvgMax;
        private bool vshowData;
        private bool vtimecodeEnable;
        private bool vlogoEnable;
        private bool vcropEnabled;
        private bool vdenoiseEnable;
        private bool vresizeEnable;
        private string vStartTimecode;
        private string vDenoiseStrength;
        private bool vinverseTelecineEnabled;
        private bool vcivolutionEnabled;
        private bool vgopEnabled;
        private bool vweightedPrediction;
        private string vinverseTelecineCorrection;
        private string vcivolutionDateTime;
        private string vcodecRateControl;
        private string vcodecParameters;
        private string ventropy;
        private string vencoding;
        private string vmotionEstimationMethod;
        private string vconstantRateFactor;
        private string vreferenceNumber;
        private string vlogoWidth;
        private string vlogoHeight;
        private string vlogoTop;
        private string vpositionStyle;
        private string logoPath = ""; // my logo file location
        private string vdataText;
        private string vdataX;
        private string vdataY;
        private string vresizeType;
        private string vresizeX;
        private string vresizeY;
        private string vgopLMin;
        private string vgopLMax;
        private string vgopMMin;
        private string vgopMMax;
        private string vcropWidth;
        private string vcropHeight;
        private string vcropX;
        private string vcropY;

        private bool vproceed = false;
        #endregion

        /// <summary>
        /// Initialises all the private variables of Video Profile
        /// </summary>
        private void getVideoProfileData()
        {
            vvideoCodec = string.IsNullOrWhiteSpace(videoCodec.Text) ? "0" : videoCodec.Text.Trim(); //must
            vprofile = string.IsNullOrWhiteSpace(profile.Text) ? "0" : profile.Text.Trim(); //must
            vRateControl = string.IsNullOrWhiteSpace(RateControl.Text) ? "0" : RateControl.Text.Trim(); //must
            vformat = string.IsNullOrWhiteSpace(format.Text) ? "0" : format.Text.Trim(); //must
            vframeCount = string.IsNullOrWhiteSpace(frameCount.Text) ? "" : frameCount.Text.Trim();
            vframeType = string.IsNullOrWhiteSpace(frameType.Text) ? "" : frameType.Text.Trim();
            vframeRate = string.IsNullOrWhiteSpace(frameRate.Text) ? "0" : frameRate.Text.Trim(); //must
            vheight = string.IsNullOrWhiteSpace(height.Text) ? "0" : height.Text.Trim(); //must
            vwidth = string.IsNullOrWhiteSpace(width.Text) ? "0" : width.Text.Trim(); //must
            vaspectRatio = string.IsNullOrWhiteSpace(aspectRatio.Text) ? "0" : aspectRatio.Text.Trim(); //must
            vcolorimetry = string.IsNullOrWhiteSpace(colorimetry.Text) ? "" : colorimetry.Text.Trim();
            vdeinterlaceMethod = string.IsNullOrWhiteSpace(deinterlaceMethod.Text) ? "" : deinterlaceMethod.Text.Trim();
            vsliceNumber = string.IsNullOrWhiteSpace(sliceNumber.Text) ? "" : sliceNumber.Text.Trim();
            vlevel = string.IsNullOrWhiteSpace(level.Text) ? "0" : level.Text.Trim(); //must
            vfieldOrder = string.IsNullOrWhiteSpace(fieldOrder.Text) ? "0" : fieldOrder.Text.Trim(); //must
            vpacketCount = string.IsNullOrWhiteSpace(packetCount.Text) ? "0" : packetCount.Text.Trim(); //must
            vvideoBitRateTarget = string.IsNullOrWhiteSpace(videoBitRateTarget.Text) ? "0" : videoBitRateTarget.Text.Trim(); //must
            vvidBitRateMin = string.IsNullOrWhiteSpace(vidBitRateMin.Text) ? "" : vidBitRateMin.Text.Trim();
            vvidBitRateMax = string.IsNullOrWhiteSpace(vidBitRateMax.Text) ? "" : vidBitRateMax.Text.Trim();
            vbitAvgMin = string.IsNullOrWhiteSpace(bitAvgMin.Text) ? "" : bitAvgMin.Text.Trim();
            vbitAvgMax = string.IsNullOrWhiteSpace(bitAvgMax.Text) ? "" : bitAvgMax.Text.Trim();
            vStartTimecode = string.IsNullOrWhiteSpace(StartTimecode.Text) ? "0" : StartTimecode.Text.Trim();
            vDenoiseStrength = string.IsNullOrWhiteSpace(DenoiseStrength.Text) ? "" : DenoiseStrength.Text.Trim();
            vinverseTelecineCorrection = string.IsNullOrWhiteSpace(inverseTelecineCorrection.Text) ? "" : inverseTelecineCorrection.Text.Trim();
            vcivolutionDateTime = string.IsNullOrWhiteSpace(civolutionDateTime.Text) ? "" : civolutionDateTime.Text.Trim();
            vcodecRateControl = string.IsNullOrWhiteSpace(codecRateControl.Text) ? "" : codecRateControl.Text.Trim();
            vcodecParameters = string.IsNullOrWhiteSpace(codecParameters.Text) ? "" : codecParameters.Text.Trim();
            ventropy = string.IsNullOrWhiteSpace(entropy.Text) ? "" : entropy.Text.Trim();
            vencoding = string.IsNullOrWhiteSpace(encoding.Text) ? "" : encoding.Text.Trim();
            vmotionEstimationMethod = string.IsNullOrWhiteSpace(motionEstimationMethod.Text) ? "" : motionEstimationMethod.Text.Trim();
            vconstantRateFactor = string.IsNullOrWhiteSpace(constantRateFactor.Text) ? "" : constantRateFactor.Text.Trim();
            vreferenceNumber = string.IsNullOrWhiteSpace(referenceNumber.Text) ? "" : referenceNumber.Text.Trim();
            vlogoWidth = string.IsNullOrWhiteSpace(logoWidth.Text) ? "" : logoWidth.Text.Trim();
            vlogoHeight = string.IsNullOrWhiteSpace(logoHeight.Text) ? "" : logoHeight.Text.Trim();
            vlogoTop = string.IsNullOrWhiteSpace(logoTop.Text) ? "" : logoTop.Text.Trim();
            vpositionStyle = string.IsNullOrWhiteSpace(positionStyle.Text) ? "" : positionStyle.Text.Trim();
            vdataText = string.IsNullOrWhiteSpace(dataText.Text) ? "" : dataText.Text.Trim();
            vdataX = string.IsNullOrWhiteSpace(dataX.Text) ? "" : dataX.Text.Trim();
            vdataY = string.IsNullOrWhiteSpace(dataY.Text) ? "" : dataY.Text.Trim();
            vresizeType = string.IsNullOrWhiteSpace(resizeType.Text) ? "" : resizeType.Text.Trim();
            vresizeX = string.IsNullOrWhiteSpace(resizeX.Text) ? "" : resizeX.Text.Trim();
            vresizeY = string.IsNullOrWhiteSpace(resizeY.Text) ? "" : resizeY.Text.Trim();
            vgopLMin = string.IsNullOrWhiteSpace(gopLMin.Text) ? "" : gopLMin.Text.Trim();
            vgopLMax = string.IsNullOrWhiteSpace(gopLMax.Text) ? "" : gopLMax.Text.Trim();
            vgopMMin = string.IsNullOrWhiteSpace(gopMMin.Text) ? "" : gopMMin.Text.Trim();
            vgopMMax = string.IsNullOrWhiteSpace(gopMMax.Text) ? "" : gopMMax.Text.Trim();
            vcropWidth = string.IsNullOrWhiteSpace(cropWidth.Text) ? "" : cropWidth.Text.Trim();
            vcropHeight = string.IsNullOrWhiteSpace(cropHeight.Text) ? "" : cropHeight.Text.Trim();
            vcropX = string.IsNullOrWhiteSpace(cropX.Text) ? "" : cropX.Text.Trim();
            vcropY = string.IsNullOrWhiteSpace(cropY.Text) ? "" : cropY.Text.Trim();

            if (vvideoCodec == "0" || vprofile == "0" || vRateControl == "0" || vformat == "0" ||
                vframeRate == "0" || vheight == "0" || vwidth == "0" || vaspectRatio == "0" ||
                vlevel == "0" || vfieldOrder == "0" || vpacketCount == "0" || vvideoBitRateTarget == "0")
                System.Windows.MessageBox.Show("Please fill all the boxes that have a red star next to them!", "Data Missing", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                vproceed = true;
            }
        }

        /// <summary>
        /// initialises the logoPath variable, which gives us the logo file path of video tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Logo File Location";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // TODO: openFileDialog.Filter = maybe extensions? or? 
            if (openFileDialog.ShowDialog() == true)
            {
                logoPath = openFileDialog.FileName.ToString();
                logoFile.Content = logoPath;
            }
        }

        /// <summary>
        /// initialises the fontSizeCB varible, which gives us the font size value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fontSize_LostFocus(object sender, RoutedEventArgs e)
        {
            fontSizeCB = fontSize.Text;
            Console.WriteLine(fontSizeCB);
        }

        private void deblockingFilter_Checked(object sender, RoutedEventArgs e)
        {
            vdeblockingFilter = true;
        }

        private void deblockingFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            vdeblockingFilter = false;
        }

        private void deringingFilter_Checked(object sender, RoutedEventArgs e)
        {
            vderingingFilter = true;
        }

        private void deringingFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            vderingingFilter = false;
        }

        private void frameRatecb_Checked(object sender, RoutedEventArgs e)
        {
            frameRate.IsEnabled = true;
            vframeRatecb = true;
        }

        private void frameRatecb_Unchecked(object sender, RoutedEventArgs e)
        {
            frameRate.IsEnabled = false;
            vframeRatecb = false;
        }

        private void frameSize_Checked(object sender, RoutedEventArgs e)
        {
            height.IsEnabled = true;
            width.IsEnabled = true;
            vframeSize = true;
        }

        private void frameSize_Unchecked(object sender, RoutedEventArgs e)
        {
            height.IsEnabled = false;
            width.IsEnabled = false;
            vframeSize = false;
        }

        private void DisplayAspecRatio_Checked(object sender, RoutedEventArgs e)
        {
            vDisplayAspecRatio = true;
        }

        private void DisplayAspecRatio_Unchecked(object sender, RoutedEventArgs e)
        {
            vDisplayAspecRatio = false;
        }

        private void showData_Checked(object sender, RoutedEventArgs e)
        {
            dataPanel.Visibility = Visibility.Visible;
            vshowData = true;
        }

        private void showData_Unchecked(object sender, RoutedEventArgs e)
        {
            dataPanel.Visibility = Visibility.Hidden;
            vshowData = false;
        }

        private void timecodeEnable_Checked(object sender, RoutedEventArgs e)
        {
            timecodePanel.Visibility = Visibility.Visible;
            vtimecodeEnable = true;
        }

        private void timecodeEnable_Unchecked(object sender, RoutedEventArgs e)
        {
            timecodePanel.Visibility = Visibility.Hidden;
            vtimecodeEnable = false;
        }

        private void logoEnable_Checked(object sender, RoutedEventArgs e)
        {
            LogoPanel.Visibility = Visibility.Visible;
            vlogoEnable = true;
        }

        private void logoEnable_Unchecked(object sender, RoutedEventArgs e)
        {
            LogoPanel.Visibility = Visibility.Hidden;
            vlogoEnable = false;
        }

        private void cropEnabled_Checked(object sender, RoutedEventArgs e)
        {
            cropPanel.Visibility = Visibility.Visible;
            vcropEnabled = true;
        }

        private void cropEnabled_Unchecked(object sender, RoutedEventArgs e)
        {
            cropPanel.Visibility = Visibility.Hidden;
            vcropEnabled = false;
        }

        private void denoiseEnable_Checked(object sender, RoutedEventArgs e)
        {
            denoisePanel.Visibility = Visibility.Visible;
            vdenoiseEnable = true;
        }

        private void denoiseEnable_Unchecked(object sender, RoutedEventArgs e)
        {
            denoisePanel.Visibility = Visibility.Hidden;
            vdenoiseEnable = false;
        }

        private void resizeEnable_Checked(object sender, RoutedEventArgs e)
        {
            resizePanel.Visibility = Visibility.Visible;
            vresizeEnable = true;
        }

        private void resizeEnable_Unchecked(object sender, RoutedEventArgs e)
        {
            resizePanel.Visibility = Visibility.Hidden;
            vresizeEnable = false;
        }

        private void inverseTelecineEnabled_Checked(object sender, RoutedEventArgs e)
        {
            inverseTelecinePanel.Visibility = Visibility.Visible;
            vinverseTelecineEnabled = true;
        }

        private void inverseTelecineEnabled_Unchecked(object sender, RoutedEventArgs e)
        {
            inverseTelecinePanel.Visibility = Visibility.Hidden;
            vinverseTelecineEnabled = false;
        }

        private void civolutionEnabled_Unchecked(object sender, RoutedEventArgs e)
        {
            civolutionPanel.Visibility = Visibility.Hidden;
            vcivolutionEnabled = true;
        }

        private void civolutionEnabled_Checked(object sender, RoutedEventArgs e)
        {
            civolutionPanel.Visibility = Visibility.Visible;
            vcivolutionEnabled = false;
        }

        private void gopEnabled_Unchecked(object sender, RoutedEventArgs e)
        {
            vgopEnabled = true;
        }

        private void gopEnabled_Checked(object sender, RoutedEventArgs e)
        {
            vgopEnabled = false;
        }

        private void weightedPrediction_Checked(object sender, RoutedEventArgs e)
        {
            vweightedPrediction = true;
        }

        private void weightedPrediction_Unchecked(object sender, RoutedEventArgs e)
        {
            vweightedPrediction = false;
        }

        #endregion

        #region TransportProfile

        #region TransportVars
        private string ttransportName;
        private string ttransCodec;
        private string ttransBitRate;
        private string tserviceProvider;
        private string tserviceName;
        private string tPIDdata;
        private string tPIDpmt;
        private string tPIDvideo;
        private string tPIDaudio;
        private bool tconstantMuxRate;
        private string tmuxRate;
        private string tpcrInterval;
        private bool tmpegtscopyts;
        private bool tresendHeaders;
        private bool tuseLatm;
        private string tpesPayloadSize;
        private string ttablesVersion;

        private bool tproceed = false;
        private TreeModel ttree = new TreeModel();
        #endregion

        /// <summary>
        /// Has TODO. 
        /// Initialises all the global variables of the Transport Porfile
        /// </summary>
        private void getTransportVars()
        {
            ttransportName = string.IsNullOrWhiteSpace(transportName.Text) ? "0" : transportName.Text.Trim(); //must
            ttransCodec = string.IsNullOrWhiteSpace(transCodec.Text) ? "0" : transCodec.Text.Trim(); //must
            ttransBitRate = string.IsNullOrWhiteSpace(transBitRate.Text) ? "" : transBitRate.Text.Trim();
            tserviceProvider = string.IsNullOrWhiteSpace(serviceProvider.Text) ? "" : serviceProvider.Text.Trim();
            tserviceName = string.IsNullOrWhiteSpace(serviceName.Text) ? "" : serviceName.Text.Trim();
            tPIDdata = string.IsNullOrWhiteSpace(PIDdata.Text) ? "" : PIDdata.Text.Trim();
            tPIDpmt = string.IsNullOrWhiteSpace(PIDpmt.Text) ? "" : PIDpmt.Text.Trim();
            tPIDvideo = string.IsNullOrWhiteSpace(PIDvideo.Text) ? "" : PIDvideo.Text.Trim();
            tPIDaudio = string.IsNullOrWhiteSpace(PIDaudio.Text) ? "" : PIDaudio.Text.Trim();
            tmuxRate = string.IsNullOrWhiteSpace(muxRate.Text) ? "" : muxRate.Text.Trim();
            tpcrInterval = string.IsNullOrWhiteSpace(pcrInterval.Text) ? "" : pcrInterval.Text.Trim();
            tpesPayloadSize = string.IsNullOrWhiteSpace(pesPayloadSize.Text) ? "" : pesPayloadSize.Text.Trim();
            ttablesVersion = string.IsNullOrWhiteSpace(tablesVersion.Text) ? "" : tablesVersion.Text.Trim();

            if (ttransportName == "0" || ttransCodec == "0")
                System.Windows.MessageBox.Show("Please fill all the boxes that have a red star next to them!", "Data Missing", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                tproceed = true;
            }
        }

        private void putTransportVarsToTree()
        {
            if (tproceed)
            {
                ttree.Nodes.Add(new TreeNode() { controlType = "Codec", controlValue = ttransCodec });
                ttree.Nodes.Add(new TreeNode() { controlType = "include_SI", controlValue = ttransCodec });
            }
        }

        /// <summary>
        /// Proceed to MPEGTS button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void proceedToMpegts_Click(object sender, RoutedEventArgs e)
        {
            PIDpanel.Visibility = Visibility.Visible;
            PIDdatapanel.Visibility = Visibility.Visible;
            mpegtsMoreOptionsLeft.Visibility = Visibility.Visible;
            mpegtsMoreOptionsRight.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// save as other transport profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsOtherTransp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void transProfileText_Loaded(object sender, RoutedEventArgs e)
        {
            transProfileText.Text = "If the profile is an MPEGTS one, please click the Proceed to MPEGTS profile button below." +
               "Otherwise click on the Save as Other transport profile button below.";
        }

        private void constantMuxRate_Checked(object sender, RoutedEventArgs e)
        {
            //constantMuxRate.IsEnabled = false;
            tconstantMuxRate = true;
        }

        private void constantMuxRate_Unchecked(object sender, RoutedEventArgs e)
        {
            //constantMuxRate.IsEnabled = true;
            tconstantMuxRate = false;
        }

        private void mpegtscopyts_Checked(object sender, RoutedEventArgs e)
        {
            tmpegtscopyts = true;
        }

        private void mpegtscopyts_Unchecked(object sender, RoutedEventArgs e)
        {
            tmpegtscopyts = false;
        }

        private void resendHeaders_Checked(object sender, RoutedEventArgs e)
        {
            tresendHeaders = true;
        }

        private void resendHeaders_Unchecked(object sender, RoutedEventArgs e)
        {
            tresendHeaders = false;
        }

        private void useLatm_Checked(object sender, RoutedEventArgs e)
        {
            tuseLatm = true;
        }

        private void useLatm_Unchecked(object sender, RoutedEventArgs e)
        {
            tuseLatm = false;
        }
        #endregion

    }
}
