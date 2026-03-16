using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class MissionMethod : Attribute
{
	public bool UsableByEditor;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionMethod()
	{
		throw null;
	}
}
