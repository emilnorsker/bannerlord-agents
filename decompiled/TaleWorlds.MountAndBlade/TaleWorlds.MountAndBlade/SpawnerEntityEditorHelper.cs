using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class SpawnerEntityEditorHelper
{
	public enum Axis
	{
		x,
		y,
		z
	}

	public enum PermissionType
	{
		scale,
		rotation
	}

	public struct Permission
	{
		public PermissionType TypeOfPermission;

		public Axis PermittedAxis;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Permission(PermissionType permission, Axis axis)
		{
			throw null;
		}
	}

	private List<Tuple<string, Permission, Action<float>>> _stableChildrenPermissions;

	private ScriptComponentBehavior spawner_;

	private List<KeyValuePair<string, MatrixFrame>> stableChildrenFrames;

	public bool LockGhostParent;

	private bool _ghostMovementMode;

	private PathTracker _tracker;

	private float _ghostObjectPosition;

	private string _pathName;

	private bool _enableAutoGhostMovement;

	private readonly List<GameEntity> _wheels;

	public bool IsValid
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

	public GameEntity SpawnedGhostEntity
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
	public SpawnerEntityEditorHelper(ScriptComponentBehavior spawner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetGhostEntityOrChild(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GivePermission(string childName, Permission permission, Action<float> onChangeFunction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyPermissions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChangeStableChildMatrixFrame(string childName, MatrixFrame matrixFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeStableChildMatrixFrameAndApply(string childName, MatrixFrame matrixFrame, bool updateTriad = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity AddGhostEntity(WeakGameEntity parent, List<string> possibleEntityNames)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SyncMatrixFrames(bool first)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetChildrenInitialFrames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<string> GetGhostName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetPrefabName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetupGhostMovement(string pathName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnableAutoGhostMovement(bool enableAutoGhostMovement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateGhostMovement(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame LinearInterpolatedIK(ref PathTracker pathTracker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static object GetFieldValue(object src, string propName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool HasField(object obj, string propertyName, bool findRestricted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool SetSpawnerMatrixFrame(object target, string propertyName, MatrixFrame value)
	{
		throw null;
	}
}
