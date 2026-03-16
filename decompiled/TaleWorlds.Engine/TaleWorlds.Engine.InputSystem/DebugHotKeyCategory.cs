using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;

namespace TaleWorlds.Engine.InputSystem;

public class DebugHotKeyCategory : GameKeyContext
{
	public const string CategoryId = "Debug";

	public const string LeftMouseButton = "LeftMouseButton";

	public const string RightMouseButton = "RightMouseButton";

	public const string SelectAll = "SelectAll";

	public const string Redo = "Redo";

	public const string Undo = "Undo";

	public const string Copy = "Copy";

	public const string Duplicate = "Duplicate";

	public const string Score = "Score";

	public const string SetOriginToZero = "SetOriginToZero";

	public const string TestEngineCrash = "TestEngineCrash";

	public const string AgentHotkeySwitchRender = "AgentHotkeySwitchRender";

	public const string AgentHotkeySwitchFaceAnimationDebug = "AgentHotkeySwitchFaceAnimationDebug";

	public const string AgentHotkeyCheckCollisionCapsule = "AgentHotkeyCheckCollisionCapsule";

	public const string EngineInterfaceHotkeyWireframe = "EngineInterfaceHotkeyWireframe";

	public const string EngineInterfaceHotkeyWireframe2 = "EngineInterfaceHotkeyWireframe2";

	public const string EngineInterfaceHotkeyTakeScreenShot = "EngineInterfaceHotkeyTakeScreenShot";

	public const string EditingManagerHotkeyCrashReporting = "EditingManagerHotkeyCrashReporting";

	public const string EditingManagerHotkeyEmergencySceneSaving = "EditingManagerHotkeyEmergencySceneSaving";

	public const string EditingManagerHotkeyAssertTestEntityOperations = "EditingManagerHotkeyAssertTestEntityOperations";

	public const string EditingManagerHotkeyUpdateSceneDialog = "EditingManagerHotkeyUpdateSceneDialog";

	public const string EditingManagerHotkeySetTriadToWorld = "EditingManagerHotkeySetTriadToWorld";

	public const string EditingManagerHotkeySetTriadToLocal = "EditingManagerHotkeySetTriadToLocal";

	public const string EditingManagerHotkeySetTriadToScreen = "EditingManagerHotkeySetTriadToScreen";

	public const string EditingManagerHotkeyCameraSmoothMode = "EditingManagerHotkeyCameraSmoothMode";

	public const string EditingManagerHotkeyDisplayNormalsOfSelectedEntities = "EditingManagerHotkeyDisplayNormalsOfSelectedEntities";

	public const string EditingManagerHotkeyChoosePhysicsMaterial = "EditingManagerHotkeyChoosePhysicsMaterial";

	public const string EditingManagerHotkeySwitchObjectsLockedForSelection = "EditingManagerHotkeySwitchObjectsLockedForSelection";

	public const string ApplicationHotkeyAnimationReload = "ApplicationHotkeyAnimationReload";

	public const string ApplicationHotkeyIncreasePingDelay = "ApplicationHotkeyIncreasePingDelay";

	public const string ApplicationHotkeyIncreaseLossRatio = "ApplicationHotkeyIncreaseLossRatio";

	public const string ApplicationHotkeySaveAllContentFilesWithType = "ApplicationHotkeySaveAllContentFilesWithType";

	public const string MissionHotkeySwitchAnimationDebugSystem = "MissionHotkeySwitchAnimationDebugSystem";

	public const string MissionHotkeyAssignMainAgentToDebugAgent = "MissionHotkeyAssignMainAgentToDebugAgent";

	public const string MissionHotkeyUseProgrammerSound = "MissionHotkeyUseProgrammerSound";

	public const string MissionHotkeySetDebugPathStartPos = "MissionHotkeySetDebugPathStartPos";

	public const string MissionHotkeySetDebugPathEndPos = "MissionHotkeySetDebugPathEndPos";

	public const string MissionHotkeyRenderCombatCollisionCapsules = "MissionHotkeyRenderCombatCollisionCapsules";

	public const string ModelviewerHotkeyApplyUpwardsForce = "ModelviewerHotkeyApplyUpwardsForce";

	public const string ModelviewerHotkeyApplyDownwardsForce = "ModelviewerHotkeyApplyDownwardsForce";

