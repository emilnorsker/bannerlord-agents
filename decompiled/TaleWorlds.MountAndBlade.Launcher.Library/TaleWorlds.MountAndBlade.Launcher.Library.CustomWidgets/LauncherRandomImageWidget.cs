using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Launcher.Library.CustomWidgets;

public class LauncherRandomImageWidget : Widget
{
	private readonly Random _random;

	private List<int> _imageIndices;

	private int _currentIndex;

	private int _imageCount;

	private bool _changeTrigger;

	[DataSourceProperty]
	public int ImageCount
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

	[DataSourceProperty]
	public bool ChangeTrigger
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
	public LauncherRandomImageWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShuffleList<T>(List<T> list)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateIndicesList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnConnectedToRoot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TriggerChanged()
	{
		throw null;
	}
}
