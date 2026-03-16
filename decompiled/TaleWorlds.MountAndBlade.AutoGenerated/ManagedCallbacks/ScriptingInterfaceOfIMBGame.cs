using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBGame : IMBGame
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void LoadModuleDataDelegate([MarshalAs(UnmanagedType.U1)] bool isLoadGame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void StartNewDelegate();

	private static readonly Encoding _utf8;

	public static LoadModuleDataDelegate call_LoadModuleDataDelegate;

	public static StartNewDelegate call_StartNewDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadModuleData(bool isLoadGame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartNew()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBGame()
	{
		throw null;
	}
}
