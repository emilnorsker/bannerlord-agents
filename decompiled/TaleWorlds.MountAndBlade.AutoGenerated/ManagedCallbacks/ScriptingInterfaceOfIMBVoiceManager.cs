using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBVoiceManager : IMBVoiceManager
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetVoiceDefinitionCountWithMonsterSoundAndCollisionInfoClassNameDelegate(byte[] className);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetVoiceDefinitionListWithMonsterSoundAndCollisionInfoClassNameDelegate(byte[] className, IntPtr definitionIndices);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetVoiceTypeIndexDelegate(byte[] voiceType);

	private static readonly Encoding _utf8;

	public static GetVoiceDefinitionCountWithMonsterSoundAndCollisionInfoClassNameDelegate call_GetVoiceDefinitionCountWithMonsterSoundAndCollisionInfoClassNameDelegate;

	public static GetVoiceDefinitionListWithMonsterSoundAndCollisionInfoClassNameDelegate call_GetVoiceDefinitionListWithMonsterSoundAndCollisionInfoClassNameDelegate;

	public static GetVoiceTypeIndexDelegate call_GetVoiceTypeIndexDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetVoiceDefinitionCountWithMonsterSoundAndCollisionInfoClassName(string className)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetVoiceDefinitionListWithMonsterSoundAndCollisionInfoClassName(string className, int[] definitionIndices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetVoiceTypeIndex(string voiceType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBVoiceManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBVoiceManager()
	{
		throw null;
	}
}
