using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultClanFinanceModel : ClanFinanceModel
{
	private enum TransactionType
	{
		Income = 1,
		Both = 0,
		Expense = -1
	}

	public enum AssetIncomeType
	{
		Workshop,
		Caravan,
		Taxes,
		TributesEarned
	}

	private static readonly string _townTaxStr;

	private static readonly string _partyIncomeStr;

	private static readonly string _partyExpensesStr;

	private static readonly string _tributeIncomeStr;

	private static readonly string _tariffTaxStr;

	private static readonly string _caravanIncomeStr;

	private static readonly string _convoyIncomeStr;

	private static readonly TextObject _projectsIncomeText;

	private static readonly TextObject _shopExpenseText;

	private static readonly TextObject _mercenaryText;

	private static readonly TextObject _mercenaryExpensesText;

	private static readonly TextObject _tributeExpensesText;

	private static readonly TextObject _tributeIncomes;

	private static readonly TextObject _callToWarExpenses;

	private static readonly TextObject _callToWarIncomes;

	private static readonly TextObject _settlementIncome;

	private static readonly TextObject _mainPartywageText;

	private static readonly TextObject _caravanAndPartyIncome;

	private static readonly TextObject _garrisonAndPartyExpenses;

	private static readonly TextObject _debtText;

	private static readonly TextObject _kingdomSupportText;

	private static readonly TextObject _kingdomBudgetText;

	private static readonly TextObject _autoRecruitmentText;

	private static readonly TextObject _alleyText;

	private static readonly TextObject _shopIncomeText;

	private const int PartyGoldIncomeThreshold = 10000;

	private const int payGarrisonWagesTreshold = 8000;

	private const int payClanPartiesTreshold = 4000;

	private const int payLeaderPartyWageTreshold = 2000;

	public override int PartyGoldLowerThreshold
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateClanGoldChange(Clan clan, bool includeDescriptions = false, bool applyWithdrawals = false, bool includeDetails = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateClanIncome(Clan clan, bool includeDescriptions = false, bool applyWithdrawals = false, bool includeDetails = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateClanIncomeInternal(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals = false, bool includeDetails = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CalculateClanExpensesInternal(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals = false, bool includeDetails = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPlayerExpenseForWorkshops(ref ExplainedNumber goldChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateClanExpenses(Clan clan, bool includeDescriptions = false, bool applyWithdrawals = false, bool includeDetails = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPaymentForDebts(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddRulingClanIncome(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals, bool includeDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddExpensesForHiredMercenaries(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddExpensesForTributes(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddExpensesForCallToWarAgreements(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyShareForExpenses(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals, int expenseShare, TextObject mercenaryExpensesText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSettlementIncome(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals, bool includeDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateTownIncomeFromTariffs(Clan clan, Town town, bool applyWithdrawals = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateSettlementProjectTariffBonuses(Town town, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateTownIncomeFromProjects(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateVillageIncome(Clan clan, Village village, bool applyWithdrawals = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float CalculateShareFactor(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddMercenaryIncome(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddIncomeFromKingdomBudget(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPlayerClanIncomeFromOwnedAlleys(ref ExplainedNumber goldChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddIncomeFromTribute(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals, bool includeDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddIncomeFromCallToWarAgrements(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddIncomeFromParties(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals, bool includeDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int AddIncomeFromParty(MobileParty party, Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddExpensesFromPartiesAndGarrisons(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals, bool includeDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddExpensesForAutoRecruitment(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int AddExpenseFromLeaderParty(Clan clan, ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int AddPartyExpense(MobileParty party, Clan clan, ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateOwnerIncomeFromCaravan(MobileParty caravan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateOwnerIncomeFromWorkshop(Workshop workshop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateHeroIncomeFromAssets(Hero hero, ref ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateHeroIncomeFromWorkshops(Hero hero, ref ExplainedNumber goldChange, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float RevenueSmoothenFraction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculatePartyWage(MobileParty mobileParty, int budget, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateNotableDailyGoldChange(Hero hero, bool applyWithdrawals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyMoraleEffect(MobileParty mobileParty, int wage, int paymentAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultClanFinanceModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultClanFinanceModel()
	{
		throw null;
	}
}
