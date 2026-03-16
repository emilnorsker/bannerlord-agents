using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public abstract class TextureProvider
{
	private Dictionary<string, MethodInfo> _getGetMethodCache;

	public string SourceInfo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void SetTargetSize(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture GetTextureForRender(TwoDimensionContext context, string name = null)
	{
		throw null;
	}

	protected abstract Texture OnGetTextureForRender(TwoDimensionContext twoDimensionContext, string name);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Clear(bool clearNextFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetProperty(string name, object value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetProperty(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected TextureProvider()
	{
		throw null;
	}
}
