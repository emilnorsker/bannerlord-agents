using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem;

internal class DialogFlowContext
{
	internal readonly string Token;

	internal readonly bool ByPlayer;

	internal readonly DialogFlowContext Parent;

	internal readonly bool OptionsUsedOnlyOnce;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DialogFlowContext(string token, bool byPlayer, DialogFlowContext parent, bool optionsUsedOnlyOnce)
	{
		throw null;
	}
}
