using System;
using System.Runtime.CompilerServices;
using SandBox.GauntletUI.Tutorial;
using SandBox.View.Map;
using TaleWorlds.Core;

namespace StoryMode.GauntletUI.Tutorial;

[Tutorial("NavigateOnMapTutorialStep1")]
public class NavigateOnMapTutorialStep1 : TutorialItemBase
{
	private bool _movedPosition;

	private bool _movedRotation;

	private const float _delayInSeconds = 2f;

	private DateTime _completionTime;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavigateOnMapTutorialStep1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TutorialContexts GetTutorialsRelevantContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForActivation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMainMapCameraMove(MainMapCameraMoveEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForCompletion()
	{
		throw null;
	}
}
