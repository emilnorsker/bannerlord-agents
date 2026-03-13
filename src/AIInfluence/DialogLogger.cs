using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public class DialogLogger : CampaignBehaviorBase
{
	private static string _currentDialogId = "unknown";

	private static string _currentInputToken = "unknown";

	private static string _currentOutputToken = "unknown";

	private bool _enableDialogLogging = false;

	private static DialogLogger _instance;

	public bool EnableDialogLogging
	{
		get
		{
			return _enableDialogLogging;
		}
		set
		{
			if (_enableDialogLogging != value)
			{
				_enableDialogLogging = value;
				this.OnSettingChanged?.Invoke("EnableDialogLogging", value);
			}
		}
	}

	public static DialogLogger Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DialogLogger();
			}
			return _instance;
		}
	}

	public event Action<string, object> OnSettingChanged;

	public override void RegisterEvents()
	{
		CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener((object)this, (Action<CampaignGameStarter>)OnSessionLaunched);
	}

	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		WrapDialogMethods(campaignGameStarter);
	}

	private void WrapDialogMethods(CampaignGameStarter starter)
	{
		try
		{
			Campaign current = Campaign.Current;
			if (((current != null) ? current.ConversationManager : null) == null)
			{
				return;
			}
			ConversationManager conversationManager = Campaign.Current.ConversationManager;
			Type type = ((object)conversationManager).GetType();
			EventInfo[] events = type.GetEvents();
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
			EventInfo[] array = events;
			foreach (EventInfo eventInfo in array)
			{
				LogMessage("[DEBUG] Found event: " + eventInfo.Name);
			}
			FieldInfo[] array2 = fields;
			foreach (FieldInfo fieldInfo in array2)
			{
				if (fieldInfo.Name.Contains("dialog") || fieldInfo.Name.Contains("conversation") || fieldInfo.Name.Contains("sentence"))
				{
					LogMessage($"[DEBUG] Found field: {fieldInfo.Name} = {fieldInfo.GetValue(conversationManager)}");
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] WrapDialogMethods failed: " + ex.Message);
		}
	}

	private void LogMessage(string message)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		try
		{
			InformationManager.DisplayMessage(new InformationMessage(message, Colors.Yellow));
		}
		catch
		{
		}
	}

	public static void UpdateCurrentDialog(string id, string inputToken, string outputToken)
	{
		_currentDialogId = id ?? "unknown";
		_currentInputToken = inputToken ?? "unknown";
		_currentOutputToken = outputToken ?? "unknown";
	}

	public void LogCurrentDialogInfo()
	{
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected O, but got Unknown
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Expected O, but got Unknown
		try
		{
			Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
			string text = ((oneToOneConversationHero != null) ? $"{oneToOneConversationHero.Name} ({((MBObjectBase)oneToOneConversationHero).StringId})" : "no_npc");
			string text2 = "unknown";
			string text3 = "unknown";
			string text4 = "unknown";
			Campaign current = Campaign.Current;
			if (current != null)
			{
				ConversationManager conversationManager = current.ConversationManager;
				if (((conversationManager != null) ? new bool?(conversationManager.IsConversationInProgress) : ((bool?)null)) == true)
				{
					try
					{
						ConversationManager conversationManager2 = Campaign.Current.ConversationManager;
						Type type = ((object)conversationManager2).GetType();
						FieldInfo field = type.GetField("_sentences", BindingFlags.Instance | BindingFlags.NonPublic);
						FieldInfo field2 = type.GetField("_currentSentence", BindingFlags.Instance | BindingFlags.NonPublic);
						if (field != null && field2 != null)
						{
							IList list = field.GetValue(conversationManager2) as IList;
							int num = (int)field2.GetValue(conversationManager2);
							LogMessage($"[DEBUG] Current sentence index: {num}");
							LogMessage($"[DEBUG] Sentences count: {list?.Count ?? 0}");
							if (list != null && num >= 0 && num < list.Count)
							{
								object obj = list[num];
								Type type2 = obj.GetType();
								LogMessage("[DEBUG] Current sentence type: " + type2.Name);
								FieldInfo field3 = type2.GetField("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
								FieldInfo field4 = type2.GetField("InputToken", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
								FieldInfo field5 = type2.GetField("OutputToken", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
								PropertyInfo property = type2.GetProperty("Id");
								PropertyInfo property2 = type2.GetProperty("InputToken");
								PropertyInfo property3 = type2.GetProperty("OutputToken");
								if (property != null)
								{
									text2 = property.GetValue(obj)?.ToString() ?? "unknown";
									LogMessage("[DEBUG] Found ID property: " + text2);
								}
								int num2 = -1;
								int num3 = -1;
								if (property2 != null)
								{
									num2 = (int)property2.GetValue(obj);
									LogMessage($"[DEBUG] Found InputToken index: {num2}");
								}
								if (property3 != null)
								{
									num3 = (int)property3.GetValue(obj);
									LogMessage($"[DEBUG] Found OutputToken index: {num3}");
								}
								if (num2 >= 0 || num3 >= 0)
								{
									try
									{
										ConversationManager conversationManager3 = Campaign.Current.ConversationManager;
										Type type3 = ((object)conversationManager3).GetType();
										FieldInfo field6 = type3.GetField("stateMap", BindingFlags.Instance | BindingFlags.NonPublic);
										if (field6 != null && field6.GetValue(conversationManager3) is Dictionary<string, int> dictionary)
										{
											foreach (KeyValuePair<string, int> item in dictionary)
											{
												if (item.Value == num2)
												{
													text3 = item.Key;
													LogMessage("[DEBUG] Found InputToken string: " + text3);
												}
												if (item.Value == num3)
												{
													text4 = item.Key;
													LogMessage("[DEBUG] Found OutputToken string: " + text4);
												}
											}
										}
									}
									catch (Exception ex)
									{
										LogMessage("[DEBUG] Error getting token strings: " + ex.Message);
									}
								}
								LogMessage("[DEBUG] === ALL FIELDS IN ConversationSentence ===");
								FieldInfo[] fields = type2.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
								PropertyInfo[] properties = type2.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
								FieldInfo[] array = fields;
								foreach (FieldInfo fieldInfo in array)
								{
									try
									{
										string text5 = fieldInfo.GetValue(obj)?.ToString();
										LogMessage("[DEBUG] FIELD: " + fieldInfo.Name + " = " + text5);
									}
									catch (Exception ex2)
									{
										LogMessage("[DEBUG] FIELD: " + fieldInfo.Name + " = ERROR: " + ex2.Message);
									}
								}
								PropertyInfo[] array2 = properties;
								foreach (PropertyInfo propertyInfo in array2)
								{
									try
									{
										string text6 = propertyInfo.GetValue(obj)?.ToString();
										LogMessage("[DEBUG] PROPERTY: " + propertyInfo.Name + " = " + text6);
									}
									catch (Exception ex3)
									{
										LogMessage("[DEBUG] PROPERTY: " + propertyInfo.Name + " = ERROR: " + ex3.Message);
									}
								}
								LogMessage("[DEBUG] === END ALL FIELDS ===");
								if (field3 == null && property == null)
								{
									LogMessage("[DEBUG] ID not found in properties, searching backing fields...");
								}
								if (field4 == null && property2 == null)
								{
									LogMessage("[DEBUG] InputToken not found in properties, searching backing fields...");
								}
								if (field5 == null && property3 == null)
								{
									LogMessage("[DEBUG] OutputToken not found in properties, searching backing fields...");
								}
							}
							else
							{
								LogMessage("[DEBUG] Invalid sentence index or sentences list is null");
							}
						}
						else
						{
							LogMessage("[DEBUG] Could not find _sentences or _currentSentence fields");
						}
					}
					catch (Exception ex4)
					{
						LogMessage("[ERROR] Failed to get dialog info: " + ex4.Message);
					}
					goto IL_05b9;
				}
			}
			text2 = "no_conversation";
			text3 = "no_conversation";
			text4 = "no_conversation";
			goto IL_05b9;
			IL_05b9:
			string text7 = $"Dialog Log: ID={text2}, Input={text3}, Output={text4}, NPC={text}, Time={CampaignTime.Now}";
			InformationManager.DisplayMessage(new InformationMessage(text7, Colors.Cyan));
		}
		catch (Exception ex5)
		{
			InformationManager.DisplayMessage(new InformationMessage("Dialog Logger Error: " + ex5.Message, ExtraColors.RedAIInfluence));
		}
	}

	public static void LogDialogInfo(string stringId, string inputToken, string outputToken)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		if (!Instance.EnableDialogLogging)
		{
			return;
		}
		try
		{
			string text = "Dialog Log: ID=" + stringId + ", Input=" + inputToken + ", Output=" + outputToken;
			InformationManager.DisplayMessage(new InformationMessage(text, Colors.Cyan));
		}
		catch (Exception ex)
		{
			InformationManager.DisplayMessage(new InformationMessage("Dialog Logger Error: " + ex.Message, ExtraColors.RedAIInfluence));
		}
	}

	public static void LogDialogInfo(string stringId, string inputToken, string outputToken, string additionalInfo)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		if (!Instance.EnableDialogLogging)
		{
			return;
		}
		try
		{
			string text = "Dialog Log: ID=" + stringId + ", Input=" + inputToken + ", Output=" + outputToken + ", Info=" + additionalInfo;
			InformationManager.DisplayMessage(new InformationMessage(text, Colors.Cyan));
		}
		catch (Exception ex)
		{
			InformationManager.DisplayMessage(new InformationMessage("Dialog Logger Error: " + ex.Message, ExtraColors.RedAIInfluence));
		}
	}

	public override void SyncData(IDataStore dataStore)
	{
	}
}
