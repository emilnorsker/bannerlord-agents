using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.Core;

public class TauntUsageManager
{
	private class TauntUsageFlagComparer : IComparer<TauntUsage.TauntUsageFlag>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(TauntUsage.TauntUsageFlag x, TauntUsage.TauntUsageFlag y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TauntUsageFlagComparer()
		{
			throw null;
		}
	}

	public class TauntUsageSet
	{
		private MBList<TauntUsage> _tauntUsages;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TauntUsageSet()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddUsage(TauntUsage usage)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MBReadOnlyList<TauntUsage> GetUsages()
		{
			throw null;
		}
	}

	public class TauntUsage
	{
		[Flags]
		public enum TauntUsageFlag
		{
			None = 0,
			RequiresBow = 1,
			RequiresShield = 2,
			IsLeftStance = 4,
			RequiresOnFoot = 8,
			UnsuitableForTwoHanded = 0x10,
			UnsuitableForOneHanded = 0x20,
			UnsuitableForShield = 0x40,
			UnsuitableForBow = 0x80,
			UnsuitableForCrossbow = 0x100,
			UnsuitableForEmpty = 0x200
		}

		private string _actionName;

		public TauntUsageFlag UsageFlag
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TauntUsage(TauntUsageFlag usageFlag, string actionName)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsSuitable(bool isLeftStance, bool isOnFoot, WeaponComponentData mainHandWeapon, WeaponComponentData offhandWeapon)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TauntUsageFlag GetIsNotSuitableReason(bool isLeftStance, bool isOnFoot, WeaponComponentData mainHandWeapon, WeaponComponentData offhandWeapon)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string GetAction()
		{
			throw null;
		}
	}

	private static TauntUsageManager _instance;

	private List<TauntUsageSet> _tauntUsageSets;

	private Dictionary<string, int> _tauntUsageSetIndexMap;

	public static TauntUsageManager Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TauntUsageManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TauntUsageManager Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Read()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TauntUsageSet GetUsageSet(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAction(int index, bool isLeftStance, bool onFoot, WeaponComponentData mainHandWeapon, WeaponComponentData offhandWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TextObject GetHintTextFromReasons(List<TextObject> reasons)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetActionDisabledReasonText(TauntUsage.TauntUsageFlag disabledReasonFlag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TauntUsage.TauntUsageFlag GetIsActionNotSuitableReason(int index, bool isLeftStance, bool onFoot, WeaponComponentData mainHandWeapon, WeaponComponentData offhandWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTauntItemCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetIndexOfAction(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetDefaultAction(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static XmlDocument LoadXmlFile(string path)
	{
		throw null;
	}
}
