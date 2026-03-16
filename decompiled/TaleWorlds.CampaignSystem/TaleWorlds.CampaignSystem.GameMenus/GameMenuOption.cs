using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameMenus;

public class GameMenuOption
{
	public delegate bool OnConditionDelegate(MenuCallbackArgs args);

	public delegate void OnConsequenceDelegate(MenuCallbackArgs args);

	public enum LeaveType
	{
		Default,
		Mission,
		Submenu,
		BribeAndEscape,
		Escape,
		Craft,
		ForceToGiveGoods,
		ForceToGiveTroops,
		Bribe,
		LeaveTroopsAndFlee,
		OrderTroopsToAttack,
		Raid,
		HostileAction,
		Recruit,
		Trade,
		Wait,
		Leave,
		Continue,
		Manage,
		TroopSelection,
		WaitQuest,
		Surrender,
		Conversation,
		DefendAction,
		Devastate,
		Pillage,
		ShowMercy,
		Leaderboard,
		OpenStash,
		ManageGarrison,
		StagePrisonBreak,
		ManagePrisoners,
		Ransom,
		PracticeFight,
		BesiegeTown,
		SneakIn,
		LeadAssault,
		DonateTroops,
		DonatePrisoners,
		SiegeAmbush,
		Warehouse,
		VisitPort,
		SetSail,
		ManageFleet,
		CallFleet,
		OrderShipsToAttack,
		RepairShips
	}

	[Flags]
	public enum IssueQuestFlags
	{
		None = 0,
		AvailableIssue = 1,
		ActiveIssue = 2,
		ActiveStoryQuest = 4,
		TrackedIssue = 8,
		TrackedStoryQuest = 0x10
	}

	public static IssueQuestFlags[] IssueQuestFlagsValues;

	public OnConditionDelegate OnCondition;

	public OnConsequenceDelegate OnConsequence;

	public GameMenu.MenuAndOptionType Type
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

	public LeaveType OptionLeaveType
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

	public IssueQuestFlags OptionQuestData
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

	public string IdString
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

	public TextObject Text
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

	public TextObject Text2
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

	public TextObject Tooltip
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

	public bool IsLeave
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

	public bool IsRepeatable
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

	public bool IsEnabled
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

	public object RelatedObject
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
	internal GameMenuOption()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameMenuOption(GameMenu.MenuAndOptionType type, string idString, TextObject text, TextObject text2, OnConditionDelegate condition, OnConsequenceDelegate consequence, bool isLeave = false, bool isRepeatable = false, object relatedObject = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetConditionsHold(Game game, MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RunConsequence(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnable(bool isEnable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GameMenuOption()
	{
		throw null;
	}
}
