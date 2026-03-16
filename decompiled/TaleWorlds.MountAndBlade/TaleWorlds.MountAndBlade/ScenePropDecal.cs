using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class ScenePropDecal : ScriptComponentBehavior
{
	public string DiffuseTexture;

	public string NormalTexture;

	public string SpecularTexture;

	public string MaskTexture;

	public bool UseBaseNormals;

	public float TilingSize;

	public float TilingOffset;

	public float AlphaTestValue;

	public float TextureSweepX;

	public float TextureSweepY;

	public string MaterialName;

	protected Material UniqueMaterial;

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
	private void EnsureUniqueMaterial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetUpMaterial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScenePropDecal()
	{
		throw null;
	}
}
