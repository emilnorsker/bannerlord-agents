using System;
using System.Collections.Generic;
using AIInfluence;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace AIInfluence.Behaviors.AIActions;

public sealed class CreatePartyAction : AIActionBase
{
	public static bool NextForceOutlawBlgm { get; set; }

	public static bool NextSkipOutlawBlgm { get; set; }

	private bool _partyCreated;

	public override string ActionName => "create_party";

	public override string Description => "Hero forms an independent clan party";

	public override bool CanExecute()
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		if (base.TargetHero == null)
		{
			return false;
		}
		if (base.TargetHero.IsDead || base.TargetHero.IsPrisoner)
		{
			return false;
		}
		if (base.TargetHero.Clan != Clan.PlayerClan)
		{
			TextObject notInClanMessage = new TextObject("{=AIAction_CreatePartyNotClan}{HERO_NAME} cannot create a party - not a member of your clan.", (Dictionary<string, object>)null);
			notInClanMessage.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(notInClanMessage);
			return false;
		}
		if (base.TargetHero.PartyBelongedTo != null && base.TargetHero.PartyBelongedTo != MobileParty.MainParty)
		{
			TextObject alreadyCommandsPartyMessage = new TextObject("{=AIAction_CreatePartyAlreadyHas}{HERO_NAME} cannot create a party - already commands their own party.", (Dictionary<string, object>)null);
			alreadyCommandsPartyMessage.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(alreadyCommandsPartyMessage);
			return false;
		}
		return true;
	}

	protected override void OnStart()
	{
		bool forceOutlaw = NextForceOutlawBlgm;
		bool skipOutlaw = NextSkipOutlawBlgm;
		NextForceOutlawBlgm = false;
		NextSkipOutlawBlgm = false;
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		if (!CanExecute())
		{
			Stop();
			return;
		}
		if (!skipOutlaw && OutlawPartyBlgmService.ShouldUseOutlawBlgmPath(base.TargetHero, forceOutlaw))
		{
			OutlawPartyBlgmService.Result outlawResult = OutlawPartyBlgmService.TryCreateOutlawMinorClanFromPlayerCompanion(base.TargetHero, 2, null);
			if (outlawResult.Success)
			{
				foreach (string w in outlawResult.Warnings)
				{
					LogAction(w);
					InformationManager.DisplayMessage(new InformationMessage("[AI Influence] " + w, ExtraColors.RedAIInfluence));
				}
				_partyCreated = true;
				TextObject outlawBreakawaySuccessMessage = new TextObject("{=AIAction_CreatePartyOutlawSuccess}{HERO_NAME} broke away as an outlaw clan \"{CLAN_NAME}\" and now roams independently (at war with you and a nearby realm).", (Dictionary<string, object>)null);
				outlawBreakawaySuccessMessage.SetTextVariable("HERO_NAME", ((object)base.TargetHero.Name)?.ToString() ?? "Unknown");
				outlawBreakawaySuccessMessage.SetTextVariable("CLAN_NAME", ((object)outlawResult.Clan?.Name)?.ToString() ?? "Outlaws");
				ShowSuccessDelayed(((object)outlawBreakawaySuccessMessage).ToString());
				LogAction($"Created BLGM outlaw minor clan '{outlawResult.Clan?.Name}' for {base.TargetHero.Name}");
				Stop();
				return;
			}
			string outlawFallbackReason = outlawResult.Error ?? "Unknown error";
			LogError("Outlaw BLGM path failed, falling back to player-clan party: " + outlawFallbackReason);
			InformationManager.DisplayMessage(new InformationMessage("[AI Influence] Outlaw clan creation failed; forming a normal clan party instead. " + outlawFallbackReason, ExtraColors.RedAIInfluence));
		}
		MobileParty playerClanLordParty = GameVersionCompatibility.CreateNewClanMobileParty(base.TargetHero, Clan.PlayerClan);
		if (playerClanLordParty == null)
		{
			TextObject createPartyFailedMessage = new TextObject("{=AIAction_CreatePartyFailed}{HERO_NAME} failed to create a party.", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			createPartyFailedMessage.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			InformationManager.DisplayMessage(new InformationMessage(((object)createPartyFailedMessage).ToString(), ExtraColors.RedAIInfluence));
			LogError("CreateNewClanMobileParty returned null");
			Stop();
			return;
		}
		try
		{
			GameVersionCompatibility.ConditionalEnableAi(playerClanLordParty);
		}
		catch (Exception ex)
		{
			LogError("Failed to enable AI for new party: " + ex.Message);
		}
		NonCombatantPartyProtector instance = NonCombatantPartyProtector.Instance;
		if (instance != null)
		{
			instance.RegisterPartyForProtection(playerClanLordParty, base.TargetHero, "CreateParty");
			LogAction($"Registered party {playerClanLordParty.Name} for non-combatant protection");
		}
		_partyCreated = true;
		TextObject standardSuccessMessage = new TextObject("{=AIAction_CreatePartySuccess}{HERO_NAME} formed the party \"{PARTY_NAME}\" and now roams independently.", (Dictionary<string, object>)null);
		Hero targetHero2 = base.TargetHero;
		standardSuccessMessage.SetTextVariable("HERO_NAME", ((targetHero2 == null) ? null : ((object)targetHero2.Name)?.ToString()) ?? "Unknown");
		standardSuccessMessage.SetTextVariable("PARTY_NAME", ((object)playerClanLordParty.Name)?.ToString() ?? "Unnamed party");
		ShowSuccessDelayed(((object)standardSuccessMessage).ToString());
		LogAction($"Created independent party '{playerClanLordParty.Name}' for {base.TargetHero.Name} at {playerClanLordParty.GetPosition2D()}");
		Stop();
	}

	protected override void OnStop()
	{
		if (_partyCreated)
		{
			LogAction($"Party creation finalized for {base.TargetHero.Name}");
		}
	}

	protected override void OnUpdate(float deltaTime)
	{
	}

	private static void ShowSuccessDelayed(string text)
	{
		DelayedTaskManager delayedTaskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
		if (delayedTaskManager != null)
			delayedTaskManager.AddTask(6.0, delegate { InformationManager.DisplayMessage(new InformationMessage(text, ExtraColors.GreenAIInfluence)); });
		else
			InformationManager.DisplayMessage(new InformationMessage(text, ExtraColors.GreenAIInfluence));
	}
}
