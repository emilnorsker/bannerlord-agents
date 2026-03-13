using System;
using System.IO;
using System.Reflection;
using AIInfluence.Behaviors.AIActions;
using AIInfluence.Behaviors.AIActions.TaskSystem;
using AIInfluence.Behaviors.RolePlay;
using AIInfluence.Diplomacy;
using AIInfluence.DynamicEvents;
using AIInfluence.SettlementCombat;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace AIInfluence;

public class InitializationManager
{
	private static InitializationManager _instance;

	private bool _isInitialized = false;

	private AIInfluenceBehavior _behavior;

	public static InitializationManager Instance => _instance ?? (_instance = new InitializationManager());

	public bool IsInitialized => _isInitialized;

	private InitializationManager()
	{
	}

	public void InitializeAllSystems(AIInfluenceBehavior behavior, CampaignGameStarter campaignGameStarter)
	{
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		if (_isInitialized)
		{
			behavior?.LogMessage("[INIT_MANAGER] Системы уже инициализированы - пропускаем повторную инициализацию");
			return;
		}
		_behavior = behavior;
		try
		{
			behavior?.LogMessage("[INIT_MANAGER] Начало инициализации всех систем...");
			if (campaignGameStarter != null)
			{
				campaignGameStarter.AddBehavior((CampaignBehaviorBase)(object)new DialogLogger());
			}
			DialogManager.Instance.RegisterDialogs(campaignGameStarter);
			behavior?.LogMessage("[INIT_MANAGER] DialogManager инициализирован и диалоги зарегистрированы.");
			behavior?.LoadAllNPCsForEvent();
			behavior?.CreateKingdomLeadersContexts();
			DynamicEventsManager.Instance.Initialize();
			behavior?.LogMessage("[INIT_MANAGER] DynamicEventsManager инициализирован.");
			InitializeSettlementOwnershipTracker();
			InitializeKingdomLeadershipTracker();
			InitializeDiplomacyManager();
			InitializeNPCInitiativeSystem();
			InitializeAIActionsManager();
			InitializeTaskManager(campaignGameStarter);
			MessengerMenuBehavior.AddTavernMenuOption(campaignGameStarter);
		InitializeSettlementPenaltyManager();
		InitializeEconomicEffectsManager();
		InitializeRPItemManager(behavior);
		InitializeArenaTrainingSystem(campaignGameStarter);
			_isInitialized = true;
			behavior?.LogMessage("[INIT_MANAGER] Все системы успешно инициализированы.");
		}
		catch (Exception ex)
		{
			behavior?.LogMessage("[INIT_MANAGER] ОШИБКА при инициализации: " + ex.Message);
			behavior?.LogMessage("[INIT_MANAGER] StackTrace: " + ex.StackTrace);
			InformationManager.DisplayMessage(new InformationMessage("AIInfluence initialization error: " + ex.Message, ExtraColors.RedAIInfluence));
		}
	}

	private void InitializeSettlementOwnershipTracker()
	{
		try
		{
			SettlementOwnershipTracker.Instance.RegisterEvents();
			SettlementOwnershipTracker.Instance.LoadData();
			if (!SettlementOwnershipTracker.Instance.IsInitialized())
			{
				SettlementOwnershipTracker.Instance.InitializeStartingOwnership();
				SettlementOwnershipTracker.Instance.SaveData();
				_behavior?.LogMessage("[INIT_MANAGER] SettlementOwnershipTracker инициализирован для новой игры.");
			}
			else
			{
				SettlementOwnershipTracker.Instance.InitializeCapitals();
				SettlementOwnershipTracker.Instance.SaveData();
				_behavior?.LogMessage("[INIT_MANAGER] SettlementOwnershipTracker уже инициализирован, данные загружены из сохранения.");
			}
		}
		catch (Exception ex)
		{
			_behavior?.LogMessage("[INIT_MANAGER] Ошибка инициализации SettlementOwnershipTracker: " + ex.Message);
		}
	}

