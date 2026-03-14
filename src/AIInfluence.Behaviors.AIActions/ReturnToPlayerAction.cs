using System;
using System.Collections.Generic;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions;

public class ReturnToPlayerAction : AIActionBase
{
	private const float REACH_DISTANCE = 2f;

	private bool _dialogShown = false;

	private CampaignTime _lastDistanceCheckTime = CampaignTime.Zero;

	private const float DISTANCE_CHECK_INTERVAL_HOURS = 0.1f;

	private bool _followActionStarted = false;

	private static readonly HashSet<string> _returningHeroIds = new HashSet<string>();

	public override string ActionName => "return_to_player";

	public override string Description => "Hero returns to player after completing task";

	internal static bool IsHeroReturning(Hero hero)
	{
		return hero != null && !string.IsNullOrEmpty(((MBObjectBase)hero).StringId) && _returningHeroIds.Contains(((MBObjectBase)hero).StringId);
	}

	private void RegisterReturnContext()
	{
		if (base.TargetHero != null && !string.IsNullOrEmpty(((MBObjectBase)base.TargetHero).StringId))
		{
			_returningHeroIds.Add(((MBObjectBase)base.TargetHero).StringId);
		}
	}

	private void ClearReturnContext()
	{
		if (base.TargetHero != null && !string.IsNullOrEmpty(((MBObjectBase)base.TargetHero).StringId))
		{
			_returningHeroIds.Remove(((MBObjectBase)base.TargetHero).StringId);
		}
	}

	public override bool CanExecute()
	{
		if (base.TargetHero == null)
		{
			return false;
		}
		return AIActionManager.Instance.GetRegisteredActions().Contains("follow_player");
	}

