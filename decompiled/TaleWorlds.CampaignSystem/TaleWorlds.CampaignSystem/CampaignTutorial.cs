using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem;

public class CampaignTutorial
{
	public readonly string TutorialTypeId;

	public readonly int Priority;

	public TextObject Description
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TextObject Title
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignTutorial(string tutorialType, int priority)
	{
		throw null;
	}
}
