using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View;

public class PopupSceneSpawnPoint : ScriptComponentBehavior
{
	public string InitialAction;

	public string NegativeAction;

	public string InitialFaceAnimCode;

	public string PositiveFaceAnimCode;

	public string NegativeFaceAnimCode;

	public string PositiveAction;

	public string LeftHandWieldedItem;

	public string RightHandWieldedItem;

	public string BannerTagToUseForAddedPrefab;

	public bool StartWithRandomProgress;

	public Vec3 AttachedPrefabOffset;

	public string PrefabItem;

	public HumanBone PrefabBone;

	private AgentVisuals _mountAgentVisuals;

	private AgentVisuals _humanAgentVisuals;

	private ActionIndexCache _initialStateActionCode;

	private ActionIndexCache _positiveStateActionCode;

	private ActionIndexCache _negativeStateActionCode;

	public CompositeComponent AddedPrefabComponent
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
	public void InitializeWithAgentVisuals(AgentVisuals humanVisuals, AgentVisuals mountVisuals = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInitialState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPositiveState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNegativeState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Destroy()
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
	public PopupSceneSpawnPoint()
	{
		throw null;
	}
}
