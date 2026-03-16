using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.Missions;

public class CameraJumpScript : ScriptComponentBehavior
{
	[EditableScriptComponentVariable(true, "WaitBeforeCameraJump")]
	private float _waitBeforeCameraJump;

	[EditableScriptComponentVariable(true, "CameraJumpPosition")]
	private Vec3 _cameraJumpPosition;

	[EditableScriptComponentVariable(true, "CameraJumpRotation")]
	private Vec3 _cameraJumpRotation;

	public SimpleButton SetCurrentCameraTransform;

	public SimpleButton Preview;

	public SimpleButton Reset;

	private MatrixFrame _initialGlobalFrame;

	private float _elapsedDuration;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorInit()
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
	private void OnJumpTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CameraJumpScript()
	{
		throw null;
	}
}
