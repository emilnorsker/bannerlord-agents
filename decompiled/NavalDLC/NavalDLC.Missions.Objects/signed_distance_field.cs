using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.Missions.Objects;

[ScriptComponentParams("ship_visual_only", "")]
public class signed_distance_field : ScriptComponentBehavior
{
	[EditableScriptComponentVariable(true, "SDF Texture")]
	private Texture _sdfTexture;

	[EditableScriptComponentVariable(true, "Visualize SDF")]
	private bool _visualizeSDF;

	private int _sdfIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DummyFunc()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private signed_distance_field()
	{
		throw null;
	}

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
	protected override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame ComputeBBOXFrame(ref Vec3 sdfBBExtend)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSDFParams()
	{
		throw null;
	}
}
