using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions;

public class TransferTroopsAndPrisonersAction : AIActionBase
{
	private class TransferRequest
	{
		public List<TroopTransfer> TroopsToTransfer { get; set; } = new List<TroopTransfer>();

		public List<PrisonerTransfer> PrisonersToTransfer { get; set; } = new List<PrisonerTransfer>();

		public bool TransferToPlayer { get; set; } = true;
	}

	public class TroopTransfer
	{
		public string TroopStringId { get; set; }

		public int Count { get; set; }
	}

	public class PrisonerTransfer
	{
		public string PrisonerStringId { get; set; }

		public int Count { get; set; }
	}

	private static readonly Dictionary<string, TransferRequest> PendingRequests = new Dictionary<string, TransferRequest>();

	private TransferRequest _currentRequest;

	private bool _transferCompleted;

	public override string ActionName => "transfer_troops_and_prisoners";

	public override string Description => "Transfer troops and prisoners between NPC and player";

	public static bool PrepareTransfer(Hero hero, List<TroopTransfer> troops, List<PrisonerTransfer> prisoners, bool transferToPlayer = true)
	{
		if (hero == null)
		{
			return false;
		}
		TransferRequest value = new TransferRequest
		{
			TroopsToTransfer = (troops ?? new List<TroopTransfer>()),
			PrisonersToTransfer = (prisoners ?? new List<PrisonerTransfer>()),
			TransferToPlayer = transferToPlayer
		};
		PendingRequests[((MBObjectBase)hero).StringId] = value;
		return true;
	}

	public override bool CanExecute()
	{
		if (base.TargetHero == null)
		{
			LogError("Cannot execute transfer - hero not set");
			return false;
		}
		if (base.TargetHero.IsDead || base.TargetHero.IsPrisoner)
		{
			LogError($"Cannot execute transfer - hero is dead or prisoner: {base.TargetHero.Name}");
			return false;
		}
		if (Hero.MainHero == null)
		{
			LogError("Cannot execute transfer - player hero not found");
			return false;
		}
		bool flag = base.TargetHero.CurrentSettlement != null && Hero.MainHero.CurrentSettlement != null && base.TargetHero.CurrentSettlement == Hero.MainHero.CurrentSettlement;
		bool flag2 = base.TargetHero.PartyBelongedTo == MobileParty.MainParty;
		if (!flag && !flag2)
		{
			if (base.TargetHero.PartyBelongedTo == null || MobileParty.MainParty == null)
			{
				LogError("Cannot execute transfer - parties not found");
				return false;
			}
			float distance = GameVersionCompatibility.GetDistance(base.TargetHero.PartyBelongedTo, MobileParty.MainParty);
			if (distance > 4f)
			{
				LogError($"Cannot execute transfer - too far: {distance:F2}");
				return false;
			}
		}
		return true;
	}

	protected override void OnStart()
	{
		if (!CanExecute())
		{
			Stop();
			return;
		}
		if (!PendingRequests.TryGetValue(((MBObjectBase)base.TargetHero).StringId, out _currentRequest) || _currentRequest == null)
		{
			LogError("No transfer request found");
			Stop();
			return;
		}
		PendingRequests.Remove(((MBObjectBase)base.TargetHero).StringId);
		try
		{
			ExecuteTransfer();
			_transferCompleted = true;
		}
		catch (Exception ex)
		{
			LogError("Error executing transfer: " + ex.Message + "\n" + ex.StackTrace);
		}
		Stop();
	}

