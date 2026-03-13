using System;
using System.Reflection;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.ScreenSystem;

namespace AIInfluence;

public class WorldEventsUILayer : GauntletLayer
{
	private object _movie;

	private WorldEventsViewModel _viewModel;

	public WorldEventsUILayer()
		: base("WorldEventsLayer", 200, false)
	{
		_viewModel = new WorldEventsViewModel();
		LoadUI();
	}

	private void LoadUI()
	{
		_movie = ((GauntletLayer)this).LoadMovie("WorldEventsButton", (ViewModel)(object)_viewModel);
		((ScreenLayer)this).InputRestrictions.SetInputRestrictions(false, (InputUsageMask)7);
	}

	protected override void OnFinalize()
	{
		if (_movie != null)
		{
			try
			{
				MethodInfo methodInfo = ((object)this).GetType().BaseType?.GetMethod("ReleaseMovie", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
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
		_viewModel = null;
		((GauntletLayer)this).OnFinalize();
	}
}
