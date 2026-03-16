using System.Runtime.CompilerServices;
using System.Threading;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class MissionEquipment
{
	private struct MissionEquipmentCache
	{
		public enum CachedBool
		{
			ContainsMeleeWeapon,
			ContainsShield,
			ContainsSpear,
			ContainsNonConsumableRangedWeaponWithAmmo,
			ContainsThrownWeapon,
			Count
		}

		public enum CachedFloat
		{
			TotalWeightOfWeapons,
			Count
		}

		private const int CachedBoolCount = 5;

		private const int CachedFloatCount = 1;

		private float _cachedFloat;

		private StackArray.StackArray5Bool _cachedBool;

		private StackArray.StackArray6Bool _validity;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Initialize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsValid(CachedBool queriedData)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UpdateAndMarkValid(CachedBool data, bool value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool GetValue(CachedBool data)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsValid(CachedFloat queriedData)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UpdateAndMarkValid(CachedFloat data, float value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetValue(CachedFloat data)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InvalidateOnWeaponSlotUpdated()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InvalidateOnWeaponUsageIndexUpdated()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InvalidateOnWeaponAmmoUpdated()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InvalidateOnWeaponAmmoAvailabilityChanged()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InvalidateOnWeaponHitPointsUpdated()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InvalidateOnWeaponDestroyed()
		{
			throw null;
		}
	}

	private readonly ReaderWriterLockSlim _cacheLock;

	private readonly MissionWeapon[] _weaponSlots;

	private MissionEquipmentCache _cache;

	public MissionWeapon this[int index]
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

	public MissionWeapon this[EquipmentIndex index]
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
	public MissionEquipment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionEquipment(Equipment spawnEquipment, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillFrom(MissionEquipment sourceEquipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillFrom(Equipment sourceEquipment, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateGetTotalWeightOfWeapons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTotalWeightOfWeapons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static EquipmentIndex SelectWeaponPickUpSlot(Agent agentPickingUp, MissionWeapon weaponBeingPickedUp, bool isStuckMissile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAmmo(EquipmentIndex equipmentIndex, out int rangedUsageIndex, out bool hasLoadedAmmo, out bool noAmmoInThisSlot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAmmoAmount(EquipmentIndex weaponIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMaxAmmo(EquipmentIndex weaponIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAmmoCountAndIndexOfType(ItemObject.ItemTypeEnum itemType, out int ammoCount, out EquipmentIndex eIndex, EquipmentIndex equippedIndex = EquipmentIndex.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DoesWeaponFitToSlot(EquipmentIndex slotIndex, MissionWeapon weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckLoadedAmmos()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsageIndexOfSlot(EquipmentIndex slotIndex, int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetReloadPhaseOfSlot(EquipmentIndex slotIndex, short reloadPhase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAmountOfSlot(EquipmentIndex slotIndex, short dataValue, bool addOverflowToMaxAmount = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHitPointsOfSlot(EquipmentIndex slotIndex, short dataValue, bool addOverflowToMaxHitPoints = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetReloadedAmmoOfSlot(EquipmentIndex slotIndex, EquipmentIndex ammoSlotIndex, short totalAmmo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetConsumedAmmoOfSlot(EquipmentIndex slotIndex, short count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AttachWeaponToWeaponInSlot(EquipmentIndex slotIndex, ref MissionWeapon weapon, ref MatrixFrame attachLocalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasShield()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAnyWeapon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAnyWeaponWithFlags(WeaponFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemObject GetBanner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasRangedWeapon(WeaponClass requiredAmmoClass = WeaponClass.Undefined)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsNonConsumableRangedWeaponWithAmmo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsMeleeWeapon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsShield()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsSpear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsThrownWeapon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GatherInformationAndUpdateCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GatherInformation(out bool containsMeleeWeapon, out bool containsShield, out bool containsSpear, out bool containsNonConsumableRangedWeaponWithAmmo, out bool containsThrownWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGlossMultipliersOfWeaponsRandomly(int seed)
	{
		throw null;
	}
}
