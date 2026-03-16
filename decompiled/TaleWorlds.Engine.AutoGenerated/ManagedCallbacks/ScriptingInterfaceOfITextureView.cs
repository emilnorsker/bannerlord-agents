using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfITextureView : ITextureView
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateTextureViewDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetTextureDelegate(UIntPtr pointer, UIntPtr texture_ptr);

	private static readonly Encoding _utf8;

	public static CreateTextureViewDelegate call_CreateTextureViewDelegate;

	public static SetTextureDelegate call_SetTextureDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextureView CreateTextureView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTexture(UIntPtr pointer, UIntPtr texture_ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfITextureView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfITextureView()
	{
		throw null;
	}
}
