// unset

using System;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class ParryData: ISpellData
	{
		public int Id => 13;

		public Type CreatorClass => typeof(Parry);

		public Vector3 Pos;
		public float Radius;
		public bool Ignite;
		public float Dmg;
	}
}