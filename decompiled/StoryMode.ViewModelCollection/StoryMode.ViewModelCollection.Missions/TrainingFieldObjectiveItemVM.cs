using System.Runtime.CompilerServices;
using StoryMode.Missions;
using TaleWorlds.Library;

namespace StoryMode.ViewModelCollection.Missions;

public class TrainingFieldObjectiveItemVM : ViewModel
{
	private string _textObjectString;

	private TrainingFieldMissionController.MouseObjectives _currentMouseObjective;

	private TrainingFieldMissionController.ObjectivePerformingType _currentObjectivePerformingType;

	private bool _lastGamepadActive;

	private bool _hasBackground;

	private string _objectiveText;

	private string _arrowState;

	private bool _isCompleted;

	private bool _isActive;

	private bool _isBackgroundActive;

	private float _score;

	private MBBindingList<TrainingFieldObjectiveItemVM> _objectiveItems;

	private MBBindingList<TrainingObjectiveKeyVM> _objectiveKeys;

	[DataSourceProperty]
	public string ObjectiveText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsCompleted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsBackgroundActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<TrainingFieldObjectiveItemVM> ObjectiveItems
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<TrainingObjectiveKeyVM> ObjectiveKeys
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string ArrowState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TrainingFieldObjectiveItemVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TrainingFieldObjectiveItemVM(TrainingFieldMissionController.TutorialObjective objective)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateObjective(TrainingFieldMissionController.MouseObjectives currentMouseObjective, TrainingFieldMissionController.ObjectivePerformingType currentObjectivePerformingType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResolveInput(TrainingFieldMissionController.MouseObjectives currentMouseObjective, TrainingFieldMissionController.ObjectivePerformingType currentObjectivePerformingType, bool isGamepadActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TrainingObjectiveKeyVM.MovementTypes GetMovementTypeOfObjective(TrainingFieldMissionController.MouseObjectives mouseObjective)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetKeyOfMovementType(TrainingObjectiveKeyVM.MovementTypes movementType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsAttackMovement(TrainingFieldMissionController.MouseObjectives mouseObjective)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string DecideArrowDirection(TrainingObjectiveKeyVM.MovementTypes movement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TrainingFieldObjectiveItemVM CreateFromObjective(TrainingFieldMissionController.TutorialObjective objective)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TrainingFieldObjectiveItemVM CreateDummy()
	{
		throw null;
	}
}
