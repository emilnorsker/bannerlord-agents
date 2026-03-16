using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class TutorialArea : MissionObject
{
	public enum TrainingType
	{
		Bow,
		Melee,
		Mounted,
		AdvancedMelee
	}

	private struct TutorialEntity
	{
		public string Tag;

		public List<Tuple<GameEntity, MatrixFrame>> EntityList;

		public List<DestructableComponent> DestructableComponents;

		public List<GameEntity> WeaponList;

		public List<ItemObject> WeaponNames;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TutorialEntity(string tag, List<Tuple<GameEntity, MatrixFrame>> entityList, List<DestructableComponent> destructableComponents, List<GameEntity> weapon, List<ItemObject> weaponNames)
		{
			throw null;
		}
	}

	[EditableScriptComponentVariable(true, "")]
	private TrainingType _typeOfTraining;

	[EditableScriptComponentVariable(true, "")]
	private string _tagPrefix;

	private readonly List<TutorialEntity> _tagWeapon;

	private readonly List<VolumeBox> _volumeBoxes;

	private readonly List<GameEntity> _boundaries;

	private bool _boundariesHidden;

	private readonly List<GameEntity> _highlightedEntities;

	private readonly List<ItemObject> _allowedWeaponsHelper;

	private readonly MBList<TrainingIcon> _trainingIcons;

	public MBReadOnlyList<TrainingIcon> TrainingIconsReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TrainingType TypeOfTraining
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorInit()
	{
		throw null;
	}

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
	public override void AfterMissionStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GatherWeapons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MarkTrainingIcons(bool mark)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TrainingIcon GetActiveTrainingIcon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBoundary(GameEntity boundary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddTaggedWeapon(GameEntity weapon, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetIndexFromTag(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<string> GetSubTrainingTags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateTaggedWeapons(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EquipWeaponsToPlayer(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeactivateAllWeapons(bool resetDestructibles)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateBoundaries()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HideBoundaries()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetBreakablesCount(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeDestructible(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MarkAllTargets(int index, bool mark)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetMarkingTargetTimers(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeInDestructible(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AllBreakablesAreBroken(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetBrokenBreakableCount(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetUnbrokenBreakableCount(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetBreakables(int index, bool makeIndestructible = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasMainAgentPickedAll(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckMainAgentEquipment(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckWeapons(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionInsideTutorialArea(Vec3 position, out string[] volumeBoxTags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TutorialArea()
	{
		throw null;
	}
}
