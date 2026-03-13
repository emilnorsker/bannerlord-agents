using System;
using System.IO;
using System.Reflection;

namespace AIInfluence.SettlementCombat;

public class SettlementCombatLogger
{
	private static SettlementCombatLogger _instance;

	private readonly string _logFilePath;

	public static SettlementCombatLogger Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SettlementCombatLogger();
			}
			return _instance;
		}
	}

	private SettlementCombatLogger()
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
		_logFilePath = Path.Combine(text, "settlement_combat.txt");
	}

	public void Log(string message)
	{
		try
		{
			string contents = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
			string directoryName = Path.GetDirectoryName(_logFilePath);
			if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			File.AppendAllText(_logFilePath, contents);
		}
		catch (Exception)
		{
		}
	}

	public void LogCombatInitiated(string settlementName, string settlementId, string triggerType, string npcName, string npcId)
	{
		Log("=== COMBAT INITIATED ===");
		Log("Settlement: " + settlementName + " (id:" + settlementId + ")");
		Log("Trigger Type: " + triggerType);
		Log("Trigger NPC: " + npcName + " (id:" + npcId + ")");
		Log($"Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("========================");
		Log("");
	}

	public void LogSituationAnalysisPrompt(string settlementId, string prompt)
	{
		Log("=== SITUATION ANALYSIS PROMPT SENT ===");
		Log("Settlement ID: " + settlementId);
		Log("");
		Log("PROMPT:");
		Log("-------");
		Log(prompt);
		Log("");
		Log("=== END PROMPT ===");
		Log("");
	}

	public void LogSituationAnalysisResponse(string settlementId, string aiResponse)
	{
		Log("=== SITUATION ANALYSIS RESPONSE ===");
		Log("Settlement ID: " + settlementId);
		Log("");
		Log("AI RESPONSE:");
		Log("------------");
		Log(aiResponse);
		Log("");
		Log("=== END RESPONSE ===");
		Log("");
	}

	public void LogAnalysisResult(string aggressor, string defender, int witnessCount, bool needsDefenders, int lordsCount)
	{
		Log("=== ANALYSIS RESULT ===");
		Log("Aggressor: " + aggressor);
		Log("Defender: " + defender);
		Log($"Witnesses: {witnessCount}");
		Log($"Needs Defenders: {needsDefenders}");
		if (needsDefenders)
		{
			Log("  - Troop numbers & timing handled automatically by system (counts set to 0 in JSON).");
			if (lordsCount > 0)
			{
				Log($"  - Lords: {lordsCount} (arrival time calculated by distance)");
			}
		}
		Log("=======================");
		Log("");
	}

	public void LogDefendersSpawned(string type, int count, string settlementId)
	{
		Log($"DEFENDERS SPAWNED: {type} x{count} in {settlementId}");
	}

	public void LogLordSpawned(string lordName, string lordId, int troopsCount, string settlementId)
	{
		Log($"LORD SPAWNED: {lordName} (id:{lordId}) with {troopsCount} troops in {settlementId}");
	}

	public void LogCivilianPanic(int processedCount, int totalCivilians, string settlementId)
	{
		Log($"CIVILIAN PANIC: {processedCount}/{totalCivilians} civilians processed (panicking + fighting) in {settlementId}");
	}

	public void LogCombatEnded(string settlementId, int totalKilled, int totalWounded, int civiliansKilled, int civiliansWounded)
	{
		Log("=== COMBAT ENDED ===");
		Log("Settlement ID: " + settlementId);
		Log($"Total Killed: {totalKilled} (Civilians: {civiliansKilled})");
		Log($"Total Wounded: {totalWounded} (Civilians: {civiliansWounded})");
		Log($"Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("====================");
		Log("");
	}

	public void LogPostCombatEventPrompt(string settlementId, string prompt)
	{
		Log("=== POST-COMBAT EVENT PROMPT SENT ===");
		Log("Settlement ID: " + settlementId);
		Log("");
		Log("PROMPT:");
		Log("-------");
		Log(prompt);
		Log("");
		Log("=== END PROMPT ===");
		Log("");
	}

	public void LogPostCombatEventResponse(string settlementId, string aiResponse)
	{
		Log("=== POST-COMBAT EVENT RESPONSE ===");
		Log("Settlement ID: " + settlementId);
		Log("");
		Log("AI RESPONSE:");
		Log("------------");
		Log(aiResponse);
		Log("");
		Log("=== END RESPONSE ===");
		Log("");
	}

	public void LogDynamicEventCreated(string eventId, string eventTitle, string settlementId)
	{
		Log("DYNAMIC EVENT CREATED: " + eventTitle + " (id:" + eventId + ") for settlement " + settlementId);
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
				Log("Settlement Combat log cleared");
			}
		}
		catch (Exception)
		{
		}
	}
}
