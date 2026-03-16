using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

public abstract class ScriptComponentBehavior : DotNetObject
{
	[Flags]
	public enum TickRequirement : uint
	{
		None = 0u,
		TickOccasionally = 1u,
		Tick = 2u,
		TickParallel = 4u,
		TickParallel2 = 8u,
		FixedTick = 0x10u,
		FixedParallelTick = 0x20u,
		TickParallel3 = 0x40u
	}

	private static List<ScriptComponentBehavior> _prefabScriptComponents;

	private static List<ScriptComponentBehavior> _undoStackScriptComponents;

	private WeakGameEntity _gameEntity;

	private WeakNativeObjectReference _scriptComponent;

	private TickRequirement _lastTickRequirement;

	private static readonly Dictionary<string, string[]> CachedFields;

	private WeakNativeObjectReference _scene;

	public WeakGameEntity GameEntity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ManagedScriptComponent ScriptComponent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	protected ManagedScriptHolder ManagedScriptHolder
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

	public Scene Scene
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void InvalidateWeakPointersIfValid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptComponentBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ScriptComponentBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Construct(UIntPtr myEntityPtr, ManagedScriptComponent scriptComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetOwnerManagedScriptHolder(ManagedScriptHolder managedScriptHolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetScriptComponentToTickAux(TickRequirement value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScriptComponentToTick(TickRequirement tickReq)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScriptComponentToTickMT(TickRequirement value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal void AddScriptComponentToTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal void RegisterAsPrefabScriptComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal void DeregisterAsPrefabScriptComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal void RegisterAsUndoStackScriptComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal void DeregisterAsUndoStackScriptComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void SetScene(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal void HandleOnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual bool CanPhysicsCollideBetweenTwoEntities(WeakGameEntity myEntity, WeakGameEntity otherEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnParallelFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnTickParallel2(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnTickParallel3(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnTickOccasionally(float currentFrameDeltaTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnPreInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnEditorValidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual bool IsOnlyVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual bool MovesEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual bool DisablesOroCreation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual bool SkeletonPostIntegrateCallback(AnimResult animResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static bool SkeletonPostIntegrateCallbackAux(ScriptComponentBehavior script, UIntPtr animResultPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnSceneSave(string saveFolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual bool OnCheckForProblems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnSaveAsPrefab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnTerrainReload(int step)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal void OnPhysicsCollisionAux(ref PhysicsContact contact, UIntPtr entity0, UIntPtr entity1, bool isFirstShape)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnPhysicsCollision(ref PhysicsContact contact, WeakGameEntity entity0, WeakGameEntity entity1, bool isFirstShape)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnEditModeVisibilityChanged(bool currentVisibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnBoundingBoxValidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	protected internal virtual void OnDynamicNavmeshVertexUpdate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CacheEditableFieldsForAllScriptComponents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string[] CollectEditableFields(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static string[] GetEditableFields(string className)
	{
		throw null;
	}
}
