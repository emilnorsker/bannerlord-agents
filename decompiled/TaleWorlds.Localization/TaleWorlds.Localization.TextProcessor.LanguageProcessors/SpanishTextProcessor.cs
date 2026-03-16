using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Localization.TextProcessor.LanguageProcessors;

public class SpanishTextProcessor : LanguageSpecificTextProcessor
{
	private enum WordGenderEnum
	{
		MasculineSingular,
		MasculinePlural,
		FeminineSingular,
		FemininePlural,
		NeuterSingular,
		NeuterPlural,
		NoDeclination
	}

	private static class GenderTokens
	{
		public const string MasculineSingular = ".MS";

		public const string MasculinePlural = ".MP";

		public const string FeminineSingular = ".FS";

		public const string FemininePlural = ".FP";

		public const string NeuterSingular = ".NS";

		public const string NeuterPlural = ".NP";

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

		public const string DefiniteArticleInUpperCase = ".L";
	}

	[ThreadStatic]
	private static WordGenderEnum _curGender;

	private static readonly Dictionary<string, Dictionary<string, string>> Contractions;

	private static Dictionary<WordGenderEnum, string> _genderToDefiniteArticle;

	private static readonly CultureInfo CultureInfo;

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
	private bool CheckWhiteSpaceAndTextEnd(string sourceText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetGender(string token)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleDefiniteArticles(string text, string token, int cursorPos, StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleContractions(string text, string article, int cursorPos, out string newVersion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetPreviousWord(string sourceText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ClearTemporaryData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpanishTextProcessor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SpanishTextProcessor()
	{
		throw null;
	}
}
