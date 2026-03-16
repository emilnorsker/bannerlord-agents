using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.MountAndBlade.GauntletUI.Mission;

[DefaultView]
public class MissionGauntletCategoryLoadManager : MissionView, IMissionListener
{
	private SpriteCategory _fullBackgroundCategory;

	private SpriteCategory _mapBarCategory;

	private SpriteCategory _encyclopediaCategory;

	private MissionGauntletOptionsUIHandler _optionsView;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleCategoryLoadingUnloading()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadUnloadAllCategories(bool load)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsBackgroundsUsedInMission(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnEquipItemsFromSpawnEquipmentBegin(Agent agent, CreationType creationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnEquipItemsFromSpawnEquipment(Agent agent, CreationType creationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnMissionModeChange(MissionMode oldMissionMode, bool atStart)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnConversationCharacterChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnResetMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMissionListener.OnDeploymentPlanMade(Team team, bool isFirstPlan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletCategoryLoadManager()
	{
		throw null;
	}
}
