using LuteMod.TrackSelection;
using LuteMod.Converter;
using LuteMod.Sequencing;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LuteMod.IO;
using LuteMod.Indexing;
using System.Text.RegularExpressions;

namespace LuteMod
{
    public partial class MidiConverterForm : Form
    {
        private string DebugSavFilePath = @"C:\Users\Monty\AppData\Local\Mordhau\Saved\SaveGames";
        private readonly string trackCountString = "The Partition Currently Contains [track] Tracks";
        private readonly string noteCountString = "The Current Track Contains [note] Notes";
        private readonly string lowestNoteString = "[midi] Lowest Note : [note]";
        private readonly string highestNoteString = "Highest Note : [note]";
        private readonly string checkAllString = "Check All";
        private readonly string uncheckAllString = "Uncheck All";

        private readonly int clientsideTargetRange = 25;
        private readonly int serversideTargetRange = 49;

        private bool allChannelsChecked = false;
        private bool allTracksChecked = false;

        MidiLoader loader;
        MordhauConverter converter;
        PartitionIndex index;

        public MidiConverterForm()
        {
            InitializeComponent();
            loader = new MidiLoader();
            loader.SongLoaded += MidiFileLoadCompleted;
            converter = new MordhauConverter();
            PopulateMidiOctaves();
            UpdateDelTrackbutton();
            index = new PartitionIndex();
            index.LoadIndex();
            if (!index.Loaded)
            {
                Form indexNotFoundForm = new IndexNotFoundForm();
                indexNotFoundForm.ShowDialog();
            }
            PopulateIndexList();
            TargetRangeNumeric.Value = new decimal(clientsideTargetRange);
            IndividualNoteCountNumeric.Value = converter.LowNote;
        }

        private void PopulateIndexList()
        {
            PartitionIndexBox.Items.Clear();
            foreach (string item in index.PartitionNames)
            {
                PartitionIndexBox.Items.Add(item);
            }
        }

        private void MidiFileLoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            PopulateMidiChannels();
            PopulateMidiTracks();
            PopulateMidiOctaves();
            converter.SetDivision(loader.GetDivision());
            UpdateMidiOctaveButtons();
            allChannelsChecked = false;
            allTracksChecked = false;
            CheckAllChannelsButton_Click(null, null);
            CheckAllTracksButton_Click(null, null);
        }

        private void MidiConverterForm_Load(object sender, EventArgs e)
        {

        }

        private string CodeToNote(int noteCode)
        {
            if (noteCode >= 0 && noteCode < 127)
            {
                int noteID = noteCode % 12;
                int octaveID = (noteCode / 12) - 1;
                string noteName = "ERR";
                switch (noteID)
                {
                    case 0:
                        noteName = "C";
                        break;
                    case 1:
                        noteName = "C#";
                        break;
                    case 2:
                        noteName = "D";
                        break;
                    case 3:
                        noteName = "D#";
                        break;
                    case 4:
                        noteName = "E";
                        break;
                    case 5:
                        noteName = "F";
                        break;
                    case 6:
                        noteName = "F#";
                        break;
                    case 7:
                        noteName = "G";
                        break;
                    case 8:
                        noteName = "G#";
                        break;
                    case 9:
                        noteName = "A";
                        break;
                    case 10:
                        noteName = "A#";
                        break;
                    case 11:
                        noteName = "B";
                        break;
                }
                return noteName + octaveID;
            }
            return "ERR";
        }

