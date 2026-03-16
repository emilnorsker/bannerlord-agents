using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace TaleWorlds.CampaignSystem.Map;

public class WeatherNode
{
	public CampaignVec2 Position;

	public MapWeatherModel.WeatherEvent CurrentWeatherEvent;

	public bool IsVisuallyDirty
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
	public WeatherNode(CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVisualDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnVisualUpdated()
	{
		throw null;
	}
}
