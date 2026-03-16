using System.Runtime.CompilerServices;
using TaleWorlds.Localization.TextProcessor;

namespace TaleWorlds.Localization.Expressions;

internal class QualifiedIdentifierExpression : TextExpression
{
	private readonly string _identifierName;

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
	public QualifiedIdentifierExpression(string identifierName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal override string EvaluateString(TextProcessingContext context, TextObject parent)
	{
		throw null;
	}
}
