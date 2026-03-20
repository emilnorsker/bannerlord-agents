using System;
using System.Collections.Generic;
using AIInfluence.Behaviors.RolePlay;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions;

public class CreateRPItemAction : AIActionBase
{
	internal class ItemCreationRequest
	{
		public string ItemName { get; set; }

		public string ItemDescription { get; set; }

		public Dictionary<string, object> Metadata { get; set; }
	}

	private static readonly Dictionary<string, ItemCreationRequest> PendingRequests = new Dictionary<string, ItemCreationRequest>();

	private string _itemName;

	private string _itemDescription;

	private Dictionary<string, object> _metadata;

	private bool _itemCreated;

	private bool _itemGivenToPlayer;

	public override string ActionName => "create_rp_item";

	public override string Description => "AI creates a roleplay item (letter, document, physical prop, etc.) and gives it to the player";

	public static bool PrepareItemCreation(Hero hero, string itemName, string itemDescription, Dictionary<string, object> metadata = null)
	{
		if (hero == null || string.IsNullOrWhiteSpace(itemName))
		{
			return false;
		}
		PendingRequests[((MBObjectBase)hero).StringId] = new ItemCreationRequest
		{
			ItemName = itemName,
			ItemDescription = (itemDescription ?? ""),
			Metadata = (metadata ?? new Dictionary<string, object>())
		};
		return true;
	}

	private static ItemCreationRequest GetPendingRequest(Hero hero)
	{
		if (hero == null || !PendingRequests.TryGetValue(((MBObjectBase)hero).StringId, out var value))
		{
			return null;
		}
		PendingRequests.Remove(((MBObjectBase)hero).StringId);
		return value;
	}

	public void InitializeWithItemData(Hero hero, string itemName, string itemDescription, Dictionary<string, object> metadata = null)
	{
		Initialize(hero);
		_itemName = itemName ?? "RP Item";
		_itemDescription = itemDescription ?? "";
		_metadata = metadata ?? new Dictionary<string, object>();
		_itemCreated = false;
		_itemGivenToPlayer = false;
	}

	public override bool CanExecute()
	{
		if (base.TargetHero == null || Hero.MainHero == null || MobileParty.MainParty == null)
		{
			return false;
		}
		ItemCreationRequest pendingRequest = GetPendingRequest(base.TargetHero);
		if (pendingRequest != null)
		{
			_itemName = pendingRequest.ItemName;
			_itemDescription = pendingRequest.ItemDescription;
			_metadata = pendingRequest.Metadata;
		}
		else
		{
			_itemName = "RP Item";
			_itemDescription = "";
			_metadata = new Dictionary<string, object>();
		}
		return true;
	}

	protected override void OnStart()
	{
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		LogAction("Starting RP item creation: " + _itemName);
		try
		{
			RPItemManager instance = RPItemManager.Instance;
			string itemName = _itemName;
			string itemDescription = _itemDescription;
			Hero targetHero = base.TargetHero;
			if (!instance.CreateAndGiveItemToPlayer(itemName, itemDescription, (targetHero != null) ? ((MBObjectBase)targetHero).StringId : null, _metadata))
			{
				LogError("Failed to create and give RP item: " + _itemName);
				Stop();
				return;
			}
			_itemCreated = true;
			_itemGivenToPlayer = true;
			LogAction("RP item created and given to player: " + _itemName);
			DelayedTaskManager delayedTaskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
			if (delayedTaskManager != null)
			{
				Hero targetHero2 = base.TargetHero;
				string heroName = ((targetHero2 == null) ? null : ((object)targetHero2.Name)?.ToString()) ?? "NPC";
				string itemName2 = _itemName;
				delayedTaskManager.AddTask(3.0, delegate
				{
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					//IL_000d: Expected O, but got Unknown
					//IL_0037: Unknown result type (might be due to invalid IL or missing references)
					//IL_003c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0046: Expected O, but got Unknown
					TextObject val2 = new TextObject("{=AIAction_RPItemCreated}{HERO_NAME} give you {ITEM_NAME}.", (Dictionary<string, object>)null);
					val2.SetTextVariable("HERO_NAME", heroName);
					val2.SetTextVariable("ITEM_NAME", itemName2);
					InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), ExtraColors.GreenAIInfluence));
				});
			}
			else
			{
				TextObject val = new TextObject("{=AIAction_RPItemCreated}{HERO_NAME} give you {ITEM_NAME}.", (Dictionary<string, object>)null);
				Hero targetHero3 = base.TargetHero;
				val.SetTextVariable("HERO_NAME", ((targetHero3 == null) ? null : ((object)targetHero3.Name)?.ToString()) ?? "NPC");
				val.SetTextVariable("ITEM_NAME", _itemName);
				InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), ExtraColors.GreenAIInfluence));
			}
			Stop();
		}
		catch (Exception ex)
		{
			LogError("Exception in CreateRPItemAction: " + ex.Message + "\n" + ex.StackTrace);
			Stop();
		}
	}

	protected override void OnStop()
	{
		if (_itemCreated && _itemGivenToPlayer)
		{
			LogAction("RP item creation completed: " + _itemName);
		}
		else if (_itemCreated && !_itemGivenToPlayer)
		{
			LogError("RP item was created but not given to player: " + _itemName);
		}
		else
		{
			LogError("RP item creation failed: " + _itemName);
		}
	}

	protected override void OnUpdate(float deltaTime)
	{
	}
}
