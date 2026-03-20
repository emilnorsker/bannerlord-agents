using System;
using System.IO;
using System.Reflection;
using MCM.Abstractions.Base.Global;

namespace AIInfluence;

/// <summary>Slice 13: append-only GM audit trail (plan, line, observation).</summary>
public static class GameMasterAuditLog
{
	private static string _path;

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
			_path = Path.Combine(fullName, "logs", "gm_audit.log");
		}
		catch
		{
			_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AIInfluence", "gm_audit.log");
		}
		return _path;
	}

	public static void Append(string completionPath, string correlationId, Guid jobId, string line, string planJson, string observationOrPhase, string detail)
	{
		if (GlobalSettings<ModSettings>.Instance == null || !GlobalSettings<ModSettings>.Instance.GameMasterAuditLogEnabled)
		{
			return;
		}
		try
		{
			string path = ResolvePath();
			string dir = Path.GetDirectoryName(path);
			if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
			string ts = DateTime.UtcNow.ToString("o");
			string row = ts + "\t" + (completionPath ?? "") + "\t" + (correlationId ?? "") + "\t" + jobId + "\t" + (line ?? "").Replace('\t', ' ') + "\t" + (observationOrPhase ?? "").Replace('\t', ' ') + "\t" + (detail ?? "").Replace('\t', ' ') + "\t" + (planJson ?? "").Replace('\n', ' ').Replace('\t', ' ') + Environment.NewLine;
			File.AppendAllText(path, row);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[GM_AUDIT] append failed: " + ex.Message);
		}
	}
}