	private void InitializeKingdomLeadershipTracker()
	{
		try
		{
			KingdomLeadershipTracker.Instance.RegisterEvents();
			KingdomLeadershipTracker.Instance.LoadData();
			if (!KingdomLeadershipTracker.Instance.IsInitialized())
			{
				KingdomLeadershipTracker.Instance.InitializeStartingLeaders();
				KingdomLeadershipTracker.Instance.SaveData();
				_behavior?.LogMessage("[INIT_MANAGER] KingdomLeadershipTracker инициализирован для новой игры.");
			}
			else
			{
				_behavior?.LogMessage("[INIT_MANAGER] KingdomLeadershipTracker уже инициализирован, данные загружены из сохранения.");
			}
		}
		catch (Exception ex)
		{
			_behavior?.LogMessage("[INIT_MANAGER] Ошибка инициализации KingdomLeadershipTracker: " + ex.Message);
		}
	}

	private void InitializeDiplomacyManager()
	{
		try
		{
			if (GlobalSettings<ModSettings>.Instance.EnableDiplomacy && GlobalSettings<ModSettings>.Instance.CanEnableDiplomacy())
			{
				DiplomacyManager.Instance.Initialize();
				_behavior?.LogMessage("[INIT_MANAGER] DiplomacyManager инициализирован.");
			}
			else
			{
				_behavior?.LogMessage($"[INIT_MANAGER] DiplomacyManager пропущен - EnableDiplomacy={GlobalSettings<ModSettings>.Instance.EnableDiplomacy}, CanEnableDiplomacy={GlobalSettings<ModSettings>.Instance.CanEnableDiplomacy()}");
			}
		}
		catch (Exception ex)
		{
			_behavior?.LogMessage("[INIT_MANAGER] Ошибка инициализации DiplomacyManager: " + ex.Message);
		}
	}

	private void InitializeNPCInitiativeSystem()
	{
		try
		{
			if (_behavior != null && _behavior.GetNPCInitiativeSystem() == null)
			{
				_behavior.InitializeNPCInitiativeSystem();
				_behavior?.LogMessage("[INIT_MANAGER] NPC Initiative System инициализирован.");
			}
		}
		catch (Exception ex)
		{
			_behavior?.LogMessage("[INIT_MANAGER] Ошибка инициализации NPC Initiative System: " + ex.Message);
		}
	}

	private void InitializeAIActionsManager()
	{
		try
		{
			AIActionManager instance = AIActionManager.Instance;
			if (instance != null)
			{
				instance.InitializeEvents();
				int count = instance.GetRegisteredActions().Count;
				_behavior?.LogMessage($"[INIT_MANAGER] AI Actions Manager инициализирован с {count} зарегистрированными действиями.");
				_behavior?.LogMessage("[INIT_MANAGER] AI Actions Manager готов к использованию.");
			}
			else
			{
				_behavior?.LogMessage("[INIT_MANAGER] WARNING: AI Actions Manager Instance is null!");
			}
		}
		catch (Exception ex)
		{
			_behavior?.LogMessage("[INIT_MANAGER] Ошибка инициализации AI Actions Manager: " + ex.Message);
			_behavior?.LogMessage("[INIT_MANAGER] StackTrace: " + ex.StackTrace);
		}
	}

	private void InitializeTaskManager(CampaignGameStarter campaignGameStarter)
	{
		try
		{
			TaskManager taskManager = new TaskManager();
			if (campaignGameStarter != null)
			{
				campaignGameStarter.AddBehavior((CampaignBehaviorBase)(object)taskManager);
			}
			TaskManager.SetInstance(taskManager);
			_behavior?.LogMessage("[INIT_MANAGER] TaskManager зарегистрирован как CampaignBehavior.");
		}
		catch (Exception ex)
		{
			_behavior?.LogMessage("[INIT_MANAGER] Ошибка инициализации TaskManager: " + ex.Message);
		}
	}

