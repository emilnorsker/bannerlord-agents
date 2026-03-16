using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

public class ThumbnailCacheNode
{
	public string Key;

	public Texture Value;

	public int FrameNo;

	public int ReferenceCount;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ThumbnailCacheNode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ThumbnailCacheNode(string key, Texture value, int frameNo)
	{
		throw null;
	}
}
