using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class ProfanityChecker
{
	public enum ProfanityChechkerType
	{
		FalsePositive,
		FalseNegative
	}

	private readonly string[] ProfanityList;

	private readonly string[] AllowList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ProfanityChecker(string[] profanityList, string[] allowList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsProfane(string word)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsProfanity(string text, ProfanityChechkerType checkType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string CensorText(string text)
	{
		throw null;
	}
}
