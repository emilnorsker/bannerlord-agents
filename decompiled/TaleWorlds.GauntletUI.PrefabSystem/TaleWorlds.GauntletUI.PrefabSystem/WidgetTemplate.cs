using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.GauntletUI.PrefabSystem;

public class WidgetTemplate
{
	[CompilerGenerated]
	private sealed class _003CGetAttributesOf_003Ed__39<TKey, TValue> : IEnumerable<WidgetAttributeTemplate>, IEnumerable, IEnumerator<WidgetAttributeTemplate>, IEnumerator, IDisposable where TKey : WidgetAttributeKeyType where TValue : WidgetAttributeValueType
	{
		private int _003C_003E1__state;

		private WidgetAttributeTemplate _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public WidgetTemplate _003C_003E4__this;

		private IEnumerator<WidgetAttributeTemplate> _003C_003E7__wrap1;

		WidgetAttributeTemplate IEnumerator<WidgetAttributeTemplate>.Current
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
		public _003CGetAttributesOf_003Ed__39(int _003C_003E1__state)
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
		IEnumerator<WidgetAttributeTemplate> IEnumerable<WidgetAttributeTemplate>.GetEnumerator()
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

	[CompilerGenerated]
	private sealed class _003Cget_AllAttributes_003Ed__41 : IEnumerable<WidgetAttributeTemplate>, IEnumerable, IEnumerator<WidgetAttributeTemplate>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private WidgetAttributeTemplate _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public WidgetTemplate _003C_003E4__this;

		private Dictionary<Type, Dictionary<string, WidgetAttributeTemplate>>.ValueCollection.Enumerator _003C_003E7__wrap1;

		private Dictionary<string, WidgetAttributeTemplate>.ValueCollection.Enumerator _003C_003E7__wrap2;

		WidgetAttributeTemplate IEnumerator<WidgetAttributeTemplate>.Current
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
		public _003Cget_AllAttributes_003Ed__41(int _003C_003E1__state)
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
		IEnumerator<WidgetAttributeTemplate> IEnumerable<WidgetAttributeTemplate>.GetEnumerator()
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

	private string _type;

	private WidgetFactory _usedFactory;

	private List<WidgetTemplate> _children;

	private List<WidgetTemplate> _customTypeChildren;

	private Dictionary<Type, Dictionary<string, WidgetAttributeTemplate>> _attributes;

	private Dictionary<string, object> _extensionData;

	public bool LogicalChildrenLocation
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

	public string Id
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string Type
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int ChildCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Dictionary<string, WidgetAttributeTemplate> GivenParameters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public WidgetPrefab Prefab
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

	public WidgetTemplate RootTemplate
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Dictionary<Type, Dictionary<string, WidgetAttributeTemplate>> Attributes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public object Tag
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public IEnumerable<WidgetAttributeTemplate> AllAttributes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_AllAttributes_003Ed__41))]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WidgetTemplate(string type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void LoadAttributeCollection(WidgetAttributeContext widgetAttributeContext, XmlAttributeCollection attributes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddExtensionData(string name, object data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetExtensionData<T>(string name) where T : class
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveExtensionData(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddExtensionData(object data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetExtensionData<T>() where T : class
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveExtensionData<T>() where T : class
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<WidgetAttributeTemplate> GetAttributesOf<T>() where T : WidgetAttributeKeyType
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetAttributesOf_003Ed__39<, >))]
	public IEnumerable<WidgetAttributeTemplate> GetAttributesOf<TKey, TValue>() where TKey : WidgetAttributeKeyType where TValue : WidgetAttributeValueType
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WidgetAttributeTemplate GetFirstAttributeIfExist<T>() where T : WidgetAttributeKeyType
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAttribute(WidgetAttributeTemplate attribute)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WidgetTemplate GetChildAt(int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddChild(WidgetTemplate child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveChild(WidgetTemplate child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwapChildren(WidgetTemplate child1, WidgetTemplate child2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WidgetInstantiationResult Instantiate(WidgetCreationData widgetCreationData, Dictionary<string, WidgetAttributeTemplate> parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WidgetInstantiationResult CreateWidgets(WidgetCreationData widgetCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnRelease()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAttributes(WidgetCreationData widgetCreationData, WidgetInstantiationResult widgetInstantiationResult, Dictionary<string, WidgetAttributeTemplate> parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WidgetTemplate LoadFrom(PrefabExtensionContext prefabExtensionContext, WidgetAttributeContext widgetAttributeContext, XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRootTemplate(WidgetPrefab prefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAttributeTo(WidgetAttributeContext widgetAttributeContext, string name, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAttributeFrom(WidgetAttributeContext widgetAttributeContext, string fullName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAttributeFrom<T>(string name) where T : WidgetAttributeKeyType
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAttributeFrom(WidgetAttributeKeyType keyType, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddAttributeTo(XmlNode node, string name, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Save(PrefabExtensionContext prefabExtensionContext, XmlNode parentNode)
	{
		throw null;
	}
}
