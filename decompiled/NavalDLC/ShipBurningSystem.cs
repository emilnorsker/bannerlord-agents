using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

[ScriptComponentParams("ship_visual_only", "")]
internal class ShipBurningSystem : ScriptComponentBehavior
{
	private const string RailingParentTag = "railing_parent";

	private bool _fireStarted;

	private BurningSystem _railingFire;

	private BurningSystem _shipDeckFire;

	private BurningSystem _deckUpgradeFire;

	private BurningSystem _mastFire;

	private List<BurningNode> _railingNodes;

	private List<BurningNode> _shipDeckNodes;

	private List<BurningNode> _deckUpgradeNodes;

	private List<BurningNode> _mastNodes;

	private List<BurningSoundNode> _soundNodes;

	private List<Light> _burningLights;

	private MBFastRandom _randomGenerator;

	private List<BurningNode> _temporaryBurningNodes;

	[EditableScriptComponentVariable(true, "Start Fire")]
	private SimpleButton _startFire;

	[EditableScriptComponentVariable(true, "Stop Fire")]
	private SimpleButton _stopFire;

	[EditableScriptComponentVariable(true, "Spread Rate")]
	private float _spreadRate;

	[EditableScriptComponentVariable(true, "Fire Start Random Count")]
	private int _fireStartRandomCount;

	[EditableScriptComponentVariable(true, "All Fire Mode")]
	private bool _allFireMode;

	[EditableScriptComponentVariable(true, "Small Hit Debug")]
	private bool _hitDebug;

	[EditableScriptComponentVariable(true, "Min Fire Progress For Light")]
	private float _minFireProgressLight;

	[EditableScriptComponentVariable(true, "Max Fire Progress For Light")]
	private float _maxFireProgressLight;

	[EditableScriptComponentVariable(true, "Max Light Intensity")]
	private float _maxLightIntensity;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DummyFunc()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipBurningSystem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickFire(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillFireSystemWithNodes(ref List<BurningNode> nodes, ref BurningSystem fire)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FetchEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleTemporaryBurningNodes(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterBlowAux(Vec3 collisionPosition, List<BurningNode> nodes, BurningSystem fire)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterBlow(Vec3 collisionPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartFire()
	{
		throw null;
	}
}
