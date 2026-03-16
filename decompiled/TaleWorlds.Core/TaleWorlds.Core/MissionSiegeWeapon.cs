using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MissionSiegeWeapon : IMissionSiegeWeapon
{
	private float _health;

	private readonly int _index;

	private readonly SiegeEngineType _type;

	private readonly float _initialHealth;

	private readonly float _maxHealth;

	public int Index
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public SiegeEngineType Type
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Health
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float InitialHealth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxHealth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionSiegeWeapon(int index, SiegeEngineType type, float health, float maxHealth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionSiegeWeapon CreateDefaultWeapon(SiegeEngineType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionSiegeWeapon CreateCampaignWeapon(SiegeEngineType type, int index, float health, float maxHealth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHealth(float health)
	{
		throw null;
	}
}
