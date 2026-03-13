using System.Collections.Generic;
using System.Xml;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.RolePlay;

public class RPItemComponent : ItemComponent
{
	public TextObject Description { get; set; }

	public string CreatedBy { get; set; }

	public int CreatedDay { get; set; }

	public RPItemComponent()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		Description = new TextObject("", (Dictionary<string, object>)null);
		CreatedBy = null;
		CreatedDay = 0;
	}

	public RPItemComponent(RPItemComponent other)
	{
		Description = other.Description;
		CreatedBy = other.CreatedBy;
		CreatedDay = other.CreatedDay;
	}

	public override ItemComponent GetCopy()
	{
		return (ItemComponent)(object)new RPItemComponent(this);
	}

	public override void Deserialize(MBObjectManager objectManager, XmlNode node)
	{
		((MBObjectBase)this).Initialize();
	}
}