	public const string NavigationMeshBuilderHotkeyMakeFourLastVerticesFace = "NavigationMeshBuilderHotkeyMakeFourLastVerticesFace";

	public const string CameraControllerHotkeyMoveForward = "CameraControllerHotkeyMoveForward";

	public const string CameraControllerHotkeyMoveBackward = "CameraControllerHotkeyMoveBackward";

	public const string CameraControllerHotkeyMoveLeft = "CameraControllerHotkeyMoveLeft";

	public const string CameraControllerHotkeyMoveRight = "CameraControllerHotkeyMoveRight";

	public const string CameraControllerHotkeyMoveUpward = "CameraControllerHotkeyMoveUpward";

	public const string CameraControllerHotkeyMoveDownward = "CameraControllerHotkeyMoveDownward";

	public const string CameraControllerHotkeyPenCamera = "CameraControllerHotkeyPenCamera";

	public const string ClothSimulationHotkeyResetAllMeshes = "ClothSimulationHotkeyResetAllMeshes";

	public const string EngineInterfaceHotkeySwitchForwardPhysicxDebugMode = "EngineInterfaceHotkeySwitchForwardPhysicxDebugMode";

	public const string EngineInterfaceHotkeySwitchBackwardPhysicxDebugMode = "EngineInterfaceHotkeySwitchBackwardPhysicxDebugMode";

	public const string EngineInterfaceHotkeyShowPhysicsDebugInfo = "EngineInterfaceHotkeyShowPhysicsDebugInfo";

	public const string EngineInterfaceHotkeyShowProfileModes = "EngineInterfaceHotkeyShowProfileModes";

	public const string EngineInterfaceHotkeyShowDebugInfo = "EngineInterfaceHotkeyShowDebugInfo";

	public const string EngineInterfaceHotkeyDecreaseByTenDrawOneByOneIndex = "EngineInterfaceHotkeyDecreaseByTenDrawOneByOneIndex";

	public const string EngineInterfaceHotkeyIncreaseByTenDrawOneByOneIndex = "EngineInterfaceHotkeyIncreaseByTenDrawOneByOneIndex";

	public const string EngineInterfaceHotkeyDecreaseDrawOneByOneIndex = "EngineInterfaceHotkeyDecreaseDrawOneByOneIndex";

	public const string EngineInterfaceHotkeyIncreaseDrawOneByOneIndex = "EngineInterfaceHotkeyIncreaseDrawOneByOneIndex";

	public const string EngineInterfaceHotkeyForceSetDrawOneByOneIndexMinusone = "EngineInterfaceHotkeyForceSetDrawOneByOneIndexMinusone";

	public const string EngineInterfaceHotkeySetDrawOneByOneIndexMinusone = "EngineInterfaceHotkeySetDrawOneByOneIndexMinusone";

	public const string EngineInterfaceHotkeyReleaseUnusedMemory = "EngineInterfaceHotkeyReleaseUnusedMemory";

	public const string EngineInterfaceHotkeyChangeShaderVisualizationMode = "EngineInterfaceHotkeyChangeShaderVisualizationMode";

	public const string EngineInterfaceHotkeyOnlyRenderDeferredQuad = "EngineInterfaceHotkeyOnlyRenderDeferredQuad";

	public const string EngineInterfaceHotkeyOnlyRenderNonDeferredMeshes = "EngineInterfaceHotkeyOnlyRenderNonDeferredMeshes";

	public const string EngineInterfaceHotkeyChangeAnimationDebugMode = "EngineInterfaceHotkeyChangeAnimationDebugMode";

	public const string EngineInterfaceHotkeyTestAssertReport = "EngineInterfaceHotkeyTestAssertReport";

	public const string EngineInterfaceHotkeyTestCreateBugReportTask = "EngineInterfaceHotkeyTestCreateBugReportTask";

	public const string EngineInterfaceHotkeySlowmotion = "EngineInterfaceHotkeySlowmotion";

	public const string EngineInterfaceHotkeyRecompileShader = "EngineInterfaceHotkeyRecompileShader";

	public const string EngineInterfaceHotkeyToggleConsole = "EngineInterfaceHotkeyToggleConsole";

	public const string EngineInterfaceHotkeyShowConsoleManager = "EngineInterfaceHotkeyShowConsoleManager";

