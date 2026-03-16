using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.AgentOrigins;

public class SimpleAgentOrigin : IAgentOriginBase
{
	private CharacterObject _troop;

	private bool _hasThrownWeapon;

	private bool _hasHeavyArmor;

	private bool _hasShield;

	private bool _hasSpear;

	private Banner _banner;

	private UniqueTroopDescriptor _descriptor;

	public BasicCharacterObject Troop
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IAgentOriginBase.HasThrownWeapon
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IAgentOriginBase.HasHeavyArmor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IAgentOriginBase.HasShield
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IAgentOriginBase.HasSpear
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsUnderPlayersCommand
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public uint FactionColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public uint FactionColor2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Seed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public PartyBase Party
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IBattleCombatant BattleCombatant
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Banner Banner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Rank
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

	public int UniqueSeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SimpleAgentOrigin(BasicCharacterObject troop, int rank = -1, Banner banner = null, UniqueTroopDescriptor descriptor = default(UniqueTroopDescriptor))
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWounded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetKilled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRouted(bool isOrderRetreat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentRemoved(float agentHealth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IAgentOriginBase.OnScoreHit(BasicCharacterObject victim, BasicCharacterObject formationCaptain, int damage, bool isFatal, bool isTeamKill, WeaponComponentData attackerWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBanner(Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	TroopTraitsMask IAgentOriginBase.GetTraitsMask()
	{
		throw null;
	}
}
