// unset

using System;

using ChampionsOfForest.Effects;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class PortalData : ISpellData
	{
		public int Id => 6;

		public Type CreatorClass => typeof(Portal);

		public Vector3 Pos;
		public float Duration;
		public int PortalId;
		public bool LeadsToCaves;
		public bool LeadsToEndgame;
	}
}