	public const string EngineInterfaceHotkeyShowDebugTools = "EngineInterfaceHotkeyShowDebugTools";

	public const string SceneHotkeyIncreaseEnforcedSkyboxIndex = "SceneHotkeyIncreaseEnforcedSkyboxIndex";

	public const string SceneHotkeyDecreaseEnforcedSkyboxIndex = "SceneHotkeyDecreaseEnforcedSkyboxIndex";

	public const string SceneHotkeyCheckBoundingBoxCorrectness = "SceneHotkeyCheckBoundingBoxCorrectness";

	public const string SceneHotkeyShowNavigationMeshIds = "SceneHotkeyShowNavigationMeshIds";

	public const string SceneHotkeyShowNavigationMeshIdsXray = "SceneHotkeyShowNavigationMeshIdsXray";

	public const string SceneHotkeyShowNavigationMeshIslands = "SceneHotkeyShowNavigationMeshIslands";

	public const string SceneHotkeySetNewCharacterDetailModifier = "SceneHotkeySetNewCharacterDetailModifier";

	public const string SceneHotkeyShowTerrainMaterials = "SceneHotkeyShowTerrainMaterials";

	public const string SceneViewHotkeyTakeHighQualityScreenshot = "SceneViewHotkeyTakeHighQualityScreenshot";

	public const string SoundManagerHotkeyReloadSounds = "SoundManagerHotkeyReloadSounds";

	public const string ReplayEditorHotkeyRenderSounds = "ReplayEditorHotkeyRenderSounds";

	public const string FrameMoveTaskHotkeyUseTelemetryProfiler = "FrameMoveTaskHotkeyUseTelemetryProfiler";

	public const string SkeletonHotkeyActivateDisableAnimationFpsOptimization = "SkeletonHotkeyActivateDisableAnimationFpsOptimization";

	public const string SkeletonHotkeyDisactiveDisableAnimationFpsOptimization = "SkeletonHotkeyDisactiveDisableAnimationFpsOptimization";

	public const string LibraryHotkeyDisableCommitChanges = "LibraryHotkeyDisableCommitChanges";

	public const string Numpad0 = "Numpad0";

	public const string Numpad1 = "Numpad1";

	public const string Numpad3 = "Numpad3";

	public const string Numpad5 = "Numpad5";

	public const string Numpad7 = "Numpad7";

	public const string Numpad9 = "Numpad9";

	public const string D0 = "D0";

	public const string D1 = "D1";

	public const string D2 = "D2";

	public const string D3 = "D3";

	public const string D4 = "D4";

	public const string D5 = "D5";

	public const string D6 = "D6";

	public const string D7 = "D7";

	public const string D8 = "D8";

	public const string D9 = "D9";

	public const string F1 = "F1";

	public const string F2 = "F2";

	public const string F3 = "F3";

	public const string F4 = "F4";

	public const string F5 = "F5";

	public const string F6 = "F6";

	public const string F7 = "F7";

	public const string F8 = "F8";

	public const string F9 = "F9";

	public const string F10 = "F10";

	public const string F11 = "F11";

	public const string Y = "Y";

	public const string A = "A";

	public const string F = "F";

	public const string B = "B";

	public const string N = "N";

	public const string C = "C";

	public const string E = "E";

	public const string J = "J";

	public const string Q = "Q";

	public const string H = "H";

	public const string W = "W";

	public const string S = "S";

	public const string U = "U";

	public const string T = "T";

	public const string K = "K";

	public const string M = "M";

	public const string G = "G";

	public const string D = "D";

	public const string Space = "Space";

	public const string UpArrow = "UpArrow";

	public const string LeftArrow = "LeftArrow";

	public const string DownArrow = "DownArrow";

	public const string RightArrow = "RightArrow";

	public const string NumpadArrowForward = "NumpadArrowForward";

	public const string NumpadArrowBackward = "NumpadArrowBackward";

	public const string NumpadArrowLeft = "NumpadArrowLeft";

	public const string NumpadArrowRight = "NumpadArrowRight";

	public const string SwapToEnemy = "SwapToEnemy";

	public const string ChangeEnemyTeam = "ChangeEnemyTeam";

	public const string Paste = "Paste";

	public const string Cut = "Cut";

	public const string Refresh = "Refresh";

	public const string EnterEditMode = "EnterEditMode";

	public const string FixSkeletons = "FixSkeletons";

