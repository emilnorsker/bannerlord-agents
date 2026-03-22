using System;
using System.Collections.Generic;

namespace AIInfluence.AINative;

public sealed class AINativeToolRegistry
{
	private readonly Dictionary<string, IAINativeTool> _tools = new Dictionary<string, IAINativeTool>(StringComparer.OrdinalIgnoreCase);

	public void Register(IAINativeTool tool)
	{
		if (tool == null)
		{
			throw new ArgumentNullException("tool");
		}
		if (_tools.ContainsKey(tool.Name))
		{
			throw new InvalidOperationException("Tool already registered: " + tool.Name);
		}
		_tools.Add(tool.Name, tool);
	}

	public IAINativeTool Resolve(string toolName)
	{
		if (string.IsNullOrWhiteSpace(toolName))
		{
			throw new ArgumentException("toolName is required.", "toolName");
		}
		if (!_tools.TryGetValue(toolName, out var tool))
		{
			throw new InvalidOperationException("Unknown tool: " + toolName);
		}
		return tool;
	}
}

