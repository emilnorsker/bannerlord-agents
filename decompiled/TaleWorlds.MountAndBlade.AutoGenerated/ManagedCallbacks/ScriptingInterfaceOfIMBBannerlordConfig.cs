using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBBannerlordConfig : IMBBannerlordConfig
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ValidateOptionsDelegate();

	private static readonly Encoding _utf8;

	public static ValidateOptionsDelegate call_ValidateOptionsDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ValidateOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBBannerlordConfig()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBBannerlordConfig()
	{
		throw null;
	}
}
