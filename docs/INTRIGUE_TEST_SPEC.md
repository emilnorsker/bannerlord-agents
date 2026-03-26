# AI Influence — World system test specification

**Audience:** Engineers running regression against slices I-01 through I-12.

---

## Automated tests

All tests live in `tests/AIInfluence.WorldSystem.Tests/`. Run with:

```
dotnet test tests/AIInfluence.WorldSystem.Tests/AIInfluence.WorldSystem.Tests.csproj
```

| TC | Slice | Test class | Count | What it covers |
|----|-------|-----------|-------|----------------|
| TC-01 | I-01 | `PlotInstancePersistenceTests` | 3 | Round-trip, null optionals, stable id/phase strings |
| TC-02 | I-01 | `IntrigueStoreTests` | 6 | Add/get, serialize/deserialize, empty/null JSON |
| TC-03 | I-02 | `RuntimeSecretStoreTests` | 3 | Add/get, unknown id, round-trip |
| TC-04 | I-02 | `SecretResolverTests` | 4 | Runtime-first, catalog-fallback, both-exist, unknown-id-logs-error |
| TC-05 | I-02 | `IntrigueStoreSecretsTests` | 1 | Runtime secrets survive IntrigueStore round-trip |
| TC-06 | I-03 | `EventDiaryTests` | 7 | Append ordering, GetTail, round-trip, refs, immutability |
| TC-07 | I-03 | `PatternMatcherTests` | 11 | Single/consecutive/non_consecutive, wildcards, negated, empty |
| TC-08 | I-03 | `EpisodeTests` | 4 | Resolution round-trip, episode round-trip, evaluate match/no-match |
| TC-09 | I-03 | `PlotTemplateTests` | 3 | PlotStep/PlotTemplate/PlotEffect round-trip |
| TC-10 | I-03 | `StepExecutorTests` | 7 | EmitSecret, EmitPlotPoint, AdvancePlotPhase, failed requires, idempotency, completion, multi-effects |
| TC-11 | I-03 | `PatternLibraryTests` | 4 | FromJson, registry get, unknown template, round-trip |
| TC-12 | I-03 | `IntrigueStoreDiaryTests` | 1 | EventDiary survives IntrigueStore round-trip |
| TC-13 | I-04 | `PlotSchedulerTests` | 5 | Matching trigger, non-matching, idempotency, correlation logs, inactive skip |
| TC-14 | I-05 | `WorldSnapshotBuilderTests` | 4 | Active plots filter, recent diary tail, secret count, serialization |
| TC-15 | I-06 | `HookStoreTests` | 4 | Add, get by target, get by owner, round-trip |
| TC-16 | I-06 | `RecallPhraseTests` | 2 | Round-trip, visibility filter |
| TC-17 | I-07 | `ProposalValidatorTests` | 5 | Valid proposal, invalid JSON, unknown plot, unknown op, commit |
| TC-18 | I-08 | `DialoguePathAuditTests` | 4 | No mutation from invalid proposals, unknown plot no phase advance |
| TC-19 | I-09 | `PlotLifecycleTests` | 4 | Cap reject, cap after expiry, expiry sets status, no-deadline safe |
| TC-20 | I-11 | `BeliefMatrixTests` | 6 | Diagonal, off-diagonal, unknown, propagation, round-trip, partial |
| TC-21 | I-12 | `ExecutionGuardTests` | 3 | Preconditions hold, preconditions fail + replan, no precondition |

**Total: 91 automated tests.**

---

## Manual tests (in-game)

### Prerequisites

- Bannerlord v1.3.x with AIInfluence mod loaded.
- MCM mod settings accessible.

### MT-01: Debug plot creation (I-01)

1. Open MCM > AI Influence > Debug & Fixes.
2. Toggle "Debug: Write Test Plot".
3. **Expected:** HUD message `[WorldSystem] Debug plot created: debug_plot_...` with incrementing count.
4. Save the game.
5. Load the save.
6. Toggle "Debug: Write Test Plot" again.
7. **Expected:** Count is previous count + 1 (persistence round-tripped).

### MT-02: Runtime secret in prompt (I-02)

1. Via code or debug tool, add a runtime secret to IntrigueStore.RuntimeSecrets for an NPC's KnownSecrets list.
2. Open chat with that NPC.
3. **Expected:** The secret description appears in the NPC's prompt (visible in debug log if enabled).

---

## Sign-off

| Run | Date | Runner | Result | Notes |
|-----|------|--------|--------|-------|
| | | | | |
