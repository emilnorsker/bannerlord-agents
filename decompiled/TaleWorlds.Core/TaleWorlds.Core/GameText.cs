using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.Core;

public class GameText
{
	public struct GameTextVariation
	{
		public readonly string Id;

		public readonly TextObject Text;

		public readonly GameTextManager.ChoiceTag[] Tags;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal GameTextVariation(string id, TextObject text, List<GameTextManager.ChoiceTag> choiceTags)
		{
			throw null;
		}
	}

	private readonly List<GameTextVariation> _variationList;

	public string Id
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public IEnumerable<GameTextVariation> Variations
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TextObject DefaultText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal GameText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal GameText(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal TextObject GetVariation(string variationId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddVariationWithId(string variationId, TextObject text, List<GameTextManager.ChoiceTag> choiceTags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVariationWithId(string variationId, TextObject text, List<GameTextManager.ChoiceTag> choiceTags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddVariation(string text, params object[] propertiesAndWeights)
	{
		throw null;
	}
}
