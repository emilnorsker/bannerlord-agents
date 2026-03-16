using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public class FontFactory
{
	private Language _currentLangugage;

	private readonly Dictionary<string, Font> _bitmapFonts;

	private readonly ResourceDepot _resourceDepot;

	private readonly Dictionary<string, Language> _fontLanguageMap;

	private SpriteData _latestSpriteData;

	public Language DefaultLanguage
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

	public Language CurrentLanguage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public Font DefaultFont
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FontFactory(ResourceDepot resourceDepot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnResourceChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadAllFonts(SpriteData spriteData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryAddFontDefinition(string fontPath, string fontName, SpriteData spriteData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadLocalizationValues(string sourceXMLPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Font GetFont(string fontName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<Font> GetFonts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetFontName(Font font)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Font GetMappedFontForLocalization(string englishFontName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnLanguageChange(string newLanguageCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Font GetUsableFontForCharacter(int characterCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckForUpdates()
	{
		throw null;
	}
}
