using System;
using System.Collections.Generic;

namespace AIInfluence.NpcInteraction;

public sealed class InteractionToolRegistry
{
	private readonly Dictionary<string, IInteractionTool> _tools = new Dictionary<string, IInteractionTool>(StringComparer.OrdinalIgnoreCase);

	public void Register(IInteractionTool tool)
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

	public IInteractionTool Resolve(string toolName)
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

