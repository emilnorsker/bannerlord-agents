using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection;

public class HeroViewModel : CharacterViewModel
{
	private Hero _hero;

	private bool _isDead;

	[DataSourceProperty]
	public bool IsDead
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HeroViewModel(StanceTypes stance = StanceTypes.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetEquipment(Equipment equipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillFrom(Hero hero, int seed = -1, bool useCivilian = false, bool useCharacteristicIdleAction = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}
}
