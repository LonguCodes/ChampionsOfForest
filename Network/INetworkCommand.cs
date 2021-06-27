// unset

namespace ChampionsOfForest.Network
{
	public interface INetworkCommand
	{
		int Id
		{
			get;
		}

		void Execute();
	}
}