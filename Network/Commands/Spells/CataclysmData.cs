// unset

using System;

using ChampionsOfForest.Effects;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class CataclysmData: ISpellData
	{
		public int Id => 11;

		public Type CreatorClass => typeof(Cataclysm);

		public Vector3 Pos;
		public float Radius;
		public float Dmg;
		public float Duration;
		public bool IsArcane;
		public bool FromEnemy;
	}
}