using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace AIInfluence.UI.Widgets.CombatPhrases;

public class PopUpConversationScreenWidget : Widget
{
	private readonly List<PopUpConversationListPanel> _registeredMarkers = new List<PopUpConversationListPanel>();

	private Widget _markersContainer;

	private bool _isMarkersEnabled = true;

	private float _targetAlphaValue = 0f;

	public bool IsMarkersEnabled
	{
		get
		{
			return _isMarkersEnabled;
		}
		set
		{
			if (_isMarkersEnabled != value)
			{
				_isMarkersEnabled = value;
				UpdateMarkersVisibility();
			}
		}
	}

	public float TargetAlphaValue
	{
		get
		{
			return _targetAlphaValue;
		}
		set
		{
			if (Math.Abs(_targetAlphaValue - value) > 0.001f)
			{
				_targetAlphaValue = value;
			}
		}
	}

	public Widget MarkersContainer
	{
		get
		{
			return _markersContainer;
		}
		set
		{
			if (_markersContainer != value)
			{
				_markersContainer = value;
				RefreshRegisteredMarkers();
			}
		}
	}

	public PopUpConversationScreenWidget(UIContext context)
		: base(context)
	{
	}

	protected override void OnLateUpdate(float dt)
	{
		base.OnLateUpdate(dt);
		RefreshRegisteredMarkers();
		bool flag = _registeredMarkers.Count > 0;
		float num = ((_isMarkersEnabled && flag) ? _targetAlphaValue : 0f);
		float num2 = MBMath.ClampFloat(dt * 10f, 0f, 1f);
		((Widget)this).AlphaFactor = MBMath.Lerp(((Widget)this).AlphaFactor, num, num2, 1E-05f);
		foreach (PopUpConversationListPanel registeredMarker in _registeredMarkers)
		{
			((Widget)registeredMarker).IsVisible = _isMarkersEnabled;
		}
	}

	private void RefreshRegisteredMarkers()
	{
		if (_markersContainer != null)
		{
			_registeredMarkers.Clear();
			_registeredMarkers.AddRange(_markersContainer.Children.OfType<PopUpConversationListPanel>());
			_targetAlphaValue = ((_registeredMarkers.Count > 0) ? 1f : 0f);
		}
	}

	private void UpdateMarkersVisibility()
	{
		foreach (PopUpConversationListPanel registeredMarker in _registeredMarkers)
		{
			((Widget)registeredMarker).IsVisible = _isMarkersEnabled;
		}
	}
}
