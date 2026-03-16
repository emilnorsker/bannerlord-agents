using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class MapAtmosphereProbe : ScriptComponentBehavior
{
	public bool visualizeRadius;

	public bool hideAllProbes;

	public static bool hideAllProbesStatic;

	public float minRadius;

	public float maxRadius;

	public float rainDensity;

	public float temperature;

	public string atmosphereType;

	public string colorGrade;

	private MetaMesh innerSphereMesh;

	private MetaMesh outerSphereMesh;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetInfluenceAmount(Vec3 worldPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapAtmosphereProbe()
	{
		throw null;
	}

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
	static MapAtmosphereProbe()
	{
		throw null;
	}
}
