using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace SandBox.CampaignBehaviors;

public class BarberCampaignBehavior : CampaignBehaviorBase, IFacegenCampaignBehavior, ICampaignBehavior
{
	private class BarberFaceGeneratorCustomFilter : IFaceGeneratorCustomFilter
	{
		private readonly int[] _haircutIndices;

		private readonly int[] _facialHairIndices;

		private readonly bool _defaultStages;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BarberFaceGeneratorCustomFilter(bool useDefaultStages, int[] haircutIndices, int[] faircutIndices)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int[] GetHaircutIndices(BasicCharacterObject character)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int[] GetFacialHairIndices(BasicCharacterObject character)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FaceGeneratorStage[] GetAvailableStages()
		{
			throw null;
		}
	}

	private const int BarberCost = 100;

	private bool _isOpenedFromBarberDialogue;

	private StaticBodyProperties _previousBodyProperties;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore store)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDialogs(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool InDisguiseSpeakingToBarber()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DoesPlayerHaveEnoughGold(out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChargeThePlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DidPlayerNotHaveAHaircut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DidPlayerHaveAHaircut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsConversationAgentBarber()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GivePlayerAHaircutCondition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GivePlayerAHaircut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeBarberConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreateBarber(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LocationCharactersAreReadyToSpawn(Dictionary<string, int> unusedUsablePointCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IFaceGeneratorCustomFilter GetFaceGenFilter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BarberCampaignBehavior()
	{
		throw null;
	}
}
