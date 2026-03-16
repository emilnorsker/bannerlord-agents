using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public struct MissionWeapon
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ImpactSoundModifier
	{
		public const string ModifierName = "impactModifier";

		public const float None = 0f;

		public const float ActiveBlock = 0.1f;

		public const float ChamberBlocked = 0.2f;

		public const float CrushThrough = 0.3f;
	}

	private class MissionSubWeapon
	{
		public MissionWeapon Value
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
		public MissionSubWeapon(MissionWeapon subWeapon)
		{
			throw null;
		}
	}

	public delegate void OnGetWeaponDataDelegate(ref WeaponData weaponData, MissionWeapon weapon, bool isFemale, Banner banner, bool needBatchedVersion);

	public const short ReloadPhaseCountMax = 10;

	public static OnGetWeaponDataDelegate OnGetWeaponDataHandler;

	public static readonly MissionWeapon Invalid;

	private readonly List<WeaponComponentData> _weapons;

	public int CurrentUsageIndex;

	private bool _hasAnyConsumableUsage;

	private short _dataValue;

	private short _modifiedMaxDataValue;

	private MissionSubWeapon _ammoWeapon;

	private List<MissionSubWeapon> _attachedWeapons;

	private List<MatrixFrame> _attachedWeaponFrames;

	public ItemObject Item
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

	public ItemModifier ItemModifier
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

	public int WeaponsCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public WeaponComponentData CurrentUsageItem
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public short ReloadPhase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public short ReloadPhaseCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsReloading
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

	public float GlossMultiplier
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

	public short RawDataForNetwork
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public short HitPoints
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

	public short Amount
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

	public short Ammo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MissionWeapon AmmoWeapon
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public short MaxAmmo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public short ModifiedMaxAmount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public short ModifiedMaxHitPoints
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsEmpty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionWeapon(ItemObject item, ItemModifier itemModifier, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionWeapon(ItemObject primaryItem, ItemModifier itemModifier, Banner banner, short dataValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionWeapon(ItemObject primaryItem, ItemModifier itemModifier, Banner banner, short dataValue, short reloadPhase, MissionWeapon? ammoWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetModifiedItemName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEqualTo(MissionWeapon other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSameType(MissionWeapon other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWeight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetBaseWeight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeaponComponentData GetWeaponComponentDataForUsage(int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGetModifiedArmorForCurrentUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetModifiedThrustDamageForCurrentUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetModifiedSwingDamageForCurrentUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetModifiedMissileDamageForCurrentUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetModifiedThrustSpeedForCurrentUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetModifiedSwingSpeedForCurrentUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetModifiedMissileSpeedForCurrentUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetModifiedMissileSpeedForUsage(int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetModifiedHandlingForCurrentUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeaponData GetWeaponData(bool needBatchedVersionForMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeaponStatsData[] GetWeaponStatsData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeaponStatsData GetWeaponStatsDataForUsage(int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeaponData GetAmmoWeaponData(bool needBatchedVersion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeaponStatsData[] GetAmmoWeaponStatsData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAttachedWeaponsCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionWeapon GetAttachedWeapon(int attachmentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetAttachedWeaponFrame(int attachmentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsShield()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBanner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAnyAmmo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAnyUsageWithWeaponClass(WeaponClass weaponClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAnyUsageWithAmmoClass(WeaponClass ammoClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAllUsagesWithAnyWeaponFlag(WeaponFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAnyUsageWithoutWeaponFlag(WeaponFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GatherInformationFromWeapon(out bool weaponHasMelee, out bool weaponHasShield, out bool weaponHasPolearm, out bool weaponHasNonConsumableRanged, out bool weaponHasThrown, out WeaponClass rangedAmmoClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetConsumableIfAny(out WeaponComponentData consumableWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAnyConsumable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRangedUsageIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionWeapon Consume(short count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ConsumeAmmo(short count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAmmo(MissionWeapon ammoWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReloadAmmo(MissionWeapon ammoWeapon, short reloadPhase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AttachWeapon(MissionWeapon attachedWeapon, ref MatrixFrame attachFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAttachedWeapon(int attachmentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasEnoughSpaceForAmount(int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRandomGlossMultiplier(int seed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddExtraModifiedMaxValue(short extraValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionWeapon()
	{
		throw null;
	}
}
