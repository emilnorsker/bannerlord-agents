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
