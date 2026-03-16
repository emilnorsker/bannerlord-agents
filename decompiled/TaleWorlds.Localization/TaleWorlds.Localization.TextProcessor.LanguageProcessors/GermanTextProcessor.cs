using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Localization.TextProcessor.LanguageProcessors;

public class GermanTextProcessor : LanguageSpecificTextProcessor
{
	private enum WordGenderEnum
	{
		Masculine,
		Feminine,
		Neuter,
		Plural,
		NoDeclination
	}

	private static class NounTokens
	{
		public const string Nominative = ".n";

		public const string Accusative = ".a";

		public const string Genitive = ".g";

		public const string Dative = ".d";

		public const string NominativePlural = ".np";

		public const string AccusativePlural = ".ap";

		public const string GenitivePlural = ".gp";

		public const string DativePlural = ".dp";

		public static readonly string[] TokenList;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static NounTokens()
		{
			throw null;
		}
	}

	private static class AdjectiveTokens
	{
		public const string WeakNominative = ".wn";

		public const string MixedNominative = ".mn";

		public const string StrongNominative = ".sn";

		public const string WeakAccusative = ".wa";

		public const string MixedAccusative = ".ma";

		public const string StrongAccusative = ".sa";

		public const string WeakDative = ".wd";

		public const string MixedDative = ".md";

		public const string StrongDative = ".sd";

		public const string WeakGenitive = ".wg";

		public const string MixedGenitive = ".mg";

		public const string StrongGenitive = ".sg";

		public const string WeakNominativePlural = ".wnp";

		public const string MixedNominativePlural = ".mnp";

		public const string StrongNominativePlural = ".snp";

		public const string WeakAccusativePlural = ".wap";

		public const string MixedAccusativePlural = ".map";

		public const string StrongAccusativePlural = ".sap";

		public const string WeakDativePlural = ".wdp";

		public const string MixedDativePlural = ".mdp";

		public const string StrongDativePlural = ".sdp";

		public const string WeakGenitivePlural = ".wgp";

		public const string MixedGenitivePlural = ".mgp";

		public const string StrongGenitivePlural = ".sgp";

		public static readonly string[] TokenList;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static AdjectiveTokens()
		{
			throw null;
		}
	}

	private static class PronounAndArticleTokens
	{
		public const string Nominative = ".pn";

		public const string Accusative = ".pa";

		public const string Genitive = ".pg";

		public const string Dative = ".pd";

		public const string NominativePlural = ".pnp";

		public const string AccusativePlural = ".pap";

		public const string GenitivePlural = ".pgp";

		public const string DativePlural = ".pdp";

		public static readonly string[] TokenList;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static PronounAndArticleTokens()
		{
			throw null;
		}
	}

	private static class GenderTokens
	{
		public const string Masculine = ".M";

		public const string Feminine = ".F";

		public const string Neuter = ".N";

		public const string Plural = ".P";

		public static readonly string[] TokenList;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static GenderTokens()
		{
			throw null;
		}
	}

	private static class WordGroupTokens
	{
		public const string NounNominative = ".nn";

		public const string PronounAndArticleNominative = ".pngroup";

		public const string AdjectiveNominativeWeak = ".ajw";

		public const string AdjectiveNominativeMixed = ".ajm";

		public const string AdjectiveNominativeStrong = ".ajs";

		public const string NounNominativeWithBrackets = "{.nn}";

		public const string PronounAndArticleNominativeWithBrackets = "{.pngroup}";

		public const string AdjectiveNominativeWeakWithBrackets = "{.ajw}";

		public const string AdjectiveNominativeMixedWithBrackets = "{.ajm}";

		public const string AdjectiveNominativeStrongWithBrackets = "{.ajs}";

		public const string NounNominativePlural = ".nnp";

		public const string PronounAndArticleNominativePlural = ".pnpgroup";

		public const string AdjectiveNominativeWeakPlural = ".ajwp";

		public const string AdjectiveNominativeMixedPlural = ".ajmp";

		public const string AdjectiveNominativeStrongPlural = ".ajsp";

		public const string NounNominativePluralWithBrackets = "{.nnp}";

		public const string PronounAndArticleNominativePluralWithBrackets = "{.pnpgroup}";

		public const string AdjectiveNominativeWeakPluralWithBrackets = "{.ajwp}";

