using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class VisualShipFactory
{
	private static readonly Dictionary<string, GameEntity> _shipEntityCache;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeShipEntityCache(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DeregisterVisualShipCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GameEntity CreateVisualShip(string shipPrefab, Scene scene, List<ShipVisualSlotInfo> upgrades, int shipSeed, float hitPointRatio, uint sailColor1 = uint.MaxValue, uint sailColor2 = uint.MaxValue, bool createPhysics = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GameEntity CreateVisualShipForCampaign(string shipPrefab, Scene scene, List<ShipVisualSlotInfo> upgrades, int shipSeed, string shipCustomSailPatternId, uint sailColor1 = uint.MaxValue, uint sailColor2 = uint.MaxValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RefreshUpgrades(WeakGameEntity shipEntity, List<ShipVisualSlotInfo> upgrades)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VisualShipFactory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static VisualShipFactory()
	{
		throw null;
	}
}
