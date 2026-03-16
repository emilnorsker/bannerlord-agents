using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade.GauntletUI;

namespace SandBox.GauntletUI;

public class SandBoxGauntletGameNotification : GauntletGameNotification
{
	private SoundEvent _currentNotificationSoundEvent;

	private bool _latestIsSoundPaused;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnReceiveNewNotification(GameNotificationItemVM notification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void UnregisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickSoundEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool GetShouldBeSuspended()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandBoxGauntletGameNotification()
	{
		throw null;
	}
}
