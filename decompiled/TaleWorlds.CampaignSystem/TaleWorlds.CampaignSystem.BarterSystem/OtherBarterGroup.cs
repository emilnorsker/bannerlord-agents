using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.BarterSystem;

public class OtherBarterGroup : BarterGroup
{
	public override float AIDecisionWeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OtherBarterGroup()
	{
		throw null;
	}
}