        private void PopulateMidiOctaves()
        {
            if (loader.Loaded)
            {
                LowestNoteLabel.Text = lowestNoteString.Replace("[note]", CodeToNote(loader.GetLowNoteId())).Replace("[midi]", "Midi");
                HighestNoteLabel.Text = highestNoteString.Replace("[note]", CodeToNote(loader.GetHighNoteId()));
            }
            else
            {
                LowestNoteLabel.Text = lowestNoteString.Replace("[note]", "None").Replace("[midi]", "Midi");
                HighestNoteLabel.Text = highestNoteString.Replace("[note]", "None");
            }

            MordhauLowestNoteLabel.Text = lowestNoteString.Replace("[note]", CodeToNote(converter.LowNote)).Replace("[midi]", "Mordhau");
            MordhauHighestNoteLabel.Text = highestNoteString.Replace("[note]", CodeToNote(converter.HighNote));
            if ((loader.GetLowNoteId() < converter.LowNote || loader.GetHighNoteId() > converter.HighNote) && loader.Loaded)
            {
                ConversionNecessaryLabel.Text = "Conversion Needed";
                ConversionCheckBox.Checked = true;
            }
            else
            {
                ConversionNecessaryLabel.Text = "No Conversion Needed";
                ConversionCheckBox.Checked = false;
            }
        }

        private void PopulateMidiChannels()
        {
            ChannelsListBox.Items.Clear();
            foreach (MidiChannelItem item in loader.MidiChannelItems)
            {
                ChannelsListBox.Items.Add(item.Name, item.Active);
            }
            ChannelsListBox.Refresh();
        }

        private void PopulateMidiTracks()
        {
            TrackListBox.Items.Clear();
            foreach (TrackItem item in loader.TrackItems)
            {
                TrackListBox.Items.Add(item.Name, item.Active);
            }
            TrackListBox.Refresh();
        }

        private void PopulatePartitionChannelsAndTrackList()
        {
            PartitionTracksListBox.Items.Clear();
            PartitionChannelsListBox.Items.Clear();
            foreach (TrackItem item in converter.GetEnabledTracksInTrack(TrackSelectionComboBox.SelectedIndex))
            {
                PartitionTracksListBox.Items.Add(item.Name);
            }
            foreach (MidiChannelItem item in converter.GetEnabledChannelsInTrack(TrackSelectionComboBox.SelectedIndex))
            {
                PartitionChannelsListBox.Items.Add(item.Name);
            }
        }

