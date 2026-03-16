using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBTeam : IMBTeam
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsEnemyDelegate(UIntPtr missionPointer, int teamIndex, int otherTeamIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetIsEnemyDelegate(UIntPtr missionPointer, int teamIndex, int otherTeamIndex, [MarshalAs(UnmanagedType.U1)] bool isEnemy);

	private static readonly Encoding _utf8;

	public static IsEnemyDelegate call_IsEnemyDelegate;

	public static SetIsEnemyDelegate call_SetIsEnemyDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEnemy(UIntPtr missionPointer, int teamIndex, int otherTeamIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsEnemy(UIntPtr missionPointer, int teamIndex, int otherTeamIndex, bool isEnemy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBTeam()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBTeam()
	{
		throw null;
	}
}
