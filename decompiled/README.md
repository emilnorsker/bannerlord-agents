# Decompiled Bannerlord assemblies (this branch)

This directory exists on the **`random_logs`** branch as a **read-only reference** for agents and developers (Gauntlet bindings, ViewModels, widgets).

- **Do not merge** this tree into normal feature PRs. Keep bulk decompiles here or regenerate locally when needed.
- **Sources:** Decompiled from game/SDK managed DLLs (ILSpy / `ilspycmd`).
- **Quick lookups:**
  - `HeroViewModel` → search `**/HeroViewModel.cs` under `TaleWorlds.CampaignSystem.ViewModelCollection`
  - `CharacterViewModel` / `BodyProperties` → `TaleWorlds.Core.ViewModelCollection`
  - `EncyclopediaCharacterTableauWidget` → `TaleWorlds.MountAndBlade.GauntletUI.Widgets` (Encyclopedia subfolder)
- **Smaller DLL mirror for CI** (not a full tree): `.github/workflows/dlls/`

Project policy is documented in **`agents.md`** at the repo root.
