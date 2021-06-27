// unset

using System.Runtime.InteropServices;

using ChampionsOfForest.Player;

using TheForest.UI.Multiplayer;

namespace ChampionsOfForest.Network.Commands
{
	public class Unknown0Command : INetworkCommand
	{
		public int Id => -1;

		private int _nId;
		private byte[] _data;

		public void Execute()
		{
			NetworkPlayerStats.syncedStats[_nId].RecievedOtherPlayerChange(_data);
		}
	}
}