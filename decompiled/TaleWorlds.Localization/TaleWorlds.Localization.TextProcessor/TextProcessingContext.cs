using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization.Expressions;

namespace TaleWorlds.Localization.TextProcessor;

public class TextProcessingContext
{
	private readonly Dictionary<string, TextObject> _variables;

	private readonly Dictionary<string, MBTextModel> _functions;

	private readonly Stack<TextObject[]> _curParams;

	private readonly Stack<TextObject[]> _curParamsWithoutEvaluate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetTextVariable(string variableName, TextObject data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal TextObject GetRawTextVariable(string variableName, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MultiStatement GetVariableValue(string variableName, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal (TextObject, bool) GetVariableValueAsTextObject(string variableName, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MultiStatement GetArrayAccess(string variableName, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CountMarkerOccurancesInString(string searchedIdentifier, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal string GetParameterWithMarkerOccurance(string token, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal string GetParameterWithMarkerOccurances(string token, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool IsDeclaration(string token)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool IsLinkToken(string token)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool IsDeclarationFinalizer(string token)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TextObject FindNestedFieldValue(string text, string identifier, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal (TextObject value, bool doesValueExist) GetQualifiedVariableValue(string token, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetFieldValue(string text, string[] fieldNames, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetFieldValuesFromLinks(string[] fieldNames, TextObject value, ref MBStringBuilder targetString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string ReadFirstToken(string text, ref int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal TextObject CallFunction(string functionName, List<TextExpression> functionParams, TextObject parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFunction(string functionName, MBTextModel functionBody)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetFunctions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBTextModel GetFunctionBody(string functionName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetFunctionParam(string rawValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetFunctionParamWithoutEvaluate(string rawValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ClearAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextProcessingContext()
	{
		throw null;
	}
}
