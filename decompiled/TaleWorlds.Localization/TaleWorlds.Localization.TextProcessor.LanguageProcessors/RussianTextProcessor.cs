using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Localization.TextProcessor.LanguageProcessors;

public class RussianTextProcessor : LanguageSpecificTextProcessor
{
	private enum WordGenderEnum
	{
		MasculineInanimate,
		MasculineAnimate,
		FeminineInanimate,
		FeminineAnimate,
		NeuterInanimate,
		NeuterAnimate,
		NoDeclination
	}

	private static class NounTokens
	{
		public const string Nominative = ".n";

		public const string NominativePlural = ".p";

		public const string Accusative = ".a";

		public const string Genitive = ".g";

		public const string Instrumental = ".i";

		public const string Locative = ".l";

		public const string Dative = ".d";

		public const string AccusativePlural = ".ap";

		public const string GenitivePlural = ".gp";

		public const string InstrumentalPlural = ".ip";

		public const string LocativePlural = ".lp";

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
		public const string Nominative = ".j";

		public const string NominativePlural = ".jp";

		public const string Accusative = ".ja";

		public const string Genitive = ".jg";

		public const string Instrumental = ".ji";

		public const string Locative = ".jl";

		public const string Dative = ".jd";

		public const string AccusativePlural = ".jap";

		public const string GenitivePlural = ".jgp";

		public const string InstrumentalPlural = ".jip";

		public const string LocativePlural = ".jlp";

		public const string DativePlural = ".jdp";

		public static readonly string[] TokenList;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static AdjectiveTokens()
		{
			throw null;
		}
	}

	private static class GenderTokens
	{
		public const string MasculineAnimate = ".MA";

		public const string MasculineInanimate = ".MI";

		public const string FeminineAnimate = ".FA";

		public const string FeminineInanimate = ".FI";

		public const string NeuterAnimate = ".NA";

		public const string NeuterInanimate = ".NI";

		public static readonly string[] TokenList;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static GenderTokens()
		{
			throw null;
		}
	}

	private static class WordGroupTokens
	{
		public const string NounNominativePlural = ".nnp";

		public const string NounNominative = ".nn";

		public const string AdjectiveNominativePlural = ".ajp";

		public const string AdjectiveNominative = ".aj";

		public const string NounNominativePluralWithBrackets = "{.nnp}";

		public const string NounNominativeWithBrackets = "{.nn}";

		public const string AdjectiveNominativePluralWithBrackets = "{.ajp}";

		public const string AdjectiveNominativeWithBrackets = "{.aj}";
	}

	private struct IrregularWord
	{
		public readonly string Nominative;

		public readonly string NominativePlural;

		public readonly string Accusative;

		public readonly string Genitive;

		public readonly string Instrumental;

		public readonly string Locative;

		public readonly string Dative;

		public readonly string AccusativePlural;

		public readonly string GenitivePlural;

		public readonly string InstrumentalPlural;

		public readonly string LocativePlural;

		public readonly string DativePlural;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public IrregularWord(string nominative, string nominativePlural, string genitive, string genitivePlural, string dative, string dativePlural, string accusative, string accusativePlural, string instrumental, string instrumentalPlural, string locative, string locativePlural)
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

	private static readonly char[] _vowels;

	private static readonly char[] _sibilants;

	private static readonly char[] _velars;

	private static readonly string[] _nounTokens;

	private static readonly Dictionary<char, List<IrregularWord>> _irregularMasculineAnimateDictionary;

	private static readonly Dictionary<char, List<IrregularWord>> _irregularMasculineInanimateDictionary;

	private static readonly Dictionary<char, List<IrregularWord>> _irregularFeminineAnimateDictionary;

	private static readonly Dictionary<char, List<IrregularWord>> _irregularFeminineInanimateDictionary;

	private static readonly Dictionary<char, List<IrregularWord>> _irregularNeuterAnimateDictionary;

	private static readonly Dictionary<char, List<IrregularWord>> _irregularNeuterInanimateDictionary;

	private const string Consonants = "БбВвГгДдЖжЗзЙйКкЛлМмНнПпРрСсТтФфХхЦцЧчШшЩщЬьЪъ";

	private static Dictionary<string, Dictionary<string, string>> exceptions;

	public override CultureInfo CultureInfoForLanguage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool MasculineAnimate
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool MasculineInanimate
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

	private bool FeminineAnimate
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool FeminineInanimate
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

	private bool NeuterInanimate
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool NeuterAnimate
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool Animate
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

	private static List<string> WordGroupsNoTags
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
	private static char GetLastCharacter(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetEnding(StringBuilder outputString, int numChars)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ProcessToken(string sourceText, ref int cursorPos, string token, StringBuilder outputString)
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
	private void AddSuffixNounInstrumental(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixNounInstrumentalPlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixNounLocative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixNounLocativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveNominative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveNominativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveGenitive(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveGenitivePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveDative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveDativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveAccusative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveAccusativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveInstrumental(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveInstrumentalPlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveLocative(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffixAdjectiveLocativePlural(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetFeminineAnimate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetFeminineInanimate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNeuterInanimate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNeuterAnimate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMasculineAnimate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMasculineInanimate()
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
	private bool IsLink(string sourceText, int tokenLength, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsIrregularWord(string sourceText, int cursorPos, string token, out string irregularWord, out int lengthOfWordToReplace)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsVowel(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsVelarOrSibilant(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsSoftStemAdjective(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsConsonant(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string IrregularWordWithCase(string token, IrregularWord irregularWord)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string PrepareNounCheckString(string noun)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string PrepareAdjectiveCheckString(string adj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string[] GetProcessedNouns(string str, string gender, string[] tokens = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RussianTextProcessor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static RussianTextProcessor()
	{
		throw null;
	}
}
