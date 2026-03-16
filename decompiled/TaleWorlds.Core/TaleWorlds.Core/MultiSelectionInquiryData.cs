using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MultiSelectionInquiryData
{
	public readonly string TitleText;

	public readonly string DescriptionText;

	public readonly List<InquiryElement> InquiryElements;

	public readonly bool IsExitShown;

	public readonly int MaxSelectableOptionCount;

	public readonly int MinSelectableOptionCount;

	public readonly string SoundEventPath;

	public readonly string AffirmativeText;

	public readonly string NegativeText;

	public readonly Action<List<InquiryElement>> AffirmativeAction;

	public readonly Action<List<InquiryElement>> NegativeAction;

	public readonly bool IsSeachAvailable;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiSelectionInquiryData(string titleText, string descriptionText, List<InquiryElement> inquiryElements, bool isExitShown, int minSelectableOptionCount, int maxSelectableOptionCount, string affirmativeText, string negativeText, Action<List<InquiryElement>> affirmativeAction, Action<List<InquiryElement>> negativeAction, string soundEventPath = "", bool isSeachAvailable = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasSameContentWith(object other)
	{
		throw null;
	}
}
