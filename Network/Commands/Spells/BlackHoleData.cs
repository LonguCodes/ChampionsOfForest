// unset

using System;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class BlackHoleData : ISpellData
	{
		public Type CreatorClass => typeof(BlackHole);
		public int Id => 1;
		
		public Vector3 Pos;
		public bool FromEnemy;
		public float Damage;
		public float Duration;
		public float Radius;
		public float PullForce;
		public string SparksOfLightAfterDarknessPlayerId;
	}
}