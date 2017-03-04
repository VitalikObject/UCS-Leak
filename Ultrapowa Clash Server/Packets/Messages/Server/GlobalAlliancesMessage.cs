using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCS.Core;
using UCS.Helpers;
using UCS.Helpers.List;
using UCS.Logic;

namespace UCS.Packets.Messages.Server
{
    // Packet 24401
    internal class GlobalAlliancesMessage : Message
    {
        public GlobalAlliancesMessage(Device client) : base(client)
        {
            this.Identifier = 24401;
        }

        internal override void Encode()
        {
            List<byte> packet1 = new List<byte>();
            int i = 0;

            foreach (Alliance alliance in ObjectManager.GetInMemoryAlliances().OrderByDescending(t => t.GetScore()))
            {
                if (i >= 100)
                    break;
                packet1.AddLong(alliance.GetAllianceId());
                packet1.AddString(alliance.GetAllianceName());
                packet1.AddInt(i + 1);
                packet1.AddInt(alliance.GetScore());
                packet1.AddInt(i + 1);
                packet1.AddInt(alliance.GetAllianceBadgeData());
                packet1.AddInt(alliance.GetAllianceMembers().Count);
                packet1.AddInt(0);
                packet1.AddInt(alliance.GetAllianceLevel());
                i++;
            }

            this.Data.AddInt(i);
            this.Data.AddRange(packet1);

            this.Data.AddInt((int) TimeSpan.FromDays(1).TotalSeconds);
            this.Data.AddInt(3);
            this.Data.AddInt(50000);
            this.Data.AddInt(30000);
            this.Data.AddInt(15000);
        }
    }
}
