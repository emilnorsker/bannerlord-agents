using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ViewModelCollection.Input;
using TaleWorlds.Library;

namespace StoryMode.ViewModelCollection.Missions;

public class TrainingObjectiveKeyVM : ViewModel
{
	public enum MovementTypes
	{
		None,
		MoveLeft,
		MoveRight,
		MoveUp,
		MoveDown
	}

	public enum InputTypes
	{
		MouseAndClick,
		Key,
		ControllerStick
	}

	public struct MouseAndClickInput
	{
		public MovementTypes CurrentMovementType;

		public MouseClickTypes CurrentClickType;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MouseAndClickInput(MovementTypes movementType, MouseClickTypes mouseClickType)
		{
			throw null;
		}
	}

	public struct KeyInput
	{
		public InputKeyItemVM InputKeyItemVM;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public KeyInput(int gameKeyDefinition, bool isCombatHotKey)
		{
			throw null;
		}
	}

	public struct ControllerStickInput
	{
		public MovementTypes CurrentMovementType;

		public bool IsLeftStick;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ControllerStickInput(MovementTypes movementType, bool isLeftStick)
		{
			throw null;
		}
	}

	public enum MouseClickTypes
	{
		Left,
		Middle,
		Right
	}

	private InputKeyItemVM _key;

	private string _forcedKeyId;

	private string _forcedKeyName;

	private int _movementType;

	private int _mouseClick;

	private int _inputType;

	[DataSourceProperty]
	public InputKeyItemVM Key
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
	public string ForcedKeyId
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
	public string ForcedKeyName
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
	public int MovementType
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
	public int MouseClick
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
	public int InputType
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
	public TrainingObjectiveKeyVM(MouseAndClickInput mouseAndClickInput)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TrainingObjectiveKeyVM(ControllerStickInput controllerStickInput)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TrainingObjectiveKeyVM(KeyInput keyInput)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnForcedKeyNameChanged(ControllerStickInput controllerStickInput)
	{
		throw null;
	}
}
