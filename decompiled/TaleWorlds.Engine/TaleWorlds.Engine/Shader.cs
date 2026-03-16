using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Engine;

public sealed class Shader : Resource
{
	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Shader(UIntPtr ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Shader GetFromResource(string shaderName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetMaterialShaderFlagMask(string flagName, bool showErrors = true)
	{
		throw null;
	}
}
