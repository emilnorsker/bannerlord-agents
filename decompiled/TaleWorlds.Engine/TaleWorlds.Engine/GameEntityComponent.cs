using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

[EngineClass("rglEntity_component")]
public abstract class GameEntityComponent : NativeObject
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal GameEntityComponent(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity GetEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual MetaMesh GetFirstMetaMesh()
	{
		throw null;
	}
}
