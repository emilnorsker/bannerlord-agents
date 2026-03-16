using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.Core;

public static class MBInformationManager
{
	public enum NotificationPriority
	{
		Lowest,
		Low,
		Medium,
		High,
		Highest
	}

	public enum NotificationStatus
	{
		Inactive,
		CurrentlyActive,
		InQueue
	}

	public class DialogNotificationHandle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DialogNotificationHandle()
		{
			throw null;
		}
	}

	public static event Action<string, int, BasicCharacterObject, Equipment, string> FiringQuickInformation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event Action ClearingQuickInformations
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event Action<MultiSelectionInquiryData, bool, bool> OnShowMultiSelectionInquiry
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event Action<InformationData> OnAddMapNotice
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event Action<InformationData> OnRemoveMapNotice
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event Action<SceneNotificationData> OnShowSceneNotification
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event Action OnHideSceneNotification
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event Func<bool> IsAnySceneNotificationActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddQuickInformation(TextObject message, int extraTimeInMs = 0, BasicCharacterObject announcerCharacter = null, Equipment equipment = null, string soundEventPath = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearQuickInformations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ShowMultiSelectionInquiry(MultiSelectionInquiryData data, bool pauseGameActiveState = false, bool prioritize = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddNotice(InformationData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MapNoticeRemoved(InformationData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ShowHint(string hint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void HideInformations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ShowSceneNotification(SceneNotificationData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void HideSceneNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool? GetIsAnySceneNotificationActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Clear()
	{
		throw null;
	}
}
