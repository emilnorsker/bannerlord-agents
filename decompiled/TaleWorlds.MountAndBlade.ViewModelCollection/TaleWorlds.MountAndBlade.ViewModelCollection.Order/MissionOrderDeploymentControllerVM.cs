using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Missions.Handlers;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Order;

public class MissionOrderDeploymentControllerVM : ViewModel
{
	public const uint _entityHiglightColor = 4289622555u;

	public const uint _entitySelectedColor = 4293481743u;

	private GameEntity _currentSelectedEntity;

	private GameEntity _currentHoveredEntity;

	private InquiryData _siegeDeployQueryData;

	private DeploymentHandler _deploymentHandler;

	private SiegeDeploymentHandler _siegeDeploymentHandler;

	internal DeploymentSiegeMachineVM _selectedDeploymentPointVM;

	private readonly MissionOrderVM _missionOrder;

	private Camera _deploymentCamera;

	private List<DeploymentPoint> _deploymentPoints;

	private MissionOrderCallbacks _callbacks;

	private MBBindingList<OrderSiegeMachineVM> _siegeMachineList;

	private MBBindingList<DeploymentSiegeMachineVM> _siegeDeploymentList;

	private MBBindingList<DeploymentSiegeMachineVM> _deploymentTargets;

	private bool _isSiegeDeploymentListActive;

	private Mission Mission
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private Team Team
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public OrderController OrderController
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<OrderSiegeMachineVM> SiegeMachineList
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
	public MBBindingList<DeploymentSiegeMachineVM> DeploymentTargets
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
	public bool IsSiegeDeploymentListActive
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
	public MBBindingList<DeploymentSiegeMachineVM> SiegeDeploymentList
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
	public void SetMissionParameters(Camera deploymentCamera, List<DeploymentPoint> deploymentPoints)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCallbacks(MissionOrderCallbacks callbacks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionOrderDeploymentControllerVM(MissionOrderVM missionOrder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void DeployFormationsOfPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetSiegeMachineActiveOrders(OrderSiegeMachineVM siegeItemVM)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ProcessSiegeMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SelectAllSiegeMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddSelectedSiegeMachine(OrderSiegeMachineVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetSelectedSiegeMachine(OrderSiegeMachineVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnDeselectSiegeMachine(OrderSiegeMachineVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnSelectOrderSiegeMachine(OrderSiegeMachineVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnSelectDeploymentSiegeMachine(DeploymentSiegeMachineVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnSelectedSiegeWeaponsChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnRefreshSelectedDeploymentPoint(DeploymentSiegeMachineVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEntityHover(WeakGameEntity hoveredEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEntityHover(DeploymentPoint deploymentPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEntitySelect(WeakGameEntity selectedEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshSelectedDeploymentPoint(DeploymentPoint selectedDeploymentPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteCancelSelectedDeploymentPoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteBeginMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteAutoDeploy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AutoDeploySiegeMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteDeployPlayerSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteDeployEnemySide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizeDeployment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnSelectFormationWithIndex(int formationTroopIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetCurrentActiveOrders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}
}