	public const string Reset = "Reset";

	public const string AnimationTestControllerHotkeyUseWeaponTesting = "AnimationTestControllerHotkeyUseWeaponTesting";

	public const string BaseBattleMissionControllerHotkeyBecomePlayer = "BaseBattleMissionControllerHotkeyBecomePlayer";

	public const string BaseBattleMissionControllerHotkeyDrawNavMeshLines = "BaseBattleMissionControllerHotkeyDrawNavMeshLines";

	public const string ModuleHotkeyOpenDebug = "ModuleHotkeyOpenDebug";

	public const string FormationTestMissionControllerHotkeyChargeSide = "FormationTestMissionControllerHotkeyChargeSide";

	public const string FormationTestMissionControllerHotkeyToggleSide = "FormationTestMissionControllerHotkeyToggleSide";

	public const string FormationTestMissionControllerHotkeyToggleFactionBackward = "FormationTestMissionControllerHotkeyToggleFactionBackward";

	public const string FormationTestMissionControllerHotkeyToggleFactionForward = "FormationTestMissionControllerHotkeyToggleFactionForward";

	public const string FormationTestMissionControllerHotkeyToggleTroopForward = "FormationTestMissionControllerHotkeyToggleTroopForward";

	public const string FormationTestMissionControllerHotkeyToggleTroopBackward = "FormationTestMissionControllerHotkeyToggleTroopBackward";

	public const string FormationTestMissionControllerHotkeyIncreaseSpawnCount = "FormationTestMissionControllerHotkeyIncreaseSpawnCount";

	public const string FormationTestMissionControllerHotkeyDecreaseSpawnCount = "FormationTestMissionControllerHotkeyDecreaseSpawnCount";

	public const string FormationTestMissionControllerHotkeySpawnCustom = "FormationTestMissionControllerHotkeySpawnCustom";

	public const string FormationTestMissionControllerHotkeyOrderLooseAndInfantryFormation = "FormationTestMissionControllerHotkeyOrderLooseAndInfantryFormation";

	public const string FormationTestMissionControllerHotkeyOrderScatterAndRangedFormation = "FormationTestMissionControllerHotkeyOrderScatterAndRangedFormation";

	public const string FormationTestMissionControllerHotkeyOrderSkeinAndCavalryFormation = "FormationTestMissionControllerHotkeyOrderSkeinAndCavalryFormation";

	public const string FormationTestMissionControllerHotkeyOrderLineAndHorseArcherFormation = "FormationTestMissionControllerHotkeyOrderLineAndHorseArcherFormation";

	public const string FormationTestMissionControllerHotkeyOrderCircle = "FormationTestMissionControllerHotkeyOrderCircle";

	public const string FormationTestMissionControllerHotkeyOrderColumn = "FormationTestMissionControllerHotkeyOrderColumn";

	public const string FormationTestMissionControllerHotkeyOrderShieldWall = "FormationTestMissionControllerHotkeyOrderShieldWall";

	public const string FormationTestMissionControllerHotkeyOrderSquare = "FormationTestMissionControllerHotkeyOrderSquare";

	public const string AiTestMissionControllerHotkeySpawnFormation = "AiTestMissionControllerHotkeySpawnFormation";

	public const string TabbedPanelHotkeyDecreaseSelectedIndex = "TabbedPanelHotkeyDecreaseSelectedIndex";

	public const string TabbedPanelHotkeyIncreaseSelectedIndex = "TabbedPanelHotkeyIncreaseSelectedIndex";

	public const string MissionSingleplayerUiHandlerHotkeyUpdateItems = "MissionSingleplayerUiHandlerHotkeyUpdateItems";

	public const string MissionSingleplayerUiHandlerHotkeyJoinEnemyTeam = "MissionSingleplayerUiHandlerHotkeyJoinEnemyTeam";

	public const string SiegeDeploymentViewHotkeyTeleportMainAgent = "SiegeDeploymentViewHotkeyTeleportMainAgent";

	public const string SiegeDeploymentViewHotkeyFinishDeployment = "SiegeDeploymentViewHotkeyFinishDeployment";

	public const string CraftingScreenHotkeyEnableRuler = "CraftingScreenHotkeyEnableRuler";

	public const string CraftingScreenHotkeyEnableRulerPoint1 = "CraftingScreenHotkeyEnableRulerPoint1";

