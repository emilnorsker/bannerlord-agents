using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View.Scripts;

public class HandMorphTest : ScriptComponentBehavior
{
	private const bool CreateFaceImmediately = true;

	private readonly ActionIndexCache act_defend_up_fist_active;

	private readonly ActionIndexCache act_visual_test_morph_animation;

	private MBGameManager _editorGameManager;

	private bool _isFinished;

	private bool _characterSpawned;

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
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HandMorphTest()
	{
		throw null;
	}
}
