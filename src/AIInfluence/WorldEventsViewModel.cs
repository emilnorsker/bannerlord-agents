using System.Collections.Generic;
using Bannerlord.UIExtenderEx.Attributes;
using SandBox.View.Map;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ScreenSystem;

namespace AIInfluence;

public class WorldEventsViewModel : ViewModel
{
	[DataSourceProperty]
	public string WorldEventsButtonText { get; set; }

	public WorldEventsViewModel()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		WorldEventsButtonText = ((object)new TextObject("{=AIInfluence_WorldEventsButton}World Events", (Dictionary<string, object>)null)).ToString();
	}

	[DataSourceMethod]
	public void ExecuteOpenWorldEvents()
	{
		WorldEventsWindowLayer worldEventsWindowLayer = new WorldEventsWindowLayer();
		ScreenBase topScreen = ScreenManager.TopScreen;
		MapScreen val = (MapScreen)(object)((topScreen is MapScreen) ? topScreen : null);
		if (val != null)
		{
			((ScreenBase)val).AddLayer((ScreenLayer)(object)worldEventsWindowLayer);
		}
	}
}
