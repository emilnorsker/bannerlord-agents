using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace NavalDLC.GameComponents;

public class NavalDLCPartySpeedCalculationModel : PartySpeedModel
{
	private const int PartyFleetSizeThreshold = 3;

	private const int RaftStateSpeed = 4;

	private const float DisorganizedEffect = -0.4f;

	private const float WindDeadZoneThresholdInDegrees = 60f;

	private const float OverburdenedEffect = -1f;

	private const float MaximumNavalSpeed = 10f;

	private static readonly TextObject _textOverburdened;

	private static readonly TextObject _textOverFleetSize;

	private static readonly TextObject _textDisorganized;

	private static readonly TextObject _textShallowDraftPenalty;

	private static readonly TextObject _openSeaEffect;

	private static readonly TextObject _windEffect;

	private static readonly TextObject _gunnarEffect;

	private readonly TextObject _cultureEffect;

	public override float BaseSpeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override float MinimumSpeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateBaseSpeed(MobileParty party, bool includeDescriptions = false, int additionalTroopOnFootCount = 0, int additionalTroopOnHorseCount = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ExplainedNumber CalculateNavalBaseSpeed(MobileParty mobileParty, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateFinalSpeed(MobileParty mobileParty, ExplainedNumber finalSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateWindBoostForParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ExplainedNumber GetOverburdenedEffect(MobileParty party, float extraWeightCarried, int partyCapacity, bool includeDescriptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetMobilePartyShipSpeedData(MobileParty mobileParty, ref int neededSkeletalCrew, ref int maximumCrewLimit, ref float totalShipSpeed, ref float minimumShipSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetOverCrewSizeEffect(int totalMenCount, int maxCrewSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetUnderSkeletalCrewEffect(float totalManCount, float neededSkeletalCrew)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCPartySpeedCalculationModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static NavalDLCPartySpeedCalculationModel()
	{
		throw null;
	}
}
