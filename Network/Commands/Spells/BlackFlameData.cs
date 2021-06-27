// unset

using System;

using ChampionsOfForest.Effects;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public class BlackFlameData : ISpellData
	{
		public int Id => 4;
		public Type CreatorClass => typeof(BlackFlame);

		public bool IsOn;
		public string PlayerName;
	}
}