# 🔧 AI Influence — 技术指南

模组文件的简要说明，以及如何与它们一起工作。

---

## 📁 文件结构

```
AIInfluence DEV/
├── world.txt                        # 提供给 AI 的世界描述
├── world_secrets.json               # NPC 秘密
├── world_info.json                  # 常规信息
├── quirks.json                      # 说话习惯
├── cultural_traditions.json         # 浪漫传统
│
├── save_data/                       # 存档数据
│   └── [CAMPAIGN_ID]/               # 战役文件夹
│       ├── NPC (id).json            # 每个 NPC 的上下文
│       ├── dynamic_events.json      # 所有动态事件与外交调度（统一 v1）
│       ├── diplomatic_statements.json   # 君主声明
│       ├── alliances.json           # 王国同盟
│       ├── war_statistics.json      # 战争统计
│       ├── pending_player_statements.json # 待发布的玩家声明
│       ├── trade_agreements.json    # 贸易协定
│       ├── territory_transfers.json # 领地转移历史
│       ├── tributes.json            # 朝贡协议
│       └── reparations.json         # 王国间的赔款
│
└── logs/                            # 日志
    ├── mod_log.txt
    ├── diplomacy.txt
    └── dynamicEvents.log
```

---

## 🌍 `world.txt`

**用途:** 为 AI 提供卡拉迪亚世界的描述。

**原因:** AI 在每次对话前都会读取它以获取上下文。

**如何编辑：**
- 在 "Additional Information About Calradia:" 部分添加你的自定义世界观/背景
- 使用 `{Character}` 和 `{Player}` 代替具体姓名
- 使用英文书写
- 保存 → 文件会被自动热重载

---

## 🔐 `world_secrets.json`

**用途:** NPC 可能掌握的秘密知识。

**格式:**
```json
[
  {
    "id": "unique_id",
    "description": "Description for AI",
    "knowledgeChance": 50,
    "applicableNPCs": ["lords"],
    "accessLevel": "high",
    "tags": ["optional"]
  }
]
```

**工作方式：**
1. 与 NPC 第一次交互时，掷一次 0–100 的骰子
2. 如果结果 ≤ `knowledgeChance` → 该 NPC 获得此秘密
3. 秘密会被加入到提示词中：`"Secrets: ... (access: high)"`
4. 是否说出秘密由 AI 决定（取决于信任等因素）

**重要:** 必须使用 `knowledgeChance`，不要使用 `usageChance`！

---

**字段说明：**
- `id` — 唯一名称
- `description` — 完整文本（会传入 AI 提示词）
- `knowledgeChance` — 0–100 的几率，表示 NPC 在第一次接触时学会这个秘密
- `applicableNPCs` — 类型：`all`, `lords`, `companions`, `faction_leaders`, `village_notables`, `merchants`
- `accessLevel` — `low`, `medium`, `high`（会在提示词中显示）
- `tags` — 用于分类/组织（不影响逻辑）

## 📰 `world_info.json`

**用途:** 公开信息（不是秘密）。

**格式:**
```json
[
  {
    "id": "unique_id",
    "description": "Description (可以使用 {character})",
    "usageChance": 75,
    "applicableNPCs": ["all"], (类型: `all`, `lords`, `companions`, `faction_leaders`, `village_notables`, `merchants`)
    "category": "world"
  }
]
```

**字段说明：**
- `usageChance` — 0–100 的几率（用法与 knowledgeChance 类似）
- `category` — `world`（持续性），`event`（临时性），`personal`（个人向）

**与 secrets 的区别：**
- 概率字段：`usageChance` vs `knowledgeChance`
- 分类字段：`category` vs `accessLevel`
- 在提示词中：`"General Info: ..."` vs `"Secrets: ... (access: high)"`

---

## 🗣️ `quirks.json`

**用途:** NPC 的说话习惯列表。

**格式:**
```json
[
  "speaks briefly and avoids unnecessary words",
  "uses hunting, battle, or military analogies",
  "questions others like a quiet interrogator"
]
```

**工作方式：**
- NPC 创建时会随机获得 1–2 条说话习惯
- 这些内容会加到提示词中：`"Speech Quirks: ..."`
- AI 会根据这些习惯调整语言风格

**自定义:** 直接在数组中增加字符串条目即可。

---

## 💕 `cultural_traditions.json`

**用途:** 各个文化的浪漫/求爱传统。

**格式:**
```json
{
  "Aserai": "Description of romantic traditions...",
  "Battania": "..."
}
```

**影响:** 调情风格和关系需求门槛。

---

## 💾 NPC 文件: `save_data/[CAMPAIGN_ID]/Name (id).json`

**主要字段：**

