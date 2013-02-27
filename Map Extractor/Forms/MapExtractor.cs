/****************************************************************************************************
 * 
 *   Filename    : MapExtractor.cs
 *   
 *   Description : Main window that allows the user to manipulate map files
 *
 *   Copyright (C) 2013  Dougan Ironfist
 *
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *   
 ***************************************************************************************************/

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Map_Extractor
{
    public partial class MapExtractor : Form
    {
        #region Variables
        private Thread backgroundThread = null;

        private Map sourcemap = null;
        private Map destinationmap = null;
        private Map destinationmapOriginal = null;
        private Statics sourcestatics = null;
        private Statics destinationstatics = null;
        private Statics destinationstaticsOriginal = null;
        #endregion

        #region Constructor
        public MapExtractor()
        {
            InitializeComponent();

            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Text = String.Format("Map Extractor {0}.{1}", v.Major, v.Minor);

            Load_Parameters();
        }
        #endregion

        #region Load_Parameters
        private void Load_Parameters()
        {
            Parameters.LoadParameters();

            sourceFiles.Text = Parameters.SourcePath;
            sourceMap.SelectedIndex = Parameters.SourceMap;
            destinationFiles.Text = Parameters.DestinationPath;
            destinationMap.SelectedIndex = Parameters.DestinationMap;
            copyStatics.Checked = Parameters.CopyStatics;
            entireMap.Checked = Parameters.EntireMap;
            portion.Checked = !Parameters.EntireMap;
            srcX.Value = Parameters.SourceArea.X;
            srcY.Value = Parameters.SourceArea.Y;
            srcW.Value = Parameters.SourceArea.Width;
            srcH.Value = Parameters.SourceArea.Height;
            destX.Value = Parameters.DestinationLocation.X;
            destY.Value = Parameters.DestinationLocation.Y;
            sourceIndex.Value = Parameters.SourceFileIndex;
            sourceWidth.Value = Parameters.SourceSize.Width;
            sourceHeight.Value = Parameters.SourceSize.Height;
            destinationIndex.Value = Parameters.DestinationFileIndex;
            destinationWidth.Value = Parameters.DestinationSize.Width;
            destinationHeight.Value = Parameters.DestinationSize.Height;
        }
        #endregion

        #region Save_Parameters
        private void Save_Parameters()
        {
            Parameters.SourcePath = sourceFiles.Text;
            Parameters.DestinationPath = destinationFiles.Text;
            Parameters.SourceMap = sourceMap.SelectedIndex;
            Parameters.DestinationMap = destinationMap.SelectedIndex;
            Parameters.CopyStatics = copyStatics.Checked;
            Parameters.EntireMap = entireMap.Checked;
            Parameters.SourceArea = new Rectangle(srcX.Value, srcY.Value, srcW.Value, srcH.Value);
            Parameters.DestinationLocation = new Point(destX.Value, destY.Value);
            Parameters.SourceFileIndex = sourceIndex.Value;
            Parameters.SourceSize = new System.Drawing.Size(sourceWidth.Value, sourceHeight.Value);
            Parameters.DestinationFileIndex = destinationIndex.Value;
            Parameters.DestinationSize = new System.Drawing.Size(destinationWidth.Value, destinationHeight.Value);

            Parameters.SaveParameters();
        }
        #endregion

        #region Delegates
        public delegate void Int32Delegate(Int32 value);
        public delegate void StringDelegate(String value);
        public delegate void EmptyDelegate();
        public delegate void CursorChangeDelegate(Cursor value);
        public delegate void BooleanDelegate(Boolean value);

        private void IncrementProgress()
        {
            if (backgroundThread != null)
                progress.Increment(1);
        }

        private void UpdateCursor(Cursor cursor)
        {
            if (backgroundThread != null)
                Cursor = cursor;
        }

        private void DisplayMessage(String text)
        {
            if (backgroundThread != null)
                MessageBox.Show(text);
        }

        private void ProgressBarInitialization(Int32 value)
        {
            if (backgroundThread != null)
            {
                progress.Value = 0;
                progress.Maximum = value;
            }
        }

        private void ProgressBarVisible(Boolean value)
        {
            if (backgroundThread != null)
                progress.Visible = value;
        }

        private void Enabler(Boolean value)
        {
            if (backgroundThread != null)
            {
                sourceFiles.Enabled = value;
                destinationFiles.Enabled = value;
                sourceMap.Enabled = value;
                destinationMap.Enabled = value;
                entireMap.Enabled = value;
                portion.Enabled = value;
                copyStatics.Enabled = value;
                srcX.Enabled = value;
                srcY.Enabled = value;
                srcW.Enabled = value;
                srcH.Enabled = value;
                destX.Enabled = value;
                destY.Enabled = value;
                sourceIndex.Enabled = value;
                sourceWidth.Enabled = value;
                sourceHeight.Enabled = value;
                destinationIndex.Enabled = value;
                destinationWidth.Enabled = value;
                destinationHeight.Enabled = value;
                conversionButton.Enabled = value;
                btnStart.Enabled = value;
            }
        }

        private void CloseFiles(Boolean overridden)
        {
            if (backgroundThread != null || overridden)
            {
                sourcemap.Close();
                destinationmap.Close();
                destinationmapOriginal.Close();

                if (Parameters.CopyStatics)
                {
                    sourcestatics.Close();
                    destinationstatics.Close();
                    destinationstaticsOriginal.Close();
                }
            }
        }
        #endregion

        #region MapExtractor_FormClosing
        private void MapExtractor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundThread != null)
                e.Cancel = true;
            else
                Save_Parameters();
        }
        #endregion

        #region mulFiles_DropDownClicked
        private void mulFiles_DropDownClicked(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog(this);

            if (dialog.SelectedPath != "")
                sourceFiles.Text = dialog.SelectedPath;
        }
        #endregion

        #region destinationFiles_DropDownClicked
        private void destinationFiles_DropDownClicked(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog(this);

            if (dialog.SelectedPath != "")
                destinationFiles.Text = dialog.SelectedPath;
        }
        #endregion

        #region Initialize_Map
        private void Initialize_Map(Int32 fileIndex, ref Map map, Boolean source)
        {
            switch (fileIndex)
            {
                case 0:
                    map = new Map(0, 6144, 4096);
                    break;
                case 1:
                    map = new Map(0, 7168, 4096);
                    break;
                case 2:
                    map = new Map(1, 6144, 4096);
                    break;
                case 3:
                    map = new Map(1, 7168, 4096);
                    break;
                case 4:
                    map = new Map(2, 2304, 1600);
                    break;
                case 5:
                    map = new Map(3, 2560, 2048);
                    break;
                case 6:
                    map = new Map(4, 1448, 1448);
                    break;
                case 7:
                    map = new Map(5, 1280, 4096);
                    break;
                case 8:
                    if (source)
                        map = new Map(sourceIndex.Value, sourceWidth.Value, sourceHeight.Value);
                    else
                        map = new Map(destinationIndex.Value, destinationWidth.Value, destinationHeight.Value);

                    break;
            }
        }
        #endregion

        #region Initialize_Statics
        private void Initialize_Statics(Int32 fileIndex, ref Statics statics, Boolean source)
        {
            switch (fileIndex)
            {
                case 0:
                    statics = new Statics(0, 6144, 4096);
                    break;
                case 1:
                    statics = new Statics(0, 7168, 4096);
                    break;
                case 2:
                    statics = new Statics(1, 6144, 4096);
                    break;
                case 3:
                    statics = new Statics(1, 7168, 4096);
                    break;
                case 4:
                    statics = new Statics(2, 2304, 1600);
                    break;
                case 5:
                    statics = new Statics(3, 2560, 2048);
                    break;
                case 6:
                    statics = new Statics(4, 1448, 1448);
                    break;
                case 7:
                    statics = new Statics(5, 1280, 4096);
                    break;
                case 8:
                    if (source)
                        statics = new Statics(sourceIndex.Value, sourceWidth.Value, sourceHeight.Value);
                    else
                        statics = new Statics(destinationIndex.Value, destinationWidth.Value, destinationHeight.Value);

                    break;
            }
        }
        #endregion

        #region btnStart_Click
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (portion.Checked && (srcX.Value == -1 || srcY.Value == -1 || srcW.Value == -1 || srcH.Value == -1 || destX.Value == -1 || destY.Value == -1))
            {
                MessageBox.Show("Please complete all of the coordinates to continue.");
                return;
            }

            if ((sourceMap.SelectedIndex == 8) && (sourceIndex.Value == -1 || sourceWidth.Value == -1 || sourceHeight.Value == -1))
            {
                MessageBox.Show("Please complete the custom source map settings to continue.");
                return;
            }

            if ((destinationMap.SelectedIndex == 8) && (destinationIndex.Value == -1 || destinationWidth.Value == -1 || destinationHeight.Value == -1))
            {
                MessageBox.Show("Please complete the custom destination map settings to continue.");
                return;
            }

            Save_Parameters();

            sourcemap = null;
            destinationmap = null;
            destinationmapOriginal = null;
            sourcestatics = null;
            destinationstatics = null;
            destinationstaticsOriginal = null;

            Initialize_Map(sourceMap.SelectedIndex, ref sourcemap, true);
            Initialize_Map(destinationMap.SelectedIndex, ref destinationmap, false);
            Initialize_Map(destinationMap.SelectedIndex, ref destinationmapOriginal, false);

            if (Parameters.CopyStatics)
            {
                Initialize_Statics(sourceMap.SelectedIndex, ref sourcestatics, true);
                Initialize_Statics(destinationMap.SelectedIndex, ref destinationstatics, false);
                Initialize_Statics(destinationMap.SelectedIndex, ref destinationstaticsOriginal, false);
            }

            if (sourcemap == null || destinationmap == null || destinationmapOriginal == null ||
                ((sourcestatics == null || destinationstatics == null || destinationstaticsOriginal == null) && Parameters.CopyStatics) ||
                sourceFiles.Text == "" || destinationFiles.Text == "")
                return;

            bool result = true;

            if (sourcemap.FileIndex == destinationmap.FileIndex && sourceFiles.Text == destinationFiles.Text)
                result = false;

            if (result)
            {
                result &= sourcemap.OpenMap(sourceFiles.Text, false);
                destinationmapOriginal.BackupMap(destinationFiles.Text);
                result &= destinationmap.OpenMap(destinationFiles.Text, true);

                if (Parameters.CopyStatics)
                {
                    result &= sourcestatics.OpenStatics(sourceFiles.Text, false);
                    destinationstaticsOriginal.BackupStatics(destinationFiles.Text);
                    result &= destinationstatics.OpenStatics(destinationFiles.Text, true);
                }
            }

            if (result)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Extract));
                }
                catch
                {
                    MessageBox.Show("An error occurred starting the process background thread.  Please restart E Med Pro and try again.\n\nPlease contact your system administrator if this problems persists.");
                    Close();
                }
            }
            else
            {
                Invoke((BooleanDelegate)CloseFiles, true);
                MessageBox.Show("Error opening files. Please verify your settings.");
            }
        }
        #endregion

        #region Extract
        private void Extract(object state)
        {
            try
            {
                backgroundThread = Thread.CurrentThread;

                Invoke((CursorChangeDelegate)UpdateCursor, Cursors.WaitCursor);

                Rectangle source = new Rectangle(0, 0, sourcemap.Width, sourcemap.Height);
                Rectangle destination = new Rectangle(0, 0, destinationmap.Width, destinationmap.Height);

                if (portion.Checked)
                {
                    source = new Rectangle(Parameters.SourceArea.X / 8, Parameters.SourceArea.Y / 8,
                        Parameters.SourceArea.Width / 8, Parameters.SourceArea.Height / 8);

                    destination = new Rectangle(Parameters.DestinationLocation.X / 8, Parameters.DestinationLocation.Y / 8,
                        source.Width, source.Height);
                }

                Invoke((Int32Delegate)ProgressBarInitialization, destinationmap.Width * destinationmap.Height);
                Invoke((BooleanDelegate)ProgressBarVisible, true);
                Invoke((BooleanDelegate)Enabler, false);

                for (Int32 x = 0; x < destinationmap.Width; x++)
                {
                    for (Int32 y = 0; y < destinationmap.Height; y++)
                    {
                        if (destination.Contains(x, y))
                        {
                            Int32 offsetX = x - destination.X;
                            Int32 offsetY = y - destination.Y;

                            Int32 sourceX = offsetX + source.X;
                            Int32 sourceY = offsetY + source.Y;

                            if (source.Contains(sourceX, sourceY))
                            {
                                Block b = sourcemap.ReadBlock(sourceX, sourceY);
                                destinationmap.WriteBlock(b, x, y);

                                if (Parameters.CopyStatics)
                                {
                                    IDX idx = sourcestatics.ReadBlock(sourceX, sourceY);
                                    destinationstatics.WriteBlock(idx, x, y);
                                }
                            }
                            else
                            {
                                if (destinationmapOriginal.FileOpen)
                                {
                                    Block b = destinationmapOriginal.ReadBlock(x, y);
                                    destinationmap.WriteBlock(b, x, y);

                                    if (Parameters.CopyStatics)
                                    {
                                        if (destinationstaticsOriginal.FileOpen)
                                        {
                                            IDX idx = destinationstaticsOriginal.ReadBlock(x, y);
                                            destinationstatics.WriteBlock(idx, x, y);
                                        }
                                        else
                                        {
                                            destinationstatics.WriteEmptyBlock(x, y);
                                        }
                                    }
                                }
                                else
                                {
                                    destinationmap.WriteEmptyBlock(x, y);

                                    if (Parameters.CopyStatics)
                                        destinationstatics.WriteEmptyBlock(x, y);
                                }
                            }
                        }
                        else
                        {
                            if (destinationmapOriginal.FileOpen)
                            {
                                Block b = destinationmapOriginal.ReadBlock(x, y);
                                destinationmap.WriteBlock(b, x, y);

                                if (Parameters.CopyStatics)
                                {
                                    if (destinationstaticsOriginal.FileOpen)
                                    {
                                        IDX idx = destinationstaticsOriginal.ReadBlock(x, y);
                                        destinationstatics.WriteBlock(idx, x, y);
                                    }
                                    else
                                    {
                                        destinationstatics.WriteEmptyBlock(x, y);
                                    }
                                }
                            }
                            else
                            {
                                destinationmap.WriteEmptyBlock(x, y);

                                if (Parameters.CopyStatics)
                                    destinationstatics.WriteEmptyBlock(x, y);
                            }
                        }

                        Invoke((EmptyDelegate)IncrementProgress);
                    }
                }

                Invoke((BooleanDelegate)CloseFiles, false);
                Invoke((BooleanDelegate)ProgressBarVisible, false);
                Invoke((BooleanDelegate)Enabler, true);
                Invoke((CursorChangeDelegate)UpdateCursor, Cursors.Default);
                Invoke((StringDelegate)DisplayMessage, "Extraction Complete!");
            }
            catch { }

            backgroundThread = null;
        }
        #endregion

        #region portion_CheckedChanged
        private void portion_CheckedChanged(object sender, EventArgs e)
        {
            coordBox.Enabled = portion.Checked;
        }
        #endregion

        #region conversionButton_Click
        private void conversionButton_Click(object sender, EventArgs e)
        {
            ConversionTable ct = new ConversionTable();
            ct.Initialize();
            ct.ShowDialog(this);
        }
        #endregion

        #region divisible_Leave
        private void divisible_Leave(object sender, EventArgs e)
        {
            if (sender is FilteredTextBox)
            {
                FilteredTextBox ftb = (FilteredTextBox)sender;

                if (ftb.Text != "")
                {
                    Int32 value = 0;

                    Int32.TryParse(ftb.Text, out value);

                    ftb.Text = ((value / 8) * 8).ToString();
                }
            }
        }
        #endregion

        #region sourceMap_SelectedIndexChanged
        private void sourceMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            customSourceBox.Enabled = (sourceMap.SelectedIndex == 8);
        }
        #endregion

        #region destinationMap_SelectedIndexChanged
        private void destinationMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            customDestinationBox.Enabled = (destinationMap.SelectedIndex == 8);
        }
        #endregion
    }
}
