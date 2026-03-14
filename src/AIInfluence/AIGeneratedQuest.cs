using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;

namespace AIInfluence;

public class AIGeneratedQuest : QuestBase
{
	[SaveableField(1)]
	private string _title;

	[SaveableField(2)]
	private string _description;

	[SaveableField(3)]
	private string _npcStringId;

	[SaveableField(4)]
	private string _targetNpcId;

	[SaveableField(5)]
	private int _rewardGold;

	[SaveableField(6)]
	private string _targetNpcIdsCsv;

	[SaveableField(7)]
	private string _aiVerificationNotes;

	[SaveableField(8)]
	private string _completerNpcId;

	[SaveableField(9)]
	private int _progressTarget;

	[SaveableField(10)]
	private string _progressLabel;

	private JournalLog _discreteLog;

	[SaveableField(11)]
	private bool _pendingFailDueToDeadGiver;

	public override TextObject Title => new TextObject(_title, (Dictionary<string, object>)null);

	public string QuestDescription => _description;

	public string NpcStringId => _npcStringId ?? "";

	public string TargetNpcId => _targetNpcId ?? "";

	public int RewardGoldAmount => _rewardGold;

	public string AIVerificationNotes => _aiVerificationNotes ?? "";

	public string CompleterNpcId => _completerNpcId ?? "";

	public int ProgressTargetValue => _progressTarget;

	public string ProgressLabel => _progressLabel ?? "";

	public List<string> TargetNpcIds
	{
		get
		{
			if (string.IsNullOrEmpty(_targetNpcIdsCsv))
			{
				if (!string.IsNullOrEmpty(_targetNpcId))
				{
					return new List<string> { _targetNpcId };
				}
				return new List<string>();
			}
			return (from s in _targetNpcIdsCsv.Split(new char[1] { ',' })
				where !string.IsNullOrEmpty(s)
				select s).ToList();
		}
	}

	public override bool IsRemainingTimeHidden => false;

	public bool PendingFailDueToDeadGiver => _pendingFailDueToDeadGiver;

