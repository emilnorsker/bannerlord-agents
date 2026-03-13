using System.Collections.Generic;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

namespace AIInfluence.SettlementCombat;

public class SimpleVisualOrderSet : VisualOrderSet
{
	private readonly string _stringId;

	private readonly string _iconId;

	public override bool IsSoloOrder => false;

	public override string StringId => _stringId;

	public override string IconId => _iconId;

	public SimpleVisualOrderSet(string stringId, string iconId)
	{
		_stringId = stringId;
		_iconId = iconId;
	}

	public override TextObject GetName(OrderController orderController)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		return new TextObject("{=!}" + _stringId, (Dictionary<string, object>)null);
	}
}
