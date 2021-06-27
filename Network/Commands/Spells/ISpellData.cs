// unset

using System;

namespace ChampionsOfForest.Network.Commands.Spells
{
	public interface ISpellData
	{
		int Id
		{
			get;
		}
		Type CreatorClass
		{
			get;
		} 
	}
}