using System;
using System.Threading.Tasks;
using AIInfluence.AINative.Tools;

namespace AIInfluence.AINative;

public sealed class AINativeRuntime
{
	private readonly AINativeToolRegistry _tools;

	public AINativeQueue Queue { get; }

	public AINativeRuntime()
	{
		Queue = new AINativeQueue();
		_tools = new AINativeToolRegistry();
		_tools.Register(new NpcSayTool());
		_tools.Register(new FollowPlayerTool());
		_tools.Register(new GoToSettlementTool());
		_tools.Register(new AttackPartyTool());
	}

	public void HandleAssistantText(string correlationId, string npcId, string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return;
		}
		Queue.Enqueue(new AINativeEvent(AINativeEventType.DialogueSpoken, correlationId, npcId, "assistant_text", text));
	}

	public void HandleToolCall(string playerId, string npcId, AINativeToolCall toolCall)
	{
		if (toolCall == null)
		{
			throw new ArgumentNullException("toolCall");
		}
		var tool = _tools.Resolve(toolCall.Name);
		var context = new AINativeToolContext(playerId, npcId, toolCall.CorrelationId, toolCall.Arguments);
		tool.Execute(context, Queue);
	}

	public void CompleteAction(string correlationId, string npcId, string actionName, string message)
	{
		Queue.Enqueue(new AINativeEvent(AINativeEventType.ActionCompleted, correlationId, npcId, actionName, message));
	}

	public void FailAction(string correlationId, string npcId, string actionName, string reason)
	{
		Queue.Enqueue(new AINativeEvent(AINativeEventType.ActionFailed, correlationId, npcId, actionName, reason));
	}

	public async Task<AINativeLlmCompletion> RunOpenRouterTurnAsync(OpenRouterStreamingLlmClient llmClient, string playerId, string npcId, string correlationId, string systemPrompt, string userPrompt, Action<string> onTextDelta = null)
	{
		var completion = await llmClient.StreamCompletionAsync(systemPrompt, userPrompt, onTextDelta).ConfigureAwait(false);
		HandleAssistantText(correlationId, npcId, completion.Text);
		foreach (AINativeLlmToolCall toolCall in completion.ToolCalls)
		{
			HandleToolCall(playerId, npcId, new AINativeToolCall(toolCall.Name, correlationId, toolCall.Arguments));
		}
		return completion;
	}
}

