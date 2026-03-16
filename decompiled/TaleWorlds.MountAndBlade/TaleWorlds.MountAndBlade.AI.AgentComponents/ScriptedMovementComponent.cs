using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.AI.AgentComponents;

public class ScriptedMovementComponent : AgentComponent
{
	private bool _isInDialogueRange;

	private readonly bool _isCharacterToTalkTo;

	private readonly float _dialogueTriggerProximity;

	private readonly float _agentSpeedLimit;

	private Agent _targetAgent;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptedMovementComponent(Agent agent, bool isCharacterToTalkTo = false, float dialogueProximityOffset = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetAgent(Agent targetAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ShouldConversationStartWithAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}
}
