using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.SettlementCombat;

public class SettlementPenaltiesStorage
{
	private readonly string _saveDataPath;

	private readonly string _penaltiesFileName = "settlement_penalties.json";

	private readonly SettlementCombatLogger _logger;

	public SettlementPenaltiesStorage()
	{
		_logger = SettlementCombatLogger.Instance;
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		_saveDataPath = Path.Combine(fullName, "save_data");
		if (!Directory.Exists(_saveDataPath))
		{
			Directory.CreateDirectory(_saveDataPath);
			_logger.Log("Created save_data directory: " + _saveDataPath);
		}
	}

	private string GetCurrentSaveFolder()
	{
		Campaign current = Campaign.Current;
		string path = ((current != null) ? current.UniqueGameId : null) ?? "default_save";
		string text = Path.Combine(_saveDataPath, path);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
			_logger.Log("Created save folder: " + text);
		}
		return text;
	}

	private string GetPenaltiesFilePath()
	{
		return Path.Combine(GetCurrentSaveFolder(), _penaltiesFileName);
	}

	public void SavePenalties(Dictionary<string, ActivePenalty> penalties)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		if (penalties == null)
		{
			_logger.Log("Attempted to save null penalties dictionary");
			return;
		}
		try
		{
			string penaltiesFilePath = GetPenaltiesFilePath();
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)penalties, val);
			File.WriteAllText(penaltiesFilePath, contents);
			_logger.Log($"Saved {penalties.Count} penalties to {penaltiesFilePath}");
		}
		catch (Exception ex)
		{
			_logger.LogError("SavePenalties", ex.Message, ex);
		}
	}

	public Dictionary<string, ActivePenalty> LoadPenalties()
	{
		try
		{
			string penaltiesFilePath = GetPenaltiesFilePath();
			if (!File.Exists(penaltiesFilePath))
			{
				_logger.Log("No penalties file found at " + penaltiesFilePath);
				return new Dictionary<string, ActivePenalty>();
			}
			string text = File.ReadAllText(penaltiesFilePath);
			if (string.IsNullOrWhiteSpace(text))
			{
				_logger.Log("Penalties file is empty");
				return new Dictionary<string, ActivePenalty>();
			}
			Dictionary<string, ActivePenalty> dictionary = JsonConvert.DeserializeObject<Dictionary<string, ActivePenalty>>(text);
			_logger.Log($"Loaded {dictionary?.Count ?? 0} penalties from {penaltiesFilePath}");
			return dictionary ?? new Dictionary<string, ActivePenalty>();
		}
		catch (Exception ex)
		{
			_logger.LogError("LoadPenalties", ex.Message, ex);
			return new Dictionary<string, ActivePenalty>();
		}
	}
}