        private void LoadMidiButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openMidiFileDialog = new OpenFileDialog();
            openMidiFileDialog.DefaultExt = "mid";
            openMidiFileDialog.Filter = "MIDI files|*.mid|All files|*.*";
            openMidiFileDialog.Title = "Open MIDI file";
            if (openMidiFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openMidiFileDialog.FileName;
                loader.LoadFile(fileName);

                if (fileName.Contains("\\"))
                {
                    string[] fileNameSplit = fileName.Split('\\');
                    string filteredFileName = fileNameSplit[fileNameSplit.Length - 1].Replace(".mid", "");
                    MidiNameLabel.Text = filteredFileName;
                }
                else
                {
                    MidiNameLabel.Text = fileName;
                }
            }
        }

        private void ContextMenuHelper()
        {
            if (PartitionIndexBox.Items.Count > 0 && PartitionIndexBox.SelectedIndex >= 0)
            {
                ContextMenu indexContextMenu = new ContextMenu();

                MenuItem deleteItem = indexContextMenu.MenuItems.Add("Delete");
                deleteItem.Click += new EventHandler(DeleteItem_Click);
                PartitionIndexBox.ContextMenu = indexContextMenu;
                indexContextMenu.Show(PartitionIndexBox, PartitionIndexBox.PointToClient(Cursor.Position));
            }
            else
            {
                PartitionIndexBox.ContextMenu = null;
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Do you want to delete this partition ?",
                                     "Confirm Deletion",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var selectedList = new List<int>();
                IEnumerable<int> selectedEnum;

                selectedEnum = PartitionIndexBox.SelectedIndices.Cast<int>();
                // Just in case some weird shit happens again
                // TLDR, because MouseDown had DoDragDrop, it induced a rare bug in .net framework which made it fail to iterate or AddRange for this type of ListBox
                // We now only DoDragDrop if a key isn't held, so it should be relatively impossible to induce, but if it does, it will silently fail
                try
                {
                    selectedList.AddRange(selectedEnum);
                }
                catch { return; }
                selectedList.Sort((a, b) => b.CompareTo(a)); // Sort largest first so we don't have issues when we remove them
                foreach (int selected in selectedList)
                {
                    try
                    {
                        SaveManager.DeleteData(SaveManager.SaveFilePath + index.PartitionNames[selected]);
                        index.PartitionNames.RemoveAt(selected);
                    }
                    catch { }
                }
                PopulateIndexList();
                index.SaveIndex();
            }
        }

        private void TrackListBox_Check(object sender, ItemCheckEventArgs e)
        {
            if (allTracksChecked && !(e.CurrentValue == CheckState.Unchecked))
            {
                allTracksChecked = !allTracksChecked;
                CheckAllTracksButton.Text = checkAllString;
            }
            loader.TrackToggle(e.Index, !(e.CurrentValue == CheckState.Checked));
        }

        private void ChannelListBox_Check(object sender, ItemCheckEventArgs e)
        {
            if (allChannelsChecked && !(e.CurrentValue == CheckState.Unchecked))
            {
                allChannelsChecked = !allChannelsChecked;
                CheckAllChannelsButton.Text = checkAllString;
            }
            loader.ChannelToggle(e.Index, !(e.CurrentValue == CheckState.Checked));
        }

        private void OctaveDownButton_Click(object sender, EventArgs e)
        {
            converter.MoveOctave(false);
            UpdateOctaveButtons();
            PopulateMidiOctaves();
        }

        private void OctaveUpButton_Click(object sender, EventArgs e)
        {
            converter.MoveOctave(true);
            UpdateOctaveButtons();
            PopulateMidiOctaves();
        }

        private void UpdateOctaveButtons()
        {
            OctaveUpButton.Enabled = converter.CanMoveOctave(true);
            OctaveDownButton.Enabled = converter.CanMoveOctave(false);
        }

        private void UpdateMidiOctaveButtons()
        {
            MidiOctaveUpButton.Enabled = loader.CanMoveOctave(true);
            MidiOctaveDownButton.Enabled = loader.CanMoveOctave(false);
        }

        private void UpdateTrackAndNoteCounter()
        {
            TrackAmountLabel.Text = trackCountString.Replace("[track]", converter.GetTrackCount().ToString());
            if (TrackSelectionComboBox.SelectedIndex > -1)
            {
                NoteCountLabel.Text = noteCountString.Replace("[note]", converter.GetNoteCount(TrackSelectionComboBox.SelectedIndex).ToString());
            }
            else
            {
                NoteCountLabel.Text = noteCountString.Replace("[note]", "0");
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            converter.ChangePartitionName(NameTextBox.Text);
        }

        private void UpdateDelTrackbutton()
        {
            DeleteTrackButton.Enabled = TrackSelectionComboBox.Items.Count > 0 && TrackSelectionComboBox.SelectedIndex >= 0;
            AddToCurrentTrackButton.Enabled = TrackSelectionComboBox.Items.Count > 0 && TrackSelectionComboBox.SelectedIndex >= 0;
        }

        private void AddTrackButton_Click(object sender, EventArgs e)
        {
            converter.AddTrack();
            TrackSelectionComboBox.Items.Add("Track " + converter.GetTrackCount());
            UpdateTrackAndNoteCounter();
            UpdateDelTrackbutton();
        }

        private void DeleteTrackButton_Click(object sender, EventArgs e)
        {
            converter.DelTrack(TrackSelectionComboBox.SelectedIndex);
            int index = TrackSelectionComboBox.SelectedIndex;
            TrackSelectionComboBox.SelectedIndex--;
            TrackSelectionComboBox.Items.RemoveAt(index);
            UpdateTrackAndNoteCounter();
            UpdateDelTrackbutton();
        }

        private void AddToCurrentTrackButton_Click(object sender, EventArgs e)
        {
            converter.FillTrack(TrackSelectionComboBox.SelectedIndex, loader.ExtractMidiContent());
            converter.SetEnabledTracksInTrack(TrackSelectionComboBox.SelectedIndex, loader.TrackItems);
            converter.SetEnabledMidiChannelsInTrack(TrackSelectionComboBox.SelectedIndex, loader.MidiChannelItems);
            UpdateTrackAndNoteCounter();
            PopulatePartitionChannelsAndTrackList();
        }

        private void TrackSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTrackAndNoteCounter();
            PopulatePartitionChannelsAndTrackList();
            UpdateDelTrackbutton();
        }

        private void AddInNewTrackButton_Click(object sender, EventArgs e)
        {
            AddTrackButton_Click(sender, e);
            TrackSelectionComboBox.SelectedIndex = TrackSelectionComboBox.Items.Count - 1;
            AddToCurrentTrackButton_Click(sender, e);
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (converter.GetTrackCount() > 0)
            {
                if (NameTextBox.Text == "Partition Name" || NameTextBox.Text.Trim() == "")
                {
                    MessageBox.Show("Please name your partition");
                }
                else
                {
                    if (index.PartitionNames.Contains(NameTextBox.Text))
                    {
                        MessageBox.Show("That name already exists");
                    }
                    else
                    {
                        if (!Regex.IsMatch(NameTextBox.Text, "^([a-zA-Z0-9][a-zA-Z0-9 ]*[a-zA-Z0-9])$"))
                        {
                            MessageBox.Show("That name contains invalid characters");
                        }
                        else
                        {
                            index.PartitionNames.Add(NameTextBox.Text);
                            SaveManager.WriteSaveFile(SaveManager.SaveFilePath + NameTextBox.Text, converter.GetPartitionToString());
                            index.SaveIndex();
                            ClearPartitionButton_Click(null, null);
                            PopulateIndexList();
                        } 
                    }
                }
            }
            else
            {
                MessageBox.Show("The partition is empty");
            }
        }

        private void OpenPartitionFolderButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", SaveManager.SaveFilePath);
        }

        private void PartitionIndexBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void PartitionIndexBox_DragDrop(object sender, DragEventArgs e)
        {
            Point point = PartitionIndexBox.PointToClient(new Point(e.X, e.Y));
            int i = this.PartitionIndexBox.IndexFromPoint(point);
            if (i < 0) i = this.PartitionIndexBox.Items.Count - 1;
            object data = e.Data.GetData(typeof(string));
            if (data != null)
            {
                this.PartitionIndexBox.Items.Remove(data);
                this.PartitionIndexBox.Items.Insert(i, data);
                index.PartitionNames.Remove((string)data);
                index.PartitionNames.Insert(i, (string)data);
                index.SaveIndex();
            }
        }

        private void PartitionIndexBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.PartitionIndexBox.SelectedItem == null) return;
            if (Control.ModifierKeys == Keys.None) // Prevents a bug when multi-selecting
                this.PartitionIndexBox.DoDragDrop(this.PartitionIndexBox.SelectedItem, DragDropEffects.Move);
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuHelper();
            }
        }

        private void CheckAllChannelsButton_Click(object sender, EventArgs e)
        {
            if (allChannelsChecked)
            {
                for (int i = 0; i < loader.MidiChannelItems.Count; i++)
                {
                    loader.ChannelToggle(i, false);
                }
                CheckAllChannelsButton.Text = checkAllString;
            }
            else
            {
                for (int i = 0; i < loader.MidiChannelItems.Count; i++)
                {
                    loader.ChannelToggle(i, true);
                }
                CheckAllChannelsButton.Text = uncheckAllString;
            }
            allChannelsChecked = !allChannelsChecked;
            PopulateMidiChannels();
        }

        private void CheckAllTracksButton_Click(object sender, EventArgs e)
        {
            if (allTracksChecked)
            {
                for (int i = 0; i < loader.TrackItems.Count; i++)
                {
                    loader.TrackToggle(i, false);
                }
                CheckAllTracksButton.Text = checkAllString;
            }
            else
            {
                for (int i = 0; i < loader.TrackItems.Count; i++)
                {
                    loader.TrackToggle(i, true);
                }
                CheckAllTracksButton.Text = uncheckAllString;
            }
            allTracksChecked = !allTracksChecked;
            PopulateMidiTracks();
        }

        private void MidiOctaveDownButton_Click(object sender, EventArgs e)
        {
            loader.MoveOctave(false);
            UpdateMidiOctaveButtons();
            PopulateMidiOctaves();
        }

        private void MidiOctaveUpButton_Click(object sender, EventArgs e)
        {
            loader.MoveOctave(true);
            UpdateMidiOctaveButtons();
            PopulateMidiOctaves();
        }

        private void TargetRangeNumeric_ValueChanged(object sender, EventArgs e)
        {
            converter.Range = int.Parse(TargetRangeNumeric.Value.ToString());
            UpdateOctaveButtons();
            UpdateMidiOctaveButtons();
            PopulateMidiOctaves();
        }

        private void ConversionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            converter.IsConversionEnabled = ConversionCheckBox.Checked;
        }

        private void ClearPartitionButton_Click(object sender, EventArgs e)
        {
            converter.ClearPartition();
            TrackSelectionComboBox.SelectedIndex = -1;
            TrackSelectionComboBox.Items.Clear();
            UpdateDelTrackbutton();
            PopulatePartitionChannelsAndTrackList();
            NameTextBox.Text = "Partition Name";
        }

        private void ImportPartitionButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openSavFileDialog = new OpenFileDialog();
            string[] fileNames;
            openSavFileDialog.DefaultExt = "sav";
            openSavFileDialog.Filter = "SAV files|*.sav";
            openSavFileDialog.Title = "Open SAV file";
            openSavFileDialog.Multiselect = true;
            if (openSavFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileNames = openSavFileDialog.FileNames;
                foreach (string fileName in fileNames)
                {
                    index.AddFileInIndex(fileName);
                }
                index.SaveIndex();
                PopulateIndexList();
            }
        }

        private void DefaultClientNoteCountButton_Click(object sender, EventArgs e)
        {
            converter.Range = clientsideTargetRange;
            TargetRangeNumeric.Value = clientsideTargetRange;
            UpdateOctaveButtons();
            UpdateMidiOctaveButtons();
            PopulateMidiOctaves();
        }

        private void DefaultServerNoteCountButton_Click(object sender, EventArgs e)
        {
            converter.Range = serversideTargetRange;
            TargetRangeNumeric.Value = serversideTargetRange;
            UpdateOctaveButtons();
            UpdateMidiOctaveButtons();
            PopulateMidiOctaves();
        }

        private void IndividualNoteCountNumeric_ValueChanged(object sender, EventArgs e)
        {
            converter.LowNote = (int)IndividualNoteCountNumeric.Value;
            UpdateOctaveButtons();
            PopulateMidiOctaves();
        }
    }
}
/* |TestPartition;2000|0-0-Pulse;250-1-Pulse;500-2-Pulse;750-3-Pulse;1000-4-Pulse;1250-5-Pulse;1500-6-Pulse;1750-7-Pulse;2000-8-Pulse;2250-9-Pulse;2500-10-Pulse;2750-11-Pulse;3000-12-Pulse;3250-13-Pulse;3500-14-Pulse;3750-15-Pulse;4000-16-Pulse;4250-17-Pulse;4500-18-Pulse;4750-19-Pulse;5000-20-Pulse;5250-21-Pulse;5500-22-Pulse;5750-23-Pulse;6000-24-Pulse;6250-25-Pulse;6500-26-Pulse;6750-27-Pulse;7000-28-Pulse;7250-29-Pulse;7500-30-Pulse;7750-31-Pulse;8000-32-Pulse;8250-33-Pulse;8500-34-Pulse;8750-35-Pulse;9000-36-Pulse;9250-37-Pulse;9500-38-Pulse;9750-39-Pulse;10000-40-Pulse;10250-41-Pulse;10500-42-Pulse;10750-43-Pulse;11000-44-Pulse;11250-45-Pulse;11500-46-Pulse;11750-47-Pulse;12000-48-Pulse|0-48-Pulse;250-47-Pulse;500-46-Pulse;750-45-Pulse;1000-44-Pulse;1250-43-Pulse;1500-42-Pulse;1750-41-Pulse;2000-40-Pulse;2250-39-Pulse;2500-38-Pulse;2750-37-Pulse;3000-36-Pulse;3250-35-Pulse;3500-34-Pulse;3750-33-Pulse;4000-32-Pulse;4250-31-Pulse;4500-30-Pulse;4750-29-Pulse;5000-28-Pulse;5250-27-Pulse;5500-26-Pulse;5750-25-Pulse;6000-24-Pulse;6250-23-Pulse;6500-22-Pulse;6750-21-Pulse;7000-20-Pulse;7250-19-Pulse;7500-18-Pulse;7750-17-Pulse;8000-16-Pulse;8250-15-Pulse;8500-14-Pulse;8750-13-Pulse;9000-12-Pulse;9250-11-Pulse;9500-10-Pulse;9750-9-Pulse;10000-8-Pulse;10250-7-Pulse;10500-6-Pulse;10750-5-Pulse;11000-4-Pulse;11250-3-Pulse;11500-2-Pulse;11750-1-Pulse;12000-0-Pulse|
 * |TestPartition;2000|0-0-Pulse;250-1-Pulse;500-2-Pulse;750-3-Pulse;1000-4-Pulse;1250-5-Pulse;1500-6-Pulse;1750-7-Pulse;2000-8-Pulse;2250-9-Pulse;2500-10-Pulse;2750-11-Pulse;3000-12-Pulse;3250-13-Pulse;3500-14-Pulse;3750-15-Pulse;4000-16-Pulse;4250-17-Pulse;4500-18-Pulse;4750-19-Pulse;5000-20-Pulse;5250-21-Pulse;5500-22-Pulse;5750-23-Pulse;6000-24-Pulse;6250-25-Pulse;6500-26-Pulse;6750-27-Pulse;7000-28-Pulse;7250-29-Pulse;7500-30-Pulse;7750-31-Pulse;8000-32-Pulse;8250-33-Pulse;8500-34-Pulse;8750-35-Pulse;9000-36-Pulse;9250-37-Pulse;9500-38-Pulse;9750-39-Pulse;10000-40-Pulse;10250-41-Pulse;10500-42-Pulse;10750-43-Pulse;11000-44-Pulse;11250-45-Pulse;11500-46-Pulse;11750-47-Pulse;12000-48-Pulse|0-48-Pulse;250-47-Pulse;500-46-Pulse;750-45-Pulse;1000-44-Pulse;1250-43-Pulse;1500-42-Pulse;1750-41-Pulse;2000-40-Pulse;2250-39-Pulse;2500-38-Pulse;2750-37-Pulse;3000-36-Pulse;3250-35-Pulse;3500-34-Pulse;3750-33-Pulse;4000-32-Pulse;4250-31-Pulse;4500-30-Pulse;4750-29-Pulse;5000-28-Pulse;5250-27-Pulse;5500-26-Pulse;5750-25-Pulse;6000-24-Pulse;6250-23-Pulse;6500-22-Pulse;6750-21-Pulse;7000-20-Pulse;7250-19-Pulse;7500-18-Pulse;7750-17-Pulse;8000-16-Pulse;8250-15-Pulse;8500-14-Pulse;8750-13-Pulse;9000-12-Pulse;9250-11-Pulse;9500-10-Pulse;9750-9-Pulse;10000-8-Pulse;10250-7-Pulse;10500-6-Pulse;10750-5-Pulse;11000-4-Pulse;11250-3-Pulse;11500-2-Pulse;11750-1-Pulse;12000-0-Pulse|
 * 
 * |DebugPartition|Debug|
 */

