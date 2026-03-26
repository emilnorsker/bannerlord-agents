using System;
using System.Collections.Generic;
using AIInfluence;
using AIInfluence.Behaviors.RolePlay;
using AIInfluence.Util;
using Bannerlord.GameMaster.Items;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions;

public class CreateRPWeaponAction : AIActionBase
{
	public class WeaponCreationRequest
	{
		public string Query { get; set; }

		public string DisplayName { get; set; }

		public string Description { get; set; }

		public ItemTypes ItemTypes { get; set; }

		public string Culture { get; set; }

		public int Tier { get; set; }

		public string ModifierToken { get; set; }

		public bool GiveToPlayer { get; set; }
	}

	private static readonly Dictionary<string, WeaponCreationRequest> PendingRequests = new Dictionary<string, WeaponCreationRequest>();

	private WeaponCreationRequest _request;

	private bool _completed;

	public override string ActionName => "create_rp_weapon";

	public override string Description => "Creates a weapon from tool arguments and updates this character's or the player's inventory.";

	public static bool PrepareWeaponCreation(Hero hero, WeaponCreationRequest request)
	{
		if (hero == null || request == null || string.IsNullOrWhiteSpace(request.Query) || string.IsNullOrWhiteSpace(request.DisplayName))
			return false;
		PendingRequests[((MBObjectBase)hero).StringId] = request;
		return true;
	}

	private static WeaponCreationRequest TakePendingRequest(Hero hero)
	{
		if (hero == null || !PendingRequests.TryGetValue(((MBObjectBase)hero).StringId, out var value))
			return null;
		PendingRequests.Remove(((MBObjectBase)hero).StringId);
		return value;
	}

	public override bool CanExecute()
	{
		if (base.TargetHero == null || Hero.MainHero == null)
			return false;
		_request = TakePendingRequest(base.TargetHero);
		return _request != null;
	}

	protected override void OnStart()
	{
		LogAction("Starting RP weapon forge: " + _request.DisplayName);
		try
		{
			if (base.TargetHero.PartyBelongedTo == null)
			{
				LogError("create_rp_weapon requires NPC in a party with an item roster.");
				Stop();
				return;
			}
			ItemObject forged = RpWeaponForgeScript.ForgeToNpcBag(base.TargetHero, _request.Query.Trim(), _request.ItemTypes, _request.Culture?.Trim() ?? "", _request.Tier, _request.ModifierToken?.Trim() ?? "", _request.DisplayName.Trim(), _request.Description?.Trim() ?? "");
			if (forged == null)
			{
				LogError("Forge returned null.");
				Stop();
				return;
			}
			if (_request.GiveToPlayer)
			{
				var transfer = new List<ItemTransferData> { new ItemTransferData { ItemId = ((MBObjectBase)forged).StringId, Amount = 1, Action = "give" } };
				NPCContext ctx = null;
				try
				{
					ctx = AIInfluenceBehavior.Instance?.GetOrCreateNPCContext(base.TargetHero);
				}
				catch (Exception ex)
				{
					LogError("GetOrCreateNPCContext for transfer pills: " + ex.Message);
				}
				AIInfluenceBehavior.Instance?.ProcessItemTransfers(base.TargetHero, ctx, transfer, ctx);
			}
			_completed = true;
			string npcName = ((object)base.TargetHero.Name)?.ToString() ?? "NPC";
			DelayedTaskManager delayedTaskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
			if (delayedTaskManager != null)
			{
				string itemName = _request.DisplayName;
				delayedTaskManager.AddTask(3.0, delegate
				{
					TextObject val = new TextObject("{=AIAction_RPWeaponCreated}{HERO_NAME} forges {ITEM_NAME} for you.", (Dictionary<string, object>)null);
					val.SetTextVariable("HERO_NAME", npcName);
					val.SetTextVariable("ITEM_NAME", itemName);
					InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), ExtraColors.GreenAIInfluence));
				});
			}
			else
			{
				TextObject val2 = new TextObject("{=AIAction_RPWeaponCreated}{HERO_NAME} forges {ITEM_NAME} for you.", (Dictionary<string, object>)null);
				val2.SetTextVariable("HERO_NAME", npcName);
				val2.SetTextVariable("ITEM_NAME", _request.DisplayName);
				InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), ExtraColors.GreenAIInfluence));
			}
			Stop();
		}
		catch (Exception ex)
		{
			LogError("Exception in CreateRPWeaponAction: " + ex.Message + "\n" + ex.StackTrace);
			InformationManager.DisplayMessage(new InformationMessage("[AI Influence] create_rp_weapon: " + ex.Message, ExtraColors.RedAIInfluence));
			Stop();
		}
	}

	protected override void OnStop()
	{
		if (_completed)
			LogAction("RP weapon forge completed.");
		else
			LogError("RP weapon forge did not complete.");
	}

	protected override void OnUpdate(float deltaTime)
	{
	}
}
