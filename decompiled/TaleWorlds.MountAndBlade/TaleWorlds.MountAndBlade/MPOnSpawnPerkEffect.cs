using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade;

public abstract class MPOnSpawnPerkEffect : MPOnSpawnPerkEffectBase
{
	protected static Dictionary<string, Type> Registered;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MPOnSpawnPerkEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MPOnSpawnPerkEffect CreateFrom(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MPOnSpawnPerkEffect()
	{
		throw null;
	}
}
