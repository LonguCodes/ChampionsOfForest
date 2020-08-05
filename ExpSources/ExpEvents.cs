﻿using ChampionsOfForest.Player;

using TheForest.Tools;
using TheForest.Utils;

using UnityEngine;

namespace ChampionsOfForest.ExpSources
{
	public class ExpEvents
	{
		public static void Initialize()
		{
			EventRegistry.Player.Subscribe(TfEvent.CutTree, OnTreeCut);
			EventRegistry.Animal.Subscribe(TfEvent.KilledShark, SharkKilled);
		}

		public static void OnTreeCut(object o)
		{
			int xp = 30;
			if (GameSetup.IsMultiplayer)
			{
				using (System.IO.MemoryStream answerStream = new System.IO.MemoryStream())
				{
					using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(answerStream))
					{
						w.Write(11);
						w.Write(xp);
					}
					ChampionsOfForest.Network.NetworkManager.SendLine(answerStream.ToArray(), ChampionsOfForest.Network.NetworkManager.Target.Everyone);
				}
			}
			else
			{
				ModdedPlayer.instance.AddFinalExperience(xp);
			}
		}

		public static void SharkKilled(object o)
		{
			int xp = 3000;
			if (GameSetup.IsMultiplayer)
			{
				using (System.IO.MemoryStream answerStream = new System.IO.MemoryStream())
				{
					using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(answerStream))
					{
						w.Write(10);
						w.Write(xp);
					}
					ChampionsOfForest.Network.NetworkManager.SendLine(answerStream.ToArray(), ChampionsOfForest.Network.NetworkManager.Target.Everyone);
				}
			}
			else
			{
				ModdedPlayer.instance.AddKillExperience(xp);
			}
			if (!GameSetup.IsMpClient)
			{
				Network.NetworkManager.SendItemDrop(ItemDataBase.GetRandomItem(270), LocalPlayer.Transform.position+Vector3.up*6f);
				Network.NetworkManager.SendItemDrop(ItemDataBase.GetRandomItem(270), LocalPlayer.Transform.position+Vector3.up*6f);
			}
		}
	}
}