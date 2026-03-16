using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox;

public class CampaignMapSiegePrefabEntityCache : ScriptComponentBehavior
{
	[EditableScriptComponentVariable(true, "")]
	private string _attackerBallistaPrefab;

	[EditableScriptComponentVariable(true, "")]
	private string _defenderBallistaPrefab;

	[EditableScriptComponentVariable(true, "")]
	private string _attackerFireBallistaPrefab;

	[EditableScriptComponentVariable(true, "")]
	private string _defenderFireBallistaPrefab;

	[EditableScriptComponentVariable(true, "")]
	private string _attackerMangonelPrefab;

	[EditableScriptComponentVariable(true, "")]
	private string _defenderMangonelPrefab;

	[EditableScriptComponentVariable(true, "")]
	private string _attackerFireMangonelPrefab;

	[EditableScriptComponentVariable(true, "")]
	private string _defenderFireMangonelPrefab;

	[EditableScriptComponentVariable(true, "")]
	private string _attackerTrebuchetPrefab;

	[EditableScriptComponentVariable(true, "")]
	private string _defenderTrebuchetPrefab;

	private MatrixFrame _attackerBallistaLaunchEntitialFrame;

	private MatrixFrame _defenderBallistaLaunchEntitialFrame;

	private MatrixFrame _attackerFireBallistaLaunchEntitialFrame;

	private MatrixFrame _defenderFireBallistaLaunchEntitialFrame;

	private MatrixFrame _attackerMangonelLaunchEntitialFrame;

	private MatrixFrame _defenderMangonelLaunchEntitialFrame;

	private MatrixFrame _attackerFireMangonelLaunchEntitialFrame;

	private MatrixFrame _defenderFireMangonelLaunchEntitialFrame;

	private MatrixFrame _attackerTrebuchetLaunchEntitialFrame;

	private MatrixFrame _defenderTrebuchetLaunchEntitialFrame;

	private Vec3 _attackerBallistaScale;

	private Vec3 _defenderBallistaScale;

	private Vec3 _attackerFireBallistaScale;

	private Vec3 _defenderFireBallistaScale;

	private Vec3 _attackerMangonelScale;

	private Vec3 _defenderMangonelScale;

	private Vec3 _attackerFireMangonelScale;

	private Vec3 _defenderFireMangonelScale;

	private Vec3 _attackerTrebuchetScale;

	private Vec3 _defenderTrebuchetScale;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetLaunchEntitialFrameForSiegeEngine(SiegeEngineType type, BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetScaleForSiegeEngine(SiegeEngineType type, BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignMapSiegePrefabEntityCache()
	{
		throw null;
	}
}
