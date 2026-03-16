using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace TaleWorlds.Localization.TextProcessor;

internal class TokenDefinition
{
	private readonly Regex _regex;

	public TokenType TokenType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public int Precedence
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TokenDefinition(TokenType tokenType, string regexPattern, int precedence)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Match CheckMatch(string str, int beginIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int SkipWhiteSpace(string str, int beginIndex)
	{
		throw null;
	}
}