	public const string CraftingScreenHotkeyEnableRulerPoint2 = "CraftingScreenHotkeyEnableRulerPoint2";

	public const string CraftingScreenHotkeySwitchSelectedPieceMovement = "CraftingScreenHotkeySwitchSelectedPieceMovement";

	public const string CraftingScreenHotkeySetSelectedVariableIndexZero = "CraftingScreenHotkeySetSelectedVariableIndexZero";

	public const string CraftingScreenHotkeySetSelectedVariableIndexOne = "CraftingScreenHotkeySetSelectedVariableIndexOne";

	public const string CraftingScreenHotkeySetSelectedVariableIndexTwo = "CraftingScreenHotkeySetSelectedVariableIndexTwo";

	public const string CraftingScreenHotkeySelectPieceZero = "CraftingScreenHotkeySelectPieceZero";

	public const string CraftingScreenHotkeySelectPieceOne = "CraftingScreenHotkeySelectPieceOne";

	public const string CraftingScreenHotkeySelectPieceTwo = "CraftingScreenHotkeySelectPieceTwo";

	public const string CraftingScreenHotkeySelectPieceThree = "CraftingScreenHotkeySelectPieceThree";

	public const string MbFaceGeneratorScreenHotkeyCamDebugAndAdjustEnabled = "MbFaceGeneratorScreenHotkeyCamDebugAndAdjustEnabled";

	public const string MbFaceGeneratorScreenHotkeyNumpad0 = "MbFaceGeneratorScreenHotkeyNumpad0";

	public const string MbFaceGeneratorScreenHotkeyNumpad1 = "MbFaceGeneratorScreenHotkeyNumpad1";

	public const string MbFaceGeneratorScreenHotkeyNumpad2 = "MbFaceGeneratorScreenHotkeyNumpad2";

	public const string MbFaceGeneratorScreenHotkeyNumpad3 = "MbFaceGeneratorScreenHotkeyNumpad3";

	public const string MbFaceGeneratorScreenHotkeyNumpad4 = "MbFaceGeneratorScreenHotkeyNumpad4";

	public const string MbFaceGeneratorScreenHotkeyNumpad5 = "MbFaceGeneratorScreenHotkeyNumpad5";

	public const string MbFaceGeneratorScreenHotkeyNumpad6 = "MbFaceGeneratorScreenHotkeyNumpad6";

	public const string MbFaceGeneratorScreenHotkeyNumpad7 = "MbFaceGeneratorScreenHotkeyNumpad7";

	public const string MbFaceGeneratorScreenHotkeyNumpad8 = "MbFaceGeneratorScreenHotkeyNumpad8";

	public const string MbFaceGeneratorScreenHotkeyNumpad9 = "MbFaceGeneratorScreenHotkeyNumpad9";

	public const string MbFaceGeneratorScreenHotkeyResetFaceToDefault = "MbFaceGeneratorScreenHotkeyResetFaceToDefault";

	public const string MbFaceGeneratorScreenHotkeySetFaceKeyMax = "MbFaceGeneratorScreenHotkeySetFaceKeyMax";

	public const string MbFaceGeneratorScreenHotkeySetFaceKeyMin = "MbFaceGeneratorScreenHotkeySetFaceKeyMin";

	public const string MbFaceGeneratorScreenHotkeySetCurFaceKeyToMax = "MbFaceGeneratorScreenHotkeySetCurFaceKeyToMax";

	public const string MbFaceGeneratorScreenHotkeySetCurFaceKeyToMin = "MbFaceGeneratorScreenHotkeySetCurFaceKeyToMin";

	public const string SoftwareOcclusionCheckerHotkeySaveOcclusionImage = "SoftwareOcclusionCheckerHotkeySaveOcclusionImage";

	public const string MapScreenHotkeySwitchCampaignTrueSight = "MapScreenHotkeySwitchCampaignTrueSight";

	public const string MapScreenPrintMultiLineText = "MapScreenPrintMultiLineText";

	public const string MapScreenHotkeyShowPos = "MapScreenHotkeyShowPos";

	public const string MapScreenHotkeyOpenEncyclopedia = "MapScreenHotkeyOpenEncyclopedia";

	public const string ReplayCaptureLogicHotkeyRenderWithScreenshot = "ReplayCaptureLogicHotkeyRenderWithScreenshot";

