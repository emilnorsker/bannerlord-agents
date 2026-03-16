using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultAgeModel : AgeModel
{
	public const string TavernVisitorTag = "TavernVisitor";

	public const string TavernDrinkerTag = "TavernDrinker";

	public const string SlowTownsmanTag = "SlowTownsman";

	public const string TownsfolkCarryingStuffTag = "TownsfolkCarryingStuff";

	public const string BroomsWomanTag = "BroomsWoman";

	public const string DancerTag = "Dancer";

	public const string BeggarTag = "Beggar";

	public const string ChildTag = "Child";

	public const string TeenagerTag = "Teenager";

	public const string InfantTag = "Infant";

	public const string NotaryTag = "Notary";

	public const string BarberTag = "Barber";

	public const string AlleyGangMemberTag = "AlleyGangMember";

	public override int BecomeInfantAge
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int BecomeChildAge
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int BecomeTeenagerAge
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int HeroComesOfAge
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MiddleAdultHoodAge
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int BecomeOldAge
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MaxAge
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetAgeLimitForLocation(CharacterObject character, out int minimumAge, out int maximumAge, string additionalTags = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultAgeModel()
	{
		throw null;
	}
}
