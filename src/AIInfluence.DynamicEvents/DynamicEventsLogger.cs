using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MCM.Abstractions.Base.Global;

namespace AIInfluence.DynamicEvents;

public class DynamicEventsLogger
{
	private static DynamicEventsLogger _instance;

	private readonly string _logFilePath;

	public static DynamicEventsLogger Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DynamicEventsLogger();
			}
			return _instance;
		}
	}

	private DynamicEventsLogger()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		string text = Path.Combine(fullName, "logs");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		_logFilePath = Path.Combine(text, "dynamicEvents.log");
	}

	public void Log(string message)
	{
		try
		{
			string contents = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
			File.AppendAllText(_logFilePath, contents);
		}
		catch (Exception)
		{
		}
	}

	public void LogEventGeneration(string prompt, string aiResponse, int eventsGenerated)
	{
		Log("=== EVENT GENERATION START ===");
		Log($"Events Generated: {eventsGenerated}");
		Log("");
		Log("PROMPT SENT TO AI:");
		Log("-------------------");
		Log(prompt);
		Log("");
		Log("AI RESPONSE:");
		Log("-------------------");
		Log(aiResponse);
		Log("");
		Log("=== EVENT GENERATION END ===");
		Log("");
	}

	public void LogEventCreated(DynamicEvent dynamicEvent)
	{
		if (dynamicEvent == null)
		{
			Log("EVENT CREATED: (null event)");
			return;
		}
		string desc = dynamicEvent.Description ?? "";
		string preview = desc.Length <= 100 ? desc : desc.Substring(0, 100) + "...";
		Log("EVENT CREATED: [" + dynamicEvent.Type + "] " + preview);
		Log("  - ID: " + dynamicEvent.Id);
		Log($"  - Importance: {dynamicEvent.Importance}");
		Log($"  - Player Involved: {dynamicEvent.PlayerInvolved}");
		Log("  - Kingdoms: " + GetKingdomsString(dynamicEvent));
		Log("  - Spread Speed: " + dynamicEvent.SpreadSpeed);
		Log($"  - Allows Diplomatic Response: {dynamicEvent.AllowsDiplomaticResponse}");
		int num = GlobalSettings<ModSettings>.Instance?.DynamicEventsLifespan ?? 30;
		Log($"  - Expiration: {num} game days from creation");
		Log("");
	}

	public void LogEventDistribution(string eventId, int npcCount)
	{
		Log($"EVENT DISTRIBUTED: {eventId} → {npcCount} NPCs");
	}

	public void LogEventExpired(string eventId, string description)
	{
		string desc = description ?? "";
		string preview = desc.Length <= 100 ? desc : desc.Substring(0, 100) + "...";
		Log("EVENT EXPIRED: " + eventId + " - " + preview);
	}

	private string GetKingdomsString(DynamicEvent evt)
	{
		if (evt.KingdomsInvolved == null)
		{
			return "null";
		}
		if (evt.KingdomsInvolved is string text)
		{
			return "\"" + text + "\"";
		}
		List<string> kingdomStringIds = evt.GetKingdomStringIds();
		return "[" + string.Join(", ", kingdomStringIds) + "]";
	}

	public void ClearLog()
	{
		try
		{
			if (File.Exists(_logFilePath))
			{
				File.WriteAllText(_logFilePath, "");
				Log("Log cleared");
			}
		}
		catch (Exception)
		{
		}
	}
}
