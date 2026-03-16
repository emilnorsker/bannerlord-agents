using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.Core.ViewModelCollection.ImageIdentifiers;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.Decisions;

public class DecisionSupporterVM : ViewModel
{
	private Supporter.SupportWeights _weight;

	private Clan _clan;

	private TextObject _nameObj;

	private Hero _hero;

	private CharacterImageIdentifierVM _visual;

	private string _name;

	private int _supportStrength;

	private string _supportWeightImagePath;

	[DataSourceProperty]
	public CharacterImageIdentifierVM Visual
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
	public int SupportStrength
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
	public string SupportWeightImagePath
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
	public string Name
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
	public DecisionSupporterVM(TextObject name, string imagePath, Clan clan, Supporter.SupportWeights weight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteBeginHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteEndHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string GetSupporterWeightImagePath(Supporter.SupportWeights weight)
	{
		throw null;
	}
}
