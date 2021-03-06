using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;

namespace Server.Spells.Mysticism
{
	public class EagleStrikeSpell : MysticSpell
	{
        public override SpellCircle Circle { get { return SpellCircle.Third; } }
        public override bool DelayedDamage { get { return true; } }
        public override bool DelayedDamageStacking { get { return false; } }

		private static SpellInfo m_Info = new SpellInfo(
				"Eagle Strike", "Kal Por Xen",
				230,
				9022,
				Reagent.Bloodmoss,
				Reagent.Bone,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public EagleStrikeSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new MysticSpellTarget( this, TargetFlags.Harmful );
		}

		public override void OnTarget( object o )
		{
			Mobile target = o as Mobile;

			if ( target == null )
			{
				return;
			}
			else if ( CheckHSequence( target ) )
			{
                SpellHelper.CheckReflect((int)Circle, Caster, ref target);

				Caster.MovingEffect( target, 0x407A, 8, 1, false, true, 0, 0 );
                Caster.PlaySound(0x2EE); 

                Timer.DelayCall(TimeSpan.FromSeconds(.5), () => 
                {
                    Caster.PlaySound(0x64D);
                });

                SpellHelper.Damage(this, target, (int)GetNewAosDamage(19, 1, 5, target), 0, 0, 0, 0, 100);
			}

			FinishSequence();
		}
	}
}