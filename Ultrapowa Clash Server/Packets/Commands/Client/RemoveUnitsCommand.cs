using System.Collections.Generic;
using System.IO;using UCS.Core;
using UCS.Files.Logic;
using UCS.Helpers.Binary;
using UCS.Logic;

namespace UCS.Packets.Commands.Client
{
    // Packet 550
    internal class RemoveUnitsCommand : Command
    {
        public RemoveUnitsCommand(Reader reader, Device client, int id) : base(reader, client, id)
        { 
        }

        internal override void Decode()
        {
            this.Reader.ReadUInt32();
            UnitTypesCount = this.Reader.ReadInt32();

            UnitsToRemove = new List<UnitToRemove>();
            for (var i = 0; i < UnitTypesCount; i++)
            {
                int UnitType = this.Reader.ReadInt32();
                int count = this.Reader.ReadInt32();
                int level = this.Reader.ReadInt32();
                this.UnitsToRemove.Add(new UnitToRemove { Data = UnitType, Count = count, Level = level });
            }
            this.Reader.ReadUInt32();
        }


        internal override void Process()
        {
            List<DataSlot> _PlayerUnits = this.Device.Player.Avatar.GetUnits();
            List<DataSlot> _PlayerSpells = this.Device.Player.Avatar.GetSpells();

            foreach (UnitToRemove _Unit in UnitsToRemove)
            {
                if (_Unit.Data.ToString().StartsWith("400"))
                {
                    CombatItemData _Troop = (CombatItemData)CSVManager.DataTables.GetDataById(_Unit.Data); ;
                    DataSlot _DataSlot = _PlayerUnits.Find(t => t.Data.GetGlobalID() == _Troop.GetGlobalID());
                    if (_DataSlot != null)
                    {
                        _DataSlot.Value = _DataSlot.Value - 1;
                    }
                }
                else if (_Unit.Data.ToString().StartsWith("260"))
                {
                    SpellData _Spell = (SpellData)CSVManager.DataTables.GetDataById(_Unit.Data); ;
                    DataSlot _DataSlot = _PlayerSpells.Find(t => t.Data.GetGlobalID() == _Spell.GetGlobalID());
                    if (_DataSlot != null)
                    {
                        _DataSlot.Value = _DataSlot.Value - 1;
                    }
                }
            }
        }

        public List<UnitToRemove> UnitsToRemove;
        public int UnitTypesCount;
    }

    internal class UnitToRemove
    {
        public int Data;
        public int Count;
        public int Level;
    }
}
