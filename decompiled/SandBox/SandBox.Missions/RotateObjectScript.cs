using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.Missions;

public class RotateObjectScript : ScriptComponentBehavior
{
	private enum State
	{
		None,
		Start,
		WaitBeforeRotate,
		Rotating,
		End
	}

	[EditableScriptComponentVariable(true, "RotationAxis")]
	private string _rotationAxis;

	[EditableScriptComponentVariable(true, "WaitBeforeRotateAsSeconds")]
	private float _waitBeforeRotateAsSeconds;

	[EditableScriptComponentVariable(true, "RotateAngle")]
	private float _rotateAngle;

	[EditableScriptComponentVariable(true, "RotationSpeed")]
	private float _rotationSpeed;

	public SimpleButton PreviewRotateObject;

	public SimpleButton StopMovement;

	private MatrixFrame _initialFrameCacheForPreviewRotateObjectButton;

	private State _state;

	private float _currentRotationAngle;

	private float _currentTimeDt;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTickInternal(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetRotationAxis()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RotateObjectScript()
	{
		throw null;
	}
}
