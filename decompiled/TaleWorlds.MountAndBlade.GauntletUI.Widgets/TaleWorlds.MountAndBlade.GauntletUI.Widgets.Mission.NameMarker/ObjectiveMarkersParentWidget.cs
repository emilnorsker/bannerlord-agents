using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Mission.NameMarker;

public class ObjectiveMarkersParentWidget : Widget
{
	private class MarkerPositionComparer : IComparer<ObjectiveMarkerWidget>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(ObjectiveMarkerWidget x, ObjectiveMarkerWidget y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MarkerPositionComparer()
		{
			throw null;
		}
	}

	private class MarkerRenderOrderComparer : IComparer<Widget>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(Widget x, Widget y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MarkerRenderOrderComparer()
		{
			throw null;
		}
	}

	private List<ObjectiveMarkerWidget> _markers;

	private ObjectiveMarkerWidget _lastFocusedWidget;

	private bool _isMarkersEnabled;

	private float _targetAlphaValue;

	private float _maxDistanceToCombineMarkers;

	private Widget _markersContainer;

	public float MinDistanceToFocus
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public bool IsMarkersEnabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public float TargetAlphaValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public float MaxDistanceToCombineMarkers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public Widget MarkersContainer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ObjectiveMarkersParentWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMarkerCombinations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMarkerFocus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ObjectiveMarkerWidget FindClosestMarkerToFocus(Vec2 screenPosition, out float distanceSquared)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<ObjectiveMarkerWidget> FindClosestMarkersToCombine(ObjectiveMarkerWidget marker, out Vec2 averageScreenPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMarkersChanged(Widget widget, string eventName, object[] args)
	{
		throw null;
	}
}
