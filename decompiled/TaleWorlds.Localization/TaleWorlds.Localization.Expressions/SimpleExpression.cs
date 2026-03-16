using System.Runtime.CompilerServices;
using TaleWorlds.Localization.TextProcessor;

namespace TaleWorlds.Localization.Expressions;

internal class SimpleExpression : TextExpression
{
	private TextExpression _innerExpression;

	internal override TokenType TokenType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SimpleExpression(TextExpression innerExpression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal override string EvaluateString(TextProcessingContext context, TextObject parent)
	{
		throw null;
	}
}
