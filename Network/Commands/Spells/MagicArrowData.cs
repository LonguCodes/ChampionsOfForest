// unset

using System;

using ChampionsOfForest.Effects;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class MagicArrowData:ISpellData
	{
		public int Id => 7;

		public Type CreatorClass => typeof(MagicArrow);

		public Vector3 Pos;
		public Vector3 Dir;
		public float Dmg;
		public string Caster;
		public float Duration;
		public bool Slow;
		public bool DmgDebuff;
	}
}