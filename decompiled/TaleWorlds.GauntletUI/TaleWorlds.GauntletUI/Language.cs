using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public class Language : ILanguage
{
	private readonly Dictionary<string, Font> _fontMap;

	public char[] ForbiddenStartOfLineCharacters
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

	public char[] ForbiddenEndOfLineCharacters
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

	public string LanguageID
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

	public string DefaultFontName
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

	public bool DoesFontRequireSpaceForNewline
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

	public Font DefaultFont
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

	public char LineSeperatorChar
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
	public bool FontMapHasKey(string keyFontName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Font GetMappedFont(string keyFontName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Language()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Language CreateFrom(XmlNode languageNode, FontFactory fontFactory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerable<char> ILanguage.GetForbiddenStartOfLineCharacters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerable<char> ILanguage.GetForbiddenEndOfLineCharacters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool ILanguage.IsCharacterForbiddenAtStartOfLine(char character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool ILanguage.IsCharacterForbiddenAtEndOfLine(char character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	string ILanguage.GetLanguageID()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	string ILanguage.GetDefaultFontName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Font ILanguage.GetDefaultFont()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	char ILanguage.GetLineSeperatorChar()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool ILanguage.DoesLanguageRequireSpaceForNewline()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool ILanguage.FontMapHasKey(string keyFontName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Font ILanguage.GetMappedFont(string keyFontName)
	{
		throw null;
	}
}
