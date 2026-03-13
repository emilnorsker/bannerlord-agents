# 🔧 AI Influence — Техническое руководство

Краткое описание файлов мода и как с ними работать.

---

## 📁 Структура файлов

```
AIInfluence DEV/
├── world.txt                        # Описание мира для AI
├── world_secrets.json               # Секреты NPC
├── world_info.json                  # Общая информация
├── quirks.json                      # Речевые манеры
├── cultural_traditions.json         # Романтические традиции
│
├── save_data/                       # Данные сохранений
│   └── [CAMPAIGN_ID]/               # Папка кампании
│       ├── NPC (id).json            # Контекст каждого NPC
│       ├── dynamic_events.json      # Активные динамические события
│       ├── diplomatic_statements.json   # Заявления правителей
│       ├── alliances.json           # Альянсы королевств
│       ├── war_statistics.json      # Статистика войн
│       ├── diplomatic_events.json   # Активные дипломатические события
│       ├── pending_player_statements.json # Отложенные заявления игрока
│       ├── trade_agreements.json    # Торговые соглашения
│       ├── territory_transfers.json # История передачи территорий
│       ├── tributes.json            # Соглашения о дани
│       └── reparations.json         # Репарации между королевствами
│
└── logs/                            # Логи
    ├── mod_log.txt
    ├── diplomacy.txt
    └── dynamicEvents.log
```

---

## 🌍 `world.txt`

**Что:** Описание мира Кальрадии для AI.

**Зачем:** AI читает при каждом диалоге для контекста.

**Как редактировать:**
- Добавьте свой лор в секцию "Additional Information About Calradia:"
- Используйте `{Character}` и `{Player}` вместо конкретных имён
- Пишите на английском
- Сохраните → файл перезагрузится автоматически

---

## 🔐 `world_secrets.json`

**Что:** Секретные знания, которые могут быть у NPC.

**Формат:**
```json
[
  {
    "id": "unique_id",
    "description": "Описание для AI",
    "knowledgeChance": 50,
    "applicableNPCs": ["lords"],
    "accessLevel": "high",
    "tags": ["optional"]
  }
]
```

**Как работает:**
1. При первом взаимодействии бросается кубик 0-100
2. Если ≤ `knowledgeChance` → NPC узнаёт секрет
3. Секрет добавляется в промпт: `"Secrets: ... (access: high)"`
4. AI решает, раскрывать или нет (зависит от доверия)

**Важно:** Используйте `knowledgeChance`, НЕ `usageChance`!

---

**Поля:**
- `id` — уникальное имя
- `description` — полный текст (передаётся в промпт AI)
- `knowledgeChance` — шанс 0-100, что NPC узнает при первом контакте
- `applicableNPCs` — типы: `all`, `lords`, `companions`, `faction_leaders`, `village_notables`, `merchants`
- `accessLevel` — `low`, `medium`, `high` (показывается в промпте)
- `tags` — для организации (не влияет на логику)

## 📰 `world_info.json`

**Что:** Общедоступная информация (не секреты).

**Формат:**
```json
[
  {
    "id": "unique_id",
    "description": "Описание ({character} можно использовать)",
    "usageChance": 75,
    "applicableNPCs": ["all"], (типы: `all`, `lords`, `companions`, `faction_leaders`, `village_notables`, `merchants`)
    "category": "world"
  }
]
```

**Поля:**
- `usageChance` — шанс 0-100 (работает как knowledgeChance)
- `category` — `world` (постоянное), `event` (временное), `personal` (личное)

**Отличия от secrets:**
- Поле: `usageChance` vs `knowledgeChance`
- Категория: `category` vs `accessLevel`
- В промпте: "General Info: ..." vs "Secrets: ... (access: high)"

---

## 🗣️ `quirks.json`

**Что:** Список речевых манер для NPC.

**Формат:**
```json
[
  "speaks briefly and avoids unnecessary words",
  "uses hunting, battle, or military analogies",
  "questions others like a quiet interrogator"
]
```

**Как работает:**
- NPC получает 1-2 случайные манеры при создании
- Добавляются в промпт: `"Speech Quirks: ..."`
- AI использует для стиля речи

**Кастомизация:** Просто добавьте строки в массив.

---

## 💕 `cultural_traditions.json`

**Что:** Романтические традиции для каждой культуры.

**Формат:**
```json
{
  "Aserai": "Description of romantic traditions...",
  "Battania": "..."
}
```

**Влияет:** На стиль флирта и требования к отношениям.

---

## 💾 Файлы NPC: `save_data/[CAMPAIGN_ID]/Name (id).json`

**Основные поля:**

