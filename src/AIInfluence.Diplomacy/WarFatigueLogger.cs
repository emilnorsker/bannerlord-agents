using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class WarFatigueLogger
{
	private static WarFatigueLogger _instance;

	private readonly string _logFilePath;

	public static WarFatigueLogger Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new WarFatigueLogger();
			}
			return _instance;
		}
	}

	private WarFatigueLogger()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		string text = Path.Combine(fullName, "logs");
		try
		{
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
		}
		catch
		{
		}
		_logFilePath = Path.Combine(text, "warfatigue.txt");
	}

	public void Log(string message)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(_logFilePath);
			if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			string contents = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
			File.AppendAllText(_logFilePath, contents);
			Console.WriteLine("[WarFatigue] " + message);
		}
		catch (Exception ex)
		{
			Console.WriteLine("WarFatigueLogger error: " + ex.Message);
		}
	}

	public void LogInitialization()
	{
		Log("=== WAR FATIGUE SYSTEM INITIALIZATION ===");
		Log($"War Fatigue Logger initialized at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("=== INITIALIZATION COMPLETE ===");
		Log("");
	}

	public void LogWarStatisticsUpdate()
	{
		Log("=== WAR STATISTICS UPDATE ===");
		Log($"Update time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		WarStatisticsTracker instance = WarStatisticsTracker.Instance;
		if (instance != null)
		{
			foreach (Kingdom item in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
			{
				KingdomWarStats kingdomStats = instance.GetKingdomStats(item);
				if (kingdomStats != null)
				{
					Log($"[{item.Name}] Troops={kingdomStats.CurrentTroops}, Casualties={kingdomStats.TotalCasualties}, Fatigue={kingdomStats.WarFatigue:F1}%, Settlements={kingdomStats.CurrentSettlements}, Lords Captured={kingdomStats.TotalLordsCaptured}, Lords Killed={kingdomStats.TotalLordsKilled}");
				}
			}
		}
		Log("=== WAR STATISTICS UPDATE COMPLETE ===");
		Log("");
	}

	public void LogWarFatigueChange(string kingdomName, float oldFatigue, float newFatigue, string reason)
	{
		Log("WAR FATIGUE CHANGE: " + kingdomName);
		Log($"  - Old Fatigue: {oldFatigue:F1}%");
		Log($"  - New Fatigue: {newFatigue:F1}%");
		Log($"  - Change: {newFatigue - oldFatigue:+0.0;-0.0;+0}%");
		Log("  - Reason: " + reason);
		Log($"  - Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogFatigueRecovery(string kingdomName, float oldFatigue, float newFatigue, float recoveryAmount)
	{
		Log("FATIGUE RECOVERY: " + kingdomName);
		Log($"  - Old Fatigue: {oldFatigue:F1}%");
		Log($"  - New Fatigue: {newFatigue:F1}%");
		Log($"  - Recovery: -{recoveryAmount:F1}%");
		Log("  - Reason: Peace time recovery");
		Log($"  - Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogCasualtyUpdate(string kingdomName, int casualties, string enemyKingdomName = null)
	{
		Log("CASUALTY UPDATE: " + kingdomName);
		Log($"  - Casualties: +{casualties}");
		if (!string.IsNullOrEmpty(enemyKingdomName))
		{
			Log("  - Against: " + enemyKingdomName);
		}
		Log($"  - Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogWarStart(string kingdom1Name, string kingdom2Name)
	{
		Log("WAR STARTED: " + kingdom1Name + " vs " + kingdom2Name);
		Log($"  - Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogWarEnd(string kingdom1Name, string kingdom2Name)
	{
		Log("WAR ENDED: " + kingdom1Name + " vs " + kingdom2Name);
		Log($"  - Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogLordEvent(string kingdomName, string eventType, string lordName = null)
	{
		Log("LORD EVENT: " + kingdomName);
		Log("  - Event: " + eventType);
		if (!string.IsNullOrEmpty(lordName))
		{
			Log("  - Lord: " + lordName);
		}
		Log($"  - Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogSettlementLost(string kingdomName, string settlementName)
	{
		Log("SETTLEMENT LOST: " + kingdomName);
		Log("  - Settlement: " + settlementName);
		Log($"  - Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogCaravanDestroyed(string kingdomName)
	{
		Log("CARAVAN DESTROYED: " + kingdomName);
		Log($"  - Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogError(string context, string errorMessage, Exception exception = null)
	{
		Log("ERROR [" + context + "]: " + errorMessage);
		if (exception != null)
		{
			Log("  - Exception: " + exception.GetType().Name);
			Log("  - Message: " + exception.Message);
			if (exception.StackTrace != null)
			{
				Log("  - Stack Trace: " + exception.StackTrace);
			}
		}
		Log("");
	}

	public void LogWarning(string context, string warningMessage)
	{
		Log("WARNING [" + context + "]: " + warningMessage);
		Log("");
	}

	public void ClearLog()
	{
		try
		{
			if (File.Exists(_logFilePath))
			{
				File.WriteAllText(_logFilePath, "");
				Log("War fatigue log cleared");
			}
		}
		catch (Exception)
		{
		}
	}
}
