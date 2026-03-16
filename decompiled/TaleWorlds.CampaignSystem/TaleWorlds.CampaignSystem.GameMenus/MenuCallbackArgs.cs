using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameMenus;

public class MenuCallbackArgs
{
	public float DeltaTime;

	public bool IsEnabled;

	public TextObject Text;

	public TextObject Tooltip;

	public GameMenuOption.IssueQuestFlags OptionQuestData;

	public GameMenuOption.LeaveType optionLeaveType;

	public TextObject MenuTitle;

	public MenuContext MenuContext
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

	public MapState MapState
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
	public MenuCallbackArgs(MenuContext menuContext, TextObject text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MenuCallbackArgs(MapState mapState, TextObject text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MenuCallbackArgs(MapState mapState, TextObject text, float dt)
	{
		throw null;
	}
}
