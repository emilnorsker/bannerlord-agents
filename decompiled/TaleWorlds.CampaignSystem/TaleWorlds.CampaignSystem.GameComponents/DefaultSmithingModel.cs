using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSmithingModel : SmithingModel
{
	[CompilerGenerated]
	private sealed class _003CGetRefiningFormulas_003Ed__7 : IEnumerable<Crafting.RefiningFormula>, IEnumerable, IEnumerator<Crafting.RefiningFormula>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Crafting.RefiningFormula _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Hero weaponsmith;

		public Hero _003C_003E3__weaponsmith;

		Crafting.RefiningFormula IEnumerator<Crafting.RefiningFormula>.Current
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
		public _003CGetRefiningFormulas_003Ed__7(int _003C_003E1__state)
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
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<Crafting.RefiningFormula> IEnumerable<Crafting.RefiningFormula>.GetEnumerator()
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

	private const int BladeDifficultyCalculationWeight = 100;

	private const int GuardDifficultyCalculationWeight = 20;

	private const int HandleDifficultyCalculationWeight = 60;

	private const int PommelDifficultyCalculationWeight = 20;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetCraftingPartDifficulty(CraftingPiece craftingPiece)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateWeaponDesignDifficulty(WeaponDesign weaponDesign)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ItemModifier GetCraftedWeaponModifier(WeaponDesign weaponDesign, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetRefiningFormulas_003Ed__7))]
	public override IEnumerable<Crafting.RefiningFormula> GetRefiningFormulas(Hero weaponsmith)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetSkillXpForRefining(ref Crafting.RefiningFormula refineFormula)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetSkillXpForSmelting(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetSkillXpForSmithingInFreeBuildMode(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetSkillXpForSmithingInCraftingOrderMode(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetEnergyCostForRefining(ref Crafting.RefiningFormula refineFormula, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetEnergyCostForSmithing(ItemObject item, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetEnergyCostForSmelting(ItemObject item, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ItemObject GetCraftingMaterialItem(CraftingMaterials craftingMaterial)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int[] GetSmeltingOutputForItem(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<(ItemQuality quality, float probability)> GetModifierQualityProbabilities(WeaponDesign weaponDesign, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AdjustModifierProbabilities(List<(ItemQuality quality, float probability)> modifierProbabilities, ItemQuality qualityToAdjust, float amount, List<ItemQuality> qualitiesToIgnore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ItemQuality AdjustQualityRegardingDesignTier(ItemQuality weaponQuality, WeaponDesign weaponDesign)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateSigmoidFunction(float x, float mean, float curvature)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetDifficultyForElement(WeaponDesignElement weaponDesignElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSmeltingReductions(int[] quantities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int[] GetSmithingCostsForWeaponDesign(WeaponDesign weaponDesign)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float ResearchPointsNeedForNewPart(int totalPartCount, int openedPartCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetPartResearchGainForSmeltingItem(ItemObject item, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetPartResearchGainForSmithingItem(ItemObject item, Hero hero, bool isFreeBuild)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSmithingModel()
	{
		throw null;
	}
}
