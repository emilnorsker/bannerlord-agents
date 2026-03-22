using System;
using System.Reflection;
using AIInfluence.Behaviors;
using AIInfluence.Behaviors.DeathHistory;
using AIInfluence.Diplomacy;
using AIInfluence.Diseases;
using AIInfluence.DynamicEvents;
using AIInfluence.SettlementCombat;
using AIInfluence.UI;
using AIInfluence.Util;
using Bannerlord.UIExtenderEx;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ScreenSystem;

namespace AIInfluence;

public class SubModule : MBSubModuleBase
{
	private const string HarmonyId = "com.mfive.aiinfluence";

	private static readonly Harmony harmony = new Harmony("com.mfive.aiinfluence");

	private readonly UIExtender _uiExtender = GameVersionCompatibility.CreateUIExtender("AIInfluence");

	private AIInfluenceBehavior _aiInfluenceBehavior;

	private bool _isInitialized;

	private bool _loadMessageDisplayed;

	private float _loadMessageTimer;

	private const float MessageDelay = 1f;

	private bool _startMessageDisplayed;

	private float _startMessageTimer;

	private WorldEventsUILayer _worldEventsUILayer;

	private MapScreen _worldEventsLayerOwner;

	protected override void OnSubModuleLoad()
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		base.OnSubModuleLoad();
		_uiExtender.Register(typeof(SubModule).Assembly);
		_uiExtender.Enable();
		try
		{
			harmony.PatchAll();
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine("[AIInfluence] Harmony PatchAll failed: " + ex);
		}
		try
		{
			Type type = AccessTools.TypeByName("TaleWorlds.CampaignSystem.ViewModelCollection.CampaignUIHelper");
			if (type != null)
			{
				MethodInfo methodInfo = AccessTools.Method(type, "GetQuestsRelatedToSettlement", (Type[])null, (Type[])null);
				if (methodInfo != null)
				{
					MethodInfo methodInfo2 = AccessTools.Method(typeof(GetQuestsRelatedToSettlement_NullGuard), "Finalizer", (Type[])null, (Type[])null);
					harmony.Patch((MethodBase)methodInfo, (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null, new HarmonyMethod(methodInfo2));
				}
			}
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine("[AIInfluence] Optional Harmony patch (GetQuestsRelatedToSettlement) failed: " + ex);
		}
	}

	protected override void OnBeforeInitialModuleScreenSetAsRoot()
	{
		if (!_isInitialized)
		{
			_isInitialized = true;
		}
	}

	protected override void OnGameStart(Game game, IGameStarter gameStarter)
	{
		base.OnGameStart(game, gameStarter);
		CampaignGameStarter val = (CampaignGameStarter)(object)((gameStarter is CampaignGameStarter) ? gameStarter : null);
		if (val != null)
		{
			DiplomacyPatches.ApplyPatches(harmony);
			SettlementIncomeMultiplierPatch.ApplyPatch(harmony);
			_aiInfluenceBehavior = new AIInfluenceBehavior();
			val.AddBehavior((CampaignBehaviorBase)(object)_aiInfluenceBehavior);
			val.AddBehavior((CampaignBehaviorBase)(object)new SettlementPenaltyManager());
			val.AddBehavior((CampaignBehaviorBase)(object)new DeathHistoryBehavior());
			val.AddBehavior((CampaignBehaviorBase)(object)new EconomicEffectsManager());
			val.AddBehavior((CampaignBehaviorBase)(object)new NonCombatantPartyProtector());
			val.AddBehavior((CampaignBehaviorBase)(object)new DiseaseTreatmentAiBehavior());
		}
	}

	public override void OnGameEnd(Game game)
	{
		base.OnGameEnd(game);
		Console.WriteLine("[SUBMODULE] OnGameEnd called - resetting systems");
		if (_aiInfluenceBehavior != null)
		{
			_aiInfluenceBehavior = null;
		}
		InitializationManager.Instance.ResetAllSystems();
	}

	protected override void OnApplicationTick(float dt)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		base.OnApplicationTick(dt);
		if (!_loadMessageDisplayed)
		{
			_loadMessageTimer += dt;
			if (_loadMessageTimer >= 1f)
			{
				InformationManager.DisplayMessage(new InformationMessage("AI Influence Mod Loaded [BETA 4.0.2]"));
				_loadMessageDisplayed = true;
			}
		}
		if (Campaign.Current != null && !_startMessageDisplayed)
		{
			_startMessageTimer += dt;
			if (_startMessageTimer >= 1f)
			{
				InformationManager.DisplayMessage(new InformationMessage("AI Influence Mod Started in Game [BETA 4.0.2]"));
				_startMessageDisplayed = true;
			}
		}
		AIInfluenceTextQueryPopupManager.Tick();
		NpcChatWindowManager.Tick();
		if (Campaign.Current != null)
		{
			Campaign.Current.GetCampaignBehavior<AIInfluenceBehavior>()?.Tick(dt);
		}
		TryAttachWorldEventsLayer();
	}

	private void TryAttachWorldEventsLayer()
	{
		ScreenBase topScreen = ScreenManager.TopScreen;
		MapScreen val = (MapScreen)(object)((topScreen is MapScreen) ? topScreen : null);
		bool flag = ShouldShowWorldEventsButton();
		if (val == null || !flag)
		{
			if (_worldEventsUILayer != null)
			{
				MapScreen worldEventsLayerOwner = _worldEventsLayerOwner;
				if (worldEventsLayerOwner != null)
				{
					((ScreenBase)worldEventsLayerOwner).RemoveLayer((ScreenLayer)(object)_worldEventsUILayer);
				}
				if (val != null)
				{
					((ScreenBase)val).RemoveLayer((ScreenLayer)(object)_worldEventsUILayer);
				}
				_worldEventsUILayer = null;
				_worldEventsLayerOwner = null;
			}
		}
		else if (_worldEventsUILayer == null)
		{
			_worldEventsUILayer = new WorldEventsUILayer();
			((ScreenBase)val).AddLayer((ScreenLayer)(object)_worldEventsUILayer);
			_worldEventsLayerOwner = val;
		}
	}

	private bool ShouldShowWorldEventsButton()
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null)
		{
			return false;
		}
		return instance.EnableModification && instance.EnableDiplomacy && instance.EnableDynamicEvents && instance.CanEnableDiplomacy();
	}
}
