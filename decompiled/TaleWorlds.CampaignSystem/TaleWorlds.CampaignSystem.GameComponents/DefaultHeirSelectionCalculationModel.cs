using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultHeirSelectionCalculationModel : HeirSelectionCalculationModel
{
	private const int MaleHeirPoint = 10;

	private const int EldestPoint = 5;

	private const int YoungestPoint = -5;

	private const int DirectDescendentPoint = 10;

	private const int CollateralHeirPoint = 10;

	public override int HighestSkillPoint
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateHeirSelectionPoint(Hero candidateHeir, Hero deadHero, ref Hero maxSkillHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int CalculateHeirSelectionPointInternal(Hero candidateHeir, Hero deadHero, ref Hero maxSkillHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool DoesHaveSameBloodLine(IEnumerable<Hero> children, Hero candidateHeir)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultHeirSelectionCalculationModel()
	{
		throw null;
	}
}
