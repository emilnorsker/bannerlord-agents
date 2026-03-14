// These global using static directives bring nested types into scope by their simple name.
// The game engine defines many detail/enum types as nested inside their action/event classes.
// Decompiled source uses the simple names directly; these imports make that valid with
// modern Roslyn, which requires explicit qualification otherwise.

global using static TaleWorlds.CampaignSystem.Actions.ChangeKingdomAction;
global using static TaleWorlds.CampaignSystem.Actions.ChangeOwnerOfSettlementAction;
global using static TaleWorlds.CampaignSystem.Actions.ChangeRelationAction;
global using static TaleWorlds.CampaignSystem.Actions.DeclareWarAction;
global using static TaleWorlds.CampaignSystem.Actions.KillCharacterAction;
global using static TaleWorlds.CampaignSystem.Actions.MakePeaceAction;
global using static TaleWorlds.CampaignSystem.Actions.TeleportHeroAction;
global using static TaleWorlds.CampaignSystem.CampaignTime;
global using static TaleWorlds.CampaignSystem.ComponentInterfaces.MapWeatherModel;
global using static TaleWorlds.CampaignSystem.ComponentInterfaces.SettlementAccessModel;
global using static TaleWorlds.CampaignSystem.MapEvents.MapEvent;
global using static TaleWorlds.CampaignSystem.Party.MobileParty;
global using static TaleWorlds.MountAndBlade.Agent;
global using static TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual.ActionVisualOrder;
global using static HarmonyLib.AccessTools;
global using static TaleWorlds.CampaignSystem.CharacterDevelopment.DefaultPerks;
global using static TaleWorlds.CampaignSystem.GameMenus.GameMenu;
global using static TaleWorlds.CampaignSystem.GameMenus.GameMenuOption;
global using static TaleWorlds.CampaignSystem.Romance;
global using static TaleWorlds.CampaignSystem.Settlements.Locations.LocationCharacter;
global using static TaleWorlds.CampaignSystem.Settlements.Village;
global using static TaleWorlds.Core.ItemObject;
global using static TaleWorlds.Core.ViewModelCollection.Information.TooltipProperty;
global using static TaleWorlds.Library.Debug;
global using Extensions = TaleWorlds.Library.Extensions;
global using Path = System.IO.Path;
global using FaceGen = TaleWorlds.Core.FaceGen;