		public const string AdjectiveNominativeMixedPluralWithBrackets = "{.ajmp}";

		public const string AdjectiveNominativeStrongPluralWithBrackets = "{.ajsp}";

		public static readonly string[] TokenList;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static WordGroupTokens()
		{
			throw null;
		}
	}

	private static class OtherTokens
	{
		public const string PossessionToken = ".o";
	}

	private struct DictionaryWord
	{
		public readonly string Nominative;

		public readonly string NominativePlural;

		public readonly string Accusative;

		public readonly string Genitive;

		public readonly string Dative;

		public readonly string AccusativePlural;

		public readonly string GenitivePlural;

		public readonly string DativePlural;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DictionaryWord(string nominative, string nominativePlural, string genitive, string genitivePlural, string dative, string dativePlural, string accusative, string accusativePlural)
		{
			throw null;
		}
	}

	private static readonly CultureInfo CultureInfo;

	[ThreadStatic]
	private static WordGenderEnum _curGender;

	[ThreadStatic]
	private static List<(string wordGroup, int firstMarkerPost)> _wordGroups;

	[ThreadStatic]
	private static List<string> _wordGroupsNoTags;

	[ThreadStatic]
	private static List<string> _linkList;

	[ThreadStatic]
	private static bool _doesComeFromWordGroup;

	private static char[] Vowels;

	private const string Consonants = "BbCcDdFfGgHhJjKkLlMmNnPpRrSsTtWwYyZz";

	private static char[] SSounds;

	private static readonly Dictionary<char, List<DictionaryWord>> IrregularMasculineDictionary;

	private static readonly Dictionary<char, List<DictionaryWord>> IrregularFeminineDictionary;

	private static readonly Dictionary<char, List<DictionaryWord>> IrregularNeuterDictionary;

	private static readonly Dictionary<char, List<DictionaryWord>> IrregularPluralDictionary;

	private static readonly Dictionary<string, Dictionary<WordGenderEnum, DictionaryWord>> PronounArticleDictionary;

	private static readonly Dictionary<string, Dictionary<string, string>> ArticlePronounReplacementDictionary;

	private static readonly Dictionary<char, List<string>> DoNotDeclineList;

	public override CultureInfo CultureInfoForLanguage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool Masculine
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool Feminine
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool Neuter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool Plural
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static List<(string wordGroup, int firstMarkerPost)> WordGroups
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static List<string> LinkList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static List<string> WordGroupsNoTags
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

	private int LinkEndingLength
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ClearTemporaryData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ProcessToken(string sourceText, ref int cursorPos, string token, StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePossession(StringBuilder outputString, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixWordGroup(string token, int wordGroupIndex, StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsWordGroup(int tokenLength, string sourceText, int curPos, out int wordGroupIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixNounNominativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixNounGenitive(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixNounGenitivePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixNounDative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixNounDativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixNounAccusative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixNounAccusativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixWeakNominative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixMixedNominative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixStrongNominative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixWeakAccusative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixMixedAccusative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixStrongAccusative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixWeakDative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixMixedDative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixStrongDative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixWeakGenitive(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixMixedGenitive(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixStrongGenitive(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixWeakNominativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixMixedNominativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixStrongNominativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixStrongAccusativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixMixedDativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixStrongDativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AddSuffixForNDeclension(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPronounArticle(string sourceText, int cursorPos, string token, ref StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetPreviousWord(string sourceText, int cursorPos, string token, ref StringBuilder outputString)
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
	private bool IsVowel(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int FindLastVowel(StringBuilder outputText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveLastCharacter(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsLastCharVowel(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ModifyAdjective(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetVowelEnding(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsLink(string sourceText, int tokenLength, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ShouldDeclineWord(string sourceText, int cursorPos, string token)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsIrregularWord(string sourceText, int cursorPos, string token, out string irregularWord, out int lengthOfWordToReplace)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsRecordedWithPreviousTag(string sourceText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WordGroupProcessor(string sourceText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string DictionaryWordWithCase(string token, DictionaryWord dictionaryWord)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static char GetLastCharacter(StringBuilder outputText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static char GetLastCharacter(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static char GetSecondLastCharacter(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetEnding(StringBuilder outputString, int numChars)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GermanTextProcessor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GermanTextProcessor()
	{
		throw null;
	}
}
