using System;

namespace AIInfluence.ChatTools;

/// <summary>Observable tool invocations for logging, analytics, and subscribers (Phase 0 north star).</summary>
public static class ToolCallTelemetry
{
	/// <param name="feature">e.g. <c>npc_chat</c>, <c>diplomacy</c>.</param>
	/// <param name="toolName">OpenRouter function name.</param>
	/// <param name="argsJson">Raw arguments JSON from the model.</param>
	/// <param name="resultJson">Handler return string (often JSON or a short code).</param>
	/// <param name="error">Set when the handler throws.</param>
	public static event Action<string, string, string, string, Exception> ToolCompleted;

	public static void RaiseCompleted(string feature, string toolName, string argsJson, string resultJson, Exception error)
	{
		ToolCompleted?.Invoke(feature ?? "", toolName ?? "", argsJson ?? "", resultJson ?? "", error);
	}
}
