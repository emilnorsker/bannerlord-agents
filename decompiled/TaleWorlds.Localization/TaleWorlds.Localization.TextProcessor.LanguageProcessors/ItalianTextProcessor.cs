using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Localization.TextProcessor.LanguageProcessors;

public class ItalianTextProcessor : LanguageSpecificTextProcessor
{
	private enum WordType
	{
		Vowel,
		SpecialConsonant,
		Consonant,
		Other
	}

	private enum WordGenderEnum
	{
		MasculineSingular,
		MasculinePlural,
		FeminineSingular,
		FemininePlural,
		MaleNoun,
		FemaleNoun,
		NoDeclination
	}

	private enum Prepositions
	{
		To,
		Of,
		From,
		In,
		On
	}

	private static class GenderTokens
	{
		public const string MasculineSingular = ".MS";

		public const string MasculinePlural = ".MP";

		public const string FeminineSingular = ".FS";

		public const string FemininePlural = ".FP";

		public const string MaleNoun = ".MN";

		public const string FemaleNoun = ".FN";

		public static readonly List<string> TokenList;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static GenderTokens()
		{
			throw null;
		}
	}

	private static class FunctionTokens
	{
		public const string DefiniteArticle = ".l";

		public const string IndefiniteArticle = ".un";

		public const string OfPreposition = ".di";

		public const string ToPreposition = ".a";

		public const string FromPreposition = ".da";

		public const string OnPreposition = ".su";

		public const string InPreposition = ".in";

		public static readonly List<string> TokenList;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static FunctionTokens()
		{
			throw null;
		}
	}

	private static char[] Vowels;

	private static char[] SpecialConsonantBeginnings;

	private static string[] SpecialConsonants;

	private static char[] Consonants;

	[ThreadStatic]
	private static WordGenderEnum _curGender;

	[ThreadStatic]
	private static Dictionary<string, (string, int)> _wordGroups;

	private static Dictionary<Prepositions, Dictionary<WordGenderEnum, Dictionary<WordType, string>>> _prepositionDictionary;

	private static Dictionary<WordGenderEnum, Dictionary<WordType, string>> _genderWordTypeDefiniteArticleDictionary;

	private static Dictionary<WordGenderEnum, Dictionary<WordType, string>> _genderWordTypeIndefiniteArticleDictionary;

	private static readonly CultureInfo CultureInfo;

	private string LinkTag
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int LinkTagLength
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private string LinkStarter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private string LinkEnding
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Dictionary<string, (string, int)> WordGroups
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override CultureInfo CultureInfoForLanguage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ProcessToken(string sourceText, ref int cursorPos, string token, StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsWordGroup(string sourceText, string token, int cursorPos, out string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WordType GetNextWordType(string sourceText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckWhiteSpaceAndTextEnd(string sourceText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleOnPrepositions(string text, string token, int cursorPos, StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleInPrepositions(string text, string token, int cursorPos, StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleOfPrepositions(string text, string token, int cursorPos, StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleToPrepositions(string text, string token, int cursorPos, StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleFromPrepositions(string text, string token, int cursorPos, StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePrepositionsInternal(string text, string token, int cursorPos, Dictionary<WordGenderEnum, Dictionary<WordType, string>> dictionary, StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleDefiniteArticles(string text, string token, int cursorPos, StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleIndefiniteArticles(string text, string token, int cursorPos, StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetGenderInfo(string token)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessWordGroup(string text, string token, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int ProcessLink(string text, int cursorPos, string token, StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ClearTemporaryData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItalianTextProcessor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ItalianTextProcessor()
	{
		throw null;
	}
}
