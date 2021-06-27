// unset

using System;

using ChampionsOfForest.Effects;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class TauntData : ISpellData
	{
		public int Id => 15;

		public Type CreatorClass => typeof(Taunt);

		public Vector3 Pos;
		public float Radius;
		public float Duration;
		public float Slow;
		public bool PullIn;
		public string PlayerId;
	}
}