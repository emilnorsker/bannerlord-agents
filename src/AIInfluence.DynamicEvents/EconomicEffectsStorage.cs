using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.DynamicEvents;

public class EconomicEffectsStorage
{
	private readonly string _saveDataPath;

	private readonly string _effectsFileName = "economic_effects.json";

	public EconomicEffectsStorage()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		_saveDataPath = Path.Combine(fullName, "save_data");
		if (!Directory.Exists(_saveDataPath))
		{
			Directory.CreateDirectory(_saveDataPath);
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
		}
		return text;
	}

	private string GetEffectsFilePath()
	{
		return Path.Combine(GetCurrentSaveFolder(), _effectsFileName);
	}

	public void SaveEffects(List<ActiveEconomicEffect> effects)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		if (effects == null)
		{
			return;
		}
		try
		{
			string effectsFilePath = GetEffectsFilePath();
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)effects, val);
			File.WriteAllText(effectsFilePath, contents);
		}
		catch (Exception)
		{
		}
	}

	public List<ActiveEconomicEffect> LoadEffects()
	{
		try
		{
			string effectsFilePath = GetEffectsFilePath();
			if (!File.Exists(effectsFilePath))
			{
				return new List<ActiveEconomicEffect>();
			}
			string text = File.ReadAllText(effectsFilePath);
			if (string.IsNullOrWhiteSpace(text))
			{
				return new List<ActiveEconomicEffect>();
			}
			List<ActiveEconomicEffect> list = JsonConvert.DeserializeObject<List<ActiveEconomicEffect>>(text);
			return list ?? new List<ActiveEconomicEffect>();
		}
		catch (Exception)
		{
			return new List<ActiveEconomicEffect>();
		}
	}
}
