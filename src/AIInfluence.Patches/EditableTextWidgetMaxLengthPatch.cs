using HarmonyLib;
using TaleWorlds.GauntletUI.BaseTypes;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(EditableTextWidget), "get_MaxLength")]
public static class EditableTextWidgetMaxLengthPatch
{
	private const int NewMaxLength = 2048;

	private const int OldMaxLength = 512;

	[HarmonyPostfix]
	public static void Postfix(ref int __result)
	{
		if (__result <= 512)
		{
			__result = 2048;
		}
	}
}
