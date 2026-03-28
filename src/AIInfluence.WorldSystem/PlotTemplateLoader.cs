using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

public static class PlotTemplateLoader
{
    public static Dictionary<string, PlotTemplate> LoadFromFile(string filePath, Action<string> log)
    {
        var result = new Dictionary<string, PlotTemplate>();

        if (!File.Exists(filePath))
        {
            log?.Invoke($"[WorldSystem] Plot templates file not found: {filePath}");
            return result;
        }

        try
        {
            string json = File.ReadAllText(filePath);
            return LoadFromJson(json, log);
        }
        catch (Exception exception)
        {
            log?.Invoke($"[WorldSystem] Failed to load plot templates from {filePath}: {exception.Message}");
            return result;
        }
    }

    public static Dictionary<string, PlotTemplate> LoadFromJson(string json, Action<string> log)
    {
        var result = new Dictionary<string, PlotTemplate>();

        var templates = JsonConvert.DeserializeObject<List<PlotTemplate>>(json);
        if (templates == null)
        {
            log?.Invoke("[WorldSystem] Plot templates JSON deserialized to null.");
            return result;
        }

        foreach (var template in templates)
        {
            if (string.IsNullOrEmpty(template.TemplateId))
            {
                log?.Invoke("[WorldSystem] Skipping template with empty template_id.");
                continue;
            }
            result[template.TemplateId] = template;
        }

        log?.Invoke($"[WorldSystem] Loaded {result.Count} plot templates.");
        return result;
    }
}