	private static void EarlyLog(string message)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string fullPath = Path.GetFullPath(Path.Combine(directoryName, "..", ".."));
			string path = Path.Combine(fullPath, "logs", "mod_log.txt");
			string directoryName2 = Path.GetDirectoryName(path);
			if (!Directory.Exists(directoryName2))
			{
				Directory.CreateDirectory(directoryName2);
			}
			File.AppendAllText(path, $"[{DateTime.Now:HH:mm:ss.fff}] {message}{Environment.NewLine}");
		}
		catch
		{
		}
	}

	public AIGeneratedQuest(string questId, Hero questGiver, CampaignTime duration, int rewardGold, string title, string description, List<string> targetNpcIds = null, string aiVerificationNotes = "", string completerNpcId = "", int progressTarget = 0, string progressLabel = "")
		: base(questId, questGiver, duration, 0)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_010e: Expected O, but got Unknown
		_title = title;
		_description = description;
		_npcStringId = ((questGiver != null) ? ((MBObjectBase)questGiver).StringId : null) ?? "";
		_rewardGold = rewardGold;
		_aiVerificationNotes = aiVerificationNotes ?? "";
		_completerNpcId = completerNpcId ?? "";
		_progressTarget = progressTarget;
		_progressLabel = progressLabel ?? "";
		if (targetNpcIds != null && targetNpcIds.Count > 0)
		{
			_targetNpcIdsCsv = string.Join(",", targetNpcIds);
			_targetNpcId = targetNpcIds[0];
		}
		else
		{
			_targetNpcIdsCsv = "";
			_targetNpcId = "";
		}
		((QuestBase)this).AddLog(new TextObject(description, (Dictionary<string, object>)null), false);
		if (progressTarget > 0 && !string.IsNullOrEmpty(progressLabel))
		{
			_discreteLog = ((QuestBase)this).AddDiscreteLog(new TextObject(progressLabel, (Dictionary<string, object>)null), new TextObject(progressLabel, (Dictionary<string, object>)null), 0, progressTarget, (TextObject)null, false);
		}
		((QuestBase)this).InitializeQuestOnCreation();
		((QuestBase)this).StartQuest();
	}

	public void AddUpdateLog(string message)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		((QuestBase)this).AddLog(new TextObject(message, (Dictionary<string, object>)null), false);
	}

	public void SetDiscreteProgress(int currentProgress)
	{
		if (_discreteLog != null && _progressTarget > 0)
		{
			((QuestBase)this).UpdateQuestTaskStage(_discreteLog, Math.Min(currentProgress, _progressTarget));
		}
	}

	public AIQuestInfo ToQuestInfo()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		double num = EstimateCreatedDaysFromId();
		CampaignTime questDueTime = ((QuestBase)this).QuestDueTime;
		int durationDays = (int)Math.Max(7.0, (questDueTime).ToDays - num);
		AIQuestInfo obj = new AIQuestInfo
		{
			QuestId = ((MBObjectBase)this).StringId,
			Title = (_title ?? "Unknown Quest"),
			Description = (_description ?? ""),
			RewardGold = _rewardGold,
			CreatedDays = num,
			DurationDays = durationDays
		};
		object obj2 = _npcStringId;
		if (obj2 == null)
		{
			Hero questGiver = ((QuestBase)this).QuestGiver;
			obj2 = ((questGiver != null) ? ((MBObjectBase)questGiver).StringId : null) ?? "";
		}
		obj.QuestGiverNpcId = (string)obj2;
		obj.TargetNpcId = _targetNpcId ?? "";
		obj.TargetNpcIds = TargetNpcIds;
		obj.AIVerificationNotes = _aiVerificationNotes ?? "";
		obj.CompleterNpcId = _completerNpcId ?? "";
		obj.ProgressTarget = _progressTarget;
		obj.ProgressLabel = _progressLabel ?? "";
		return obj;
	}

	private double EstimateCreatedDaysFromId()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime now;
		if (string.IsNullOrEmpty(((MBObjectBase)this).StringId))
		{
			now = CampaignTime.Now;
			return (now).ToDays;
		}
		string[] array = ((MBObjectBase)this).StringId.Split(new char[1] { '_' });
		if (array.Length >= 2 && int.TryParse(array[^2], out var result))
		{
			return result;
		}
		now = CampaignTime.Now;
		return (now).ToDays;
	}

	protected override void SetDialogs()
	{
	}

	protected override void InitializeQuestOnGameLoad()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			CampaignTime questDueTime = ((QuestBase)this).QuestDueTime;
			CampaignTime now = CampaignTime.Now;
			double num = (questDueTime).RemainingDaysFromNow;
			Hero questGiver = ((QuestBase)this).QuestGiver;
			bool flag = questGiver != null && !questGiver.IsDead;
			string message = $"[QUEST_LOAD] AIGeneratedQuest '{((MBObjectBase)this).StringId}' loaded. DueTime={(questDueTime).ToDays:F0}, Now={(now).ToDays:F0}, RemainingDays={num:F1}, QuestGiver valid={flag}";
			EarlyLog(message);
			AIInfluenceBehavior.Instance?.LogMessage(message);
			if (!flag)
			{
				_pendingFailDueToDeadGiver = true;
				string message2 = "[QUEST_LOAD] Quest '" + ((MBObjectBase)this).StringId + "' has dead/null giver — marked for deferred failure (SyncQuestsWithGameState will clean up)";
				EarlyLog(message2);
				AIInfluenceBehavior.Instance?.LogMessage(message2);
			}
			if (num < 0.0)
			{
				string message3 = "[QUEST_LOAD] WARNING: Quest '" + ((MBObjectBase)this).StringId + "' DueTime already passed! Extending by 7 days to prevent false fail.";
				EarlyLog(message3);
				AIInfluenceBehavior.Instance?.LogMessage(message3);
				((QuestBase)this).ChangeQuestDueTime(CampaignTime.DaysFromNow(7f));
				CampaignTime questDueTime2 = ((QuestBase)this).QuestDueTime;
				EarlyLog($"[QUEST_LOAD] ChangeQuestDueTime called. New due time: {(questDueTime2).ToDays:F0}");
			}
			if (_progressTarget > 0 && !string.IsNullOrEmpty(_progressLabel))
			{
				_discreteLog = ((IEnumerable<JournalLog>)((QuestBase)this).JournalEntries)?.LastOrDefault((Func<JournalLog, bool>)((JournalLog j) => j.TaskName != (TextObject)null && ((object)j.TaskName).ToString() == _progressLabel));
			}
		}
		catch (Exception ex)
		{
			string message4 = "[QUEST_LOAD] Error in InitializeQuestOnGameLoad: " + ex.Message + "\n" + ex.StackTrace;
			EarlyLog(message4);
			AIInfluenceBehavior.Instance?.LogMessage(message4);
		}
	}

	protected override void OnCompleteWithSuccess()
	{
		AIInfluenceBehavior.Instance?.GetDelayedTaskManager()?.AddTask(5.0, delegate
		{
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			int num = MBRandom.RandomInt(2, 11);
			Clan playerClan = Clan.PlayerClan;
			if (playerClan != null)
			{
				playerClan.AddRenown((float)num, true);
			}
			TextObject val = new TextObject("{=AIInfluence_RenownGain}Clan renown increased by {renown}", new Dictionary<string, object> { { "renown", num } });
			MBInformationManager.AddQuickInformation(val, 0, (BasicCharacterObject)null, (Equipment)null, "");
		});
	}

	public override void OnFailed()
	{
		string message = "[QUEST_FAIL] AIGeneratedQuest '" + ((MBObjectBase)this).StringId + "' failed.\nStack: " + Environment.StackTrace;
		EarlyLog(message);
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}

	protected override void OnTimedOut()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		string stringId = ((MBObjectBase)this).StringId;
		CampaignTime val = ((QuestBase)this).QuestDueTime;
		object arg = (val).ToDays;
		val = CampaignTime.Now;
		string message = $"[QUEST_TIMEOUT] AIGeneratedQuest '{stringId}' timed out. DueTime was: {arg:F0}, Now: {(val).ToDays:F0}";
		EarlyLog(message);
		AIInfluenceBehavior.Instance?.LogMessage(message);
		AIInfluenceBehavior.Instance?.HandleQuestTimedOut(((MBObjectBase)this).StringId, _title ?? "Unknown Quest", _npcStringId);
		((QuestBase)this).OnFailed();
	}
}
