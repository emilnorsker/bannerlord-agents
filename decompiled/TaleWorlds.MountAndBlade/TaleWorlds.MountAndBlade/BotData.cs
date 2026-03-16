using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class BotData
{
	public int AliveCount;

	public int KillCount;

	public int DeathCount;

	public int AssistCount;

	public int Score
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAnyValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BotData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BotData(int kill, int assist, int death, int alive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetKillDeathAssist()
	{
		throw null;
	}
}
