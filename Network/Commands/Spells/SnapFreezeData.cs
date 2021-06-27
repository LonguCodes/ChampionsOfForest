// unset

using System;

using ChampionsOfForest.Effects;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class SnapFreezeData: ISpellData
	{
		public int Id => 9;

		public Type CreatorClass => typeof(SnapFreeze);

		public Vector3 Pos;
		public float Dist;
		public float SlowMultiplier;
		public float Duration;
		public float Damage;
	}
}