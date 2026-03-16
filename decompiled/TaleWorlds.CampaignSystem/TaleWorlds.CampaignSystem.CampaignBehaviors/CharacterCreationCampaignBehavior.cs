using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class CharacterCreationCampaignBehavior : CampaignBehaviorBase, ICharacterCreationContentHandler
{
	private static class CharacterOccupationTypes
	{
		public const string Retainer = "retainer";

		public const string Bard = "bard";

		public const string Hunter = "hunter";

		public const string Farmer = "farmer";

		public const string Herder = "herder";

		public const string Healer = "healer";

		public const string Mercenary = "mercenary";

		public const string Infantry = "infantry";

		public const string Skirmisher = "skirmisher";

		public const string Kern = "kern";

		public const string Guard = "guard";

		public const string RetainerUrban = "retainer_urban";

		public const string MercenaryUrban = "mercenary_urban";

		public const string MerchantUrban = "merchant_urban";

		public const string VagabondUrban = "vagabond_urban";

		public const string ArtisanUrban = "artisan_urban";

		public const string PhysicianUrban = "physician_urban";

		public const string HealerUrban = "healer_urban";

		public const string BardUrban = "bard_urban";

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool IsUrbanOccupation(string occupation)
		{
			throw null;
		}
	}

	private readonly IReadOnlyDictionary<string, string> _occupationToEquipmentMapping;

	private const int ChildhoodAge = 7;

	private const int EducationAge = 12;

	private const int YouthAge = 17;

	private const int AccomplishmentAge = 20;

	private const int ParentAge = 33;

	private const int YoungAdultAge = 20;

	private const int AdultAge = 30;

	private const int MiddleAge = 40;

	private const int ElderAge = 50;

	public const int FocusToAddYouthStart = 2;

	public const int FocusToAddAdultStart = 4;

	public const int FocusToAddMiddleAgedStart = 6;

	public const int FocusToAddElderlyStart = 8;

	public const int AttributeToAddYouthStart = 1;

	public const int AttributeToAddAdultStart = 2;

	public const int AttributeToAddMiddleAgedStart = 3;

	public const int AttributeToAddElderlyStart = 4;

	public const string MotherNarrativeCharacterStringId = "mother_character";

	public const string FatherNarrativeCharacterStringId = "father_character";

	public const string PlayerChildhoodCharacterStringId = "player_childhood_character";

	public const string PlayerEducationCharacterStringId = "player_education_character";

	public const string PlayerYouthCharacterStringId = "player_youth_character";

	public const string PlayerAdulthoodCharacterStringId = "player_adulthood_character";

	public const string PlayerAgeSelectionCharacterStringId = "player_age_selection_character";

	public const string HorseNarrativeCharacterStringId = "narrative_character_horse";

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
	private string GetPlayerChildhoodAgeEquipmentId(CharacterCreationManager characterCreationManager, string parentOccupationType, string cultureId, bool isFemale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetPlayerEducationAgeEquipmentId(CharacterCreationManager characterCreationManager, string parentOccupationType, string cultureId, bool isFemale)
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
	public void InitializeCharacterCreationStages(CharacterCreationManager characterCreationManager)
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
	public void FaceGenUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<NarrativeMenuCharacterArgs> GetParentMenuNarrativeMenuCharacterArgs(CultureObject culture, string occupationType, CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddParentsMenu(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEmpireParentNarrativeMenuOptions(NarrativeMenu narrativeMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEmpireLandlordNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EmpireLandlordNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EmpireLandlordNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEmpireUrbanNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EmpireUrbanNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EmpireUrbanNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEmpireFarmerNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EmpireFarmerNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EmpireFarmerNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEmpireArtisanNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EmpireArtisanNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EmpireArtisanNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEmpireHunterNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EmpireHunterNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EmpireHunterNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEmpireVagabondNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EmpireVagabondNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EmpireVagabondNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateParentEquipment(CharacterCreationManager characterCreationManager, MBEquipmentRoster motherEquipment, MBEquipmentRoster fatherEquipment, string motherAnimation, string fatherAnimation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddVlandianParentNarrativeMenuOptions(NarrativeMenu narrativeMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetVlandiaRetainerNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool VlandiaRetainerNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VlandiaRetainerNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetVlandiaMerchantNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool VlandiaMerchantNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VlandiaMerchantNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetVlandiaFarmerNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool VlandiaFarmerNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VlandiaFarmerNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetVlandiaBlacksmithNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool VlandiaBlacksmithNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VlandiaBlacksmithNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetVlandiaHunterNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool VlandiaHunterNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VlandiaHunterNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetVlandiaMercenaryNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool VlandiaMercenaryNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VlandiaMercenaryNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSturgianParentNarrativeMenuOptions(NarrativeMenu narrativeMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSturgiaCompanionNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SturgiaCompanionNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SturgiaCompanionNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSturgiaTraderNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SturgiaTraderNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SturgiaTraderNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSturgiaFarmerNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SturgiaFarmerNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SturgiaFarmerNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSturgiaArtisanNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SturgiaArtisanNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SturgiaArtisanNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSturgiaHunterNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SturgiaHunterNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SturgiaHunterNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSturgiaVagabondNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SturgiaVagabondNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SturgiaVagabondNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAseraiParentNarrativeMenuOptions(NarrativeMenu narrativeMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAseraiKinsfolkNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AseraiKinsfolkNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AseraiKinsfolkNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAseraiSlaveNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AseraiSlaveNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AseraiSlaveNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAseraiPhysicianNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AseraiPhysicianNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AseraiPhysicianNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAseraiFarmerNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AseraiFarmerNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AseraiFarmerNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAseraiHerderNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AseraiHerderNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AseraiHerderNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAseraiArtisanNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AseraiArtisanNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AseraiArtisanNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBattaniaNarrativeMenuOptions(NarrativeMenu narrativeMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBattaniaRetainerNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool BattaniaRetainerNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BattaniaRetainerNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBattaniaHealerNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool BattaniaHealerNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BattaniaHealerNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBattaniaFarmerNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool BattaniaFarmerNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BattaniaFarmerNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBattaniaArtisanNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool BattaniaArtisanNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BattaniaArtisanNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBattaniaHunterNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool BattaniaHunterNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BattaniaHunterNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBattaniaBardNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool BattaniaBardNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BattaniaBardNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddKhuzaitNarrativeMenuOptions(NarrativeMenu narrativeMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetKhuzaitRetainerNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool KhuzaitRetainerNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KhuzaitRetainerNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetKhuzaitMerchantNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool KhuzaitMerchantNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KhuzaitMerchantNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetKhuzaitHerderNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool KhuzaitHerderNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KhuzaitHerderNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetKhuzaitFarmerNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool KhuzaitFarmerNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KhuzaitFarmerNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetKhuzaitHealerNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool KhuzaitHealerNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KhuzaitHealerNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetKhuzaitNomadHerderNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool KhuzaitNomadHerderNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KhuzaitNomadHerderNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<NarrativeMenuCharacterArgs> GetChildhoodMenuNarrativeMenuCharacterArgs(CultureObject culture, string occupationType, CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddChildhoodMenu(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddChildhoodNarrativeMenuOptions(NarrativeMenu narrativeMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetChildhoodLeadershipOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ChildhoodLeadershipOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChildhoodLeadershipOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetChildhoodBrawnOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ChildhoodBrawnOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChildhoodBrawnOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetChildhoodDetailOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ChildhoodDetailOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChildhoodDetailOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetChildhoodSmartOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ChildhoodSmartOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChildhoodSmartOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetChildhoodLeaderOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ChildhoodLeaderOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChildhoodLeaderOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetChildhoodHorseOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ChildhoodHorseOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChildhoodHorseOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<NarrativeMenuCharacterArgs> GetEducationMenuNarrativeMenuCharacterArgs(CultureObject culture, string occupationType, CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEducationMenu(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEducationMenuOptions(NarrativeMenu narrativeMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationHerderOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationHerderOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationHerderOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationSmithOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationSmithOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationSmithOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationEngineerOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationEngineerOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationEngineerOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationDoctorOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationDoctorOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationDoctorOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationHunterOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationHunterOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationHunterOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationMerchantOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationMerchantOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationMerchantOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationWatcherOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationWatcherOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationWatcherOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationGangerOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationGangerOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationGangerOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationDockerOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationDockerOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationDockerOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationMarketerOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationMarketerOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationMarketerOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationTutorOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationTutorOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationTutorOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEducationPoorHorserOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EducationPoorHorserOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EducationPoorHorserOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<NarrativeMenuCharacterArgs> GetYouthMenuNarrativeMenuCharacterArgs(CultureObject culture, string occupationType, CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddYouthMenu(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddYouthMenuOptions(NarrativeMenu narrativeMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthStaffOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthStaffOneOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthStaffTwoOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthStaffOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthGroomOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthGroomOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthGroomOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthServantOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthServantOneOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthServantTwoOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthServantOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthCavalryOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthCavalryOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthCavalryOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthHearthOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthHearthOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthHearthOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthGuardHighRegisterOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthGuardHighRegisterOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthGuardHighRegisterOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthGuardLowRegisterOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthGuardLowRegisterOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthGuardLowRegisterOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthGuardGarrisonRegisterOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthGuardGarrisonRegisterOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthGuardGarrisonRegisterOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthGuardEmpireRegisterOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthGuardEmpireRegisterOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthGuardEmpireRegisterOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthRiderHighRegisterOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthRiderHighRegisterOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthRiderHighRegisterOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthRiderLowRegisterOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthRiderLowRegisterOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthRiderLowRegisterOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthInfantryOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthInfantryOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthInfantryOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthSkirmisherOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthSkirmisherOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthSkirmisherOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthKernOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthKernOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthKernOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetYouthCampOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool YouthCampOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YouthCampOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEnvoysGuardFirstOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEnvoysGuardSecondOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EnvoysGuardFirstOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EnvoysGuardSecondOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnvoysGuardFirstOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnvoysGuardSecondOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<NarrativeMenuCharacterArgs> GetAdultMenuNarrativeMenuCharacterArgs(CultureObject culture, string occupationType, CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAdulthoodMenu(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAdulthoodMenuOptions(NarrativeMenu narrativeMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodDefeatedEnemyOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodDefeatedEnemyOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodDefeatedEnemyOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodManhuntOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodManhuntOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodManhuntOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodCaravanLeaderOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodCaravanLeaderOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodCaravanLeaderOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodSavedVillageOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodSavedVillageOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodSavedVillageOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodSavedCityOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodSavedCityOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodSavedCityOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodWorkshopOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodWorkshopOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodWorkshopOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodInvestorOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodInvestorOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodInvestorOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodHunterOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodHunterOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodHunterOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodSiegeSurvivorOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodSiegeSurvivorOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodSiegeSurvivorOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodEscapadeHighRegisterOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodEscapadeHighRegisterOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodEscapadeHighRegisterOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodEscapadeLowRegisterOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodEscapadeLowRegisterOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodEscapadeLowRegisterOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAdulthoodNicePersonOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AdulthoodNicePersonOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdulthoodNicePersonOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<NarrativeMenuCharacterArgs> GetAgeSelectionMenuNarrativeMenuCharacterArgs(CultureObject culture, string occupationType, CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAgeSelectionMenu(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAgeSelectionYoungAdultAgeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AgeSelectionYoungAdultAgeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AgeSelectionYoungAdultAgeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AgeSelectionYoungAdultAgeOptionOnConsequence(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAgeSelectionAdultOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AgeSelectionAdultOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AgeSelectionAdultOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AgeSelectionAdultOptionOnConsequence(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAgeSelectionMiddleAgeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AgeSelectionMiddleAgeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AgeSelectionMiddleAgeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AgeSelectionMiddleAgeOptionOnConsequence(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAgeSelectionElderOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AgeSelectionElderOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AgeSelectionElderOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AgeSelectionElderOptionOnConsequence(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyMainHeroEquipment(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHeroAge(float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CharacterCreationCampaignBehavior()
	{
		throw null;
	}
}
