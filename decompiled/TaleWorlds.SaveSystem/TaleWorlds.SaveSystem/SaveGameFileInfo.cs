using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem;

public class SaveGameFileInfo
{
	public string Name;

	public MetaData MetaData;

	public bool IsCorrupted;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveGameFileInfo()
	{
		throw null;
	}
}