| 字段 | 作用 | 是否允许编辑 |
|------|------|--------------|
| `CharacterDescription` | 性格描述 | ✅ 可以 |
| `KnownSecrets` | 已知秘密 | ✅ 可以（会设置标记） |
| `KnownInfo` | 已知信息 | ✅ 可以（会设置标记） |
| `ConversationHistory` | 对话历史 | ❌ 系统自动维护 |
| `DynamicEvents` | 已知的动态事件 | ❌ 系统自动维护 |
| `Quirks` | 说话习惯 | ⚠️ 会被系统覆盖 |

此外你还会看到一些服务字段：

- `KnownSecretsUserEdited` / `KnownInfoUserEdited` — 标记对应知识是否被玩家编辑过（如果为 `true`，系统将不再自动修改这些数组）
- `DynamicEvents` / `LastEventAnalysisMessageIndex` — NPC 已知的动态事件，以及已发送给分析的消息索引
- `AIGeneratedPersonality` / `AIGeneratedBackstory` — 系统自动生成的人格与背景描述
- 恋爱相关字段（`RomanceLevel`, `LastRomanceInteractionDays`, `IsRomanceEligible`）以及战斗相关字段（`SettlementCombatInfo`）— 只由系统管理

**建议:** 如果你不完全理解某个服务字段的用途，请不要编辑它，否则可能破坏系统逻辑。

**编辑知识字段：**

在你修改 `KnownSecrets` 或 `KnownInfo` 之后：
```json
"KnownSecrets": ["My_Custom_Secret"],
"KnownSecretsUserEdited": false  // ← 会自动变为 true
```

当标记 `UserEdited: true` 时 → 系统将不再修改该字段。

**重置标记：** MCM → NPC Management → Reset User‑Edited Knowledge

---

## 📋 `dynamic_events.json`

**用途:** 动态事件目录与外交附带的调度数据（统一格式 v1）。

**外层（v1）：**
- `format_version` — `1`
- `events` — 事件对象数组
- `campaign_days`、`save_time` — 记录用
- 可选外交字段：`statement_schedules`、`analysis_schedules`、`statement_queues`、`pending_statements`（与旧版独立外交事件文件作用相同）

**事件对象重要字段：**
- `type` — `military`, `political`, `economic`, `social`, `mysterious`
- `importance` — 1–10（事件重要程度）
- `kingdoms_involved` — 参与王国的 `string_id` 数组
- `allows_diplomatic_response` — 是否允许统治者发表外交声明
- `expiration_campaign_days` — 事件在多少战役日后过期
- `storage_tags` — 可选：`dynamic`（动态事件管线）、`diplomatic`（外交活跃切片）；可同时存在

其他字段：
- `id` — 事件唯一标识符（字符串，NPC 在 `DynamicEvents` 中通过该 ID 存储他们的认知）
- `player_involved` — 玩家是否参与事件
- `spread_speed` — 事件传播速度

**迁移：** 若仍存在旧版 `diplomatic_events.json`，加载时会合并进本文件并删除旧文件。

**与 NPC 的关联：**  
每个 `NPC (id).json` 文件中都有一个 `DynamicEvents` 数组，用来存储该 NPC 知道哪些事件。`DynamicEventsManager` 会自动更新这些字段并从 NPC 处移除过期事件。

**编辑建议:** 不推荐手动编辑（由系统自动管理）。

---

## 💬 `diplomatic_statements.json`

**用途:** 各王国统治者的外交声明。

**结构:**
```json
{
  "kingdom_id": "battania",
  "statement_text": "声明内容",
  "action": "None/DeclareWar/ProposePeace/...",
  "target_kingdom_id": "khuzait",
  "reason": "原因说明",
  "event_id": "关联的事件 ID"
}
```

**存储规则:** 仅保存最近 50 个游戏日内的 15 条声明。

**编辑:** 无需编辑（完全由系统自动维护）。

---

## 🤝 其它外交相关文件

下面所有文件都位于 `save_data/[CAMPAIGN_ID]/`，并由外交系统自动管理。

- `pending_player_statements.json` — 将在未来发布的玩家声明
- `trade_agreements.json` — 王国之间现有的贸易协定
- `territory_transfers.json` — 王国之间领地转移的历史
- `tributes.json` — 朝贡协议数据
- `reparations.json` — 赔款数据（历史与未完成的赔偿要求）

**规则:** 这些文件都是给系统用的。除非你非常清楚后果（例如在调试），否则不要编辑它们；编辑前务必做好备份。

## 📊 日志

### `logs/mod_log.txt` — 主日志
- 模组初始化
- 配置加载
- AI 提示词与回复
- API 错误

**可以在以下情况查看：**
- NPC 没有回答
- 秘密没有被加载
- 游戏中出现错误

### `logs/diplomacy.txt` — 外交日志
- 外交系统初始化
- 外交局势与声明的创建
- 外交事件分析（包括完整提示词与 AI 回复）
- 行动执行（宣战、求和、结盟、关系变化）
- 外交系统的错误与警告

