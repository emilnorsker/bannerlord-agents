using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.View.Map;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

public class MissionCampaignView : MissionView
{
	private MapScreen _mapScreen;

	private MissionMainAgentController _missionMainAgentController;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenPreLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("get_face_and_helmet_info_of_followed_agent", "mission")]
	public static string GetFaceAndHelmetInfoOfFollowedAgent(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionCampaignView()
	{
		throw null;
	}
}
