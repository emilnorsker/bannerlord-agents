using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.Scripts;

public class MapColorGradeManager : ScriptComponentBehavior
{
	private class ColorGradeBlendRecord
	{
		public string color1;

		public string color2;

		public float alpha;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ColorGradeBlendRecord()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ColorGradeBlendRecord(ColorGradeBlendRecord other)
		{
			throw null;
		}
	}

	public bool ColorGradeEnabled;

	public bool AtmosphereSimulationEnabled;

	public float TimeOfDay;

	public float SeasonTimeFactor;

	private string colorGradeGridName;

	private const int colorGradeGridSize = 262144;

	private byte[] colorGradeGrid;

	private Dictionary<byte, string> colorGradeGridMapping;

	private ColorGradeBlendRecord primaryTransitionRecord;

	private ColorGradeBlendRecord secondaryTransitionRecord;

	private byte lastColorGrade;

	private Vec2 terrainSize;

	private string defaultColorGradeTextureName;

	private const float transitionSpeedFactor = 1f;

	private float lastSceneTimeOfDay;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Init()
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
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReadColorGradesXml()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyAtmosphere(bool forceLoadTextures)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyColorGrade(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapColorGradeManager()
	{
		throw null;
	}
}
