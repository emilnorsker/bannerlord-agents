using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineStruct("rglWorld_position::Plain_world_position", false, null)]
public struct WorldPosition
{
	public enum WorldPositionEnforcedCache
	{
		None,
		NavMeshVec3,
		GroundVec3
	}

	private readonly UIntPtr _scene;

	private UIntPtr _navMesh;

	private UIntPtr _nearestNavMesh;

	private Vec3 _position;

	[CustomEngineStructMemberData("normal_")]
	public Vec3 Normal;

	private Vec2 _lastValidZPosition;

	[CustomEngineStructMemberData("z_validity_state_")]
	public ZValidityState State;

	public static readonly WorldPosition Invalid;

	public Vec2 AsVec2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float X
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Y
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal WorldPosition(UIntPtr scenePointer, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal WorldPosition(UIntPtr scenePointer, UIntPtr navMesh, Vec3 position, bool hasValidZ)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition(Scene scene, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition(Scene scene, UIntPtr navMesh, Vec3 position, bool hasValidZ)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVec3(UIntPtr navMesh, Vec3 position, bool hasValidZ)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ValidateZ(ZValidityState minimumValidityState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ValidateZMT(ZValidityState minimumValidityState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetNavMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetNavMeshMT()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetNearestNavMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetNavMeshZ()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetNavMeshZMT()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetGroundZ()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetGroundZMT()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetNavMeshVec3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetNavMeshVec3MT()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetGroundVec3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetGroundVec3MT()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetVec3WithoutValidity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVec2MT(Vec2 value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVec2(Vec2 value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float DistanceSquaredWithLimit(in Vec3 targetPoint, float limitSquared)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static WorldPosition()
	{
		throw null;
	}
}
