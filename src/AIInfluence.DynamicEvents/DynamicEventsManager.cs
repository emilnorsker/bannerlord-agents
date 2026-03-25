using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AIInfluence;
using AIInfluence.Diplomacy;
using AIInfluence.Services;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.DynamicEvents;

public class DynamicEventsManager
{
	/// <summary>
	/// When a <see cref="DynamicEvent"/>'s importance is &gt;= this value, all NPCs are treated as knowing the event (legacy spread rule).
	/// Set to <c>11</c> to disable this shortcut (only kingdom / character / applicable_npc rules apply).
	/// </summary>
	private const int GlobalRumorImportanceThresholdInclusive = 8;

	private static DynamicEventsManager _instance;

	private UnifiedDynamicEventsEnvelope _eventEnvelope;

	private readonly DynamicEventsStorage _storage;

	private readonly DynamicEventsGenerator _generator;

	private CampaignTime _lastGenerationTime;

	private bool _isGeneratingManually = false;

	private bool _generationInProgress = false;

	private bool _initialized = false;

	private List<DynamicEvent> EventsList
	{
		get
		{
			if (_eventEnvelope == null)
			{
				_eventEnvelope = new UnifiedDynamicEventsEnvelope
				{
					Events = new List<DynamicEvent>()
				};
			}
			if (_eventEnvelope.Events == null)
			{
				_eventEnvelope.Events = new List<DynamicEvent>();
			}
			return _eventEnvelope.Events;
		}
	}

