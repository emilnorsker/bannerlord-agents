using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade;

public abstract class MPRandomOnSpawnPerkEffect : MPOnSpawnPerkEffectBase
{
	protected static Dictionary<string, Type> Registered;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MPRandomOnSpawnPerkEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MPRandomOnSpawnPerkEffect CreateFrom(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MPRandomOnSpawnPerkEffect()
	{
		throw null;
	}
}
