using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace SandBox.View.Map;

public class SnowAndRainTextureDefiner : ScriptComponentBehavior
{
	[EditorVisibleScriptComponentVariable(true)]
	public Texture SnowAndRainTexture;

	[EditorVisibleScriptComponentVariable(true)]
	public int WeatherNodeGridWidthAndHeight;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTerrainReload(int step)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetDataToScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SnowAndRainTextureDefiner()
	{
		throw null;
	}
}
