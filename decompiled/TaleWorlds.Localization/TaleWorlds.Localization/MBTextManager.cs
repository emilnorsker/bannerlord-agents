using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using TaleWorlds.Localization.TextProcessor;

namespace TaleWorlds.Localization;

public static class MBTextManager
{
	public const string LinkAttribute = "LINK";

	internal const string LinkTag = ".link";

	internal const int LinkTagLength = 7;

	internal const string LinkEnding = "</b></a>";

	internal const int LinkEndingLength = 8;

	internal const string LinkStarter = "<a style=\"Link.";

	private const string CommentRegexPattern = "{%.+?}";

	private const string AnimationTagsRegexPattern = "\\[.+\\]";

	private static readonly TextProcessingContext TextContext;

	private static LanguageSpecificTextProcessor _languageProcessor;

	private static string _activeVoiceLanguageId;

	private static string _activeTextLanguageId;

	private static int _activeTextLanguageIndex;

	[ThreadStatic]
	private static StringBuilder _idStringBuilder;

	[ThreadStatic]
	private static StringBuilder _targetStringBuilder;

	private static readonly Regex CommentRemoverRegex;

	private static readonly Regex AnimationTagRemoverRegex;

	internal static readonly Tokenizer Tokenizer;

	public static string ActiveTextLanguage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool LocalizationDebugMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LanguageExistsInCurrentConfiguration(string language, bool developmentMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ChangeLanguage(string language)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetActiveTextLanguageIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryChangeVoiceLanguage(string language)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TextObject ProcessNumber(object integer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string ProcessTextToString(TextObject to, bool shouldClear)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string ProcessWithoutLanguageProcessor(TextObject to)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string Process(string query, TextObject parent = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetTextVariable(string variableName, string text, bool sendClients = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetTextVariable(string variableName, TextObject text, bool sendClients = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetTextVariable(string variableName, int content)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetTextVariable(string variableName, float content, int decimalDigits = 2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetTextVariable(string variableName, object content)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetTextVariable(string variableName, int arrayIndex, object content)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetFunction(string funcName, string functionBody)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ResetFunctions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ThrowLocalizationError(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string GetLocalizedText(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string RemoveComments(string localizedText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string DiscardAnimationTagsAndCheckAnimationTagPositions(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string DiscardAnimationTags(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckAnimationTagPositions(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string[] GetConversationAnimations(TextObject to)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryGetVoiceObject(TextObject to, out VoiceObject vo, out string vocalizationId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static VoiceObject ProcessTextForVocalization(TextObject to, out string vocalizationId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetLocalizationId(TextObject to)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MBTextManager()
	{
		throw null;
	}
}
