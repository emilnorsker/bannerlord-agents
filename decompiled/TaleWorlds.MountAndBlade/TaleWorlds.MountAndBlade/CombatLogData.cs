using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public struct CombatLogData
{
	private const string DetailTagStart = "<Detail>";

	private const string DetailTagEnd = "</Detail>";

	private const uint DamageReceivedColor = 4292917946u;

	private const uint DamageDealedColor = 4210351871u;

	private static List<(string, uint)> _logStringCache;

	public readonly bool IsVictimAgentSameAsAttackerAgent;

	public readonly bool IsVictimRiderAgentSameAsAttackerAgent;

	public readonly bool IsAttackerAgentHuman;

	public readonly bool IsAttackerAgentMine;

	public readonly bool DoesAttackerAgentHaveRiderAgent;

	public readonly bool IsAttackerAgentRiderAgentMine;

	public readonly bool IsAttackerAgentMount;

	public readonly bool IsVictimAgentHuman;

	public readonly bool IsVictimAgentMine;

	public readonly bool DoesVictimAgentHaveRiderAgent;

	public readonly bool IsVictimAgentRiderAgentMine;

	public readonly bool IsVictimAgentMount;

	public MissionObject MissionObjectHit;

	public DamageTypes DamageType;

	public bool CrushedThrough;

	public bool Chamber;

	public bool IsRangedAttack;

	public bool IsFriendlyFire;

	public bool IsFatalDamage;

	public bool IsSpecialDamage;

	public bool IsEntityToEntityCollisionDamage;

	public bool IsSneakAttack;

	public BoneBodyPartType BodyPartHit;

	public string VictimAgentName;

	public float HitSpeed;

	public int InflictedDamage;

	public int AbsorbedDamage;

	public int ModifiedDamage;

	public int ReflectedDamage;

	public float Distance;

	private bool IsValidForPlayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsImportant
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsAttackerPlayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsVictimPlayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsAttackerMount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsVictimMount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int TotalDamage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float AttackProgress
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		internal set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<(string, uint)> GetLogString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CombatLogData(bool isVictimAgentSameAsAttackerAgent, bool isAttackerAgentHuman, bool isAttackerAgentMine, bool doesAttackerAgentHaveRiderAgent, bool isAttackerAgentRiderAgentMine, bool isAttackerAgentMount, bool isVictimAgentHuman, bool isVictimAgentMine, bool isVictimAgentDead, bool doesVictimAgentHaveRiderAgent, bool isVictimAgentRiderAgentIsMine, bool isVictimAgentMount, MissionObject missionObjectHit, bool isVictimRiderAgentSameAsAttackerAgent, bool crushedThrough, bool chamber, float distance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVictimAgent(Agent victimAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CombatLogData()
	{
		throw null;
	}
}
