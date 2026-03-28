using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

public static class PatternLibraryLoader
{
    public static PatternLibraryRegistry LoadFromFile(string filePath, Action<string> log)
    {
        var registry = new PatternLibraryRegistry();

        if (!File.Exists(filePath))
        {
            log?.Invoke($"[WorldSystem] Pattern library file not found: {filePath}");
            return registry;
        }

        try
        {
            string json = File.ReadAllText(filePath);
            var libraries = JsonConvert.DeserializeObject<List<PatternLibrary>>(json);
            if (libraries != null)
            {
                foreach (var library in libraries)
                    registry.Register(library);
                log?.Invoke($"[WorldSystem] Loaded {libraries.Count} pattern libraries.");
            }
        }
        catch (Exception exception)
        {
            log?.Invoke($"[WorldSystem] Failed to load pattern libraries from {filePath}: {exception.Message}");
        }

        return registry;
    }
}
