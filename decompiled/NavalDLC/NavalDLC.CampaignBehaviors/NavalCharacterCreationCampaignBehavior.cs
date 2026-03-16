using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;

namespace NavalDLC.CampaignBehaviors;

public class NavalCharacterCreationCampaignBehavior : CampaignBehaviorBase, ICharacterCreationContentHandler
{
	private static class NavalCharacterOccupationTypes
	{
		public const string Retainer = "retainer";

		public const string Bard = "bard";

		public const string Hunter = "hunter";

		public const string Mercenary = "mercenary";

		public const string Infantry = "infantry";

		public const string Skirmisher = "skirmisher";

		public const string Artisan = "artisan";

		public const string Vagabond = "vagabond";

		public const string Guard = "guard";

		public const string ArtisanUrban = "artisan_urban";

		public const string MercenaryUrban = "mercenary_urban";

		public const string MerchantUrban = "merchant_urban";

		public const string VagabondUrban = "vagabond_urban";

		public const string RetainerUrban = "retainer_urban";

		public const string PhysicianUrban = "physician_urban";

		public const string HealerUrban = "healer_urban";

		public const string BardUrban = "bard_urban";

		public const string Seafarer = "seafarer";

		public const string ShipmasterUrban = "shipmaster_urban";

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool IsUrbanOccupation(string occupation)
		{
			throw null;
		}
	}

	private readonly IReadOnlyDictionary<string, string> _occupationToEquipmentMapping;

	public const string MotherNarrativeCharacterStringId = "mother_character";

	public const string FatherNarrativeCharacterStringId = "father_character";

	public const string PlayerChildhoodCharacterStringId = "player_childhood_character";

	public const string PlayerEducationCharacterStringId = "player_education_character";

	public const string PlayerYouthCharacterStringId = "player_youth_character";

	private int _focusToAdd;

	private int _skillLevelToAdd;

	private int _attributeLevelToAdd;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetMotherEquipmentId(CharacterCreationManager characterCreationManager, string occupationType, string cultureId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetFatherEquipmentId(CharacterCreationManager characterCreationManager, string occupationType, string cultureId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetPlayerEquipmentId(CharacterCreationManager characterCreationManager, string occupationType, string cultureId, bool isFemale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCharacterCreationInitialized(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationContentHandler.InitializeContent(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationContentHandler.AfterInitializeContent(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationContentHandler.OnStageCompleted(CharacterCreationStageBase stage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationContentHandler.OnCharacterCreationFinalize(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeCharacterCreationCultures(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeData(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddVlandiaParentMenuOptions(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetVlandiaCoastalFishermanNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool VlandiaCoastalFishermanNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VlandiaCoastalFishermanNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetVlandiaDockersNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool VlandiaDockersNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetVlandiaDockersNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSturgiaParentMenuOptions(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSturgiaRiverFishermanNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SturgiaRiverFishermanNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSturgiaRiverFishermanNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSturgiaShipbuildersNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SturgiaShipbuildersNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSturgiaShipbuildersNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAseraiParentMenuOptions(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAseraiFerrymanNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AseraiFerrymanNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAseraiFerrymanNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAseraiCorsairTradersNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AseraiCorsairTradersNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAseraiCorsairTradersNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBattaniaParentMenuOptions(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBattaniaCurrachSailorsNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool BattaniaCurrachSailorsNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBattaniaCurrachSailorsNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBattaniaGuardianOfTheLakeNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool BattaniaGuardianOfTheLakeNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBattaniaGuardianOfTheLakeNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddKhuzaitParentMenuOptions(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetKhuzaitRiverForagersNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool KhuzaitRiverForagersNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetKhuzaitRiverForagersNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetKhuzaitRiverTradersNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool KhuzaitRiverTradersNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetKhuzaitRiverTradersNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEmpireParentMenuOptions(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEmpireSmallBoatFishermanNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EmpireSmallBoatFishermanNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEmpireSmallBoatFishermanNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEmpireImperialFleetNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EmpireImperialFleetNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEmpireImperialFleetNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddNordParentMenuOptions(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetNordHersirNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NordHersirNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NordHersirNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetNordMarketTraderNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NordMarketTraderNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NordMarketTraderNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetNordSkaldNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NordSkaldNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NordSkaldNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetNordBlacksmithNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NordBlacksmithNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NordBlacksmithNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetNordHunterNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NordHunterNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NordHunterNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetNordVagabondNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NordVagabondNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NordVagabondNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetNordSailorsNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NordSailorsNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetNordSailorsNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetNordShipwrightsNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NordShipwrightsNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetNordShipwrightsNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateParentEquipment(CharacterCreationManager characterCreationManager, MBEquipmentRoster motherEquipment, MBEquipmentRoster fatherEquipment, string motherAnimation, string fatherAnimation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEarlyChildhoodMenuOptions(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetChildhoodPredictWeatherOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ChildhoodPredictWeatherOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChildhoodPredictWeatherOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEducationMenuOptions(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationFishingBoatOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationFishingBoatOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationFishingBoatOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationDocksOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationDocksOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationDocksOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddYouthMenuOptions(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthNordGuardOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthNordGuardOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthNordGuardOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthNordSkirmisherOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthNordSkirmisherOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthNordSkirmisherOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthNordVagabondOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthNordVagabondOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthNordVagabondOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthNordArtisanOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthNordArtisanOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthNordArtisanOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthNordInfantryOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthNordInfantryOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthNordInfantryOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthNordMercenaryOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthNordMercenaryOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthNordMercenaryOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthCrewedAGalleyNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthCrewedAGalleyNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthCrewedAGalleyNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthRowedRiverTraderNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthRowedRiverTraderNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthRowedRiverTraderNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthDeckhandCorsairNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthDeckhandCorsairNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthDeckhandCorsairNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthRaidedRiverTrafficNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthRaidedRiverTrafficNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthRaidedRiverTrafficNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthCoastalDefenderNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthCoastalDefenderNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthCoastalDefenderNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthServeRaiderShipNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthServeRaiderShipNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthServeRaiderShipNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalCharacterCreationCampaignBehavior()
	{
		throw null;
	}
}
