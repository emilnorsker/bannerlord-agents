using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Library;

namespace TaleWorlds.TwoDimension;

public class SpriteData
{
	private struct SpriteDataLoadResult
	{
		public Dictionary<string, SpritePart> SpritePartNames;

		public Dictionary<string, Sprite> SpriteNames;

		public Dictionary<string, SpriteCategory> SpriteCategories;
	}

	public Dictionary<string, SpritePart> SpriteParts
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

	public Dictionary<string, Sprite> Sprites
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

	public Dictionary<string, SpriteCategory> SpriteCategories
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

	public string Name
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpriteData(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Sprite GetSprite(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SpriteExists(string spriteName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static SpriteDataLoadResult LoadFromDepot(ResourceDepot resourceDepot, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static SpriteDataLoadResult LoadSpriteDataFromFile(XmlDocument spriteData, string filePath, ref SpriteDataLoadResult loadResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Load(ResourceDepot resourceDepot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reload(ResourceDepot resourceDepot, ITwoDimensionResourceContext resourceContext)
	{
		throw null;
	}
}
