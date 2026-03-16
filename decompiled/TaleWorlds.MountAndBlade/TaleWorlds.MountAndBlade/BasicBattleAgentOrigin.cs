using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class BasicBattleAgentOrigin : IAgentOriginBase
{
	private BasicCharacterObject _troop;

	private bool _hasThrownWeapon;

	private bool _hasHeavyArmor;

	private bool _hasShield;

	private bool _hasSpear;

	bool IAgentOriginBase.IsUnderPlayersCommand
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	uint IAgentOriginBase.FactionColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	uint IAgentOriginBase.FactionColor2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	IBattleCombatant IAgentOriginBase.BattleCombatant
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	int IAgentOriginBase.UniqueSeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	int IAgentOriginBase.Seed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	Banner IAgentOriginBase.Banner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	BasicCharacterObject IAgentOriginBase.Troop
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BasicBattleAgentOrigin(BasicCharacterObject troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IAgentOriginBase.SetWounded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IAgentOriginBase.SetKilled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IAgentOriginBase.SetRouted(bool isOrderRetreat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IAgentOriginBase.OnAgentRemoved(float agentHealth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IAgentOriginBase.OnScoreHit(BasicCharacterObject victim, BasicCharacterObject captain, int damage, bool isFatal, bool isTeamKill, WeaponComponentData attackerWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IAgentOriginBase.SetBanner(Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	TroopTraitsMask IAgentOriginBase.GetTraitsMask()
	{
		throw null;
	}
}
