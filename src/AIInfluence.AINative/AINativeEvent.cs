using System;

namespace AIInfluence.NpcInteraction;

public sealed class InteractionEvent
{
	public long Sequence { get; private set; }

	public DateTime TimestampUtc { get; }

	public string CorrelationId { get; }

	public string NpcId { get; }

	public InteractionEventType Type { get; }

	public string Name { get; }

	public string Message { get; }

	public InteractionEvent(InteractionEventType type, string correlationId, string npcId, string name, string message)
	{
		if (string.IsNullOrWhiteSpace(correlationId))
		{
			throw new ArgumentException("correlationId is required.", "correlationId");
		}
		if (string.IsNullOrWhiteSpace(npcId))
		{
			throw new ArgumentException("npcId is required.", "npcId");
		}
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new ArgumentException("name is required.", "name");
		}
		TimestampUtc = DateTime.UtcNow;
		CorrelationId = correlationId;
		NpcId = npcId;
		Type = type;
		Name = name;
		Message = message ?? string.Empty;
	}

	internal void AssignSequence(long sequence)
	{
		Sequence = sequence;
	}
}

