using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.Core;

public class Crafting
{
	public class RefiningFormula
	{
		public CraftingMaterials Output
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public int OutputCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public CraftingMaterials Output2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public int Output2Count
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public CraftingMaterials Input1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public int Input1Count
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public CraftingMaterials Input2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public int Input2Count
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public RefiningFormula(CraftingMaterials input1, int input1Count, CraftingMaterials input2, int input2Count, CraftingMaterials output, int outputCount = 1, CraftingMaterials output2 = CraftingMaterials.IronOre, int output2Count = 0)
		{
			throw null;
		}
	}

	private static class CraftedItemGenerationHelper
	{
		private struct CraftingStats
		{
			private WeaponDesign _craftedData;

			private WeaponDescription _weaponDescription;

			private float _stoppingTorque;

			private float _armInertia;

			private float _swingDamageFactor;

			private float _thrustDamageFactor;

			private float _currentWeaponWeight;

			private float _currentWeaponReach;

			private float _currentWeaponSweetSpot;

			private float _currentWeaponCenterOfMass;

			private float _currentWeaponInertia;

			private float _currentWeaponInertiaAroundShoulder;

			private float _currentWeaponInertiaAroundGrip;

			private float _currentWeaponSwingSpeed;

			private float _currentWeaponThrustSpeed;

			private float _currentWeaponHandling;

			private float _currentWeaponSwingDamage;

			private float _currentWeaponThrustDamage;

			private WeaponComponentData.WeaponTiers _currentWeaponTier;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static void FillWeapon(ItemObject item, WeaponDescription weaponDescription, WeaponFlags weaponFlags, bool isAlternative, out WeaponComponentData filledWeapon)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void CalculateStats()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void SetWeaponData(WeaponComponentData weapon, bool isAlternative)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private float CalculateSweetSpot()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private float CalculateCenterOfMass()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private float CalculateWeaponInertia()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private float CalculateSwingSpeed()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private float CalculateThrustSpeed()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void CalculateSwingBaseDamage(out float damage)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void CalculateThrustBaseDamage(out float damage, bool isThrown = false)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void CalculateMissileDamage(out float damage)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private WeaponComponentData.WeaponTiers CalculateWeaponTier()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private string GetItemUsage()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private float CalculateMissileSpeed()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private int CalculateAgility()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private float GetWeaponBalance()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private int GetWeaponHandArmorBonus()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private WeaponClass GetAmmoClass()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private static float ParallelAxis(WeaponDesignElement selectedPiece, float offset, float weightMultiplier)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private static float ParallelAxis(float inertiaAroundCm, float mass, float offsetFromCm)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void SimulateSwingLayer(double angleSpan, double usablePower, double maxUsableTorque, double inertia, out double finalSpeed, out double finalTime)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void SimulateThrustLayer(double distance, double usablePower, double maxUsableForce, double mass, out double finalSpeed, out double finalTime)
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ItemObject GenerateCraftedItem(ItemObject item, WeaponDesign weaponDesign, ItemModifierGroup itemModifierGroup)
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetStatDatasFromTemplate_003Ed__52 : IEnumerable<CraftingStatData>, IEnumerable, IEnumerator<CraftingStatData>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private CraftingStatData _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ItemObject craftedItemObject;

		public ItemObject _003C_003E3__craftedItemObject;

		private int usageIndex;

		public int _003C_003E3__usageIndex;

		private CraftingTemplate template;

		public CraftingTemplate _003C_003E3__template;

		private WeaponComponentData _003Cweapon_003E5__2;

		private DamageTypes _003CstatDamageType_003E5__3;

		private IEnumerator<KeyValuePair<CraftingTemplate.CraftingStatTypes, float>> _003C_003E7__wrap3;

		CraftingStatData IEnumerator<CraftingStatData>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetStatDatasFromTemplate_003Ed__52(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<CraftingStatData> IEnumerable<CraftingStatData>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetStatDatas_003Ed__54 : IEnumerable<CraftingStatData>, IEnumerable, IEnumerator<CraftingStatData>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private CraftingStatData _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public Crafting _003C_003E4__this;

		private int usageIndex;

		public int _003C_003E3__usageIndex;

		private WeaponComponentData _003Cweapon_003E5__2;

		private IEnumerator<KeyValuePair<CraftingTemplate.CraftingStatTypes, float>> _003C_003E7__wrap2;

		CraftingStatData IEnumerator<CraftingStatData>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetStatDatas_003Ed__54(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<CraftingStatData> IEnumerable<CraftingStatData>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	public const int WeightOfCrudeIron = 1;

	public const int WeightOfIron = 2;

	public const int WeightOfCompositeIron = 3;

	public const int WeightOfSteel = 4;

	public const int WeightOfRefinedSteel = 5;

	public const int WeightOfCalradianSteel = 6;

	private List<WeaponDesign> _history;

	private int _currentHistoryIndex;

	private ItemObject _craftedItemObject;

	public BasicCultureObject CurrentCulture
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public CraftingTemplate CurrentCraftingTemplate
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public WeaponDesign CurrentWeaponDesign
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

	public ItemModifierGroup CurrentItemModifierGroup
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

	public TextObject CraftedWeaponName
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

	public List<WeaponDesignElement>[] UsablePiecesList
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

	public WeaponDesignElement[] SelectedPieces
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Crafting(CraftingTemplate craftingTemplate, BasicCultureObject culture, TextObject name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCraftedWeaponName(TextObject weaponName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Init()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeaponDesignElement GetRandomPieceOfType(CraftingPiece.PieceTypes pieceType, bool randomScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwitchToCraftedItem(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Randomize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwitchToPiece(WeaponDesignElement piece)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ScaleThePiece(CraftingPiece.PieceTypes scalingPieceType, int percentage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReIndex(bool enforceReCreation = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Undo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Redo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateHistory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetRandomCraftName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GenerateItem(WeaponDesign weaponDesignTemplate, TextObject name, BasicCultureObject culture, ItemModifierGroup itemModifierGroup, ref ItemObject itemObject, string customId = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ItemFlags GetItemFlags(WeaponDesign weaponDesign)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetItemObject(ItemObject itemObject = null, string customId = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemObject GetCurrentCraftedItemObject(bool forceReCreate = false, string customId = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetStatDatasFromTemplate_003Ed__52))]
	public static IEnumerable<CraftingStatData> GetStatDatasFromTemplate(int usageIndex, ItemObject craftedItemObject, CraftingTemplate template)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetValueForCraftingStatForWeaponOfUsageIndex(CraftingTemplate.CraftingStatTypes craftingStatType, ItemObject item, WeaponComponentData weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetStatDatas_003Ed__54))]
	public IEnumerable<CraftingStatData> GetStatDatas(int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetXmlCodeForCurrentItem(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetWeaponPropertiesFromXmlCode(string xmlCode, out CraftingTemplate craftingTemplate, out (CraftingPiece, int)[] pieces)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ItemObject CreatePreCraftedWeaponOnDeserialize(ItemObject itemObject, WeaponDesignElement[] usedPieces, string templateId, TextObject craftedWeaponName, ItemModifierGroup itemModifierGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ItemObject InitializePreCraftedWeaponOnLoad(ItemObject itemObject, WeaponDesign craftedData, TextObject itemName, BasicCultureObject culture)
	{
		throw null;
	}
}
