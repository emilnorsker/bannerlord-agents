using System.Runtime.CompilerServices;
using TaleWorlds.Localization.TextProcessor;

namespace TaleWorlds.Localization.Expressions;

internal class TextIdExpression : TextExpression
{
	internal override TokenType TokenType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextIdExpression(string innerText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal override string EvaluateString(TextProcessingContext context, TextObject parent)
	{
		throw null;
	}
}
