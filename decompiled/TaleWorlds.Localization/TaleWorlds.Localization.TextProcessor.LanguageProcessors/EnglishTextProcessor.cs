using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Localization.TextProcessor.LanguageProcessors;

public class EnglishTextProcessor : LanguageSpecificTextProcessor
{
	private Dictionary<string, string> IrregularNouns;

	private string[] Sibilants;

	private const string Vowels = "aeiouAEIOU";

	private const string Consonants = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";

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
	private char GetLastCharacter(StringBuilder outputText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleApostrophe(StringBuilder outputString, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckNextCharIsVowel(string sourceText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleIrregularNouns(string text, out string resultPlural)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool Handle_ves_Suffix(string text, out string resultPlural)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool Handle_ies_Suffix(string text, out string resultPlural)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool Handle_es_Suffix(string text, out string resultPlural)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool Handle_s_Suffix(string text, out string resultPlural)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ClearTemporaryData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EnglishTextProcessor()
	{
		throw null;
	}
}
