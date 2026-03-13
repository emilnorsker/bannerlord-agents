using System;
using System.IO;
using System.Reflection;

namespace AIInfluence.Diplomacy;

public class DiplomacyLogger
{
	private static DiplomacyLogger _instance;

	private readonly string _logFilePath;

	public static DiplomacyLogger Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DiplomacyLogger();
			}
			return _instance;
		}
	}

	private DiplomacyLogger()
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
		_logFilePath = Path.Combine(text, "diplomacy.txt");
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

	public void LogInitialization(bool enabled, bool startInPeace)
	{
		Log("=== DIPLOMACY SYSTEM INITIALIZATION ===");
		Log($"Diplomacy Enabled: {enabled}");
		Log($"Start In Peace: {startInPeace}");
		Log("=== INITIALIZATION COMPLETE ===");
		Log("");
	}

	public void LogSituationCreated(string situationId, string situationType, string[] kingdomsInvolved)
	{
		Log("DIPLOMATIC SITUATION CREATED: [" + situationType + "] " + situationId);
		Log("  - Kingdoms Involved: [" + string.Join(", ", kingdomsInvolved) + "]");
		Log($"  - Created: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogStatementGeneration(string situationId, string kingdomId, string leaderId, string prompt, string aiResponse)
	{
		Log("=== DIPLOMATIC STATEMENT GENERATION START ===");
		Log("Situation: " + situationId);
		Log("Kingdom: " + kingdomId);
		Log("Leader: " + leaderId);
		Log("");
		Log("PROMPT SENT TO AI:");
		Log("-------------------");
		Log(prompt);
		Log("");
		Log("AI RESPONSE:");
		Log("-------------------");
		Log(aiResponse);
		Log("");
		Log("=== DIPLOMATIC STATEMENT GENERATION END ===");
		Log("");
	}

	public void LogStatementCreated(string statementId, string situationId, string kingdomId, string leaderId, string content)
	{
		Log("DIPLOMATIC STATEMENT CREATED: " + statementId);
		Log("  - Situation: " + situationId);
		Log("  - Kingdom: " + kingdomId);
		Log("  - Leader: " + leaderId);
		Log("  - Content: " + content.Substring(0, Math.Min(100, content.Length)) + "...");
		Log($"  - Created: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogDiplomaticResponse(string situationId, string respondingKingdomId, string responseType, string responseContent)
	{
		Log("DIPLOMATIC RESPONSE: " + situationId);
		Log("  - Responding Kingdom: " + respondingKingdomId);
		Log("  - Response Type: " + responseType);
		Log("  - Response: " + responseContent.Substring(0, Math.Min(100, responseContent.Length)) + "...");
		Log($"  - Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogSituationResolved(string situationId, string resolutionType, string[] affectedKingdoms)
	{
		Log("DIPLOMATIC SITUATION RESOLVED: " + situationId);
		Log("  - Resolution Type: " + resolutionType);
		Log("  - Affected Kingdoms: [" + string.Join(", ", affectedKingdoms) + "]");
		Log($"  - Resolved: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogDiplomaticAction(string actionType, string kingdom1Id, string kingdom2Id, string reason)
	{
		Log("DIPLOMATIC ACTION: " + actionType);
		Log("  - Kingdom 1: " + kingdom1Id);
		Log("  - Kingdom 2: " + kingdom2Id);
		Log("  - Reason: " + reason);
		Log($"  - Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogRelationChange(string kingdom1Id, string kingdom2Id, int oldRelation, int newRelation, string reason)
	{
		Log("RELATION CHANGE: " + kingdom1Id + " ↔ " + kingdom2Id);
		Log($"  - Old Relation: {oldRelation}");
		Log($"  - New Relation: {newRelation}");
		Log($"  - Change: {newRelation - oldRelation:+0;-0;+0}");
		Log("  - Reason: " + reason);
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

	public void LogDailyTick(int activeSituations, int pendingStatements, int expiredSituations)
	{
		Log($"DAILY TICK: Active Situations: {activeSituations}, Pending Statements: {pendingStatements}, Expired: {expiredSituations}");
	}

	public void LogEventAnalysis(string eventId, string eventType, int round, string prompt, string aiResponse, int actionsCount)
	{
		Log("=== DIPLOMATIC EVENT ANALYSIS START ===");
		Log("Event ID: " + eventId);
		Log("Event Type: " + eventType);
		Log($"Diplomatic Round: {round}");
		Log("");
		Log("ANALYSIS PROMPT SENT TO AI:");
		Log("----------------------------");
		Log(prompt);
		Log("");
		Log("AI ANALYSIS RESPONSE:");
		Log("---------------------");
		Log(aiResponse);
		Log("");
		Log($"Actions to Execute: {actionsCount}");
		Log("=== DIPLOMATIC EVENT ANALYSIS END ===");
		Log("");
	}

	public void ClearLog()
	{
		try
		{
			if (File.Exists(_logFilePath))
			{
				File.WriteAllText(_logFilePath, "");
				Log("Diplomacy log cleared");
			}
		}
		catch (Exception)
		{
		}
	}
}
