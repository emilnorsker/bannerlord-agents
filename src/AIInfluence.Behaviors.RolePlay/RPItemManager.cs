using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.RolePlay;

public class RPItemManager : IGameStateManagerListener
{
	private static RPItemManager _instance;

	private Dictionary<string, RPItemData> _rpItems = new Dictionary<string, RPItemData>();

	private Dictionary<string, ItemObject> _createdItems = new Dictionary<string, ItemObject>();

	private string _saveFilePath;

	private string _logFilePath;

	public static RPItemManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new RPItemManager();
			}
			return _instance;
		}
	}

	private RPItemManager()
	{
	}

	public void Initialize(string saveDataPath)
	{
		try
		{
			Campaign current = Campaign.Current;
			string path = ((current != null) ? current.UniqueGameId.ToString() : null) ?? "default";
			string path2 = Path.Combine(saveDataPath, path);
			_saveFilePath = Path.Combine(path2, "rp_items.json");
			string fullName = Directory.GetParent(saveDataPath).FullName;
			string path3 = Path.Combine(fullName, "logs");
			_logFilePath = Path.Combine(path3, "rp_item_manager_log.txt");
			LoadRPItems();
			RegisterEvents();
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error initializing: " + ex.Message);
		}
	}

	public void RegisterEvents()
	{
		try
		{
			Game current = Game.Current;
			if (((current != null) ? current.GameStateManager : null) != null)
			{
				bool flag = Game.Current.GameStateManager.RegisterListener((IGameStateManagerListener)(object)this);
				LogMessage($"[RP_ITEM_MANAGER] RegisterEvents: GameStateManager found, listener registered: {flag}");
			}
			else if (GameStateManager.Current != null)
			{
				bool flag2 = GameStateManager.Current.RegisterListener((IGameStateManagerListener)(object)this);
				LogMessage($"[RP_ITEM_MANAGER] RegisterEvents: GameStateManager.Current found, listener registered: {flag2}");
			}
			else
			{
				LogMessage("[RP_ITEM_MANAGER] RegisterEvents: GameStateManager not available yet");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] RegisterEvents error: " + ex.Message);
		}
	}

	public void OnCreateState(GameState gameState)
	{
	}

	public void OnPushState(GameState gameState, bool isTopGameState)
	{
		try
		{
			LogMessage($"[RP_ITEM_MANAGER] OnPushState called: Type={((object)gameState)?.GetType().Name}, isTopGameState={isTopGameState}");
			if (gameState is InventoryState)
			{
				LogMessage("[RP_ITEM_MANAGER] Inventory opened, starting synchronization...");
				SynchronizeAllItems();
				LogMessage("[RP_ITEM_MANAGER] Synchronization completed");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error in OnPushState: " + ex.Message);
		}
	}

	public void OnPopState(GameState gameState)
	{
	}

	public void OnCleanStates()
	{
	}

	public void OnSavedGameLoadFinished()
	{
	}

	public ItemObject CreateRPItem(string name, string description, string createdBy = null, string baseItemId = null, Dictionary<string, object> metadata = null, string existingItemId = null)
	{
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Campaign.Current == null)
			{
				LogMessage("[RP_ITEM_MANAGER] Cannot create item: Campaign not initialized");
				return null;
			}
			string text;
			CampaignTime now;
			if (!string.IsNullOrEmpty(existingItemId))
			{
				text = existingItemId;
				ItemObject val = MBObjectManager.Instance.GetObject<ItemObject>(text);
				if (val != null)
				{
					RPItemData obj = new RPItemData
					{
						ItemId = text,
						Name = name,
						Description = description,
						BaseItemId = null,
						CreatedBy = createdBy
					};
					now = CampaignTime.Now;
					obj.CreatedDay = (int)((CampaignTime)(ref now)).ToDays;
					obj.Metadata = metadata ?? new Dictionary<string, object>();
					obj.Owner = null;
					RPItemData itemData = obj;
					SynchronizeItemData(val, itemData);
					_createdItems[text] = val;
					LogMessage("[RP_ITEM_MANAGER] Updated existing item " + text + ": Name='" + name + "'");
					return val;
				}
			}
			else
			{
				string text2 = Guid.NewGuid().ToString("N").Substring(0, 5);
				text = "ai_rp_item_" + text2;
			}
			string value = "merchandise_leather_a";
			ItemObject val2 = new ItemObject();
			((MBObjectBase)val2).StringId = text;
			((MBObjectBase)val2).Initialize();
			TextObject value2 = new TextObject(name, (Dictionary<string, object>)null);
			ItemCategory cloth = DefaultItemCategories.Cloth;
			SetPrivateProperty(val2, "Name", value2);
			SetPrivateProperty(val2, "ItemCategory", cloth);
			SetPrivateProperty(val2, "Value", 0);
			SetPrivateProperty(val2, "Weight", 0.1f);
			SetPrivateProperty(val2, "ItemType", (object)(ItemTypeEnum)22);
			SetPrivateProperty(val2, "IsFood", false);
			if (!string.IsNullOrEmpty(value))
			{
				SetPrivateProperty(val2, "MultiMeshName", value);
			}
			else
			{
				SetPrivateProperty(val2, "MultiMeshName", "");
			}
			SetPrivateProperty(val2, "BodyName", "");
			SetPrivateProperty(val2, "PrefabName", "");
			SetPrivateProperty(val2, "SkeletonName", "");
			SetPrivateProperty(val2, "StaticAnimationName", "");
			SetPrivateProperty(val2, "HolsterBodyName", "");
			SetPrivateProperty(val2, "CollisionBodyName", "");
			SetPrivateProperty(val2, "HolsterMeshName", "");
			SetPrivateProperty(val2, "FlyingMeshName", "");
			SetPrivateProperty(val2, "ItemHolsters", new string[0]);
			SetPrivateProperty(val2, "ItemFlags", (object)(ItemFlags)4194304);
			RPItemComponent obj2 = new RPItemComponent
			{
				Description = new TextObject(description ?? "", (Dictionary<string, object>)null),
				CreatedBy = createdBy
			};
			now = CampaignTime.Now;
			obj2.CreatedDay = (int)((CampaignTime)(ref now)).ToDays;
			((ItemComponent)obj2).Item = val2;
			RPItemComponent value3 = obj2;
			SetPrivateProperty(val2, "ItemComponent", value3);
			SetPrivateProperty(val2, "IsCraftedByPlayer", true);
			if (!((MBObjectBase)val2).IsReady)
			{
				((MBObjectBase)val2).AfterInitialized();
			}
			try
			{
				ItemObject val3 = MBObjectManager.Instance.GetObject<ItemObject>(text);
				if (val3 == null)
				{
					MBObjectManager.Instance.RegisterObject<ItemObject>(val2);
				}
				else
				{
					val2 = val3;
					LogMessage("[RP_ITEM_MANAGER] Item " + text + " already exists in MBObjectManager, using existing item");
				}
			}
			catch (Exception ex)
			{
				LogMessage("[RP_ITEM_MANAGER] Error registering item: " + ex.Message);
			}
			if (string.IsNullOrEmpty(existingItemId))
			{
				RPItemData obj3 = new RPItemData
				{
					ItemId = text,
					Name = name,
					Description = description,
					BaseItemId = null,
					CreatedBy = createdBy
				};
				now = CampaignTime.Now;
				obj3.CreatedDay = (int)((CampaignTime)(ref now)).ToDays;
				obj3.Metadata = metadata ?? new Dictionary<string, object>();
				obj3.Owner = null;
				RPItemData value4 = obj3;
				_rpItems[text] = value4;
				_createdItems[text] = val2;
				SaveRPItems();
			}
			else
			{
				_createdItems[text] = val2;
			}
			LogMessage("[RP_ITEM_MANAGER] Created RP item: " + name + " (ID: " + text + ")");
			return val2;
		}
		catch (Exception ex2)
		{
			LogMessage("[RP_ITEM_MANAGER] Error creating RP item: " + ex2.Message + "\n" + ex2.StackTrace);
			return null;
		}
	}

	public bool CreateAndGiveItemToPlayer(string name, string description, string createdBy = null, Dictionary<string, object> metadata = null)
	{
		try
		{
			ItemObject val = CreateRPItem(name, description, createdBy, null, metadata);
			if (val == null)
			{
				return false;
			}
			MobileParty mainParty = MobileParty.MainParty;
			if (((mainParty != null) ? mainParty.ItemRoster : null) != null)
			{
				MobileParty.MainParty.ItemRoster.AddToCounts(val, 1);
				if (_rpItems.TryGetValue(((MBObjectBase)val).StringId, out var value))
				{
					value.Owner = "MainParty";
					SaveRPItems();
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error creating and giving item: " + ex.Message);
			return false;
		}
	}

	public ItemObject GetItem(string itemId)
	{
		if (_createdItems.TryGetValue(itemId, out var value))
		{
			return value;
		}
		return MBObjectManager.Instance.GetObject<ItemObject>(itemId);
	}

	public RPItemData GetItemData(string itemId)
	{
		RPItemData value;
		return _rpItems.TryGetValue(itemId, out value) ? value : null;
	}

	public void UpdateItemOwner(string itemId, string newOwner)
	{
		if (_rpItems.TryGetValue(itemId, out var value))
		{
			string owner = value.Owner;
			value.Owner = newOwner;
			SaveRPItems();
			LogMessage("[RP_ITEM_MANAGER] UpdateItemOwner: " + itemId + " owner changed " + owner + " -> " + newOwner);
		}
	}

	public void OnDailyTick()
	{
		try
		{
			if (_rpItems == null || _rpItems.Count == 0)
			{
				return;
			}
			List<string> list = new List<string>();
			bool flag = false;
			foreach (KeyValuePair<string, RPItemData> item in _rpItems.ToList())
			{
				RPItemData value = item.Value;
				if (string.IsNullOrEmpty(value.Owner))
				{
					continue;
				}
				if (!IsOwnerAlive(value.Owner))
				{
					list.Add(item.Key);
					LogMessage("[RP_ITEM_MANAGER] Daily check: Removing item " + value.Name + " - owner " + value.Owner + " is dead");
				}
				else
				{
					ItemObject val = MBObjectManager.Instance.GetObject<ItemObject>(item.Key);
					if (val != null)
					{
						RestoreItemToOwner(val, value);
						flag = true;
					}
				}
			}
			foreach (string item2 in list)
			{
				RemoveItem(item2);
			}
			if (list.Count > 0)
			{
				SaveRPItems();
				LogMessage($"[RP_ITEM_MANAGER] Daily check: Removed {list.Count} items with dead owners");
			}
			if (flag)
			{
				LogMessage("[RP_ITEM_MANAGER] Daily check: Attempted to restore items for available owners");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error in daily check: " + ex.Message);
		}
	}

	private bool IsOwnerAlive(string ownerId)
	{
		try
		{
			if (string.IsNullOrEmpty(ownerId))
			{
				return false;
			}
			if (ownerId == "MainParty")
			{
				return Hero.MainHero != null && !Hero.MainHero.IsDead;
			}
			Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == ownerId));
			if (val != null)
			{
				return true;
			}
			Hero val2 = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == ownerId));
			if (val2 != null)
			{
				return !val2.IsDead;
			}
			return false;
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error checking owner alive status: " + ex.Message);
			return false;
		}
	}

	private string FindActualOwner(ItemObject item)
	{
		try
		{
			if (item == null)
			{
				return null;
			}
			MobileParty mainParty = MobileParty.MainParty;
			if (((mainParty != null) ? mainParty.ItemRoster : null) != null)
			{
				int itemNumber = MobileParty.MainParty.ItemRoster.GetItemNumber(item);
				if (itemNumber > 0)
				{
					return "MainParty";
				}
			}
			foreach (Hero item2 in (List<Hero>)(object)Hero.AllAliveHeroes)
			{
				MobileParty partyBelongedTo = item2.PartyBelongedTo;
				if (((partyBelongedTo != null) ? partyBelongedTo.ItemRoster : null) != null)
				{
					int itemNumber2 = item2.PartyBelongedTo.ItemRoster.GetItemNumber(item);
					if (itemNumber2 > 0)
					{
						return ((MBObjectBase)item2).StringId;
					}
				}
			}
			foreach (Settlement item3 in (List<Settlement>)(object)Settlement.All)
			{
				if (((item3 != null) ? item3.ItemRoster : null) != null)
				{
					int itemNumber3 = item3.ItemRoster.GetItemNumber(item);
					if (itemNumber3 > 0)
					{
						return ((MBObjectBase)item3).StringId;
					}
				}
			}
			return null;
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error finding actual owner: " + ex.Message);
			return null;
		}
	}

	public void SynchronizeAllItems()
	{
		try
		{
			if (string.IsNullOrEmpty(_saveFilePath) || !File.Exists(_saveFilePath))
			{
				return;
			}
			string text = File.ReadAllText(_saveFilePath);
			Dictionary<string, RPItemData> dictionary = JsonConvert.DeserializeObject<Dictionary<string, RPItemData>>(text);
			if (dictionary == null)
			{
				return;
			}
			_rpItems = dictionary;
			bool flag = false;
			foreach (KeyValuePair<string, RPItemData> item in dictionary)
			{
				ItemObject val = MBObjectManager.Instance.GetObject<ItemObject>(item.Key);
				if (val != null)
				{
					string text2 = FindActualOwner(val);
					if (string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(item.Value.Owner))
					{
						string owner = item.Value.Owner;
						item.Value.Owner = null;
						flag = true;
						LogMessage("[RP_ITEM_MANAGER] Item " + item.Key + " was discarded, updated owner: " + owner + " -> null");
					}
					else if (!string.IsNullOrEmpty(text2) && item.Value.Owner != text2)
					{
						string owner2 = item.Value.Owner;
						item.Value.Owner = text2;
						flag = true;
						LogMessage("[RP_ITEM_MANAGER] Updated owner for item " + item.Key + ": " + owner2 + " -> " + text2);
					}
					SynchronizeItemData(val, item.Value);
					LogMessage("[RP_ITEM_MANAGER] Synchronized item " + item.Key + ": Name='" + item.Value.Name + "', Description='" + item.Value.Description + "'");
				}
				else
				{
					LogMessage("[RP_ITEM_MANAGER] Item " + item.Key + " not found in MBObjectManager, skipping synchronization");
				}
			}
			if (flag)
			{
				_rpItems = dictionary;
			}
			SaveRPItems();
			LogMessage($"[RP_ITEM_MANAGER] Synchronized {dictionary.Count} items from JSON");
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error synchronizing items: " + ex.Message);
		}
	}

	private void LoadRPItems()
	{
		try
		{
			if (string.IsNullOrEmpty(_saveFilePath) || !File.Exists(_saveFilePath))
			{
				_rpItems = new Dictionary<string, RPItemData>();
				return;
			}
			string text = File.ReadAllText(_saveFilePath);
			Dictionary<string, RPItemData> dictionary = JsonConvert.DeserializeObject<Dictionary<string, RPItemData>>(text);
			if (dictionary == null)
			{
				return;
			}
			_rpItems = dictionary;
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, RPItemData> rpItem in _rpItems)
			{
				RPItemData value = rpItem.Value;
				if (!string.IsNullOrEmpty(value.Owner) && !IsOwnerAlive(value.Owner))
				{
					list.Add(rpItem.Key);
					LogMessage("[RP_ITEM_MANAGER] Removing item " + value.Name + " - owner " + value.Owner + " is dead");
					continue;
				}
				ItemObject val = MBObjectManager.Instance.GetObject<ItemObject>(rpItem.Key);
				if (val == null)
				{
					val = RecreateItemFromData(value);
					if (val != null)
					{
						_createdItems[rpItem.Key] = val;
						LogMessage("[RP_ITEM_MANAGER] Recreated item: " + value.Name);
					}
				}
				else
				{
					_createdItems[rpItem.Key] = val;
					SynchronizeItemData(val, value);
				}
				RestoreItemToOwner(val, value);
			}
			foreach (string item in list)
			{
				RemoveItem(item);
			}
			if (list.Count > 0)
			{
				SaveRPItems();
			}
			LogMessage($"[RP_ITEM_MANAGER] Loaded {_rpItems.Count} RP items, removed {list.Count} items with dead creators");
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error loading RP items: " + ex.Message);
			_rpItems = new Dictionary<string, RPItemData>();
		}
	}

	private void UpdateOwnersBeforeSave()
	{
		try
		{
			bool flag = false;
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, RPItemData> rpItem in _rpItems)
			{
				if (!string.IsNullOrEmpty(rpItem.Value.Owner) && !IsOwnerAlive(rpItem.Value.Owner))
				{
					list.Add(rpItem.Key);
					LogMessage("[RP_ITEM_MANAGER] Removing item " + rpItem.Value.Name + " before save - owner " + rpItem.Value.Owner + " is dead");
					continue;
				}
				ItemObject val = MBObjectManager.Instance.GetObject<ItemObject>(rpItem.Key);
				if (val != null)
				{
					string text = FindActualOwner(val);
					if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(rpItem.Value.Owner))
					{
						string owner = rpItem.Value.Owner;
						rpItem.Value.Owner = null;
						flag = true;
						LogMessage("[RP_ITEM_MANAGER] Item " + rpItem.Key + " was discarded before save, updated owner: " + owner + " -> null");
					}
					else if (!string.IsNullOrEmpty(text) && rpItem.Value.Owner != text)
					{
						string owner2 = rpItem.Value.Owner;
						rpItem.Value.Owner = text;
						flag = true;
						LogMessage("[RP_ITEM_MANAGER] Updated owner before save for item " + rpItem.Key + ": " + owner2 + " -> " + text);
					}
				}
			}
			foreach (string item in list)
			{
				_rpItems.Remove(item);
				_createdItems.Remove(item);
			}
			if (flag)
			{
				LogMessage("[RP_ITEM_MANAGER] Updated owners for items before save");
			}
			if (list.Count > 0)
			{
				LogMessage($"[RP_ITEM_MANAGER] Removed {list.Count} items with dead owners before save");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error updating owners before save: " + ex.Message);
		}
	}

	private void SaveRPItems()
	{
		try
		{
			if (!string.IsNullOrEmpty(_saveFilePath))
			{
				UpdateOwnersBeforeSave();
				string directoryName = Path.GetDirectoryName(_saveFilePath);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				string contents = JsonConvert.SerializeObject((object)_rpItems, (Formatting)1);
				File.WriteAllText(_saveFilePath, contents);
			}
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error saving RP items: " + ex.Message);
		}
	}

	private ItemObject RecreateItemFromData(RPItemData itemData)
	{
		try
		{
			return CreateRPItem(itemData.Name, itemData.Description, itemData.CreatedBy, null, itemData.Metadata, itemData.ItemId);
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error recreating item " + itemData.Name + ": " + ex.Message);
			return null;
		}
	}

	private void SynchronizeItemData(ItemObject item, RPItemData itemData)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		try
		{
			SetPrivateProperty(item, "Name", (object)new TextObject(itemData.Name ?? "", (Dictionary<string, object>)null));
			if (item.ItemComponent is RPItemComponent rPItemComponent)
			{
				rPItemComponent.Description = new TextObject(itemData.Description ?? "", (Dictionary<string, object>)null);
				if (rPItemComponent.CreatedBy != itemData.CreatedBy)
				{
					rPItemComponent.CreatedBy = itemData.CreatedBy;
				}
				if (rPItemComponent.CreatedDay != itemData.CreatedDay)
				{
					rPItemComponent.CreatedDay = itemData.CreatedDay;
				}
			}
			else
			{
				RPItemComponent obj = new RPItemComponent
				{
					Description = new TextObject(itemData.Description ?? "", (Dictionary<string, object>)null),
					CreatedBy = itemData.CreatedBy,
					CreatedDay = itemData.CreatedDay
				};
				((ItemComponent)obj).Item = item;
				RPItemComponent value = obj;
				SetPrivateProperty(item, "ItemComponent", value);
			}
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error synchronizing item data: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void RestoreItemToOwner(ItemObject item, RPItemData itemData)
	{
		try
		{
			if (item == null || string.IsNullOrEmpty(itemData.Owner))
			{
				return;
			}
			if (itemData.Owner == "MainParty")
			{
				MobileParty mainParty = MobileParty.MainParty;
				if (((mainParty != null) ? mainParty.ItemRoster : null) != null && MobileParty.MainParty.ItemRoster.GetItemNumber(item) == 0)
				{
					MobileParty.MainParty.ItemRoster.AddToCounts(item, 1);
					LogMessage("[RP_ITEM_MANAGER] Restored item " + itemData.Name + " to MainParty");
				}
				return;
			}
			Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == itemData.Owner));
			if (val != null && val.ItemRoster != null)
			{
				if (val.ItemRoster.GetItemNumber(item) == 0)
				{
					val.ItemRoster.AddToCounts(item, 1);
					LogMessage($"[RP_ITEM_MANAGER] Restored item {itemData.Name} to settlement {val.Name}");
				}
				return;
			}
			Hero val2 = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == itemData.Owner));
			if (val2 != null && !val2.IsDead && val2.PartyBelongedTo != null && val2.PartyBelongedTo.ItemRoster != null)
			{
				if (val2.PartyBelongedTo.ItemRoster.GetItemNumber(item) == 0)
				{
					val2.PartyBelongedTo.ItemRoster.AddToCounts(item, 1);
					LogMessage($"[RP_ITEM_MANAGER] Restored item {itemData.Name} to {val2.Name}");
				}
			}
			else if (val2 != null && (val2.IsDead || val2.PartyBelongedTo == null))
			{
				LogMessage("[RP_ITEM_MANAGER] Cannot restore item " + itemData.Name + " - owner " + itemData.Owner + " is dead or has no party (prisoner)");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error restoring item to owner: " + ex.Message);
		}
	}

	private void RemoveItem(string itemId)
	{
		try
		{
			if (_rpItems.TryGetValue(itemId, out var _))
			{
				ItemObject val = MBObjectManager.Instance.GetObject<ItemObject>(itemId);
				if (val != null)
				{
					MobileParty mainParty = MobileParty.MainParty;
					if (((mainParty != null) ? mainParty.ItemRoster : null) != null)
					{
						int itemNumber = MobileParty.MainParty.ItemRoster.GetItemNumber(val);
						if (itemNumber > 0)
						{
							MobileParty.MainParty.ItemRoster.AddToCounts(val, -itemNumber);
						}
					}
					foreach (Hero item in (List<Hero>)(object)Hero.AllAliveHeroes)
					{
						MobileParty partyBelongedTo = item.PartyBelongedTo;
						if (((partyBelongedTo != null) ? partyBelongedTo.ItemRoster : null) != null)
						{
							int itemNumber2 = item.PartyBelongedTo.ItemRoster.GetItemNumber(val);
							if (itemNumber2 > 0)
							{
								item.PartyBelongedTo.ItemRoster.AddToCounts(val, -itemNumber2);
							}
						}
					}
				}
			}
			_rpItems.Remove(itemId);
			_createdItems.Remove(itemId);
		}
		catch (Exception ex)
		{
			LogMessage("[RP_ITEM_MANAGER] Error removing item " + itemId + ": " + ex.Message);
		}
	}

	private void LogMessage(string message)
	{
		try
		{
			if (!string.IsNullOrEmpty(_logFilePath))
			{
				string directoryName = Path.GetDirectoryName(_logFilePath);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				File.AppendAllText(_logFilePath, $"[{DateTime.Now:HH:mm:ss.fff}] {message}{Environment.NewLine}");
			}
		}
		catch (Exception)
		{
		}
	}

	private void SetPrivateProperty(object obj, string propertyName, object value)
	{
		try
		{
			PropertyInfo property = obj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (property != null && property.CanWrite)
			{
				property.SetValue(obj, value);
			}
		}
		catch
		{
		}
	}
}
