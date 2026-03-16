using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace StoryMode.GameComponents;

public class StoryModeIncidentModel : IncidentModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetMinGlobalCooldownTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetMaxGlobalCooldownTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetIncidentTriggerGlobalProbability()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetIncidentTriggerProbabilityDuringSiege()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetIncidentTriggerProbabilityDuringWait()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StoryModeIncidentModel()
	{
		throw null;
	}
}