	private void ExecuteTransfer()
	{
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		if (_currentRequest == null)
		{
			return;
		}
		MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
		if (partyBelongedTo == null)
		{
			LogError("NPC has no party");
			return;
		}
		if (MobileParty.MainParty == null)
		{
			LogError("Player party not found");
			return;
		}
		int num = 0;
		int num2 = 0;
		if (_currentRequest.TransferToPlayer)
		{
			num = TransferTroops(partyBelongedTo, MobileParty.MainParty, _currentRequest.TroopsToTransfer);
			num2 = TransferPrisoners(partyBelongedTo, MobileParty.MainParty, _currentRequest.PrisonersToTransfer);
		}
		else
		{
			num = TransferTroops(MobileParty.MainParty, partyBelongedTo, _currentRequest.TroopsToTransfer);
			num2 = TransferPrisoners(MobileParty.MainParty, partyBelongedTo, _currentRequest.PrisonersToTransfer);
		}
		string text = ((object)base.TargetHero.Name).ToString();
		TextObject message;
		if (_currentRequest.TransferToPlayer)
		{
			if (num > 0 && num2 > 0)
			{
				message = new TextObject("{=AIAction_TransferBoth_NPCToPlayer}{NPC_NAME} transferred troops and prisoners to you.", (Dictionary<string, object>)null);
				message.SetTextVariable("NPC_NAME", text);
			}
			else if (num > 0)
			{
				message = new TextObject("{=AIAction_TransferTroops_NPCToPlayer}{NPC_NAME} transferred troops to you.", (Dictionary<string, object>)null);
				message.SetTextVariable("NPC_NAME", text);
			}
			else
			{
				if (num2 <= 0)
				{
					LogAction("No troops or prisoners were transferred");
					return;
				}
				message = new TextObject("{=AIAction_TransferPrisoners_NPCToPlayer}{NPC_NAME} transferred prisoners to you.", (Dictionary<string, object>)null);
				message.SetTextVariable("NPC_NAME", text);
			}
		}
		else if (num > 0 && num2 > 0)
		{
			message = new TextObject("{=AIAction_TransferBoth_PlayerToNPC}You transferred troops and prisoners to {NPC_NAME}.", (Dictionary<string, object>)null);
			message.SetTextVariable("NPC_NAME", text);
		}
		else if (num > 0)
		{
			message = new TextObject("{=AIAction_TransferTroops_PlayerToNPC}You transferred troops to {NPC_NAME}.", (Dictionary<string, object>)null);
			message.SetTextVariable("NPC_NAME", text);
		}
		else
		{
			if (num2 <= 0)
			{
				LogAction("No troops or prisoners were transferred");
				return;
			}
			message = new TextObject("{=AIAction_TransferPrisoners_PlayerToNPC}You transferred prisoners to {NPC_NAME}.", (Dictionary<string, object>)null);
			message.SetTextVariable("NPC_NAME", text);
		}
		LogAction(((object)message).ToString());
		DelayedTaskManager delayedTaskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
		if (delayedTaskManager != null)
		{
			delayedTaskManager.AddTask(1.0, delegate
			{
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_001b: Expected O, but got Unknown
				InformationManager.DisplayMessage(new InformationMessage(((object)message).ToString(), ExtraColors.GreenAIInfluence));
			});
		}
		else
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)message).ToString(), ExtraColors.GreenAIInfluence));
		}
	}

	private int TransferTroops(MobileParty sourceParty, MobileParty targetParty, List<TroopTransfer> troopsToTransfer)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		if (troopsToTransfer == null || troopsToTransfer.Count == 0)
		{
			return 0;
		}
		int num = 0;
		foreach (TroopTransfer transfer in troopsToTransfer)
		{
			if (string.IsNullOrEmpty(transfer.TroopStringId) || transfer.Count <= 0)
			{
				continue;
			}
			CharacterObject val = ((IEnumerable<CharacterObject>)CharacterObject.All).FirstOrDefault((Func<CharacterObject, bool>)((CharacterObject c) => ((MBObjectBase)c).StringId == transfer.TroopStringId));
			if (val == null)
			{
				LogError("Troop not found: " + transfer.TroopStringId);
				continue;
			}
			int troopCount = sourceParty.MemberRoster.GetTroopCount(val);
			int num2 = Math.Min(troopCount, transfer.Count);
			if (num2 > 0)
			{
				sourceParty.MemberRoster.RemoveTroop(val, num2, default(UniqueTroopDescriptor), 0);
				targetParty.MemberRoster.AddToCounts(val, num2, false, 0, 0, true, -1);
				num += num2;
				LogAction($"Transferred {num2} x {((BasicCharacterObject)val).Name} ({transfer.TroopStringId})");
			}
			else
			{
				LogError($"No troops available: {((BasicCharacterObject)val).Name} ({transfer.TroopStringId})");
			}
		}
		return num;
	}

	private int TransferPrisoners(MobileParty sourceParty, MobileParty targetParty, List<PrisonerTransfer> prisonersToTransfer)
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		if (prisonersToTransfer == null || prisonersToTransfer.Count == 0)
		{
			return 0;
		}
		int num = 0;
		foreach (PrisonerTransfer transfer in prisonersToTransfer)
		{
			if (string.IsNullOrEmpty(transfer.PrisonerStringId))
			{
				continue;
			}
			Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == transfer.PrisonerStringId));
			if (val != null)
			{
				if (sourceParty.PrisonRoster.Contains(val.CharacterObject))
				{
					int troopCount = sourceParty.PrisonRoster.GetTroopCount(val.CharacterObject);
					sourceParty.PrisonRoster.RemoveTroop(val.CharacterObject, troopCount, default(UniqueTroopDescriptor), 0);
					targetParty.PrisonRoster.AddToCounts(val.CharacterObject, troopCount, false, 0, 0, true, -1);
					num += troopCount;
					LogAction($"Transferred prisoner hero: {val.Name} ({transfer.PrisonerStringId})");
				}
				continue;
			}
			CharacterObject val2 = ((IEnumerable<CharacterObject>)CharacterObject.All).FirstOrDefault((Func<CharacterObject, bool>)((CharacterObject c) => ((MBObjectBase)c).StringId == transfer.PrisonerStringId));
			if (val2 != null)
			{
				int troopCount2 = sourceParty.PrisonRoster.GetTroopCount(val2);
				int num2 = Math.Min(troopCount2, (transfer.Count > 0) ? transfer.Count : troopCount2);
				if (num2 > 0)
				{
					sourceParty.PrisonRoster.RemoveTroop(val2, num2, default(UniqueTroopDescriptor), 0);
					targetParty.PrisonRoster.AddToCounts(val2, num2, false, 0, 0, true, -1);
					num += num2;
					LogAction($"Transferred {num2} x prisoner {((BasicCharacterObject)val2).Name} ({transfer.PrisonerStringId})");
				}
			}
		}
		return num;
	}

	protected override void OnStop()
	{
		if (_transferCompleted)
		{
			Hero targetHero = base.TargetHero;
			LogAction($"Transfer completed for {((targetHero != null) ? targetHero.Name : null)}");
		}
	}

	protected override void OnUpdate(float deltaTime)
	{
	}

	public override Dictionary<string, string> GetStateDataForSave()
	{
		return null;
	}
}
