using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;

namespace SandBox.View.CharacterCreation;

[GameStateScreen(typeof(CharacterCreationState))]
public class CharacterCreationScreen : ScreenBase, ICharacterCreationStateHandler, IGameStateListener
{
	private const string CultureParameterId = "MissionCulture";

	private readonly CharacterCreationState _characterCreationStateState;

	private IEnumerable<ScreenLayer> _shownLayers;

	private CharacterCreationStageViewBase _currentStageView;

	private readonly Dictionary<Type, Type> _stageViews;

	private SoundEvent _cultureAmbientSoundEvent;

	private Scene _genericScene;

	private MBAgentRendererSceneController _agentRendererSceneController;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CharacterCreationScreen(CharacterCreationState characterCreationState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateGenericScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StopSound()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationStateHandler.OnCharacterCreationFinalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationStateHandler.OnRefresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationStateHandler.OnStageCreated(CharacterCreationStageBase stage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectUnorderedStages()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectStagesFromAssembly(Assembly assembly)
	{
		throw null;
	}
}
