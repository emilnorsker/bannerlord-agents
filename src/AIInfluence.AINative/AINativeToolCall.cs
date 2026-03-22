using System;
using System.Collections.Generic;

namespace AIInfluence.AINative;

public sealed class AINativeToolCall
{
	public string Name { get; }

	public string CorrelationId { get; }

	public IReadOnlyDictionary<string, string> Arguments { get; }

	public AINativeToolCall(string name, string correlationId, IReadOnlyDictionary<string, string> arguments)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new ArgumentException("name is required.", "name");
		}
		if (string.IsNullOrWhiteSpace(correlationId))
		{
			throw new ArgumentException("correlationId is required.", "correlationId");
		}
		Name = name;
		CorrelationId = correlationId;
		Arguments = arguments ?? new Dictionary<string, string>();
	}
}

