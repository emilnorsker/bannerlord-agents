using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace SandBox.ViewModelCollection.Missions.MainAgentDetection;

public class MissionDisguiseMarkersVM : ViewModel
{
	private MissionDisguiseMarkerItemVM _targetAgent;

	private MBBindingList<MissionDisguiseMarkerItemVM> _hostileAgents;

	[DataSourceProperty]
	public MissionDisguiseMarkerItemVM TargetAgent
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
	public MBBindingList<MissionDisguiseMarkerItemVM> HostileAgents
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
	public MissionDisguiseMarkersVM()
	{
		throw null;
	}
}
