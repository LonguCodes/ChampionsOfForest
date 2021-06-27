// unset

using System;

using ChampionsOfForest.Effects;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class HealingDomeData: ISpellData
	{
		public int Id => 2;
		public Type CreatorClass => typeof(HealingDome);


		public Vector3 Pos;
		public float Radius;
		public float Healing;
		public bool GrantImmunity;
		public bool RegenEnergy;
		public float Duration;
	}
}