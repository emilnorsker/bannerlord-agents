using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Intermission;

public class MPIntermissionCultureItemVM : MPCultureItemVM
{
	private readonly Action<MPIntermissionCultureItemVM> _onPlayerVoted;

	private int _votes;

	[DataSourceProperty]
	public int Votes
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
	public MPIntermissionCultureItemVM(string cultureCode, Action<MPIntermissionCultureItemVM> onPlayerVoted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteVote()
	{
		throw null;
	}
}
