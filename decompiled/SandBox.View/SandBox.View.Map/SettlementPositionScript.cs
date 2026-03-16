using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Map.DistanceCache;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.View.Map;

public class SettlementPositionScript : ScriptComponentBehavior
{
	private sealed class SettlementRecord : ISettlementDataHolder
	{
		public readonly string SettlementId;

		public readonly XmlNode Node;

		public readonly Vec2 Position;

		public readonly Vec2 GatePosition;

		public readonly bool HasGate;

		public readonly Vec2 PortPosition;

		public readonly bool HasPort;

		public readonly bool IsFortification;

		public string StringId
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		CampaignVec2 ISettlementDataHolder.GatePosition
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		CampaignVec2 ISettlementDataHolder.PortPosition
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		bool ISettlementDataHolder.IsFortification
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		bool ISettlementDataHolder.HasPort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SettlementRecord(string settlementId, Vec2 position, Vec2 gatePosition, XmlNode node, bool hasGate, Vec2 portPosition, bool hasPort, bool isFortification)
		{
			throw null;
		}
	}

	private sealed class SettlementPositionScriptNavigationCache : NavigationCache<SettlementRecord>
	{
		private readonly Scene Scene;

		private readonly List<SettlementRecord> _settlementRecords;

		private readonly int[] _excludedFaceIds;

		private readonly int _regionSwitchCostTo0;

		private readonly int _regionSwitchCostTo1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SettlementPositionScriptNavigationCache(List<SettlementRecord> settlementRecords, Scene scene, MapDistanceModel mapDistanceModel, PartyNavigationModel partyNavigationModel, NavigationType navigationType)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override NavigationCacheElement<SettlementRecord> GetCacheElement(SettlementRecord settlement, bool isPortUsed)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override SettlementRecord GetCacheElement(string settlementId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void GetSceneXmlCrcValues(out uint sceneXmlCrc, out uint sceneNavigationMeshCrc)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override int GetNavMeshFaceCount()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override Vec2 GetNavMeshFaceCenterPosition(int faceIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override PathFaceRecord GetFaceRecordAtIndex(int faceIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override int[] GetExcludedFaceIds()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override int GetRegionSwitchCostTo0()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override int GetRegionSwitchCostTo1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override IEnumerable<SettlementRecord> GetClosestSettlementsToPositionInCache(Vec2 checkPosition, List<SettlementRecord> settlements)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override float GetRealPathDistanceFromPositionToSettlement(Vec2 checkPosition, PathFaceRecord currentFaceRecord, float maxDistanceToLookForPathDetection, SettlementRecord currentSettlementToLook, out bool isPort)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override float GetRealDistanceAndLandRatioBetweenSettlements(NavigationCacheElement<SettlementRecord> settlement1, NavigationCacheElement<SettlementRecord> settlement2, out float landRatio)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void GetFaceRecordForPoint(Vec2 position, out bool isOnRegion1)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override bool CheckBeingNeighbor(List<SettlementRecord> settlementsToConsider, SettlementRecord settlement1, SettlementRecord settlement2, bool useGate1, bool useGate2, out float distance)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override List<SettlementRecord> GetAllRegisteredSettlements()
		{
			throw null;
		}
	}

	private const string SandBoxModuleId = "Sandbox";

	private const string NavalDLCModuleId = "NavalDLC";

	private const string NavalPartyNavigationModelName = "NavalPartyNavigationModel";

	private const string NavalMapDistanceModelName = "NavalDLCMapDistanceModel";

	private bool _mapIsSandBox;

	private bool _mapIsNavalDLC;

	[EditableScriptComponentVariable(true, "")]
	private string _partyNavigationModelOverriddenClassName;

	[EditableScriptComponentVariable(true, "")]
	private string _distanceModelOverridenClassName;

	private PartyNavigationModel _partyNavigationModel;

	private MapDistanceModel _mapDistanceModel;

	public SimpleButton CheckPositions;

	public SimpleButton SavePositions;

	public SimpleButton ComputeAndSaveSettlementDistanceCache;

	private string SettlementsXmlPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterNavigationCachesOnGameLoad(bool useNavalNavigation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SandBoxNavigationCache ReadNavigationCacheForNavigationTypeOnGameLoad(NavigationType navigationCapability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SandBoxNavigationCache ReadNavigationCacheOnGameLoad(string path, NavigationType navigationCapability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSceneSave(string saveFolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckSettlementPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCachedVariables()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsOnlyVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetMapIsNavalDLC()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetMapIsSandBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetMapModuleId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PartyNavigationModel GetPartyNavigationModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MapDistanceModel GetMapDistanceModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static PartyNavigationModel CreateCustomNavigationModel(string name, bool naval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static MapDistanceModel CreateCustomMapDistanceModel(string name, bool naval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Type FindClass(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static PartyNavigationModel CreateBaseNavigationModel(bool naval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static MapDistanceModel CreateBaseDistanceModel(bool naval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static MapDistanceModel CreateBaseDistanceModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetSettlementsDistanceCacheFileForCapability(string moduleId, NavigationType navigationType, out string filePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<SettlementRecord> LoadSettlementData(XmlDocument settlementDocument)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private XmlDocument LoadXmlFile(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SaveSettlementPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SaveSettlementDistanceCacheEditor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SettlementPositionScript()
	{
		throw null;
	}
}
