using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.GauntletUI.Map;

public class GauntletMapEventVisual : IMapEventVisual
{
	private static int _battleSoundEventIndex;

	private static int _navalBattleSoundEventIndex;

	private static int _raidSoundEventIndex;

	private static int _siegeSoundEventIndex;

	private static int _hideoutBattleSoundEventIndex;

	private SoundEvent _mapEventSoundEvent;

	private readonly Action<GauntletMapEventVisual> _onDeactivate;

	private readonly Action<GauntletMapEventVisual> _onInitialized;

	private readonly Action<GauntletMapEventVisual> _onVisibilityChanged;

	private Scene _mapScene;

	public MapEvent MapEvent
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

	public Vec2 WorldPosition
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

	public bool IsVisible
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

	private Scene MapScene
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapEventVisual(MapEvent mapEvent, Action<GauntletMapEventVisual> onInitialized, Action<GauntletMapEventVisual> onVisibilityChanged, Action<GauntletMapEventVisual> onDeactivate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(CampaignVec2 position, int battleSizeValue, bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMapEventEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVisibility(bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GauntletMapEventVisual()
	{
		throw null;
	}
}
