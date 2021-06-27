// unset

namespace ChampionsOfForest.Network.Commands
{
	public class Unknown1Command : INetworkCommand
	{
		public int Id => 1;

		public void Execute()
		{
			if (ModSettings.DifficultyChoosen)
			{
				ModSettings.BroadCastSettingsToClients();
			}
		}
	}
}