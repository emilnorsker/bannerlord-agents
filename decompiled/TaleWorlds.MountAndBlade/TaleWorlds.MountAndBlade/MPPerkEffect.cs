using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade;

public abstract class MPPerkEffect : MPPerkEffectBase
{
	protected static Dictionary<string, Type> Registered;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MPPerkEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MPPerkEffect CreateFrom(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MPPerkEffect()
	{
		throw null;
	}
}
