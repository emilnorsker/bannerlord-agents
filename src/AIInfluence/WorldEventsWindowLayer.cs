using System;
using System.Reflection;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.ScreenSystem;

namespace AIInfluence;

public class WorldEventsWindowLayer : GauntletLayer
{
	private object _movie;

	private WorldEventsWindowViewModel _windowViewModel;

	public WorldEventsWindowLayer()
		: base("WorldEventsWindowLayer", 300, false)
	{
		_windowViewModel = new WorldEventsWindowViewModel(this);
		LoadWindowUI();
	}

	private void LoadWindowUI()
	{
		_movie = base.LoadMovie("WorldEventsWindow", (ViewModel)(object)_windowViewModel);
		((ScreenLayer)this).InputRestrictions.SetInputRestrictions(false, (InputUsageMask)7);
	}

	protected override void OnFinalize()
	{
		if (_movie != null)
		{
			try
			{
				MethodInfo methodInfo = base.GetType().BaseType?.GetMethod("ReleaseMovie", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (methodInfo != null)
				{
					methodInfo.Invoke(this, new object[1] { _movie });
				}
			}
			catch (Exception)
			{
			}
			_movie = null;
		}
		_windowViewModel = null;
		base.OnFinalize();
	}
}
