using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;

namespace SandBox.View.Map.Managers;

internal class MapAudioManager : CampaignEntityVisualComponent
{
	private const string SeasonParameterId = "Season";

	private const string CameraHeightParameterId = "CampaignCameraHeight";

	private const string TimeOfDayParameterId = "Daytime";

	private const string WeatherEventIntensityParameterId = "Rainfall";

	private Seasons _lastCachedSeason;

	private float _lastCameraZ;

	private int _lastHourUpdate;

	private MapScene _mapScene;

	public override int Priority
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapAudioManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnVisualTick(MapScreen screen, float realDt, float dt)
	{
		throw null;
	}
}
