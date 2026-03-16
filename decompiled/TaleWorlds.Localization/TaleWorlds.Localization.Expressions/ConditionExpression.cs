using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization.TextProcessor;

namespace TaleWorlds.Localization.Expressions;

internal class ConditionExpression : TextExpression
{
	private TextExpression[] _conditionExpressions;

	private TextExpression[] _resultExpressions;

	internal override TokenType TokenType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConditionExpression(TextExpression condition, TextExpression part1, TextExpression part2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConditionExpression(List<TextExpression> conditionExpressions, List<TextExpression> resultExpressions2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal override string EvaluateString(TextProcessingContext context, TextObject parent)
	{
		throw null;
	}
}
