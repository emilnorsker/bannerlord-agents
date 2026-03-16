using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Localization.TextProcessor.LanguageProcessors;

public class TurkishTextProcessor : LanguageSpecificTextProcessor
{
	private static CultureInfo _curCultureInfo;

	private static char[] Vowels;

	private static char[] BackVowels;

	private static int[] BackNumbers;

	private static char[] FrontVowels;

	private static char[] OpenVowels;

	private static char[] ClosedVowels;

	private static char[] Consonants;

	private static char[] UnvoicedConsonants;

	private static char[] HardUnvoicedConsonants;

	private static string[] NonMutatingWord;

	private static Dictionary<string, char> _exceptions;

	[ThreadStatic]
	private static List<string> _linkList;

	private static CultureInfo _cultureInfo;

	public static List<string> LinkList
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
	private bool IsVowel(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private char GetNextVowel(StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private char GetNextVowel(int number)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsFrontVowel(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsClosedVowel(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsConsonant(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsUnvoicedConsonant(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHardUnvoicedConsonant(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private char FrontVowelToBackVowel(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private char OpenVowelToClosedVowel(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private char HardConsonantToSoftConsonant(char c)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private char GetLastVowel(StringBuilder outputText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ProcessToken(string sourceText, ref int cursorPos, string token, StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_im(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_sin(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_dir(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_iz(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_siniz(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_dirler(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_i(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_e(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_de(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_den(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_nin(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_ler(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_m(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_n(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_in(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_si(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_miz(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_niz(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSuffix_leri(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private char GetHarmonizedD(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddYIfNeeded(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SoftenLastCharacter(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetLastWord(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool LastWordNonMutating(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private char GetLastCharacter(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private char GetLastLetter(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private char GetSecondLastLetter(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private char GetSecondLastCharacter(StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsLink(string sourceText, int tokenLength, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ClearTemporaryData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TurkishTextProcessor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static TurkishTextProcessor()
	{
		throw null;
	}
}
