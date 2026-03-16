using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects.UsableMachines;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace NavalDLC.Storyline.Objectives.Quest5;

public class Quest5CutLooseObjective : MissionObjective
{
	private class CutLooseObjectiveTarget : MissionObjectiveTarget
	{
		private readonly ShipAttachmentMachine _attachmentMachine;

		private readonly ShipAttachmentPointMachine _attachmentPointMachine;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CutLooseObjectiveTarget(ShipAttachmentMachine attachmentMachine)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CutLooseObjectiveTarget(ShipAttachmentPointMachine attachmentPointMachine)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsActive()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsCutLoose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Vec3 GetGlobalPosition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override TextObject GetName()
		{
			throw null;
		}
	}

	private readonly MBReadOnlyList<ShipAttachmentMachine> _attachmentMachines;

	private readonly MBReadOnlyList<ShipAttachmentPointMachine> _attachmentPointMachines;

	private MissionObjectiveProgressInfo _cachedProgress;

	public override string UniqueId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject Description
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quest5CutLooseObjective(Mission mission, MBReadOnlyList<ShipAttachmentMachine> attachmentMachines, MBReadOnlyList<ShipAttachmentPointMachine> attachmentPointMachines)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MissionObjectiveProgressInfo GetCurrentProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsActivationRequirementsMet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsCompletionRequirementsMet()
	{
		throw null;
	}
}
