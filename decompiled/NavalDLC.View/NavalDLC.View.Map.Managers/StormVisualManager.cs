using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Map;
using NavalDLC.View.Map.Visuals;
using SandBox.View.Map;
using SandBox.View.Map.Managers;
using SandBox.View.Map.Visuals;

namespace NavalDLC.View.Map.Managers;

public class StormVisualManager : EntityVisualManagerBase<Storm>
{
	private readonly List<StormVisual> _allStormVisuals;

	public static StormVisualManager Current
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int Priority
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StormVisualManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StormCreated(Storm storm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MapEntityVisual<Storm> GetVisualOfEntity(Storm entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnVisualTick(MapScreen screen, float realDt, float dt)
	{
		throw null;
	}
}
