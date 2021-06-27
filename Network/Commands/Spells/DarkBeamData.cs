// unset

using System;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class DarkBeamData : ISpellData
	{
		public int Id => 3;

		public Type CreatorClass =>typeof(DarkBeam);

		public Vector3 Pos;
		public bool FromEnemy;
		public float Damage;
		public float Healing;
		public float Slow;
		public float Boost;
		public float Duration;
		public float Radius;
	}
}