| Поле | Что делает | Можно редактировать |
|------|-----------|---------------------|
| `CharacterDescription` | Описание характера | ✅ ДА |
| `KnownSecrets` | Известные секреты | ✅ ДА (ставит флаг) |
| `KnownInfo` | Известная информация | ✅ ДА (ставит флаг) |
| `ConversationHistory` | История диалогов | ❌ Автоматически |
| `DynamicEvents` | Известные события | ❌ Автоматически |
| `Quirks` | Манеры речи | ⚠️ Перезапишутся |

Дополнительно вы можете увидеть служебные поля:

- `KnownSecretsUserEdited` / `KnownInfoUserEdited` — флаги, что знания были отредактированы пользователем (если `true`, система больше не меняет эти массивы)
- `DynamicEvents` / `LastEventAnalysisMessageIndex` — какие динамические события известны NPC и какие сообщения уже отправлялись в анализ
- `AIGeneratedPersonality` / `AIGeneratedBackstory` — автогенерируемое описание личности и предыстории
- Поля романтики (`RomanceLevel`, `LastRomanceInteractionDays`, `IsRomanceEligible`) и боевых ситуаций (`SettlementCombatInfo`) — управляются только системой

**Рекомендация:** если вы не полностью понимаете назначение служебного поля, не редактируйте его — это может нарушить работу системы.

**Редактирование знаний:**

После изменения `KnownSecrets` или `KnownInfo`:
```json
"KnownSecrets": ["My_Custom_Secret"],
"KnownSecretsUserEdited": false  // ← Автоматически станет true
```

Флаг `UserEdited: true` → система не будет трогать это поле.

**Сброс флагов:** MCM → NPC Management → Reset User-Edited Knowledge

---

## 📋 `dynamic_events.json`

**Что:** Активные мировые события.

**Важные поля:**
- `type` — `military`, `political`, `economic`, `social`, `mysterious`
- `importance` — 1-10 (насколько важно)
- `kingdoms_involved` — массив kingdom string_id
- `allows_diplomatic_response` — разрешить заявления правителей
- `expiration_campaign_days` — когда истекает

Дополнительно в событиях есть:
- `id` — уникальный идентификатор события (строка, по нему NPC хранят знание в `DynamicEvents`)
- `player_involved` — участвовал ли игрок
- `spread_speed` — скорость распространения

**Связь с NPC:**  
Список известных событию NPC хранится в каждом `NPC (id).json` в массиве `DynamicEvents`. `DynamicEventsManager` сам обновляет эти поля и удаляет просроченные события у NPC.

**Редактирование:** Не рекомендуется (управляется автоматически).

---

## 💬 `diplomatic_statements.json`

**Что:** Заявления правителей королевств.

**Структура:**
```json
{
  "kingdom_id": "battania",
  "statement_text": "Текст заявления",
  "action": "None/DeclareWar/ProposePeace/...",
  "target_kingdom_id": "khuzait",
  "reason": "Причина",
  "event_id": "событие, к которому относится"
}
```

**Хранение:** Последние 15 заявлений за 50 игровых дней.

**Редактирование:** Не нужно (автоматическая система).

---

## 🤝 Дополнительные дипломатические файлы

Все файлы ниже лежат в `save_data/[CAMPAIGN_ID]/` и управляются системой дипломатии автоматически.

- `diplomatic_events.json` — активные дипломатические события, связанные с динамическими событиями (`DynamicEvents`)
- `pending_player_statements.json` — отложенные заявления игрока, которые будут опубликованы позже
- `trade_agreements.json` — текущие торговые соглашения между королевствами
- `territory_transfers.json` — история передачи владений между королевствами
- `tributes.json` — соглашения о выплате дани
- `reparations.json` — данные о репарациях (история и незакрытые требования)

**Правило:** все эти файлы предназначены для автоматической работы системы. Редактируйте их только если точно понимаете последствия (для отладки), перед этим делайте бэкап.

## 📊 Логи

### `logs/mod_log.txt` — основной лог
- Инициализация мода
- Загрузка конфигов
- Промпты и ответы AI
- Ошибки API

**Смотрите при:**
- NPC не отвечает
- Секреты не загружаются
- Ошибки в игре

### `logs/diplomacy.txt` — дипломатия
- Инициализация дипломатической системы
- Создание дипломатических ситуаций и заявлений
- Анализ дипломатических событий (полные промпты и ответы AI)
- Выполнение действий (войны, мир, альянсы, изменение отношений)
- Ошибки и предупреждения системы дипломатии

### `logs/dynamicEvents.log` — динамические события
- Генерация событий (включая полный промпт и ответ AI при детальной отладке)
- Распространение событий к NPC (кто узнал, кто нет, и почему)
- Удаление устаревших событий и очистка знаний NPC

