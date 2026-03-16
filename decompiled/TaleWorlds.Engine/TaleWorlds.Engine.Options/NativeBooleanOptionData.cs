using System.Runtime.CompilerServices;

namespace TaleWorlds.Engine.Options;

public class NativeBooleanOptionData : NativeOptionData, IBooleanOptionData, IOptionData
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public NativeBooleanOptionData(NativeOptions.NativeOptionsType type)
	{
		throw null;
	}
}
