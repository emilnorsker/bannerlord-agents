using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.BarterSystem;

public abstract class BarterGroup
{
	public abstract float AIDecisionWeight { get; }

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected BarterGroup()
	{
		throw null;
	}
}
