using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace TaleWorlds.MountAndBlade.CustomBattle.Views;

[OverrideView(typeof(MissionCheatView))]
internal class GauntletCustomBattleMissionCheatView : MissionCheatView
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void InitializeScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void FinalizeScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool GetIsCheatsAvailable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletCustomBattleMissionCheatView()
	{
		throw null;
	}
}
