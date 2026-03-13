using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.DynamicEvents;

public class DynamicEventsStorage
{
	private readonly string _saveDataPath;

	private readonly string _eventsFileName = "dynamic_events.json";

	public DynamicEventsStorage()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		_saveDataPath = Path.Combine(fullName, "save_data");
		if (!Directory.Exists(_saveDataPath))
		{
			Directory.CreateDirectory(_saveDataPath);
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Created save_data directory: " + _saveDataPath);
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
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Created save folder: " + text);
		}
		return text;
	}

	private string GetEventsFilePath()
	{
		return Path.Combine(GetCurrentSaveFolder(), _eventsFileName);
	}

	public void SaveEvents(List<DynamicEvent> events)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		if (events == null)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Attempted to save null events list");
			return;
		}
		try
		{
			string eventsFilePath = GetEventsFilePath();
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)events, val);
			File.WriteAllText(eventsFilePath, contents);
			LogMessage($"[DYNAMIC_EVENTS_STORAGE] Saved {events.Count} events to {eventsFilePath}");
		}
		catch (Exception ex)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Error saving events: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	public List<DynamicEvent> LoadEvents()
	{
		try
		{
			string eventsFilePath = GetEventsFilePath();
			if (!File.Exists(eventsFilePath))
			{
				LogMessage("[DYNAMIC_EVENTS_STORAGE] No events file found at " + eventsFilePath);
				return new List<DynamicEvent>();
			}
			string text = File.ReadAllText(eventsFilePath);
			if (string.IsNullOrWhiteSpace(text))
			{
				LogMessage("[DYNAMIC_EVENTS_STORAGE] Events file is empty");
				return new List<DynamicEvent>();
			}
			List<DynamicEvent> list = JsonConvert.DeserializeObject<List<DynamicEvent>>(text);
			if (list == null)
			{
				LogMessage("[DYNAMIC_EVENTS_STORAGE] Failed to deserialize events");
				return new List<DynamicEvent>();
			}
			LogMessage($"[DYNAMIC_EVENTS_STORAGE] Loaded {list.Count} events from {eventsFilePath}");
			return list;
		}
		catch (Exception ex)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Error loading events: " + ex.Message + "\n" + ex.StackTrace);
			return new List<DynamicEvent>();
		}
	}

	public void DeleteEventsFile()
	{
		try
		{
			string eventsFilePath = GetEventsFilePath();
			if (File.Exists(eventsFilePath))
			{
				File.Delete(eventsFilePath);
				LogMessage("[DYNAMIC_EVENTS_STORAGE] Deleted events file: " + eventsFilePath);
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Error deleting events file: " + ex.Message);
		}
	}

	public bool EventsFileExists()
	{
		return File.Exists(GetEventsFilePath());
	}

	private void LogMessage(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}
}
