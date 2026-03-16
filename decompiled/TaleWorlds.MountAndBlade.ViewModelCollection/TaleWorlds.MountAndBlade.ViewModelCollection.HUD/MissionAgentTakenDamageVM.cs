using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.HUD;

public class MissionAgentTakenDamageVM : ViewModel
{
	private Camera _missionCamera;

	private bool _isEnabled;

	private MBBindingList<MissionAgentTakenDamageItemVM> _takenDamageList;

	[DataSourceProperty]
	public MBBindingList<MissionAgentTakenDamageItemVM> TakenDamageList
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
	public MissionAgentTakenDamageVM(Camera missionCamera)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsEnabled(bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnMainAgentHit(int damage, float distance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRemoveDamageItem(MissionAgentTakenDamageItemVM item)
	{
		throw null;
	}
}
