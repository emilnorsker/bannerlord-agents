using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultPartySpeedCalculatingModel : PartySpeedModel
{
	private static readonly TextObject _textCargo;

	private static readonly TextObject _textOverburdened;

	private static readonly TextObject _textOverPartySize;

	private static readonly TextObject _textOverPrisonerSize;

	private static readonly TextObject _textCavalry;

	private static readonly TextObject _textCavalryWeatherPenalty;

	private static readonly TextObject _textKhuzaitCavalryBonus;

	private static readonly TextObject _textMountedFootmen;

	private static readonly TextObject _textMountedFootmenWeatherPenalty;

	private static readonly TextObject _textWounded;

	private static readonly TextObject _textPrisoners;

	private static readonly TextObject _textHerd;

	private static readonly TextObject _textHighMorale;

	private static readonly TextObject _textLowMorale;

	private static readonly TextObject _textCaravan;

	private static readonly TextObject _textDisorganized;

	private static readonly TextObject _movingInForest;

	private static readonly TextObject _fordEffect;

	private static readonly TextObject _night;

	private static readonly TextObject _snow;

	private static readonly TextObject _desert;

	private static readonly TextObject _sturgiaSnowBonus;

	private readonly TextObject _culture;

	private const float MovingAtForestEffect = -0.3f;

	private const float MovingAtWaterEffect = -0.3f;

	private const float MovingAtNightEffect = -0.25f;

	private const float MovingOnSnowEffect = -0.1f;

	private const float MovingInDesertEffect = -0.1f;

	private const float CavalryEffect = 0.3f;

	private const float MountedFootMenEffect = 0.15f;

	private const float HerdEffect = -0.4f;

	private const float WoundedEffect = -0.05f;

	private const float CargoEffect = -0.02f;

	private const float OverburdenedEffect = -0.4f;

	private const float HighMoraleThreshold = 70f;

	private const float LowMoraleThreshold = 30f;

	private const float HighMoraleEffect = 0.05f;

	private const float LowMoraleEffect = -0.1f;

	private const float DisorganizedEffect = -0.4f;

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
	private ExplainedNumber CalculateLandBaseSpeed(MobileParty mobileParty, bool includeDescriptions = false, int additionalTroopOnFootCount = 0, int additionalTroopOnHorseCount = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateBaseSpeed(MobileParty mobileParty, bool includeDescriptions = false, int additionalTroopOnFootCount = 0, int additionalTroopOnHorseCount = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddCargoStats(MobileParty mobileParty, ref int numberOfAvailableMounts, ref float totalWeightCarried, ref int herdSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateBaseSpeedForParty(int menCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ExplainedNumber GetOverburdenedEffect(MobileParty party, float totalWeightCarried, int partyCapacity, bool includeDescriptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateFinalSpeed(MobileParty mobileParty, ExplainedNumber finalSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetCargoEffect(float weightCarried, int partyCapacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetOverPartySizeEffect(int totalMenCount, int partySize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetOverPrisonerSizeEffect(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetHerdingModifier(int totalMenCount, int herdSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetWoundedModifier(int totalMenCount, int numWounded, MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetCavalryRatioModifier(int totalMenCount, int totalCavalryCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMountedFootmenRatioModifier(int totalMenCount, int totalMountedFootmenCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetFootmenPerkBonus(MobileParty party, int totalMenCount, int totalFootmenCount, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSizeModifierWounded(int totalMenCount, int totalWoundedMenCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSizeModifierPrisoner(int totalMenCount, int totalPrisonerCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultPartySpeedCalculatingModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultPartySpeedCalculatingModel()
	{
		throw null;
	}
}
