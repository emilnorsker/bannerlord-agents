using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultInformationRestrictionModel : InformationRestrictionModel
{
	public bool IsDisabledByCheat;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool DoesPlayerKnowDetailsOf(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool DoesPlayerKnowDetailsOf(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultInformationRestrictionModel()
	{
		throw null;
	}
}
