using System;
using System.Threading.Tasks;

namespace AIInfluence.NpcInteraction;

public sealed class NpcInteractionEngine
{
	public async Task<ModelTurnResult> RunOpenRouterTurnAsync(OpenRouterModelClient llmClient, string systemPrompt, string userPrompt, Action<string> onTextDelta = null)
	{
		if (llmClient == null)
		{
			throw new ArgumentNullException("llmClient");
		}
		return await llmClient.StreamTurnAsync(systemPrompt, userPrompt, onTextDelta).ConfigureAwait(false);
	}
}