	private void PersistCatalog()
	{
		if (!_storage.SaveUnifiedEnvelope(_eventEnvelope))
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] ERROR: SaveUnifiedEnvelope failed — disk catalog may be stale vs memory");
		}
	}

	private static void EnsureDynamicStorageTag(DynamicEvent e)
	{
		if (e == null)
		{
			return;
		}
		if (e.StorageTags == null)
		{
			e.StorageTags = new List<string>();
		}
		if (!e.StorageTags.Contains(DynamicEventStorageTags.Dynamic))
		{
			e.StorageTags.Add(DynamicEventStorageTags.Dynamic);
		}
	}

	public void SaveDiplomaticSlice(List<DynamicEvent> diplomaticEvents, Dictionary<string, CampaignTime> statementSchedules, Dictionary<string, CampaignTime> analysisSchedules, Dictionary<string, Queue<(Kingdom kingdom, CampaignTime scheduledTime)>> statementQueues, Dictionary<string, Kingdom> pendingStatements)
	{
		_storage.SaveDiplomaticSliceInto(_eventEnvelope, diplomaticEvents, statementSchedules, analysisSchedules, statementQueues, pendingStatements);
	}

	public UnifiedDynamicEventsEnvelope GetUnifiedEnvelope()
	{
		return _eventEnvelope;
	}

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
		_eventEnvelope = new UnifiedDynamicEventsEnvelope();
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
		_eventEnvelope = _storage.LoadUnifiedEnvelope();
		if (_eventEnvelope.Events == null)
		{
			_eventEnvelope.Events = new List<DynamicEvent>();
		}
		DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Loaded {_eventEnvelope.Events.Count} events from unified storage");
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
			int num = EventsList.Count((DynamicEvent e) => e.AllowsDiplomaticResponse && e.RequiresDiplomaticAnalysis);
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
			int dynamicTaggedCount = EventsList.Count((DynamicEvent e) => e != null && e.StorageTags != null && e.StorageTags.Contains(DynamicEventStorageTags.Dynamic));
			if (dynamicTaggedCount >= maxSimultaneousDynamicEvents)
			{
				DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Warning: Dynamic-tagged active events {dynamicTaggedCount}/{maxSimultaneousDynamicEvents}, but continuing because limit applies only to diplomatic-response events.");
			}
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Time to generate events. Days since last: {toDays:F1}");
			if (_generationInProgress)
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Generation already in progress – skipping.");
				return;
			}
			_generationInProgress = true;
			_lastGenerationTime = CampaignTime.Now;
			_generator.GenerateEvents().ContinueWith(delegate(Task t)
			{
				MainThreadDispatcher.Queue.Enqueue(delegate
				{
					_generationInProgress = false;
					if (t.IsFaulted && t.Exception != null)
					{
						DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] GenerateEvents faulted: " + t.Exception.GetBaseException().Message);
					}
				});
			}, TaskScheduler.Default);
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
		if (string.IsNullOrEmpty(dynamicEvent.Id))
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Rejected event with null or empty Id (cannot persist in unified catalog)");
			return;
		}
		if (EventsList.Any((DynamicEvent e) => e.Id == dynamicEvent.Id))
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Duplicate event detected by ID, skipping: " + dynamicEvent.Id);
			return;
		}
		string description = dynamicEvent.Description ?? "";
		if (EventsList.Any((DynamicEvent e) => string.Equals(e.Description ?? "", description, StringComparison.Ordinal)))
		{
			string descPreview = description.Length <= 50 ? description : description.Substring(0, 50) + "...";
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Duplicate event detected by description, skipping: " + descPreview);
			return;
		}
		EnsureDynamicStorageTag(dynamicEvent);
		EventsList.Add(dynamicEvent);
		string addedDescPreview = description.Length <= 50 ? description : description.Substring(0, 50) + "...";
		DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Added new event: " + dynamicEvent.Type + " - " + addedDescPreview);
		DynamicEventsLogger.Instance.LogEventCreated(dynamicEvent);
		PersistCatalog();
		DisplayEventNotification(dynamicEvent);
		DistributeEventToNPCs(dynamicEvent);
	}

	private void RemoveExpiredEvents()
	{
		List<DynamicEvent> list = EventsList.Where((DynamicEvent e) => e.IsExpired()).ToList();
		foreach (DynamicEvent item in list)
		{
			DynamicEventsLogger.Instance.LogEventExpired(item.Id, item.Description);
		}
		int num = EventsList.RemoveAll((DynamicEvent e) => e.IsExpired());
		List<string> expiredEventIds = list.Select((DynamicEvent e) => e.Id).ToList();
		if (num <= 0 && !expiredEventIds.Any())
		{
			return;
		}
		if (num > 0)
		{
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Removed {num} expired events from catalog");
			PersistCatalog();
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
		return BuildMergedActiveEvents();
	}

	public List<DynamicEvent> GetAllEvents()
	{
		return GetActiveEvents();
	}

	private List<DynamicEvent> BuildMergedActiveEvents()
	{
		return new List<DynamicEvent>(EventsList);
	}

	public DynamicEvent GetEventById(string eventId)
	{
		return EventsList.FirstOrDefault((DynamicEvent e) => e.Id == eventId);
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
			PersistCatalog();
			return;
		}
		DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Event " + eventId + " not found in catalog — scanning envelope");
		try
		{
			DynamicEvent dynamicEvent = EventsList.FirstOrDefault((DynamicEvent e) => e != null && e.Id == eventId);
			if (dynamicEvent != null)
			{
				dynamicEvent.RequiresDiplomaticAnalysis = false;
				PersistCatalog();
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Updated event " + eventId + " in unified storage (RequiresDiplomaticAnalysis = false)");
			}
			else
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Event " + eventId + " not in catalog — already cleaned up");
			}
		}
		catch (Exception ex)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] WARNING: Failed to update event " + eventId + " in storage: " + ex.Message);
		}
	}

	/// <summary>
	/// Returns catalog events this NPC is treated as knowing, after syncing <see cref="NPCContext.DynamicEvents"/>.
	/// </summary>
	/// <param name="syncIntoContext">Required. Must be the canonical context for this hero (same reference as <see cref="AIInfluenceBehavior.GetNPCContexts"/> when registered).</param>
	public List<DynamicEvent> GetEventsForNPC(Hero npc, NPCContext syncIntoContext, bool persistKnowledgeSync = true)
	{
		if (npc == null)
		{
			return new List<DynamicEvent>();
		}
		if (syncIntoContext == null)
		{
			throw new ArgumentNullException(nameof(syncIntoContext));
		}
		string npcKey = ((MBObjectBase)npc).StringId;
		if (string.IsNullOrEmpty(npcKey))
		{
			throw new ArgumentException("Hero has empty StringId.", nameof(npc));
		}
		if (!string.Equals(syncIntoContext.StringId, npcKey, StringComparison.Ordinal))
		{
			throw new ArgumentException("syncIntoContext.StringId must match hero.StringId (got '" + syncIntoContext.StringId + "', expected '" + npcKey + "').", nameof(syncIntoContext));
		}
		AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
		if (instance != null)
		{
			Dictionary<string, NPCContext> nPCContexts = instance.GetNPCContexts();
			if (nPCContexts != null && nPCContexts.TryGetValue(npcKey, out NPCContext registered) && !ReferenceEquals(registered, syncIntoContext))
			{
				throw new InvalidOperationException("syncIntoContext is not the registered NPCContext for '" + npcKey + "'. Use AIInfluenceBehavior.GetOrCreateNPCContext(hero) so prompts, UI, and disk stay aligned.");
			}
		}
		List<DynamicEvent> catalog = BuildMergedActiveEvents();
		SyncNpcDynamicEventKnowledge(npc, syncIntoContext, instance, npcKey, persistKnowledgeSync, catalog);
		HashSet<string> knownIds = (syncIntoContext.DynamicEvents != null && syncIntoContext.DynamicEvents.Any()) ? new HashSet<string>(syncIntoContext.DynamicEvents) : new HashSet<string>();
		return (from e in catalog
			where e != null && !string.IsNullOrEmpty(e.Id) && !e.IsExpired() && knownIds.Contains(e.Id)
			orderby e.Importance descending, e.DaysSinceCreation
			select e).ToList();
	}

	/// <summary>Mutates <paramref name="context"/> only; callers must pass the canonical instance (same as <see cref="GetEventsForNPC"/>). Not public so the registered-context check cannot be bypassed.</summary>
	private void SyncNpcDynamicEventKnowledge(Hero npc, NPCContext context, AIInfluenceBehavior behavior, string npcContextKey, bool persist = true, List<DynamicEvent> catalog = null)
	{
		if (npc == null || context == null || string.IsNullOrEmpty(npcContextKey))
		{
			return;
		}
		string heroKey = ((MBObjectBase)npc).StringId;
		if (string.Equals(npcContextKey, heroKey, StringComparison.Ordinal) && behavior != null)
		{
			Dictionary<string, NPCContext> registeredContexts = behavior.GetNPCContexts();
			if (registeredContexts != null && registeredContexts.TryGetValue(heroKey, out NPCContext registered) && !ReferenceEquals(registered, context))
			{
				throw new InvalidOperationException("context is not the registered NPCContext for '" + heroKey + "'. Use AIInfluenceBehavior.GetOrCreateNPCContext(hero).");
			}
		}
		List<DynamicEvent> merged = catalog ?? BuildMergedActiveEvents();
		HashSet<string> mergedIds = new HashSet<string>(from e in merged
			where e != null && !string.IsNullOrEmpty(e.Id)
			select e.Id);
		bool flag = false;
		if (context.DynamicEvents != null && context.DynamicEvents.Any())
		{
			int count = context.DynamicEvents.Count;
			context.DynamicEvents.RemoveAll((string id) => !mergedIds.Contains(id));
			if (context.DynamicEvents.Count != count)
			{
				flag = true;
			}
		}
		foreach (DynamicEvent dynamicEvent in merged)
		{
			if (dynamicEvent == null || string.IsNullOrEmpty(dynamicEvent.Id) || dynamicEvent.IsExpired())
			{
				continue;
			}
			if (!ShouldNPCKnowEvent(npc, context, dynamicEvent))
			{
				continue;
			}
			int count2 = context.DynamicEvents?.Count ?? 0;
			context.AddDynamicEvent(dynamicEvent.Id);
			if (context.DynamicEvents != null && context.DynamicEvents.Count != count2)
			{
				flag = true;
			}
		}
		if (flag && persist && behavior != null)
		{
			behavior.SaveNPCContext(npcContextKey, npc, context);
		}
	}

	private void DisplayEventNotification(DynamicEvent dynamicEvent)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		if (dynamicEvent != null)
		{
			string notificationDescription = dynamicEvent.Description ?? "";
			string notificationPreview = notificationDescription.Length <= 50 ? notificationDescription : notificationDescription.Substring(0, 50) + "...";
			if (GlobalSettings<ModSettings>.Instance.DynamicEventsDialogueOnly)
			{
				DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Skipping notification in dialogue-only mode: " + notificationPreview);
				return;
			}
			Color val = default(Color);
			val = new Color(1f, 0.55f, 0f, 1f);
			InformationManager.DisplayMessage(new InformationMessage(notificationDescription, val));
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Displayed notification: " + notificationPreview);
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
						string spreadDesc = dynamicEvent.Description ?? "";
						string spreadPreview = spreadDesc.Length <= 50 ? spreadDesc : spreadDesc.Substring(0, 50) + "...";
						DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS_SPREAD] {val.Name} learned about event: {spreadPreview}");
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

	public bool ShouldNPCKnowEvent(Hero npc, NPCContext context, DynamicEvent dynamicEvent)
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
		if (GlobalRumorImportanceThresholdInclusive <= 10 && dynamicEvent.Importance >= GlobalRumorImportanceThresholdInclusive)
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
		if (GlobalRumorImportanceThresholdInclusive <= 10 && dynamicEvent.Importance >= GlobalRumorImportanceThresholdInclusive)
		{
			return "high importance (>=" + GlobalRumorImportanceThresholdInclusive + ") - should know!";
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
			List<string> eventIds = EventsList.Select((DynamicEvent e) => e.Id).ToList();
			int count = EventsList.Count;
			EventsList.Clear();
			if (_eventEnvelope != null)
			{
				_eventEnvelope.StatementSchedules = null;
				_eventEnvelope.AnalysisSchedules = null;
				_eventEnvelope.StatementQueues = null;
				_eventEnvelope.PendingStatements = null;
			}
			PersistCatalog();
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
			if (_instance._eventEnvelope?.Events != null)
			{
				_instance._eventEnvelope.Events.Clear();
			}
			_instance._generationInProgress = false;
			_instance._isGeneratingManually = false;
			_instance._initialized = false;
			_instance._lastGenerationTime = CampaignTime.Now;
			_instance = null;
		}
	}

	public void SaveActiveEvents()
	{
		PersistCatalog();
		DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Saved {EventsList.Count} events to unified storage");
	}

	public async Task GenerateEventsManually()
	{
		if (_isGeneratingManually)
		{
			DynamicEventsLogger.Instance.Log("[DYNAMIC_EVENTS] Manual generation already in progress, ignoring duplicate request");
			return;
		}
		int maxEvents = GlobalSettings<ModSettings>.Instance.MaxSimultaneousDynamicEvents;
		List<DynamicEvent> activeDiplomaticEvents = EventsList.Where((DynamicEvent e) => e.AllowsDiplomaticResponse && e.RequiresDiplomaticAnalysis).ToList();
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
		int dynamicTaggedCountManual = EventsList.Count((DynamicEvent e) => e != null && e.StorageTags != null && e.StorageTags.Contains(DynamicEventStorageTags.Dynamic));
		if (dynamicTaggedCountManual >= maxEvents)
		{
			DynamicEventsLogger.Instance.Log($"[DYNAMIC_EVENTS] Warning: Dynamic-tagged active events {dynamicTaggedCountManual}/{maxEvents}, but continuing manual generation (limit applies only to diplomatic-response events).");
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
