using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace TaleWorlds.MountAndBlade.Multiplayer.GauntletUI.Mission;

[OverrideView(typeof(MissionCheatView))]
public class MissionGauntletMultiplayerCheatView : MissionCheatView
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool GetIsCheatsAvailable()
	{
		throw null;
	}

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
	public MissionGauntletMultiplayerCheatView()
	{
		throw null;
	}
}
