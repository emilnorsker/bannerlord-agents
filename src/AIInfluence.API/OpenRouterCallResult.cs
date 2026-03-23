namespace AIInfluence.API;

/// <summary>Outcome of a single OpenRouter HTTP completion (dialogue JSON or raw text). Call sites branch on <see cref="Success"/> instead of parsing <see cref="Payload"/> with string heuristics.</summary>
public readonly struct OpenRouterCallResult
{
	public bool Success { get; }
	public string Payload { get; }

	public static OpenRouterCallResult Ok(string payload) => new OpenRouterCallResult(true, payload ?? "");
	public static OpenRouterCallResult Failed(string payload) => new OpenRouterCallResult(false, payload ?? "");

	private OpenRouterCallResult(bool success, string payload)
	{
		Success = success;
		Payload = payload;
	}
}
