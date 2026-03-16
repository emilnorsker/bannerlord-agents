using System.Runtime.CompilerServices;
using TaleWorlds.Localization.TextProcessor;

namespace TaleWorlds.Localization.Expressions;

internal abstract class TextExpression
{
	internal abstract TokenType TokenType { get; }

	internal string RawValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	internal abstract string EvaluateString(TextProcessingContext context, TextObject parent);

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int EvaluateAsNumber(TextExpression exp, TextProcessingContext context, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected TextExpression()
	{
		throw null;
	}
}
