using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.Overlay;

public class MenuOverlay : Attribute
{
	public new string TypeId;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MenuOverlay(string typeId)
	{
		throw null;
	}
}
