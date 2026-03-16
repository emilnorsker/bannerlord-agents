using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.SaveSystem.Load;
using TaleWorlds.SaveSystem.Resolvers;

namespace TaleWorlds.SaveSystem.Definition;

public class TypeDefinition : TypeDefinitionBase
{
	[CompilerGenerated]
	private sealed class _003CGetFieldsOfType_003Ed__34 : IEnumerable<FieldInfo>, IEnumerable, IEnumerator<FieldInfo>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private FieldInfo _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Type type;

		public Type _003C_003E3__type;

		private Type _003CtypeToCheck_003E5__2;

		private FieldInfo[] _003C_003E7__wrap2;

		private int _003C_003E7__wrap3;

		FieldInfo IEnumerator<FieldInfo>.Current
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
		public _003CGetFieldsOfType_003Ed__34(int _003C_003E1__state)
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
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<FieldInfo> IEnumerable<FieldInfo>.GetEnumerator()
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

	private Dictionary<MemberTypeId, PropertyDefinition> _properties;

	private Dictionary<MemberTypeId, FieldDefinition> _fields;

	private List<string> _errors;

	private List<MethodInfo> _initializationCallbacks;

	private List<MethodInfo> _lateInitializationCallbacks;

	private bool _isClass;

	private readonly IObjectResolver _objectResolver;

	public List<MemberDefinition> MemberDefinitions
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

	public IEnumerable<MethodInfo> InitializationCallbacks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IEnumerable<MethodInfo> LateInitializationCallbacks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IEnumerable<string> Errors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsClassDefinition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public List<CustomField> CustomFields
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

	public CollectObjectsDelegate CollectObjectsMethod
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

	public Dictionary<MemberTypeId, PropertyDefinition>.ValueCollection PropertyDefinitions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Dictionary<MemberTypeId, FieldDefinition>.ValueCollection FieldDefinitions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TypeDefinition(Type type, SaveId saveId, IObjectResolver objectResolver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TypeDefinition(Type type, int saveId, IObjectResolver objectResolver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfRequiresAdvancedResolving(object originalObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object ResolveObject(object originalObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object AdvancedResolveObject(object originalObject, MetaData metaData, ObjectLoadData objectLoadData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CollectInitializationCallbacks()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CollectProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetFieldsOfType_003Ed__34))]
	private static IEnumerable<FieldInfo> GetFieldsOfType(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CollectFields()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddCustomField(string fieldName, short saveId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PropertyDefinition GetPropertyDefinitionWithId(MemberTypeId id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FieldDefinition GetFieldDefinitionWithId(MemberTypeId id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeForAutoGeneration(CollectObjectsDelegate collectObjectsDelegate)
	{
		throw null;
	}
}
