// unset

using System;

using ChampionsOfForest.Effects;
using ChampionsOfForest.Network.Commands.Spells;

using TheForest.Utils;

using UnityEngine;

namespace ChampionsOfForest.Network.Commands
{
	[Serializable]
	public class SpellCommand : INetworkCommand
	{
		public int Id => 3;

		private ISpellData _spellData;

		public void Execute()
		{
			_spellData.CreatorClass.GetMethod("CastFromData")?.Invoke(null, new object[] {_spellData});
			if (_spellId == 1)
			{
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				BlackHole.CreateBlackHole(pos, r.ReadBoolean(), r.ReadSingle(), r.ReadSingle(),
					r.ReadSingle(), r.ReadSingle(), r.ReadString());
			}
			else if (_spellId == 2)
			{
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				HealingDome.CreateHealingDome(pos, r.ReadSingle(), r.ReadSingle(),
					r.ReadBoolean(), r.ReadBoolean(), r.ReadSingle());
			}
			else if (_spellId == 3)
			{
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				DarkBeam.Create(pos, r.ReadBoolean(), r.ReadSingle(), r.ReadSingle(),
					r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
			}
			else if (_spellId == 4)
			{
				bool isOn = r.ReadBoolean();
				string packed = r.ReadString();
				BlackFlame.ToggleOtherPlayer(packed, isOn);
			}
			else if (_spellId == 5)
			{
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				float radius = r.ReadSingle();
				float speed = r.ReadSingle();
				float dmg = r.ReadSingle();
				bool GiveDmg = r.ReadBoolean();
				bool GiveAr = r.ReadBoolean();
				int ar = 0;
				if (GiveAr)
				{
					ar = r.ReadInt32();
				}

				WarCry.Cast(pos, radius, speed, dmg, GiveDmg, GiveAr, ar);
			}
			else if (_spellId == 6)
			{
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				float duration = r.ReadSingle();
				int id = r.ReadInt32();

				Portal.CreatePortal(pos, duration, id, r.ReadBoolean(), r.ReadBoolean());
			}
			else if (_spellId == 7)
			{
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				Vector3 dir = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());

				float dmg = r.ReadSingle();
				string caster = r.ReadString();
				float duration = r.ReadSingle();
				bool slow = r.ReadBoolean();
				bool dmgdebuff = r.ReadBoolean();
				if (GameSetup.IsMpServer)
				{
					MagicArrow.Create(pos, dir, dmg, caster, duration, slow, dmgdebuff);
				}
				else
				{
					MagicArrow.CreateEffect(pos, dir, dmgdebuff, duration);
				}
			}
			else if (_spellId == 8)
			{
				Purge.Cast(new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle()),
					r.ReadSingle(), r.ReadBoolean(), r.ReadBoolean());
			}
			else if (_spellId == 9)
			{
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				float dist = r.ReadSingle();

				SnapFreeze.CreateEffect(pos, dist);
				if (!GameSetup.IsMpClient)
				{
					SnapFreeze.HostAction(pos, dist, r.ReadSingle(), r.ReadSingle(),
						r.ReadSingle());
				}
			}
			else if (_spellId == 10)
			{
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				Vector3 speed = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				float dmg = r.ReadSingle();
				uint id = r.ReadUInt32();

				if (BallLightning.lastID < id)
				{
					BallLightning.lastID = id;
				}

				BallLightning.Create(pos, speed, dmg, id);
			}
			else if (_spellId == 11) //cataclysm
			{
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				float radius = r.ReadSingle();
				float dmg = r.ReadSingle();
				float duration = r.ReadSingle();
				bool isArcane = r.ReadBoolean();
				bool fromEnemy = r.ReadBoolean();
				Cataclysm.Create(pos, radius, dmg, duration,
					isArcane ? Cataclysm.TornadoType.Arcane : Cataclysm.TornadoType.Fire,
					fromEnemy);
			}
			else if (_spellId == 12)
			{
				//a request from a client to a host to spawn a ball lightning. The host assigns the id of
				//a ball lightning to not create overlapping ids
				using (System.IO.MemoryStream answerStream = new System.IO.MemoryStream())
				{
					using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(answerStream))
					{
						w.Write(3);
						w.Write(10);
						w.Write(r.ReadSingle());
						w.Write(r.ReadSingle());
						w.Write(r.ReadSingle());
						w.Write(r.ReadSingle());
						w.Write(r.ReadSingle());
						w.Write(r.ReadSingle());
						w.Write(r.ReadSingle());
						w.Write((uint)(BallLightning.lastID + 1));
						w.Close();
						BallLightning.lastID++;
					}

					ChampionsOfForest.Network.NetworkManager.SendLine(answerStream.ToArray(),
						ChampionsOfForest.Network.NetworkManager.Target.Everyone);
					answerStream.Close();
				}
			}
			else if (_spellId == 13) //parry was casted by a client
			{
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				float radius = r.ReadSingle();
				bool ignite = r.ReadBoolean();
				float dmg = r.ReadSingle();

				var hits = Physics.SphereCastAll(pos, radius, Vector3.one);

				for (int i = 0; i < hits.Length; i++)
				{
					if (hits[i].transform.CompareTag("enemyCollide"))
					{
						var prog = hits[i].transform.root.GetComponent<EnemyProgression>();
						if (prog)
							hits[i].transform.root.SendMessageUpwards("Hit", (int)dmg,
								SendMessageOptions.DontRequireReceiver);
						else
							prog.HitPhysical(dmg);
						if (ignite)
							hits[i].transform.SendMessageUpwards("Burn",
								SendMessageOptions.DontRequireReceiver);
					}
				}
			}
			else if (_spellId == 14) //Massive fart
			{
				bool grounded = r.ReadBoolean();
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				Vector3 dir = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				Effects.TheFartCreator.CreateEffect(pos, dir, !grounded);
				if (GameSetup.IsMpServer)
				{
					Effects.TheFartCreator.DealDamageAsHost(pos, dir, r.ReadSingle(),
						r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				}
			}
			else if (_spellId == 15) //taunt
			{
				Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				float radius = r.ReadSingle();
				if (GameSetup.IsMpServer)
				{
					float duration = r.ReadSingle();
					float slow = r.ReadSingle();
					bool pullIn = r.ReadBoolean();
					string playerID = r.ReadString();
					var player = ModReferences.AllPlayerEntities.First(x =>
						x.GetState<IPlayerState>().name == playerID);
					if (player)
					{
						Taunt.Cast(pos, radius, player.gameObject, duration, slow, pullIn);
					}
				}

				Taunt.CastEffect(pos, radius);
			}
		}
	}
}