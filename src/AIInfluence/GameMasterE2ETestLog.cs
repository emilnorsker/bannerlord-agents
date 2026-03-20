using System;
using System.IO;
using System.Reflection;

namespace AIInfluence;

/// <summary>BLGM E2E test output only — <c>logs/test_log.txt</c> under the mod folder (not <c>mod_log.txt</c>).</summary>
public static class GameMasterE2ETestLog
{
	private static string _path;

	private static readonly object LockObj = new object();

	private static string ResolvePath()
	{
		if (_path != null)
		{
			return _path;
		}
		try
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
			_path = Path.Combine(fullName, "logs", "test_log.txt");
		}
		catch
		{
			_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AIInfluence", "test_log.txt");
		}
		return _path;
	}

	public static string GetPathForDisplay()
	{
		return ResolvePath();
	}

	public static void Append(string message)
	{
		lock (LockObj)
		{
			try
			{
				string path = ResolvePath();
				string dir = Path.GetDirectoryName(path);
				if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
				{
					Directory.CreateDirectory(dir);
				}
				File.AppendAllText(path, "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] " + message + Environment.NewLine);
			}
			catch (Exception ex)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GameMasterE2ETestLog.Append failed: " + ex);
			}
		}
	}
}