	protected override void OnStart()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		if (base.TargetHero == null)
		{
			LogError("TargetHero is null");
			return;
		}
		_dialogShown = false;
		_lastDistanceCheckTime = CampaignTime.Zero;
		_followActionStarted = false;
		RegisterReturnContext();
		if (!AIActionManager.Instance.StartAction(base.TargetHero, "follow_player"))
		{
			LogError($"Failed to start follow_player action for {base.TargetHero.Name}");
			TextObject val = new TextObject("{=AIAction_ReturnFailed}{HERO_NAME} cannot return to you - failed to start travel.", (Dictionary<string, object>)null);
			val.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val);
			Stop();
		}
		else
		{
			_followActionStarted = true;
			LogAction($"Started return_to_player for {base.TargetHero.Name}");
		}
	}

	protected override void OnStop()
	{
		if (_followActionStarted)
		{
			AIActionManager.Instance.StopAction(base.TargetHero, "follow_player");
		}
		ClearReturnContext();
		_followActionStarted = false;
		_dialogShown = false;
		Hero targetHero = base.TargetHero;
		LogAction($"Stopped return_to_player for {((targetHero != null) ? targetHero.Name : null)}");
	}

	protected override void OnUpdate(float deltaTime)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		if (base.TargetHero == null)
		{
			return;
		}
		if (!AIActionManager.Instance.IsActionActive(base.TargetHero, "follow_player"))
		{
			Stop();
			return;
		}
		CampaignTime now = CampaignTime.Now;
		if (now - _lastDistanceCheckTime >= CampaignTime.Hours(0.1f))
		{
			_lastDistanceCheckTime = now;
			CheckDistanceToPlayer();
		}
	}

	private void CheckDistanceToPlayer()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			MobileParty mainParty = MobileParty.MainParty;
			if (partyBelongedTo != null && mainParty != null && partyBelongedTo.CurrentSettlement == null && mainParty.CurrentSettlement == null)
			{
				Vec2 position2D = partyBelongedTo.GetPosition2D();
				float num = (position2D).Distance(mainParty.GetPosition2D());
				if (num <= 2f && !_dialogShown)
				{
					ShowReturnDialog();
					_dialogShown = true;
				}
			}
		}
		catch (Exception ex)
		{
			LogError("Error checking distance to player: " + ex.Message);
		}
	}

	private void ShowReturnDialog()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		try
		{
			if (base.TargetHero != null)
			{
				string text = ((object)base.TargetHero.Name)?.ToString() ?? "Unknown";
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("HERO_NAME", text);
				TextObject val = new TextObject("{=AIInfluence_ReturnToPlayer_Title}{HERO_NAME} has returned", dictionary);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("HERO_NAME", text);
				TextObject val2 = new TextObject("{=AIInfluence_ReturnToPlayer_Message}{HERO_NAME} has completed their task and wants to talk to you.", dictionary2);
				InformationManager.ShowInquiry(new InquiryData(((object)val).ToString(), ((object)val2).ToString(), true, true, ((object)new TextObject("{=AIInfluence_AcceptTalk}Talk", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_DeclineTalk}Not now", (Dictionary<string, object>)null)).ToString(), (Action)delegate
				{
					OnAcceptTalk();
				}, (Action)delegate
				{
					OnDeclineTalk();
				}, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), true, false);
				LogAction("Showed return dialog for " + text);
			}
		}
		catch (Exception ex)
		{
			LogError("Error showing return dialog: " + ex.Message);
		}
	}

	private async void OnAcceptTalk()
	{
		try
		{
			if (base.TargetHero == null)
			{
				return;
			}
			LogAction($"Player accepted talk with {base.TargetHero.Name} after return");
			AIInfluenceBehavior behavior = AIInfluenceBehavior.Instance;
			if (behavior == null)
			{
				LogError("AIInfluenceBehavior.Instance is null");
				return;
			}
			NPCInitiativeSystem npcInitiativeSystem = behavior.GetNPCInitiativeSystem();
			if (npcInitiativeSystem == null)
			{
				LogError("NPCInitiativeSystem is null");
				return;
			}
			NPCContext context = behavior.GetOrCreateNPCContext(base.TargetHero);
			behavior.UpdateContextData(context, base.TargetHero);
			context.IsNPCInitiatedConversation = true;
			if (string.IsNullOrEmpty(context.AdditionalContext))
			{
				context.AdditionalContext = "";
			}
			context.AdditionalContext += "\n[CONTEXT: You have just returned to the player after completing a task they assigned to you. You want to report on what you did and discuss the results.]";
			behavior.SaveNPCContext(((MBObjectBase)base.TargetHero).StringId, base.TargetHero, context);
			NPCInitiativeRequest request = new NPCInitiativeRequest
			{
				NPC = base.TargetHero,
				Context = context,
				IsInParty = (base.TargetHero.PartyBelongedTo == MobileParty.MainParty),
				CreatedTime = CampaignTime.Now
			};
			await npcInitiativeSystem.StartConversationAfterReturn(request);
			LogAction($"Started conversation with {base.TargetHero.Name} after return");
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			LogError("Error in OnAcceptTalk: " + ex2.Message + "\n" + ex2.StackTrace);
		}
		finally
		{
			Stop();
		}
	}

	private void OnDeclineTalk()
	{
		try
		{
			if (base.TargetHero != null)
			{
				LogAction($"Player declined talk with {base.TargetHero.Name} after return");
				Stop();
				List<string> activeActions = AIActionManager.Instance.GetActiveActions(base.TargetHero);
				if (activeActions != null && activeActions.Count > 0)
				{
					LogAction(string.Format("Stopping remaining actions for {0}: {1}", base.TargetHero.Name, string.Join(", ", activeActions)));
					AIActionManager.Instance.StopAllActions(base.TargetHero);
				}
			}
		}
		catch (Exception ex)
		{
			LogError("Error in OnDeclineTalk: " + ex.Message);
		}
	}

	private new void LogAction(string message)
	{
		AIActionsLogger.Instance.Log("[return_to_player] " + message);
	}

	private new void LogError(string message)
	{
		AIActionsLogger.Instance.Log("[return_to_player] ERROR: " + message);
	}
}
