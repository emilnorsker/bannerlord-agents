using System.Runtime.CompilerServices;
using TaleWorlds.Localization.TextProcessor;

namespace TaleWorlds.Localization.Expressions;

internal class MarkerOccuranceTextExpression : TextExpression
{
	private VariableExpression _innerVariable;

	private string _identifierName;

	public string IdentifierName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal override TokenType TokenType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MarkerOccuranceTextExpression(string identifierName, VariableExpression innerExpression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string MarkerOccuranceExpression(string identifierName, string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal override string EvaluateString(TextProcessingContext context, TextObject parent)
	{
		throw null;
	}
}
