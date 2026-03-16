using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace SandBox.ViewModelCollection.Missions.NameMarker.Targets;

public class MissionGenericMarkerTargetVM : MissionNameMarkerTargetBaseVM
{
	public readonly string Identifier;

	private readonly Vec3 _position;

	private readonly TextObject _name;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGenericMarkerTargetVM(string identifier, string nameType, string iconType, Vec3 position, TextObject name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(MissionNameMarkerTargetBaseVM other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void UpdatePosition(Camera missionCamera)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override TextObject GetName()
	{
		throw null;
	}
}
