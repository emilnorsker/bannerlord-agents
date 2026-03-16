using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign;

public class WeaponAttributeVM : ViewModel
{
	private string _attributeFieldText;

	public DamageTypes DamageType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public CraftingTemplate.CraftingStatTypes AttributeType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public float AttributeValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string AttributeFieldText
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
	public WeaponAttributeVM(CraftingTemplate.CraftingStatTypes type, DamageTypes damageType, string attributeName, float attributeValue)
	{
		throw null;
	}
}
