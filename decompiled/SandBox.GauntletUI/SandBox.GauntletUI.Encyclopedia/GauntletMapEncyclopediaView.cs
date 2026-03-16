using System.Runtime.CompilerServices;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI.Encyclopedia;

[OverrideView(typeof(MapEncyclopediaView))]
public class GauntletMapEncyclopediaView : MapEncyclopediaView
{
	private EncyclopediaHomeVM _homeDatasource;

	private EncyclopediaNavigatorVM _navigatorDatasource;

	private EncyclopediaData _encyclopediaData;

	public EncyclopediaListViewDataController ListViewDataController;

	private SpriteCategory _spriteCategory;

	private Game _game;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CreateLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EncyclopediaPageVM ExecuteLink(string pageId, object obj, bool needsRefresh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CloseEncyclopedia()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override TutorialContexts GetTutorialContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapEncyclopediaView()
	{
		throw null;
	}
}
