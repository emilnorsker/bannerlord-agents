using System.Runtime.CompilerServices;
using SandBox.Objects.Usables;

namespace SandBox.Objects;

public class GroupSpawnPoint : UsablePlace
{
	public float Delay;

	public int SpawnCount;

	public bool IsInstant
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GroupSpawnPoint()
	{
		throw null;
	}
}
