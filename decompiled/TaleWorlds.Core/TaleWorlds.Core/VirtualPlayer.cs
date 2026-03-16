using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.Core;

public class VirtualPlayer
{
	private const string DefaultPlayerBannerCode = "11.8.1.4345.4345.770.774.1.0.0.133.7.5.512.512.784.769.1.0.0";

	private static Dictionary<Type, object> _peerComponents;

	private static Dictionary<Type, uint> _peerComponentIds;

	private static Dictionary<uint, Type> _peerComponentTypes;

	private string _bannerCode;

	public readonly ICommunicator Communicator;

	private EntitySystem<PeerComponent> _peerEntitySystem;

	public Dictionary<int, List<int>> UsedCosmetics;

	public static Dictionary<Type, object> PeerComponents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string BannerCode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public BodyProperties BodyProperties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public int Race
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public bool IsFemale
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public PlayerId Id
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public int Index
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

	public bool IsMine
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string UserName
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

	public int ChosenBadgeIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static VirtualPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void FindPeerComponents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckAssemblyForPeerComponent(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void EnsurePeerTypeList<T>() where T : PeerComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void EnsurePeerTypeList(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<T> Peers<T>() where T : PeerComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VirtualPlayer(int index, string name, PlayerId playerID, ICommunicator communicator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T AddComponent<T>() where T : PeerComponent, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PeerComponent AddComponent(Type peerComponentType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PeerComponent AddComponent(uint componentId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PeerComponent GetComponent(uint componentId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetComponent<T>() where T : PeerComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PeerComponent GetComponent(Type peerComponentType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveComponent<T>(bool synched = true) where T : PeerComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveComponent(PeerComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDisconnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SynchronizeComponentsTo(VirtualPlayer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateIndexForReconnectingPlayer(int playerIndex)
	{
		throw null;
	}
}
