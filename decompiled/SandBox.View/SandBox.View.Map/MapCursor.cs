using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.View.Map;

public class MapCursor
{
	private const string GameCursorValidDecalMaterialName = "map_cursor_valid_decal";

	private const string GameCursorInvalidDecalMaterialName = "map_cursor_invalid_decal";

	private const float CursorDecalBaseScale = 0.38f;

	private GameEntity _mapCursorDecalEntity;

	private Decal _mapCursorDecal;

	private MapScreen _mapScreen;

	private Material _gameCursorValidDecalMaterial;

	private Material _gameCursorInvalidDecalMaterial;

	private Vec3 _smoothRotationNormalStart;

	private Vec3 _smoothRotationNormalEnd;

	private Vec3 _smoothRotationNormalCurrent;

	private float _smoothRotationAlpha;

	private int _smallAtlasTextureIndex;

	private float _targetCircleRotationStartTime;

	private bool _gameCursorActive;

	private bool _anotherEntityHiglighted;

	private const float _navigationPositionCheckFrequency = 0.2f;

	private float _navigatablePositionCheckTimer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(MapScreen parentMapScreen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeforeTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVisible(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal void OnMapTerrainClick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal void OnAnotherEntityHighlighted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal void SetAlpha(float alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetCircleIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapCursor()
	{
		throw null;
	}
}
