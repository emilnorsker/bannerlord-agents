using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class TextInquiryData
{
	public string TitleText;

	public string Text;

	public readonly bool IsAffirmativeOptionShown;

	public readonly bool IsNegativeOptionShown;

	public readonly bool IsInputObfuscated;

	public readonly string AffirmativeText;

	public readonly string NegativeText;

	public readonly string SoundEventPath;

	public readonly string DefaultInputText;

	public readonly Action<string> AffirmativeAction;

	public readonly Action NegativeAction;

	public readonly Func<string, Tuple<bool, string>> TextCondition;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextInquiryData(string titleText, string text, bool isAffirmativeOptionShown, bool isNegativeOptionShown, string affirmativeText, string negativeText, Action<string> affirmativeAction, Action negativeAction, bool shouldInputBeObfuscated = false, Func<string, Tuple<bool, string>> textCondition = null, string soundEventPath = "", string defaultInputText = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasSameContentWith(object other)
	{
		throw null;
	}
}
