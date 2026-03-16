using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace SandBox.ViewModelCollection.Missions.NameMarker.Targets;

public class MissionWorkshopNameMarkerTargetVM : MissionNameMarkerTargetVM<Workshop>
{
	private readonly Vec3 _signPosition;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionWorkshopNameMarkerTargetVM(Workshop target, Vec3 signPosition)
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
}
