﻿using System.IO;
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.Packets.Messages.Server;

namespace UCS.Packets.Messages.Client
{
    // Packet 14403
    internal class TopGlobalPlayersMessage : Message
    {
        public TopGlobalPlayersMessage(Packets.Client client, PacketReader br) : base(client, br)
        {
        }

        public override void Decode()
        {
        }

        public override void Process(Level level)
        {
            PacketManager.Send(new GlobalPlayersMessage(Client));
        }
    }
}