	public const string MissionScreenHotkeyFixCamera = "MissionScreenHotkeyFixCamera";

	public const string MissionScreenHotkeyIncrementArtificialLag = "MissionScreenHotkeyIncrementArtificialLag";

	public const string MissionScreenHotkeyIncrementArtificialLoss = "MissionScreenHotkeyIncrementArtificialLoss";

	public const string MissionScreenHotkeyResetDebugVariables = "MissionScreenHotkeyResetDebugVariables";

	public const string MissionScreenHotkeySwitchCameraSmooth = "MissionScreenHotkeySwitchCameraSmooth";

	public const string MissionScreenHotkeyIncreaseFirstFormationWidth = "MissionScreenHotkeyIncreaseFirstFormationWidth";

	public const string MissionScreenHotkeyDecreaseFirstFormationWidth = "MissionScreenHotkeyDecreaseFirstFormationWidth";

	public const string MissionScreenHotkeyExtendedDebugKey = "MissionScreenHotkeyExtendedDebugKey";

	public const string MissionScreenHotkeyShowDebug = "MissionScreenHotkeyShowDebug";

	public const string MissionScreenHotkeyIncreaseTotalUploadLimit = "MissionScreenHotkeyIncreaseTotalUploadLimit";

	public const string MissionScreenIncreaseTotalUploadLimit = "MissionScreenIncreaseTotalUploadLimit";

	public const string MissionScreenHotkeyDecreaseRulerDistanceFromPivot = "MissionScreenHotkeyDecreaseRulerDistanceFromPivot";

	public const string MissionScreenHotkeyIncreaseRulerDistanceFromPivot = "MissionScreenHotkeyIncreaseRulerDistanceFromPivot";

	public const string DebugAgentTeleportMissionControllerHotkeyTeleportMainAgent = "DebugAgentTeleportMissionControllerHotkeyTeleportMainAgent";

	public const string DebugAgentTeleportMissionControllerHotkeyDisableScriptedMovement = "DebugAgentTeleportMissionControllerHotkeyDisableScriptedMovement";

	public const string MissionDebugHandlerHotkeyKillAI = "MissionDebugHandlerHotkeyKillAI";

	public const string MissionDebugHandlerHotkeyKillAttacker = "MissionDebugHandlerHotkeyKillAttacker";

	public const string MissionDebugHandlerHotkeyKillDefender = "MissionDebugHandlerHotkeyKillDefender";

	public const string MissionDebugHandlerHotkeyKillMainAgent = "MissionDebugHandlerHotkeyKillMainAgent";

	public const string MissionDebugHandlerHotkeyAttackingAiAgent = "MissionDebugHandlerHotkeyAttackingAiAgent";

	public const string MissionDebugHandlerHotkeyDefendingAiAgent = "MissionDebugHandlerHotkeyDefendingAiAgent";

	public const string MissionDebugHandlerHotkeyNormalAiAgent = "MissionDebugHandlerHotkeyNormalAiAgent";

	public const string MissionDebugHandlerHotkeyAiAgentSideZero = "MissionDebugHandlerHotkeyAiAgentSideZero";

	public const string MissionDebugHandlerHotkeyAiAgentSideOne = "MissionDebugHandlerHotkeyAiAgentSideOne";

	public const string MissionDebugHandlerHotkeyAiAgentSideTwo = "MissionDebugHandlerHotkeyAiAgentSideTwo";

	public const string MissionDebugHandlerHotkeyAiAgentSideThree = "MissionDebugHandlerHotkeyAiAgentSideThree";

	public const string MissionDebugHandlerHotkeyColorEnemyTeam = "MissionDebugHandlerHotkeyColorEnemyTeam";

	public const string MissionDebugHandlerHotkeyOpenMissionDebug = "MissionDebugHandlerHotkeyOpenMissionDebug";

	public const string UsableMachineAiBaseHotkeyShowMachineUsers = "UsableMachineAiBaseHotkeyShowMachineUsers";

	public const string UsableMachineAiBaseHotkeyRetreatScriptActive = "UsableMachineAiBaseHotkeyRetreatScriptActive";

	public const string UsableMachineAiBaseHotkeyRetreatScriptPassive = "UsableMachineAiBaseHotkeyRetreatScriptPassive";

