using UCS.Logic;

namespace UCS.Packets.Messages.Server
{
    internal class ChallangeVisitDataMessage : Message
    {
        public ChallangeVisitDataMessage(Device client, Level level) : base(client)
        {
            this.Identifier = 25007;
        }
    }
}

