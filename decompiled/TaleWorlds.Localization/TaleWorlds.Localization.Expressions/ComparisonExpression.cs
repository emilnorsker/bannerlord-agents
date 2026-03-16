using System.Runtime.CompilerServices;
using TaleWorlds.Localization.TextProcessor;

namespace TaleWorlds.Localization.Expressions;

internal class ComparisonExpression : NumeralExpression
{
	private readonly ComparisonOperation _op;

	private readonly TextExpression _exp1;

	private readonly TextExpression _exp2;

	internal override TokenType TokenType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ComparisonExpression(ComparisonOperation op, TextExpression exp1, TextExpression exp2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool EvaluateBoolean(TextProcessingContext context, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal override int EvaluateNumber(TextProcessingContext context, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal override string EvaluateString(TextProcessingContext context, TextObject parent)
	{
		throw null;
	}
}
