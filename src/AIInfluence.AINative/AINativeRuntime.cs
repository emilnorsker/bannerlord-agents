using System;
using System.Threading.Tasks;
using AIInfluence.NpcInteraction.Tools;

namespace AIInfluence.NpcInteraction;

public sealed class NpcInteractionEngine
{
	private readonly InteractionToolRegistry _tools;

	public InteractionEventStream Stream { get; }

	public NpcInteractionEngine()
	{
		Stream = new InteractionEventStream();
		_tools = new InteractionToolRegistry();
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
		Stream.Enqueue(new InteractionEvent(InteractionEventType.DialogueSpoken, correlationId, npcId, "assistant_text", text));
	}

	public void HandleToolCall(string playerId, string npcId, InteractionToolCall toolCall)
	{
		if (toolCall == null)
		{
			throw new ArgumentNullException("toolCall");
		}
		var tool = _tools.Resolve(toolCall.Name);
		var context = new InteractionToolContext(playerId, npcId, toolCall.CorrelationId, toolCall.Arguments);
		tool.Execute(context, Stream);
	}

	public void CompleteAction(string correlationId, string npcId, string actionName, string message)
	{
		Stream.Enqueue(new InteractionEvent(InteractionEventType.ActionCompleted, correlationId, npcId, actionName, message));
	}

	public void FailAction(string correlationId, string npcId, string actionName, string reason)
	{
		Stream.Enqueue(new InteractionEvent(InteractionEventType.ActionFailed, correlationId, npcId, actionName, reason));
	}

	public async Task<ModelTurnResult> RunOpenRouterTurnAsync(OpenRouterModelClient llmClient, string playerId, string npcId, string correlationId, string systemPrompt, string userPrompt, Action<string> onTextDelta = null)
	{
		var completion = await llmClient.StreamTurnAsync(systemPrompt, userPrompt, onTextDelta).ConfigureAwait(false);
		HandleAssistantText(correlationId, npcId, completion.Text);
		foreach (ModelToolCall toolCall in completion.ToolCalls)
		{
			HandleToolCall(playerId, npcId, new InteractionToolCall(toolCall.Name, correlationId, toolCall.Arguments));
		}
		return completion;
	}
}

