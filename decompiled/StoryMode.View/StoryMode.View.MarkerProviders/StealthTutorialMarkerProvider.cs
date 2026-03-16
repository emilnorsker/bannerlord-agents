using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.ViewModelCollection.Missions.NameMarker;
using Storymode.Missions;

namespace StoryMode.View.MarkerProviders;

public class StealthTutorialMarkerProvider : MissionNameMarkerProvider
{
	private SneakIntoTheVillaMissionController _controller;

	private SneakIntoTheVillaMissionController Controller
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CreateMarkers(List<MissionNameMarkerTargetBaseVM> markers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StealthTutorialMarkerProvider()
	{
		throw null;
	}
}
