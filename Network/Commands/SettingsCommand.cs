// unset

using System;

using TheForest.Utils;

namespace ChampionsOfForest.Network.Commands
{
	[Serializable]
	public class SettingsCommand : INetworkCommand
	{
		public int Id => 2;

		private ModSettings.Difficulty _difficulty;
		private ModSettings.DropsOnDeathMode _dropsOnDeath;
		private bool _isFriendlyFire;
		private bool _isKillOnDowned;

		public void Execute()
		{
			ModSettings.FriendlyFire = _isFriendlyFire;
			ModSettings.dropsOnDeath = _dropsOnDeath;
			ModSettings.killOnDowned = _isKillOnDowned;
			ModSettings.difficulty = _difficulty;
			if (!ModSettings.DifficultyChoosen)
			{
				LocalPlayer.FpCharacter.UnLockView();
				LocalPlayer.FpCharacter.MovementLocked = false;
				Cheats.GodMode = false;
				MainMenu.Instance.ClearDiffSelectionObjects();
			}
			ModSettings.DifficultyChoosen = true;
		}
	}
}