using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Objects;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.View.Missions.SandBox;

public class SpawnPointDebugView : ScriptComponentBehavior
{
	private enum CategoryId
	{
		NPC,
		Animal,
		Chair,
		Passage,
		OutOfMissionBound,
		SemivalidChair
	}

	private struct InvalidPosition
	{
		public Vec3 position;

		public GameEntity entity;

		public bool isDisabledNavMesh;

		public bool doNotShowWarning;
	}

	private const string BattleSetName = "sp_battle_set";

	private const string CenterConversationPoint = "center_conversation_point";

	private const float AgentRadius = 0.3f;

	public static bool ActivateDebugUI;

	public bool ActivateDebugUIEditor;

	private readonly bool _separatorNeeded;

	private readonly bool _onSameLineNeeded;

	private bool _townCenterRadioButton;

	private bool _tavernRadioButton;

	private bool _arenaRadioButton;

	private bool _villageRadioButton;

	private bool _lordshallRadioButton;

	private bool _castleRadioButton;

	private bool _basicInformationTab;

	private bool _entityInformationTab;

	private bool _navigationMeshCheckTab;

	private bool _inaccessiblePositionCheckTab;

	private bool _relatedEntityWindow;

	private string _relatedPrefabTag;

	private bool _workshopAndAlleyConflictWindow;

	private string _problematicAreaMarkerWarningText;

	private int _cameraFocusIndex;

	private bool _showNPCs;

	private bool _showChairs;

	private bool _showAnimals;

	private bool _showSemiValidPoints;

	private bool _showPassagePoints;

	private bool _showOutOfBoundPoints;

	private bool _showPassagesList;

	private bool _showAnimalsList;

	private bool _showNPCsList;

	private bool _showDontUseList;

	private bool _showOthersList;

	private string _sceneName;

	private SpawnPointUnits.SceneType _sceneType;

	private readonly bool _normalButton;

	private int _currentTownsfolkCount;

	private Vec3 _redColor;

	private Vec3 _greenColor;

	private Vec3 _blueColor;

	private Vec3 _yellowColor;

	private Vec3 _purbleColor;

	private uint _npcDebugLineColor;

	private uint _chairDebugLineColor;

	private uint _animalDebugLineColor;

	private uint _semivalidChairDebugLineColor;

	private uint _passageDebugLineColor;

	private uint _missionBoundDebugLineColor;

	private int _totalInvalidPoints;

	private int _currentInvalidPoints;

	private int _disabledFaceId;

	private int _particularfaceID;

	private Dictionary<CategoryId, List<InvalidPosition>> _invalidSpawnPointsDictionary;

	private string allPrefabsWithParticularTag;

	private IList<SpawnPointUnits> _spUnitsList;

	private List<NavigationPath> _allPathForPosition;

	private List<GameEntity> _allGameEntitiesWithAnimationScript;

	private List<GameEntity> _inaccessibleEntitiesList;

	private List<GameEntity> _closeEntitiesToInaccessible;

	private GameEntity _selectedEntity;

	private GameEntity _closeEntity;

	private PathFaceRecord _startPositionNavMesh;

	private PathFaceRecord _targetPositionNavMesh;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ToolMainFunction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowWorkshopAndAlleyConflictWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowRelatedEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowBasicInformationTab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleRadioButtons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChangeTab(bool basicInformationTab, bool entityInformationTab, bool navigationMeshCheckTab, bool navigationMeshCanWalkCheckTab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineSceneType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSpawnPointsToList(bool alreadyInitialized)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<List<string>> GetLevelCombinationsToCheck()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSceneSave(string saveFolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnCheckForProblems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowEntityInformationTab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateSpawnedAgentCount(SpawnPointUnits spUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CountEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForCommonAreas(IEnumerable<GameEntity> allGameEntitiesWithGivenTag, SpawnPointUnits spUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForWorkshops(IEnumerable<GameEntity> allGameEntitiesWithGivenTag, SpawnPointUnits spUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int FindValidSpawnPointCountOfUsableMachine(List<GameEntity> gameEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CountPassages(SpawnPointUnits spUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateCurrentInvalidPointsCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DetectWhichPassage(PassageUsePoint passageUsePoint, string spName, string locationName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowNavigationCheckTab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForNavigationMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckNavigationMeshForParticularEntity(GameEntity gameEntity, CategoryId categoryId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckSemiValidsOfChair(GameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfChairOrAnimal(SpawnPointUnits spUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfPassage(SpawnPointUnits spUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveDuplicateValuesInLists()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPositionToInvalidList(CategoryId categoryId, Vec3 globalPosition, GameEntity entity, bool isDisabledNavMesh, bool doNotShowWarning = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ToggleButtons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckInaccessiblePoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckInaccesiblePositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FindAllPrefabsWithSelectedTag()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FocusCameraToMisplacedObjects(CategoryId CategoryId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FocusCameraToInaccessiblePosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetCategoryCount(CategoryId CategoryId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetDisableFaceID()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearAllLists()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ImGUIButton(string buttonText, bool smallButton)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LeaveSpaceBetweenTabs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EndImGUIWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartImGUIWindow(string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ImGUITextArea(string text, bool separatorNeeded, bool onSameLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ImGUICheckBox(string text, ref bool is_checked, bool separatorNeeded, bool onSameLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ImguiSameLine(float positionX, float spacingWidth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ImGUISeparatorSameLineHandler(bool separatorNeeded, bool onSameLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSameLine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Separator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WriteLineOfTableDebug(SpawnPointUnits spUnit, Vec3 Color, string type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WriteNavigationMeshTabTexts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WriteInaccessiblePointTexts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DrawDebugLineForInaccesiblePositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DrawDebugLinesForInvalidSpawnPoints(CategoryId CategoryId, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WriteTableHeaders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpawnPointDebugView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SpawnPointDebugView()
	{
		throw null;
	}
}
