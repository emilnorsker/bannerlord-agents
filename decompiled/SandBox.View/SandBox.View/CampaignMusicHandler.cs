using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.MountAndBlade;

namespace SandBox.View;

public class CampaignMusicHandler : IMusicHandler
{
	private const float MinRestDurationInSeconds = 30f;

	private const float MaxRestDurationInSeconds = 120f;

	private float _restTimer;

	bool IMusicHandler.IsPausable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CampaignMusicHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Create()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMusicHandler.OnUpdated(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckMusicMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickCampaignMusic(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CultureObject GetNearbyCulture()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsPlayerInAnArmy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMoodOfMainParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsMainPartyAtSea()
	{
		throw null;
	}
}
