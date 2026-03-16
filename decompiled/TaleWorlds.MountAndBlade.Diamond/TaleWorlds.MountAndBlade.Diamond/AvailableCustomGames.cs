using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.MountAndBlade.Diamond;

[Serializable]
public class AvailableCustomGames
{
	[JsonProperty]
	public List<GameServerEntry> CustomGameServerInfos
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AvailableCustomGames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AvailableCustomGames GetCustomGamesByPermission(int playerPermission)
	{
		throw null;
	}
}
