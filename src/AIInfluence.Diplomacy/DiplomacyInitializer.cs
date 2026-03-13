using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class DiplomacyInitializer
{
	private static DiplomacyInitializer _instance;

	private bool _initialized = false;

	private bool _isNewGame = false;

	public static DiplomacyInitializer Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DiplomacyInitializer();
			}
			return _instance;
		}
	}

	public bool IsInitialized => _initialized;

	private DiplomacyInitializer()
	{
	}

	public void Initialize()
	{
		if (_initialized)
		{
			LogMessage("[DIPLOMACY_INIT] Already initialized, skipping");
			return;
		}
		LogMessage("[DIPLOMACY_INIT] Starting diplomacy system initialization...");
		LogMessage($"[DIPLOMACY_INIT] EnableDiplomacy = {GlobalSettings<ModSettings>.Instance.EnableDiplomacy}");
		LogMessage($"[DIPLOMACY_INIT] EnableDynamicEvents = {GlobalSettings<ModSettings>.Instance.EnableDynamicEvents}");
		LogMessage($"[DIPLOMACY_INIT] DynamicEventsDialogueOnly = {GlobalSettings<ModSettings>.Instance.DynamicEventsDialogueOnly}");
		LogMessage($"[DIPLOMACY_INIT] CanEnableDiplomacy = {GlobalSettings<ModSettings>.Instance.CanEnableDiplomacy()}");
		LogMessage($"[DIPLOMACY_INIT] StartInPeace = {GlobalSettings<ModSettings>.Instance.StartInPeace}");
		try
		{
			CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener((object)this, (Action<CampaignGameStarter>)OnNewGameCreated);
			CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener((object)this, (Action<CampaignGameStarter>)OnSessionLaunched);
			LogMessage("[DIPLOMACY_INIT] Subscribed to OnNewGameCreatedEvent and OnSessionLaunchedEvent for StartInPeace functionality");
			if (GlobalSettings<ModSettings>.Instance.EnableDiplomacy && GlobalSettings<ModSettings>.Instance.CanEnableDiplomacy())
			{
				DiplomacyLogger.Instance.LogInitialization(GlobalSettings<ModSettings>.Instance.EnableDiplomacy, GlobalSettings<ModSettings>.Instance.StartInPeace);
			}
			_initialized = true;
			LogMessage("[DIPLOMACY_INIT] Diplomacy system initialization completed successfully");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.LogError("DiplomacyInitializer.Initialize", "Failed to initialize diplomacy system", ex);
			LogMessage("[DIPLOMACY_INIT] ERROR: Failed to initialize diplomacy system: " + ex.Message);
		}
	}

	private void OnNewGameCreated(CampaignGameStarter starter)
	{
		try
		{
			LogMessage("[DIPLOMACY_INIT] OnNewGameCreated called - this is a NEW GAME");
			_isNewGame = true;
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.LogError("DiplomacyInitializer.OnNewGameCreated", "Failed to handle new game creation", ex);
			LogMessage("[DIPLOMACY_INIT] ERROR: Failed to handle new game creation: " + ex.Message);
		}
	}

	private void OnSessionLaunched(CampaignGameStarter starter)
	{
		try
		{
			LogMessage($"[DIPLOMACY_INIT] OnSessionLaunched called - isNewGame={_isNewGame}, StartInPeace={GlobalSettings<ModSettings>.Instance.StartInPeace}");
			if (_isNewGame && GlobalSettings<ModSettings>.Instance.StartInPeace)
			{
				LogMessage("[DIPLOMACY_INIT] New game with StartInPeace enabled, establishing peace between all kingdoms");
				EstablishPeaceBetweenAllKingdoms();
			}
			else if (_isNewGame)
			{
				LogMessage("[DIPLOMACY_INIT] New game but StartInPeace is disabled, skipping peace establishment");
			}
			else
			{
				LogMessage("[DIPLOMACY_INIT] Loading existing save, skipping peace establishment");
			}
			_isNewGame = false;
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.LogError("DiplomacyInitializer.OnSessionLaunched", "Failed to establish peace on session launch", ex);
			LogMessage("[DIPLOMACY_INIT] ERROR: Failed to establish peace on session launch: " + ex.Message);
		}
	}

	private void EstablishPeaceBetweenAllKingdoms()
	{
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		try
		{
			LogMessage("[DIPLOMACY_INIT] Establishing peace between all kingdoms...");
			List<Kingdom> list = Campaign.Current.Factions.Where((IFaction f) => f.IsKingdomFaction).Cast<Kingdom>().ToList();
			LogMessage($"[DIPLOMACY_INIT] Found {list.Count()} kingdoms");
			int num = 0;
			for (int num2 = 0; num2 < list.Count(); num2++)
			{
				for (int num3 = num2 + 1; num3 < list.Count(); num3++)
				{
					Kingdom kingdom1 = list[num2];
					Kingdom kingdom2 = list[num3];
					if (!FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom1, (IFaction)(object)kingdom2))
					{
						continue;
					}
					LogMessage($"[DIPLOMACY_INIT] Making peace between {kingdom1.Name} and {kingdom2.Name}");
					try
					{
						DiplomacyPatches.WithBypass(delegate
						{
							MakePeaceAction.Apply((IFaction)(object)kingdom1, (IFaction)(object)kingdom2);
						});
						num++;
						DiplomacyLogger.Instance.LogDiplomaticAction("peace_treaty", ((MBObjectBase)kingdom1).StringId, ((MBObjectBase)kingdom2).StringId, "Campaign start peace treaty");
					}
					catch (Exception ex)
					{
						LogMessage($"[DIPLOMACY_INIT] ERROR: Failed to make peace between {kingdom1.Name} and {kingdom2.Name}: {ex.Message}");
						DiplomacyLogger.Instance.LogError("DiplomacyInitializer.EstablishPeaceBetweenAllKingdoms", $"Failed to make peace between {kingdom1.Name} and {kingdom2.Name}", ex);
					}
				}
			}
			LogMessage($"[DIPLOMACY_INIT] Successfully established {num} peace treaties");
			ResetWarFatigueForAllKingdoms();
			if (num > 0)
			{
				TextObject val = new TextObject("{=AIInfluence_PeaceEstablished}Peace has been established between all kingdoms at the start of this campaign.", (Dictionary<string, object>)null);
				InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), new Color(0.2f, 0.8f, 0.2f, 1f)));
			}
		}
		catch (Exception ex2)
		{
			DiplomacyLogger.Instance.LogError("DiplomacyInitializer.EstablishPeaceBetweenAllKingdoms", "Failed to establish peace between kingdoms", ex2);
			LogMessage("[DIPLOMACY_INIT] ERROR: Failed to establish peace between kingdoms: " + ex2.Message);
		}
	}

	private void ResetWarFatigueForAllKingdoms()
	{
		try
		{
			LogMessage("[DIPLOMACY_INIT] Resetting war fatigue for all kingdoms...");
			List<Kingdom> list = Campaign.Current.Factions.Where((IFaction f) => f.IsKingdomFaction).Cast<Kingdom>().ToList();
			foreach (Kingdom item in list)
			{
				if (item == null || item.IsEliminated)
				{
					continue;
				}
				WarStatisticsTracker instance = WarStatisticsTracker.Instance;
				if (instance != null)
				{
					instance.InitializeKingdomStats(item);
					KingdomWarStats kingdomWarStats = instance.KingdomStats[((MBObjectBase)item).StringId];
					if (kingdomWarStats != null)
					{
						float warFatigue = kingdomWarStats.WarFatigue;
						kingdomWarStats.WarFatigue = 0f;
						LogMessage($"[DIPLOMACY_INIT] Reset war fatigue for {item.Name}: {warFatigue:F1}% → 0.0%");
					}
				}
			}
			LogMessage("[DIPLOMACY_INIT] War fatigue reset complete for all kingdoms");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.LogError("DiplomacyInitializer.ResetWarFatigueForAllKingdoms", "Failed to reset war fatigue", ex);
			LogMessage("[DIPLOMACY_INIT] ERROR: Failed to reset war fatigue: " + ex.Message);
		}
	}

	public void Reset()
	{
		_initialized = false;
		LogMessage("[DIPLOMACY_INIT] Reset initialization state");
	}

	private void LogMessage(string message)
	{
		if (AIInfluenceBehavior.Instance != null)
		{
			AIInfluenceBehavior.Instance.LogMessage(message);
			return;
		}
		try
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
			string path = Path.Combine(fullName, "mod_log.txt");
			string text = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
			File.AppendAllText(path, text + Environment.NewLine);
		}
		catch
		{
		}
	}
}