---

## 🛠️ Частые задачи

### Добавить секрет
1. Откройте `world_secrets.json`
2. Добавьте объект в массив:
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
3. Сохраните → перезагрузится автоматически

### Дать секрет конкретному NPC
1. Откройте `save_data/[ID]/NPC_name (id).json`
2. Найдите `KnownSecrets`
3. Добавьте ID секрета:
```json
"KnownSecrets": ["My_Secret", "Another_Secret"]
```
4. Сохраните → флаг `UserEdited` поставится автоматически. Если по какой то приичине он не установился, установите его вручную.

### Изменить характер NPC
1. Откройте файл NPC
2. Измените:
```json
"CharacterDescription": "Ваше описание характера",
```
3. Сохраните

### Узнать ID кампании
1. Откройте `logs/mod_log.txt`
2. Найдите строку:
```
Created save directory: ...\save_data\b7ed0c2f2399
                                       ^^^^^^^^^^^^ ID
```

Или: MCM → Debug → Show Save Folder Info

### Сбросить данные NPC
**Вариант 1:** Удалить всех
- MCM → NPC Management → Clear Current Campaign NPC Data

**Вариант 2:** Удалить одного
- MCM → NPC Management → Erase Specific NPC

**Вариант 3:** Вручную
- Удалите файл `save_data/[ID]/NPC_name.json`

```

---

## ⚠️ Важные правила

### JSON файлы
✅ Всегда проверяйте валидность (jsonlint.com)  
✅ Делайте бэкапы перед редактированием  
✅ Не удаляйте обязательные поля  
❌ Не редактируйте `dynamic_events.json` и `diplomatic_statements.json` без необходимости

### Секреты vs Информация
- `world_secrets.json` → поле `knowledgeChance`
- `world_info.json` → поле `usageChance`
- **НЕ ПУТАЙТЕ!** Иначе значение будет 0.

### Горячая перезагрузка
Эти файлы перезагружаются автоматически:
- ✅ `world.txt`
- ✅ `world_secrets.json`
- ✅ `world_info.json`
- ✅ `quirks.json`
- ✅ `cultural_traditions.json`

Файлы NPC перезагружаются при следующем взаимодействии.

### Флаги редактирования
Если редактируете `KnownSecrets` или `KnownInfo`:
- Флаг `UserEdited` автоматически становится `true`
- Система больше не трогает эти поля
- Сброс: MCM → Reset User-Edited Knowledge


---

## 🔄 Workflow

### Добавление нового контента

1. **Придумайте идею** (секрет, событие, квест)
2. **Добавьте в JSON** (`world_secrets.json` или `world_info.json`)
3. **Сохраните файл** → перезагрузится автоматически
4. **Создайте новых NPC** или сбросьте существующих
5. **Начните диалог** → AI будет знать о новом контенте

### Тестирование секретов

1. Добавьте секрет с `knowledgeChance: 100`
2. Создайте нового NPC или сбросьте существующего
3. Начните диалог
4. Проверьте лог: `[NPC] Name learned secret: ...`
5. Спросите NPC о секрете напрямую

### Отладка событий

1. Включите детальное логирование (MCM)
2. Создайте событие (Force Generate Event)
3. Проверьте `logs/dynamicEvents.log`
4. Смотрите, кто получил событие и почему

---

## 📌 Шпаргалка

### Типы NPC для `applicableNPCs`
```
"all"              — все
"lords"            — лорды
"companions"       — компаньоны
"faction_leaders"  — правители
"village_notables" — деревенские нотабли
"merchants"        — торговцы
```

### Типы событий
```
"news"        — важные новости
"political"   — дипломатия
"military"    — войны, битвы
"economic"    — торговля
"local"       — локальное
"rumor"       — слухи
```

### Дипломатические действия
```
"None"            — просто заявление
"DeclareWar"      — объявить войну
"ProposePeace"    — предложить мир
"AcceptPeace"     — принять мир
"RejectPeace"     — отклонить мир
"ProposeAlliance" — предложить альянс
"AcceptAlliance"  — принять альянс
"RejectAlliance"  — отклонить альянс
"BreakAlliance"   — разорвать альянс
```

---

## 🎯 Ключевые отличия

| Аспект | Secrets | Info |
|--------|---------|------|
| **Файл** | `world_secrets.json` | `world_info.json` |
| **Поле шанса** | `knowledgeChance` | `usageChance` |
| **Классификация** | `accessLevel` + `tags` | `category` |
| **Назначение** | Тайны, требуют доверия | Общедоступная информация |

---

