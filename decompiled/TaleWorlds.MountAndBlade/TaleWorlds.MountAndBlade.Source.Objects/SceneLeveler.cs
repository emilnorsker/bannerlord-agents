using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.Source.Objects;

public class SceneLeveler : ScriptComponentBehavior
{
	public string SourceSelectionSetName;

	public string TargetSelectionSetName;

	public SimpleButton CreateLevel1;

	public SimpleButton CreateLevel2;

	public SimpleButton CreateLevel3;

	public SimpleButton DeleteLevel1;

	public SimpleButton DeleteLevel2;

	public SimpleButton DeleteLevel3;

	public SimpleButton SelectEntitiesWithoutLevel;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnLevelizeButtonPressed(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CopyScriptParameters(GameEntity entity, GameEntity copyFromEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity.UpgradeLevelMask GetLevelMask(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetLevelSubString(GameEntity.UpgradeLevelMask levelMask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string ConvertPrefabName(string prefabName, GameEntity.UpgradeLevelMask newLevelMask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string FindPossiblePrefabName(GameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDeleteButtonPressed(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelectEntitiesWithoutLevelButtonPressed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<GameEntity> CollectEntitiesWithLevel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SceneLeveler()
	{
		throw null;
	}
}
