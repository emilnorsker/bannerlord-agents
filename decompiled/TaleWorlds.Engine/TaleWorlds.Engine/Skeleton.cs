using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineClass("rglSkeleton")]
public sealed class Skeleton : NativeObject
{
	[CompilerGenerated]
	private sealed class _003CGetAllMeshes_003Ed__57 : IEnumerable<Mesh>, IEnumerable, IEnumerator<Mesh>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Mesh _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public Skeleton _003C_003E4__this;

		private IEnumerator<NativeObject> _003C_003E7__wrap1;

		Mesh IEnumerator<Mesh>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetAllMeshes_003Ed__57(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<Mesh> IEnumerable<Mesh>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	public const sbyte MaxBoneCount = 64;

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Skeleton(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Skeleton CreateFromModel(string modelName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Skeleton CreateFromModelWithNullAnimTree(GameEntity entity, string modelName, float boneScale = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetBoneName(sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetBoneChildAtIndex(sbyte boneIndex, sbyte childIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetBoneChildCount(sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetParentBoneIndex(sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMeshToBone(UIntPtr mesh, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Freeze(bool p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFrozen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBoneLocalFrame(sbyte boneIndex, MatrixFrame localFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetBoneCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneBody(sbyte boneIndex, ref CapsuleData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SkeletonModelExist(string skeletonModelName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceUpdateBoneFrames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetBoneEntitialFrameWithIndex(sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetBoneEntitialFrameWithName(string boneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RagdollState GetCurrentRagdollState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateRagdoll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetSkeletonBoneMapping(sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMesh(Mesh mesh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearComponents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddComponent(GameEntityComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasComponent(GameEntityComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveComponent(GameEntityComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearMeshes(bool clearBoneComponents = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetComponentCount(GameEntity.ComponentType componentType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateEntitialFramesFromLocalFrames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetFrames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntityComponent GetComponentAtIndex(GameEntity.ComponentType componentType, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsePreciseBoundingVolume(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetBoneEntitialRestFrame(sbyte boneIndex, bool useBoneMapping)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetBoneLocalRestFrame(sbyte boneIndex, bool useBoneMapping = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetBoneEntitialRestFrame(sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetBoneEntitialFrameAtChannel(int channelNo, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetBoneEntitialFrame(sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetBoneComponentCount(sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntityComponent GetBoneComponentAtIndex(sbyte boneIndex, int componentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasBoneComponent(sbyte boneIndex, GameEntityComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddComponentToBone(sbyte boneIndex, GameEntityComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveBoneComponent(sbyte boneIndex, GameEntityComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearMeshesAtBone(sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickAnimations(float dt, MatrixFrame globalFrame, bool tickAnimsForChildren)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickAnimationsAndForceUpdate(float dt, MatrixFrame globalFrame, bool tickAnimsForChildren)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAnimationParameterAtChannel(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnimationParameterAtChannel(int channelNo, float parameter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAnimationSpeedAtChannel(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnimationSpeedAtChannel(int channelNo, float speed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUptoDate(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAnimationAtChannel(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAnimationIndexAtChannel(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableScriptDrivenPostIntegrateCallback()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetCloths()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetAllMeshes_003Ed__57))]
	public IEnumerable<Mesh> GetAllMeshes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static sbyte GetBoneIndexFromName(string skeletonModelName, string boneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Transformation GetEntitialOutTransform(UIntPtr animResultPointer, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetOutBoneDisplacement(UIntPtr animResultPointer, sbyte boneIndex, Vec3 displacement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetOutQuat(UIntPtr animResultPointer, sbyte boneIndex, Mat3 rotation)
	{
		throw null;
	}
}
