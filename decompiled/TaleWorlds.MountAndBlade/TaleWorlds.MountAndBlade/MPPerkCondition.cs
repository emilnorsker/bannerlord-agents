using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade;

public abstract class MPPerkCondition
{
	[Flags]
	public enum PerkEventFlags
	{
		None = 0,
		MoraleChange = 1,
		FlagCapture = 2,
		FlagRemoval = 4,
		HealthChange = 8,
		AliveBotCountChange = 0x10,
		PeerControlledAgentChange = 0x20,
		BannerPickUp = 0x40,
		BannerDrop = 0x80,
		SpawnEnd = 0x100,
		MountHealthChange = 0x200,
		MountChange = 0x400,
		AgentEventsMask = 0x628
	}

	protected static Dictionary<string, Type> Registered;

	public virtual PerkEventFlags EventFlags
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual bool IsPeerCondition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MPPerkCondition()
	{
		throw null;
	}

	public abstract bool Check(MissionPeer peer);

	public abstract bool Check(Agent agent);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool IsGameModesValid(List<string> gameModes)
	{
		throw null;
	}

	protected abstract void Deserialize(XmlNode node);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MPPerkCondition CreateFrom(List<string> gameModes, XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MPPerkCondition()
	{
		throw null;
	}
}
public abstract class MPPerkCondition<T> : MPPerkCondition where T : MissionMultiplayerGameModeBase
{
	protected T GameModeInstance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsGameModesValid(List<string> gameModes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MPPerkCondition()
	{
		throw null;
	}
}
