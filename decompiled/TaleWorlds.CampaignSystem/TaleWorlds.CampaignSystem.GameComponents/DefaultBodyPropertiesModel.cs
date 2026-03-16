using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultBodyPropertiesModel : BodyPropertiesModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int[] GetHairIndicesForCulture(int race, int gender, float age, CultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int[] GetBeardIndicesForCulture(int race, int gender, float age, CultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int[] GetTattooIndicesForCulture(int race, int gender, float age, CultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultBodyPropertiesModel()
	{
		throw null;
	}
}
