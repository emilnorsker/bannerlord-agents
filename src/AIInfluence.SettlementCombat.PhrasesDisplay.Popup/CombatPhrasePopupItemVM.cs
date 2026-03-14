using System;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace AIInfluence.SettlementCombat.PhrasesDisplay.Popup;

public class CombatPhrasePopupItemVM : ViewModel
{
	private Vec2 _screenPosition;

	private string _text;

	private bool _isEnemy;

	private int _distance;

	private float _fontSize;

	private readonly Agent _agent;

	private readonly Vec3 _offset = new Vec3(0f, 0f, 0.6f, -1f);

	[DataSourceProperty]
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
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			if (_screenPosition != value)
			{
				_screenPosition = value;
				base.OnPropertyChangedWithValue(value, "ScreenPosition");
			}
		}
	}

	[DataSourceProperty]
	public string Name
	{
		get
		{
			return _text;
		}
		set
		{
			if (_text != value)
			{
				_text = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "Name");
			}
		}
	}

	[DataSourceProperty]
	public bool IsEnemy
	{
		get
		{
			return _isEnemy;
		}
		set
		{
			if (_isEnemy != value)
			{
				_isEnemy = value;
				base.OnPropertyChangedWithValue(value, "IsEnemy");
			}
		}
	}

	[DataSourceProperty]
	public int Distance
	{
		get
		{
			return _distance;
		}
		set
		{
			if (_distance != value)
			{
				_distance = value;
				base.OnPropertyChangedWithValue(value, "Distance");
			}
		}
	}

	[DataSourceProperty]
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
				base.OnPropertyChangedWithValue(value, "FontSize");
				base.OnPropertyChanged("FontSizeInt");
			}
		}
	}

	[DataSourceProperty]
	public int FontSizeInt => (int)Math.Round(_fontSize);

	public Agent Agent => _agent;

	public CombatPhrasePopupItemVM(Agent agent, string text, bool isEnemy, float fontSize = 16f)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		_agent = agent;
		_text = text;
		_isEnemy = isEnemy;
		_fontSize = fontSize;
	}

	public void Update(Camera camera)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		if (_agent == null)
		{
			ScreenPosition = new Vec2(-500f, -500f);
			return;
		}
		Vec3 val = _agent.GetEyeGlobalPosition() + _offset;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		MBWindowManager.WorldToScreenInsideUsableArea(camera, val, ref num, ref num2, ref num3);
		if (num3 > 0f)
		{
			ScreenPosition = new Vec2(num, num2);
			Vec3 val2 = val - camera.Position;
			Distance = (int)(val2).Length;
		}
		else
		{
			ScreenPosition = new Vec2(-500f, -500f);
			Distance = -1;
		}
	}
}
