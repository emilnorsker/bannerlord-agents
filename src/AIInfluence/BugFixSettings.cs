using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AIInfluence;

public class BugFixSettings : AttributeGlobalSettings<BugFixSettings>
{
	public override string Id => "BugFixSettings";

	public override string DisplayName => "BUG-FIX-0";

	public override string FolderName => "AIInfluence";

	public override string FormatType => "json";

	[SettingPropertyGroup("Bug Fixes / Party Speed", GroupOrder = -1)]
	[SettingPropertyBool("Fix Party Speed Tooltip Bug", RequireRestart = false, HintText = "Fixes vanilla bug where hovering the Party Speed tooltip corrupts the displayed Total and the actual party movement speed. The bug is caused by ExplainedNumber (struct) return value from CalculateFinalSpeed being discarded in MobileParty.SpeedExplained. Always enabled — this setting is informational only.", Order = 0)]
	public bool PartySpeedBugFixInfo { get; set; } = true;

	[SettingPropertyGroup("Bug Fixes", GroupOrder = 0)]
	[SettingPropertyButton("Teleport to Random Zero-Unit Party", 1, true, "Teleport to Zero-Unit Party", Content = "Teleport to Random Zero-Unit Party", RequireRestart = false, HintText = "Teleports player to a random party with 0 units on the global map. Useful for finding and inspecting stuck battles.")]
	public Action TeleportToZeroUnitParty { get; set; } = delegate
	{
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected O, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Campaign.Current == null)
			{
				InformationManager.DisplayMessage(new InformationMessage("Campaign is not active. Cannot teleport.", Colors.Red));
			}
			else if (MobileParty.MainParty == null)
			{
				InformationManager.DisplayMessage(new InformationMessage("Player party not found.", Colors.Red));
			}
			else if (MobileParty.MainParty.CurrentSettlement != null)
			{
				InformationManager.DisplayMessage(new InformationMessage("Please exit the settlement first to teleport.", Colors.Yellow));
			}
			else
			{
				List<MobileParty> list = new List<MobileParty>();
				foreach (MobileParty item in (List<MobileParty>)(object)MobileParty.All)
				{
					if (item != MobileParty.MainParty && !item.IsGarrison && !item.IsMilitia && item.IsActive && item.CurrentSettlement == null && item.MemberRoster.TotalManCount == 0)
					{
						list.Add(item);
					}
				}
				if (list.Count != 0)
				{
					Random random = new Random();
					MobileParty val = list[random.Next(list.Count)];
					try
					{
						CampaignVec2 position = val.Position;
						MobileParty.MainParty.Position = position;
						string text = ((object)val.Name)?.ToString() ?? "Unknown Party";
						string text2 = "Teleported to " + text + " (0 units)";
						InformationManager.DisplayMessage(new InformationMessage(text2, Colors.Green));
						if (AIInfluenceBehavior.Instance != null)
						{
							AIInfluenceBehavior.Instance.LogMessage($"[BUG-FIX-0] Teleported to party {text} at position {position}");
						}
						return;
					}
					catch (Exception ex)
					{
						string text3 = "Error teleporting to party: " + ex.Message;
						InformationManager.DisplayMessage(new InformationMessage(text3, Colors.Red));
						AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] " + text3);
						return;
					}
				}
				InformationManager.DisplayMessage(new InformationMessage("No zero-unit parties found on the global map.", Colors.Yellow));
			}
		}
		catch (Exception ex2)
		{
			string text4 = "Error finding zero-unit party: " + ex2.Message;
			InformationManager.DisplayMessage(new InformationMessage(text4, Colors.Red));
			AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] " + text4);
		}
	};

	[SettingPropertyGroup("Bug Fixes", GroupOrder = 0)]
	[SettingPropertyButton("Remove Zero-Unit Parties", 0, true, "Remove Zero-Unit Parties", Content = "Remove Zero-Unit Parties", RequireRestart = false, HintText = "WARNING: Ends battles with zero-unit parties and removes those parties. Use this to fix the infinite battle bug with empty parties. This action cannot be undone!")]
	public Action RemoveZeroUnitParties { get; set; } = delegate
	{
		//IL_137b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1380: Unknown result type (might be due to invalid IL or missing references)
		//IL_138a: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_076f: Unknown result type (might be due to invalid IL or missing references)
		//IL_117d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1183: Unknown result type (might be due to invalid IL or missing references)
		//IL_1329: Unknown result type (might be due to invalid IL or missing references)
		//IL_079b: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Unknown result type (might be due to invalid IL or missing references)
		//IL_132e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1338: Expected O, but got Unknown
		//IL_1322: Unknown result type (might be due to invalid IL or missing references)
		//IL_089b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0860: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_0624: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Campaign.Current == null)
			{
				InformationManager.DisplayMessage(new InformationMessage("Campaign is not active. Cannot remove parties.", Colors.Red));
			}
			else
			{
				List<MobileParty> list = new List<MobileParty>();
				Dictionary<MapEvent, List<MobileParty>> dictionary = new Dictionary<MapEvent, List<MobileParty>>();
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				foreach (MobileParty item2 in (List<MobileParty>)(object)MobileParty.All)
				{
					if (item2 == MobileParty.MainParty)
					{
						num3++;
					}
					else if (item2.IsGarrison || item2.IsMilitia)
					{
						num3++;
					}
					else if (!item2.IsActive)
					{
						num3++;
					}
					else if (item2.CurrentSettlement != null)
					{
						num3++;
					}
					else if (item2.MemberRoster.TotalManCount == 0)
					{
						list.Add(item2);
						MapEvent val = null;
						try
						{
							if (item2.Party != null)
							{
								val = item2.Party.MapEvent;
							}
							if (val == null)
							{
								val = item2.MapEvent;
							}
						}
						catch (Exception ex)
						{
							AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Error getting MapEvent from party {item2.Name}: {ex.Message}");
						}
						if (val != null)
						{
							if (!dictionary.ContainsKey(val))
							{
								dictionary[val] = new List<MobileParty>();
							}
							dictionary[val].Add(item2);
						}
					}
					else
					{
						num3++;
					}
				}
				foreach (KeyValuePair<MapEvent, List<MobileParty>> item3 in dictionary)
				{
					MapEvent key = item3.Key;
					List<MobileParty> value = item3.Value;
					try
					{
						if (key != null)
						{
							List<MapEventParty> list2 = new List<MapEventParty>();
							try
							{
								list2.AddRange((IEnumerable<MapEventParty>)key.PartiesOnSide((BattleSideEnum)1));
								list2.AddRange((IEnumerable<MapEventParty>)key.PartiesOnSide((BattleSideEnum)0));
							}
							catch (Exception ex2)
							{
								AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Error getting parties from MapEvent: " + ex2.Message);
								goto end_IL_01f1;
							}
							AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Processing MapEvent with {list2.Count} total participants, {value.Count} zero-unit parties");
							List<MobileParty> list3 = new List<MobileParty>();
							foreach (MapEventParty item4 in list2)
							{
								object obj;
								if (item4 == null)
								{
									obj = null;
								}
								else
								{
									PartyBase party = item4.Party;
									obj = ((party != null) ? party.MobileParty : null);
								}
								if (obj != null)
								{
									list3.Add(item4.Party.MobileParty);
								}
							}
							AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Found {list3.Count} mobile parties in MapEvent");
							List<MapEventParty> list4 = new List<MapEventParty>();
							foreach (MapEventParty item5 in list2)
							{
								PartyBase party2 = item5.Party;
								if (((party2 != null) ? party2.MobileParty : null) != null && item5.Party.MobileParty.MemberRoster.TotalManCount == 0)
								{
									list4.Add(item5);
								}
							}
							foreach (MapEventParty item6 in list4)
							{
								try
								{
									MethodInfo method = typeof(MapEvent).GetMethod("RemoveParty", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
									if (method != null)
									{
										method.Invoke(key, new object[1] { item6 });
										AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
										if (instance != null)
										{
											PartyBase party3 = item6.Party;
											instance.LogMessage($"[BUG-FIX-0] Removed party {((party3 != null) ? party3.Name : null)} from map event");
										}
									}
								}
								catch (Exception ex3)
								{
									AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Could not remove party from event: " + ex3.Message);
								}
							}
							BattleSideEnum val2 = (BattleSideEnum)(-1);
							bool flag = false;
							bool flag2 = false;
							int num4 = 0;
							int num5 = 0;
							foreach (MapEventParty item7 in (List<MapEventParty>)(object)key.PartiesOnSide((BattleSideEnum)1))
							{
								PartyBase party4 = item7.Party;
								if (((party4 != null) ? party4.MobileParty : null) != null)
								{
									int totalManCount = item7.Party.MobileParty.MemberRoster.TotalManCount;
									if (totalManCount == 0)
									{
										flag = true;
									}
									else
									{
										num4 += totalManCount;
									}
								}
								else
								{
									PartyBase party5 = item7.Party;
									if (((party5 != null) ? party5.Settlement : null) != null)
									{
										num4 += 100;
									}
								}
							}
							foreach (MapEventParty item8 in (List<MapEventParty>)(object)key.PartiesOnSide((BattleSideEnum)0))
							{
								PartyBase party6 = item8.Party;
								if (((party6 != null) ? party6.MobileParty : null) != null)
								{
									int totalManCount2 = item8.Party.MobileParty.MemberRoster.TotalManCount;
									if (totalManCount2 == 0)
									{
										flag2 = true;
									}
									else
									{
										num5 += totalManCount2;
									}
								}
								else
								{
									PartyBase party7 = item8.Party;
									if (((party7 != null) ? party7.Settlement : null) != null)
									{
										num5 += 100;
									}
								}
							}
							val2 = ((flag && !flag2) ? ((BattleSideEnum)0) : ((flag2 && !flag) ? ((BattleSideEnum)1) : ((num4 > num5) ? ((BattleSideEnum)1) : ((num5 <= num4) ? ((BattleSideEnum)(-1)) : ((BattleSideEnum)0)))));
							bool flag3 = false;
							try
							{
								MethodInfo[] methods = typeof(MapEvent).GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
								string[] array = new string[6] { "Finish", "End", "Conclude", "Finalize", "Complete", "Close" };
								string[] array2 = array;
								foreach (string methodName in array2)
								{
									List<MethodInfo> list5 = methods.Where((MethodInfo m) => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase)).ToList();
									foreach (MethodInfo item9 in list5)
									{
										try
										{
											ParameterInfo[] parameters = item9.GetParameters();
											if (parameters.Length == 0)
											{
												item9.Invoke(key, null);
												num2++;
												flag3 = true;
												AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Finished map event using " + methodName + "()");
												break;
											}
											if (parameters.Length == 1 && parameters[0].ParameterType == typeof(BattleSideEnum))
											{
												item9.Invoke(key, new object[1] { val2 });
												num2++;
												flag3 = true;
												AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Finished map event using {methodName}(BattleSideEnum). Winning side: {val2}");
												break;
											}
										}
										catch (Exception)
										{
										}
									}
									if (flag3)
									{
										break;
									}
								}
								if (!flag3)
								{
									PropertyInfo property = typeof(MapEvent).GetProperty("WinningSide", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
									if (property != null)
									{
										if (property.CanWrite)
										{
											property.SetValue(key, val2);
											num2++;
											flag3 = true;
											AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Set WinningSide property to: {val2}");
										}
										else
										{
											MethodInfo setMethod = property.GetSetMethod(nonPublic: true);
											if (setMethod != null)
											{
												setMethod.Invoke(key, new object[1] { val2 });
												num2++;
												flag3 = true;
												AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Set WinningSide via setter to: {val2}");
											}
										}
									}
									if (!flag3)
									{
										PropertyInfo property2 = typeof(MapEvent).GetProperty("HasWinner", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
										if (property2 != null)
										{
											if (property2.CanWrite)
											{
												property2.SetValue(key, true);
												num2++;
												flag3 = true;
												AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Set HasWinner to true");
											}
											else
											{
												MethodInfo setMethod2 = property2.GetSetMethod(nonPublic: true);
												if (setMethod2 != null)
												{
													setMethod2.Invoke(key, new object[1] { true });
													num2++;
													flag3 = true;
													AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Set HasWinner via setter to true");
												}
											}
										}
									}
								}
							}
							catch (Exception ex5)
							{
								AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Error finishing map event: " + ex5.Message);
							}
							int num6 = 0;
							foreach (MobileParty item10 in list3)
							{
								try
								{
									if (item10 != MobileParty.MainParty)
									{
										bool flag4 = false;
										if (item10.Party != null)
										{
											try
											{
												PropertyInfo property3 = typeof(PartyBase).GetProperty("MapEventSide", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
												if (property3 != null)
												{
													if (property3.CanWrite)
													{
														property3.SetValue(item10.Party, null);
														flag4 = true;
														AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Cleared MapEventSide from party {item10.Name}");
													}
													else
													{
														MethodInfo setMethod3 = property3.GetSetMethod(nonPublic: true);
														if (setMethod3 != null)
														{
															setMethod3.Invoke(item10.Party, new object[1]);
															flag4 = true;
															AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Cleared MapEventSide from party {item10.Name} via setter");
														}
													}
												}
											}
											catch (Exception ex6)
											{
												AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Error clearing MapEventSide: " + ex6.Message);
											}
										}
										if (item10.Party != null && !flag4)
										{
											try
											{
												PropertyInfo property4 = typeof(PartyBase).GetProperty("MapEvent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
												if (property4 != null)
												{
													if (property4.CanWrite)
													{
														property4.SetValue(item10.Party, null);
														flag4 = true;
														AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Cleared PartyBase.MapEvent from party {item10.Name}");
													}
													else
													{
														MethodInfo setMethod4 = property4.GetSetMethod(nonPublic: true);
														if (setMethod4 != null)
														{
															setMethod4.Invoke(item10.Party, new object[1]);
															flag4 = true;
															AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Cleared PartyBase.MapEvent from party {item10.Name} via setter");
														}
													}
												}
											}
											catch (Exception ex7)
											{
												AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Error clearing PartyBase.MapEvent: " + ex7.Message);
											}
										}
										if (!flag4)
										{
											try
											{
												PropertyInfo property5 = typeof(MobileParty).GetProperty("MapEvent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
												if (property5 != null)
												{
													if (property5.CanWrite)
													{
														property5.SetValue(item10, null);
														flag4 = true;
														AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Cleared MobileParty.MapEvent from party {item10.Name}");
													}
													else
													{
														MethodInfo setMethod5 = property5.GetSetMethod(nonPublic: true);
														if (setMethod5 != null)
														{
															setMethod5.Invoke(item10, new object[1]);
															flag4 = true;
															AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Cleared MobileParty.MapEvent from party {item10.Name} via setter");
														}
													}
												}
											}
											catch (Exception ex8)
											{
												AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Error clearing MobileParty.MapEvent: " + ex8.Message);
											}
										}
										if (flag4)
										{
											num6++;
										}
									}
								}
								catch (Exception ex9)
								{
									AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Error clearing MapEvent from party {((item10 != null) ? item10.Name : null)}: {ex9.Message}");
								}
							}
							if (!flag3)
							{
								try
								{
									EventInfo eventInfo = typeof(CampaignEvents).GetEvent("MapEventEnded", BindingFlags.Static | BindingFlags.Public);
									if (eventInfo != null)
									{
										AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Attempting to trigger MapEventEnded event manually");
									}
									PropertyInfo property6 = typeof(MapEvent).GetProperty("HasWinner", BindingFlags.Instance | BindingFlags.Public);
									if (property6 != null && property6.CanWrite)
									{
										property6.SetValue(key, true);
										AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Set HasWinner to true");
									}
									PropertyInfo property7 = typeof(MapEvent).GetProperty("State", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
									if (property7 != null && property7.CanWrite)
									{
										Type propertyType = property7.PropertyType;
										if (propertyType.IsEnum)
										{
											Array values = Enum.GetValues(propertyType);
											foreach (object item11 in values)
											{
												string text = item11.ToString();
												if (text.Contains("End") || text.Contains("Finish") || text.Contains("Complete"))
												{
													property7.SetValue(key, item11);
													AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Set MapEvent State to " + text);
													break;
												}
											}
										}
									}
								}
								catch (Exception ex10)
								{
									AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Error trying alternative methods: " + ex10.Message);
								}
								AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Could not finish map event via methods. Cleared MapEvent from {num6}/{list2.Count} participants.");
							}
							else
							{
								AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Map event finished. Cleared MapEvent from {num6}/{list2.Count} participants.");
							}
						}
						end_IL_01f1:;
					}
					catch (Exception ex11)
					{
						AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Error processing map event: " + ex11.Message);
					}
				}
				Thread.Sleep(200);
				foreach (MobileParty item12 in list)
				{
					try
					{
						if (item12 != MobileParty.MainParty)
						{
							if (item12.MapEvent != null)
							{
								try
								{
									MethodInfo method2 = typeof(MobileParty).GetMethod("RemoveParty", BindingFlags.Instance | BindingFlags.Public);
									if (method2 != null)
									{
										method2.Invoke(item12, null);
										AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Removed party {((item12 != null) ? item12.Name : null)} from map event using RemoveParty()");
									}
									else
									{
										PropertyInfo property8 = typeof(MobileParty).GetProperty("MapEvent", BindingFlags.Instance | BindingFlags.Public);
										if (property8 != null && property8.CanWrite)
										{
											property8.SetValue(item12, null);
											AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Cleared MapEvent property for party {((item12 != null) ? item12.Name : null)}");
										}
									}
									Thread.Sleep(50);
								}
								catch (Exception ex12)
								{
									AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] Could not remove party from map event: " + ex12.Message + ". Will try to destroy anyway.");
								}
							}
							if (item12.LeaderHero != null && item12.MemberRoster.Contains(item12.LeaderHero.CharacterObject))
							{
								item12.MemberRoster.RemoveTroop(item12.LeaderHero.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
							}
							try
							{
								MethodInfo method3 = typeof(MobileParty).GetMethod("RemoveParty", BindingFlags.Instance | BindingFlags.Public);
								if (method3 != null)
								{
									method3.Invoke(item12, null);
									num++;
									AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Removed party {((item12 != null) ? item12.Name : null)} using RemoveParty()");
								}
								else
								{
									DestroyPartyAction.Apply((PartyBase)null, item12);
									num++;
									AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Destroyed party {((item12 != null) ? item12.Name : null)} using DestroyPartyAction");
								}
							}
							catch (Exception)
							{
								try
								{
									DestroyPartyAction.Apply((PartyBase)null, item12);
									num++;
									AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Destroyed party {((item12 != null) ? item12.Name : null)} using DestroyPartyAction (fallback)");
								}
								catch (Exception ex14)
								{
									AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Error removing party {((item12 != null) ? item12.Name : null)}: {ex14.Message}");
								}
							}
						}
					}
					catch (Exception ex15)
					{
						AIInfluenceBehavior.Instance?.LogMessage($"[BUG-FIX-0] Error removing party {((item12 != null) ? item12.Name : null)}: {ex15.Message}");
					}
				}
				string text2 = $"Ended battles: {num2}. Removed parties: {num}. Skipped: {num3}";
				InformationManager.DisplayMessage(new InformationMessage(text2, (num > 0 || num2 > 0) ? Colors.Green : Colors.Yellow));
				if (AIInfluenceBehavior.Instance != null)
				{
					AIInfluenceBehavior.Instance.LogMessage("[BUG-FIX-0] " + text2);
				}
			}
		}
		catch (Exception ex16)
		{
			string text3 = "Error removing parties: " + ex16.Message;
			InformationManager.DisplayMessage(new InformationMessage(text3, Colors.Red));
			AIInfluenceBehavior.Instance?.LogMessage("[BUG-FIX-0] " + text3);
		}
	};
}
