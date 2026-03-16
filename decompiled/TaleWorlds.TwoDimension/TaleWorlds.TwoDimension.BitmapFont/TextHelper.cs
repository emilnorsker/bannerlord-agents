using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension.BitmapFont;

internal static class TextHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int GetIndexOfFirstAppropriateCharacterToMoveToNextLineBackwardsFromIndex(List<TextToken> tokens, int startIndex, ILanguage currentLanguage, bool canBreakInZeroWidthSpace = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int GetIndexOfFirstAppropriateCharacterToMoveToNextLineForwardsFromIndex(List<TextToken> tokens, int startIndex, ILanguage currentLanguage, bool canBreakInZeroWidthSpace = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static float GetTotalWordWidthBetweenIndices(int startIndex, int endIndex, List<TextToken> tokens, Func<TextToken, Font> getFontForToken, float extraPadding, float requiredFontSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool IsTokenEqualToSeparatorChar(TextToken token, ILanguage currentLanguage)
	{
		throw null;
	}
}
