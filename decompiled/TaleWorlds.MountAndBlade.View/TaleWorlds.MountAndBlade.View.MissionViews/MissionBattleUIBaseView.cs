using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.View.MissionViews;

public abstract class MissionBattleUIBaseView : MissionView
{
	public bool IsViewCreated
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

	protected abstract void OnCreateView();

	protected abstract void OnDestroyView();

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEnableView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDisableView()
	{
		throw null;
	}

	protected abstract override void OnSuspendView();

	protected abstract override void OnResumeView();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MissionBattleUIBaseView()
	{
		throw null;
	}
}
