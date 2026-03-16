using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.FactionBanVote;

public class MultiplayerFactionBanVM : ViewModel
{
	private MBBindingList<MultiplayerFactionBanVoteVM> _banList;

	private MBBindingList<MultiplayerFactionBanVoteVM> _selectList;

	private string _selectTitle;

	private string _banTitle;

	[DataSourceProperty]
	public MBBindingList<MultiplayerFactionBanVoteVM> SelectList
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
	public MBBindingList<MultiplayerFactionBanVoteVM> BanList
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
	public string SelectTitle
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
	public string BanTitle
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
	public MultiplayerFactionBanVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelectFaction(MultiplayerFactionBanVoteVM vote)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBanFaction(MultiplayerFactionBanVoteVM vote)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Refresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void VoteForCulture(CultureVoteTypes voteType, BasicCultureObject culture)
	{
		throw null;
	}
}