### `logs/dynamicEvents.log` — 动态事件日志
- 事件生成（开启详细调试后包含完整提示词与 AI 回复）
- 事件向 NPC 传播（谁知道、谁不知道以及原因）
- 过期事件的删除与 NPC 知识清理

---

## 🛠️ 常见操作

### 添加一个秘密
1. 打开 `world_secrets.json`
2. 在数组中添加一个对象：
```json
{
  "id": "My_Secret",
  "description": "Secret text here",
  "knowledgeChance": 100,
  "applicableNPCs": ["lords"],
  "accessLevel": "high",
  "tags": []
}
```
3. 保存 → 会自动热重载

### 将秘密赋给特定 NPC
1. 打开 `save_data/[ID]/NPC_name (id).json`
2. 找到 `KnownSecrets`
3. 添加秘密 ID：
```json
"KnownSecrets": ["My_Secret", "Another_Secret"]
```
4. 保存 → `UserEdited` 标记会自动设置。如果由于某些原因没有设置，请手动将其设为 `true`。

### 修改 NPC 性格
1. 打开该 NPC 文件
2. 修改：
```json
"CharacterDescription": "你的性格描述",
```
3. 保存

### 获取战役 ID
1. 打开 `logs/mod_log.txt`
2. 找到类似的行：
```
Created save directory: ...\save_data\b7ed0c2f2399
                                       ^^^^^^^^^^^^ ID
```

或者：MCM → Debug → Show Save Folder Info

### 重置 NPC 数据
**方式 1:** 清除所有 NPC 数据
- MCM → NPC Management → Clear Current Campaign NPC Data

**方式 2:** 删除单个 NPC
- MCM → NPC Management → Erase Specific NPC

**方式 3:** 手动删除
- 删除文件 `save_data/[ID]/NPC_name.json`

```

---

## ⚠️ 重要规则

### JSON 文件
✅ 修改后务必检查是否是合法 JSON（例如：jsonlint.com）  
✅ 在编辑前先做好备份  
✅ 不要删除必要字段  
❌ 非必要情况下不要编辑 `dynamic_events.json` 和 `diplomatic_statements.json`

### Secrets vs Info
- `world_secrets.json` → 概率字段为 `knowledgeChance`
- `world_info.json` → 概率字段为 `usageChance`
- **不要搞混！** 否则数值会被视为 0。

### 热重载
以下文件会被自动热重载：
- ✅ `world.txt`
- ✅ `world_secrets.json`
- ✅ `world_info.json`
- ✅ `quirks.json`
- ✅ `cultural_traditions.json`

NPC 文件会在下次与该 NPC 交互时重新加载。

### 编辑标记
如果你编辑了 `KnownSecrets` 或 `KnownInfo`：
- 标记 `UserEdited` 会自动变为 `true`
- 系统将不再自动修改这些字段
- 重置方式：MCM → Reset User‑Edited Knowledge


---

## 🔄 工作流程

### 添加新内容

1. **先构思内容**（秘密、事件、任务等）
2. **写入 JSON**（`world_secrets.json` 或 `world_info.json`）
3. **保存文件** → 自动热重载
4. **创建新 NPC** 或重置已有 NPC
5. **开始对话** → AI 会知道这些新内容

### 测试秘密是否工作

1. 添加一个 `knowledgeChance: 100` 的秘密
2. 创建一个新 NPC 或重置已有 NPC
3. 与其开始对话
4. 在日志中检查：`[NPC] Name learned secret: ...`
5. 直接向 NPC 询问此秘密

### 调试事件系统

1. 在 MCM 中启用详细日志
2. 通过 Force Generate Event 创建事件
3. 查看 `logs/dynamicEvents.log`
4. 检查哪些 NPC 收到事件以及原因

---

## 📌 速查表

### `applicableNPCs` 可用 NPC 类型
```
"all"              — 所有 NPC
"lords"            — 领主
"companions"       — 同伴
"faction_leaders"  — 派系统治者
"village_notables" — 村庄名流
"merchants"        — 商人
```

### 事件类型
```
"news"        — 重要消息
"political"   — 外交/政治
"military"    — 战争与战斗
"economic"    — 经济与贸易
"local"       — 本地事件
"rumor"       — 流言蜚语
```

### 外交行动类型
```
"None"            — 仅为声明
"DeclareWar"      — 宣战
"ProposePeace"    — 提议和平
"AcceptPeace"     — 接受和平
"RejectPeace"     — 拒绝和平
"ProposeAlliance" — 提议结盟
"AcceptAlliance"  — 接受结盟
"RejectAlliance"  — 拒绝结盟
"BreakAlliance"   — 解除同盟
```

---

## 🎯 关键区别

| 方面 | Secrets | Info |
|------|---------|------|
| **文件** | `world_secrets.json` | `world_info.json` |
| **概率字段** | `knowledgeChance` | `usageChance` |
| **分类方式** | `accessLevel` + `tags` | `category` |
| **用途** | 需要信任的秘密信息 | 公共信息 |

---



