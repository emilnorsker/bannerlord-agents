using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;

namespace SandBox.Missions;

public class ChangeLightIntensityScript : ScriptComponentBehavior
{
	private enum State
	{
		None,
		Start,
		WaitBeforeChange,
		ChangingIntensity,
		End
	}

	[EditableScriptComponentVariable(true, "WaitBeforeChangeAsSeconds")]
	private float _waitBeforeChangeAsSeconds;

	[EditableScriptComponentVariable(true, "ChangeAmount")]
	private float _changeAmount;

	[EditableScriptComponentVariable(true, "ChangeSpeed")]
	private float _changeSpeed;

	private State _state;

	private float _currentChangeAmount;

	private float _currentTimeDt;

	public SimpleButton Preview;

	public SimpleButton Reset;

	private float _initialIntensityCacheForPreviewButton;

	private Light _lightComponent;

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
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChangeLightIntensityScript()
	{
		throw null;
	}
}
