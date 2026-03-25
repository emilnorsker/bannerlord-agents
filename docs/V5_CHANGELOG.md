# Mod v5.0.0 — change summary (developers)

This version is **not** save-compatible with earlier mod releases. Use **new campaigns** for supported behavior.

## Dynamic events

- **Single file:** `save_data/<campaign_id>/dynamic_events.json` as **format_version `2`** envelope (`events`, optional diplomacy schedules/queues).
- **No legacy load:** Bare JSON arrays, `diplomatic_events.json`, and `format_version` ≠ `2` result in an **empty** in-memory catalog (logged).
- **NPC knowledge:** `DynamicEventsManager.GetEventsForNPC` requires the **canonical** `NPCContext` from `AIInfluenceBehavior` (see `TECHNICAL_GUIDE.en.md`). UI should use `WorldEventsReadFacade.GetEventsKnownToNpcForUi`.

## Removed systems

- **Arena training** (behaviors, notifications, related UI).
- **Disease** module and related patches / dynamic-event disease types.

## Embedded save (SyncData)

- Failed **NPC context** deserialization or outer **SyncData** failure on load **throws** (no silent reset to empty state) for the behaviors adjusted in v5.

## Version display

- `SubModule.xml` version **v5.0.0**; in-game load banners show the same.
