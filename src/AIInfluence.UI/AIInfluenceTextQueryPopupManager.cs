using System;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.ScreenSystem;

namespace AIInfluence.UI;

public static class AIInfluenceTextQueryPopupManager
{
	private static GauntletLayer _layer;

	private static AIInfluenceTextQueryPopupVM _viewModel;

	private static ScreenBase _ownerScreen;

	public static bool IsActive => _layer != null;

	public static void Show(TextInquiryData data)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		Close();
		ScreenBase topScreen = ScreenManager.TopScreen;
		if (topScreen == null)
		{
			Debug.Print("[AIInfluence] AIInfluenceTextQueryPopupManager.Show: no TopScreen, falling back to InformationManager", 0, (DebugColor)12, 17592186044416uL);
			InformationManager.ShowTextInquiry(data, false, false);
			return;
		}
		try
		{
			_viewModel = new AIInfluenceTextQueryPopupVM(data, Close);
			_layer = new GauntletLayer("GauntletLayer", 500, false);
			_layer.LoadMovie("AIInfluenceTextQueryPopup", (ViewModel)(object)_viewModel);
			((ScreenLayer)_layer).IsFocusLayer = true;
			((ScreenLayer)_layer).InputRestrictions.SetInputRestrictions(true, (InputUsageMask)7);
			_ownerScreen = topScreen;
			topScreen.AddLayer((ScreenLayer)(object)_layer);
			ScreenManager.TrySetFocus((ScreenLayer)(object)_layer);
		}
		catch (Exception ex)
		{
			Debug.Print("[AIInfluence] AIInfluenceTextQueryPopupManager.Show failed: " + ex.Message, 0, (DebugColor)12, 17592186044416uL);
			Close();
			InformationManager.ShowTextInquiry(data, false, false);
		}
	}

	public static void Close()
	{
		if (_layer != null)
		{
			((ScreenLayer)_layer).IsFocusLayer = false;
			((ScreenLayer)_layer).InputRestrictions.ResetInputRestrictions();
			try
			{
				ScreenBase ownerScreen = _ownerScreen;
				if (ownerScreen != null)
				{
					ownerScreen.RemoveLayer((ScreenLayer)(object)_layer);
				}
			}
			catch (Exception)
			{
				try
				{
					ScreenBase topScreen = ScreenManager.TopScreen;
					if (topScreen != null)
					{
						topScreen.RemoveLayer((ScreenLayer)(object)_layer);
					}
				}
				catch (Exception)
				{
				}
			}
			_layer = null;
		}
		_viewModel = null;
		_ownerScreen = null;
	}

	public static void Tick()
	{
		if (_layer == null || _viewModel == null)
		{
			return;
		}
		try
		{
			if (((ScreenLayer)_layer).Input.IsKeyReleased((InputKey)1))
			{
				_viewModel.ExecuteNegativeAction();
			}
		}
		catch (Exception)
		{
		}
	}
}
