using System.Runtime.CompilerServices;
using SandBox.View.Map;
using SandBox.ViewModelCollection.Map.Incidents;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Incidents;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI.Map;

[OverrideView(typeof(MapIncidentView))]
public class GauntletMapIncidentView : MapIncidentView
{
	private MapIncidentVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private SpriteCategory _spriteCategory;

	private bool _controlModeLockBeforeIncident;

	private CampaignTimeControlMode _controlModeBeforeIncident;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapIncidentView(Incident incident)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CreateLayout()
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
	private void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsOpeningEscapeMenuOnFocusChangeAllowed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCloseView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayIncidentSound()
	{
		throw null;
	}
}
