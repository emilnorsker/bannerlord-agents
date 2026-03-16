using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ManagedCallbacks;

internal static class ScriptingInterfaceObjects
{
	private enum LibraryInterfaceGeneratedEnum
	{
		enm_IMono_LibrarySizeChecker_get_engine_struct_member_offset,
		enm_IMono_LibrarySizeChecker_get_engine_struct_size,
		enm_IMono_Managed_decrease_reference_count,
		enm_IMono_Managed_get_class_type_definition,
		enm_IMono_Managed_get_class_type_definition_count,
		enm_IMono_Managed_increase_reference_count,
		enm_IMono_Managed_release_managed_object,
		enm_IMono_NativeArray_add_element,
		enm_IMono_NativeArray_add_float_element,
		enm_IMono_NativeArray_add_integer_element,
		enm_IMono_NativeArray_clear,
		enm_IMono_NativeArray_create,
		enm_IMono_NativeArray_get_data_pointer,
		enm_IMono_NativeArray_get_data_pointer_offset,
		enm_IMono_NativeArray_get_data_size,
		enm_IMono_NativeObjectArray_add_element,
		enm_IMono_NativeObjectArray_clear,
		enm_IMono_NativeObjectArray_create,
		enm_IMono_NativeObjectArray_get_count,
		enm_IMono_NativeObjectArray_get_element_at_index,
		enm_IMono_NativeString_create,
		enm_IMono_NativeString_get_string,
		enm_IMono_NativeString_set_string,
		enm_IMono_NativeStringHelper_create_rglVarString,
		enm_IMono_NativeStringHelper_delete_rglVarString,
		enm_IMono_NativeStringHelper_get_thread_local_cached_rglVarString,
		enm_IMono_NativeStringHelper_set_rglVarString,
		enm_IMono_Telemetry_begin_telemetry_scope,
		enm_IMono_Telemetry_end_telemetry_scope,
		enm_IMono_Telemetry_get_telemetry_level_mask,
		enm_IMono_Telemetry_has_telemetry_connection,
		enm_IMono_Telemetry_start_telemetry_connection,
		enm_IMono_Telemetry_stop_telemetry_connection
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Dictionary<string, object> GetObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetFunctionPointer(int id, IntPtr pointer)
	{
		throw null;
	}
}
