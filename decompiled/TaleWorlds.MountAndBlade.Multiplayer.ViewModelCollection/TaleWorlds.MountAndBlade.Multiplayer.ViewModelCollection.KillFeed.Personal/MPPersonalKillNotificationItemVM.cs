using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.KillFeed.Personal;

public class MPPersonalKillNotificationItemVM : ViewModel
{
	private enum ItemTypes
	{
		NormalDamage,
		FriendlyFireDamage,
		FriendlyFireKill,
		MountDamage,
		NormalKill,
		Assist,
		GoldChange,
		HeadshotKill
	}

	private Action<MPPersonalKillNotificationItemVM> _onRemoveItem;

	private ItemTypes _itemTypeAsEnum;

	private string _message;

	private int _amount;

	private int _itemType;

	private ItemTypes ItemTypeAsEnum
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

	[DataSourceProperty]
	public string Message
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

	[DataSourceProperty]
	public int ItemType
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

	[DataSourceProperty]
	public int Amount
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
	public MPPersonalKillNotificationItemVM(int amount, bool isFatal, bool isMountDamage, bool isFriendlyFire, bool isHeadshot, string killedAgentName, Action<MPPersonalKillNotificationItemVM> onRemoveItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MPPersonalKillNotificationItemVM(int amount, GoldGainFlags reasonType, Action<MPPersonalKillNotificationItemVM> onRemoveItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MPPersonalKillNotificationItemVM(string victimAgentName, Action<MPPersonalKillNotificationItemVM> onRemoveItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteRemove()
	{
		throw null;
	}
}
