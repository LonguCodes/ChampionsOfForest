// unset

using System;

using ChampionsOfForest.Effects;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class MassiveFartData: ISpellData
	{
		public int Id => 14;

		public Type CreatorClass => typeof(TheFartCreator);

		public bool IsGrounded;
		public Vector3 Pos;
		public Vector3 Dir;
		public float Radius;
		public float Dmg;
		public float KnockBack;
		public float SlowAmount;
		public float Duration;
	}
}