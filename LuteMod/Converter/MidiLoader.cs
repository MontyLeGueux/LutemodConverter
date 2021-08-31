using LuteMod.Sequencing;
using LuteMod.TrackSelection;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Track = Sanford.Multimedia.Midi.Track;

namespace LuteMod.Converter
{
    public class MidiLoader
    {
        private Sequence sequence;

        public event EventHandler<AsyncCompletedEventArgs> SongLoaded;

        private List<TrackItem> trackItems;
        private List<MidiChannelItem> midiChannelItems;
        private bool loaded;
        private int offset;

        public List<TrackItem> TrackItems { get => trackItems; }
        public List<MidiChannelItem> MidiChannelItems { get => midiChannelItems; }
        public bool Loaded { get => loaded; }
        public int Offset { get => offset; }

        public MidiLoader()
        {
            sequence = new Sequence
            {
                Format = 1
            };
            sequence.LoadCompleted += HandleLoadCompleted;
            trackItems = new List<TrackItem>();
            midiChannelItems = new List<MidiChannelItem>();
            loaded = false;
            offset = 0;
        }

        public bool CanMoveOctave(bool up)
        {
            if (up)
            {
                return sequence.MaxNoteId + offset <= 115;
            }
            else
            {
                return sequence.MinNoteId + offset >= 12;
            }
        }

        public void MoveOctave(bool up)
        {
            if (CanMoveOctave(up))
            {
                if (up)
                {
                    offset = offset + 12;
                }
                else
                {
                    offset = offset - 12;
                }
            }
        }

        private void HandleLoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                trackItems = new List<TrackItem>();
                midiChannelItems = new List<MidiChannelItem>();
                foreach (int channel in sequence.Channels)
                {
                    midiChannelItems.Add(new MidiChannelItem() { Id = channel, Active = false });
                }
                int i = 0;
                foreach (string track in sequence.TrackNames())
                {
                    trackItems.Add(new TrackItem() { Name = (track.Trim().Length > 0 ? track : "Unnamed Track " + i.ToString()), Active = false, Id = i });
                    i++;
                }
                loaded = true;
                SongLoaded.Invoke(sender, e);
            }
            else
            {
                MessageBox.Show("Error Loading Midi File", "Something went wrong");
            }
        }

        public int GetDivision()
        {
            return sequence.Division;
        }

        public void TrackToggle(int id, bool active)
        {
            trackItems[id].Active = active;
        }

        public void ChannelToggle(int id, bool active)
        {
            midiChannelItems[id].Active = active;
        }

        public int GetLowNoteId()
        {
            return sequence.MinNoteId + offset;
        }

        public int GetHighNoteId()
        {
            return sequence.MaxNoteId + offset;
        }

        public void LoadFile(string filename)
        {
            if (File.Exists(filename))
            {
                sequence.LoadAsync(filename);
            }
            else
            {
                MessageBox.Show("Could not load the file : " + filename + ".\n was it moved or deleted ?", "Something went wrong");
            }
        }

        private int BytesToInt(byte[] bytes)
        {
            return (int)((bytes[0] * Math.Pow(2, 16)) + (bytes[1] * Math.Pow(2, 8)) + bytes[2]);
        }

        public List<Note> ExtractMidiContent()
        {
            List<Note> result = new List<Note>();
            Track tempTrack;
            ChannelMessage tempMessage;
            MetaMessage tempMetaMessage;
            int tempTick;
            bool isChannelActive = false;

            foreach (TrackItem track in trackItems)
            {
                if (track.Active)
                {
                    tempTrack = sequence.ElementAt(track.Id);
                    for (int i = 0; i < tempTrack.Count; i++)
                    {
                        tempTick = tempTrack.GetMidiEvent(i).AbsoluteTicks;
                        if (tempTrack.GetMidiEvent(i).MidiMessage.MessageType == MessageType.Channel)
                        {
                            tempMessage = (ChannelMessage)tempTrack.GetMidiEvent(i).MidiMessage;
                            foreach (MidiChannelItem item in midiChannelItems)
                            {
                                isChannelActive = isChannelActive || (item.Id == tempMessage.MidiChannel && item.Active);
                            }
                            if (isChannelActive && tempMessage.Command == ChannelCommand.NoteOn)
                            {
                                result.Add(new Note() { Tick = tempTick, Tone = tempMessage.Data1 + offset, Type = NoteType.On });
                            }
                            isChannelActive = false;
                        }
                        if (tempTrack.GetMidiEvent(i).MidiMessage.MessageType == MessageType.Meta)
                        {
                            tempMetaMessage = (MetaMessage)tempTrack.GetMidiEvent(i).MidiMessage;
                            if (tempMetaMessage.MetaType == MetaType.Tempo)
                            {
                                result.Add(new Note() { Tick = tempTick, Tone = BytesToInt(tempMetaMessage.GetBytes()), Type = NoteType.Tempo });
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
