using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.GameMenus;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.Overlay;

public static class GameMenuOverlayFactory
{
	private static List<IGameMenuOverlayProvider> _providers;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GameMenuOverlayFactory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RegisterProvider(IGameMenuOverlayProvider provider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UnregisterProvider(IGameMenuOverlayProvider provider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GameMenuOverlay GetOverlay(TaleWorlds.CampaignSystem.GameMenus.GameMenu.MenuOverlayType menuOverlayType)
	{
		throw null;
	}
}
