using System;
using System.IO;
using System.Reflection;

namespace AIInfluence.Behaviors.DeathHistory;

public class DeathHistoryLogger
{
	private static DeathHistoryLogger _instance;

	private readonly string _logFilePath;

	public static DeathHistoryLogger Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DeathHistoryLogger();
			}
			return _instance;
		}
	}

	private DeathHistoryLogger()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		string text = Path.Combine(fullName, "logs");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		_logFilePath = Path.Combine(text, "DeathHistory.log");
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

	public void LogHistoryGeneration(string heroName, bool isPlayer, string prompt, string aiResponse)
	{
		Log("=== DEATH HISTORY GENERATION START ===");
		Log("Hero: " + heroName);
		Log($"Is Player: {isPlayer}");
		Log($"Prompt Length: {prompt?.Length ?? 0} chars");
		Log("");
		Log("PROMPT SENT TO AI:");
		Log("-------------------");
		Log(prompt ?? "(null)");
		Log("");
		Log("AI RESPONSE:");
		Log("-------------------");
		Log(aiResponse ?? "(null)");
		Log("");
		Log("=== DEATH HISTORY GENERATION END ===");
		Log("");
	}
}
