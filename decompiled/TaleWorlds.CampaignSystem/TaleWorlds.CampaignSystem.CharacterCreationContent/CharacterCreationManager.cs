using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.CharacterCreationContent;

public class CharacterCreationManager
{
	private readonly MBList<CharacterCreationStageBase> _stages;

	private readonly MBList<NarrativeMenu> _narrativeMenus;

	public readonly Dictionary<NarrativeMenu, NarrativeMenuOption> SelectedOptions;

	private SortedList<int, ICharacterCreationContentHandler> _handlers;

	private readonly CharacterCreationState _state;

	private int _stageIndex;

	public readonly FaceGenHistory FaceGenHistory;

	private int _furthestStageIndex;

	public MBReadOnlyList<NarrativeMenu> NarrativeMenus
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public CharacterCreationContent CharacterCreationContent
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

	public NarrativeMenu CurrentMenu
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

	public int CharacterCreationMenuCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public CharacterCreationStageBase CurrentStage
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
	public CharacterCreationManager(CharacterCreationState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterCharacterCreationContentHandler(ICharacterCreationContentHandler characterCreationContentHandler, int priority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddStage(CharacterCreationStageBase stage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RemoveStage<T>() where T : CharacterCreationStageBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetStage<T>() where T : CharacterCreationStageBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void NextStage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreviousStage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GoToStage(int stageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ActivateStage(CharacterCreationStageBase stage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnStateActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetIndexOfCurrentStage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTotalStagesCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetFurthestIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNewMenu(NarrativeMenu menu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NarrativeMenu GetCurrentMenu(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<NarrativeMenuOption> GetCurrentMenuOptions(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NarrativeMenu GetNarrativeMenuWithId(string stringId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteNarrativeMenuWithId(string stringId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetNarrativeMenus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetMenuOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartNarrativeStage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TrySwitchToNextMenu()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ModifyMenuCharacters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TrySwitchToPreviousMenu()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnNarrativeMenuOptionSelected(NarrativeMenuOption option)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<NarrativeMenuOption> GetSuitableNarrativeMenuOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyFinalEffects()
	{
		throw null;
	}
}
