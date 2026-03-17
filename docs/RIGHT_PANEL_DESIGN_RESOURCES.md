# Right Panel Design Resources — Crowlands Project

This document specifies design resources to source from the **Crowlands** Figma project for implementing the conversation right panel (character info + world events).

---

## Target Design (from reference)

The right panel should match the Bannerlord-style UI:

- **Layout**: Vertical panel (~300px wide), dark background, gold/bronze accents
- **Header**: "Character" with folder/person icon, close (X) button
- **Sections**:
  1. **Character Info** — Gold on hand, Relation (gradient bar), Times met, Known for, Wealthy
  2. **Recent World Events** — Event cards with icon, description, location/time

---

## Crowlands Resources to Find in Figma

### 1. Color Tokens
- **Gold accent**: `#FFE6B685` (or similar) — headers, icons, highlights
- **Subtext**: `#9BA4B5FF` — secondary labels
- **Relation positive**: `#6FCF6FFF` (green)
- **Relation negative**: `#CF6F6FFF` (red)
- **Cautious/warning**: `#D0A96BFF` (orange)
- **Background dark**: `#0A0A0A`, `#1A120DFF`, `#130D09FF`
- **Separator**: `#FFFFFF22`

### 2. Typography
- **Section headers**: ~18px, gold
- **Body text**: ~13–16px, light grey/white
- **Labels**: smaller, subtext color

### 3. Icons (gold, consistent style)
- Gold bag / coin — Gold on hand
- Magnifying glass — Relation indicator
- Crossed weapons — Times met
- Lightbulb — Known for
- Crown / wealth — Wealthy
- Raiding / broken sword — Raid events
- Castle / fort — Siege/capture events
- Castle with checkmark — Successful siege
- Folder / person — Character section header

### 4. Components
- **Relation bar**: Horizontal gradient (green "Cold" → yellow-orange "Friendly") with draggable indicator
- **Event card**: Icon + title + location/time
- **Section divider**: Thin gold or grey line
- **Close button**: Standard X, gold or white

### 5. Layout / Spacing
- Panel width: 300px (matches `Right.W` in ChatInterface.xml)
- Section spacing: ~8–12px
- Card padding: ~12px
- Icon + text row height: ~24–32px

---

## Current Implementation (codebase)

- **ChatInterface.xml**: Right column 300px, `RightPanelItems` list, "Diplomacy & Relation" header
- **NpcChatWindowVM.cs**: `PopulateRightPanel` — flat list with WORLD EVENTS, WHAT WE KNOW, CHARACTER sections
- **Brushes**: `Encyclopedia.Frame`, `Encyclopedia.TopBanner`, `SPScoreboard.Subtitle.Text`, `Conversation.HeaderText`

---

## Enabling Figma Access

To pull resources from Crowlands in Figma:

1. **Install Figma MCP** — e.g. `npx figma-developer-mcp --figma-api-key=<your-api-key>` or use the official Figma Dev Mode MCP.
2. **Configure in Cursor** — Add the MCP server in Cursor Settings → MCP.
3. **Open Crowlands** — In Figma, open the Crowlands project and the relevant frames (Character panel, World events, icons).
4. **Query** — Once connected, ask for: **Crowlands**, **Character panel**, **World events**, **Gold icons**, **Relation bar**.

---

## File Paths for Implementation

- GUI: `GUI/Prefabs/ChatInterface.xml`
- ViewModel: `src/AIInfluence/NpcChatWindowVM.cs`
- Existing brushes: `GUI/Brushes/PopUpBrush.xml`, `GUI/Brushes/` (Bannerlord sprites)
