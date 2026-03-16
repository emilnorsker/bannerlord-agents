using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Library;
using TaleWorlds.Localization.TextProcessor;

namespace TaleWorlds.Localization;

public static class LocalizedTextManager
{
	public const string LanguageDataFileName = "language_data";

	public const string DefaultEnglishLanguageId = "English";

	private static readonly Dictionary<string, string> _gameTextDictionary;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTranslatedText(string languageId, string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<string> GetLanguageIds(bool developmentMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetLanguageTitle(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LanguageSpecificTextProcessor CreateTextProcessorForLanguage(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddLanguageTest(string id, string processor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetLanguageIndex(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LoadLocalizationXmls(string[] loadedModules)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddLocalizationXml(string newModule)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetDateFormattedByLanguage(string languageCode, DateTime dateTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTimeFormattedByLanguage(string languageCode, DateTime dateTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetSubtitleExtensionOfLanguage(string languageId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetLocalizationCodeOfISOLanguageCode(string isoLanguageCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static CultureInfo GetCultureInfo(string languageId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LanguageData GetLanguageData(string languageId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static XmlDocument LoadXmlFile(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LoadLanguage(string languageId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void LoadLanguage(LanguageData language)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void DeserializeStrings(XmlNode node, string languageId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("change_language", "localization")]
	public static string ChangeLanguage(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("reload_texts", "localization")]
	public static string ReloadTexts(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("check_for_errors", "localization")]
	public static string CheckValidity(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckValidity(string id, string text, out string errorLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LocalizedTextManager()
	{
		throw null;
	}
}