	public void InitializeDiplomacyInitializer()
	{
		try
		{
			DiplomacyInitializer.Instance.Initialize();
			_behavior?.LogMessage("[INIT_MANAGER] DiplomacyInitializer инициализирован и подписан на события игры.");
		}
		catch (Exception ex)
		{
			_behavior?.LogMessage("[INIT_MANAGER] Ошибка инициализации DiplomacyInitializer: " + ex.Message);
		}
	}

	private void InitializeSettlementPenaltyManager()
	{
		try
		{
			if (SettlementPenaltyManager.Instance != null)
			{
				SettlementPenaltyManager.Instance.Initialize();
				_behavior?.LogMessage("[INIT_MANAGER] SettlementPenaltyManager инициализирован.");
			}
			else
			{
				_behavior?.LogMessage("[INIT_MANAGER] WARNING: SettlementPenaltyManager.Instance is null!");
			}
		}
		catch (Exception ex)
		{
			_behavior?.LogMessage("[INIT_MANAGER] Ошибка инициализации SettlementPenaltyManager: " + ex.Message);
		}
	}

	private void InitializeEconomicEffectsManager()
	{
		try
		{
			if (EconomicEffectsManager.Instance != null)
			{
				_behavior?.LogMessage("[INIT_MANAGER] EconomicEffectsManager найден и будет инициализирован через события кампании.");
			}
			else
			{
				_behavior?.LogMessage("[INIT_MANAGER] WARNING: EconomicEffectsManager.Instance is null!");
			}
		}
		catch (Exception ex)
		{
			_behavior?.LogMessage("[INIT_MANAGER] Ошибка инициализации EconomicEffectsManager: " + ex.Message);
		}
	}

	private void InitializeRPItemManager(AIInfluenceBehavior behavior)
	{
		try
		{
			if (behavior != null)
			{
				string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
				string saveDataPath = Path.Combine(fullName, "save_data");
				RPItemManager.Instance.Initialize(saveDataPath);
				_behavior?.LogMessage("[INIT_MANAGER] RPItemManager инициализирован.");
			}
		}
		catch (Exception ex)
		{
			_behavior?.LogMessage("[INIT_MANAGER] Ошибка инициализации RPItemManager: " + ex.Message);
		}
	}

	private void InitializeArenaTrainingSystem(CampaignGameStarter campaignGameStarter)
	{
		try
		{
			ArenaTrainingMenuBehavior.AddMenus(campaignGameStarter);
			if (campaignGameStarter != null)
			{
				campaignGameStarter.AddBehavior((CampaignBehaviorBase)(object)new ArenaTrainingMenuBehavior());
			}
			_behavior?.LogMessage("[INIT_MANAGER] Arena training system initialized.");
		}
		catch (Exception ex)
		{
			_behavior?.LogMessage("[INIT_MANAGER] Error initializing Arena Training System: " + ex.Message);
			_behavior?.LogMessage("[INIT_MANAGER] StackTrace: " + ex.StackTrace);
		}
	}

	public void ResetAllSystems()
	{
		try
		{
			Console.WriteLine("[INIT_MANAGER] ResetAllSystems called");
			AIInfluenceBehavior behavior = _behavior;
			behavior?.LogMessage("[INIT_MANAGER] Начало сброса всех систем...");
			AIInfluenceBehavior.ResetStaticFlags();
			DynamicEventsManager.Reset();
			SettlementOwnershipTracker.Instance.ResetInitialization();
			KingdomLeadershipTracker.Instance.ResetInitialization();
		DiplomacyInitializer.Instance.Reset();
		TaskManager.ResetInstance();
			_isInitialized = false;
			_behavior = null;
			behavior?.LogMessage("[INIT_MANAGER] Все системы успешно сброшены.");
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior behavior2 = _behavior;
			behavior2?.LogMessage("[INIT_MANAGER] ОШИБКА при сбросе систем: " + ex.Message);
			behavior2?.LogMessage("[INIT_MANAGER] StackTrace: " + ex.StackTrace);
		}
	}

	public void ForceReset()
	{
		_isInitialized = false;
		_behavior = null;
	}
}
