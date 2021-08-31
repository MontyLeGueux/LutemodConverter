using System;

namespace LuteMod
{
    partial class MidiConverterForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadMidiButton = new System.Windows.Forms.Button();
            this.MidiGroupBox = new System.Windows.Forms.GroupBox();
            this.CheckAllTracksButton = new System.Windows.Forms.Button();
            this.CheckAllChannelsButton = new System.Windows.Forms.Button();
            this.TransposeMidiRangeLabel = new System.Windows.Forms.Label();
            this.MidiOctaveUpButton = new System.Windows.Forms.Button();
            this.MidiOctaveDownButton = new System.Windows.Forms.Button();
            this.TransposeRangeLabel = new System.Windows.Forms.Label();
            this.TargetLabel = new System.Windows.Forms.Label();
            this.TargetRangeNumeric = new System.Windows.Forms.NumericUpDown();
            this.ConversionCheckBox = new System.Windows.Forms.CheckBox();
            this.OctaveUpButton = new System.Windows.Forms.Button();
            this.OctaveDownButton = new System.Windows.Forms.Button();
            this.MordhauHighestNoteLabel = new System.Windows.Forms.Label();
            this.MordhauLowestNoteLabel = new System.Windows.Forms.Label();
            this.ConversionNecessaryLabel = new System.Windows.Forms.Label();
            this.HighestNoteLabel = new System.Windows.Forms.Label();
            this.LowestNoteLabel = new System.Windows.Forms.Label();
            this.TrackListBox = new System.Windows.Forms.CheckedListBox();
            this.ChannelsListBox = new System.Windows.Forms.CheckedListBox();
            this.MidiNameLabel = new System.Windows.Forms.Label();
            this.LuteModGroupBox = new System.Windows.Forms.GroupBox();
            this.NoteCountLabel = new System.Windows.Forms.Label();
            this.DeleteTrackButton = new System.Windows.Forms.Button();
            this.AddTrackButton = new System.Windows.Forms.Button();
            this.SelectTrackLabel = new System.Windows.Forms.Label();
            this.TrackSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.TrackAmountLabel = new System.Windows.Forms.Label();
            this.PartitionTracksListBox = new System.Windows.Forms.ListBox();
            this.PartitionChannelsListBox = new System.Windows.Forms.ListBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.AddToCurrentTrackButton = new System.Windows.Forms.Button();
            this.AddInNewTrackButton = new System.Windows.Forms.Button();
            this.PartitionsIndexLabel = new System.Windows.Forms.Label();
            this.PartitionIndexBox = new System.Windows.Forms.ListBox();
            this.OpenPartitionFolderButton = new System.Windows.Forms.Button();
            this.ClearPartitionButton = new System.Windows.Forms.Button();
            this.ImportPartitionButton = new System.Windows.Forms.Button();
            this.DefaultClientNoteCountButton = new System.Windows.Forms.Button();
            this.DefaultServerNoteCountButton = new System.Windows.Forms.Button();
            this.IndividualNoteCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.MidiGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetRangeNumeric)).BeginInit();
            this.LuteModGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IndividualNoteCountNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadMidiButton
            // 
            this.LoadMidiButton.Location = new System.Drawing.Point(6, 486);
            this.LoadMidiButton.Name = "LoadMidiButton";
            this.LoadMidiButton.Size = new System.Drawing.Size(310, 30);
            this.LoadMidiButton.TabIndex = 0;
            this.LoadMidiButton.Text = "Load Midi File";
            this.LoadMidiButton.UseVisualStyleBackColor = true;
            this.LoadMidiButton.Click += new System.EventHandler(this.LoadMidiButton_Click);
            // 
            // MidiGroupBox
            // 
            this.MidiGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.MidiGroupBox.Controls.Add(this.IndividualNoteCountNumeric);
            this.MidiGroupBox.Controls.Add(this.DefaultServerNoteCountButton);
            this.MidiGroupBox.Controls.Add(this.DefaultClientNoteCountButton);
            this.MidiGroupBox.Controls.Add(this.CheckAllTracksButton);
            this.MidiGroupBox.Controls.Add(this.CheckAllChannelsButton);
            this.MidiGroupBox.Controls.Add(this.TransposeMidiRangeLabel);
            this.MidiGroupBox.Controls.Add(this.MidiOctaveUpButton);
            this.MidiGroupBox.Controls.Add(this.MidiOctaveDownButton);
            this.MidiGroupBox.Controls.Add(this.TransposeRangeLabel);
            this.MidiGroupBox.Controls.Add(this.TargetLabel);
            this.MidiGroupBox.Controls.Add(this.TargetRangeNumeric);
            this.MidiGroupBox.Controls.Add(this.ConversionCheckBox);
            this.MidiGroupBox.Controls.Add(this.OctaveUpButton);
            this.MidiGroupBox.Controls.Add(this.OctaveDownButton);
            this.MidiGroupBox.Controls.Add(this.MordhauHighestNoteLabel);
            this.MidiGroupBox.Controls.Add(this.MordhauLowestNoteLabel);
            this.MidiGroupBox.Controls.Add(this.ConversionNecessaryLabel);
            this.MidiGroupBox.Controls.Add(this.HighestNoteLabel);
            this.MidiGroupBox.Controls.Add(this.LowestNoteLabel);
            this.MidiGroupBox.Controls.Add(this.TrackListBox);
            this.MidiGroupBox.Controls.Add(this.ChannelsListBox);
            this.MidiGroupBox.Controls.Add(this.MidiNameLabel);
            this.MidiGroupBox.Controls.Add(this.LoadMidiButton);
            this.MidiGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MidiGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MidiGroupBox.Location = new System.Drawing.Point(11, 12);
            this.MidiGroupBox.Name = "MidiGroupBox";
            this.MidiGroupBox.Size = new System.Drawing.Size(322, 521);
            this.MidiGroupBox.TabIndex = 2;
            this.MidiGroupBox.TabStop = false;
            this.MidiGroupBox.Text = "Midi File";
            // 
            // CheckAllTracksButton
            // 
            this.CheckAllTracksButton.Location = new System.Drawing.Point(176, 206);
            this.CheckAllTracksButton.Name = "CheckAllTracksButton";
            this.CheckAllTracksButton.Size = new System.Drawing.Size(140, 24);
            this.CheckAllTracksButton.TabIndex = 19;
            this.CheckAllTracksButton.Text = "Check All";
            this.CheckAllTracksButton.UseVisualStyleBackColor = true;
            this.CheckAllTracksButton.Click += new System.EventHandler(this.CheckAllTracksButton_Click);
            // 
            // CheckAllChannelsButton
            // 
            this.CheckAllChannelsButton.Location = new System.Drawing.Point(6, 206);
            this.CheckAllChannelsButton.Name = "CheckAllChannelsButton";
            this.CheckAllChannelsButton.Size = new System.Drawing.Size(140, 24);
            this.CheckAllChannelsButton.TabIndex = 18;
            this.CheckAllChannelsButton.Text = "Check All";
            this.CheckAllChannelsButton.UseVisualStyleBackColor = true;
            this.CheckAllChannelsButton.Click += new System.EventHandler(this.CheckAllChannelsButton_Click);
            // 
            // TransposeMidiRangeLabel
            // 
            this.TransposeMidiRangeLabel.AutoSize = true;
            this.TransposeMidiRangeLabel.Location = new System.Drawing.Point(6, 70);
            this.TransposeMidiRangeLabel.Name = "TransposeMidiRangeLabel";
            this.TransposeMidiRangeLabel.Size = new System.Drawing.Size(115, 13);
            this.TransposeMidiRangeLabel.TabIndex = 17;
            this.TransposeMidiRangeLabel.Text = "Transpose Midi range :";
            // 
            // MidiOctaveUpButton
            // 
            this.MidiOctaveUpButton.Location = new System.Drawing.Point(216, 65);
            this.MidiOctaveUpButton.Name = "MidiOctaveUpButton";
            this.MidiOctaveUpButton.Size = new System.Drawing.Size(75, 22);
            this.MidiOctaveUpButton.TabIndex = 16;
            this.MidiOctaveUpButton.Text = "+1 Octave";
            this.MidiOctaveUpButton.UseVisualStyleBackColor = true;
            this.MidiOctaveUpButton.Click += new System.EventHandler(this.MidiOctaveUpButton_Click);
            // 
            // MidiOctaveDownButton
            // 
            this.MidiOctaveDownButton.Location = new System.Drawing.Point(135, 65);
            this.MidiOctaveDownButton.Name = "MidiOctaveDownButton";
            this.MidiOctaveDownButton.Size = new System.Drawing.Size(75, 22);
            this.MidiOctaveDownButton.TabIndex = 15;
            this.MidiOctaveDownButton.Text = "-1 Octave";
            this.MidiOctaveDownButton.UseVisualStyleBackColor = true;
            this.MidiOctaveDownButton.Click += new System.EventHandler(this.MidiOctaveDownButton_Click);
            // 
            // TransposeRangeLabel
            // 
            this.TransposeRangeLabel.AutoSize = true;
            this.TransposeRangeLabel.Location = new System.Drawing.Point(7, 144);
            this.TransposeRangeLabel.Name = "TransposeRangeLabel";
            this.TransposeRangeLabel.Size = new System.Drawing.Size(123, 13);
            this.TransposeRangeLabel.TabIndex = 14;
            this.TransposeRangeLabel.Text = "Transpose target range :";
            // 
            // TargetLabel
            // 
            this.TargetLabel.AutoSize = true;
            this.TargetLabel.Location = new System.Drawing.Point(7, 96);
            this.TargetLabel.Name = "TargetLabel";
            this.TargetLabel.Size = new System.Drawing.Size(147, 13);
            this.TargetLabel.TabIndex = 13;
            this.TargetLabel.Text = "Target Instrument Note Count";
            // 
            // TargetRangeNumeric
            // 
            this.TargetRangeNumeric.Location = new System.Drawing.Point(159, 94);
            this.TargetRangeNumeric.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.TargetRangeNumeric.Name = "TargetRangeNumeric";
            this.TargetRangeNumeric.Size = new System.Drawing.Size(57, 20);
            this.TargetRangeNumeric.TabIndex = 12;
            this.TargetRangeNumeric.ValueChanged += new System.EventHandler(this.TargetRangeNumeric_ValueChanged);
            // 
            // ConversionCheckBox
            // 
            this.ConversionCheckBox.AutoSize = true;
            this.ConversionCheckBox.Location = new System.Drawing.Point(10, 183);
            this.ConversionCheckBox.Name = "ConversionCheckBox";
            this.ConversionCheckBox.Size = new System.Drawing.Size(171, 17);
            this.ConversionCheckBox.TabIndex = 11;
            this.ConversionCheckBox.Text = "Convert notes to target\'s range";
            this.ConversionCheckBox.UseVisualStyleBackColor = true;
            this.ConversionCheckBox.CheckedChanged += new System.EventHandler(this.ConversionCheckBox_CheckedChanged);
            // 
            // OctaveUpButton
            // 
            this.OctaveUpButton.Location = new System.Drawing.Point(216, 139);
            this.OctaveUpButton.Name = "OctaveUpButton";
            this.OctaveUpButton.Size = new System.Drawing.Size(75, 22);
            this.OctaveUpButton.TabIndex = 10;
            this.OctaveUpButton.Text = "+1 Octave";
            this.OctaveUpButton.UseVisualStyleBackColor = true;
            this.OctaveUpButton.Click += new System.EventHandler(this.OctaveUpButton_Click);
            // 
            // OctaveDownButton
            // 
            this.OctaveDownButton.Location = new System.Drawing.Point(135, 139);
            this.OctaveDownButton.Name = "OctaveDownButton";
            this.OctaveDownButton.Size = new System.Drawing.Size(75, 22);
            this.OctaveDownButton.TabIndex = 9;
            this.OctaveDownButton.Text = "-1 Octave";
            this.OctaveDownButton.UseVisualStyleBackColor = true;
            this.OctaveDownButton.Click += new System.EventHandler(this.OctaveDownButton_Click);
            // 
            // MordhauHighestNoteLabel
            // 
            this.MordhauHighestNoteLabel.AutoSize = true;
            this.MordhauHighestNoteLabel.Location = new System.Drawing.Point(156, 123);
            this.MordhauHighestNoteLabel.Name = "MordhauHighestNoteLabel";
            this.MordhauHighestNoteLabel.Size = new System.Drawing.Size(91, 13);
            this.MordhauHighestNoteLabel.TabIndex = 8;
            this.MordhauHighestNoteLabel.Text = "Highest Note : C4";
            // 
            // MordhauLowestNoteLabel
            // 
            this.MordhauLowestNoteLabel.AutoSize = true;
            this.MordhauLowestNoteLabel.Location = new System.Drawing.Point(7, 123);
            this.MordhauLowestNoteLabel.Name = "MordhauLowestNoteLabel";
            this.MordhauLowestNoteLabel.Size = new System.Drawing.Size(140, 13);
            this.MordhauLowestNoteLabel.TabIndex = 7;
            this.MordhauLowestNoteLabel.Text = "Mordhau : Lowest Note : C2";
            // 
            // ConversionNecessaryLabel
            // 
            this.ConversionNecessaryLabel.AutoSize = true;
            this.ConversionNecessaryLabel.Location = new System.Drawing.Point(8, 167);
            this.ConversionNecessaryLabel.Name = "ConversionNecessaryLabel";
            this.ConversionNecessaryLabel.Size = new System.Drawing.Size(118, 13);
            this.ConversionNecessaryLabel.TabIndex = 6;
            this.ConversionNecessaryLabel.Text = "No Conversion Needed";
            // 
            // HighestNoteLabel
            // 
            this.HighestNoteLabel.AutoSize = true;
            this.HighestNoteLabel.Location = new System.Drawing.Point(129, 47);
            this.HighestNoteLabel.Name = "HighestNoteLabel";
            this.HighestNoteLabel.Size = new System.Drawing.Size(91, 13);
            this.HighestNoteLabel.TabIndex = 5;
            this.HighestNoteLabel.Text = "Highest Note : C4";
            // 
            // LowestNoteLabel
            // 
            this.LowestNoteLabel.AutoSize = true;
            this.LowestNoteLabel.Location = new System.Drawing.Point(6, 47);
            this.LowestNoteLabel.Name = "LowestNoteLabel";
            this.LowestNoteLabel.Size = new System.Drawing.Size(117, 13);
            this.LowestNoteLabel.TabIndex = 4;
            this.LowestNoteLabel.Text = "Midi : Lowest Note : C2";
            // 
            // TrackListBox
            // 
            this.TrackListBox.FormattingEnabled = true;
            this.TrackListBox.Location = new System.Drawing.Point(176, 236);
            this.TrackListBox.Name = "TrackListBox";
            this.TrackListBox.Size = new System.Drawing.Size(140, 244);
            this.TrackListBox.TabIndex = 3;
            this.TrackListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TrackListBox_Check);
            // 
            // ChannelsListBox
            // 
            this.ChannelsListBox.FormattingEnabled = true;
            this.ChannelsListBox.Location = new System.Drawing.Point(6, 236);
            this.ChannelsListBox.Name = "ChannelsListBox";
            this.ChannelsListBox.Size = new System.Drawing.Size(140, 244);
            this.ChannelsListBox.TabIndex = 2;
            this.ChannelsListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ChannelListBox_Check);
            // 
            // MidiNameLabel
            // 
            this.MidiNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MidiNameLabel.Location = new System.Drawing.Point(6, 16);
            this.MidiNameLabel.Name = "MidiNameLabel";
            this.MidiNameLabel.Size = new System.Drawing.Size(310, 31);
            this.MidiNameLabel.TabIndex = 1;
            this.MidiNameLabel.Text = "No Midi Selected";
            this.MidiNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LuteModGroupBox
            // 
            this.LuteModGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.LuteModGroupBox.Controls.Add(this.NoteCountLabel);
            this.LuteModGroupBox.Controls.Add(this.DeleteTrackButton);
            this.LuteModGroupBox.Controls.Add(this.AddTrackButton);
            this.LuteModGroupBox.Controls.Add(this.SelectTrackLabel);
            this.LuteModGroupBox.Controls.Add(this.TrackSelectionComboBox);
            this.LuteModGroupBox.Controls.Add(this.TrackAmountLabel);
            this.LuteModGroupBox.Controls.Add(this.PartitionTracksListBox);
            this.LuteModGroupBox.Controls.Add(this.PartitionChannelsListBox);
            this.LuteModGroupBox.Controls.Add(this.NameTextBox);
            this.LuteModGroupBox.Controls.Add(this.ConvertButton);
            this.LuteModGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LuteModGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LuteModGroupBox.Location = new System.Drawing.Point(462, 12);
            this.LuteModGroupBox.Name = "LuteModGroupBox";
            this.LuteModGroupBox.Size = new System.Drawing.Size(322, 521);
            this.LuteModGroupBox.TabIndex = 3;
            this.LuteModGroupBox.TabStop = false;
            this.LuteModGroupBox.Text = "LuteMod Partition";
            // 
            // NoteCountLabel
            // 
            this.NoteCountLabel.AutoSize = true;
            this.NoteCountLabel.Location = new System.Drawing.Point(6, 144);
            this.NoteCountLabel.Name = "NoteCountLabel";
            this.NoteCountLabel.Size = new System.Drawing.Size(178, 13);
            this.NoteCountLabel.TabIndex = 15;
            this.NoteCountLabel.Text = "The Current Track Contains 0 Notes";
            // 
            // DeleteTrackButton
            // 
            this.DeleteTrackButton.Location = new System.Drawing.Point(238, 119);
            this.DeleteTrackButton.Name = "DeleteTrackButton";
            this.DeleteTrackButton.Size = new System.Drawing.Size(78, 21);
            this.DeleteTrackButton.TabIndex = 14;
            this.DeleteTrackButton.Text = "Delete Track";
            this.DeleteTrackButton.UseVisualStyleBackColor = true;
            this.DeleteTrackButton.Click += new System.EventHandler(this.DeleteTrackButton_Click);
            // 
            // AddTrackButton
            // 
            this.AddTrackButton.Location = new System.Drawing.Point(167, 119);
            this.AddTrackButton.Name = "AddTrackButton";
            this.AddTrackButton.Size = new System.Drawing.Size(65, 21);
            this.AddTrackButton.TabIndex = 13;
            this.AddTrackButton.Text = "Add Track";
            this.AddTrackButton.UseVisualStyleBackColor = true;
            this.AddTrackButton.Click += new System.EventHandler(this.AddTrackButton_Click);
            // 
            // SelectTrackLabel
            // 
            this.SelectTrackLabel.AutoSize = true;
            this.SelectTrackLabel.Location = new System.Drawing.Point(6, 123);
            this.SelectTrackLabel.Name = "SelectTrackLabel";
            this.SelectTrackLabel.Size = new System.Drawing.Size(83, 13);
            this.SelectTrackLabel.TabIndex = 12;
            this.SelectTrackLabel.Text = "Select a Track :";
            // 
            // TrackSelectionComboBox
            // 
            this.TrackSelectionComboBox.FormattingEnabled = true;
            this.TrackSelectionComboBox.Location = new System.Drawing.Point(95, 120);
            this.TrackSelectionComboBox.Name = "TrackSelectionComboBox";
            this.TrackSelectionComboBox.Size = new System.Drawing.Size(66, 21);
            this.TrackSelectionComboBox.TabIndex = 11;
            this.TrackSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.TrackSelectionComboBox_SelectedIndexChanged);
            // 
            // TrackAmountLabel
            // 
            this.TrackAmountLabel.AutoSize = true;
            this.TrackAmountLabel.Location = new System.Drawing.Point(6, 96);
            this.TrackAmountLabel.Name = "TrackAmountLabel";
            this.TrackAmountLabel.Size = new System.Drawing.Size(200, 13);
            this.TrackAmountLabel.TabIndex = 10;
            this.TrackAmountLabel.Text = "The Partition Currently Contains 0 Tracks";
            // 
            // PartitionTracksListBox
            // 
            this.PartitionTracksListBox.FormattingEnabled = true;
            this.PartitionTracksListBox.Location = new System.Drawing.Point(176, 242);
            this.PartitionTracksListBox.Name = "PartitionTracksListBox";
            this.PartitionTracksListBox.Size = new System.Drawing.Size(140, 238);
            this.PartitionTracksListBox.TabIndex = 9;
            // 
            // PartitionChannelsListBox
            // 
            this.PartitionChannelsListBox.FormattingEnabled = true;
            this.PartitionChannelsListBox.Location = new System.Drawing.Point(6, 241);
            this.PartitionChannelsListBox.Name = "PartitionChannelsListBox";
            this.PartitionChannelsListBox.Size = new System.Drawing.Size(140, 238);
            this.PartitionChannelsListBox.TabIndex = 8;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(9, 19);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(310, 26);
            this.NameTextBox.TabIndex = 7;
            this.NameTextBox.Text = "Partition Name";
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // ConvertButton
            // 
            this.ConvertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConvertButton.Location = new System.Drawing.Point(6, 485);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(310, 30);
            this.ConvertButton.TabIndex = 1;
            this.ConvertButton.Text = "Convert to LuteMod Format";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // AddToCurrentTrackButton
            // 
            this.AddToCurrentTrackButton.Location = new System.Drawing.Point(339, 395);
            this.AddToCurrentTrackButton.Name = "AddToCurrentTrackButton";
            this.AddToCurrentTrackButton.Size = new System.Drawing.Size(117, 43);
            this.AddToCurrentTrackButton.TabIndex = 4;
            this.AddToCurrentTrackButton.Text = "Add Selection to Current Track";
            this.AddToCurrentTrackButton.UseVisualStyleBackColor = true;
            this.AddToCurrentTrackButton.Click += new System.EventHandler(this.AddToCurrentTrackButton_Click);
            // 
            // AddInNewTrackButton
            // 
            this.AddInNewTrackButton.Location = new System.Drawing.Point(339, 346);
            this.AddInNewTrackButton.Name = "AddInNewTrackButton";
            this.AddInNewTrackButton.Size = new System.Drawing.Size(117, 43);
            this.AddInNewTrackButton.TabIndex = 5;
            this.AddInNewTrackButton.Text = "Add Selection to New Track";
            this.AddInNewTrackButton.UseVisualStyleBackColor = true;
            this.AddInNewTrackButton.Click += new System.EventHandler(this.AddInNewTrackButton_Click);
            // 
            // PartitionsIndexLabel
            // 
            this.PartitionsIndexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartitionsIndexLabel.Location = new System.Drawing.Point(339, 12);
            this.PartitionsIndexLabel.Name = "PartitionsIndexLabel";
            this.PartitionsIndexLabel.Size = new System.Drawing.Size(117, 26);
            this.PartitionsIndexLabel.TabIndex = 6;
            this.PartitionsIndexLabel.Text = "Partition Index";
            this.PartitionsIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PartitionIndexBox
            // 
            this.PartitionIndexBox.AllowDrop = true;
            this.PartitionIndexBox.FormattingEnabled = true;
            this.PartitionIndexBox.HorizontalScrollbar = true;
            this.PartitionIndexBox.Location = new System.Drawing.Point(339, 46);
            this.PartitionIndexBox.Name = "PartitionIndexBox";
            this.PartitionIndexBox.Size = new System.Drawing.Size(117, 147);
            this.PartitionIndexBox.TabIndex = 7;
            this.PartitionIndexBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.PartitionIndexBox_DragDrop);
            this.PartitionIndexBox.DragOver += new System.Windows.Forms.DragEventHandler(this.PartitionIndexBox_DragOver);
            this.PartitionIndexBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PartitionIndexBox_MouseDown);
            // 
            // OpenPartitionFolderButton
            // 
            this.OpenPartitionFolderButton.Location = new System.Drawing.Point(339, 196);
            this.OpenPartitionFolderButton.Name = "OpenPartitionFolderButton";
            this.OpenPartitionFolderButton.Size = new System.Drawing.Size(117, 34);
            this.OpenPartitionFolderButton.TabIndex = 9;
            this.OpenPartitionFolderButton.Text = "Open Partition Folder";
            this.OpenPartitionFolderButton.UseVisualStyleBackColor = true;
            this.OpenPartitionFolderButton.Click += new System.EventHandler(this.OpenPartitionFolderButton_Click);
            // 
            // ClearPartitionButton
            // 
            this.ClearPartitionButton.Location = new System.Drawing.Point(339, 444);
            this.ClearPartitionButton.Name = "ClearPartitionButton";
            this.ClearPartitionButton.Size = new System.Drawing.Size(117, 23);
            this.ClearPartitionButton.TabIndex = 16;
            this.ClearPartitionButton.Text = "Clear Partition";
            this.ClearPartitionButton.UseVisualStyleBackColor = true;
            this.ClearPartitionButton.Click += new System.EventHandler(this.ClearPartitionButton_Click);
            // 
            // ImportPartitionButton
            // 
            this.ImportPartitionButton.Location = new System.Drawing.Point(339, 236);
            this.ImportPartitionButton.Name = "ImportPartitionButton";
            this.ImportPartitionButton.Size = new System.Drawing.Size(117, 34);
            this.ImportPartitionButton.TabIndex = 17;
            this.ImportPartitionButton.Text = "Import Existing Partition";
            this.ImportPartitionButton.UseVisualStyleBackColor = true;
            this.ImportPartitionButton.Click += new System.EventHandler(this.ImportPartitionButton_Click);
            // 
            // DefaultClientNoteCountButton
            // 
            this.DefaultClientNoteCountButton.Location = new System.Drawing.Point(222, 94);
            this.DefaultClientNoteCountButton.Name = "DefaultClientNoteCountButton";
            this.DefaultClientNoteCountButton.Size = new System.Drawing.Size(27, 20);
            this.DefaultClientNoteCountButton.TabIndex = 20;
            this.DefaultClientNoteCountButton.Text = "25";
            this.DefaultClientNoteCountButton.UseMnemonic = false;
            this.DefaultClientNoteCountButton.UseVisualStyleBackColor = true;
            this.DefaultClientNoteCountButton.Click += new System.EventHandler(this.DefaultClientNoteCountButton_Click);
            // 
            // DefaultServerNoteCountButton
            // 
            this.DefaultServerNoteCountButton.Location = new System.Drawing.Point(255, 94);
            this.DefaultServerNoteCountButton.Name = "DefaultServerNoteCountButton";
            this.DefaultServerNoteCountButton.Size = new System.Drawing.Size(27, 20);
            this.DefaultServerNoteCountButton.TabIndex = 21;
            this.DefaultServerNoteCountButton.Text = "49";
            this.DefaultServerNoteCountButton.UseVisualStyleBackColor = true;
            this.DefaultServerNoteCountButton.Click += new System.EventHandler(this.DefaultServerNoteCountButton_Click);
            // 
            // IndividualNoteCountNumeric
            // 
            this.IndividualNoteCountNumeric.Location = new System.Drawing.Point(297, 140);
            this.IndividualNoteCountNumeric.Name = "IndividualNoteCountNumeric";
            this.IndividualNoteCountNumeric.Size = new System.Drawing.Size(17, 20);
            this.IndividualNoteCountNumeric.TabIndex = 22;
            this.IndividualNoteCountNumeric.ValueChanged += new System.EventHandler(this.IndividualNoteCountNumeric_ValueChanged);
            // 
            // MidiConverterForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(796, 537);
            this.Controls.Add(this.ImportPartitionButton);
            this.Controls.Add(this.ClearPartitionButton);
            this.Controls.Add(this.OpenPartitionFolderButton);
            this.Controls.Add(this.PartitionIndexBox);
            this.Controls.Add(this.PartitionsIndexLabel);
            this.Controls.Add(this.AddInNewTrackButton);
            this.Controls.Add(this.AddToCurrentTrackButton);
            this.Controls.Add(this.LuteModGroupBox);
            this.Controls.Add(this.MidiGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MidiConverterForm";
            this.Text = "LuteMod Midi Converter";
            this.Load += new System.EventHandler(this.MidiConverterForm_Load);
            this.MidiGroupBox.ResumeLayout(false);
            this.MidiGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetRangeNumeric)).EndInit();
            this.LuteModGroupBox.ResumeLayout(false);
            this.LuteModGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IndividualNoteCountNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        private void ChannelsListBox_Check(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button LoadMidiButton;
        private System.Windows.Forms.GroupBox MidiGroupBox;
        private System.Windows.Forms.Label MidiNameLabel;
        private System.Windows.Forms.CheckedListBox TrackListBox;
        private System.Windows.Forms.CheckedListBox ChannelsListBox;
        private System.Windows.Forms.Label LowestNoteLabel;
        private System.Windows.Forms.Label HighestNoteLabel;
        private System.Windows.Forms.Label ConversionNecessaryLabel;
        private System.Windows.Forms.GroupBox LuteModGroupBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.ListBox PartitionTracksListBox;
        private System.Windows.Forms.ListBox PartitionChannelsListBox;
        private System.Windows.Forms.ComboBox TrackSelectionComboBox;
        private System.Windows.Forms.Label TrackAmountLabel;
        private System.Windows.Forms.Button AddTrackButton;
        private System.Windows.Forms.Label SelectTrackLabel;
        private System.Windows.Forms.Button DeleteTrackButton;
        private System.Windows.Forms.Label NoteCountLabel;
        private System.Windows.Forms.Button AddToCurrentTrackButton;
        private System.Windows.Forms.Button AddInNewTrackButton;
        private System.Windows.Forms.Label MordhauLowestNoteLabel;
        private System.Windows.Forms.Label MordhauHighestNoteLabel;
        private System.Windows.Forms.Button OctaveUpButton;
        private System.Windows.Forms.Button OctaveDownButton;
        private System.Windows.Forms.Label PartitionsIndexLabel;
        private System.Windows.Forms.ListBox PartitionIndexBox;
        private System.Windows.Forms.Button OpenPartitionFolderButton;
        private System.Windows.Forms.Label TargetLabel;
        private System.Windows.Forms.NumericUpDown TargetRangeNumeric;
        private System.Windows.Forms.CheckBox ConversionCheckBox;
        private System.Windows.Forms.Label TransposeRangeLabel;
        private System.Windows.Forms.Label TransposeMidiRangeLabel;
        private System.Windows.Forms.Button MidiOctaveUpButton;
        private System.Windows.Forms.Button MidiOctaveDownButton;
        private System.Windows.Forms.Button ClearPartitionButton;
        private System.Windows.Forms.Button CheckAllChannelsButton;
        private System.Windows.Forms.Button CheckAllTracksButton;
        private System.Windows.Forms.Button ImportPartitionButton;
        private System.Windows.Forms.Button DefaultServerNoteCountButton;
        private System.Windows.Forms.Button DefaultClientNoteCountButton;
        private System.Windows.Forms.NumericUpDown IndividualNoteCountNumeric;
    }
}

