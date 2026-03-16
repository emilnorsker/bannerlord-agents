using System.Runtime.CompilerServices;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem.BarterSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.ViewModelCollection.Map.MapConversation;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI.Map;

[OverrideView(typeof(MapConversationView))]
public class GauntletMapConversationView : MapConversationView, IConversationStateHandler
{
	private GauntletMovieIdentifier _conversationMovie;

	private GauntletLayer _layerAsGauntletLayer;

	private MapConversationVM _dataSource;

	private SpriteCategory _conversationCategory;

	private MapConversationTableauData _tableauData;

	private BarterManager _barterManager;

	private GauntletMapConversationBarterView _barterView;

	private ConversationCharacterData _playerCharacterData;

	private ConversationCharacterData _conversationPartnerData;

	private bool _isSwitchingConversations;

	private int _minimumAvailableConversationInstallFrame;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapConversationView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBarterActiveStateChanged(bool isBarterActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void InitializeConversation(ConversationCharacterData playerCharacterData, ConversationCharacterData conversationPartnerData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void FinalizeConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateConversationView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnContinue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroyConversationView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsEscaped()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsOpeningEscapeMenuOnFocusChangeAllowed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnIdleTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMenuModeTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateConversationTableau()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroyConversationTableau()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.OnConversationUninstall()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetContinueKeyText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.OnConversationInstall()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.OnConversationActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.OnConversationDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.OnConversationContinue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.ExecuteConversationContinue()
	{
		throw null;
	}
}
