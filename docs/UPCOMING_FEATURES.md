# Upcoming features (not implemented)

## Encyclopedia: “Conversations” hub

**Idea:** Add a top-level category on the campaign encyclopedia home (alongside heroes, clans, etc.) — e.g. **Conversations** — that lists NPCs the player can revisit for AI chat, similar to bookmarks but first-class in the wiki UI.

**Why not bookmarks today:** Vanilla encyclopedia bookmarks are driven from `EncyclopediaPageVM.ExecuteSwitchBookmarkedState`, which talks to `Campaign.EncyclopediaManager` methods that are **not part of the public modding surface** in the shipped API docs (`GoToLink`, `GetPageOf`, … only). Calling `AddEncyclopediaBookmarkToItem` / `RemoveEncyclopediaBookmarkFromItem` requires reflection or Harmony on internals — fragile and easy to break on game updates. The “native” path is to stay inside TaleWorlds’ encyclopedia stack (custom page VM + prefab), not to poke private manager APIs from a standalone Gauntlet movie.

### Caveats (must be designed explicitly)

1. **Active conversation gate**  
   The mod must **not** allow sending chat messages to arbitrary NPCs just because they appear in the encyclopedia list. Sending should remain tied to **valid campaign context** (e.g. current dialog, messenger, party encounter, or whatever rules `AIInfluence` already uses). A wiki entry is only a **navigation affordance** unless you add explicit remote-chat semantics (which is a larger design).

2. **Screen / layer stack**  
   Opening the full encyclopedia while NPC chat is open raises UX questions: which layer stays on top, who owns input, and how the player returns to chat. Today, NPC chat is its own `GauntletLayer`; encyclopedia is another UI. Any integration should define **open / close / back** behavior so players are never stuck or double-processing input.

3. **Implementation scope (SandBox / Gauntlet)**  
   A real category requires extending SandBox encyclopedia data (list items, filters, home tiles) and likely new Gauntlet prefabs or `PrefabExtension`s — similar in effort to a new encyclopedia page type, not a one-line hook.

4. **Persistence**  
   “Who appears under Conversations” needs a clear rule: last N talked-to heroes, manual pin, quest-linked NPCs, etc., and save compatibility.

5. **Multiplayer / future API**  
   If TaleWorlds ever exposes bookmark (or “favorite”) APIs on `EncyclopediaManager` publicly, reassess whether to reuse that instead of a custom category.

---

*Last updated with removal of in-chat encyclopedia bookmark button + reflection helper (prefer documented APIs or in-stack UI extensions).*
