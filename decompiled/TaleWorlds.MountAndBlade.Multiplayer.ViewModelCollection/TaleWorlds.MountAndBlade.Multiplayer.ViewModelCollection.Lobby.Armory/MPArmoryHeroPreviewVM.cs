using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Armory;

public class MPArmoryHeroPreviewVM : ViewModel
{
	private BasicCharacterObject _character;

	private Equipment _orgEquipmentWithoutPerks;

	private CharacterViewModel _heroVisual;

	private string _className;

	[DataSourceProperty]
	public CharacterViewModel HeroVisual
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

	[DataSourceProperty]
	public string ClassName
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
	public MPArmoryHeroPreviewVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCharacter(BasicCharacterObject character, DynamicBodyProperties dynamicBodyProperties, int race, bool isFemale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCharacterClass(BasicCharacterObject classCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCharacterPerks(List<IReadOnlyPerkObject> selectedPerks)
	{
		throw null;
	}
}
