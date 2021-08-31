using System;
using System.Collections.Generic;
using System.Text;

namespace Sanford.Multimedia.Midi
{
    public class ChannelMessageEventArgs : EventArgs
    {
        private ChannelMessage message;
        private int trackId;

        public ChannelMessageEventArgs(ChannelMessage message, int trackId)
        {
            this.message = message;
        }

        public ChannelMessage Message
        {
            get
            {
                return message;
            }
        }

        public int TrackId { get => trackId; }
    }
}
