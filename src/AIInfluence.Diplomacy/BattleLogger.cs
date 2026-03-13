using System;
using System.IO;
using System.Reflection;

namespace AIInfluence.Diplomacy;

public class BattleLogger
{
	private static BattleLogger _instance;

	private readonly string _logFilePath;

	public static BattleLogger Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new BattleLogger();
			}
			return _instance;
		}
	}

	private BattleLogger()
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
		_logFilePath = Path.Combine(text, "battle.txt");
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
		}
		catch (Exception ex)
		{
			Console.WriteLine("BattleLogger error: " + ex.Message);
		}
	}

	public void LogBattleEnded(string battleType, string winningSide, string losingSide, int attackerInitial, int defenderInitial, int attackerLosses, int defenderLosses, string location = null, bool playerInvolved = false)
	{
		Log("BATTLE ENDED: " + battleType);
		if (!string.IsNullOrEmpty(location))
		{
			Log("  - Location: " + location);
		}
		Log("  - Winner: " + winningSide);
		Log("  - Loser: " + losingSide);
		Log($"  - Initial troops - Attacker: {attackerInitial}, Defender: {defenderInitial}");
		Log($"  - Losses - Attacker: {attackerLosses}, Defender: {defenderLosses}");
		if (playerInvolved)
		{
			Log("  - Player involved: Yes");
		}
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
}
