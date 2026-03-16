using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

[ScriptComponentParams("ship_visual_only", "ShipColorAssigner")]
public class ColorAssigner : ScriptComponentBehavior
{
	[EditableScriptComponentVariable(true, "Factor Color")]
	private Color _color;

	[EditableScriptComponentVariable(true, "Ram Debris Color")]
	private Color _ramDebrisColor;

	[EditableScriptComponentVariable(true, "Set Colors")]
	private SimpleButton _refreshButton;

	public Color ShipColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Color RamDebrisColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ColorAssigner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetColor(WeakGameEntity entity)
	{
		throw null;
	}
}
