using System;
using System.Collections.Generic;

namespace AIInfluence.NpcInteraction;

public sealed class InteractionToolContext
{
	public string PlayerId { get; }

	public string NpcId { get; }

	public string CorrelationId { get; }

	public IReadOnlyDictionary<string, string> Arguments { get; }

	public InteractionToolContext(string playerId, string npcId, string correlationId, IReadOnlyDictionary<string, string> arguments)
	{
		if (string.IsNullOrWhiteSpace(playerId))
		{
			throw new ArgumentException("playerId is required.", "playerId");
		}
		if (string.IsNullOrWhiteSpace(npcId))
		{
			throw new ArgumentException("npcId is required.", "npcId");
		}
		if (string.IsNullOrWhiteSpace(correlationId))
		{
			throw new ArgumentException("correlationId is required.", "correlationId");
		}
		PlayerId = playerId;
		NpcId = npcId;
		CorrelationId = correlationId;
		Arguments = arguments ?? new Dictionary<string, string>();
	}
}

