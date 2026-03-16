using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library.EventSystem;
using TaleWorlds.Localization;

namespace SandBox.View.Map.Navigation.NavigationElements;

public class ClanScreenPermissionEvent : EventBase
{
	public Action<bool, TextObject> IsClanScreenAvailable
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
	public ClanScreenPermissionEvent(Action<bool, TextObject> isClanScreenAvailable)
	{
		throw null;
	}
}
