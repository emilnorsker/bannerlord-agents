using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class IntermissionVoteItem
{
	public readonly string Id;

	public readonly int Index;

	public int VoteCount
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IntermissionVoteItem(string id, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVoteCount(int voteCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void IncreaseVoteCount(int incrementAmount)
	{
		throw null;
	}
}
