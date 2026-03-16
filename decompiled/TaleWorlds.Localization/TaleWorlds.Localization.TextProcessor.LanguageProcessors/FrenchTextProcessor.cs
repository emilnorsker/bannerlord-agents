using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Localization.TextProcessor.LanguageProcessors;

public class FrenchTextProcessor : LanguageSpecificTextProcessor
{
	private enum WordGenderEnum
	{
		Masculine,
		Feminine,
		Neuter,
		NoDeclination
	}

	private enum WordType
	{
		StartingWithaVowel,
		Masculine,
		Feminine,
		Plural,
		None
	}

	private static class GenderTokens
	{
		public const string Masculine = ".M";

		public const string Feminine = ".F";

		public const string Neuter = ".N";

		public const string Plural = ".P";

		public const string Singular = ".S";

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

		public const string DefiniteArticleWithBrackets = "{.l}";

		public const string IndefiniteArticle = ".a";

		public const string APreposition = ".c";

		public const string APrepositionFollowedByDefiniteArticle = ".cl";

		public const string DePreposition = ".d";

		public const string DePrepositionFollowedByDefiniteArticle = ".dl";

		public static readonly List<string> TokenList;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static FunctionTokens()
		{
			throw null;
		}
	}

	private static char[] Vowels;

	[ThreadStatic]
	private static Dictionary<string, (string, int, bool)> _wordGroups;

	[ThreadStatic]
	private static WordGenderEnum _curGender;

	[ThreadStatic]
	private static bool _isPlural;

	private static List<string> _articles;

	private static string _articleVowelStart;

	private static string _dePreposition;

	private static string _dePrepositionWithVowel;

	private static string _aPreposition;

	private static readonly Dictionary<string, Dictionary<string, string>> Contractions;

	private static Dictionary<WordType, string> _genderToDefiniteArticle;

	private static Dictionary<WordType, string> _genderToIndefiniteArticle;

	private static List<string> _shouldBeConsideredConsonants;

	private static readonly CultureInfo CultureInfo;

	public static Dictionary<string, (string, int, bool)> WordGroups
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

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
	private bool IsWordGroup(string sourceText, string token, int cursorPos, out (string, bool) tags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckNextCharIsVowel(string sourceText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckWhiteSpaceAndTextEnd(string sourceText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetFeminine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNeuter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMasculine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetPlural()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSingular()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleDefiniteArticles(string text, string token, int cursorPos, StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetDefiniteArticle(string text, string token, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleIndefiniteArticles(string text, string token, int cursorPos, StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleAPreposition(string text, string token, ref int cursorPos, StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetAPreposition(string text, string token, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleAPrepositionFollowedByDefiniteArticle(string text, string token, ref int cursorPos, StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleDePrepositionFollowedByArticle(string text, string token, ref int cursorPos, StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetDePreposition(string text, string token, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleDePreposition(string text, string token, ref int cursorPos, StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfNextWordShouldBeConsideredAConsonant(string text, string token, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfWordsHaveContraction(string t1, string t2, out string result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfWordIsAnArticle(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetNextWord(string text, string token, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WordType GetWordTypeFromGender(WordGenderEnum gender)
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
	private void ResetGender()
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
	public FrenchTextProcessor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FrenchTextProcessor()
	{
		throw null;
	}
}
