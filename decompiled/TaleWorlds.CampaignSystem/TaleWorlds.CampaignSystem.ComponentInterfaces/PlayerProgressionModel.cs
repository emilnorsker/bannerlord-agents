using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class PlayerProgressionModel : MBGameModel<PlayerProgressionModel>
{
	public abstract float GetPlayerProgress();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected PlayerProgressionModel()
	{
		throw null;
	}
}
