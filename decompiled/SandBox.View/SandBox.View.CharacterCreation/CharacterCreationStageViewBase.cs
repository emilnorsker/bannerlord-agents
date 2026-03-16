using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ViewModelCollection.EscapeMenu;
using TaleWorlds.ScreenSystem;

namespace SandBox.View.CharacterCreation;

public abstract class CharacterCreationStageViewBase : ICharacterCreationStageListener
{
	protected readonly ControlCharacterCreationStage _affirmativeAction;

	protected readonly ControlCharacterCreationStage _negativeAction;

	protected readonly ControlCharacterCreationStage _refreshAction;

	protected readonly ControlCharacterCreationStageReturnInt _getTotalStageCountAction;

	protected readonly ControlCharacterCreationStageReturnInt _getCurrentStageIndexAction;

	protected readonly ControlCharacterCreationStageReturnInt _getFurthestIndexAction;

	protected readonly ControlCharacterCreationStageWithInt _goToIndexAction;

	protected readonly Vec3 _cameraPosition;

	private bool _isEscapeOpen;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected CharacterCreationStageViewBase(ControlCharacterCreationStage affirmativeAction, ControlCharacterCreationStage negativeAction, ControlCharacterCreationStage refreshAction, ControlCharacterCreationStageReturnInt getCurrentStageIndexAction, ControlCharacterCreationStageReturnInt getTotalStageCountAction, ControlCharacterCreationStageReturnInt getFurthestIndexAction, ControlCharacterCreationStageWithInt goToIndexAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void SetGenericScene(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnRefresh()
	{
		throw null;
	}

	public abstract IEnumerable<ScreenLayer> GetLayers();

	public abstract void NextStage();

	public abstract void PreviousStage();

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationStageListener.OnStageFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Tick(float dt)
	{
		throw null;
	}

	public abstract int GetVirtualStageCount();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void GoToIndex(int index)
	{
		throw null;
	}

	public abstract void LoadEscapeMenuMovie();

	public abstract void ReleaseEscapeMenuMovie();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleEscapeMenu(CharacterCreationStageViewBase view, ScreenLayer screenLayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenEscapeMenu(CharacterCreationStageViewBase view)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveEscapeMenu(CharacterCreationStageViewBase view)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<EscapeMenuItemVM> GetEscapeMenuItems(CharacterCreationStageViewBase view)
	{
		throw null;
	}
}
