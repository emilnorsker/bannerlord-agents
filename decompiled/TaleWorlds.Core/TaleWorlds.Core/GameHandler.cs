using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public abstract class GameHandler : IEntityComponent
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	void IEntityComponent.OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IEntityComponent.OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnGameStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnGameEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnGameNetworkBegin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnGameNetworkEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnEarlyPlayerConnect(VirtualPlayer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnPlayerConnect(VirtualPlayer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnPlayerDisconnect(VirtualPlayer peer)
	{
		throw null;
	}

	public abstract void OnBeforeSave();

	public abstract void OnAfterSave();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GameHandler()
	{
		throw null;
	}
}
