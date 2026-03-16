using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI.PrefabSystem;

public abstract class WidgetAttributeKeyType
{
	public abstract bool CheckKeyType(string key);

	public abstract string GetKeyName(string key);

	public abstract string GetSerializedKey(string key);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected WidgetAttributeKeyType()
	{
		throw null;
	}
}
