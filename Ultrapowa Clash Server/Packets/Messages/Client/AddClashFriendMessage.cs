using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCS.Helpers;
using UCS.Helpers.Binary;
using UCS.Logic;

namespace UCS.Packets.Messages.Client
{
    internal class AddClashFriendMessage : Message
    {
        public AddClashFriendMessage(Device device, Reader reader) : base(device, reader)
        {
        }

        internal override void Decode()
        {
            this.FriendID = this.Reader.ReadInt64();
        }

        public long FriendID { get; set; }

        internal override void Process()
        {
        }
    }
}
