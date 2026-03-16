using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

public static class ManagedExtensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnEditorVariableChanged(DotNetObject managedObject, uint classNameHash, uint fieldNameHash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldString(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, string value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldDouble(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, double value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldFloat(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, float value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldBool(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, bool value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldInt(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, int value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldVec3(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, Vec3 value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldEntity(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldTexture(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldMesh(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldMaterial(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldColor(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, Vec3 value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldMatrixFrame(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, MatrixFrame value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void SetObjectFieldEnum(DotNetObject managedObject, uint classNameHash, uint fieldNameHash, string value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void GetObjectField(DotNetObject managedObject, uint classNameHash, ref ScriptComponentFieldHolder scriptComponentFieldHolder, uint fieldNameHash, RglScriptFieldType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void CopyObjectFieldsFrom(DotNetObject dst, DotNetObject src, string className, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static DotNetObject CreateScriptComponentInstance(string className, UIntPtr entityPtr, ManagedScriptComponent managedScriptComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static string GetScriptComponentClassNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static bool GetEditorVisibilityOfField(uint classNameHash, uint fieldNamehash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static RglScriptFieldType GetTypeOfField(uint classNameHash, uint fieldNameHash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void ForceGarbageCollect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void CollectCommandLineFunctions()
	{
		throw null;
	}
}
