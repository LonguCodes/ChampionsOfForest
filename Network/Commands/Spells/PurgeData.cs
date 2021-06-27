// unset

using System;

using ChampionsOfForest.Effects;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class PurgeData : ISpellData
	{
		public int Id => 8;

		public Type CreatorClass => typeof(Purge);

		public Vector3 Pos;
		public float Radius;
		public bool Heal;
		public bool DamageBonus;
	}
}