using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diseases;

public class DiseaseStorage
{
	private readonly string _saveDataPath;

	private const string DiseasesFileName = "diseases.json";

	private const string DiseaseInstancesFileName = "disease_instances.json";

	private const string SettlementDiseaseInstancesFileName = "settlement_disease_instances.json";

	private const string ManualQuarantineFileName = "manual_quarantine.json";

	public DiseaseStorage()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		_saveDataPath = Path.Combine(fullName, "save_data");
		if (!Directory.Exists(_saveDataPath))
		{
			Directory.CreateDirectory(_saveDataPath);
			LogMessage("[DISEASE_STORAGE] Created save_data directory: " + _saveDataPath);
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
			LogMessage("[DISEASE_STORAGE] Created save folder: " + text);
		}
		return text;
	}

	private string GetDiseasesFilePath()
	{
		return Path.Combine(GetCurrentSaveFolder(), "diseases.json");
	}

	public void SaveDiseases(List<Disease> diseases)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		if (diseases == null)
		{
			LogMessage("[DISEASE_STORAGE] Attempted to save null diseases list");
			return;
		}
		try
		{
			string diseasesFilePath = GetDiseasesFilePath();
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)diseases, val);
			File.WriteAllText(diseasesFilePath, contents);
		}
		catch (Exception ex)
		{
			LogMessage("[DISEASE_STORAGE] Error saving diseases: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	public List<Disease> LoadDiseases()
	{
		try
		{
			string diseasesFilePath = GetDiseasesFilePath();
			if (!File.Exists(diseasesFilePath))
			{
				LogMessage("[DISEASE_STORAGE] No diseases file found at " + diseasesFilePath);
				return new List<Disease>();
			}
			string text = File.ReadAllText(diseasesFilePath);
			if (string.IsNullOrWhiteSpace(text))
			{
				LogMessage("[DISEASE_STORAGE] Diseases file is empty");
				return new List<Disease>();
			}
			List<Disease> list = JsonConvert.DeserializeObject<List<Disease>>(text);
			if (list == null)
			{
				LogMessage("[DISEASE_STORAGE] Failed to deserialize diseases");
				return new List<Disease>();
			}
			LogMessage($"[DISEASE_STORAGE] Loaded {list.Count} diseases from {diseasesFilePath}");
			return list;
		}
		catch (Exception ex)
		{
			LogMessage("[DISEASE_STORAGE] Error loading diseases: " + ex.Message + "\n" + ex.StackTrace);
			return new List<Disease>();
		}
	}

	private string GetDiseaseInstancesFilePath()
	{
		return Path.Combine(GetCurrentSaveFolder(), "disease_instances.json");
	}

	public void SaveDiseaseInstances(List<DiseaseInstance> instances)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		if (instances == null)
		{
			LogMessage("[DISEASE_STORAGE] Attempted to save null disease instances list");
			return;
		}
		try
		{
			string diseaseInstancesFilePath = GetDiseaseInstancesFilePath();
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)instances, val);
			File.WriteAllText(diseaseInstancesFilePath, contents);
		}
		catch (Exception ex)
		{
			LogMessage("[DISEASE_STORAGE] Error saving disease instances: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	public List<DiseaseInstance> LoadDiseaseInstances()
	{
		try
		{
			string diseaseInstancesFilePath = GetDiseaseInstancesFilePath();
			if (!File.Exists(diseaseInstancesFilePath))
			{
				LogMessage("[DISEASE_STORAGE] No disease instances file found at " + diseaseInstancesFilePath);
				return new List<DiseaseInstance>();
			}
			string text = File.ReadAllText(diseaseInstancesFilePath);
			if (string.IsNullOrWhiteSpace(text))
			{
				LogMessage("[DISEASE_STORAGE] Disease instances file is empty");
				return new List<DiseaseInstance>();
			}
			List<DiseaseInstance> list = JsonConvert.DeserializeObject<List<DiseaseInstance>>(text);
			if (list == null)
			{
				LogMessage("[DISEASE_STORAGE] Failed to deserialize disease instances");
				return new List<DiseaseInstance>();
			}
			LogMessage($"[DISEASE_STORAGE] Loaded {list.Count} disease instances from {diseaseInstancesFilePath}");
			return list;
		}
		catch (Exception ex)
		{
			LogMessage("[DISEASE_STORAGE] Error loading disease instances: " + ex.Message + "\n" + ex.StackTrace);
			return new List<DiseaseInstance>();
		}
	}

	private string GetSettlementDiseaseInstancesFilePath()
	{
		return Path.Combine(GetCurrentSaveFolder(), "settlement_disease_instances.json");
	}

	public void SaveSettlementDiseaseInstances(List<SettlementDiseaseInstance> instances)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		if (instances == null)
		{
			LogMessage("[DISEASE_STORAGE] Attempted to save null settlement disease instances list");
			return;
		}
		try
		{
			string settlementDiseaseInstancesFilePath = GetSettlementDiseaseInstancesFilePath();
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)instances, val);
			File.WriteAllText(settlementDiseaseInstancesFilePath, contents);
		}
		catch (Exception ex)
		{
			LogMessage("[DISEASE_STORAGE] Error saving settlement disease instances: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	public List<SettlementDiseaseInstance> LoadSettlementDiseaseInstances()
	{
		try
		{
			string settlementDiseaseInstancesFilePath = GetSettlementDiseaseInstancesFilePath();
			if (!File.Exists(settlementDiseaseInstancesFilePath))
			{
				LogMessage("[DISEASE_STORAGE] No settlement disease instances file found at " + settlementDiseaseInstancesFilePath);
				return new List<SettlementDiseaseInstance>();
			}
			string text = File.ReadAllText(settlementDiseaseInstancesFilePath);
			if (string.IsNullOrWhiteSpace(text))
			{
				LogMessage("[DISEASE_STORAGE] Settlement disease instances file is empty");
				return new List<SettlementDiseaseInstance>();
			}
			List<SettlementDiseaseInstance> list = JsonConvert.DeserializeObject<List<SettlementDiseaseInstance>>(text);
			if (list == null)
			{
				LogMessage("[DISEASE_STORAGE] Failed to deserialize settlement disease instances");
				return new List<SettlementDiseaseInstance>();
			}
			LogMessage($"[DISEASE_STORAGE] Loaded {list.Count} settlement disease instances from {settlementDiseaseInstancesFilePath}");
			return list;
		}
		catch (Exception ex)
		{
			LogMessage("[DISEASE_STORAGE] Error loading settlement disease instances: " + ex.Message + "\n" + ex.StackTrace);
			return new List<SettlementDiseaseInstance>();
		}
	}

	private string GetManualQuarantineFilePath()
	{
		return Path.Combine(GetCurrentSaveFolder(), "manual_quarantine.json");
	}

	public void SaveManualQuarantine(Dictionary<string, float?> manualQuarantine)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		if (manualQuarantine == null)
		{
			return;
		}
		try
		{
			string manualQuarantineFilePath = GetManualQuarantineFilePath();
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)0
			};
			string contents = JsonConvert.SerializeObject((object)manualQuarantine, val);
			File.WriteAllText(manualQuarantineFilePath, contents);
		}
		catch (Exception ex)
		{
			LogMessage("[DISEASE_STORAGE] Error saving manual quarantine: " + ex.Message);
		}
	}

	public Dictionary<string, float?> LoadManualQuarantine()
	{
		try
		{
			string manualQuarantineFilePath = GetManualQuarantineFilePath();
			if (!File.Exists(manualQuarantineFilePath))
			{
				return new Dictionary<string, float?>();
			}
			string text = File.ReadAllText(manualQuarantineFilePath);
			if (string.IsNullOrWhiteSpace(text))
			{
				return new Dictionary<string, float?>();
			}
			Dictionary<string, float?> dictionary = JsonConvert.DeserializeObject<Dictionary<string, float?>>(text);
			if (dictionary == null)
			{
				return new Dictionary<string, float?>();
			}
			LogMessage($"[DISEASE_STORAGE] Loaded {dictionary.Count} manual quarantine entries");
			return dictionary;
		}
		catch (Exception ex)
		{
			LogMessage("[DISEASE_STORAGE] Error loading manual quarantine: " + ex.Message);
			return new Dictionary<string, float?>();
		}
	}

	public void SaveAll(List<Disease> diseases, List<DiseaseInstance> instances, List<SettlementDiseaseInstance> settlementInstances, Dictionary<string, float?> manualQuarantine = null)
	{
		SaveDiseases(diseases);
		SaveDiseaseInstances(instances);
		SaveSettlementDiseaseInstances(settlementInstances);
		if (manualQuarantine != null)
		{
			SaveManualQuarantine(manualQuarantine);
		}
	}

	public void DeleteAllFiles()
	{
		try
		{
			string diseasesFilePath = GetDiseasesFilePath();
			string diseaseInstancesFilePath = GetDiseaseInstancesFilePath();
			string settlementDiseaseInstancesFilePath = GetSettlementDiseaseInstancesFilePath();
			string manualQuarantineFilePath = GetManualQuarantineFilePath();
			if (File.Exists(diseasesFilePath))
			{
				File.Delete(diseasesFilePath);
				LogMessage("[DISEASE_STORAGE] Deleted diseases file: " + diseasesFilePath);
			}
			if (File.Exists(diseaseInstancesFilePath))
			{
				File.Delete(diseaseInstancesFilePath);
				LogMessage("[DISEASE_STORAGE] Deleted disease instances file: " + diseaseInstancesFilePath);
			}
			if (File.Exists(settlementDiseaseInstancesFilePath))
			{
				File.Delete(settlementDiseaseInstancesFilePath);
				LogMessage("[DISEASE_STORAGE] Deleted settlement disease instances file: " + settlementDiseaseInstancesFilePath);
			}
			if (File.Exists(manualQuarantineFilePath))
			{
				File.Delete(manualQuarantineFilePath);
				LogMessage("[DISEASE_STORAGE] Deleted manual quarantine file: " + manualQuarantineFilePath);
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DISEASE_STORAGE] Error deleting files: " + ex.Message);
		}
	}

	public bool HasSavedData()
	{
		return File.Exists(GetDiseasesFilePath()) || File.Exists(GetDiseaseInstancesFilePath()) || File.Exists(GetSettlementDiseaseInstancesFilePath()) || File.Exists(GetManualQuarantineFilePath());
	}

	private void LogMessage(string message)
	{
		DiseaseLogger.Instance?.Log(message);
	}
}
