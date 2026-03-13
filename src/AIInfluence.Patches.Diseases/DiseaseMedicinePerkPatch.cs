using System;
using System.Collections.Generic;
using System.Reflection;
using AIInfluence.Diseases;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace AIInfluence.Patches.Diseases;

public static class DiseaseMedicinePerkPatch
{
	private static FieldInfo _descriptionField;

	private static FieldInfo _primaryDescField;

	private static FieldInfo _secondaryDescField;

	private static bool _fieldsResolved;

	private static bool _applied;

	public static void ApplyDiseaseDescriptions()
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		if (_applied)
		{
			return;
		}
		_applied = true;
		try
		{
			ModSettings instance = GlobalSettings<ModSettings>.Instance;
			if (instance == null || !instance.EnableDiseaseSystem)
			{
				return;
			}
			if (!_fieldsResolved)
			{
				_descriptionField = typeof(PropertyObject).GetField("_description", BindingFlags.Instance | BindingFlags.NonPublic);
				_primaryDescField = typeof(PerkObject).GetField("<PrimaryDescription>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
				_secondaryDescField = typeof(PerkObject).GetField("<SecondaryDescription>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
				_fieldsResolved = true;
			}
			if (_descriptionField == null)
			{
				return;
			}
			MBReadOnlyList<PerkObject> all = PerkObject.All;
			if (all == null)
			{
				return;
			}
			int num = 0;
			foreach (PerkObject item in (List<PerkObject>)(object)all)
			{
				if (((item != null) ? item.Skill : null) != DefaultSkills.Medicine)
				{
					continue;
				}
				string diseaseBonusText = DiseasePerkBonuses.GetDiseaseBonusText(item);
				if (string.IsNullOrEmpty(diseaseBonusText))
				{
					continue;
				}
				TextObject description = ((PropertyObject)item).Description;
				if (description != (TextObject)null)
				{
					string text = ((object)description).ToString() + "\n\n" + diseaseBonusText;
					_descriptionField.SetValue(item, (object?)new TextObject(text, (Dictionary<string, object>)null));
				}
				bool flag = false;
				if (_secondaryDescField != null)
				{
					TextObject secondaryDescription = item.SecondaryDescription;
					if (secondaryDescription != (TextObject)null && !string.IsNullOrEmpty(((object)secondaryDescription).ToString()))
					{
						string text2 = ((object)secondaryDescription).ToString() + "\n" + diseaseBonusText;
						_secondaryDescField.SetValue(item, (object?)new TextObject(text2, (Dictionary<string, object>)null));
						flag = true;
					}
				}
				if (!flag && _primaryDescField != null)
				{
					TextObject primaryDescription = item.PrimaryDescription;
					if (primaryDescription != (TextObject)null)
					{
						string text3 = ((object)primaryDescription).ToString() + "\n" + diseaseBonusText;
						_primaryDescField.SetValue(item, (object?)new TextObject(text3, (Dictionary<string, object>)null));
					}
				}
				num++;
			}
			if (num > 0)
			{
				DiseaseManager.Instance?.LogMessage($"[PERK_PATCH] Injected disease descriptions into {num} Medicine perks");
			}
		}
		catch (Exception ex)
		{
			DiseaseManager.Instance?.LogMessage("[PERK_PATCH] Error: " + ex.Message);
		}
	}

	public static void Reset()
	{
		_applied = false;
	}
}
