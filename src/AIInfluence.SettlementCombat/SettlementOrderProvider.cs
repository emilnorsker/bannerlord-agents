using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

namespace AIInfluence.SettlementCombat;

public class SettlementOrderProvider : VisualOrderProvider
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static OrderActionDelegate _003C_003E9__3_0;

		public static OrderActionDelegate _003C_003E9__3_1;

		public static OrderActionDelegate _003C_003E9__3_2;

		public static OrderActionDelegate _003C_003E9__3_3;

		public static OrderActionDelegate _003C_003E9__3_4;

		public static OrderActionDelegate _003C_003E9__3_5;

		public static OrderActionDelegate _003C_003E9__4_0;

		public static OrderActionDelegate _003C_003E9__5_0;

		public static OrderActionDelegate _003C_003E9__5_1;

		public static OrderActionDelegate _003C_003E9__5_2;

		public static OrderActionDelegate _003C_003E9__5_3;

		public static OrderActionDelegate _003C_003E9__5_4;

		public static OrderActionDelegate _003C_003E9__5_5;

		public static OrderActionDelegate _003C_003E9__5_6;

		public static OrderActionDelegate _003C_003E9__5_7;

		public static OrderActionDelegate _003C_003E9__6_0;

		public static OrderActionDelegate _003C_003E9__6_1;

		public static OrderActionDelegate _003C_003E9__7_0;

		public static OrderActionDelegate _003C_003E9__7_1;

		public static OrderActionDelegate _003C_003E9__8_0;

		public static OrderActionDelegate _003C_003E9__8_1;

		public static OrderActionDelegate _003C_003E9__8_2;

		internal void _003CCreateMovementOrderSet_003Eb__3_0(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)4);
		}

		internal void _003CCreateMovementOrderSet_003Eb__3_1(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)12);
		}

		internal void _003CCreateMovementOrderSet_003Eb__3_2(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)13);
		}

		internal void _003CCreateMovementOrderSet_003Eb__3_3(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)6);
		}

		internal void _003CCreateMovementOrderSet_003Eb__3_4(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrderWithAgent((OrderType)7, oc.Owner);
		}

		internal void _003CCreateMovementOrderSet_003Eb__3_5(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)9);
		}

		internal void _003CCreateFacingOrderSet_003Eb__4_0(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)14);
		}

		internal void _003CCreateFormOrderSet_003Eb__5_0(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)16);
		}

		internal void _003CCreateFormOrderSet_003Eb__5_1(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)17);
		}

		internal void _003CCreateFormOrderSet_003Eb__5_2(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)18);
		}

		internal void _003CCreateFormOrderSet_003Eb__5_3(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)19);
		}

		internal void _003CCreateFormOrderSet_003Eb__5_4(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)20);
		}

		internal void _003CCreateFormOrderSet_003Eb__5_5(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)21);
		}

		internal void _003CCreateFormOrderSet_003Eb__5_6(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)22);
		}

		internal void _003CCreateFormOrderSet_003Eb__5_7(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)23);
		}

		internal void _003CCreateFiringOrderSet_003Eb__6_0(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)32);
		}

		internal void _003CCreateFiringOrderSet_003Eb__6_1(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)31);
		}

		internal void _003CCreateRidingOrderSet_003Eb__7_0(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)34);
		}

		internal void _003CCreateRidingOrderSet_003Eb__7_1(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)35);
		}

		internal void _003CCreateWidthOrderSet_003Eb__8_0(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)25);
		}

		internal void _003CCreateWidthOrderSet_003Eb__8_1(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)26);
		}

		internal void _003CCreateWidthOrderSet_003Eb__8_2(OrderController oc, VisualOrderExecutionParameters p)
		{
			oc.SetOrder((OrderType)27);
		}
	}

	private static readonly SettlementCombatLogger _logger = SettlementCombatLogger.Instance;

	public override bool IsAvailable()
	{
		try
		{
			if (PlayerEncounter.EncounteredBattle != null)
			{
				return false;
			}
			if (Settlement.CurrentSettlement == null)
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	public override MBReadOnlyList<VisualOrderSet> GetOrders()
	{
		try
		{
			MBList<VisualOrderSet> val = new MBList<VisualOrderSet>();
			((List<VisualOrderSet>)(object)val).Add(CreateMovementOrderSet());
			((List<VisualOrderSet>)(object)val).Add(CreateFacingOrderSet());
			((List<VisualOrderSet>)(object)val).Add(CreateFormOrderSet());
			((List<VisualOrderSet>)(object)val).Add(CreateFiringOrderSet());
			((List<VisualOrderSet>)(object)val).Add(CreateRidingOrderSet());
			((List<VisualOrderSet>)(object)val).Add(CreateWidthOrderSet());
			_logger.Log($"[SETTLEMENT_ORDER_PROVIDER] Created {((List<VisualOrderSet>)(object)val).Count} order sets");
			return (MBReadOnlyList<VisualOrderSet>)(object)val;
		}
		catch (Exception ex)
		{
			_logger.LogError("SettlementOrderProvider.GetOrders", ex.Message, ex);
			return (MBReadOnlyList<VisualOrderSet>)(object)new MBList<VisualOrderSet>();
		}
	}

	private VisualOrderSet CreateMovementOrderSet()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		SimpleVisualOrderSet simpleVisualOrderSet = new SimpleVisualOrderSet("Movement", "order_type_movement");
		object obj = _003C_003Ec._003C_003E9__3_0;
		if (obj == null)
		{
			OrderActionDelegate val = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)4);
			};
			_003C_003Ec._003C_003E9__3_0 = val;
			obj = (object)val;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_movement_charge", (OrderActionDelegate)obj, new TextObject("{=3lKkeVlj}Charge", (Dictionary<string, object>)null)));
		object obj2 = _003C_003Ec._003C_003E9__3_1;
		if (obj2 == null)
		{
			OrderActionDelegate val2 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)12);
			};
			_003C_003Ec._003C_003E9__3_1 = val2;
			obj2 = (object)val2;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_movement_advance", (OrderActionDelegate)obj2, new TextObject("{=8c6fCI9Z}Advance", (Dictionary<string, object>)null)));
		object obj3 = _003C_003Ec._003C_003E9__3_2;
		if (obj3 == null)
		{
			OrderActionDelegate val3 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)13);
			};
			_003C_003Ec._003C_003E9__3_2 = val3;
			obj3 = (object)val3;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_movement_fallback", (OrderActionDelegate)obj3, new TextObject("{=DoNrosmL}Fall Back", (Dictionary<string, object>)null)));
		object obj4 = _003C_003Ec._003C_003E9__3_3;
		if (obj4 == null)
		{
			OrderActionDelegate val4 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)6);
			};
			_003C_003Ec._003C_003E9__3_3 = val4;
			obj4 = (object)val4;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_movement_stop", (OrderActionDelegate)obj4, new TextObject("{=NJpEb58T}Stand Your Ground", (Dictionary<string, object>)null)));
		object obj5 = _003C_003Ec._003C_003E9__3_4;
		if (obj5 == null)
		{
			OrderActionDelegate val5 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrderWithAgent((OrderType)7, oc.Owner);
			};
			_003C_003Ec._003C_003E9__3_4 = val5;
			obj5 = (object)val5;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_movement_follow", (OrderActionDelegate)obj5, new TextObject("{=GblAevP0}Follow Me", (Dictionary<string, object>)null)));
		object obj6 = _003C_003Ec._003C_003E9__3_5;
		if (obj6 == null)
		{
			OrderActionDelegate val6 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)9);
			};
			_003C_003Ec._003C_003E9__3_5 = val6;
			obj6 = (object)val6;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_movement_retreat", (OrderActionDelegate)obj6, new TextObject("{=7cJFhLRp}Retreat", (Dictionary<string, object>)null)));
		return (VisualOrderSet)(object)simpleVisualOrderSet;
	}

	private VisualOrderSet CreateFacingOrderSet()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		SimpleVisualOrderSet simpleVisualOrderSet = new SimpleVisualOrderSet("Facing", "order_type_facing");
		object obj = _003C_003Ec._003C_003E9__4_0;
		if (obj == null)
		{
			OrderActionDelegate val = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)14);
			};
			_003C_003Ec._003C_003E9__4_0 = val;
			obj = (object)val;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_toggle_facing", (OrderActionDelegate)obj, new TextObject("{=1THZeeJe}Look at Enemy", (Dictionary<string, object>)null)));
		return (VisualOrderSet)(object)simpleVisualOrderSet;
	}

	private VisualOrderSet CreateFormOrderSet()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		SimpleVisualOrderSet simpleVisualOrderSet = new SimpleVisualOrderSet("Form", "order_type_form");
		object obj = _003C_003Ec._003C_003E9__5_0;
		if (obj == null)
		{
			OrderActionDelegate val = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)16);
			};
			_003C_003Ec._003C_003E9__5_0 = val;
			obj = (object)val;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_form_line", (OrderActionDelegate)obj, new TextObject("{=cCKizVFi}Line", (Dictionary<string, object>)null)));
		object obj2 = _003C_003Ec._003C_003E9__5_1;
		if (obj2 == null)
		{
			OrderActionDelegate val2 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)17);
			};
			_003C_003Ec._003C_003E9__5_1 = val2;
			obj2 = (object)val2;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_form_close", (OrderActionDelegate)obj2, new TextObject("{=U1Yx8hPl}Shield Wall", (Dictionary<string, object>)null)));
		object obj3 = _003C_003Ec._003C_003E9__5_2;
		if (obj3 == null)
		{
			OrderActionDelegate val3 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)18);
			};
			_003C_003Ec._003C_003E9__5_2 = val3;
			obj3 = (object)val3;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_form_loose", (OrderActionDelegate)obj3, new TextObject("{=AMFP3h6Z}Loose", (Dictionary<string, object>)null)));
		object obj4 = _003C_003Ec._003C_003E9__5_3;
		if (obj4 == null)
		{
			OrderActionDelegate val4 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)19);
			};
			_003C_003Ec._003C_003E9__5_3 = val4;
			obj4 = (object)val4;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_form_circular", (OrderActionDelegate)obj4, new TextObject("{=fzj76rP0}Circle", (Dictionary<string, object>)null)));
		object obj5 = _003C_003Ec._003C_003E9__5_4;
		if (obj5 == null)
		{
			OrderActionDelegate val5 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)20);
			};
			_003C_003Ec._003C_003E9__5_4 = val5;
			obj5 = (object)val5;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_form_schiltron", (OrderActionDelegate)obj5, new TextObject("{=oKJadWNP}Square", (Dictionary<string, object>)null)));
		object obj6 = _003C_003Ec._003C_003E9__5_5;
		if (obj6 == null)
		{
			OrderActionDelegate val6 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)21);
			};
			_003C_003Ec._003C_003E9__5_5 = val6;
			obj6 = (object)val6;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_form_v", (OrderActionDelegate)obj6, new TextObject("{=o5fW1aWP}Skein", (Dictionary<string, object>)null)));
		object obj7 = _003C_003Ec._003C_003E9__5_6;
		if (obj7 == null)
		{
			OrderActionDelegate val7 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)22);
			};
			_003C_003Ec._003C_003E9__5_6 = val7;
			obj7 = (object)val7;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_form_column", (OrderActionDelegate)obj7, new TextObject("{=fEVOKYoW}Column", (Dictionary<string, object>)null)));
		object obj8 = _003C_003Ec._003C_003E9__5_7;
		if (obj8 == null)
		{
			OrderActionDelegate val8 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)23);
			};
			_003C_003Ec._003C_003E9__5_7 = val8;
			obj8 = (object)val8;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_form_scatter", (OrderActionDelegate)obj8, new TextObject("{=UZw6Ftr6}Scatter", (Dictionary<string, object>)null)));
		return (VisualOrderSet)(object)simpleVisualOrderSet;
	}

	private VisualOrderSet CreateFiringOrderSet()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		SimpleVisualOrderSet simpleVisualOrderSet = new SimpleVisualOrderSet("Firing", "order_type_toggle");
		object obj = _003C_003Ec._003C_003E9__6_0;
		if (obj == null)
		{
			OrderActionDelegate val = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)32);
			};
			_003C_003Ec._003C_003E9__6_0 = val;
			obj = (object)val;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_toggle_fire_active", (OrderActionDelegate)obj, new TextObject("{=ej8AnBWw}Fire at Will", (Dictionary<string, object>)null)));
		object obj2 = _003C_003Ec._003C_003E9__6_1;
		if (obj2 == null)
		{
			OrderActionDelegate val2 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)31);
			};
			_003C_003Ec._003C_003E9__6_1 = val2;
			obj2 = (object)val2;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_toggle_fire", (OrderActionDelegate)obj2, new TextObject("{=6xmh2iLF}Hold Your Fire", (Dictionary<string, object>)null)));
		return (VisualOrderSet)(object)simpleVisualOrderSet;
	}

	private VisualOrderSet CreateRidingOrderSet()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		SimpleVisualOrderSet simpleVisualOrderSet = new SimpleVisualOrderSet("Riding", "order_type_toggle");
		object obj = _003C_003Ec._003C_003E9__7_0;
		if (obj == null)
		{
			OrderActionDelegate val = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)34);
			};
			_003C_003Ec._003C_003E9__7_0 = val;
			obj = (object)val;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_toggle_mount_active", (OrderActionDelegate)obj, new TextObject("{=1cvf1Nkz}Mount", (Dictionary<string, object>)null)));
		object obj2 = _003C_003Ec._003C_003E9__7_1;
		if (obj2 == null)
		{
			OrderActionDelegate val2 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)35);
			};
			_003C_003Ec._003C_003E9__7_1 = val2;
			obj2 = (object)val2;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_toggle_mount", (OrderActionDelegate)obj2, new TextObject("{=5CnmF4oJ}Dismount", (Dictionary<string, object>)null)));
		return (VisualOrderSet)(object)simpleVisualOrderSet;
	}

	private VisualOrderSet CreateWidthOrderSet()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		SimpleVisualOrderSet simpleVisualOrderSet = new SimpleVisualOrderSet("Form Width", "order_type_form");
		object obj = _003C_003Ec._003C_003E9__8_0;
		if (obj == null)
		{
			OrderActionDelegate val = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)25);
			};
			_003C_003Ec._003C_003E9__8_0 = val;
			obj = (object)val;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_form_line", (OrderActionDelegate)obj, new TextObject("{=tHPXM5F6}Deep", (Dictionary<string, object>)null)));
		object obj2 = _003C_003Ec._003C_003E9__8_1;
		if (obj2 == null)
		{
			OrderActionDelegate val2 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)26);
			};
			_003C_003Ec._003C_003E9__8_1 = val2;
			obj2 = (object)val2;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_form_loose", (OrderActionDelegate)obj2, new TextObject("{=vdDdJnMc}Wide", (Dictionary<string, object>)null)));
		object obj3 = _003C_003Ec._003C_003E9__8_2;
		if (obj3 == null)
		{
			OrderActionDelegate val3 = delegate(OrderController oc, VisualOrderExecutionParameters p)
			{
				oc.SetOrder((OrderType)27);
			};
			_003C_003Ec._003C_003E9__8_2 = val3;
			obj3 = (object)val3;
		}
		((VisualOrderSet)simpleVisualOrderSet).AddOrder((VisualOrder)new ActionVisualOrder("order_form_scatter", (OrderActionDelegate)obj3, new TextObject("{=!}Wider", (Dictionary<string, object>)null)));
		return (VisualOrderSet)(object)simpleVisualOrderSet;
	}
}
