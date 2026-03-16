using System.Runtime.CompilerServices;
using SandBox.Objects.AreaMarkers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Engine;
using TaleWorlds.Localization;

namespace SandBox.ViewModelCollection.Missions.NameMarker.Targets;

public class MissionCommonAreaMarkerTargetVM : MissionNameMarkerTargetVM<CommonAreaMarker>
{
	public readonly Alley TargetAlley;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionCommonAreaMarkerTargetVM(CommonAreaMarker target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAlleyOwnerChanged(Alley alley, Hero newOwner, Hero oldOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void UpdatePosition(Camera missionCamera)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override TextObject GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAlleyStatus()
	{
		throw null;
	}
}
