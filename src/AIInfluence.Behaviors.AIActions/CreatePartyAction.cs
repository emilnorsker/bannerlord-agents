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
			TextObject val = new TextObject("{=AIAction_CreatePartyNotClan}{HERO_NAME} cannot create a party - not a member of your clan.", (Dictionary<string, object>)null);
			val.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val);
			return false;
		}
		if (base.TargetHero.PartyBelongedTo != null && base.TargetHero.PartyBelongedTo != MobileParty.MainParty)
		{
			TextObject val2 = new TextObject("{=AIAction_CreatePartyAlreadyHas}{HERO_NAME} cannot create a party - already commands their own party.", (Dictionary<string, object>)null);
			val2.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val2);
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
				MobileParty outlawParty = outlawResult.Party;
				TextObject valOutlaw = new TextObject("{=AIAction_CreatePartyOutlawSuccess}{HERO_NAME} broke away as an outlaw clan \"{CLAN_NAME}\" and now roams independently (at war with you and a nearby realm).", (Dictionary<string, object>)null);
				valOutlaw.SetTextVariable("HERO_NAME", ((object)base.TargetHero.Name)?.ToString() ?? "Unknown");
				valOutlaw.SetTextVariable("CLAN_NAME", ((object)outlawResult.Clan?.Name)?.ToString() ?? "Outlaws");
				ShowSuccessDelayed(((object)valOutlaw).ToString());
				LogAction($"Created BLGM outlaw minor clan '{outlawResult.Clan?.Name}' for {base.TargetHero.Name}");
				Stop();
				return;
			}
			string err = outlawResult.Error ?? "Unknown error";
			LogError("Outlaw BLGM path failed, falling back to player-clan party: " + err);
			InformationManager.DisplayMessage(new InformationMessage("[AI Influence] Outlaw clan creation failed; forming a normal clan party instead. " + err, ExtraColors.RedAIInfluence));
		}
		MobileParty val = GameVersionCompatibility.CreateNewClanMobileParty(base.TargetHero, Clan.PlayerClan);
		if (val == null)
		{
			TextObject val2 = new TextObject("{=AIAction_CreatePartyFailed}{HERO_NAME} failed to create a party.", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			val2.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), ExtraColors.RedAIInfluence));
			LogError("CreateNewClanMobileParty returned null");
			Stop();
			return;
		}
		try
		{
			GameVersionCompatibility.ConditionalEnableAi(val);
		}
		catch (Exception ex)
		{
			LogError("Failed to enable AI for new party: " + ex.Message);
		}
		NonCombatantPartyProtector instance = NonCombatantPartyProtector.Instance;
		if (instance != null)
		{
			instance.RegisterPartyForProtection(val, base.TargetHero, "CreateParty");
			LogAction($"Registered party {val.Name} for non-combatant protection");
		}
		_partyCreated = true;
		TextObject val3 = new TextObject("{=AIAction_CreatePartySuccess}{HERO_NAME} formed the party \"{PARTY_NAME}\" and now roams independently.", (Dictionary<string, object>)null);
		Hero targetHero2 = base.TargetHero;
		val3.SetTextVariable("HERO_NAME", ((targetHero2 == null) ? null : ((object)targetHero2.Name)?.ToString()) ?? "Unknown");
		val3.SetTextVariable("PARTY_NAME", ((val == null) ? null : ((object)val.Name)?.ToString()) ?? "Unnamed party");
		ShowSuccessDelayed(((object)val3).ToString());
		LogAction($"Created independent party '{val.Name}' for {base.TargetHero.Name} at {val.GetPosition2D()}");
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
