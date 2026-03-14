using System;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.ScreenSystem;

namespace AIInfluence.UI;

public static class NpcChatWindowManager
{
	private static GauntletLayer _layer;

	private static NpcChatWindowVM _viewModel;

	private static ScreenBase _ownerScreen;

	public static bool IsActive => _layer != null;

	public static NpcChatWindowVM ViewModel => _viewModel;

	public static void Show(NpcChatWindowVM vm)
	{
		Close();
		ScreenBase topScreen = ScreenManager.TopScreen;
		if (topScreen == null)
		{
			Debug.Print("[AIInfluence] NpcChatWindowManager.Show: no TopScreen", 0, (DebugColor)12, 17592186044416uL);
			return;
		}
		try
		{
			_viewModel = vm;
			_layer = new GauntletLayer("GauntletLayer", 490, false);
			_layer.LoadMovie("NpcChatWindow", (ViewModel)(object)_viewModel);
			((ScreenLayer)_layer).IsFocusLayer = true;
			((ScreenLayer)_layer).InputRestrictions.SetInputRestrictions(true, (InputUsageMask)7);
			_ownerScreen = topScreen;
			topScreen.AddLayer((ScreenLayer)(object)_layer);
			ScreenManager.TrySetFocus((ScreenLayer)(object)_layer);
		}
		catch (Exception ex)
		{
			Debug.Print("[AIInfluence] NpcChatWindowManager.Show failed: " + ex.Message, 0, (DebugColor)12, 17592186044416uL);
			Close();
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
					ownerScreen.RemoveLayer((ScreenLayer)(object)_layer);
			}
			catch (Exception)
			{
				try { ScreenManager.TopScreen?.RemoveLayer((ScreenLayer)(object)_layer); }
				catch (Exception) { }
			}
			_layer = null;
		}
		_viewModel = null;
		_ownerScreen = null;
	}

	public static void Tick()
	{
		if (_layer == null || _viewModel == null) return;
		try
		{
			if (((ScreenLayer)_layer).Input.IsKeyReleased((InputKey)1))
				_viewModel.ExecuteLeave();
		}
		catch (Exception) { }
	}
}
