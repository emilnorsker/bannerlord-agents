using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class ScenePropPositiveLight : ScriptComponentBehavior
{
	public float Flatness_X;

	public float Flatness_Y;

	public float Flatness_Z;

	public float DirectLightRed;

	public float DirectLightGreen;

	public float DirectLightBlue;

	public float DirectLightIntensity;

	public float AmbientLightRed;

	public float AmbientLightGreen;

	public float AmbientLightBlue;

	public float AmbientLightIntensity;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMeshParams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private uint CalculateFactor(Vec3 color, float alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override bool IsOnlyVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScenePropPositiveLight()
	{
		throw null;
	}
}
