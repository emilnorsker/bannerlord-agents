using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade;

public class MBProfileSelectionScreenBase : ScreenBase, IGameStateListener
{
	private ProfileSelectionState _state;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBProfileSelectionScreenBase(ProfileSelectionState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected sealed override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnProfileSelectionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnActivateProfileSelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnInitialize()
	{
		throw null;
	}
}
