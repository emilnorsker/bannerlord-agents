using System;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace AIInfluence.UI.Widgets.CombatPhrases;

public class PopUpConversationListPanel : ListPanel
{
	private Vec2 _screenPosition;

	private float _fontSize = 25f;

	private float _distance;

	private float _currentScale = 1f;

	public Widget TypeVisualWidget { get; set; }

	public TextWidget NameTextWidget { get; set; }

	public float FontSize
	{
		get
		{
			return _fontSize;
		}
		set
		{
			if (Math.Abs(_fontSize - value) > 0.001f)
			{
				_fontSize = value;
				UpdateFontSize();
			}
		}
	}

	public Vec2 ScreenPosition
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _screenPosition;
		}
		set
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			if (_screenPosition != value)
			{
				_screenPosition = value;
				UpdatePosition();
			}
		}
	}

	public float Distance
	{
		get
		{
			return _distance;
		}
		set
		{
			if (Math.Abs(_distance - value) > 0.001f)
			{
				_distance = value;
				UpdateScaleWithDistance();
			}
		}
	}

	[Editor(false)]
	public Vec2 Position
	{
		get
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			return new Vec2(((Widget)this).ScaledPositionXOffset, ((Widget)this).ScaledPositionYOffset);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			ScreenPosition = value;
		}
	}

	public PopUpConversationListPanel(UIContext context)
		: base(context)
	{
	}

	protected override void OnLateUpdate(float dt)
	{
		((Widget)this).OnLateUpdate(dt);
		UpdateFontSize();
		UpdatePosition();
	}

	private void UpdateFontSize()
	{
		if (NameTextWidget != null)
		{
			((BrushWidget)NameTextWidget).Brush.FontSize = (int)(FontSize * _currentScale);
		}
	}

	private void UpdateScaleWithDistance()
	{
		if (Distance <= 0f)
		{
			_currentScale = 0f;
			UpdateFontSize();
		}
		else
		{
			float num = MBMath.ClampFloat(1f - (Distance - 3f) / 47f, 0f, 1f);
			_currentScale = 0.35f + 0.65f * num;
			UpdateFontSize();
		}
	}

	private void UpdatePosition()
	{
		float num = _fontSize * _currentScale * 1.5f;
		((Widget)this).ScaledPositionXOffset = _screenPosition.x - ((Widget)this).ScaledSuggestedWidth * 0.5f;
		((Widget)this).ScaledPositionYOffset = _screenPosition.y - num;
	}
}
