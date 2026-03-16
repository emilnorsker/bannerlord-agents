using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Generic;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection;

public class GameVersionVM : ViewModel
{
	private readonly Func<List<string>> _getVersionTexts;

	private MBBindingList<BindingListStringItem> _gameVersionTexts;

	[DataSourceProperty]
	public MBBindingList<BindingListStringItem> GameVersionTexts
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
	public GameVersionVM(Func<List<string>> getVersionTexts)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}
}
