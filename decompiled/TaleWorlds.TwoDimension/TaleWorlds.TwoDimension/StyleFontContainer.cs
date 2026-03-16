using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

public class StyleFontContainer
{
	public struct FontData
	{
		public Font Font;

		public float FontSize;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FontData(Font font, float fontSize)
		{
			throw null;
		}
	}

	private readonly Dictionary<string, FontData> _styleFonts;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StyleFontContainer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add(string style, Font font, float fontSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FontData GetFontData(string style)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearFonts()
	{
		throw null;
	}
}
