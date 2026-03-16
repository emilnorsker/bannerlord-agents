using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.Core;

public static class GameTexts
{
	public class GameTextHelper
	{
		private string _id;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GameTextHelper(string id)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GameTextHelper Variation(string text, params object[] propertiesAndWeights)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TextObject MergeTextObjectsWithComma(List<TextObject> textObjects, bool includeAnd)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TextObject MergeTextObjectsWithSymbol(List<TextObject> textObjects, TextObject symbol, TextObject lastSymbol = null)
		{
			throw null;
		}
	}

	private static GameTextManager _gameTextManager;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize(GameTextManager gameTextManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject FindText(string id, string variation = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryGetText(string id, out TextObject textObject, string variation = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<TextObject> FindAllTextVariations(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetVariable(string variableName, string content)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetVariable(string variableName, float content)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetVariable(string variableName, int content)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetVariable(string variableName, TextObject content)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearInstance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GameTextHelper AddGameTextWithVariation(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void InitializeGlobalTags()
	{
		throw null;
	}
}
