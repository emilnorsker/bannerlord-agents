using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class RetrainOutlawPartyMembersBehavior : CampaignBehaviorBase, IRetrainOutlawPartyMembersCampaignBehavior, ICampaignBehavior
{
	private Dictionary<CharacterObject, int> _retrainTable;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetRetrainedNumberInternal(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int SetRetrainedNumberInternal(CharacterObject character, int numberRetrained)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRetrainedNumber(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRetrainedNumber(CharacterObject character, int number)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RetrainOutlawPartyMembersBehavior()
	{
		throw null;
	}
}
