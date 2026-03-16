using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.Source.Missions;

public class CaravanBattleMissionHandler : MissionLogic
{
	private GameEntity _entity;

	private int _unitCount;

	private bool _isCamelCulture;

	private bool _isCaravan;

	private readonly string[] _camelLoadHarnesses;

	private readonly string[] _camelMountableHarnesses;

	private readonly string[] _muleLoadHarnesses;

	private readonly string[] _muleMountableHarnesses;

	private const string CaravanPrefabName = "caravan_scattered_goods_prop";

	private const string VillagerGoodsPrefabName = "villager_scattered_goods_prop";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CaravanBattleMissionHandler(int unitCount, bool isCamelCulture, bool isCaravan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}
}
