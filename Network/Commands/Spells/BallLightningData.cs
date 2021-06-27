// unset

using System;

using ChampionsOfForest.Effects;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class BallLightningData: ISpellData
	{
		public int Id => 10;

		public Type CreatorClass => typeof(BallLightning);

		public Vector3 Pos;
		public Vector3 Speed;
		public float Dmg;
		public float BallLightningId;
	}
}