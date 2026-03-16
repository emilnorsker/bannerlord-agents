using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace Helpers;

public static class CharacterHelper
{
	[CompilerGenerated]
	private sealed class _003CGetTroopTree_003Ed__19 : IEnumerable<CharacterObject>, IEnumerable, IEnumerator<CharacterObject>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private CharacterObject _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private CharacterObject baseTroop;

		public CharacterObject _003C_003E3__baseTroop;

		private float minTier;

		public float _003C_003E3__minTier;

		private float maxTier;

		public float _003C_003E3__maxTier;

		private MBQueue<CharacterObject> _003Cqueue_003E5__2;

		private CharacterObject _003Ccharacter_003E5__3;

		CharacterObject IEnumerator<CharacterObject>.Current
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
		public _003CGetTroopTree_003Ed__19(int _003C_003E1__state)
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
		IEnumerator<CharacterObject> IEnumerable<CharacterObject>.GetEnumerator()
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetDeathNotification(Hero victimHero, Hero killer, KillCharacterAction.KillCharacterActionDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static DynamicBodyProperties GetDynamicBodyPropertiesBetweenMinMaxRange(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetReputationDescription(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static (uint color1, uint color2) GetDeterministicColorsForCharacter(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static uint GetDeterministicColorFromListForHero(Hero hero, uint[] colors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IFaceGeneratorCustomFilter GetFaceGeneratorFilter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetNonconversationPose(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetNonconversationFacialIdle(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetStandingBodyIdle(CharacterObject character, PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetDefaultFaceIdle(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetSuperiorityState(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool MorePowerThanPlayer(CharacterObject otherCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CharacterObject FindUpgradeRootOf(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool UpgradeTreeContains(CharacterObject rootTroop, CharacterObject baseTroop, CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ItemObject GetDefaultWeapon(CharacterObject affectorCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CanUseItemBasedOnSkill(BasicCharacterObject currentCharacter, EquipmentElement itemRosterElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetPartyMemberFaceSeed(PartyBase party, BasicCharacterObject character, int rank)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetDefaultFaceSeed(BasicCharacterObject character, int rank)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SearchForFormationInTroopTree(CharacterObject baseTroop, FormationClass formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetTroopTree_003Ed__19))]
	public static IEnumerable<CharacterObject> GetTroopTree(CharacterObject baseTroop, float minTier = -1f, float maxTier = float.MaxValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DeleteQuestCharacter(CharacterObject character, Settlement questSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CharacterObject GetRandomCompanionTemplateWithPredicate(Func<CharacterObject, bool> predicate = null)
	{
		throw null;
	}
}
