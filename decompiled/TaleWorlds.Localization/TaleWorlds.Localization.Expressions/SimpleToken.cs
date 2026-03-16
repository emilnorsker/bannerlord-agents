using System.Runtime.CompilerServices;
using TaleWorlds.Localization.TextProcessor;

namespace TaleWorlds.Localization.Expressions;

internal class SimpleToken : TextExpression
{
	public static readonly SimpleToken SequenceTerminator;

	private readonly TokenType _tokenType;

	internal override TokenType TokenType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SimpleToken(TokenType tokenType, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal override string EvaluateString(TextProcessingContext context, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SimpleToken()
	{
		throw null;
	}
}
