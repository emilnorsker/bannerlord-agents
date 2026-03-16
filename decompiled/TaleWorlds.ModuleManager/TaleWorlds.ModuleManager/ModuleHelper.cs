using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.ModuleManager;

public static class ModuleHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public ModuleInfo module;

		public Func<DependedModule, bool> _003C_003E9__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass32_0()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal bool _003CGetDependentModulesOf_003Eb__1(DependedModule m)
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetDependentModulesOf_003Ed__32 : IEnumerable<ModuleInfo>, IEnumerable, IEnumerator<ModuleInfo>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ModuleInfo _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ModuleInfo module;

		public ModuleInfo _003C_003E3__module;

		private IEnumerable<ModuleInfo> source;

		public IEnumerable<ModuleInfo> _003C_003E3__source;

		private _003C_003Ec__DisplayClass32_0 _003C_003E8__1;

		private List<DependedModule>.Enumerator _003C_003E7__wrap1;

		private IEnumerator<ModuleInfo> _003C_003E7__wrap2;

		ModuleInfo IEnumerator<ModuleInfo>.Current
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
		public _003CGetDependentModulesOf_003Ed__32(int _003C_003E1__state)
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
		private void _003C_003Em__Finally2()
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
		IEnumerator<ModuleInfo> IEnumerable<ModuleInfo>.GetEnumerator()
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

	public const char ModuleVersionSeperator = ':';

	public static bool IsTestMode;

	public const char ModuleCodeSeperator = ';';

	public static readonly MBList<string> ModulesDisablingLoadingAfterBeingRemoved;

	public static readonly MBList<string> ModulesDisablingLoadingAfterBeingAdded;

	private static IPlatformModuleExtension _platformModuleExtension;

	private static Dictionary<string, ModuleInfo> _loadedModules;

	private static List<ModuleInfo> results;

	private static string _pathPrefix
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetModuleFullPath(string moduleId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ModuleInfo GetModuleInfo(string moduleId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnModuleDeactivated(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnModuleActivated(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeModules(string[] loadedModuleIds, string[] platformModulePaths = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ModuleInfo InitializeSingleModule(string modulePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsModuleActive(string moduleId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializePlatformModuleExtension(IPlatformModuleExtension moduleExtension, List<string> args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearPlatformModuleExtension()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<ModuleInfo> GetModuleInfos(string[] moduleIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<ModuleInfo> GetModules(Func<ModuleInfo, bool> cond = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Dictionary<string, ModuleInfo>.ValueCollection GetAllModules()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<ModuleInfo> GetActiveModules()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetMbprojPath(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetXmlPathForNative(string moduleId, string xmlName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetXmlPathForNativeWBase(string moduleId, string xmlName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetXsltPathForNative(string moduleId, string xsltName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPath(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetXmlPath(string moduleId, string xmlName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetXsltPath(string moduleId, string xmlName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetXsdPathForModules(string moduleId, string xsdName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetXsdPath(string xmlInfoId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetDependentModulesOf_003Ed__32))]
	public static IEnumerable<ModuleInfo> GetDependentModulesOf(IEnumerable<ModuleInfo> source, ModuleInfo module)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<ModuleInfo> GetSortedModules(string[] moduleIDs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<ModuleInfo> GetModulesForLauncher()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<string> GetOfficialModuleIds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<ModuleInfo> GetPhysicalModules(bool isLauncher)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<Assembly> GetActiveGameAssemblies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsAssemblyDirectlyReferencedInModule(Assembly assembly, ModuleInfo moduleInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsGameAssembly(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<ModuleInfo> GetPlatformModules(string[] platformModulePaths = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ModuleHelper()
	{
		throw null;
	}
}
