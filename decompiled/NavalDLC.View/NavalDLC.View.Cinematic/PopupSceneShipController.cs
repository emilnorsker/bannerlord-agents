using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.View.Cinematic;

public class PopupSceneShipController : ScriptComponentBehavior
{
	[EditableScriptComponentVariable(true, "")]
	private Vec3 _continousForce;

	[EditableScriptComponentVariable(true, "")]
	private bool _isAnchored;

	[EditableScriptComponentVariable(true, "")]
	private string _targetShipEntityTag;

	private GameEntity _targetShipEntity;

	private MatrixFrame _initialShipFrame;

	private bool _isApplyingForce;

	public SimpleButton StartApplyingForce;

	public SimpleButton StopApplyingForce;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PopupSceneShipController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnParallelFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyForce(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}
}
