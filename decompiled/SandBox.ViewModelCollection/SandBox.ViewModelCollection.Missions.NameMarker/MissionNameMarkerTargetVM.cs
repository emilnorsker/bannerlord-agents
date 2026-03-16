using System.Runtime.CompilerServices;

namespace SandBox.ViewModelCollection.Missions.NameMarker;

public abstract class MissionNameMarkerTargetVM<T> : MissionNameMarkerTargetBaseVM
{
	public T Target
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
	protected MissionNameMarkerTargetVM(T target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(MissionNameMarkerTargetBaseVM other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreQuestsEqual(MissionNameMarkerTargetVM<T> tOther)
	{
		throw null;
	}
}
