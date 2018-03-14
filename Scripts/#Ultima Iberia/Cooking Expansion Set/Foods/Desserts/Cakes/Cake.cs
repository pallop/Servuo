
using System;
using Server.Network;

namespace Server.Items
{
    public class Cake : Food
    {
        [Constructable]
        public Cake()
            : base(0x9E9)
        {
            this.Weight = 1.0;
            this.FillFactor = 10;
        }

        public Cake(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}