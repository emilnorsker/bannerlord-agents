using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AIInfluence.API;
using AIInfluence.Behaviors.RolePlay;
using AIInfluence.Util;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.Common;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public class ModSettings : AttributeGlobalSettings<ModSettings>
{
	private DateTime _lastForceGenerateEventTime = DateTime.MinValue;

	private bool _enableModification = true;

	private bool _enableNearbyNPCInitialization = true;

	private bool _enableDebugLogging = true;

	private Dropdown<string> _aiBackend = new Dropdown<string>((IEnumerable<string>)new List<string> { "OpenRouter", "DeepSeek", "Player2", "Ollama", "KoboldCpp" }, 2);

	private string _aiModel = "gpt-3.5-turbo";

	private string _apiKey = "";

	private string _deepSeekModel = "deepseek-chat";

	private string _deepSeekApiKey = "";

	private bool _enableTTS = false;

	private bool _enableTTSAnimations = true;

	private float _ttsSpeed = 1f;

	private float _ttsVolume = 1.5f;

	private bool _promptEnableInternalThoughts = false;

	private int _promptMaxHistory = 100;

	private bool _promptIncludeEvents = true;

	private float _promptSensitiveTrust = 0.5f;

	private float _promptSecretTrust = 0.8f;

	private bool _promptIncludeQuirks = true;

	private bool _promptEnableQuests = true;

	private string _debugQuestGenerationPrompt = "";

	private float _promptQuirksFrequency = 0.5f;

	private bool _promptUseAsterisks = true;

	private float _promptLieStrictness = 0.5f;

	private int _promptMinResponseLength = 20;

	private int _promptMaxResponseLength = 500;

	private bool _promptIncludeFriends = true;

	private int _promptMaxFriends = 5;

	private int _promptMaxEnemies = 5;

	private bool _useAdvancedTrust = false;

	private float _interactionTrustBonus = 0.01f;

	private float _familiarityTrustBonus = 0.1f;

	private float _minLieTrustPenalty = 0.05f;

	private float _maxLieTrustPenalty = 0.1f;

	private int _minLieRelationPenalty = 1;

	private int _maxLieRelationPenalty = 5;

	private int _minPositiveRelationChange = 1;

	private int _maxPositiveRelationChange = 5;

	private int _minNegativeRelationChange = 1;

	private int _maxNegativeRelationChange = 5;

	private float _femaleNPCRomanceInitiative = 0.2f;

	private float _maleNPCRomanceInitiative = 0.6f;

	private int _minRomanceChange = 2;

	private int _maxRomanceChange = 10;

	private int _romanceDecayDays = 7;

	private int _minRomanceToAcceptMarriage = 50;

	private int _romanceDecayAmount = 2;

	private bool _allowRomanceWithMarried = false;

	private float _intimacyConceptionChance = 0.15f;

	private float _intimacyRomanceIncrease = 15f;

	private bool _companionAutoRecognize = true;

	private bool _kingdomAutoRecognize = true;

	private bool _clanTierAutoRecognize = false;

	private int _clanTierThreshold = 3;

	private float _clanTierRecognitionChance = 25f;

	private bool _realisticInformationSpread = true;

	private float _localNewsDistance = 15f;

	private float _regionalNewsDistance = 50f;

	private float _kingdomNewsDistance = 150f;

	private float _nobleDistanceMultiplier = 1.5f;

	private float _royalDistanceMultiplier = 2f;

	private int _relationshipThreshold = 20;

	private bool _enableSocialFiltering = true;

	private bool _enableRelationshipOverride = true;

	private bool _enableFactionOverride = true;

	private bool _enableDetailedInfoLogging = false;

	private int _newsDelayHoursPerDistance = 2;

	private int _recentEventsLifetimeDays = 30;

	private int _maxRecentEvents = 50;

	private bool _enableDynamicEventsInternalThoughts = false;

	private bool _enableDynamicEvents = true;

	private bool _dynamicEventsDialogueOnly = false;

	private int _maxSimultaneousDynamicEvents = 1;

	private int _dynamicEventsInterval = 3;

	private int _dynamicEventsMinLength = 100;

	private int _dynamicEventsMaxLength = 600;

	private int _dynamicEventsLifespan = 100;

	private bool _enableMilitaryEvents = true;

	private int _militaryEventsChance = 20;

	private bool _enablePoliticalEvents = true;

	private int _politicalEventsChance = 20;

	private bool _enableEconomicEvents = true;

	private int _economicEventsChance = 20;

	private bool _enableSocialEvents = true;

	private int _socialEventsChance = 20;

	private bool _enableMysteriousEvents = true;

	private int _mysteriousEventsChance = 20;

	private bool _enableDiseaseOutbreakEvents = true;

	private int _diseaseOutbreakEventsChance = 10;

	private int _prosperityDeltaMin = -100;

	private int _prosperityDeltaMax = 100;

	private int _prosperityDeltaPerDayMin = -10;

	private int _prosperityDeltaPerDayMax = 10;

	private int _foodDeltaMin = -100;

	private int _foodDeltaMax = 100;

	private int _foodDeltaPerDayMin = -10;

	private int _foodDeltaPerDayMax = 10;

	private int _securityDeltaMin = -5;

	private int _securityDeltaMax = 5;

	private int _securityDeltaPerDayMin = -1;

	private int _securityDeltaPerDayMax = 1;

	private int _loyaltyDeltaMin = -5;

	private int _loyaltyDeltaMax = 5;

	private int _loyaltyDeltaPerDayMin = -1;

	private int _loyaltyDeltaPerDayMax = 1;

	private float _incomeMultiplierMin = 0.5f;

	private float _incomeMultiplierMax = 1.5f;

	private int _durationDaysMin = 7;

	private int _durationDaysMax = 90;

	private bool _enableDiplomacyInternalThoughts = false;

	private bool _enableDiplomacy = true;

	private bool _startInPeace = false;

	private int _maxParticipatingKingdoms = 4;

	private int _statementGenerationIntervalDays = 2;

	private int _diplomacyMinStatementLength = 100;

	private int _diplomacyMaxStatementLength = 500;

	private int _minKingdomRelationChange = -10;

	private int _maxKingdomRelationChange = 10;

	private float _fatiguePerTroopLost = 0.002f;

	private float _fatiguePerLordKilled = 5f;

	private float _fatiguePerLordCaptured = 2f;

	private float _fatiguePerSettlementLost = 10f;

	private float _fatiguePerCaravanDestroyed = 2f;

	private float _fatigueRecoveryPerDay = 3f;

	private bool _enableDiseaseSystem = true;

	private bool _enableSeasonalDiseases = true;

	private float _seasonalDiseaseBaseChance = 0.02f;

	private float _seasonalDiseaseMaxChance = 0.35f;

	private float _seasonalWinterBonus = 0.08f;

	private float _seasonalAutumnBonus = 0.05f;

	private float _seasonalSpringBonus = 0.03f;

	private float _seasonalSummerBonus = 0.01f;

	private float _seasonalWeatherLightRainBonus = 0.02f;

	private float _seasonalWeatherHeavyRainBonus = 0.04f;

	private float _seasonalWeatherSnowyBonus = 0.05f;

	private float _seasonalWeatherBlizzardBonus = 0.08f;

	private float _seasonalWeatherWetBonus = 0.01f;

	private float _seasonalShipAtSeaBonus = 0.04f;

	private float _diseaseTreatmentBaseCost = 100f;

	private float _diseaseTreatmentTroopMultiplier = 0.5f;

	private float _diseasePreventionHerbCostMultiplier = 1f;

	private float _diseaseMedicineSkillForTroopsMultiplier = 0.75f;

	private float _diseaseProgressionMultiplier = 1f;

	private float _diseaseRecoveryMultiplier = 1f;

	private int _seasonalPostRecoveryImmunityDays = 21;

	private float _diseaseSpreadInheritFactor = 0.75f;

	private float _settlementInfectionBaseChance = 0.05f;

	private float _missionInfectionBaseChance = 0.08f;

	private float _playerFromTroopsBaseChance = 0.175f;

	private float _lordHallInfectionChancePerLord = 0.025f;

	private float _quarantineInfectionReduction = 0.5f;

	private float _prisonerSpreadModifier = 0.5f;

	private int _diseaseMaxSeverity = 5;

	private int _diseaseMaxSimultaneous = 3;

	private int _diseaseMinDaysBetweenOutbreaks = 14;

	private float _diseaseMaxSpreadRate = 0.8f;

	private float _diseaseMaxDeathChance = 0.3f;

	private float _diseaseMinCombatModifier = 0.5f;

	private float _diseaseMinMapSpeedModifier = 0.5f;

	private float _diseaseMaxMoralePenalty = -30f;

	private float _diseaseMaxPhysicalSkillPenalty = -30f;

	private bool _enableNPCInitiative = true;

	private float _npcInitiativeBaseChance = 2.5f;

	private float _npcInitiativeFriendlyBonus = 1.5f;

	private float _npcInitiativeHostileBonus = 1f;

	private bool _enableNPCMapInitiative = true;

	private float _npcInitiativeMapBaseChance = 2f;

	private float _npcInitiativeRomanceBonus = 2f;

	private float _npcInitiativeFamiliarityBonus = 3f;

	private float _npcInitiativePartyBonus = 2f;

	private float _npcInitiativeLongTimeSinceContactBonus = 5f;

	private float _messengerCostPerDistance = 15f;

	private float _messengerDeliveryHoursPerDistance = 1f;

	private bool _enableArenaTraining = true;

	private float _dialogDelay = 15f;

	private bool _enableResponseReadySound = true;

	private bool _enableNPCLastMessageHistory = true;

	private bool _enableDeadNPCCleanup = false;

	public override string Id => "AIInfluenceSettings";

	public override string DisplayName => ((object)new TextObject("{=AIInfluence_Settings}AIInfluence Settings", (Dictionary<string, object>)null)).ToString();

	public override string FolderName => "AIInfluence";

	public override string FormatType => "json";

	[SettingPropertyGroup("{=AIInfluence_Group_General}General Settings", GroupOrder = 0)]
	[SettingPropertyBool("{=AIInfluence_EnableModification}Enable Modification", Order = 1, RequireRestart = false, HintText = "{=AIInfluence_EnableModification_Hint}Enables or disables the AIInfluence mod.")]
	public bool EnableModification
	{
		get
		{
			return _enableModification;
		}
		set
		{
			if (_enableModification != value)
			{
				_enableModification = value;
				this.OnSettingChanged?.Invoke("EnableModification", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_General}General Settings", GroupOrder = 0)]
	[SettingPropertyBool("{=AIInfluence_EnableNearbyNPCInitialization}Enable Nearby NPC Initialization", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_EnableNearbyNPCInitialization_Hint}Automatically initialize NPCs near the player every 2 hours.")]
	public bool EnableNearbyNPCInitialization
	{
		get
		{
			return _enableNearbyNPCInitialization;
		}
		set
		{
			if (_enableNearbyNPCInitialization != value)
			{
				_enableNearbyNPCInitialization = value;
				this.OnSettingChanged?.Invoke("EnableNearbyNPCInitialization", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_General}General Settings", GroupOrder = 0)]
	[SettingPropertyBool("{=AIInfluence_EnableDebugLogging}Enable Debug Logging", Order = 3, RequireRestart = false, HintText = "{=AIInfluence_EnableDebugLogging_Hint}Enables logging of debug messages to a file.")]
	public bool EnableDebugLogging
	{
		get
		{
			return _enableDebugLogging;
		}
		set
		{
			if (_enableDebugLogging != value)
			{
				_enableDebugLogging = value;
				this.OnSettingChanged?.Invoke("EnableDebugLogging", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_General}General Settings", GroupOrder = 0)]
	[SettingPropertyButton("Open Logs Folder", 4, true, "Open Logs Folder", Content = "Open Logs Folder", RequireRestart = false, HintText = "Opens the mod's logs folder in Windows Explorer")]
	public Action OpenLogsFolder { get; set; } = delegate
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		try
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
			string text = Path.Combine(fullName, "logs");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			Process.Start(new ProcessStartInfo
			{
				FileName = text,
				UseShellExecute = true
			});
		}
		catch (Exception ex)
		{
			InformationManager.DisplayMessage(new InformationMessage("Could not open logs folder: " + ex.Message, Colors.Yellow));
		}
	};

	[SettingPropertyGroup("{=AIInfluence_Group_Community}Community & Support", GroupOrder = -2)]
	[SettingPropertyButton("{=AIInfluence_JoinDiscord}Join Discord - Support & Community", -1, true, "{=AIInfluence_JoinDiscord_Button}Open Discord", Content = "{=AIInfluence_JoinDiscord_Content}Join Discord Server", RequireRestart = false, HintText = "{=AIInfluence_JoinDiscord_Hint}Join our Discord server for support, updates, and community discussions")]
	public Action OpenDiscordServer { get; set; } = delegate
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		try
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "https://discord.gg/692hQj3rvq",
				UseShellExecute = true
			});
		}
		catch (Exception)
		{
			InformationManager.DisplayMessage(new InformationMessage("Could not open browser. Discord: https://discord.gg/692hQj3rvq", Colors.Yellow));
		}
	};

	[SettingPropertyGroup("{=AIInfluence_Group_Community}Community & Support", GroupOrder = -2)]
	[SettingPropertyButton("{=AIInfluence_OpenBoosty}Support on Boosty", -1, true, "{=AIInfluence_OpenBoosty_Button}Open Boosty", Content = "{=AIInfluence_OpenBoosty_Content}Open Boosty page", RequireRestart = false, HintText = "{=AIInfluence_OpenBoosty_Hint}Open the AI Influence Boosty support page in your browser")]
	public Action OpenBoostyPage { get; set; } = delegate
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		try
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "https://boosty.to/aiinfluence",
				UseShellExecute = true
			});
		}
		catch (Exception)
		{
			InformationManager.DisplayMessage(new InformationMessage("Could not open browser. Boosty: https://boosty.to/aiinfluence", Colors.Yellow));
		}
	};

	[SettingPropertyGroup("{=AIInfluence_Group_Community}Community & Support", GroupOrder = -2)]
	[SettingPropertyButton("{=AIInfluence_OpenAfdian}Support on Afdian", -1, true, "{=AIInfluence_OpenAfdian_Button}Open Afdian", Content = "{=AIInfluence_OpenAfdian_Content}Open Afdian page", RequireRestart = false, HintText = "{=AIInfluence_OpenAfdian_Hint}Open the AI Influence Afdian support page in your browser")]
	public Action OpenAfdianPage { get; set; } = delegate
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		try
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "https://afdian.com/a/mfive",
				UseShellExecute = true
			});
		}
		catch (Exception)
		{
			InformationManager.DisplayMessage(new InformationMessage("Could not open browser. Afdian: https://afdian.com/a/mfive", Colors.Yellow));
		}
	};

	[SettingPropertyDropdown("AI Backend", RequireRestart = false, HintText = "Select the backend to use for AI responses.")]
	[SettingPropertyGroup("API Settings/Main Settings", GroupOrder = 1)]
	public Dropdown<string> AIBackend
	{
		get
		{
			return _aiBackend;
		}
		set
		{
			if (_aiBackend == null)
			{
				_aiBackend = value;
				return;
			}
			_aiBackend = value;
			this.OnSettingChanged?.Invoke("AIBackend", value);
		}
	}

	[SettingPropertyText("OpenRouter AI Model", -1, true, "", RequireRestart = false, HintText = "Enter the AI model to use for conversations (e.g., gpt-3.5-turbo, gpt-4).")]
	[SettingPropertyGroup("API Settings/OpenRouter Settings", GroupOrder = 1)]
	public string AIModel
	{
		get
		{
			return _aiModel;
		}
		set
		{
			if (_aiModel != value)
			{
				_aiModel = value;
				this.OnSettingChanged?.Invoke("AIModel", value);
			}
		}
	}

	[SettingPropertyText("OpenRouter API Key", -1, true, "", RequireRestart = false, HintText = "Enter your OpenRouter API key (only needed for OpenRouter provider).")]
	[SettingPropertyGroup("API Settings/OpenRouter Settings", GroupOrder = 1)]
	public string ApiKey
	{
		get
		{
			return _apiKey;
		}
		set
		{
			if (_apiKey != value)
			{
				_apiKey = value;
				this.OnSettingChanged?.Invoke("ApiKey", value);
			}
		}
	}

	[SettingPropertyText("DeepSeek Model", -1, true, "", RequireRestart = false, HintText = "Enter the DeepSeek model to use (e.g., deepseek-chat).")]
	[SettingPropertyGroup("API Settings/DeepSeek Settings", GroupOrder = 5)]
	public string DeepSeekModel
	{
		get
		{
			return _deepSeekModel;
		}
		set
		{
			if (_deepSeekModel != value)
			{
				_deepSeekModel = value;
				this.OnSettingChanged?.Invoke("DeepSeekModel", value);
			}
		}
	}

	[SettingPropertyText("DeepSeek API Key", -1, true, "", RequireRestart = false, HintText = "Enter your DeepSeek API key (only needed for DeepSeek provider).")]
	[SettingPropertyGroup("API Settings/DeepSeek Settings", GroupOrder = 5)]
	public string DeepSeekApiKey
	{
		get
		{
			return _deepSeekApiKey;
		}
		set
		{
			if (_deepSeekApiKey != value)
			{
				_deepSeekApiKey = value;
				this.OnSettingChanged?.Invoke("DeepSeekApiKey", value);
			}
		}
	}

	[SettingPropertyBool("Test DeepSeek Connection", Order = 0, RequireRestart = false, HintText = "Test connection to DeepSeek backend. Results will be displayed in game messages.")]
	[SettingPropertyGroup("API Settings/DeepSeek Settings", GroupOrder = 5)]
	public bool TestDeepSeekConnection
	{
		get
		{
			return false;
		}
		set
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			if (!value)
			{
				return;
			}
			try
			{
				Task.Run(async delegate
				{
					await AIClient.TestDeepSeekConnection();
				});
			}
			catch (Exception ex)
			{
				InformationManager.DisplayMessage(new InformationMessage("Error testing DeepSeek connection: " + ex.Message, ExtraColors.RedAIInfluence));
			}
		}
	}

	[SettingPropertyText("Player2 API URL", -1, true, "", RequireRestart = false, HintText = "The URL for the Player2 API. Default is http://127.0.0.1:4315")]
	[SettingPropertyGroup("API Settings/Player2 Settings", GroupOrder = 2)]
	public string Player2ApiUrl { get; set; } = "http://127.0.0.1:4315";

	[SettingPropertyBool("Test OpenRouter Connection", Order = 0, RequireRestart = false, HintText = "Test connection to OpenRouter backend. Results will be displayed in game messages.")]
	[SettingPropertyGroup("API Settings/OpenRouter Settings", GroupOrder = 1)]
	public bool TestOpenRouterConnection
	{
		get
		{
			return false;
		}
		set
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			if (!value)
			{
				return;
			}
			try
			{
				Task.Run(async delegate
				{
					await AIClient.TestOpenRouterConnection();
				});
			}
			catch (Exception ex)
			{
				InformationManager.DisplayMessage(new InformationMessage("Error testing OpenRouter connection: " + ex.Message, ExtraColors.RedAIInfluence));
			}
		}
	}

	[SettingPropertyBool("Test Player2 Connection", Order = 0, RequireRestart = false, HintText = "Test connection to Player2 backend. Results will be displayed in game messages.")]
	[SettingPropertyGroup("API Settings/Player2 Settings", GroupOrder = 2)]
	public bool TestPlayer2Connection
	{
		get
		{
			return false;
		}
		set
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			if (!value)
			{
				return;
			}
			try
			{
				Task.Run(async delegate
				{
					await AIClient.TestPlayer2Connection();
				});
			}
			catch (Exception ex)
			{
				InformationManager.DisplayMessage(new InformationMessage("Error testing Player2 connection: " + ex.Message, ExtraColors.RedAIInfluence));
			}
		}
	}

	[SettingPropertyButton("{=DownloadPlayer2}API Settings/Player2 Settings", 0, true, "{=DownloadPlayer2_Button}Open Player2 Web", Content = "{=DownloadPlayer2_Button_2}Open Player2 Web", RequireRestart = false, HintText = "{=DynamicClanSettings_CheckAIInfluence_Hint}Download Player2 (free AI API)")]
	[SettingPropertyGroup("API Settings/Player2 Settings", GroupOrder = 2)]
	public Action OpenAIInfluenceWebsite { get; set; } = delegate
	{
		try
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "https://player2.game/",
				UseShellExecute = true
			});
		}
		catch (Exception)
		{
		}
	};

	[SettingPropertyText("Ollama Model Name", -1, true, "", RequireRestart = false, HintText = "Enter the Ollama model name (e.g., llama2, mistral, codellama).")]
	[SettingPropertyGroup("API Settings/Ollama Settings", GroupOrder = 3)]
	public string OllamaModel { get; set; } = "llama2";

	[SettingPropertyText("Ollama API URL", -1, true, "", RequireRestart = false, HintText = "Enter the Ollama API URL (default: http://localhost:11434).")]
	[SettingPropertyGroup("API Settings/Ollama Settings", GroupOrder = 3)]
	public string OllamaApiUrl { get; set; } = "http://localhost:11434";

	[SettingPropertyText("KoboldCpp API URL", -1, true, "", RequireRestart = false, HintText = "Enter the KoboldCpp API URL (default: http://localhost:5001).")]
	[SettingPropertyGroup("API Settings/KoboldCpp Settings", GroupOrder = 4)]
	public string KoboldCppApiUrl { get; set; } = "http://localhost:5001";

	[SettingPropertyBool("Test Ollama Connection", Order = 0, RequireRestart = false, HintText = "Test connection to Ollama backend. Results will be displayed in game messages.")]
	[SettingPropertyGroup("API Settings/Ollama Settings", GroupOrder = 3)]
	public bool TestOllamaConnection
	{
		get
		{
			return false;
		}
		set
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			if (!value)
			{
				return;
			}
			try
			{
				Task.Run(async delegate
				{
					await AIClient.TestOllamaConnection();
				});
			}
			catch (Exception ex)
			{
				InformationManager.DisplayMessage(new InformationMessage("Error testing Ollama connection: " + ex.Message, ExtraColors.RedAIInfluence));
			}
		}
	}

	[SettingPropertyBool("Test KoboldCpp Connection", Order = 0, RequireRestart = false, HintText = "Test connection to KoboldCpp backend. Results will be displayed in game messages.")]
	[SettingPropertyGroup("API Settings/KoboldCpp Settings", GroupOrder = 4)]
	public bool TestKoboldCppConnection
	{
		get
		{
			return false;
		}
		set
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			if (!value)
			{
				return;
			}
			try
			{
				Task.Run(async delegate
				{
					await AIClient.TestKoboldCppConnection();
				});
			}
			catch (Exception ex)
			{
				InformationManager.DisplayMessage(new InformationMessage("Error testing KoboldCpp connection: " + ex.Message, ExtraColors.RedAIInfluence));
			}
		}
	}

	[SettingPropertyBool("Enable TTS (Text-to-Speech)", Order = 1, RequireRestart = false, HintText = "Enable text-to-speech for NPC dialogue responses. Voices are assigned automatically based on gender.")]
	[SettingPropertyGroup("API Settings/Player2 Settings", GroupOrder = 2)]
	public bool EnableTTS
	{
		get
		{
			return _enableTTS;
		}
		set
		{
			if (_enableTTS != value)
			{
				_enableTTS = value;
				this.OnSettingChanged?.Invoke("EnableTTS", value);
			}
		}
	}

	[SettingPropertyBool("{=AIInfluence_EnableTTSAnimations}Enable TTS Animations (Lip Sync)", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_EnableTTSAnimations_Hint}Enable body and lip-sync animations during TTS playback. When disabled, only audio is played without animations.")]
	[SettingPropertyGroup("API Settings/Player2 Settings", GroupOrder = 2)]
	public bool EnableTTSAnimations
	{
		get
		{
			return _enableTTSAnimations;
		}
		set
		{
			if (_enableTTSAnimations != value)
			{
				_enableTTSAnimations = value;
				this.OnSettingChanged?.Invoke("EnableTTSAnimations", value);
			}
		}
	}

	[SettingPropertyFloatingInteger("TTS Speed", 0.25f, 4f, "0.00", Order = 3, RequireRestart = false, HintText = "Speed of text-to-speech (0.25 to 4.0)")]
	[SettingPropertyGroup("API Settings/Player2 Settings", GroupOrder = 2)]
	public float TTSSpeed
	{
		get
		{
			return _ttsSpeed;
		}
		set
		{
			if (Math.Abs(_ttsSpeed - value) > 0.01f)
			{
				_ttsSpeed = value;
				this.OnSettingChanged?.Invoke("TTSSpeed", value);
			}
		}
	}

	[SettingPropertyFloatingInteger("TTS Volume", 0.1f, 3f, "0.00", Order = 4, RequireRestart = false, HintText = "Volume multiplier for TTS voice (0.1 = quiet, 1.0 = normal, 3.0 = very loud). The gain is applied during audio encoding.")]
	[SettingPropertyGroup("API Settings/Player2 Settings", GroupOrder = 2)]
	public float TTSVolume
	{
		get
		{
			return _ttsVolume;
		}
		set
		{
			if (Math.Abs(_ttsVolume - value) > 0.01f)
			{
				_ttsVolume = value;
				this.OnSettingChanged?.Invoke("TTSVolume", value);
			}
		}
	}

	[SettingPropertyButton("Export Available Voices", 0, true, "Export Voices", Content = "Export Available Voices", RequireRestart = false, HintText = "Export available TTS voices to a text file in the mod folder. You can use this list to manually edit NPC .json files and assign custom voices.")]
	[SettingPropertyGroup("API Settings/Player2 Settings", GroupOrder = 2)]
	public Action ExportTTSVoices { get; set; } = delegate
	{
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		try
		{
			Dictionary<string, VoiceInfo> availableVoices = Player2Client.GetAvailableVoices();
			if (availableVoices == null || availableVoices.Count == 0)
			{
				InformationManager.DisplayMessage(new InformationMessage("No voices available.", Colors.Yellow));
			}
			else
			{
				string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
				string text = Path.Combine(fullName, "tts_voices.txt");
				List<VoiceInfo> list = (from v in availableVoices.Values
					where v.Gender?.ToLower() == "male"
					orderby v.Name
					select v).ToList();
				List<VoiceInfo> list2 = (from v in availableVoices.Values
					where v.Gender?.ToLower() == "female"
					orderby v.Name
					select v).ToList();
				List<string> list3 = new List<string> { "Available TTS Voices", "====================", "", "You can manually edit NPC .json files and set 'AssignedTTSVoice' to any voice ID from this list.", "", "MALE VOICES:", "------------" };
				foreach (VoiceInfo item in list)
				{
					list3.Add(item.Id + " - " + item.Name + " (" + item.Language + ")");
				}
				list3.Add("");
				list3.Add("FEMALE VOICES:");
				list3.Add("--------------");
				foreach (VoiceInfo item2 in list2)
				{
					list3.Add(item2.Id + " - " + item2.Name + " (" + item2.Language + ")");
				}
				File.WriteAllLines(text, list3, Encoding.UTF8);
				InformationManager.DisplayMessage(new InformationMessage("TTS voices exported to: tts_voices.txt", Colors.Green));
				if (AIInfluenceBehavior.Instance != null)
				{
					AIInfluenceBehavior.Instance.LogMessage($"[TTS] Exported {list.Count} male and {list2.Count} female voices to {text}");
				}
			}
		}
		catch (Exception ex)
		{
			InformationManager.DisplayMessage(new InformationMessage("Error: " + ex.Message, Colors.Red));
		}
	};

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyBool("{=AIInfluence_PromptInternalThoughts}Enable AI Internal Thoughts (EXPERIMENTAL)", Order = -1, RequireRestart = false, HintText = "{=AIInfluence_PromptInternalThoughts_Hint}EXPERIMENTAL FEATURE: AI will think through character's motivations, emotions, and internal conflicts before responding. This creates deeper, more nuanced roleplay but may increase response time by 10-30%. The AI's internal thoughts will be logged for debugging but not shown to the player.")]
	public bool PromptEnableInternalThoughts
	{
		get
		{
			return _promptEnableInternalThoughts;
		}
		set
		{
			if (_promptEnableInternalThoughts != value)
			{
				_promptEnableInternalThoughts = value;
				this.OnSettingChanged?.Invoke("PromptEnableInternalThoughts", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyInteger("{=AIInfluence_PromptMaxHistory}Maximum Conversation History Length", 1, 200, "0 Messages", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_PromptMaxHistory_Hint}Sets how many recent conversation messages to include in the AI prompt (1–10). Lower is faster, higher is more contextual.")]
	public int PromptMaxHistory
	{
		get
		{
			return _promptMaxHistory;
		}
		set
		{
			if (_promptMaxHistory != value)
			{
				_promptMaxHistory = value;
				this.OnSettingChanged?.Invoke("PromptMaxHistory", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyBool("{=AIInfluence_PromptIncludeEvents}Include Recent Events", Order = 1, RequireRestart = false, HintText = "{=AIInfluence_PromptIncludeEvents_Hint}Includes recent events (wars, tournaments) from the last 7 days in the prompt. Disabling reduces prompt size.")]
	public bool PromptIncludeEvents
	{
		get
		{
			return _promptIncludeEvents;
		}
		set
		{
			if (_promptIncludeEvents != value)
			{
				_promptIncludeEvents = value;
				this.OnSettingChanged?.Invoke("PromptIncludeEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyFloatingInteger("{=AIInfluence_PromptSensitiveTrust}Sensitive Information Trust Threshold", 0f, 1f, "#0.0", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_PromptSensitiveTrust_Hint}Minimum trust level (0–1) to discuss sensitive topics (troops, plans). Higher makes NPCs more cautious.")]
	public float PromptSensitiveTrust
	{
		get
		{
			return _promptSensitiveTrust;
		}
		set
		{
			if (_promptSensitiveTrust != value)
			{
				_promptSensitiveTrust = value;
				this.OnSettingChanged?.Invoke("PromptSensitiveTrust", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyFloatingInteger("{=AIInfluence_PromptSecretTrust}Secret Information Trust Threshold", 0f, 1f, "#0.0", Order = 3, RequireRestart = false, HintText = "{=AIInfluence_PromptSecretTrust_Hint}Minimum trust level (0–1) to reveal secrets (weaknesses, alliances). Higher makes NPCs more secretive.")]
	public float PromptSecretTrust
	{
		get
		{
			return _promptSecretTrust;
		}
		set
		{
			if (_promptSecretTrust != value)
			{
				_promptSecretTrust = value;
				this.OnSettingChanged?.Invoke("PromptSecretTrust", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyBool("{=AIInfluence_PromptIncludeQuirks}Include Speech Quirks", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_PromptIncludeQuirks_Hint}Includes NPC speech quirks (e.g., *sighs*) in the prompt. Disabling makes responses more neutral.")]
	public bool PromptIncludeQuirks
	{
		get
		{
			return _promptIncludeQuirks;
		}
		set
		{
			if (_promptIncludeQuirks != value)
			{
				_promptIncludeQuirks = value;
				this.OnSettingChanged?.Invoke("PromptIncludeQuirks", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyBool("{=AIInfluence_PromptEnableQuests}AI creates quests", Order = 5, RequireRestart = false, HintText = "{=AIInfluence_PromptEnableQuests_Hint}If enabled, AI can create quests for the player and will see instructions for creating, completing, and failing quests. Disabling reduces prompt size.")]
	public bool PromptEnableQuests
	{
		get
		{
			return _promptEnableQuests;
		}
		set
		{
			if (_promptEnableQuests != value)
			{
				_promptEnableQuests = value;
				this.OnSettingChanged?.Invoke("PromptEnableQuests", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyFloatingInteger("{=AIInfluence_PromptQuirksFrequency}Speech Quirks Frequency", 0f, 1f, "0.0", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_PromptQuirksFrequency_Hint}How often NPCs use their speech quirks (0–1). 0 = never, 1 = always, 0.5 = half the time.")]
	public float PromptQuirksFrequency
	{
		get
		{
			return _promptQuirksFrequency;
		}
		set
		{
			if (_promptQuirksFrequency != value)
			{
				_promptQuirksFrequency = value;
				this.OnSettingChanged?.Invoke("PromptQuirksFrequency", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyBool("{=AIInfluence_PromptUseAsterisks}Use Asterisks for Actions", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_PromptUseAsterisks_Hint}Enables NPCs to use **asterisks** for describing actions and emotions in their responses. Disabling makes responses more text-only.")]
	public bool PromptUseAsterisks
	{
		get
		{
			return _promptUseAsterisks;
		}
		set
		{
			if (_promptUseAsterisks != value)
			{
				_promptUseAsterisks = value;
				this.OnSettingChanged?.Invoke("PromptUseAsterisks", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyFloatingInteger("{=AIInfluence_PromptLieStrictness}Lie Detection Strictness", 0f, 1f, "#0.0", Order = 7, RequireRestart = false, HintText = "{=AIInfluence_PromptLieStrictness_Hint}Sets how strictly NPCs detect lies about the player's identity (0–1). Higher makes them more suspicious.")]
	public float PromptLieStrictness
	{
		get
		{
			return _promptLieStrictness;
		}
		set
		{
			if (_promptLieStrictness != value)
			{
				_promptLieStrictness = value;
				this.OnSettingChanged?.Invoke("PromptLieStrictness", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyInteger("{=AIInfluence_PromptMinResponseLength}Minimum AI Response Length", 10, 300, "0 Characters", Order = 8, RequireRestart = false, HintText = "{=AIInfluence_PromptMinResponseLength_Hint}Minimum number of characters in AI responses (10–100). Shorter responses will be expanded.")]
	public int PromptMinResponseLength
	{
		get
		{
			return _promptMinResponseLength;
		}
		set
		{
			if (_promptMinResponseLength != value)
			{
				_promptMinResponseLength = value;
				this.OnSettingChanged?.Invoke("PromptMinResponseLength", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyInteger("{=AIInfluence_PromptMaxResponseLength}Maximum AI Response Length", 100, 1000, "0 Characters", Order = 9, RequireRestart = false, HintText = "{=AIInfluence_PromptMaxResponseLength_Hint}Maximum number of characters in AI responses (100–1000). Longer responses will be truncated.")]
	public int PromptMaxResponseLength
	{
		get
		{
			return _promptMaxResponseLength;
		}
		set
		{
			if (_promptMaxResponseLength != value)
			{
				_promptMaxResponseLength = value;
				this.OnSettingChanged?.Invoke("PromptMaxResponseLength", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyBool("{=AIInfluence_PromptIncludeFriends}Include NPC Friends", Order = 10, RequireRestart = false, HintText = "{=AIInfluence_PromptIncludeFriends_Hint}Includes the list of NPC friends in the prompt. Disabling reduces prompt size.")]
	public bool PromptIncludeFriends
	{
		get
		{
			return _promptIncludeFriends;
		}
		set
		{
			if (_promptIncludeFriends != value)
			{
				_promptIncludeFriends = value;
				this.OnSettingChanged?.Invoke("PromptIncludeFriends", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyInteger("{=AIInfluence_PromptMaxFriends}Maximum Number of Friends", 1, 50, "0 Friends", Order = 11, RequireRestart = false, HintText = "{=AIInfluence_PromptMaxFriends_Hint}Maximum number of NPC friends included in the prompt (1–20). Limits the size of the friend list.")]
	public int PromptMaxFriends
	{
		get
		{
			return _promptMaxFriends;
		}
		set
		{
			if (_promptMaxFriends != value)
			{
				_promptMaxFriends = value;
				this.OnSettingChanged?.Invoke("PromptMaxFriends", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyInteger("{=AIInfluence_PromptMaxEnemies}Maximum Number of Enemies", 1, 50, "0 Enemies", Order = 12, RequireRestart = false, HintText = "{=AIInfluence_PromptMaxEnemies_Hint}Maximum number of NPC enemies included in the prompt (1–50). Limits the size of the enemy list.")]
	public int PromptMaxEnemies
	{
		get
		{
			return _promptMaxEnemies;
		}
		set
		{
			if (_promptMaxEnemies != value)
			{
				_promptMaxEnemies = value;
				this.OnSettingChanged?.Invoke("PromptMaxEnemies", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyBool("{=AIInfluence_UseAdvancedTrust}Use Advanced Trust Mode", Order = 13, RequireRestart = false, HintText = "{=AIInfluence_UseAdvancedTrust_Hint}Enables advanced trust calculation (based on relations, interactions, familiarity, and lies). If disabled, trust equals relations.")]
	public bool UseAdvancedTrust
	{
		get
		{
			return _useAdvancedTrust;
		}
		set
		{
			if (_useAdvancedTrust != value)
			{
				_useAdvancedTrust = value;
				this.OnSettingChanged?.Invoke("UseAdvancedTrust", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyFloatingInteger("{=AIInfluence_InteractionTrustBonus}Interaction Trust Bonus", 0.01f, 0.03f, "#0.00", Order = 14, RequireRestart = false, HintText = "{=AIInfluence_InteractionTrustBonus_Hint}Trust gained per interaction with an NPC in advanced trust mode (0.01–0.03).")]
	public float InteractionTrustBonus
	{
		get
		{
			return _interactionTrustBonus;
		}
		set
		{
			if (_interactionTrustBonus != value)
			{
				_interactionTrustBonus = value;
				this.OnSettingChanged?.Invoke("InteractionTrustBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyFloatingInteger("{=AIInfluence_FamiliarityTrustBonus}Familiarity Trust Bonus", 0f, 0.2f, "#0.0", Order = 15, RequireRestart = false, HintText = "{=AIInfluence_FamiliarityTrustBonus_Hint}Trust bonus when the NPC knows the player's identity in advanced trust mode (0.0–0.2).")]
	public float FamiliarityTrustBonus
	{
		get
		{
			return _familiarityTrustBonus;
		}
		set
		{
			if (_familiarityTrustBonus != value)
			{
				_familiarityTrustBonus = value;
				this.OnSettingChanged?.Invoke("FamiliarityTrustBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyFloatingInteger("{=AIInfluence_MinLieTrustPenalty}Minimum Lie Trust Penalty", 0.05f, 0.1f, "#0.00", Order = 16, RequireRestart = false, HintText = "{=AIInfluence_MinLieTrustPenalty_Hint}Minimum trust penalty when a lie is detected in advanced trust mode (0.05–0.1).")]
	public float MinLieTrustPenalty
	{
		get
		{
			return _minLieTrustPenalty;
		}
		set
		{
			if (_minLieTrustPenalty != value)
			{
				_minLieTrustPenalty = value;
				this.OnSettingChanged?.Invoke("MinLieTrustPenalty", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyFloatingInteger("{=AIInfluence_MaxLieTrustPenalty}Maximum Lie Trust Penalty", 0.1f, 0.2f, "#0.00", Order = 17, RequireRestart = false, HintText = "{=AIInfluence_MaxLieTrustPenalty_Hint}Maximum trust penalty when a lie is detected in advanced trust mode (0.1–0.2).")]
	public float MaxLieTrustPenalty
	{
		get
		{
			return _maxLieTrustPenalty;
		}
		set
		{
			if (_maxLieTrustPenalty != value)
			{
				_maxLieTrustPenalty = value;
				this.OnSettingChanged?.Invoke("MaxLieTrustPenalty", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyInteger("{=AIInfluence_MinLieRelationPenalty}Minimum Lie Relation Penalty", 1, 10, "0 Points", Order = 18, RequireRestart = false, HintText = "{=AIInfluence_MinLieRelationPenalty_Hint}Minimum relation penalty when a lie is detected (1–5).")]
	public int MinLieRelationPenalty
	{
		get
		{
			return _minLieRelationPenalty;
		}
		set
		{
			if (_minLieRelationPenalty != value)
			{
				_minLieRelationPenalty = value;
				this.OnSettingChanged?.Invoke("MinLieRelationPenalty", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyInteger("{=AIInfluence_MaxLieRelationPenalty}Maximum Lie Relation Penalty", 1, 10, "0 Points", Order = 19, RequireRestart = false, HintText = "{=AIInfluence_MaxLieRelationPenalty_Hint}Maximum relation penalty when a lie is detected (5–10).")]
	public int MaxLieRelationPenalty
	{
		get
		{
			return _maxLieRelationPenalty;
		}
		set
		{
			if (_maxLieRelationPenalty != value)
			{
				_maxLieRelationPenalty = value;
				this.OnSettingChanged?.Invoke("MaxLieRelationPenalty", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyInteger("{=AIInfluence_MinPositiveRelationChange}Minimum Positive Relation Change", 1, 10, "0 Points", Order = 20, RequireRestart = false, HintText = "{=AIInfluence_MinPositiveRelationChange_Hint}Minimum relation increase when the player communicates positively (1–5).")]
	public int MinPositiveRelationChange
	{
		get
		{
			return _minPositiveRelationChange;
		}
		set
		{
			if (_minPositiveRelationChange != value)
			{
				_minPositiveRelationChange = value;
				this.OnSettingChanged?.Invoke("MinPositiveRelationChange", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyInteger("{=AIInfluence_MaxPositiveRelationChange}Maximum Positive Relation Change", 1, 10, "0 Points", Order = 21, RequireRestart = false, HintText = "{=AIInfluence_MaxPositiveRelationChange_Hint}Maximum relation increase when the player communicates positively (5–10).")]
	public int MaxPositiveRelationChange
	{
		get
		{
			return _maxPositiveRelationChange;
		}
		set
		{
			if (_maxPositiveRelationChange != value)
			{
				_maxPositiveRelationChange = value;
				this.OnSettingChanged?.Invoke("MaxPositiveRelationChange", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyInteger("{=AIInfluence_MinNegativeRelationChange}Minimum Negative Relation Change", 1, 10, "0 Points", Order = 22, RequireRestart = false, HintText = "{=AIInfluence_MinNegativeRelationChange_Hint}Minimum relation decrease when the player communicates aggressively (1–5).")]
	public int MinNegativeRelationChange
	{
		get
		{
			return _minNegativeRelationChange;
		}
		set
		{
			if (_minNegativeRelationChange != value)
			{
				_minNegativeRelationChange = value;
				this.OnSettingChanged?.Invoke("MinNegativeRelationChange", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Prompt}Prompt Settings", GroupOrder = 5)]
	[SettingPropertyInteger("{=AIInfluence_MaxNegativeRelationChange}Maximum Negative Relation Change", 1, 10, "0 Points", Order = 23, RequireRestart = false, HintText = "{=AIInfluence_MaxNegativeRelationChange_Hint}Maximum relation decrease when the player communicates aggressively (5–10).")]
	public int MaxNegativeRelationChange
	{
		get
		{
			return _maxNegativeRelationChange;
		}
		set
		{
			if (_maxNegativeRelationChange != value)
			{
				_maxNegativeRelationChange = value;
				this.OnSettingChanged?.Invoke("MaxNegativeRelationChange", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Romance}Romance Settings", GroupOrder = 6)]
	[SettingPropertyFloatingInteger("{=AIInfluence_FemaleNPCRomanceInitiative}Female NPC Romance Initiative Chance", 0f, 1f, "#0.0", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_FemaleNPCRomanceInitiative_Hint}Chance (0–1) for female NPCs to initiate romantic interactions with a male player.")]
	public float FemaleNPCRomanceInitiative
	{
		get
		{
			return _femaleNPCRomanceInitiative;
		}
		set
		{
			if (_femaleNPCRomanceInitiative != value)
			{
				_femaleNPCRomanceInitiative = value;
				this.OnSettingChanged?.Invoke("FemaleNPCRomanceInitiative", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Romance}Romance Settings", GroupOrder = 6)]
	[SettingPropertyFloatingInteger("{=AIInfluence_MaleNPCRomanceInitiative}Male NPC Romance Initiative Chance", 0f, 1f, "#0.0", Order = 1, RequireRestart = false, HintText = "{=AIInfluence_MaleNPCRomanceInitiative_Hint}Chance (0–1) for male NPCs to initiate romantic interactions with a female player.")]
	public float MaleNPCRomanceInitiative
	{
		get
		{
			return _maleNPCRomanceInitiative;
		}
		set
		{
			if (_maleNPCRomanceInitiative != value)
			{
				_maleNPCRomanceInitiative = value;
				this.OnSettingChanged?.Invoke("MaleNPCRomanceInitiative", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Romance}Romance Settings", GroupOrder = 6)]
	[SettingPropertyInteger("{=AIInfluence_MinRomanceChange}Minimum Romance Level Change", 1, 10, "0 Points", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_MinRomanceChange_Hint}Minimum change in RomanceLevel for successful romantic interactions.")]
	public int MinRomanceChange
	{
		get
		{
			return _minRomanceChange;
		}
		set
		{
			if (_minRomanceChange != value)
			{
				_minRomanceChange = value;
				this.OnSettingChanged?.Invoke("MinRomanceChange", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Romance}Romance Settings", GroupOrder = 6)]
	[SettingPropertyInteger("{=AIInfluence_MaxRomanceChange}Maximum Romance Level Change", 1, 10, "0 Points", Order = 3, RequireRestart = false, HintText = "{=AIInfluence_MaxRomanceChange_Hint}Maximum change in RomanceLevel for successful romantic interactions.")]
	public int MaxRomanceChange
	{
		get
		{
			return _maxRomanceChange;
		}
		set
		{
			if (_maxRomanceChange != value)
			{
				_maxRomanceChange = value;
				this.OnSettingChanged?.Invoke("MaxRomanceChange", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Romance}Romance Settings", GroupOrder = 6)]
	[SettingPropertyInteger("{=AIInfluence_RomanceDecayDays}Romance Decay Days", 1, 60, "0 Days", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_RomanceDecayDays_Hint}Number of days without romantic interaction before RomanceLevel starts to decay.")]
	public int RomanceDecayDays
	{
		get
		{
			return _romanceDecayDays;
		}
		set
		{
			if (_romanceDecayDays != value)
			{
				_romanceDecayDays = value;
				this.OnSettingChanged?.Invoke("RomanceDecayDays", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Romance}Romance Settings", GroupOrder = 6)]
	[SettingPropertyInteger("{=AIInfluence_MinRomanceToAcceptMarriage}Minimum Romance to Accept Marriage", 0, 100, "0", Order = 5, RequireRestart = false, HintText = "{=AIInfluence_MinRomanceToAcceptMarriage_Hint}Minimum RomanceLevel (0-100) required for NPC to accept marriage proposal from player.")]
	public int MinRomanceToAcceptMarriage
	{
		get
		{
			return _minRomanceToAcceptMarriage;
		}
		set
		{
			if (_minRomanceToAcceptMarriage != value)
			{
				_minRomanceToAcceptMarriage = value;
				this.OnSettingChanged?.Invoke("MinRomanceToAcceptMarriage", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Romance}Romance Settings", GroupOrder = 6)]
	[SettingPropertyInteger("{=AIInfluence_RomanceDecayAmount}Romance Decay Amount", 1, 100, "0 Points", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_RomanceDecayAmount_Hint}Amount by which RomanceLevel decreases per day after decay period.")]
	public int RomanceDecayAmount
	{
		get
		{
			return _romanceDecayAmount;
		}
		set
		{
			if (_romanceDecayAmount != value)
			{
				_romanceDecayAmount = value;
				this.OnSettingChanged?.Invoke("RomanceDecayAmount", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Romance}Romance Settings", GroupOrder = 6)]
	[SettingPropertyBool("{=AIInfluence_AllowRomanceWithMarried}Allow Romance with Married NPCs", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_AllowRomanceWithMarried_Hint}Allow romantic interactions with married NPCs (player or NPC can be married). Warning: This may lead to affairs and divorces.")]
	public bool AllowRomanceWithMarried
	{
		get
		{
			return _allowRomanceWithMarried;
		}
		set
		{
			if (_allowRomanceWithMarried != value)
			{
				_allowRomanceWithMarried = value;
				this.OnSettingChanged?.Invoke("AllowRomanceWithMarried", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Romance}Romance Settings", GroupOrder = 6)]
	[SettingPropertyFloatingInteger("{=AIInfluence_IntimacyConceptionChance}Intimacy Conception Chance", 0f, 1f, "#0.00", Order = 7, RequireRestart = false, HintText = "{=AIInfluence_IntimacyConceptionChance_Hint}Probability (0-1) of conception during intimate roleplay interactions. Default: 0.15 (15%).")]
	public float IntimacyConceptionChance
	{
		get
		{
			return _intimacyConceptionChance;
		}
		set
		{
			if (_intimacyConceptionChance != value)
			{
				_intimacyConceptionChance = value;
				this.OnSettingChanged?.Invoke("IntimacyConceptionChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Romance}Romance Settings", GroupOrder = 6)]
	[SettingPropertyFloatingInteger("{=AIInfluence_IntimacyRomanceIncrease}Intimacy Romance Level Increase", 0f, 50f, "#0.0", Order = 8, RequireRestart = false, HintText = "{=AIInfluence_IntimacyRomanceIncrease_Hint}Amount by which RomanceLevel increases after intimate interaction. Default: 15.0 points. Maximum RomanceLevel is 100.")]
	public float IntimacyRomanceIncrease
	{
		get
		{
			return _intimacyRomanceIncrease;
		}
		set
		{
			if (_intimacyRomanceIncrease != value)
			{
				_intimacyRomanceIncrease = value;
				this.OnSettingChanged?.Invoke("IntimacyRomanceIncrease", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyBool("{=AIInfluence_CompanionAutoRecognize}Companions Auto-Recognize Player", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_CompanionAutoRecognize_Hint}NPCs automatically recognize you if they are your companions.")]
	public bool CompanionAutoRecognize
	{
		get
		{
			return _companionAutoRecognize;
		}
		set
		{
			if (_companionAutoRecognize != value)
			{
				_companionAutoRecognize = value;
				this.OnSettingChanged?.Invoke("CompanionAutoRecognize", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyBool("{=AIInfluence_KingdomAutoRecognize}Kingdom Members Auto-Recognize Player", Order = 1, RequireRestart = false, HintText = "{=AIInfluence_KingdomAutoRecognize_Hint}All NPCs in your kingdom automatically recognize you if you are the kingdom leader.")]
	public bool KingdomAutoRecognize
	{
		get
		{
			return _kingdomAutoRecognize;
		}
		set
		{
			if (_kingdomAutoRecognize != value)
			{
				_kingdomAutoRecognize = value;
				this.OnSettingChanged?.Invoke("KingdomAutoRecognize", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyBool("{=AIInfluence_ClanTierAutoRecognize}Clan Tier Auto-Recognition", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_ClanTierAutoRecognize_Hint}NPCs have a chance to recognize you based on your clan tier level.")]
	public bool ClanTierAutoRecognize
	{
		get
		{
			return _clanTierAutoRecognize;
		}
		set
		{
			if (_clanTierAutoRecognize != value)
			{
				_clanTierAutoRecognize = value;
				this.OnSettingChanged?.Invoke("ClanTierAutoRecognize", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyInteger("{=AIInfluence_ClanTierThreshold}Clan Tier Recognition Threshold", 1, 6, "0 Tier", Order = 3, RequireRestart = false, HintText = "{=AIInfluence_ClanTierThreshold_Hint}Minimum clan tier level for NPCs to have a chance to recognize you. Default: 3.")]
	public int ClanTierThreshold
	{
		get
		{
			return _clanTierThreshold;
		}
		set
		{
			if (_clanTierThreshold != value)
			{
				_clanTierThreshold = value;
				this.OnSettingChanged?.Invoke("ClanTierThreshold", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyFloatingInteger("{=AIInfluence_ClanTierRecognitionChance}Clan Tier Recognition Chance", 1f, 100f, "#0", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_ClanTierRecognitionChance_Hint}Chance percentage for NPCs to recognize you based on clan tier. Default: 25%.")]
	public float ClanTierRecognitionChance
	{
		get
		{
			return _clanTierRecognitionChance;
		}
		set
		{
			if (_clanTierRecognitionChance != value)
			{
				_clanTierRecognitionChance = value;
				this.OnSettingChanged?.Invoke("ClanTierRecognitionChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyBool("{=AIInfluence_RealisticInfoSpread}Realistic Information Spread", Order = 5, RequireRestart = false, HintText = "{=AIInfluence_RealisticInfoSpread_Hint}Enable realistic information spreading: NPCs only learn about events based on distance, social status, and relationships. Disable for classic behavior where all NPCs know everything.")]
	public bool RealisticInformationSpread
	{
		get
		{
			return _realisticInformationSpread;
		}
		set
		{
			if (_realisticInformationSpread != value)
			{
				_realisticInformationSpread = value;
				this.OnSettingChanged?.Invoke("RealisticInformationSpread", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyFloatingInteger("{=AIInfluence_LocalNewsDistance}Local News Distance", 5f, 50f, "0 Units", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_LocalNewsDistance_Hint}Maximum distance for local events (tournaments, marriages, deaths). Default: 15 units.")]
	public float LocalNewsDistance
	{
		get
		{
			return _localNewsDistance;
		}
		set
		{
			if (_localNewsDistance != value)
			{
				_localNewsDistance = value;
				this.OnSettingChanged?.Invoke("LocalNewsDistance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyFloatingInteger("{=AIInfluence_RegionalNewsDistance}Regional News Distance", 20f, 150f, "0 Units", Order = 7, RequireRestart = false, HintText = "{=AIInfluence_RegionalNewsDistance_Hint}Maximum distance for regional events (wars, battles, settlements). Default: 50 units.")]
	public float RegionalNewsDistance
	{
		get
		{
			return _regionalNewsDistance;
		}
		set
		{
			if (_regionalNewsDistance != value)
			{
				_regionalNewsDistance = value;
				this.OnSettingChanged?.Invoke("RegionalNewsDistance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyFloatingInteger("{=AIInfluence_KingdomNewsDistance}Kingdom News Distance", 50f, 300f, "0 Units", Order = 8, RequireRestart = false, HintText = "{=AIInfluence_KingdomNewsDistance_Hint}Maximum distance for kingdom events (laws, political decisions). Default: 150 units.")]
	public float KingdomNewsDistance
	{
		get
		{
			return _kingdomNewsDistance;
		}
		set
		{
			if (_kingdomNewsDistance != value)
			{
				_kingdomNewsDistance = value;
				this.OnSettingChanged?.Invoke("KingdomNewsDistance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyFloatingInteger("{=AIInfluence_NobleDistanceMultiplier}Noble Distance Multiplier", 1f, 3f, "0.0x", Order = 9, RequireRestart = false, HintText = "{=AIInfluence_NobleDistanceMultiplier_Hint}Distance multiplier for nobles (medium access level). Default: 1.5x.")]
	public float NobleDistanceMultiplier
	{
		get
		{
			return _nobleDistanceMultiplier;
		}
		set
		{
			if (_nobleDistanceMultiplier != value)
			{
				_nobleDistanceMultiplier = value;
				this.OnSettingChanged?.Invoke("NobleDistanceMultiplier", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyFloatingInteger("{=AIInfluence_RoyalDistanceMultiplier}Royal Distance Multiplier", 1f, 5f, "0.0x", Order = 10, RequireRestart = false, HintText = "{=AIInfluence_RoyalDistanceMultiplier_Hint}Distance multiplier for kings and clan leaders (high access level). Default: 2.0x.")]
	public float RoyalDistanceMultiplier
	{
		get
		{
			return _royalDistanceMultiplier;
		}
		set
		{
			if (_royalDistanceMultiplier != value)
			{
				_royalDistanceMultiplier = value;
				this.OnSettingChanged?.Invoke("RoyalDistanceMultiplier", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyInteger("{=AIInfluence_RelationshipThreshold}Relationship Threshold", 5, 50, "0 Points", Order = 11, RequireRestart = false, HintText = "{=AIInfluence_RelationshipThreshold_Hint}Minimum relationship level for NPCs to learn about personal events regardless of distance. Default: 20 points.")]
	public int RelationshipThreshold
	{
		get
		{
			return _relationshipThreshold;
		}
		set
		{
			if (_relationshipThreshold != value)
			{
				_relationshipThreshold = value;
				this.OnSettingChanged?.Invoke("RelationshipThreshold", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyBool("{=AIInfluence_EnableSocialFiltering}Enable Social Filtering", Order = 12, RequireRestart = false, HintText = "{=AIInfluence_EnableSocialFiltering_Hint}Enable social class filtering: commoners won't learn about political events, nobles get priority access to information.")]
	public bool EnableSocialFiltering
	{
		get
		{
			return _enableSocialFiltering;
		}
		set
		{
			if (_enableSocialFiltering != value)
			{
				_enableSocialFiltering = value;
				this.OnSettingChanged?.Invoke("EnableSocialFiltering", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyBool("{=AIInfluence_EnableRelationshipOverride}Enable Relationship Override", Order = 13, RequireRestart = false, HintText = "{=AIInfluence_EnableRelationshipOverride_Hint}Allow close friends/enemies to learn about events regardless of distance and social status.")]
	public bool EnableRelationshipOverride
	{
		get
		{
			return _enableRelationshipOverride;
		}
		set
		{
			if (_enableRelationshipOverride != value)
			{
				_enableRelationshipOverride = value;
				this.OnSettingChanged?.Invoke("EnableRelationshipOverride", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyBool("{=AIInfluence_EnableFactionOverride}Enable Faction Override", Order = 14, RequireRestart = false, HintText = "{=AIInfluence_EnableFactionOverride_Hint}Members of the same faction always know about faction-related events (wars, battles).")]
	public bool EnableFactionOverride
	{
		get
		{
			return _enableFactionOverride;
		}
		set
		{
			if (_enableFactionOverride != value)
			{
				_enableFactionOverride = value;
				this.OnSettingChanged?.Invoke("EnableFactionOverride", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyBool("{=AIInfluence_EnableDetailedLogging}Enable Detailed Info Logging", Order = 15, RequireRestart = false, HintText = "{=AIInfluence_EnableDetailedLogging_Hint}Log detailed information about who learns what events and why. Useful for debugging information spread.")]
	public bool EnableDetailedInfoLogging
	{
		get
		{
			return _enableDetailedInfoLogging;
		}
		set
		{
			if (_enableDetailedInfoLogging != value)
			{
				_enableDetailedInfoLogging = value;
				this.OnSettingChanged?.Invoke("EnableDetailedInfoLogging", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyInteger("{=AIInfluence_NewsDelayHours}News Delay Hours per Distance", 0, 24, "0 Hours", Order = 16, RequireRestart = false, HintText = "{=AIInfluence_NewsDelayHours_Hint}Hours of delay per unit of distance for news to travel. Higher values make news spread more slowly. Default: 2 hours per distance unit.")]
	public int NewsDelayHoursPerDistance
	{
		get
		{
			return _newsDelayHoursPerDistance;
		}
		set
		{
			if (_newsDelayHoursPerDistance != value)
			{
				_newsDelayHoursPerDistance = value;
				this.OnSettingChanged?.Invoke("NewsDelayHoursPerDistance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyInteger("{=AIInfluence_RecentEventsLifetimeDays}Recent Events Lifetime (Days)", 7, 90, "0 Days", Order = 17, RequireRestart = false, HintText = "{=AIInfluence_RecentEventsLifetimeDays_Hint}How many days to keep events in NPC memory before automatic cleanup. Lower values improve performance. Default: 30 days.")]
	public int RecentEventsLifetimeDays
	{
		get
		{
			return _recentEventsLifetimeDays;
		}
		set
		{
			if (_recentEventsLifetimeDays != value)
			{
				_recentEventsLifetimeDays = value;
				this.OnSettingChanged?.Invoke("RecentEventsLifetimeDays", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_InfoLogic}Information Logic", GroupOrder = 7)]
	[SettingPropertyInteger("{=AIInfluence_MaxRecentEvents}Max Recent Events Per NPC", 20, 100, "0 Events", Order = 18, RequireRestart = false, HintText = "{=AIInfluence_MaxRecentEvents_Hint}Maximum number of recent events stored per NPC. Older events are removed. Lower values improve performance. Default: 50 events.")]
	public int MaxRecentEvents
	{
		get
		{
			return _maxRecentEvents;
		}
		set
		{
			if (_maxRecentEvents != value)
			{
				_maxRecentEvents = value;
				this.OnSettingChanged?.Invoke("MaxRecentEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_DynamicEventsInternalThoughts}Enable AI Internal Thoughts (EXPERIMENTAL)", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_DynamicEventsInternalThoughts_Hint}EXPERIMENTAL FEATURE: If enabled, AI will generate a hidden internal thought process before creating events. This improves logic and consistency but uses more tokens.")]
	public bool EnableDynamicEventsInternalThoughts
	{
		get
		{
			return _enableDynamicEventsInternalThoughts;
		}
		set
		{
			if (_enableDynamicEventsInternalThoughts != value)
			{
				_enableDynamicEventsInternalThoughts = value;
				this.OnSettingChanged?.Invoke("EnableDynamicEventsInternalThoughts", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_EnableDynamicEvents}Enable Dynamic Events", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_EnableDynamicEvents_Hint}Enables AI-generated dynamic world events that NPCs know about and can discuss.")]
	public bool EnableDynamicEvents
	{
		get
		{
			return _enableDynamicEvents;
		}
		set
		{
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			if (_enableDynamicEvents != value)
			{
				_enableDynamicEvents = value;
				if (!value && _enableDiplomacy && !CanEnableDiplomacy())
				{
					_enableDiplomacy = false;
					this.OnSettingChanged?.Invoke("EnableDiplomacy", false);
					TextObject val = new TextObject("{=AIInfluence_DiplomacyAutoDisabled}Diplomacy automatically disabled: Dynamic Events are required.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Yellow));
				}
				this.OnSettingChanged?.Invoke("EnableDynamicEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_DynamicEventsDialogueOnly}Dialogue Analysis Only (No Global Events)", Order = 1, RequireRestart = false, HintText = "{=AIInfluence_DynamicEventsDialogueOnly_Hint}When enabled, dynamic events will only analyze player-NPC dialogues and update NPC knowledge. No global events will be generated and no map notifications will be shown. Useful when you want dialogue analysis without diplomacy system.")]
	public bool DynamicEventsDialogueOnly
	{
		get
		{
			return _dynamicEventsDialogueOnly;
		}
		set
		{
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			if (_dynamicEventsDialogueOnly != value)
			{
				_dynamicEventsDialogueOnly = value;
				if (value && _enableDiplomacy && !CanEnableDiplomacy())
				{
					_enableDiplomacy = false;
					this.OnSettingChanged?.Invoke("EnableDiplomacy", false);
					TextObject val = new TextObject("{=AIInfluence_DiplomacyAutoDisabledDialogue}Diplomacy automatically disabled: does not work in 'Dialogue Only' mode.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Yellow));
				}
				this.OnSettingChanged?.Invoke("DynamicEventsDialogueOnly", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyDropdown("{=AIInfluence_DynamicEventsAIBackend}AI Backend for Events", RequireRestart = false, Order = 2, HintText = "{=AIInfluence_DynamicEventsAIBackend_Hint}Select which AI backend to use for dynamic event generation. Can be different from dialogue AI.")]
	public Dropdown<string> DynamicEventsAIBackend { get; set; } = new Dropdown<string>((IEnumerable<string>)new List<string> { "OpenRouter", "DeepSeek", "Player2", "Ollama", "KoboldCpp" }, 2);

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyInteger("{=AIInfluence_MaxSimultaneousDynamicEvents}Max Simultaneous Events", 1, 3, "0 Events", Order = 3, RequireRestart = false, HintText = "{=AIInfluence_MaxSimultaneousDynamicEvents_Hint}Maximum number of active dynamic events allowed at the same time. Default: 1.")]
	public int MaxSimultaneousDynamicEvents
	{
		get
		{
			return _maxSimultaneousDynamicEvents;
		}
		set
		{
			if (_maxSimultaneousDynamicEvents != value)
			{
				_maxSimultaneousDynamicEvents = value;
				this.OnSettingChanged?.Invoke("MaxSimultaneousDynamicEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyInteger("{=AIInfluence_DynamicEventsInterval}Event Generation Interval (Days)", 1, 100, "0 Days", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_DynamicEventsInterval_Hint}How often AI generates new events (in game days). Default: 14 days.")]
	public int DynamicEventsInterval
	{
		get
		{
			return _dynamicEventsInterval;
		}
		set
		{
			if (_dynamicEventsInterval != value)
			{
				_dynamicEventsInterval = value;
				this.OnSettingChanged?.Invoke("DynamicEventsInterval", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyInteger("{=AIInfluence_DynamicEventsMinLength}Minimum Event Description Length", 50, 1000, "0 Characters", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_DynamicEventsMinLength_Hint}Minimum characters for event descriptions. Default: 50.")]
	public int DynamicEventsMinLength
	{
		get
		{
			return _dynamicEventsMinLength;
		}
		set
		{
			if (_dynamicEventsMinLength != value)
			{
				_dynamicEventsMinLength = value;
				this.OnSettingChanged?.Invoke("DynamicEventsMinLength", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyInteger("{=AIInfluence_DynamicEventsMaxLength}Maximum Event Description Length", 100, 1000, "0 Characters", Order = 5, RequireRestart = false, HintText = "{=AIInfluence_DynamicEventsMaxLength_Hint}Maximum characters for event descriptions. Default: 500.")]
	public int DynamicEventsMaxLength
	{
		get
		{
			return _dynamicEventsMaxLength;
		}
		set
		{
			if (_dynamicEventsMaxLength != value)
			{
				_dynamicEventsMaxLength = value;
				this.OnSettingChanged?.Invoke("DynamicEventsMaxLength", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyInteger("{=AIInfluence_DynamicEventsLifespan}Event Lifespan (Days)", 1, 300, "0 Days", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_DynamicEventsLifespan_Hint}How long events exist before expiring. Default: 100 days.")]
	public int DynamicEventsLifespan
	{
		get
		{
			return _dynamicEventsLifespan;
		}
		set
		{
			if (_dynamicEventsLifespan != value)
			{
				_dynamicEventsLifespan = value;
				this.OnSettingChanged?.Invoke("DynamicEventsLifespan", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_EnableMilitaryEvents}Enable Military Events", Order = 7, RequireRestart = false, HintText = "{=AIInfluence_EnableMilitaryEvents_Hint}Enable generation of military-related events (battles, wars, sieges).")]
	public bool EnableMilitaryEvents
	{
		get
		{
			return _enableMilitaryEvents;
		}
		set
		{
			if (_enableMilitaryEvents != value)
			{
				_enableMilitaryEvents = value;
				this.OnSettingChanged?.Invoke("EnableMilitaryEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyInteger("{=AIInfluence_MilitaryEventsChance}Military Events Chance (%)", 0, 100, "0", Order = 8, RequireRestart = false, HintText = "{=AIInfluence_MilitaryEventsChance_Hint}Chance for military events to be generated when enabled. Default: 20%.")]
	public int MilitaryEventsChance
	{
		get
		{
			return _militaryEventsChance;
		}
		set
		{
			if (_militaryEventsChance != value)
			{
				_militaryEventsChance = value;
				this.OnSettingChanged?.Invoke("MilitaryEventsChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_EnablePoliticalEvents}Enable Political Events", Order = 9, RequireRestart = false, HintText = "{=AIInfluence_EnablePoliticalEvents_Hint}Enable generation of political events (diplomacy, succession, intrigues).")]
	public bool EnablePoliticalEvents
	{
		get
		{
			return _enablePoliticalEvents;
		}
		set
		{
			if (_enablePoliticalEvents != value)
			{
				_enablePoliticalEvents = value;
				this.OnSettingChanged?.Invoke("EnablePoliticalEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyInteger("{=AIInfluence_PoliticalEventsChance}Political Events Chance (%)", 0, 100, "0", Order = 10, RequireRestart = false, HintText = "{=AIInfluence_PoliticalEventsChance_Hint}Chance for political events to be generated when enabled. Default: 20%.")]
	public int PoliticalEventsChance
	{
		get
		{
			return _politicalEventsChance;
		}
		set
		{
			if (_politicalEventsChance != value)
			{
				_politicalEventsChance = value;
				this.OnSettingChanged?.Invoke("PoliticalEventsChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_EnableEconomicEvents}Enable Economic Events", Order = 11, RequireRestart = false, HintText = "{=AIInfluence_EnableEconomicEvents_Hint}Enable generation of economic events (trade, resources, prosperity).")]
	public bool EnableEconomicEvents
	{
		get
		{
			return _enableEconomicEvents;
		}
		set
		{
			if (_enableEconomicEvents != value)
			{
				_enableEconomicEvents = value;
				this.OnSettingChanged?.Invoke("EnableEconomicEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyInteger("{=AIInfluence_EconomicEventsChance}Economic Events Chance (%)", 0, 100, "0", Order = 12, RequireRestart = false, HintText = "{=AIInfluence_EconomicEventsChance_Hint}Chance for economic events to be generated when enabled. Default: 20%.")]
	public int EconomicEventsChance
	{
		get
		{
			return _economicEventsChance;
		}
		set
		{
			if (_economicEventsChance != value)
			{
				_economicEventsChance = value;
				this.OnSettingChanged?.Invoke("EconomicEventsChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_EnableSocialEvents}Enable Social Events", Order = 13, RequireRestart = false, HintText = "{=AIInfluence_EnableSocialEvents_Hint}Enable generation of social events (marriages, festivals, cultural events).")]
	public bool EnableSocialEvents
	{
		get
		{
			return _enableSocialEvents;
		}
		set
		{
			if (_enableSocialEvents != value)
			{
				_enableSocialEvents = value;
				this.OnSettingChanged?.Invoke("EnableSocialEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyInteger("{=AIInfluence_SocialEventsChance}Social Events Chance (%)", 0, 100, "0", Order = 14, RequireRestart = false, HintText = "{=AIInfluence_SocialEventsChance_Hint}Chance for social events to be generated when enabled. Default: 20%.")]
	public int SocialEventsChance
	{
		get
		{
			return _socialEventsChance;
		}
		set
		{
			if (_socialEventsChance != value)
			{
				_socialEventsChance = value;
				this.OnSettingChanged?.Invoke("SocialEventsChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_EnableMysteriousEvents}Enable Mysterious Events", Order = 15, RequireRestart = false, HintText = "{=AIInfluence_EnableMysteriousEvents_Hint}Enable generation of mysterious events (supernatural, unexplained phenomena).")]
	public bool EnableMysteriousEvents
	{
		get
		{
			return _enableMysteriousEvents;
		}
		set
		{
			if (_enableMysteriousEvents != value)
			{
				_enableMysteriousEvents = value;
				this.OnSettingChanged?.Invoke("EnableMysteriousEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyInteger("{=AIInfluence_MysteriousEventsChance}Mysterious Events Chance (%)", 0, 100, "0", Order = 16, RequireRestart = false, HintText = "{=AIInfluence_MysteriousEventsChance_Hint}Chance for mysterious events to be generated when enabled. Default: 20%.")]
	public int MysteriousEventsChance
	{
		get
		{
			return _mysteriousEventsChance;
		}
		set
		{
			if (_mysteriousEventsChance != value)
			{
				_mysteriousEventsChance = value;
				this.OnSettingChanged?.Invoke("MysteriousEventsChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_EnableDiseaseOutbreakEvents}Enable Disease Outbreak Events", Order = 17, RequireRestart = false, HintText = "{=AIInfluence_EnableDiseaseOutbreakEvents_Hint}Enable generation of disease outbreak events (epidemics, plagues, infections).")]
	public bool EnableDiseaseOutbreakEvents
	{
		get
		{
			return _enableDiseaseOutbreakEvents;
		}
		set
		{
			if (_enableDiseaseOutbreakEvents != value)
			{
				_enableDiseaseOutbreakEvents = value;
				this.OnSettingChanged?.Invoke("EnableDiseaseOutbreakEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyInteger("{=AIInfluence_DiseaseOutbreakEventsChance}Disease Outbreak Events Chance (%)", 0, 100, "0", Order = 18, RequireRestart = false, HintText = "{=AIInfluence_DiseaseOutbreakEventsChance_Hint}Chance for disease outbreak events to be generated when enabled. Default: 10%.")]
	public int DiseaseOutbreakEventsChance
	{
		get
		{
			return _diseaseOutbreakEventsChance;
		}
		set
		{
			if (_diseaseOutbreakEventsChance != value)
			{
				_diseaseOutbreakEventsChance = value;
				this.OnSettingChanged?.Invoke("DiseaseOutbreakEventsChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_ForceGenerateEvent}Force Generate Event Now", Order = 19, RequireRestart = false, HintText = "{=AIInfluence_ForceGenerateEvent_Hint}Manually trigger event generation immediately (for testing).")]
	public bool ForceGenerateEvent
	{
		get
		{
			return false;
		}
		set
		{
			if (value)
			{
				DateTime now = DateTime.Now;
				if (!((now - _lastForceGenerateEventTime).TotalSeconds < 2.0))
				{
					_lastForceGenerateEventTime = now;
					this.OnSettingChanged?.Invoke("ForceGenerateEvent", value);
				}
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_ViewActiveEvents}View Active Events", Order = 20, RequireRestart = false, HintText = "{=AIInfluence_ViewActiveEvents_Hint}Display all currently active dynamic events in game log")]
	public bool ViewActiveEvents
	{
		get
		{
			return false;
		}
		set
		{
			if (value)
			{
				this.OnSettingChanged?.Invoke("ViewActiveEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_DynamicEvents}Dynamic Events", GroupOrder = 8)]
	[SettingPropertyBool("{=AIInfluence_ClearAllDynamicEvents}Clear All Dynamic Events", Order = 21, RequireRestart = false, HintText = "{=AIInfluence_ClearAllDynamicEvents_Hint}Completely clears all dynamic events and diplomacy systems: removes all active events, scheduled statements, analyses, event queues, and clears related data from NPCs. This action cannot be undone!")]
	public bool ClearAllDynamicEvents
	{
		get
		{
			return false;
		}
		set
		{
			if (value)
			{
				this.OnSettingChanged?.Invoke("ClearAllDynamicEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_ProsperityDeltaMin}Prosperity Delta Min", -500, 0, "0", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_ProsperityDeltaMin_Hint}Minimum prosperity change value that AI can use in economic effects. Default: -100.")]
	public int ProsperityDeltaMin
	{
		get
		{
			return _prosperityDeltaMin;
		}
		set
		{
			if (_prosperityDeltaMin != value)
			{
				if (value > _prosperityDeltaMax)
				{
					_prosperityDeltaMin = _prosperityDeltaMax;
				}
				else
				{
					_prosperityDeltaMin = value;
				}
				this.OnSettingChanged?.Invoke("ProsperityDeltaMin", _prosperityDeltaMin);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_ProsperityDeltaMax}Prosperity Delta Max", 0, 500, "0", Order = 1, RequireRestart = false, HintText = "{=AIInfluence_ProsperityDeltaMax_Hint}Maximum prosperity change value that AI can use in economic effects. Default: 100.")]
	public int ProsperityDeltaMax
	{
		get
		{
			return _prosperityDeltaMax;
		}
		set
		{
			if (_prosperityDeltaMax != value)
			{
				if (value < _prosperityDeltaMin)
				{
					_prosperityDeltaMax = _prosperityDeltaMin;
				}
				else
				{
					_prosperityDeltaMax = value;
				}
				this.OnSettingChanged?.Invoke("ProsperityDeltaMax", _prosperityDeltaMax);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_ProsperityDeltaPerDayMin}Prosperity Delta Per Day Min", -50, 0, "0", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_ProsperityDeltaPerDayMin_Hint}Minimum daily prosperity change value that AI can use in economic effects. Default: -10.")]
	public int ProsperityDeltaPerDayMin
	{
		get
		{
			return _prosperityDeltaPerDayMin;
		}
		set
		{
			if (_prosperityDeltaPerDayMin != value)
			{
				if (value > _prosperityDeltaPerDayMax)
				{
					_prosperityDeltaPerDayMin = _prosperityDeltaPerDayMax;
				}
				else
				{
					_prosperityDeltaPerDayMin = value;
				}
				this.OnSettingChanged?.Invoke("ProsperityDeltaPerDayMin", _prosperityDeltaPerDayMin);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_ProsperityDeltaPerDayMax}Prosperity Delta Per Day Max", 0, 50, "0", Order = 3, RequireRestart = false, HintText = "{=AIInfluence_ProsperityDeltaPerDayMax_Hint}Maximum daily prosperity change value that AI can use in economic effects. Default: 10.")]
	public int ProsperityDeltaPerDayMax
	{
		get
		{
			return _prosperityDeltaPerDayMax;
		}
		set
		{
			if (_prosperityDeltaPerDayMax != value)
			{
				if (value < _prosperityDeltaPerDayMin)
				{
					_prosperityDeltaPerDayMax = _prosperityDeltaPerDayMin;
				}
				else
				{
					_prosperityDeltaPerDayMax = value;
				}
				this.OnSettingChanged?.Invoke("ProsperityDeltaPerDayMax", _prosperityDeltaPerDayMax);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_FoodDeltaMin}Food Delta Min", -500, 0, "0", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_FoodDeltaMin_Hint}Minimum food change value that AI can use in economic effects. Default: -100.")]
	public int FoodDeltaMin
	{
		get
		{
			return _foodDeltaMin;
		}
		set
		{
			if (_foodDeltaMin != value)
			{
				if (value > _foodDeltaMax)
				{
					_foodDeltaMin = _foodDeltaMax;
				}
				else
				{
					_foodDeltaMin = value;
				}
				this.OnSettingChanged?.Invoke("FoodDeltaMin", _foodDeltaMin);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_FoodDeltaMax}Food Delta Max", 0, 500, "0", Order = 5, RequireRestart = false, HintText = "{=AIInfluence_FoodDeltaMax_Hint}Maximum food change value that AI can use in economic effects. Default: 100.")]
	public int FoodDeltaMax
	{
		get
		{
			return _foodDeltaMax;
		}
		set
		{
			if (_foodDeltaMax != value)
			{
				if (value < _foodDeltaMin)
				{
					_foodDeltaMax = _foodDeltaMin;
				}
				else
				{
					_foodDeltaMax = value;
				}
				this.OnSettingChanged?.Invoke("FoodDeltaMax", _foodDeltaMax);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_FoodDeltaPerDayMin}Food Delta Per Day Min", -50, 0, "0", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_FoodDeltaPerDayMin_Hint}Minimum daily food change value that AI can use in economic effects. Default: -10.")]
	public int FoodDeltaPerDayMin
	{
		get
		{
			return _foodDeltaPerDayMin;
		}
		set
		{
			if (_foodDeltaPerDayMin != value)
			{
				if (value > _foodDeltaPerDayMax)
				{
					_foodDeltaPerDayMin = _foodDeltaPerDayMax;
				}
				else
				{
					_foodDeltaPerDayMin = value;
				}
				this.OnSettingChanged?.Invoke("FoodDeltaPerDayMin", _foodDeltaPerDayMin);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_FoodDeltaPerDayMax}Food Delta Per Day Max", 0, 50, "0", Order = 7, RequireRestart = false, HintText = "{=AIInfluence_FoodDeltaPerDayMax_Hint}Maximum daily food change value that AI can use in economic effects. Default: 10.")]
	public int FoodDeltaPerDayMax
	{
		get
		{
			return _foodDeltaPerDayMax;
		}
		set
		{
			if (_foodDeltaPerDayMax != value)
			{
				if (value < _foodDeltaPerDayMin)
				{
					_foodDeltaPerDayMax = _foodDeltaPerDayMin;
				}
				else
				{
					_foodDeltaPerDayMax = value;
				}
				this.OnSettingChanged?.Invoke("FoodDeltaPerDayMax", _foodDeltaPerDayMax);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_SecurityDeltaMin}Security Delta Min", -20, 0, "0", Order = 8, RequireRestart = false, HintText = "{=AIInfluence_SecurityDeltaMin_Hint}Minimum security change value that AI can use in economic effects. Default: -5.")]
	public int SecurityDeltaMin
	{
		get
		{
			return _securityDeltaMin;
		}
		set
		{
			if (_securityDeltaMin != value)
			{
				if (value > _securityDeltaMax)
				{
					_securityDeltaMin = _securityDeltaMax;
				}
				else
				{
					_securityDeltaMin = value;
				}
				this.OnSettingChanged?.Invoke("SecurityDeltaMin", _securityDeltaMin);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_SecurityDeltaMax}Security Delta Max", 0, 20, "0", Order = 9, RequireRestart = false, HintText = "{=AIInfluence_SecurityDeltaMax_Hint}Maximum security change value that AI can use in economic effects. Default: 5.")]
	public int SecurityDeltaMax
	{
		get
		{
			return _securityDeltaMax;
		}
		set
		{
			if (_securityDeltaMax != value)
			{
				if (value < _securityDeltaMin)
				{
					_securityDeltaMax = _securityDeltaMin;
				}
				else
				{
					_securityDeltaMax = value;
				}
				this.OnSettingChanged?.Invoke("SecurityDeltaMax", _securityDeltaMax);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_SecurityDeltaPerDayMin}Security Delta Per Day Min", -5, 0, "0", Order = 10, RequireRestart = false, HintText = "{=AIInfluence_SecurityDeltaPerDayMin_Hint}Minimum daily security change value that AI can use in economic effects. Values should be small (0.2, 0.5) since security is 0-100. Default: -1.")]
	public int SecurityDeltaPerDayMin
	{
		get
		{
			return _securityDeltaPerDayMin;
		}
		set
		{
			if (_securityDeltaPerDayMin != value)
			{
				if (value > _securityDeltaPerDayMax)
				{
					_securityDeltaPerDayMin = _securityDeltaPerDayMax;
				}
				else
				{
					_securityDeltaPerDayMin = value;
				}
				this.OnSettingChanged?.Invoke("SecurityDeltaPerDayMin", _securityDeltaPerDayMin);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_SecurityDeltaPerDayMax}Security Delta Per Day Max", 0, 5, "0", Order = 11, RequireRestart = false, HintText = "{=AIInfluence_SecurityDeltaPerDayMax_Hint}Maximum daily security change value that AI can use in economic effects. Values should be small (0.2, 0.5) since security is 0-100. Default: 1.")]
	public int SecurityDeltaPerDayMax
	{
		get
		{
			return _securityDeltaPerDayMax;
		}
		set
		{
			if (_securityDeltaPerDayMax != value)
			{
				if (value < _securityDeltaPerDayMin)
				{
					_securityDeltaPerDayMax = _securityDeltaPerDayMin;
				}
				else
				{
					_securityDeltaPerDayMax = value;
				}
				this.OnSettingChanged?.Invoke("SecurityDeltaPerDayMax", _securityDeltaPerDayMax);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_LoyaltyDeltaMin}Loyalty Delta Min", -20, 0, "0", Order = 12, RequireRestart = false, HintText = "{=AIInfluence_LoyaltyDeltaMin_Hint}Minimum loyalty change value that AI can use in economic effects. Default: -5.")]
	public int LoyaltyDeltaMin
	{
		get
		{
			return _loyaltyDeltaMin;
		}
		set
		{
			if (_loyaltyDeltaMin != value)
			{
				if (value > _loyaltyDeltaMax)
				{
					_loyaltyDeltaMin = _loyaltyDeltaMax;
				}
				else
				{
					_loyaltyDeltaMin = value;
				}
				this.OnSettingChanged?.Invoke("LoyaltyDeltaMin", _loyaltyDeltaMin);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_LoyaltyDeltaMax}Loyalty Delta Max", 0, 20, "0", Order = 13, RequireRestart = false, HintText = "{=AIInfluence_LoyaltyDeltaMax_Hint}Maximum loyalty change value that AI can use in economic effects. Default: 5.")]
	public int LoyaltyDeltaMax
	{
		get
		{
			return _loyaltyDeltaMax;
		}
		set
		{
			if (_loyaltyDeltaMax != value)
			{
				if (value < _loyaltyDeltaMin)
				{
					_loyaltyDeltaMax = _loyaltyDeltaMin;
				}
				else
				{
					_loyaltyDeltaMax = value;
				}
				this.OnSettingChanged?.Invoke("LoyaltyDeltaMax", _loyaltyDeltaMax);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_LoyaltyDeltaPerDayMin}Loyalty Delta Per Day Min", -5, 0, "0", Order = 14, RequireRestart = false, HintText = "{=AIInfluence_LoyaltyDeltaPerDayMin_Hint}Minimum daily loyalty change value that AI can use in economic effects. Values should be small (0.2, 0.5) since loyalty is 0-100. Default: -1.")]
	public int LoyaltyDeltaPerDayMin
	{
		get
		{
			return _loyaltyDeltaPerDayMin;
		}
		set
		{
			if (_loyaltyDeltaPerDayMin != value)
			{
				if (value > _loyaltyDeltaPerDayMax)
				{
					_loyaltyDeltaPerDayMin = _loyaltyDeltaPerDayMax;
				}
				else
				{
					_loyaltyDeltaPerDayMin = value;
				}
				this.OnSettingChanged?.Invoke("LoyaltyDeltaPerDayMin", _loyaltyDeltaPerDayMin);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_LoyaltyDeltaPerDayMax}Loyalty Delta Per Day Max", 0, 5, "0", Order = 15, RequireRestart = false, HintText = "{=AIInfluence_LoyaltyDeltaPerDayMax_Hint}Maximum daily loyalty change value that AI can use in economic effects. Values should be small (0.2, 0.5) since loyalty is 0-100. Default: 1.")]
	public int LoyaltyDeltaPerDayMax
	{
		get
		{
			return _loyaltyDeltaPerDayMax;
		}
		set
		{
			if (_loyaltyDeltaPerDayMax != value)
			{
				if (value < _loyaltyDeltaPerDayMin)
				{
					_loyaltyDeltaPerDayMax = _loyaltyDeltaPerDayMin;
				}
				else
				{
					_loyaltyDeltaPerDayMax = value;
				}
				this.OnSettingChanged?.Invoke("LoyaltyDeltaPerDayMax", _loyaltyDeltaPerDayMax);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyFloatingInteger("{=AIInfluence_IncomeMultiplierMin}Income Multiplier Min", 0f, 1f, "0.00", Order = 16, RequireRestart = false, HintText = "{=AIInfluence_IncomeMultiplierMin_Hint}Minimum income multiplier value that AI can use in economic effects. Default: 0.5 (50% income).")]
	public float IncomeMultiplierMin
	{
		get
		{
			return _incomeMultiplierMin;
		}
		set
		{
			if (Math.Abs(_incomeMultiplierMin - value) > 0.001f)
			{
				if (value > _incomeMultiplierMax)
				{
					_incomeMultiplierMin = _incomeMultiplierMax;
				}
				else
				{
					_incomeMultiplierMin = value;
				}
				this.OnSettingChanged?.Invoke("IncomeMultiplierMin", _incomeMultiplierMin);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyFloatingInteger("{=AIInfluence_IncomeMultiplierMax}Income Multiplier Max", 1f, 2f, "0.00", Order = 17, RequireRestart = false, HintText = "{=AIInfluence_IncomeMultiplierMax_Hint}Maximum income multiplier value that AI can use in economic effects. Default: 1.5 (150% income).")]
	public float IncomeMultiplierMax
	{
		get
		{
			return _incomeMultiplierMax;
		}
		set
		{
			if (Math.Abs(_incomeMultiplierMax - value) > 0.001f)
			{
				if (value < _incomeMultiplierMin)
				{
					_incomeMultiplierMax = _incomeMultiplierMin;
				}
				else
				{
					_incomeMultiplierMax = value;
				}
				this.OnSettingChanged?.Invoke("IncomeMultiplierMax", _incomeMultiplierMax);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_DurationDaysMin}Duration Days Min", 1, 180, "0 Days", Order = 18, RequireRestart = false, HintText = "{=AIInfluence_DurationDaysMin_Hint}Minimum duration in days that AI can use in economic effects. Default: 7 days.")]
	public int DurationDaysMin
	{
		get
		{
			return _durationDaysMin;
		}
		set
		{
			if (_durationDaysMin != value)
			{
				if (value > _durationDaysMax)
				{
					_durationDaysMin = _durationDaysMax;
				}
				else
				{
					_durationDaysMin = value;
				}
				this.OnSettingChanged?.Invoke("DurationDaysMin", _durationDaysMin);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Economic}Economic Effects", GroupOrder = 9)]
	[SettingPropertyInteger("{=AIInfluence_DurationDaysMax}Duration Days Max", 7, 365, "0 Days", Order = 19, RequireRestart = false, HintText = "{=AIInfluence_DurationDaysMax_Hint}Maximum duration in days that AI can use in economic effects. Default: 90 days.")]
	public int DurationDaysMax
	{
		get
		{
			return _durationDaysMax;
		}
		set
		{
			if (_durationDaysMax != value)
			{
				if (value < _durationDaysMin)
				{
					_durationDaysMax = _durationDaysMin;
				}
				else
				{
					_durationDaysMax = value;
				}
				this.OnSettingChanged?.Invoke("DurationDaysMax", _durationDaysMax);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyBool("{=AIInfluence_DiplomacyInternalThoughts}Enable AI Internal Thoughts (EXPERIMENTAL)", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_DiplomacyInternalThoughts_Hint}EXPERIMENTAL FEATURE: If enabled, AI will generate a hidden internal thought process before making diplomatic statements. This improves roleplay and strategic logic but uses more tokens.")]
	public bool EnableDiplomacyInternalThoughts
	{
		get
		{
			return _enableDiplomacyInternalThoughts;
		}
		set
		{
			if (_enableDiplomacyInternalThoughts != value)
			{
				_enableDiplomacyInternalThoughts = value;
				this.OnSettingChanged?.Invoke("EnableDiplomacyInternalThoughts", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyBool("{=AIInfluence_EnableDiplomacy}Enable Diplomacy System", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_EnableDiplomacy_Hint}Enables AI-driven diplomacy system. When enabled, vanilla diplomacy (war declarations, peace treaties) will be disabled and replaced with AI-controlled diplomatic situations. Requires Dynamic Events to be enabled and not in dialogue-only mode.")]
	public bool EnableDiplomacy
	{
		get
		{
			return _enableDiplomacy;
		}
		set
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Expected O, but got Unknown
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Expected O, but got Unknown
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			if (_enableDiplomacy == value)
			{
				return;
			}
			if (value && !CanEnableDiplomacy())
			{
				_enableDiplomacy = false;
				string text = "";
				if (!EnableDynamicEvents)
				{
					text = ((object)new TextObject("{=AIInfluence_DiplomacyRequiresDynamicEvents}Diplomacy requires Dynamic Events to be enabled.", (Dictionary<string, object>)null)).ToString();
				}
				else if (DynamicEventsDialogueOnly)
				{
					text = ((object)new TextObject("{=AIInfluence_DiplomacyNotWorkingDialogueOnly}Diplomacy does not work in 'Dialogue Only' mode. Disable this option in Dynamic Events settings.", (Dictionary<string, object>)null)).ToString();
				}
				TextObject val = new TextObject("{=AIInfluence_DiplomacyBlocked}Diplomacy blocked: " + text, (Dictionary<string, object>)null);
				InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Yellow));
				this.OnSettingChanged?.Invoke("EnableDiplomacy", false);
			}
			else
			{
				_enableDiplomacy = value;
				this.OnSettingChanged?.Invoke("EnableDiplomacy", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyDropdown("{=AIInfluence_DiplomacyAIBackend}AI Backend for Diplomacy", RequireRestart = false, Order = 1, HintText = "{=AIInfluence_DiplomacyAIBackend_Hint}Select which AI backend to use for diplomatic statement generation. Can be different from dialogue AI.")]
	public Dropdown<string> DiplomacyAIBackend { get; set; } = new Dropdown<string>((IEnumerable<string>)new List<string> { "OpenRouter", "DeepSeek", "Player2", "Ollama", "KoboldCpp" }, 2);

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyBool("{=AIInfluence_StartInPeace}Start Campaign in Peace", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_StartInPeace_Hint}When enabled, all kingdoms start the campaign at peace with each other. Wars will only be declared through the AI diplomacy system.")]
	public bool StartInPeace
	{
		get
		{
			return _startInPeace;
		}
		set
		{
			if (_startInPeace != value)
			{
				_startInPeace = value;
				this.OnSettingChanged?.Invoke("StartInPeace", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyInteger("{=AIInfluence_MaxParticipatingKingdoms}Maximum Participating Kingdoms", 2, 8, "0 Kingdoms", Order = 3, RequireRestart = false, HintText = "{=AIInfluence_MaxParticipatingKingdoms_Hint}Maximum number of kingdoms that can participate in a single diplomatic event (excluding player kingdom). Default: 4.")]
	public int MaxParticipatingKingdoms
	{
		get
		{
			return _maxParticipatingKingdoms;
		}
		set
		{
			if (_maxParticipatingKingdoms != value)
			{
				_maxParticipatingKingdoms = value;
				this.OnSettingChanged?.Invoke("MaxParticipatingKingdoms", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyInteger("{=AIInfluence_StatementGenerationInterval}Statement Generation Interval (Days)", 1, 10, "0 Days", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_StatementGenerationInterval_Hint}Maximum days between kingdom statement generations in diplomatic events. Actual interval is random from 1 to this value. Default: 3 days.")]
	public int StatementGenerationIntervalDays
	{
		get
		{
			return _statementGenerationIntervalDays;
		}
		set
		{
			if (_statementGenerationIntervalDays != value)
			{
				_statementGenerationIntervalDays = value;
				this.OnSettingChanged?.Invoke("StatementGenerationIntervalDays", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyInteger("{=AIInfluence_DiplomacyMinLength}Minimum Statement Length", 50, 1000, "0 Characters", Order = 5, RequireRestart = false, HintText = "{=AIInfluence_DiplomacyMinLength_Hint}Minimum characters for diplomatic statements. Default: 150.")]
	public int DiplomacyMinStatementLength
	{
		get
		{
			return _diplomacyMinStatementLength;
		}
		set
		{
			if (_diplomacyMinStatementLength != value)
			{
				_diplomacyMinStatementLength = value;
				this.OnSettingChanged?.Invoke("DiplomacyMinStatementLength", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyInteger("{=AIInfluence_DiplomacyMaxLength}Maximum Statement Length", 100, 1000, "0 Characters", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_DiplomacyMaxLength_Hint}Maximum characters for diplomatic statements. Default: 600.")]
	public int DiplomacyMaxStatementLength
	{
		get
		{
			return _diplomacyMaxStatementLength;
		}
		set
		{
			if (_diplomacyMaxStatementLength != value)
			{
				_diplomacyMaxStatementLength = value;
				this.OnSettingChanged?.Invoke("DiplomacyMaxStatementLength", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyInteger("{=AIInfluence_MinRelationChange}Minimum Kingdom Relation Change", -20, 0, "0", Order = 7, RequireRestart = false, HintText = "{=AIInfluence_MinRelationChange_Hint}Minimum relation change between kingdom leaders during diplomatic events. Negative values decrease relations. Default: -10.")]
	public int MinKingdomRelationChange
	{
		get
		{
			return _minKingdomRelationChange;
		}
		set
		{
			if (_minKingdomRelationChange != value)
			{
				_minKingdomRelationChange = value;
				this.OnSettingChanged?.Invoke("MinKingdomRelationChange", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyInteger("{=AIInfluence_MaxRelationChange}Maximum Kingdom Relation Change", 0, 20, "0", Order = 8, RequireRestart = false, HintText = "{=AIInfluence_MaxRelationChange_Hint}Maximum relation change between kingdom leaders during diplomatic events. Positive values increase relations. Default: 10.")]
	public int MaxKingdomRelationChange
	{
		get
		{
			return _maxKingdomRelationChange;
		}
		set
		{
			if (_maxKingdomRelationChange != value)
			{
				_maxKingdomRelationChange = value;
				this.OnSettingChanged?.Invoke("MaxKingdomRelationChange", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyFloatingInteger("{=AIInfluence_FatiguePerTroop}Fatigue per Troop Lost", 0.001f, 0.1f, "0.000", Order = 9, RequireRestart = false, HintText = "{=AIInfluence_FatiguePerTroop_Hint}Fatigue points added per troop casualty. With 1000 troops lost and value 0.005, adds 5 points. Default: 0.005")]
	public float FatiguePerTroopLost
	{
		get
		{
			return _fatiguePerTroopLost;
		}
		set
		{
			if (Math.Abs(_fatiguePerTroopLost - value) > 0.0001f)
			{
				_fatiguePerTroopLost = value;
				this.OnSettingChanged?.Invoke("FatiguePerTroopLost", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyFloatingInteger("{=AIInfluence_FatiguePerLordKilled}Fatigue per Lord Killed", 0.5f, 10f, "0.0", Order = 10, RequireRestart = false, HintText = "{=AIInfluence_FatiguePerLordKilled_Hint}Fatigue points added when a lord is killed in war. Default: 5.0")]
	public float FatiguePerLordKilled
	{
		get
		{
			return _fatiguePerLordKilled;
		}
		set
		{
			if (Math.Abs(_fatiguePerLordKilled - value) > 0.01f)
			{
				_fatiguePerLordKilled = value;
				this.OnSettingChanged?.Invoke("FatiguePerLordKilled", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyFloatingInteger("{=AIInfluence_FatiguePerLordCaptured}Fatigue per Lord Captured", 0.5f, 10f, "0.0", Order = 11, RequireRestart = false, HintText = "{=AIInfluence_FatiguePerLordCaptured_Hint}Fatigue points added when a lord is captured by enemy. Default: 3.0")]
	public float FatiguePerLordCaptured
	{
		get
		{
			return _fatiguePerLordCaptured;
		}
		set
		{
			if (Math.Abs(_fatiguePerLordCaptured - value) > 0.01f)
			{
				_fatiguePerLordCaptured = value;
				this.OnSettingChanged?.Invoke("FatiguePerLordCaptured", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyFloatingInteger("{=AIInfluence_FatiguePerSettlement}Fatigue per Settlement Lost", 1f, 20f, "0.0", Order = 12, RequireRestart = false, HintText = "{=AIInfluence_FatiguePerSettlement_Hint}Fatigue points added when a settlement is captured by enemy. Default: 10.0")]
	public float FatiguePerSettlementLost
	{
		get
		{
			return _fatiguePerSettlementLost;
		}
		set
		{
			if (Math.Abs(_fatiguePerSettlementLost - value) > 0.01f)
			{
				_fatiguePerSettlementLost = value;
				this.OnSettingChanged?.Invoke("FatiguePerSettlementLost", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyFloatingInteger("{=AIInfluence_FatiguePerCaravan}Fatigue per Caravan Destroyed", 0.5f, 10f, "0.0", Order = 13, RequireRestart = false, HintText = "{=AIInfluence_FatiguePerCaravan_Hint}Fatigue points added when a caravan is destroyed by enemy. Default: 2.0")]
	public float FatiguePerCaravanDestroyed
	{
		get
		{
			return _fatiguePerCaravanDestroyed;
		}
		set
		{
			if (Math.Abs(_fatiguePerCaravanDestroyed - value) > 0.01f)
			{
				_fatiguePerCaravanDestroyed = value;
				this.OnSettingChanged?.Invoke("FatiguePerCaravanDestroyed", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Diplomacy}Diplomacy", GroupOrder = 10)]
	[SettingPropertyFloatingInteger("{=AIInfluence_FatigueRecoveryPerDay}Fatigue Recovery per Day (at Peace)", 1f, 10f, "0.0", Order = 14, RequireRestart = false, HintText = "{=AIInfluence_FatigueRecoveryPerDay_Hint}Fatigue points recovered each day when kingdom is at peace with all factions. Default: 5.0")]
	public float FatigueRecoveryPerDay
	{
		get
		{
			return _fatigueRecoveryPerDay;
		}
		set
		{
			if (Math.Abs(_fatigueRecoveryPerDay - value) > 0.01f)
			{
				_fatigueRecoveryPerDay = value;
				this.OnSettingChanged?.Invoke("FatigueRecoveryPerDay", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System", GroupOrder = 11)]
	[SettingPropertyBool("{=AIInfluence_EnableDiseaseSystem}Enable Disease System", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_EnableDiseaseSystem_Hint}Master switch for the entire disease system. Disabling this turns off AI-generated diseases, seasonal diseases, spread mechanics and treatment.")]
	public bool EnableDiseaseSystem
	{
		get
		{
			return _enableDiseaseSystem;
		}
		set
		{
			if (_enableDiseaseSystem != value)
			{
				_enableDiseaseSystem = value;
				this.OnSettingChanged?.Invoke("EnableDiseaseSystem", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyBool("{=AIInfluence_EnableSeasonalDiseases}Enable Seasonal Diseases", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_EnableSeasonalDiseases_Hint}Enables seasonal diseases (common cold, flu, bronchitis, etc.) for heroes and troops traveling on the world map. These are mild diseases independent of AI-generated outbreaks.")]
	public bool EnableSeasonalDiseases
	{
		get
		{
			return _enableSeasonalDiseases;
		}
		set
		{
			if (_enableSeasonalDiseases != value)
			{
				_enableSeasonalDiseases = value;
				this.OnSettingChanged?.Invoke("EnableSeasonalDiseases", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalDiseaseBaseChance}Base Infection Chance (per 6h)", 0.005f, 0.1f, "0.000", Order = 1, RequireRestart = false, HintText = "{=AIInfluence_SeasonalDiseaseBaseChance_Hint}Base chance of contracting a seasonal disease per 6-hour check. Season, weather and ship bonuses are added on top. Default: 0.02 (2%).")]
	public float SeasonalDiseaseBaseChance
	{
		get
		{
			return _seasonalDiseaseBaseChance;
		}
		set
		{
			if (Math.Abs(_seasonalDiseaseBaseChance - value) > 0.0001f)
			{
				_seasonalDiseaseBaseChance = value;
				this.OnSettingChanged?.Invoke("SeasonalDiseaseBaseChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalDiseaseMaxChance}Max Infection Chance", 0.1f, 0.5f, "0.00", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_SeasonalDiseaseMaxChance_Hint}Maximum infection chance per 6-hour check after all bonuses (season, weather, ship) are applied. Default: 0.35 (35%).")]
	public float SeasonalDiseaseMaxChance
	{
		get
		{
			return _seasonalDiseaseMaxChance;
		}
		set
		{
			if (Math.Abs(_seasonalDiseaseMaxChance - value) > 0.001f)
			{
				_seasonalDiseaseMaxChance = value;
				this.OnSettingChanged?.Invoke("SeasonalDiseaseMaxChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalWinterBonus}Winter Infection Bonus", 0f, 0.2f, "0.00", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_SeasonalWinterBonus_Hint}Additional infection chance added during winter. Stacks with base chance and weather bonuses. Default: 0.08 (+8%).")]
	public float SeasonalWinterBonus
	{
		get
		{
			return _seasonalWinterBonus;
		}
		set
		{
			if (Math.Abs(_seasonalWinterBonus - value) > 0.001f)
			{
				_seasonalWinterBonus = value;
				this.OnSettingChanged?.Invoke("SeasonalWinterBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalAutumnBonus}Autumn Infection Bonus", 0f, 0.2f, "0.00", Order = 5, RequireRestart = false, HintText = "{=AIInfluence_SeasonalAutumnBonus_Hint}Additional infection chance added during autumn. Default: 0.05 (+5%).")]
	public float SeasonalAutumnBonus
	{
		get
		{
			return _seasonalAutumnBonus;
		}
		set
		{
			if (Math.Abs(_seasonalAutumnBonus - value) > 0.001f)
			{
				_seasonalAutumnBonus = value;
				this.OnSettingChanged?.Invoke("SeasonalAutumnBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalSpringBonus}Spring Infection Bonus", 0f, 0.2f, "0.00", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_SeasonalSpringBonus_Hint}Additional infection chance added during spring. Default: 0.03 (+3%).")]
	public float SeasonalSpringBonus
	{
		get
		{
			return _seasonalSpringBonus;
		}
		set
		{
			if (Math.Abs(_seasonalSpringBonus - value) > 0.001f)
			{
				_seasonalSpringBonus = value;
				this.OnSettingChanged?.Invoke("SeasonalSpringBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalSummerBonus}Summer Infection Bonus", 0f, 0.1f, "0.00", Order = 7, RequireRestart = false, HintText = "{=AIInfluence_SeasonalSummerBonus_Hint}Additional infection chance added during summer. Default: 0.01 (+1%).")]
	public float SeasonalSummerBonus
	{
		get
		{
			return _seasonalSummerBonus;
		}
		set
		{
			if (Math.Abs(_seasonalSummerBonus - value) > 0.001f)
			{
				_seasonalSummerBonus = value;
				this.OnSettingChanged?.Invoke("SeasonalSummerBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalWeatherLightRainBonus}Light Rain Bonus", 0f, 0.1f, "0.00", Order = 8, RequireRestart = false, HintText = "{=AIInfluence_SeasonalWeatherLightRainBonus_Hint}Additional infection chance during light rain. Default: 0.02 (+2%).")]
	public float SeasonalWeatherLightRainBonus
	{
		get
		{
			return _seasonalWeatherLightRainBonus;
		}
		set
		{
			if (Math.Abs(_seasonalWeatherLightRainBonus - value) > 0.001f)
			{
				_seasonalWeatherLightRainBonus = value;
				this.OnSettingChanged?.Invoke("SeasonalWeatherLightRainBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalWeatherHeavyRainBonus}Heavy Rain / Storm Bonus", 0f, 0.15f, "0.00", Order = 9, RequireRestart = false, HintText = "{=AIInfluence_SeasonalWeatherHeavyRainBonus_Hint}Additional infection chance during heavy rain or storm. Default: 0.04 (+4%).")]
	public float SeasonalWeatherHeavyRainBonus
	{
		get
		{
			return _seasonalWeatherHeavyRainBonus;
		}
		set
		{
			if (Math.Abs(_seasonalWeatherHeavyRainBonus - value) > 0.001f)
			{
				_seasonalWeatherHeavyRainBonus = value;
				this.OnSettingChanged?.Invoke("SeasonalWeatherHeavyRainBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalWeatherSnowyBonus}Snowfall Bonus", 0f, 0.15f, "0.00", Order = 10, RequireRestart = false, HintText = "{=AIInfluence_SeasonalWeatherSnowyBonus_Hint}Additional infection chance during snowfall. Default: 0.05 (+5%).")]
	public float SeasonalWeatherSnowyBonus
	{
		get
		{
			return _seasonalWeatherSnowyBonus;
		}
		set
		{
			if (Math.Abs(_seasonalWeatherSnowyBonus - value) > 0.001f)
			{
				_seasonalWeatherSnowyBonus = value;
				this.OnSettingChanged?.Invoke("SeasonalWeatherSnowyBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalWeatherBlizzardBonus}Blizzard Bonus", 0f, 0.2f, "0.00", Order = 11, RequireRestart = false, HintText = "{=AIInfluence_SeasonalWeatherBlizzardBonus_Hint}Additional infection chance during a blizzard. Default: 0.08 (+8%).")]
	public float SeasonalWeatherBlizzardBonus
	{
		get
		{
			return _seasonalWeatherBlizzardBonus;
		}
		set
		{
			if (Math.Abs(_seasonalWeatherBlizzardBonus - value) > 0.001f)
			{
				_seasonalWeatherBlizzardBonus = value;
				this.OnSettingChanged?.Invoke("SeasonalWeatherBlizzardBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalWeatherWetBonus}Wet Ground Bonus", 0f, 0.1f, "0.00", Order = 12, RequireRestart = false, HintText = "{=AIInfluence_SeasonalWeatherWetBonus_Hint}Additional infection chance when terrain is wet (mud, waterlogged ground). Default: 0.01 (+1%).")]
	public float SeasonalWeatherWetBonus
	{
		get
		{
			return _seasonalWeatherWetBonus;
		}
		set
		{
			if (Math.Abs(_seasonalWeatherWetBonus - value) > 0.001f)
			{
				_seasonalWeatherWetBonus = value;
				this.OnSettingChanged?.Invoke("SeasonalWeatherWetBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_SeasonalDiseases}Seasonal Diseases", GroupOrder = 0)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SeasonalShipAtSeaBonus}Ship at Sea Bonus", 0f, 0.15f, "0.00", Order = 13, RequireRestart = false, HintText = "{=AIInfluence_SeasonalShipAtSeaBonus_Hint}Additional infection chance for parties traveling at sea. Wind and sea moisture raise the risk of colds and respiratory illness. Default: 0.04 (+4%).")]
	public float SeasonalShipAtSeaBonus
	{
		get
		{
			return _seasonalShipAtSeaBonus;
		}
		set
		{
			if (Math.Abs(_seasonalShipAtSeaBonus - value) > 0.001f)
			{
				_seasonalShipAtSeaBonus = value;
				this.OnSettingChanged?.Invoke("SeasonalShipAtSeaBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseTreatment}Treatment & Healing", GroupOrder = 1)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseTreatmentBaseCost}Treatment Base Cost", 50f, 500f, "0", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_DiseaseTreatmentBaseCost_Hint}Base gold cost for treating a hero in a hospital. Final cost = BaseCost × DiseaseSeverity × TierMultiplier. Default: 100")]
	public float DiseaseTreatmentBaseCost
	{
		get
		{
			return _diseaseTreatmentBaseCost;
		}
		set
		{
			if (Math.Abs(_diseaseTreatmentBaseCost - value) > 0.01f)
			{
				_diseaseTreatmentBaseCost = value;
				this.OnSettingChanged?.Invoke("DiseaseTreatmentBaseCost", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseTreatment}Treatment & Healing", GroupOrder = 1)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseTreatmentTroopMultiplier}Troop Treatment Cost Multiplier", 0.1f, 2f, "0.0", Order = 1, RequireRestart = false, HintText = "{=AIInfluence_DiseaseTreatmentTroopMultiplier_Hint}Cost multiplier for treating troops. Lower = cheaper troop treatment. Default: 0.5 (half the hero cost per sqrt of troop count)")]
	public float DiseaseTreatmentTroopMultiplier
	{
		get
		{
			return _diseaseTreatmentTroopMultiplier;
		}
		set
		{
			if (Math.Abs(_diseaseTreatmentTroopMultiplier - value) > 0.01f)
			{
				_diseaseTreatmentTroopMultiplier = value;
				this.OnSettingChanged?.Invoke("DiseaseTreatmentTroopMultiplier", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseTreatment}Treatment & Healing", GroupOrder = 1)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseasePreventionHerbCostMultiplier}Herb Cost Multiplier", 0.5f, 3f, "0.0", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_DiseasePreventionHerbCostMultiplier_Hint}Price multiplier for healing herbs purchased at hospitals. Default: 1.0 (no change)")]
	public float DiseasePreventionHerbCostMultiplier
	{
		get
		{
			return _diseasePreventionHerbCostMultiplier;
		}
		set
		{
			if (Math.Abs(_diseasePreventionHerbCostMultiplier - value) > 0.01f)
			{
				_diseasePreventionHerbCostMultiplier = value;
				this.OnSettingChanged?.Invoke("DiseasePreventionHerbCostMultiplier", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseTreatment}Treatment & Healing", GroupOrder = 1)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseMedicineSkillForTroopsMultiplier}Troop Medicine Effectiveness", 0.5f, 1f, "0.00", Order = 3, RequireRestart = false, HintText = "{=AIInfluence_DiseaseMedicineSkillForTroopsMultiplier_Hint}What fraction of the party surgeon's Medicine skill applies when healing troops (vs heroes). Default: 0.75 (75%)")]
	public float DiseaseMedicineSkillForTroopsMultiplier
	{
		get
		{
			return _diseaseMedicineSkillForTroopsMultiplier;
		}
		set
		{
			if (Math.Abs(_diseaseMedicineSkillForTroopsMultiplier - value) > 0.01f)
			{
				_diseaseMedicineSkillForTroopsMultiplier = value;
				this.OnSettingChanged?.Invoke("DiseaseMedicineSkillForTroopsMultiplier", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseTreatment}Treatment & Healing", GroupOrder = 1)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseProgressionMultiplier}Disease Progression Speed", 0.25f, 3f, "0.00", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_DiseaseProgressionMultiplier_Hint}Multiplier applied to how fast a disease progresses each day. 1.0 = default. 2.0 = diseases worsen twice as fast. 0.5 = diseases progress at half speed. Default: 1.0")]
	public float DiseaseProgressionMultiplier
	{
		get
		{
			return _diseaseProgressionMultiplier;
		}
		set
		{
			if (Math.Abs(_diseaseProgressionMultiplier - value) > 0.01f)
			{
				_diseaseProgressionMultiplier = value;
				this.OnSettingChanged?.Invoke("DiseaseProgressionMultiplier", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseTreatment}Treatment & Healing", GroupOrder = 1)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseRecoveryMultiplier}Disease Recovery Speed", 0.25f, 3f, "0.00", Order = 8, RequireRestart = false, HintText = "{=AIInfluence_DiseaseRecoveryMultiplier_Hint}Multiplier applied to the base recovery rate when a disease is being treated. 1.0 = default. 2.0 = recovery is twice as fast. 0.5 = recovery is twice as slow. Default: 1.0")]
	public float DiseaseRecoveryMultiplier
	{
		get
		{
			return _diseaseRecoveryMultiplier;
		}
		set
		{
			if (Math.Abs(_diseaseRecoveryMultiplier - value) > 0.01f)
			{
				_diseaseRecoveryMultiplier = value;
				this.OnSettingChanged?.Invoke("DiseaseRecoveryMultiplier", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseTreatment}Treatment & Healing", GroupOrder = 1)]
	[SettingPropertyInteger("{=AIInfluence_SeasonalPostRecoveryImmunityDays}Seasonal Post-Recovery Immunity Days", 0, 60, "0 Days", Order = 9, RequireRestart = false, HintText = "{=AIInfluence_SeasonalPostRecoveryImmunityDays_Hint}How many days of immunity against ALL seasonal diseases a hero gains after recovering from one. Heroes only — troops are not tracked individually. Set to 0 to disable. Default: 21")]
	public int SeasonalPostRecoveryImmunityDays
	{
		get
		{
			return _seasonalPostRecoveryImmunityDays;
		}
		set
		{
			if (_seasonalPostRecoveryImmunityDays != value)
			{
				_seasonalPostRecoveryImmunityDays = value;
				this.OnSettingChanged?.Invoke("SeasonalPostRecoveryImmunityDays", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseTreatment}Treatment & Healing", GroupOrder = 1)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseSpreadInheritFactor}Spread Duration Inherit Factor", 0.25f, 1f, "0.00", Order = 10, RequireRestart = false, HintText = "{=AIInfluence_DiseaseSpreadInheritFactor_Hint}When a disease spreads from one settlement to another, the new outbreak gets this fraction of the source disease's remaining duration. Default: 0.75 (75%)")]
	public float DiseaseSpreadInheritFactor
	{
		get
		{
			return _diseaseSpreadInheritFactor;
		}
		set
		{
			if (Math.Abs(_diseaseSpreadInheritFactor - value) > 0.01f)
			{
				_diseaseSpreadInheritFactor = value;
				this.OnSettingChanged?.Invoke("DiseaseSpreadInheritFactor", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseSpread}Disease Spread", GroupOrder = 2)]
	[SettingPropertyFloatingInteger("{=AIInfluence_SettlementInfectionBaseChance}Settlement Infection Chance", 0f, 0.3f, "0.000", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_SettlementInfectionBaseChance_Hint}Base chance per 6-hour tick that a hero in a diseased settlement becomes infected. Scaled up by disease severity and spread rate. Default: 0.05 (5%)")]
	public float SettlementInfectionBaseChance
	{
		get
		{
			return _settlementInfectionBaseChance;
		}
		set
		{
			if (Math.Abs(_settlementInfectionBaseChance - value) > 0.001f)
			{
				_settlementInfectionBaseChance = value;
				this.OnSettingChanged?.Invoke("SettlementInfectionBaseChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseSpread}Disease Spread", GroupOrder = 2)]
	[SettingPropertyFloatingInteger("{=AIInfluence_MissionInfectionBaseChance}Mission Infection Chance", 0f, 0.3f, "0.000", Order = 1, RequireRestart = false, HintText = "{=AIInfluence_MissionInfectionBaseChance_Hint}Chance per minute of contracting a disease while inside a diseased settlement (sieges, town visits, taverns). Default: 0.08 (8% per minute)")]
	public float MissionInfectionBaseChance
	{
		get
		{
			return _missionInfectionBaseChance;
		}
		set
		{
			if (Math.Abs(_missionInfectionBaseChance - value) > 0.001f)
			{
				_missionInfectionBaseChance = value;
				this.OnSettingChanged?.Invoke("MissionInfectionBaseChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseSpread}Disease Spread", GroupOrder = 2)]
	[SettingPropertyFloatingInteger("{=AIInfluence_PlayerFromTroopsBaseChance}Player Infection from Troops Chance", 0f, 0.5f, "0.00", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_PlayerFromTroopsBaseChance_Hint}Daily chance for the player to contract a disease from their own infected troops. At 100% troop infection this is the full value; reduced proportionally. Default: 0.175 (17.5%)")]
	public float PlayerFromTroopsBaseChance
	{
		get
		{
			return _playerFromTroopsBaseChance;
		}
		set
		{
			if (Math.Abs(_playerFromTroopsBaseChance - value) > 0.001f)
			{
				_playerFromTroopsBaseChance = value;
				this.OnSettingChanged?.Invoke("PlayerFromTroopsBaseChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseSpread}Disease Spread", GroupOrder = 2)]
	[SettingPropertyFloatingInteger("{=AIInfluence_LordHallInfectionChancePerLord}Lord Hall Infection Chance (per Lord)", 0f, 0.1f, "0.000", Order = 3, RequireRestart = false, HintText = "{=AIInfluence_LordHallInfectionChancePerLord_Hint}Infection chance per infected lord when visiting a lord's hall in a settlement mission. Stacks with number of infected lords present. Default: 0.025 (2.5%)")]
	public float LordHallInfectionChancePerLord
	{
		get
		{
			return _lordHallInfectionChancePerLord;
		}
		set
		{
			if (Math.Abs(_lordHallInfectionChancePerLord - value) > 0.001f)
			{
				_lordHallInfectionChancePerLord = value;
				this.OnSettingChanged?.Invoke("LordHallInfectionChancePerLord", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseSpread}Disease Spread", GroupOrder = 2)]
	[SettingPropertyFloatingInteger("{=AIInfluence_QuarantineInfectionReduction}Quarantine Infection Reduction", 0f, 1f, "0.00", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_QuarantineInfectionReduction_Hint}Multiplier applied to infection chance for everyone INSIDE a quarantined settlement (heroes, troops, garrison, militia). Quarantine also fully blocks outgoing disease spread to other settlements. 0.5 = halves infection risk inside. Default: 0.5")]
	public float QuarantineInfectionReduction
	{
		get
		{
			return _quarantineInfectionReduction;
		}
		set
		{
			if (Math.Abs(_quarantineInfectionReduction - value) > 0.01f)
			{
				_quarantineInfectionReduction = value;
				this.OnSettingChanged?.Invoke("QuarantineInfectionReduction", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseSpread}Disease Spread", GroupOrder = 2)]
	[SettingPropertyFloatingInteger("{=AIInfluence_PrisonerSpreadModifier}Prisoner Disease Spread Rate", 0f, 1f, "0.00", Order = 5, RequireRestart = false, HintText = "{=AIInfluence_PrisonerSpreadModifier_Hint}Multiplier applied to all disease spread checks for prisoners. 0.5 = prisoners spread disease at half the normal rate. Set to 0 to disable prisoner spread entirely. Default: 0.5")]
	public float PrisonerSpreadModifier
	{
		get
		{
			return _prisonerSpreadModifier;
		}
		set
		{
			if (Math.Abs(_prisonerSpreadModifier - value) > 0.01f)
			{
				_prisonerSpreadModifier = value;
				this.OnSettingChanged?.Invoke("PrisonerSpreadModifier", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseAILimits}AI Disease Limits", GroupOrder = 3)]
	[SettingPropertyInteger("{=AIInfluence_DiseaseMaxSeverity}Max Disease Severity", 1, 5, "0", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_DiseaseMaxSeverity_Hint}Maximum severity level AI can assign to generated diseases. 1=mild (cold), 5=severe/fatal (plague). Affects duration, recovery difficulty and death chance. Default: 5")]
	public int DiseaseMaxSeverity
	{
		get
		{
			return _diseaseMaxSeverity;
		}
		set
		{
			if (_diseaseMaxSeverity != value)
			{
				_diseaseMaxSeverity = value;
				this.OnSettingChanged?.Invoke("DiseaseMaxSeverity", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseAILimits}AI Disease Limits", GroupOrder = 3)]
	[SettingPropertyInteger("{=AIInfluence_DiseaseMaxSimultaneous}Max Simultaneous Diseases", 1, 10, "0", Order = 1, RequireRestart = false, HintText = "{=AIInfluence_DiseaseMaxSimultaneous_Hint}Maximum number of AI-generated disease outbreaks active in the world at the same time. AI will not create new ones until an existing outbreak ends. Default: 3")]
	public int DiseaseMaxSimultaneous
	{
		get
		{
			return _diseaseMaxSimultaneous;
		}
		set
		{
			if (_diseaseMaxSimultaneous != value)
			{
				_diseaseMaxSimultaneous = value;
				this.OnSettingChanged?.Invoke("DiseaseMaxSimultaneous", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseAILimits}AI Disease Limits", GroupOrder = 3)]
	[SettingPropertyInteger("{=AIInfluence_DiseaseMinDaysBetweenOutbreaks}Min Days Between Outbreaks", 7, 60, "0 Days", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_DiseaseMinDaysBetweenOutbreaks_Hint}Minimum number of game days that must pass between two successive AI-generated disease outbreaks. Prevents rapid disease spam. Default: 14")]
	public int DiseaseMinDaysBetweenOutbreaks
	{
		get
		{
			return _diseaseMinDaysBetweenOutbreaks;
		}
		set
		{
			if (_diseaseMinDaysBetweenOutbreaks != value)
			{
				_diseaseMinDaysBetweenOutbreaks = value;
				this.OnSettingChanged?.Invoke("DiseaseMinDaysBetweenOutbreaks", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseAILimits}AI Disease Limits", GroupOrder = 3)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseMaxSpreadRate}Max Spread Rate", 0.1f, 1f, "0.00", Order = 3, RequireRestart = false, HintText = "{=AIInfluence_DiseaseMaxSpreadRate_Hint}Upper limit on AI-assigned spread rate. Higher spread = disease reaches more settlements and heroes faster. Default: 0.8")]
	public float DiseaseMaxSpreadRate
	{
		get
		{
			return _diseaseMaxSpreadRate;
		}
		set
		{
			if (Math.Abs(_diseaseMaxSpreadRate - value) > 0.01f)
			{
				_diseaseMaxSpreadRate = value;
				this.OnSettingChanged?.Invoke("DiseaseMaxSpreadRate", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseAILimits}AI Disease Limits", GroupOrder = 3)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseMaxDeathChance}Max Death Chance", 0f, 1f, "0.00", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_DiseaseMaxDeathChance_Hint}Maximum per-day death chance allowed for AI-generated diseases. Values the AI proposes above this are clamped. Default: 0.3 (30%)")]
	public float DiseaseMaxDeathChance
	{
		get
		{
			return _diseaseMaxDeathChance;
		}
		set
		{
			if (Math.Abs(_diseaseMaxDeathChance - value) > 0.01f)
			{
				_diseaseMaxDeathChance = value;
				this.OnSettingChanged?.Invoke("DiseaseMaxDeathChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseAILimits}AI Disease Limits", GroupOrder = 3)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseMinCombatModifier}Min Combat Modifier", 0.1f, 1f, "0.00", Order = 5, RequireRestart = false, HintText = "{=AIInfluence_DiseaseMinCombatModifier_Hint}Lower limit on AI-assigned combat modifiers (damage, defense, speed). 0.5 means a disease can reduce combat stats to at most 50% of normal. Default: 0.5")]
	public float DiseaseMinCombatModifier
	{
		get
		{
			return _diseaseMinCombatModifier;
		}
		set
		{
			if (Math.Abs(_diseaseMinCombatModifier - value) > 0.01f)
			{
				_diseaseMinCombatModifier = value;
				this.OnSettingChanged?.Invoke("DiseaseMinCombatModifier", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseAILimits}AI Disease Limits", GroupOrder = 3)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseMinMapSpeedModifier}Min Map Speed Modifier", 0.1f, 1f, "0.00", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_DiseaseMinMapSpeedModifier_Hint}Lower limit on the world-map movement speed modifier for AI diseases. 0.5 means a disease can slow a party to at most 50% of normal speed. Default: 0.5")]
	public float DiseaseMinMapSpeedModifier
	{
		get
		{
			return _diseaseMinMapSpeedModifier;
		}
		set
		{
			if (Math.Abs(_diseaseMinMapSpeedModifier - value) > 0.01f)
			{
				_diseaseMinMapSpeedModifier = value;
				this.OnSettingChanged?.Invoke("DiseaseMinMapSpeedModifier", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseAILimits}AI Disease Limits", GroupOrder = 3)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseMaxMoralePenalty}Max Morale Penalty", -50f, 0f, "0", Order = 7, RequireRestart = false, HintText = "{=AIInfluence_DiseaseMaxMoralePenalty_Hint}Most negative morale modifier allowed for AI diseases. -30 means no disease can reduce morale by more than 30 points. Default: -30")]
	public float DiseaseMaxMoralePenalty
	{
		get
		{
			return _diseaseMaxMoralePenalty;
		}
		set
		{
			if (Math.Abs(_diseaseMaxMoralePenalty - value) > 0.01f)
			{
				_diseaseMaxMoralePenalty = value;
				this.OnSettingChanged?.Invoke("DiseaseMaxMoralePenalty", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Disease}Disease System/{=AIInfluence_Group_DiseaseAILimits}AI Disease Limits", GroupOrder = 3)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DiseaseMaxPhysicalSkillPenalty}Max Physical Skill Penalty", -50f, 0f, "0", Order = 8, RequireRestart = false, HintText = "{=AIInfluence_DiseaseMaxPhysicalSkillPenalty_Hint}Most negative physical skill penalty allowed for AI diseases. -30 means no disease can reduce physical combat skills by more than 30 points. Applies to all combat skills. Default: -30")]
	public float DiseaseMaxPhysicalSkillPenalty
	{
		get
		{
			return _diseaseMaxPhysicalSkillPenalty;
		}
		set
		{
			if (Math.Abs(_diseaseMaxPhysicalSkillPenalty - value) > 0.01f)
			{
				_diseaseMaxPhysicalSkillPenalty = value;
				this.OnSettingChanged?.Invoke("DiseaseMaxPhysicalSkillPenalty", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyBool("{=AIInfluence_EnableNPCInitiative}Enable NPC Initiative System", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_EnableNPCInitiative_Hint}Allows NPCs to initiate conversations with the player. NPCs in your party will ask to talk, while others will send messengers.")]
	public bool EnableNPCInitiative
	{
		get
		{
			return _enableNPCInitiative;
		}
		set
		{
			if (_enableNPCInitiative != value)
			{
				_enableNPCInitiative = value;
				this.OnSettingChanged?.Invoke("EnableNPCInitiative", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyFloatingInteger("{=AIInfluence_NPCInitiativeBaseChance}Base Daily Initiative Chance (%)", 0f, 50f, "#0.0", Order = 1, RequireRestart = false, HintText = "{=AIInfluence_NPCInitiativeBaseChance_Hint}Base chance for an NPC to initiate conversation each day (0-50%). Default: 5%")]
	public float NPCInitiativeBaseChance
	{
		get
		{
			return _npcInitiativeBaseChance;
		}
		set
		{
			if (Math.Abs(_npcInitiativeBaseChance - value) > 0.01f)
			{
				_npcInitiativeBaseChance = value;
				this.OnSettingChanged?.Invoke("NPCInitiativeBaseChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyFloatingInteger("{=AIInfluence_NPCInitiativeFriendlyBonus}Friendly Relation Bonus (%)", 0f, 30f, "#0.0", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_NPCInitiativeFriendlyBonus_Hint}Additional chance for NPCs with good relations (20+). Default: 10%")]
	public float NPCInitiativeFriendlyBonus
	{
		get
		{
			return _npcInitiativeFriendlyBonus;
		}
		set
		{
			if (Math.Abs(_npcInitiativeFriendlyBonus - value) > 0.01f)
			{
				_npcInitiativeFriendlyBonus = value;
				this.OnSettingChanged?.Invoke("NPCInitiativeFriendlyBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyFloatingInteger("{=AIInfluence_NPCInitiativeHostileBonus}Hostile Relation Bonus (%)", 0f, 20f, "#0.0", Order = 3, RequireRestart = false, HintText = "{=AIInfluence_NPCInitiativeHostileBonus_Hint}Additional chance for NPCs with bad relations (-20 or worse). Default: 5%")]
	public float NPCInitiativeHostileBonus
	{
		get
		{
			return _npcInitiativeHostileBonus;
		}
		set
		{
			if (Math.Abs(_npcInitiativeHostileBonus - value) > 0.01f)
			{
				_npcInitiativeHostileBonus = value;
				this.OnSettingChanged?.Invoke("NPCInitiativeHostileBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyBool("{=AIInfluence_EnableNPCMapInitiative}Enable Map Initiative", Order = 9, RequireRestart = false, HintText = "{=AIInfluence_EnableNPCMapInitiative_Hint}Allow lords on the global map to approach the player (friendly or hostile).")]
	public bool EnableNPCMapInitiative
	{
		get
		{
			return _enableNPCMapInitiative;
		}
		set
		{
			if (_enableNPCMapInitiative != value)
			{
				_enableNPCMapInitiative = value;
				this.OnSettingChanged?.Invoke("EnableNPCMapInitiative", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyBool("{=AIInfluence_EnableHostileInitiative}Enable Hostile Initiative", Order = 10, RequireRestart = false, HintText = "{=AIInfluence_EnableHostileInitiative_Hint}Allow hostile lords to initiate conversation when they catch the player on the map.")]
	public bool EnableHostileInitiative { get; set; } = true;

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyFloatingInteger("{=AIInfluence_NPCInitiativeMapBaseChance}Map Approach Base Chance (%)", 0f, 50f, "#0.0", Order = 10, RequireRestart = false, HintText = "{=AIInfluence_NPCInitiativeMapBaseChance_Hint}Base chance for a visible lord on the map to approach the player (checked every 5 hours). Default: 2%")]
	public float NPCInitiativeMapBaseChance
	{
		get
		{
			return _npcInitiativeMapBaseChance;
		}
		set
		{
			if (Math.Abs(_npcInitiativeMapBaseChance - value) > 0.01f)
			{
				_npcInitiativeMapBaseChance = value;
				this.OnSettingChanged?.Invoke("NPCInitiativeMapBaseChance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyInteger("{=AIInfluence_HostileInitiativeCooldown}Hostile Initiative Cooldown (Days)", 1, 30, "0 days", Order = 11, RequireRestart = false, HintText = "{=AIInfluence_HostileInitiativeCooldown_Hint}Number of days before ANY hostile lord can initiate conversation again after one has successfully caught the player.")]
	public int HostileInitiativeCooldown { get; set; } = 3;

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyFloatingInteger("{=AIInfluence_NPCInitiativeRomanceBonus}Romance Bonus (%)", 0f, 40f, "#0.0", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_NPCInitiativeRomanceBonus_Hint}Additional chance for NPCs with romance level 50+. Default: 20%")]
	public float NPCInitiativeRomanceBonus
	{
		get
		{
			return _npcInitiativeRomanceBonus;
		}
		set
		{
			if (Math.Abs(_npcInitiativeRomanceBonus - value) > 0.01f)
			{
				_npcInitiativeRomanceBonus = value;
				this.OnSettingChanged?.Invoke("NPCInitiativeRomanceBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyFloatingInteger("{=AIInfluence_NPCInitiativeFamiliarityBonus}Familiarity Bonus (%)", 0f, 20f, "#0.0", Order = 5, RequireRestart = false, HintText = "{=AIInfluence_NPCInitiativeFamiliarityBonus_Hint}Additional chance for NPCs with 10+ interactions. Default: 5%")]
	public float NPCInitiativeFamiliarityBonus
	{
		get
		{
			return _npcInitiativeFamiliarityBonus;
		}
		set
		{
			if (Math.Abs(_npcInitiativeFamiliarityBonus - value) > 0.01f)
			{
				_npcInitiativeFamiliarityBonus = value;
				this.OnSettingChanged?.Invoke("NPCInitiativeFamiliarityBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyFloatingInteger("{=AIInfluence_NPCInitiativePartyBonus}Party Member Bonus (%)", 0f, 30f, "#0.0", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_NPCInitiativePartyBonus_Hint}Additional chance for NPCs in player's party. Default: 15%")]
	public float NPCInitiativePartyBonus
	{
		get
		{
			return _npcInitiativePartyBonus;
		}
		set
		{
			if (Math.Abs(_npcInitiativePartyBonus - value) > 0.01f)
			{
				_npcInitiativePartyBonus = value;
				this.OnSettingChanged?.Invoke("NPCInitiativePartyBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyFloatingInteger("{=AIInfluence_NPCInitiativeLongTimeSinceContactBonus}Long Time Since Contact Bonus (%)", 0f, 25f, "#0.0", Order = 7, RequireRestart = false, HintText = "{=AIInfluence_NPCInitiativeLongTimeSinceContactBonus_Hint}Additional chance for NPCs you haven't talked to in 20+ days. Default: 10%")]
	public float NPCInitiativeLongTimeSinceContactBonus
	{
		get
		{
			return _npcInitiativeLongTimeSinceContactBonus;
		}
		set
		{
			if (Math.Abs(_npcInitiativeLongTimeSinceContactBonus - value) > 0.01f)
			{
				_npcInitiativeLongTimeSinceContactBonus = value;
				this.OnSettingChanged?.Invoke("NPCInitiativeLongTimeSinceContactBonus", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyFloatingInteger("{=AIInfluence_MessengerCostPerDistance}Messenger Cost Per Distance Unit", 10f, 50f, "#0", Order = 20, RequireRestart = false, HintText = "{=AIInfluence_MessengerCostPerDistance_Hint}Cost in denars per 1.0 distance unit to send a messenger to an NPC. Default: 15 denars.")]
	public float MessengerCostPerDistance
	{
		get
		{
			return _messengerCostPerDistance;
		}
		set
		{
			if (Math.Abs(_messengerCostPerDistance - value) > 0.01f)
			{
				_messengerCostPerDistance = value;
				this.OnSettingChanged?.Invoke("MessengerCostPerDistance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCInitiative}NPC Initiative", GroupOrder = 11)]
	[SettingPropertyFloatingInteger("{=AIInfluence_MessengerDeliveryHoursPerDistance}Messenger Delivery Hours Per Distance Unit", 0.5f, 5f, "#0.0", Order = 21, RequireRestart = false, HintText = "{=AIInfluence_MessengerDeliveryHoursPerDistance_Hint}Hours required for messenger to travel per 1.0 distance unit. Default: 1.0 hour.")]
	public float MessengerDeliveryHoursPerDistance
	{
		get
		{
			return _messengerDeliveryHoursPerDistance;
		}
		set
		{
			if (Math.Abs(_messengerDeliveryHoursPerDistance - value) > 0.01f)
			{
				_messengerDeliveryHoursPerDistance = value;
				this.OnSettingChanged?.Invoke("MessengerDeliveryHoursPerDistance", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_ArenaTraining}Arena Training", GroupOrder = 11)]
	[SettingPropertyBool("{=AIInfluence_EnableArenaTraining}Enable Arena Troop Training", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_EnableArenaTraining_Hint}Enables the arena training system. When disabled, the training menu will not appear in town arenas.")]
	public bool EnableArenaTraining
	{
		get
		{
			return _enableArenaTraining;
		}
		set
		{
			if (_enableArenaTraining != value)
			{
				_enableArenaTraining = value;
				this.OnSettingChanged?.Invoke("EnableArenaTraining", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Technical}Technical Settings", GroupOrder = 11)]
	[SettingPropertyFloatingInteger("{=AIInfluence_DialogDelay}Dialog Auto-Close Delay (seconds)", 10f, 40f, "#0", Order = 100, RequireRestart = false, HintText = "{=AIInfluence_DialogDelay_Hint}Time in seconds before dialog automatically closes after NPC action (combat, release, surrender, marriage, etc.). Default: 15 seconds. Increase if you need more time to read messages.")]
	public float DialogDelay
	{
		get
		{
			return _dialogDelay;
		}
		set
		{
			if (Math.Abs(_dialogDelay - value) > 0.01f)
			{
				_dialogDelay = value;
				this.OnSettingChanged?.Invoke("DialogDelay", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Technical}Technical Settings", GroupOrder = 11)]
	[SettingPropertyBool("{=AIInfluence_EnableResponseReadySound}Enable response ready sound", Order = 101, RequireRestart = false, HintText = "{=AIInfluence_EnableResponseReadySound_Hint}Play a sound when the AI response is ready and the NPC notification appears.")]
	public bool EnableResponseReadySound
	{
		get
		{
			return _enableResponseReadySound;
		}
		set
		{
			if (_enableResponseReadySound != value)
			{
				_enableResponseReadySound = value;
				this.OnSettingChanged?.Invoke("EnableResponseReadySound", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Technical}Technical Settings", GroupOrder = 11)]
	[SettingPropertyBool("{=AIInfluence_EnableNPCLastMessageHistory}Show NPC Last Message in Dialog", Order = 102, RequireRestart = false, HintText = "{=AIInfluence_EnableNPCLastMessageHistory_Hint}When enabled, the last NPC message is shown in the text input dialog as a reminder of the previous conversation.")]
	public bool EnableNPCLastMessageHistory
	{
		get
		{
			return _enableNPCLastMessageHistory;
		}
		set
		{
			if (_enableNPCLastMessageHistory != value)
			{
				_enableNPCLastMessageHistory = value;
				this.OnSettingChanged?.Invoke("EnableNPCLastMessageHistory", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCManagement}NPC Management", GroupOrder = 12)]
	[SettingPropertyBool("{=AIInfluence_ClearAllNPCs}Clear Current Campaign NPC Data", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_ClearAllNPCs_Hint}WARNING: This will permanently delete all NPC conversation data and contexts for the CURRENT CAMPAIGN only. Other campaigns will not be affected. This action cannot be undone! Set to true and save settings to execute.")]
	public bool ClearAllNPCs
	{
		get
		{
			return false;
		}
		set
		{
			if (value)
			{
				this.OnSettingChanged?.Invoke("ClearAllNPCs", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCManagement}NPC Management", GroupOrder = 12)]
	[SettingPropertyBool("{=AIInfluence_ClearAllNPCEvents}Clear All NPC Events", Order = 2, RequireRestart = false, HintText = "{=AIInfluence_ClearAllNPCEvents_Hint}Clears all events (RecentEvents) for all NPCs in the current campaign. This will remove all battle, marriage, death, and other world events from NPC memory. This action cannot be undone!")]
	public bool ClearAllNPCEvents
	{
		get
		{
			return false;
		}
		set
		{
			if (value)
			{
				this.OnSettingChanged?.Invoke("ClearAllNPCEvents", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCManagement}NPC Management", GroupOrder = 12)]
	[SettingPropertyBool("{=AIInfluence_LoadAllNPCs}Load All NPCs Into Memory", Order = 4, RequireRestart = false, HintText = "{=AIInfluence_LoadAllNPCs_Hint}Loads all NPC contexts from JSON files into game memory. This ensures all NPCs can receive world events. Use this button after loading a save game to activate all NPCs for event processing.")]
	public bool LoadAllNPCs
	{
		get
		{
			return false;
		}
		set
		{
			if (value)
			{
				this.OnSettingChanged?.Invoke("LoadAllNPCs", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCManagement}NPC Management", GroupOrder = 12)]
	[SettingPropertyBool("{=AIInfluence_EraseSpecificNPC}Erase Specific NPC", Order = 5, RequireRestart = false, HintText = "{=AIInfluence_EraseSpecificNPC_Hint}Opens a window to select and permanently delete a specific NPC's data from memory and saved files. This action cannot be undone!")]
	public bool EraseSpecificNPC
	{
		get
		{
			return false;
		}
		set
		{
			if (value)
			{
				this.OnSettingChanged?.Invoke("EraseSpecificNPC", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_NPCManagement}NPC Management", GroupOrder = 12)]
	[SettingPropertyBool("{=AIInfluence_EnableDeadNPCCleanup}Enable Dead NPC Cleanup", Order = 6, RequireRestart = false, HintText = "{=AIInfluence_EnableDeadNPCCleanup_Hint}Automatically removes dead NPC data from memory and deletes their JSON files. When disabled, dead NPC data will be preserved. This helps keep the system clean and prevents memory bloat.")]
	public bool EnableDeadNPCCleanup
	{
		get
		{
			return _enableDeadNPCCleanup;
		}
		set
		{
			if (_enableDeadNPCCleanup != value)
			{
				_enableDeadNPCCleanup = value;
				this.OnSettingChanged?.Invoke("EnableDeadNPCCleanup", value);
			}
		}
	}

	[SettingPropertyGroup("{=AIInfluence_Group_Debug}Debug & Fixes", GroupOrder = 99)]
	[SettingPropertyButton("{=AIInfluence_ForceCloseDialog}Force Close Dialog", -1, true, "", Content = "{=AIInfluence_ForceCloseDialog_Button}Fix Stuck Dialog", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_ForceCloseDialog_Hint}Forcefully ends the current conversation and resets NPC locking states. Use if stuck.")]
	public Action ForceCloseDialog { get; set; } = delegate
	{
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected O, but got Unknown
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected O, but got Unknown
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Expected O, but got Unknown
		try
		{
			AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
			Hero val = null;
			string text = null;
			if (Campaign.Current != null && Campaign.Current.ConversationManager != null)
			{
				ConversationManager conversationManager = Campaign.Current.ConversationManager;
				val = Hero.OneToOneConversationHero;
				if (val == null && conversationManager.ConversationCharacters != null)
				{
					foreach (CharacterObject conversationCharacter in conversationManager.ConversationCharacters)
					{
						if (conversationCharacter != null && conversationCharacter.HeroObject != null && conversationCharacter.HeroObject != Hero.MainHero)
						{
							val = conversationCharacter.HeroObject;
							break;
						}
					}
				}
				if (val == null && conversationManager.ConversationAgents != null && conversationManager.ConversationAgents.Count > 0)
				{
					foreach (IAgent conversationAgent in conversationManager.ConversationAgents)
					{
						if (conversationAgent != null && conversationAgent.Character != null)
						{
							BasicCharacterObject character = conversationAgent.Character;
							CharacterObject val2 = (CharacterObject)(object)((character is CharacterObject) ? character : null);
							if (val2 != null && val2.HeroObject != null && val2.HeroObject != Hero.MainHero)
							{
								val = val2.HeroObject;
								break;
							}
						}
					}
				}
				if (val != null)
				{
					text = ((MBObjectBase)val).StringId;
				}
				if (conversationManager.IsConversationInProgress)
				{
					if (conversationManager.IsConversationFlowActive)
					{
						conversationManager.OnConversationDeactivate();
					}
					conversationManager.EndConversation();
				}
			}
			if (instance != null)
			{
				if (val != null)
				{
					NPCContext orCreateNPCContext = instance.GetOrCreateNPCContext(val);
					if (orCreateNPCContext != null)
					{
						orCreateNPCContext.CombatResponse = null;
						orCreateNPCContext.IsSurrendering = false;
						orCreateNPCContext.MarriageResponse = null;
						orCreateNPCContext.PendingDeath = null;
						orCreateNPCContext.PendingSettlementCombat = null;
						orCreateNPCContext.SettlementCombatResponse = null;
						orCreateNPCContext.PendingAIResponse = null;
						orCreateNPCContext.PendingWorkshopSale = null;
						orCreateNPCContext.PendingMoneyTransfer = null;
						orCreateNPCContext.PendingItemTransfers = null;
						orCreateNPCContext.IsNPCInitiatedConversation = false;
						orCreateNPCContext.IsHostileInitiative = false;
						instance.SaveNPCContext(((MBObjectBase)val).StringId, val, orCreateNPCContext);
						InformationManager.DisplayMessage(new InformationMessage($"[AIInfluence] Dialog forced closed and NPC {val.Name} reset.", Colors.Green));
					}
				}
				else if (text != null)
				{
					NPCContext nPCContextByStringId = instance.GetNPCContextByStringId(text);
					if (nPCContextByStringId != null)
					{
						nPCContextByStringId.CombatResponse = null;
						nPCContextByStringId.IsSurrendering = false;
						nPCContextByStringId.MarriageResponse = null;
						nPCContextByStringId.PendingDeath = null;
						nPCContextByStringId.PendingSettlementCombat = null;
						nPCContextByStringId.SettlementCombatResponse = null;
						nPCContextByStringId.PendingAIResponse = null;
						nPCContextByStringId.PendingWorkshopSale = null;
						nPCContextByStringId.PendingMoneyTransfer = null;
						nPCContextByStringId.PendingItemTransfers = null;
						nPCContextByStringId.IsNPCInitiatedConversation = false;
						nPCContextByStringId.IsHostileInitiative = false;
						instance.SaveNPCContext(text, null, nPCContextByStringId);
						InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Dialog forced closed and NPC context reset (ID: " + text + ").", Colors.Green));
					}
					else
					{
						InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Dialog closed. No NPC context found to reset.", Colors.Yellow));
					}
				}
				else
				{
					InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Dialog closed. No active NPC found to reset.", Colors.Yellow));
				}
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Dialog closed. AIInfluenceBehavior instance not found.", Colors.Yellow));
			}
		}
		catch (Exception ex)
		{
			InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Error fixing dialog: " + ex.Message, Colors.Red));
		}
	};

	[SettingPropertyGroup("{=AIInfluence_Group_Debug}Debug & Fixes", GroupOrder = 99)]
	[SettingPropertyButton("{=AIInfluence_FixPregnancy}Fix Broken Pregnancies", -1, true, "", Content = "{=AIInfluence_FixPregnancy_Button}Fix Now", Order = 0, RequireRestart = false, HintText = "{=AIInfluence_FixPregnancy_Hint}Fixes pregnancy records with missing father data (caused by intimacy with unmarried NPCs in older versions). Removes broken records and resets IsPregnant flag to prevent crash at childbirth.")]
	public Action FixBrokenPregnancies { get; set; } = delegate
	{
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		try
		{
			if (Campaign.Current == null)
			{
				InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Cannot fix: Campaign not loaded.", Colors.Red));
			}
			else
			{
				AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
				PregnancyCampaignBehavior campaignBehavior = Campaign.Current.GetCampaignBehavior<PregnancyCampaignBehavior>();
				if (campaignBehavior == null)
				{
					InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] PregnancyCampaignBehavior not found.", Colors.Red));
				}
				else
				{
					FieldInfo field = typeof(PregnancyCampaignBehavior).GetField("_heroPregnancies", BindingFlags.Instance | BindingFlags.NonPublic);
					if (field == null)
					{
						InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Could not access pregnancy data.", Colors.Red));
					}
					else if (field.GetValue(campaignBehavior) is IList { Count: not 0 } list)
					{
						Type nestedType = typeof(PregnancyCampaignBehavior).GetNestedType("Pregnancy", BindingFlags.Public | BindingFlags.NonPublic);
						if (nestedType == null)
						{
							InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Could not find Pregnancy type.", Colors.Red));
						}
						else
						{
							FieldInfo field2 = nestedType.GetField("Father", BindingFlags.Instance | BindingFlags.Public);
							FieldInfo field3 = nestedType.GetField("Mother", BindingFlags.Instance | BindingFlags.Public);
							if (field2 == null || field3 == null)
							{
								InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Could not access pregnancy fields.", Colors.Red));
							}
							else
							{
								int count = list.Count;
								List<object> list2 = new List<object>();
								foreach (object item3 in list)
								{
									object? value = field2.GetValue(item3);
									Hero val = (Hero)((value is Hero) ? value : null);
									if (val == null)
									{
										list2.Add(item3);
									}
								}
								if (list2.Count == 0)
								{
									InformationManager.DisplayMessage(new InformationMessage($"[AIInfluence] All {count} pregnancy record(s) are valid. No fix needed.", Colors.Green));
								}
								else
								{
									foreach (object item4 in list2)
									{
										object? value2 = field3.GetValue(item4);
										Hero val2 = (Hero)((value2 is Hero) ? value2 : null);
										list.Remove(item4);
										if (val2 != null)
										{
											val2.IsPregnant = false;
											instance?.LogMessage($"[FIX_PREGNANCY] Removed broken pregnancy for {val2.Name} (father was null). Reset IsPregnant.");
										}
									}
									InformationManager.DisplayMessage(new InformationMessage($"[AIInfluence] Fixed {list2.Count} broken pregnancy record(s) out of {count} total. Characters will no longer crash at childbirth.", Colors.Green));
									instance?.LogMessage($"[FIX_PREGNANCY] Fix complete. Removed {list2.Count} broken records out of {count}.");
								}
							}
						}
					}
					else
					{
						InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] No active pregnancies found. Nothing to fix.", Colors.Green));
					}
				}
			}
		}
		catch (Exception ex)
		{
			InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Error fixing pregnancies: " + ex.Message, Colors.Red));
		}
	};

	[SettingPropertyGroup("{=AIInfluence_Group_Debug}Debug & Fixes", GroupOrder = 99)]
	[SettingPropertyButton("Create Test RP Item", -1, true, "", Content = "Create Test RP Item", Order = 1, RequireRestart = false, HintText = "Creates a test RP item (letter) and adds it to player inventory")]
	public Action CreateTestRPItem { get; set; } = delegate
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		try
		{
			if (Campaign.Current == null)
			{
				InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Cannot create test item: Campaign not initialized", Colors.Red));
			}
			else
			{
				RPItemManager instance = RPItemManager.Instance;
				Hero mainHero = Hero.MainHero;
				if (instance.CreateAndGiveItemToPlayer("Тестовое письмо", "Это тестовое письмо, созданное для проверки системы RP предметов.", (mainHero != null) ? ((MBObjectBase)mainHero).StringId : null))
				{
					InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Test RP item created and added to inventory!", Colors.Green));
				}
				else
				{
					InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Failed to create test RP item. Check logs for details.", Colors.Red));
				}
			}
		}
		catch (Exception ex)
		{
			InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Error creating test item: " + ex.Message, Colors.Red));
		}
	};

	public event Action<string, object> OnSettingChanged;

	public bool CanEnableDiplomacy()
	{
		return EnableDynamicEvents && !DynamicEventsDialogueOnly;
	}

	public (bool enabled, int chance) GetEventTypeConfig(string eventType)
	{
		return eventType.ToLower() switch
		{
			"military" => (enabled: EnableMilitaryEvents, chance: MilitaryEventsChance), 
			"political" => (enabled: EnablePoliticalEvents, chance: PoliticalEventsChance), 
			"economic" => (enabled: EnableEconomicEvents, chance: EconomicEventsChance), 
			"social" => (enabled: EnableSocialEvents, chance: SocialEventsChance), 
			"mysterious" => (enabled: EnableMysteriousEvents, chance: MysteriousEventsChance), 
			"disease_outbreak" => (enabled: EnableDiseaseSystem && EnableDiseaseOutbreakEvents, chance: DiseaseOutbreakEventsChance), 
			_ => (enabled: false, chance: 0), 
		};
	}

	public Dictionary<string, int> GetEnabledEventTypes()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (EnableMilitaryEvents && MilitaryEventsChance > 0)
		{
			dictionary["military"] = MilitaryEventsChance;
		}
		if (EnablePoliticalEvents && PoliticalEventsChance > 0)
		{
			dictionary["political"] = PoliticalEventsChance;
		}
		if (EnableEconomicEvents && EconomicEventsChance > 0)
		{
			dictionary["economic"] = EconomicEventsChance;
		}
		if (EnableSocialEvents && SocialEventsChance > 0)
		{
			dictionary["social"] = SocialEventsChance;
		}
		if (EnableMysteriousEvents && MysteriousEventsChance > 0)
		{
			dictionary["mysterious"] = MysteriousEventsChance;
		}
		if (EnableDiseaseSystem && EnableDiseaseOutbreakEvents && DiseaseOutbreakEventsChance > 0)
		{
			dictionary["disease_outbreak"] = DiseaseOutbreakEventsChance;
		}
		return dictionary;
	}

	public bool HasEnabledEventTypes()
	{
		return GetEnabledEventTypes().Any();
	}

	[SettingPropertyGroup("Quest Debug", GroupOrder = 20)]
	[SettingPropertyBool("Spawn Test Quest", Order = 0, RequireRestart = false, HintText = "Spawns a test AI quest on the nearest NPC with all reward types (gold, items, skill XP, influence, hostile party). Use to verify the quest system works in-game.")]
	public bool DebugSpawnTestQuest
	{
		get => false;
		set
		{
			if (value)
			{
				this.OnSettingChanged?.Invoke("DebugSpawnTestQuest", value);
			}
		}
	}

	[SettingPropertyGroup("Quest Debug", GroupOrder = 20)]
	[SettingPropertyText("Quest Generation Prompt", 1, false, "", RequireRestart = false, HintText = "Enter a quest idea/request. Then use 'Generate Quest From Prompt' to create a quest via the AI quest-action pipeline.")]
	public string DebugQuestGenerationPrompt
	{
		get => _debugQuestGenerationPrompt;
		set => _debugQuestGenerationPrompt = value ?? "";
	}

	[SettingPropertyGroup("Quest Debug", GroupOrder = 20)]
	[SettingPropertyBool("Generate Quest From Prompt", Order = 2, RequireRestart = false, HintText = "Uses the Quest Generation Prompt text to ask the AI for a create_quest action, then immediately creates that quest on the nearest NPC.")]
	public bool DebugGenerateQuestFromPrompt
	{
		get => false;
		set
		{
			if (value)
			{
				this.OnSettingChanged?.Invoke("DebugGenerateQuestFromPrompt", value);
			}
		}
	}

	[SettingPropertyGroup("Quest Debug", GroupOrder = 20)]
	[SettingPropertyBool("View Active AI Quests", Order = 3, RequireRestart = false, HintText = "Prints all active AI quests (ID, title, giver, rewards, progress) to the game log and HUD.")]
	public bool DebugViewActiveQuests
	{
		get => false;
		set
		{
			if (value)
			{
				this.OnSettingChanged?.Invoke("DebugViewActiveQuests", value);
			}
		}
	}

	[SettingPropertyGroup("Quest Debug", GroupOrder = 20)]
	[SettingPropertyBool("Fail All Active AI Quests", Order = 4, RequireRestart = false, HintText = "Immediately fails every active AI quest. Useful for clearing stuck quests during testing.")]
	public bool DebugFailAllQuests
	{
		get => false;
		set
		{
			if (value)
			{
				this.OnSettingChanged?.Invoke("DebugFailAllQuests", value);
			}
		}
	}
}
