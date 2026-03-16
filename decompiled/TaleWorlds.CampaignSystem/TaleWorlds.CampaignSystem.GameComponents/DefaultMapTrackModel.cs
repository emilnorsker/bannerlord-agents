using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultMapTrackModel : MapTrackModel
{
	private const float MinimumTrackSize = 0.1f;

	private const float MaximumTrackSize = 1f;

	private static TextObject _defaultTrackTitle;

	public override float MaxTrackLife
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetMaxTrackSpottingDistanceForMainParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanPartyLeaveTrack(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetTrackLife(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetTrackDetectionDifficultyForMainParty(Track track, float trackSpottingDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetSkillFromTrackDetected(Track track)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetSkipTrackChance(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject TrackTitle(Track track)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string UncertainifyNumber(float num, float baseNum, int skillLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string UncertainifyNumber(int num, int baseNum, int skillLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override IEnumerable<(TextObject, string)> GetTrackDescription(Track track)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override uint GetTrackColor(Track track)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetTrackScale(Track track)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultMapTrackModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultMapTrackModel()
	{
		throw null;
	}
}
