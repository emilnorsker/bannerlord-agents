using System;
using System.IO;
using System.Reflection;

namespace AIInfluence.Behaviors.AIActions;

public class AIActionsLogger
{
	private static AIActionsLogger _instance;

	private readonly string _logFilePath;

	public static AIActionsLogger Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new AIActionsLogger();
			}
			return _instance;
		}
	}

	private AIActionsLogger()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		string text = Path.Combine(fullName, "logs");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		_logFilePath = Path.Combine(text, "aiActions.log");
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

	public void LogActionStarted(string actionName, string heroName)
	{
		Log("=== ACTION STARTED: " + actionName + " ===");
		Log("Hero: " + heroName);
		Log($"Start Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}

	public void LogActionStopped(string actionName, string heroName)
	{
		Log("=== ACTION STOPPED: " + actionName + " ===");
		Log("Hero: " + heroName);
		Log($"Stop Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
		Log("");
	}
}
