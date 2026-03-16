using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBBannerlordTableauManager : IMBBannerlordTableauManager
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNumberOfPendingTableauRequestsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void InitializeCharacterTableauRenderSystemDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RequestCharacterTableauRenderDelegate(int characterCodeId, byte[] path, UIntPtr poseEntity, UIntPtr cameraObject, int tableauType);

	private static readonly Encoding _utf8;

	public static GetNumberOfPendingTableauRequestsDelegate call_GetNumberOfPendingTableauRequestsDelegate;

	public static InitializeCharacterTableauRenderSystemDelegate call_InitializeCharacterTableauRenderSystemDelegate;

	public static RequestCharacterTableauRenderDelegate call_RequestCharacterTableauRenderDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfPendingTableauRequests()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeCharacterTableauRenderSystem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RequestCharacterTableauRender(int characterCodeId, string path, UIntPtr poseEntity, UIntPtr cameraObject, int tableauType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBBannerlordTableauManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBBannerlordTableauManager()
	{
		throw null;
	}
}
