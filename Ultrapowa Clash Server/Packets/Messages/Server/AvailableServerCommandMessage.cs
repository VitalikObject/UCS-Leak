﻿using UCS.Core.Network;
using UCS.Helpers.List;

namespace UCS.Packets.Messages.Server
{
    // Packet 24111
    internal class AvailableServerCommandMessage : Message
    {
        public AvailableServerCommandMessage(Device client, Command command) : base(client)
        {
            this.Identifier = 24111;
            this.Command = command.Handle();
        }

        internal Command Command;

        internal override void Encode()
        {
            this.Data.AddInt(this.Command.Identifier);
            this.Data.AddRange(this.Command.Data.ToArray());
        }
    }
}