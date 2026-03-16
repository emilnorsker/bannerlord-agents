using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class BoundaryWallView : ScriptComponentBehavior
{
	private List<Vec2> _lastPoints;

	private List<Vec2> _lastAttackerPoints;

	private List<Vec2> _lastDefenderPoints;

	private float timer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CalculateBoundaries(string vertexTag, ref List<Vec2> lastPoints)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mesh CreateBoundaryMesh(Scene scene, ICollection<Vec2> boundaryPoints, uint meshColor = 536918784u)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoundaryWallView()
	{
		throw null;
	}
}
