using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.BarterSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Barter;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI.Map;

public class GauntletMapConversationBarterView
{
	public delegate void OnBarterActiveStateChanged(bool isBarterActive);

	private readonly GauntletLayer _gauntletLayer;

	private readonly OnBarterActiveStateChanged _onActiveStateChanged;

	private SpriteCategory _barterCategory;

	private BarterVM _barterDataSource;

	private GauntletMovieIdentifier _barterMovie;

	public bool IsCreated
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

	public bool IsActive
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
	public GauntletMapConversationBarterView(GauntletLayer layer, OnBarterActiveStateChanged onActiveStateChanged)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateBarterView(BarterData args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DestroyBarterView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Activate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickInput()
	{
		throw null;
	}
}