	public const string CustomCameraMissionViewHotkeyIncreaseCustomCameraIndex = "CustomCameraMissionViewHotkeyIncreaseCustomCameraIndex";

	public const string DebugSiegeBehaviorHotkeyAimAtBallistas = "DebugSiegeBehaviorHotkeyAimAtBallistas";

	public const string DebugSiegeBehaviorHotkeyAimAtMangonels = "DebugSiegeBehaviorHotkeyAimAtMangonels";

	public const string DebugSiegeBehaviorHotkeyAimAtBattlements = "DebugSiegeBehaviorHotkeyAimAtBattlements";

	public const string DebugSiegeBehaviorHotkeyAimAtNone = "DebugSiegeBehaviorHotkeyAimAtNone";

	public const string DebugSiegeBehaviorHotkeyAimAtNone2 = "DebugSiegeBehaviorHotkeyAimAtNone2";

	public const string DebugSiegeBehaviorHotkeyTargetDebugActive = "DebugSiegeBehaviorHotkeyTargetDebugActive";

	public const string DebugSiegeBehaviorHotkeyTargetDebugDisactive = "DebugSiegeBehaviorHotkeyTargetDebugDisactive";

	public const string DebugSiegeBehaviorHotkeyAimAtRam = "DebugSiegeBehaviorHotkeyAimAtRam";

	public const string DebugSiegeBehaviorHotkeyAimAtSt = "DebugSiegeBehaviorHotkeyAimAtSt";

	public const string DebugSiegeBehaviorHotkeyAimAtBallistas2 = "DebugSiegeBehaviorHotkeyAimAtBallistas2";

	public const string DebugSiegeBehaviorHotkeyAimAtMangonels2 = "DebugSiegeBehaviorHotkeyAimAtMangonels2";

	public const string DebugNetworkEventStatisticsHotkeyClear = "DebugNetworkEventStatisticsHotkeyClear";

	public const string DebugNetworkEventStatisticsHotkeyDumpDataAndClear = "DebugNetworkEventStatisticsHotkeyDumpDataAndClear";

	public const string DebugNetworkEventStatisticsHotkeyDumpData = "DebugNetworkEventStatisticsHotkeyDumpData";

	public const string DebugNetworkEventStatisticsHotkeyClearReplicationData = "DebugNetworkEventStatisticsHotkeyClearReplicationData";

	public const string DebugNetworkEventStatisticsHotkeyDumpReplicationData = "DebugNetworkEventStatisticsHotkeyDumpReplicationData";

	public const string DebugNetworkEventStatisticsHotkeyDumpAndClearReplicationData = "DebugNetworkEventStatisticsHotkeyDumpAndClearReplicationData";

	public const string DebugNetworkEventStatisticsHotkeyToggleActive = "DebugNetworkEventStatisticsHotkeyToggleActive";

	public const string AiSelectDebugAgent1 = "AiSelectDebugAgent1";

	public const string AiSelectDebugAgent2 = "AiSelectDebugAgent2";

	public const string AiClearDebugAgents = "AiClearDebugAgents";

	public const string DebugCustomBattlePredefinedSettings1 = "DebugCustomBattlePredefinedSettings1";

	public const string CraftingScreenResetVariable = "CraftingScreenResetVariable";

	public const string DisableParallelSettlementPositionUpdate = "DisableParallelSettlementPositionUpdate";

	public const string OpenUIEditor = "OpenUIEditor";

	public const string ToggleUI = "ToggleUI";

	public const string LeaveWhileInConversation = "LeaveWhileInConversation";

	public const string ShowHighlightsSummary = "ShowHighlightsSummary";

	public const string ResetMusicParameters = "ResetMusicParameters";

	public const string UIExtendedDebugKey = "UIExtendedDebugKey";

	public const string FaceGeneratorExtendedDebugKey = "FaceGeneratorExtendedDebugKey";

	public const string FormationTestMissionExtendedDebugKey = "FormationTestMissionExtendedDebugKey";

	public const string FormationTestMissionExtendedDebugKey2 = "FormationTestMissionExtendedDebugKey2";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DebugHotKeyCategory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterDebugHotkey(string id, InputKey hotkeyKey, HotKey.Modifiers modifiers, HotKey.Modifiers negativeModifiers = HotKey.Modifiers.None)
	{
		throw null;
	}
}
