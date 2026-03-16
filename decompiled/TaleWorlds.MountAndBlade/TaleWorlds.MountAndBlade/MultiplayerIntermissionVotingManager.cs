using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerIntermissionVotingManager
{
	public delegate void MapItemAddedDelegate(string mapId);

	public delegate void CultureItemAddedDelegate(string cultureId);

	public delegate void MapItemVoteCountChangedDelegate(int mapItemIndex, int voteCount);

	public delegate void CultureItemVoteCountChangedDelegate(int cultureItemIndex, int voteCount);

	public const int MaxAllowedMapCount = 100;

	private static MultiplayerIntermissionVotingManager _instance;

	public bool IsAutomatedBattleSwitchingEnabled;

	public bool IsMapVoteEnabled;

	public bool IsCultureVoteEnabled;

	public bool IsDisableMapVoteOverride;

	public bool IsDisableCultureVoteOverride;

	public bool IsMapSelectedByAdmin;

	public string InitialGameType;

	private readonly Dictionary<PlayerId, List<string>> _votesOfPlayers;

	public MultiplayerIntermissionState CurrentVoteState;

	public static MultiplayerIntermissionVotingManager Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public List<IntermissionVoteItem> MapVoteItems
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public List<IntermissionVoteItem> CultureVoteItems
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public List<CustomGameUsableMap> UsableMaps
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public event MapItemAddedDelegate OnMapItemAdded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event CultureItemAddedDelegate OnCultureItemAdded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event MapItemVoteCountChangedDelegate OnMapItemVoteCountChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event CultureItemVoteCountChangedDelegate OnCultureItemVoteCountChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerIntermissionVotingManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMapItem(string mapID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddUsableMap(CustomGameUsableMap usableMap)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<string> GetUsableMaps(string gameType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddCultureItem(string cultureID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddVote(PlayerId voterID, string itemID, int voteCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVotesOfMap(int mapItemIndex, int voteCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVotesOfCulture(int cultureItemIndex, int voteCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearVotes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsCultureItem(string itemID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsMapItem(string itemID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandlePlayerDisconnect(PlayerId playerID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SelectRandomCultures(MultiplayerOptions.MultiplayerOptionsAccessMode accessMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPeerVotedForItem(NetworkCommunicator peer, string itemID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SortVotesAndPickBest()
	{
		throw null;
	}
}
