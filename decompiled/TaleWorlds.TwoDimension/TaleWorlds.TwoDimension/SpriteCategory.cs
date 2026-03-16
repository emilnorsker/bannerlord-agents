using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.TwoDimension;

public class SpriteCategory
{
	protected class SpriteSizeComparer : IComparer<SpritePart>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(SpritePart x, SpritePart y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SpriteSizeComparer()
		{
			throw null;
		}
	}

	public const int SpriteSheetSize = 4096;

	public readonly bool AlwaysLoad;

	private SpriteSizeComparer _spritePartComparer;

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

	public List<SpritePart> SpriteParts
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

	public List<SpritePart> SortedSpritePartList
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

	public List<Texture> SpriteSheets
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

	public int SpriteSheetCount
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

	public bool IsLoaded
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

	public bool IsPartiallyLoaded
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

	public Vec2i[] SheetSizes
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
	public SpriteCategory(string name, int spriteSheetCount, bool alwaysLoad = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Load(ITwoDimensionResourceContext resourceContext, ResourceDepot resourceDepot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Unload()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reload(ITwoDimensionResourceContext resourceContext, ResourceDepot resourceDepot, SpriteCategory newCategoryInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializePartialLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleasePartialLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PartialLoadAtIndex(ITwoDimensionResourceContext resourceContext, ResourceDepot resourceDepot, int sheetIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PartialUnloadAtIndex(int sheetIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SortList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsCategoryFullyLoaded()
	{
		throw null;
	}
}
