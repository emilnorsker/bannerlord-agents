using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class Mover : ScriptComponentBehavior
{
	[EditorVisibleScriptComponentVariable(true)]
	private string _pathname;

	[EditorVisibleScriptComponentVariable(true)]
	private float _speed;

	[EditorVisibleScriptComponentVariable(true)]
	private bool _moveGhost;

	private GameEntity _moverGhost;

	private PathTracker _tracker;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateOrUpdateMoverGhost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mover()
	{
		throw null;
	}
}
