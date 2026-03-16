using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.View.MissionViews.Sound;

public class MusicSilencedMissionView : MissionView, IMusicHandler
{
	bool IMusicHandler.IsPausable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMusicHandler.OnUpdated(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MusicSilencedMissionView()
	{
		throw null;
	}
}
