// unset

using System;

using ChampionsOfForest.Effects;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class WarCryData : ISpellData
	{
		public int Id => 5;
		public Type CreatorClass => typeof(WarCry);

		public Vector3 Pos;
		public float Radius;
		public float Speed;
		public float Dmg;
		public bool GiveDmg;
		public bool GiveAr;
		public int Ar;
	}
}