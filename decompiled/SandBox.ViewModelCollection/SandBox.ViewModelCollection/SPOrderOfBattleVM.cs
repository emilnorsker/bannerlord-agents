using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.OrderOfBattle;

namespace SandBox.ViewModelCollection;

public class SPOrderOfBattleVM : OrderOfBattleVM
{
	private OrderOfBattleCampaignBehavior _orderOfBattleBehavior;

	private static readonly TextObject _perkDefinitionText;

	private readonly TextObject _captainPerksText;

	private readonly TextObject _infantryInfluenceText;

	private readonly TextObject _rangedInfluenceText;

	private readonly TextObject _cavalryInfluenceText;

	private readonly TextObject _horseArcherInfluenceText;

	private readonly TextObject _noPerksText;

	private readonly PerkObjectComparer _perkComparer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SPOrderOfBattleVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void LoadConfiguration()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SaveConfiguration()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override List<TooltipProperty> GetAgentTooltip(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddPerks(TextObject title, List<TooltipProperty> tooltipProperties, List<PerkObject> perks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SPOrderOfBattleVM()
	{
		throw null;
	}
}
