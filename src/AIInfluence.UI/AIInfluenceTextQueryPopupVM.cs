using System;
using TaleWorlds.Library;

namespace AIInfluence.UI;

public class AIInfluenceTextQueryPopupVM : ViewModel
{
	private readonly TextInquiryData _data;

	private readonly Action _closeAction;

	private string _titleText;

	private string _popUpLabel;

	private string _inputText = "";

	private string _buttonOkLabel;

	private string _buttonCancelLabel;

	private bool _isButtonOkShown;

	private bool _isButtonCancelShown;

	private bool _isButtonOkEnabled = true;

	private bool _isInputObfuscated;

	[DataSourceProperty]
	public string TitleText
	{
		get
		{
			return _titleText;
		}
		set
		{
			if (value != _titleText)
			{
				_titleText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "TitleText");
			}
		}
	}

	[DataSourceProperty]
	public string PopUpLabel
	{
		get
		{
			return _popUpLabel;
		}
		set
		{
			if (value != _popUpLabel)
			{
				_popUpLabel = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "PopUpLabel");
			}
		}
	}

	[DataSourceProperty]
	public string InputText
	{
		get
		{
			return _inputText;
		}
		set
		{
			if (value != _inputText)
			{
				_inputText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "InputText");
				UpdateOkButton();
			}
		}
	}

	[DataSourceProperty]
	public bool IsInputObfuscated
	{
		get
		{
			return _isInputObfuscated;
		}
		set
		{
			if (value != _isInputObfuscated)
			{
				_isInputObfuscated = value;
				base.OnPropertyChangedWithValue(value, "IsInputObfuscated");
			}
		}
	}

	[DataSourceProperty]
	public string ButtonOkLabel
	{
		get
		{
			return _buttonOkLabel;
		}
		set
		{
			if (value != _buttonOkLabel)
			{
				_buttonOkLabel = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "ButtonOkLabel");
			}
		}
	}

	[DataSourceProperty]
	public string ButtonCancelLabel
	{
		get
		{
			return _buttonCancelLabel;
		}
		set
		{
			if (value != _buttonCancelLabel)
			{
				_buttonCancelLabel = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "ButtonCancelLabel");
			}
		}
	}

	[DataSourceProperty]
	public bool IsButtonOkShown
	{
		get
		{
			return _isButtonOkShown;
		}
		set
		{
			if (value != _isButtonOkShown)
			{
				_isButtonOkShown = value;
				base.OnPropertyChangedWithValue(value, "IsButtonOkShown");
			}
		}
	}

	[DataSourceProperty]
	public bool IsButtonCancelShown
	{
		get
		{
			return _isButtonCancelShown;
		}
		set
		{
			if (value != _isButtonCancelShown)
			{
				_isButtonCancelShown = value;
				base.OnPropertyChangedWithValue(value, "IsButtonCancelShown");
			}
		}
	}

	[DataSourceProperty]
	public bool IsButtonOkEnabled
	{
		get
		{
			return _isButtonOkEnabled;
		}
		set
		{
			if (value != _isButtonOkEnabled)
			{
				_isButtonOkEnabled = value;
				base.OnPropertyChangedWithValue(value, "IsButtonOkEnabled");
			}
		}
	}

	public AIInfluenceTextQueryPopupVM(TextInquiryData data, Action closeAction)
	{
		_data = data ?? throw new ArgumentNullException("data");
		_closeAction = closeAction;
		TitleText = data.TitleText ?? "";
		PopUpLabel = data.Text ?? "";
		ButtonOkLabel = data.AffirmativeText ?? "";
		ButtonCancelLabel = data.NegativeText ?? "";
		IsButtonOkShown = data.IsAffirmativeOptionShown;
		IsButtonCancelShown = data.IsNegativeOptionShown;
		IsInputObfuscated = data.IsInputObfuscated;
		UpdateOkButton();
	}

	public void ExecuteAffirmativeAction()
	{
		if (IsButtonOkEnabled)
		{
			string obj = InputText ?? "";
			Action<string> affirmativeAction = _data.AffirmativeAction;
			_closeAction?.Invoke();
			affirmativeAction?.Invoke(obj);
		}
	}

	public void ExecuteNegativeAction()
	{
		Action negativeAction = _data.NegativeAction;
		_closeAction?.Invoke();
		negativeAction?.Invoke();
	}

	private void UpdateOkButton()
	{
		if (_data.TextCondition != null)
		{
			Tuple<bool, string> tuple = _data.TextCondition(InputText ?? "");
			IsButtonOkEnabled = tuple.Item1;
		}
		else
		{
			IsButtonOkEnabled = true;
		}
	}
}
