using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AIInfluence;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.ChatTools;

/// <summary>Formats player-visible chat pill lines when a chat tool runs. Colors match <see cref="NpcChatWindowVM"/> segment constants.</summary>
public static class ChatToolPillBuilder
{
	public const string ActionColor = "#FFD700FF";
	public const string MoneyTransferColor = "#E6B800FF";
	public const string ItemTransferColor = "#4CAF50FF";
	public const string TroopTransferColor = "#78909CFF";
	public const string QuestActionColor = "#26A69AFF";
	public const string MapOrderPillColor = "#81C784FF";
	public const string RomanceActionColor = "#E91E63FF";
	public const string WorkshopActionColor = "#FFB74DFF";
	public const string KingdomActionColor = "#5C6BC0FF";

	private static string ResolveItemName(string itemId)
	{
		if (string.IsNullOrEmpty(itemId)) return "Unknown item";
		var item = MBObjectManager.Instance?.GetObject<ItemObject>(itemId);
		return item?.Name?.ToString() ?? "Unknown item";
	}

	private static string ResolveTroopName(string stringId)
	{
		if (string.IsNullOrEmpty(stringId)) return "Unknown troop";
		var troop = MBObjectManager.Instance?.GetObject<CharacterObject>(stringId);
		return troop?.Name?.ToString() ?? "Unknown troop";
	}

	private static string FormatTroopTransferLine(string payload, string npcName)
	{
		string[] dirAndRest = payload.Split(new[] { ':' }, 2);
		if (dirAndRest.Length < 2) return "Transferred troops";
		bool toPlayer = dirAndRest[0].Trim().Equals("to_player", StringComparison.OrdinalIgnoreCase);
		var items = new List<string>();
		foreach (string part in dirAndRest[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
		{
			string[] segs = part.Trim().Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
			if (segs.Length < 3 || !int.TryParse(segs[2], out int count) || count <= 0) continue;
			string name = ResolveTroopName(segs[1].Trim());
			items.Add($"{name} (x{count})");
		}
		if (items.Count == 0) return toPlayer ? $"{npcName} transferred troops to you" : $"You transferred troops to {npcName}";
		string list = string.Join(", ", items);
		return toPlayer ? $"{npcName} gave you {list}" : $"You gave {list} to {npcName}";
	}

	public static string FormatItemListForPill(IEnumerable<ItemTransferData> transfers) =>
		string.Join(", ", transfers.Select(t => $"{ResolveItemName(t.ItemId)} (x{t.Amount})"));

	/// <summary>Chat pill for one map/order tool (internal tag + payload, e.g. <c>follow_player</c>, <c>go_to_settlement:id:3</c>).</summary>
	public static void AppendMapToolPill(NPCContext context, Hero npc, string toolTagAndPayload)
	{
		if (context == null || string.IsNullOrWhiteSpace(toolTagAndPayload)) return;
		string npcName = ((object)npc?.Name)?.ToString() ?? "Unknown";
		string[] segs = toolTagAndPayload.Trim().Split(new[] { ':' }, 2);
		string name = segs[0].Trim();
		string payload = segs.Length > 1 ? segs[1].Trim() : "";
		bool isStop = payload.Equals("STOP", StringComparison.OrdinalIgnoreCase);
		if (isStop)
			context.AppendToolPill($"Stopped {name}", MapOrderPillColor);
		else if (name.Equals("follow_player", StringComparison.OrdinalIgnoreCase))
			context.AppendToolPill("Now following you", MapOrderPillColor);
		else if (name.Equals("return_to_player", StringComparison.OrdinalIgnoreCase))
			context.AppendToolPill("Returning to you", MapOrderPillColor);
		else if (name.Equals("go_to_settlement", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(payload))
			context.AppendToolPill($"Traveling to {payload.Split(':')[0]}", MapOrderPillColor);
		else if (name.Equals("transfer_troops_and_prisoners", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(payload))
			context.AppendToolPill(FormatTroopTransferLine(payload, npcName), TroopTransferColor);
		else if (!string.IsNullOrEmpty(name))
			context.AppendToolPill(name, MapOrderPillColor);
		context.MapToolRanThisTurn = true;
	}

	public static void AppendMoneyGive(NPCContext context, string npcName, int amount) =>
		context?.AppendToolPill($"{npcName} gave you {amount} gold", MoneyTransferColor);

	public static void AppendMoneyReceive(NPCContext context, string npcName, int amount) =>
		context?.AppendToolPill($"{npcName} received {amount} gold from you", MoneyTransferColor);

	public static void AppendPlayerMoneyGive(NPCContext context, string npcName, int amount) =>
		context?.AppendPlayerToolPill($"You gave {amount} gold to {npcName}", MoneyTransferColor);

	public static void AppendPlayerMoneyReceive(NPCContext context, string npcName, int amount) =>
		context?.AppendPlayerToolPill($"You received {amount} gold from {npcName}", MoneyTransferColor);

	public static void AppendNpcItemGive(NPCContext context, string npcName, IEnumerable<ItemTransferData> transfers) =>
		context?.AppendToolPill($"{npcName} gave you {FormatItemListForPill(transfers)}", ItemTransferColor);

	public static void AppendNpcItemTake(NPCContext context, string npcName, IEnumerable<ItemTransferData> transfers) =>
		context?.AppendToolPill($"{npcName} took {FormatItemListForPill(transfers)} from you", ItemTransferColor);

	public static void AppendPlayerItemGive(NPCContext context, string npcName, IEnumerable<ItemTransferData> transfers) =>
		context?.AppendPlayerToolPill($"You gave {FormatItemListForPill(transfers)} to {npcName}", ItemTransferColor);

	public static void AppendPlayerItemReceive(NPCContext context, string npcName, IEnumerable<ItemTransferData> transfers) =>
		context?.AppendPlayerToolPill($"You received {FormatItemListForPill(transfers)} from {npcName}", ItemTransferColor);

	/// <summary>One pill for a pending <c>kingdom_action</c> (shown when chat row finalizes after streaming).</summary>
	public static (string Text, string Color) FormatKingdomActionPill(AIResponse k)
	{
		if (k == null || string.IsNullOrWhiteSpace(k.KingdomAction))
			return ("", "");
		string action = k.KingdomAction.Trim();
		if (action.Equals("none", StringComparison.OrdinalIgnoreCase))
			return ("", "");
		string reason = k.KingdomActionReason;
		string line = string.IsNullOrWhiteSpace(reason)
			? "Kingdom: " + action
			: "Kingdom: " + action + " — " + Regex.Replace(reason.Trim(), @"\s+", " ");
		string t = line.Trim();
		if (!t.StartsWith("• ", StringComparison.Ordinal))
			t = "• " + t;
		return (t, KingdomActionColor);
	}

	public static void AppendRomanceIntent(NPCContext context, string intent)
	{
		if (context == null || string.IsNullOrEmpty(intent) || intent.Equals("none", StringComparison.OrdinalIgnoreCase)) return;
		string ri = intent.Trim().ToLowerInvariant();
		string msg = ri == "flirt" ? "Accepted your flirtation" : ri == "romance" ? "Accepted your courtship" : ri == "proposal" ? "Marriage proposal" : $"Romance: {intent.Trim()}";
		context.AppendToolPill(msg, RomanceActionColor);
	}
}
