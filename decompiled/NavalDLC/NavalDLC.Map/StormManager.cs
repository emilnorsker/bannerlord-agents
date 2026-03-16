using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Handlers;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;

namespace NavalDLC.Map;

public class StormManager : ICustomSystemManager
{
	[SaveableField(10)]
	private MBList<Storm> _spawnedStorms;

	public bool DebugVisualsEnabled;

	public bool DebugVisualsStopped;

	public MBReadOnlyList<Storm> SpawnedStorms
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StormManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CampaignTick(float campaignDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StormCollisionTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateStormAtPosition(Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateStormAtPosition(Vec2 position, Storm.StormTypes stormType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAfterLoad()
	{
		throw null;
	}
}
