using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem;

public class AtmosphereGrid
{
	private struct AtmosphereStateSortData
	{
		public Vec3 Position;

		public int InitialIndex;
	}

	private List<AtmosphereState> states;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AtmosphereState GetInterpolatedStateInfo(Vec3 pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AtmosphereGrid()
	{
		throw null;
	}
}
