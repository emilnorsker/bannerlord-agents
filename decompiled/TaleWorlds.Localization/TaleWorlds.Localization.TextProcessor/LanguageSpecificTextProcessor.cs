using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Localization.TextProcessor;

public abstract class LanguageSpecificTextProcessor
{
	private List<int> _lowerMarkers;

	public abstract CultureInfo CultureInfoForLanguage { get; }

	public abstract void ProcessToken(string sourceText, ref int cursorPos, string token, StringBuilder outputString);

	public abstract void ClearTemporaryData();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LanguageSpecificTextProcessor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string Process(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessTokenInternal(string sourceText, ref int cursorPos, string token, StringBuilder outputString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessLowerCaseMarkers(StringBuilder stringBuilder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int FindNextLetter(string sourceText, int cursorPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsPostProcessToken(string token)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string ReadFirstToken(string text, ref int i)
	{
		throw null;
	}
}
