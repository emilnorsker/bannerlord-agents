using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class InquiryData
{
	public string TitleText;

	public string Text;

	public readonly float ExpireTime;

	public readonly bool IsAffirmativeOptionShown;

	public readonly bool IsNegativeOptionShown;

	public readonly string AffirmativeText;

	public readonly string NegativeText;

	public readonly string SoundEventPath;

	public readonly Action AffirmativeAction;

	public readonly Action NegativeAction;

	public readonly Action TimeoutAction;

	public readonly Func<(bool, string)> GetIsAffirmativeOptionEnabled;

	public readonly Func<(bool, string)> GetIsNegativeOptionEnabled;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InquiryData(string titleText, string text, bool isAffirmativeOptionShown, bool isNegativeOptionShown, string affirmativeText, string negativeText, Action affirmativeAction, Action negativeAction, string soundEventPath = "", float expireTime = 0f, Action timeoutAction = null, Func<(bool, string)> isAffirmativeOptionEnabled = null, Func<(bool, string)> isNegativeOptionEnabled = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetText(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTitleText(string titleText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasSameContentWith(object other)
	{
		throw null;
	}
}
