using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.TwoDimension.Standalone;

public class OpenGLTexture : ITexture
{
	private int _width;

	private int _height;

	private string _name;

	private GraphicsContext _context;

	private int _id;

	private bool _clampToEdge;

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Width
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Height
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	internal static OpenGLTexture ActiveTexture
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	internal int Id
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool ClampToEdge
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OpenGLTexture()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(string name, int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyFrom(OpenGLTexture texture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Delete()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void MakeActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTextureParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static OpenGLTexture FromFile(ResourceDepot resourceDepot, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static OpenGLTexture FromFile(string fullFilePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Release()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadFromFile(ResourceDepot resourceDepot, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadFromFile(string fullPathName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLoaded()
	{
		throw null;
	}
}
