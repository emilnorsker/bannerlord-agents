using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.Scripts;

public class CharacterDebugSpawner : ScriptComponentBehavior
{
	private readonly ActionIndexCache[] _actionIndices;

	public readonly ActionIndexCache PoseAction;

	public string LordName;

	public bool IsWeaponWielded;

	private Vec2 MovementDirection;

	private float MovementSpeed;

	private float PhaseDiff;

	private float Time;

	private float ActionSetTimer;

	private float ActionChangeInterval;

	private float MovementDirectionChange;

	private static MBGameManager _editorGameManager;

	private static int _editorGameManagerRefCount;

	private static bool isFinished;

	private static int gameTickFrameNo;

	private bool CreateFaceImmediately;

	private AgentVisuals _agentVisuals;

	public uint ClothColor1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public uint ClothColor2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
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
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClothColors(uint color1, uint color2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SpawnCharacter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitWithCharacter(CharacterCode characterCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WieldWeapon(CharacterCode characterCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CharacterDebugSpawner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CharacterDebugSpawner()
	{
		throw null;
	}
}
