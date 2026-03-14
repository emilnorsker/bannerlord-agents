using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AIInfluence.Diplomacy;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.DynamicEvents;

public class DynamicEventsManager
{
	private static DynamicEventsManager _instance;

	private readonly List<DynamicEvent> _activeEvents;

	private readonly DynamicEventsStorage _storage;

	private readonly DynamicEventsGenerator _generator;

	private CampaignTime _lastGenerationTime;

	private bool _isGeneratingManually = false;

	private bool _generationInProgress = false;

	private bool _initialized = false;

	public static DynamicEventsManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DynamicEventsManager();
			}
			return _instance;
		}
	}

	private DynamicEventsManager()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		_activeEvents = new List<DynamicEvent>();
		_storage = new DynamicEventsStorage();
		_generator = new DynamicEventsGenerator();
		_lastGenerationTime = CampaignTime.Now;
	}

	public void Initialize()
	{
		if (_initialized)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Already initialized - skipping to prevent double initialization");
			return;
		}
		DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Initializing DynamicEventsManager...");
		List<DynamicEvent> list = _storage.LoadEvents();
		if (list != null && list.Any())
		{
			_activeEvents.AddRange(list);
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Loaded {list.Count} events from storage");
		}
		RemoveExpiredEvents();
		_initialized = true;
		DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] DynamicEventsManager initialized successfully");
	}

	public void OnDailyTick()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		if (!GlobalSettings<ModSettings>.Instance.EnableModification || !GlobalSettings<ModSettings>.Instance.EnableDynamicEvents)
		{
			return;
		}
		CampaignTime val = CampaignTime.Now - _lastGenerationTime;
		double toDays = (val).ToDays;
		if (toDays >= (double)GlobalSettings<ModSettings>.Instance.DynamicEventsInterval)
		{
			int maxSimultaneousDynamicEvents = GlobalSettings<ModSettings>.Instance.MaxSimultaneousDynamicEvents;
			int num = _activeEvents.Count((DynamicEvent e) => e.AllowsDiplomaticResponse && e.RequiresDiplomaticAnalysis);
			if (num >= maxSimultaneousDynamicEvents)
			{
				DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Skipping automatic generation: Events awaiting diplomatic response ({num}) reached limit ({maxSimultaneousDynamicEvents})");
				return;
			}
			List<DynamicEvent> activeDiplomaticEvents = DiplomacyManager.Instance.GetActiveDiplomaticEvents();
			int count = activeDiplomaticEvents.Count;
			if (count >= maxSimultaneousDynamicEvents)
			{
				string arg = string.Join(", ", activeDiplomaticEvents.Select((DynamicEvent e) => $"{e.Id}(type={e.Type},rounds={e.DiplomaticRounds})"));
				DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Skipping automatic generation: Active diplomatic negotiations ({count}) reached limit ({maxSimultaneousDynamicEvents}). Blocking events: [{arg}]");
				return;
			}
			if (_activeEvents.Count >= maxSimultaneousDynamicEvents)
			{
				DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Warning: Total active events {_activeEvents.Count}/{maxSimultaneousDynamicEvents}, but continuing because limit applies only to diplomatic-response events.");
			}
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Time to generate events. Days since last: {toDays:F1}");
			if (_generationInProgress)
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Generation already in progress – skipping.");
				return;
			}
			_generationInProgress = true;
			_lastGenerationTime = CampaignTime.Now;
			_generator.GenerateEvents().ContinueWith(delegate
			{
				_generationInProgress = false;
			});
		}
		RemoveExpiredEvents();
	}

	public void ResetGenerationTimer()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		_lastGenerationTime = CampaignTime.Now;
		DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Generation timer reset");
	}

	public void ScheduleGenerationForNextDay()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		float num = GlobalSettings<ModSettings>.Instance.DynamicEventsInterval;
		_lastGenerationTime = CampaignTime.Now - CampaignTime.Days(num - 1f);
		DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Scheduled generation for TOMORROW (1 day from now, instead of full {num}-day interval)");
	}

	public void AddEvent(DynamicEvent dynamicEvent)
	{
		if (dynamicEvent == null)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Attempted to add null event");
			return;
		}
		if (!string.IsNullOrEmpty(dynamicEvent.Id) && _activeEvents.Any((DynamicEvent e) => e.Id == dynamicEvent.Id))
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Duplicate event detected by ID, skipping: " + dynamicEvent.Id);
			return;
		}
		if (_activeEvents.Any((DynamicEvent e) => e.Description == dynamicEvent.Description))
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Duplicate event detected by description, skipping: " + dynamicEvent.Description.Substring(0, Math.Min(50, dynamicEvent.Description.Length)) + "...");
			return;
		}
		_activeEvents.Add(dynamicEvent);
		DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Added new event: " + dynamicEvent.Type + " - " + dynamicEvent.Description.Substring(0, Math.Min(50, dynamicEvent.Description.Length)) + "...");
		DynamicEventsLogger.Instance.LogEventCreated(dynamicEvent);
		_storage.SaveEvents(_activeEvents);
		DisplayEventNotification(dynamicEvent);
		DistributeEventToNPCs(dynamicEvent);
	}

	private void RemoveExpiredEvents()
	{
		List<DynamicEvent> list = _activeEvents.Where((DynamicEvent e) => e.IsExpired()).ToList();
		foreach (DynamicEvent item in list)
		{
			DynamicEventsLogger.Instance.LogEventExpired(item.Id, item.Description);
		}
		int num = _activeEvents.RemoveAll((DynamicEvent e) => e.IsExpired());
		List<string> expiredEventIds = list.Select((DynamicEvent e) => e.Id).ToList();
		try
		{
			DiplomacyStorage diplomacyStorage = new DiplomacyStorage();
			List<DynamicEvent> list2 = diplomacyStorage.LoadDiplomaticEvents() ?? new List<DynamicEvent>();
			List<DynamicEvent> list3 = list2.Where((DynamicEvent e) => e != null && !string.IsNullOrEmpty(e.Id) && e.IsExpired()).ToList();
			foreach (DynamicEvent item2 in list3)
			{
				if (!expiredEventIds.Contains(item2.Id))
				{
					expiredEventIds.Add(item2.Id);
					DynamicEventsLogger.Instance.LogEventExpired(item2.Id, item2.Description);
				}
			}
			int count = list2.Count;
			list2.RemoveAll((DynamicEvent e) => e != null && !string.IsNullOrEmpty(e.Id) && expiredEventIds.Contains(e.Id));
			List<DynamicEvent> list4 = list2.Where((DynamicEvent e) => e != null && !string.IsNullOrEmpty(e.Id) && e.IsExpired()).ToList();
			if (list4.Any())
			{
				foreach (DynamicEvent item3 in list4)
				{
					if (!expiredEventIds.Contains(item3.Id))
					{
						expiredEventIds.Add(item3.Id);
						DynamicEventsLogger.Instance.LogEventExpired(item3.Id, item3.Description);
					}
				}
				list2.RemoveAll((DynamicEvent e) => e != null && !string.IsNullOrEmpty(e.Id) && e.IsExpired());
			}
			int num2 = count - list2.Count;
			if (num2 > 0 || list3.Any())
			{
				diplomacyStorage.SaveDiplomaticEvents(list2);
				if (num2 > 0)
				{
					DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Removed {num2} expired events from DiplomacyStorage");
				}
			}
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] ERROR checking expired events in DiplomacyStorage: " + ex.Message);
		}
		if (num <= 0 && !expiredEventIds.Any())
		{
			return;
		}
		if (num > 0)
		{
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Removed {num} expired events from active events");
			_storage.SaveEvents(_activeEvents);
		}
		RemoveExpiredEventsFromNPCs(expiredEventIds);
		try
		{
			DiplomaticStatementsStorage instance = DiplomaticStatementsStorage.Instance;
			if (instance != null)
			{
				int num3 = instance.RemoveStatementsByEventIds(expiredEventIds);
				if (num3 > 0)
				{
					DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Removed {num3} statements for {expiredEventIds.Count} expired events");
				}
			}
		}
		catch (Exception ex2)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] ERROR removing statements for expired events: " + ex2.Message);
		}
	}

	public List<DynamicEvent> GetActiveEvents()
	{
		return new List<DynamicEvent>(_activeEvents);
	}

	public List<DynamicEvent> GetAllEvents()
	{
		return GetActiveEvents();
	}

	public DynamicEvent GetEventById(string eventId)
	{
		return _activeEvents.FirstOrDefault((DynamicEvent e) => e.Id == eventId);
	}

	public void MarkDiplomaticEventAsCompleted(string eventId)
	{
		if (string.IsNullOrEmpty(eventId))
		{
			return;
		}
		DynamicEvent eventById = GetEventById(eventId);
		if (eventById != null)
		{
			eventById.RequiresDiplomaticAnalysis = false;
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Marked event " + eventId + " as completed (RequiresDiplomaticAnalysis = false)");
			_storage.SaveEvents(_activeEvents);
			return;
		}
		DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Event " + eventId + " not found in active events — updating storage file directly");
		try
		{
			List<DynamicEvent> list = _storage.LoadEvents();
			if (list != null)
			{
				DynamicEvent dynamicEvent = list.FirstOrDefault((DynamicEvent e) => e != null && e.Id == eventId);
				if (dynamicEvent != null)
				{
					dynamicEvent.RequiresDiplomaticAnalysis = false;
					_storage.SaveEvents(list);
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Updated event " + eventId + " in storage file (RequiresDiplomaticAnalysis = false)");
				}
				else
				{
					DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Event " + eventId + " not found in storage file either — already cleaned up");
				}
			}
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] WARNING: Failed to update event " + eventId + " in storage: " + ex.Message);
		}
	}

	public List<DynamicEvent> GetEventsForNPC(Hero npc)
	{
		if (npc == null)
		{
			return new List<DynamicEvent>();
		}
		AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
		NPCContext tempContext = null;
		if (instance != null)
		{
			Dictionary<string, NPCContext> nPCContexts = instance.GetNPCContexts();
			if (nPCContexts != null && nPCContexts.ContainsKey(((MBObjectBase)npc).StringId))
			{
				tempContext = nPCContexts[((MBObjectBase)npc).StringId];
			}
		}
		if (tempContext == null)
		{
			tempContext = new NPCContext
			{
				StringId = ((MBObjectBase)npc).StringId
			};
		}
		return (from e in _activeEvents
			where ShouldNPCKnowEvent(npc, tempContext, e)
			orderby e.Importance descending, e.DaysSinceCreation
			select e).ToList();
	}

	private void DisplayEventNotification(DynamicEvent dynamicEvent)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		if (dynamicEvent != null)
		{
			if (GlobalSettings<ModSettings>.Instance.DynamicEventsDialogueOnly)
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Skipping notification in dialogue-only mode: " + dynamicEvent.Description.Substring(0, Math.Min(50, dynamicEvent.Description.Length)) + "...");
				return;
			}
			Color val = default(Color);
			val = new Color(1f, 0.55f, 0f, 1f);
			string text = dynamicEvent.Description ?? "";
			InformationManager.DisplayMessage(new InformationMessage(text, val));
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Displayed notification: " + dynamicEvent.Description.Substring(0, Math.Min(50, dynamicEvent.Description.Length)) + "...");
		}
	}

	private void DistributeEventToNPCs(DynamicEvent dynamicEvent)
	{
		if (dynamicEvent == null)
		{
			return;
		}
		DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Distributing event to NPCs: " + dynamicEvent.Type);
		AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
		if (instance == null)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] AIInfluenceBehavior instance not found");
			return;
		}
		Dictionary<string, NPCContext> nPCContexts = instance.GetNPCContexts();
		if (nPCContexts == null || !nPCContexts.Any())
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] No NPC contexts found");
			return;
		}
		Dictionary<string, NPCContext> dictionary = new Dictionary<string, NPCContext>(nPCContexts);
		int num = 0;
		int num2 = 0;
		bool enableDetailedInfoLogging = GlobalSettings<ModSettings>.Instance.EnableDetailedInfoLogging;
		foreach (KeyValuePair<string, NPCContext> item in dictionary)
		{
			string key = item.Key;
			NPCContext context = item.Value;
			Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == context.StringId));
			if (val == null)
			{
				continue;
			}
			if (ShouldNPCKnowEvent(val, context, dynamicEvent))
			{
				if (context.DynamicEvents == null)
				{
					context.DynamicEvents = new List<string>();
				}
				if (!context.DynamicEvents.Contains(dynamicEvent.Id))
				{
					context.DynamicEvents.Add(dynamicEvent.Id);
					num++;
					instance.SaveNPCContext(key, val, context);
					if (enableDetailedInfoLogging)
					{
						DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_SPREAD] {val.Name} learned about event: {dynamicEvent.Description.Substring(0, Math.Min(50, dynamicEvent.Description.Length))}...");
					}
				}
			}
			else if (enableDetailedInfoLogging)
			{
				string reasonForNotKnowing = GetReasonForNotKnowing(val, context, dynamicEvent);
				DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_BLOCKED] {val.Name} did NOT learn: {reasonForNotKnowing}");
				num2++;
			}
		}
		if (enableDetailedInfoLogging)
		{
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_STATS] Distributed: {num} | Blocked: {num2}");
		}
		DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Distributed event to {num} NPCs");
		DynamicEventsLogger.Instance.LogEventDistribution(dynamicEvent.Id, num);
	}

	private bool ShouldNPCKnowEvent(Hero npc, NPCContext context, DynamicEvent dynamicEvent)
	{
		if (npc == null || context == null || dynamicEvent == null)
		{
			return false;
		}
		if (dynamicEvent.CharactersInvolved != null && dynamicEvent.CharactersInvolved.Any() && !string.IsNullOrEmpty(((MBObjectBase)npc).StringId))
		{
			if (dynamicEvent.CharactersInvolved.Contains(((MBObjectBase)npc).StringId))
			{
				DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_SPREAD] {npc.Name} ({((MBObjectBase)npc).StringId}) is DIRECTLY INVOLVED in event (CharactersInvolved)");
				return true;
			}
			if (npc.Clan != null && npc.Clan.Leader != null && !string.IsNullOrEmpty(((MBObjectBase)npc.Clan.Leader).StringId) && dynamicEvent.CharactersInvolved.Contains(((MBObjectBase)npc.Clan.Leader).StringId))
			{
				DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_SPREAD] {npc.Name} knows about event because CLAN LEADER {npc.Clan.Leader.Name} ({((MBObjectBase)npc.Clan.Leader).StringId}) is involved");
				return true;
			}
		}
		if (dynamicEvent.Importance >= 8)
		{
			return true;
		}
		if (dynamicEvent.KingdomsInvolved is string text && text == "all")
		{
			if (dynamicEvent.ApplicableNPCs != null && dynamicEvent.ApplicableNPCs.Any())
			{
				return IsApplicableNPC(npc, dynamicEvent.ApplicableNPCs);
			}
			return true;
		}
		Clan clan = npc.Clan;
		object obj;
		if (clan == null)
		{
			obj = null;
		}
		else
		{
			Kingdom kingdom = clan.Kingdom;
			obj = ((kingdom != null) ? ((MBObjectBase)kingdom).StringId : null);
		}
		if (obj == null)
		{
			IFaction mapFaction = npc.MapFaction;
			obj = ((mapFaction != null) ? mapFaction.StringId : null);
		}
		string text2 = (string)obj;
		bool flag = !string.IsNullOrEmpty(text2) && dynamicEvent.IsKingdomInvolved(text2);
		bool flag2 = false;
		if (string.IsNullOrEmpty(text2) && npc.CurrentSettlement != null)
		{
			Clan ownerClan = npc.CurrentSettlement.OwnerClan;
			object obj2;
			if (ownerClan == null)
			{
				obj2 = null;
			}
			else
			{
				Kingdom kingdom2 = ownerClan.Kingdom;
				obj2 = ((kingdom2 != null) ? ((MBObjectBase)kingdom2).StringId : null);
			}
			if (obj2 == null)
			{
				IFaction mapFaction2 = npc.CurrentSettlement.MapFaction;
				obj2 = ((mapFaction2 != null) ? mapFaction2.StringId : null);
			}
			string text3 = (string)obj2;
			if (!string.IsNullOrEmpty(text3) && dynamicEvent.IsKingdomInvolved(text3))
			{
				flag2 = true;
			}
		}
		if (flag || flag2)
		{
			if (dynamicEvent.ApplicableNPCs != null && dynamicEvent.ApplicableNPCs.Any())
			{
				return IsApplicableNPC(npc, dynamicEvent.ApplicableNPCs);
			}
			return true;
		}
		return false;
	}

	private bool IsApplicableNPC(Hero npc, List<string> applicableNPCs)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		if (applicableNPCs == null || !applicableNPCs.Any())
		{
			return true;
		}
		if (applicableNPCs.Contains("all"))
		{
			return true;
		}
		if (applicableNPCs.Contains("lords") && (int)npc.Occupation == 3)
		{
			return true;
		}
		if (applicableNPCs.Contains("companions") && npc.IsWanderer)
		{
			return true;
		}
		if (applicableNPCs.Contains("faction_leaders"))
		{
			Clan clan = npc.Clan;
			object obj;
			if (clan == null)
			{
				obj = null;
			}
			else
			{
				IFaction mapFaction = clan.MapFaction;
				obj = ((mapFaction != null) ? mapFaction.Leader : null);
			}
			if (npc == obj)
			{
				return true;
			}
		}
		if (applicableNPCs.Contains("village_notables") && npc.IsNotable)
		{
			Settlement currentSettlement = npc.CurrentSettlement;
			if (currentSettlement != null && currentSettlement.IsVillage)
			{
				return true;
			}
		}
		if (applicableNPCs.Contains("merchants") && npc.IsMerchant)
		{
			return true;
		}
		if (!string.IsNullOrEmpty(((MBObjectBase)npc).StringId) && applicableNPCs.Contains(((MBObjectBase)npc).StringId))
		{
			return true;
		}
		return false;
	}

	private string GetReasonForNotKnowing(Hero npc, NPCContext context, DynamicEvent dynamicEvent)
	{
		if (dynamicEvent.CharactersInvolved != null && dynamicEvent.CharactersInvolved.Any() && !string.IsNullOrEmpty(((MBObjectBase)npc).StringId))
		{
			if (dynamicEvent.CharactersInvolved.Contains(((MBObjectBase)npc).StringId))
			{
				return "directly involved in event (CharactersInvolved) - should know!";
			}
			if (npc.Clan != null && npc.Clan.Leader != null && !string.IsNullOrEmpty(((MBObjectBase)npc.Clan.Leader).StringId) && dynamicEvent.CharactersInvolved.Contains(((MBObjectBase)npc.Clan.Leader).StringId))
			{
				return $"clan leader {npc.Clan.Leader.Name} is involved - should know!";
			}
		}
		if (dynamicEvent.Importance >= 8)
		{
			return "high importance (>=8) - should know!";
		}
		if (dynamicEvent.KingdomsInvolved is string text && text == "all")
		{
			if (dynamicEvent.ApplicableNPCs != null && dynamicEvent.ApplicableNPCs.Any())
			{
				if (!IsApplicableNPC(npc, dynamicEvent.ApplicableNPCs))
				{
					return "global event but does not match applicable_npcs: [" + string.Join(", ", dynamicEvent.ApplicableNPCs) + "]";
				}
				return "global event - should know!";
			}
			return "global event - should know!";
		}
		Clan clan = npc.Clan;
		object obj;
		if (clan == null)
		{
			obj = null;
		}
		else
		{
			Kingdom kingdom = clan.Kingdom;
			obj = ((kingdom != null) ? ((MBObjectBase)kingdom).StringId : null);
		}
		if (obj == null)
		{
			IFaction mapFaction = npc.MapFaction;
			obj = ((mapFaction != null) ? mapFaction.StringId : null);
		}
		string text2 = (string)obj;
		bool flag = !string.IsNullOrEmpty(text2) && dynamicEvent.IsKingdomInvolved(text2);
		bool flag2 = false;
		if (string.IsNullOrEmpty(text2) && npc.CurrentSettlement != null)
		{
			Clan ownerClan = npc.CurrentSettlement.OwnerClan;
			object obj2;
			if (ownerClan == null)
			{
				obj2 = null;
			}
			else
			{
				Kingdom kingdom2 = ownerClan.Kingdom;
				obj2 = ((kingdom2 != null) ? ((MBObjectBase)kingdom2).StringId : null);
			}
			if (obj2 == null)
			{
				IFaction mapFaction2 = npc.CurrentSettlement.MapFaction;
				obj2 = ((mapFaction2 != null) ? mapFaction2.StringId : null);
			}
			string text3 = (string)obj2;
			if (!string.IsNullOrEmpty(text3) && dynamicEvent.IsKingdomInvolved(text3))
			{
				flag2 = true;
			}
		}
		if (flag || flag2)
		{
			if (dynamicEvent.ApplicableNPCs != null && dynamicEvent.ApplicableNPCs.Any())
			{
				if (!IsApplicableNPC(npc, dynamicEvent.ApplicableNPCs))
				{
					return "from involved kingdom but does not match applicable_npcs: [" + string.Join(", ", dynamicEvent.ApplicableNPCs) + "]";
				}
				return "from involved kingdom - should know!";
			}
			return "from involved kingdom - should know!";
		}
		string text4 = ((npc.CurrentSettlement != null) ? $" (in {npc.CurrentSettlement.Name})" : "");
		return "not from involved kingdom (npc kingdom: " + (text2 ?? "none") + text4 + ", event kingdoms: " + GetKingdomsInvolvedString(dynamicEvent) + ")";
	}

	private string GetKingdomsInvolvedString(DynamicEvent dynamicEvent)
	{
		if (dynamicEvent.KingdomsInvolved == null)
		{
			return "null";
		}
		if (dynamicEvent.KingdomsInvolved is string result)
		{
			return result;
		}
		List<string> kingdomStringIds = dynamicEvent.GetKingdomStringIds();
		return (kingdomStringIds != null && kingdomStringIds.Any()) ? string.Join(", ", kingdomStringIds) : "none";
	}

	public void ClearAllEvents()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Starting complete cleanup of all dynamic events...");
			List<string> eventIds = _activeEvents.Select((DynamicEvent e) => e.Id).ToList();
			int count = _activeEvents.Count;
			_activeEvents.Clear();
			_storage.SaveEvents(_activeEvents);
			RemoveEventsFromAllNPCs(eventIds);
			_lastGenerationTime = CampaignTime.Now;
			_generationInProgress = false;
			_isGeneratingManually = false;
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Complete cleanup finished: {count} events cleared, all NPC references removed, timers reset");
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] ERROR during complete cleanup: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	public static void Reset()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		if (_instance != null)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Resetting manager state for new session");
			_instance._activeEvents.Clear();
			_instance._generationInProgress = false;
			_instance._isGeneratingManually = false;
			_instance._initialized = false;
			_instance._lastGenerationTime = CampaignTime.Now;
			_instance = null;
		}
	}

	public void SaveActiveEvents()
	{
		_storage.SaveEvents(_activeEvents);
		DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Saved {_activeEvents.Count} active events to storage");
	}

	public async Task GenerateEventsManually()
	{
		if (_isGeneratingManually)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Manual generation already in progress, ignoring duplicate request");
			return;
		}
		int maxEvents = GlobalSettings<ModSettings>.Instance.MaxSimultaneousDynamicEvents;
		List<DynamicEvent> activeDiplomaticEvents = _activeEvents.Where((DynamicEvent e) => e.AllowsDiplomaticResponse && e.RequiresDiplomaticAnalysis).ToList();
		if (activeDiplomaticEvents.Count >= maxEvents)
		{
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Cannot generate new event: Events awaiting diplomatic response ({activeDiplomaticEvents.Count}) reached limit ({maxEvents})");
			string.Join(", ", activeDiplomaticEvents.Select((DynamicEvent e) => e.Type));
			return;
		}
		List<DynamicEvent> activeDiplomaticEventsManual = DiplomacyManager.Instance.GetActiveDiplomaticEvents();
		int activeDiplomaticEventsCount = activeDiplomaticEventsManual.Count;
		if (activeDiplomaticEventsCount >= maxEvents)
		{
			string blockingIds = string.Join(", ", activeDiplomaticEventsManual.Select((DynamicEvent e) => $"{e.Id}(type={e.Type},rounds={e.DiplomaticRounds})"));
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Cannot generate new event: Active diplomatic negotiations ({activeDiplomaticEventsCount}) reached limit ({maxEvents}). Blocking events: [{blockingIds}]");
			InformationManager.DisplayMessage(new InformationMessage($"Cannot generate event: Limit of {maxEvents} active diplomatic negotiation(s) reached.", new Color(1f, 0f, 0f, 1f)));
			return;
		}
		if (_activeEvents.Count >= maxEvents)
		{
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Warning: Total active events {_activeEvents.Count}/{maxEvents}, but continuing manual generation (limit applies only to diplomatic-response events).");
		}
		_isGeneratingManually = true;
		try
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Manual event generation triggered");
			await _generator.GenerateEvents();
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Manual generation completed");
		}
		finally
		{
			_isGeneratingManually = false;
		}
	}

	private void RemoveExpiredEventsFromNPCs(List<string> expiredEventIds)
	{
		if (expiredEventIds == null || !expiredEventIds.Any())
		{
			return;
		}
		AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
		if (instance == null)
		{
			return;
		}
		Dictionary<string, NPCContext> nPCContexts = instance.GetNPCContexts();
		if (nPCContexts == null || !nPCContexts.Any())
		{
			return;
		}
		Dictionary<string, NPCContext> dictionary = new Dictionary<string, NPCContext>(nPCContexts);
		int num = 0;
		foreach (KeyValuePair<string, NPCContext> item in dictionary)
		{
			NPCContext context = item.Value;
			if (context.DynamicEvents == null || !context.DynamicEvents.Any())
			{
				continue;
			}
			int count = context.DynamicEvents.Count;
			context.RemoveExpiredEvents(expiredEventIds);
			int count2 = context.DynamicEvents.Count;
			if (count != count2)
			{
				num++;
				Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == context.StringId));
				if (val != null)
				{
					instance.SaveNPCContext(item.Key, val, context);
				}
			}
		}
		if (num > 0)
		{
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Removed expired events from {num} NPCs");
		}
	}

	private void RemoveEventsFromAllNPCs(List<string> eventIds)
	{
		try
		{
			AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
			if (instance == null)
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] AIInfluenceBehavior instance not found - cannot clear events from NPCs");
				return;
			}
			int num = 0;
			int num2 = 0;
			Dictionary<string, NPCContext> nPCContexts = instance.GetNPCContexts();
			if (nPCContexts != null && nPCContexts.Any())
			{
				List<NPCContext> list = nPCContexts.Values.ToList();
				foreach (NPCContext item in list)
				{
					if (item.DynamicEvents != null && item.DynamicEvents.Count > 0)
					{
						num2 += item.DynamicEvents.Count;
						item.DynamicEvents.Clear();
						num++;
					}
				}
			}
			string activeSaveDirectory = instance.GetActiveSaveDirectory();
			if (!string.IsNullOrEmpty(activeSaveDirectory) && nPCContexts != null)
			{
				List<string> list2 = nPCContexts.Keys.ToList();
				foreach (string item2 in list2)
				{
					string text = instance.FindNPCFileByStringId(activeSaveDirectory, item2);
					if (string.IsNullOrEmpty(text) || !File.Exists(text))
					{
						continue;
					}
					try
					{
						string text2 = File.ReadAllText(text);
						NPCContext nPCContext = JsonConvert.DeserializeObject<NPCContext>(text2);
						if (nPCContext.DynamicEvents != null && nPCContext.DynamicEvents.Count > 0)
						{
							nPCContext.DynamicEvents.Clear();
							string contents = JsonConvert.SerializeObject((object)nPCContext, (Formatting)1);
							File.WriteAllText(text, contents);
						}
					}
					catch (Exception ex)
					{
						DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] ERROR clearing events for " + item2 + ": " + ex.Message);
					}
				}
			}
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Cleared {num2} DynamicEvents from {num} NPCs");
		}
		catch (Exception ex2)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] ERROR in RemoveEventsFromAllNPCs: " + ex2.Message);
		}
	}
}
