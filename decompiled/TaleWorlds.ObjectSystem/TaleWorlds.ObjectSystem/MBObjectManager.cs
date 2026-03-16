using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using TaleWorlds.Library;

namespace TaleWorlds.ObjectSystem;

public sealed class MBObjectManager
{
	internal interface IObjectTypeRecord : IEnumerable
	{
		bool AutoCreate { get; }

		string ElementName { get; }

		string ElementListName { get; }

		Type ObjectClass { get; }

		uint TypeNo { get; }

		bool IsTemporary { get; }

		void ReInitialize();

		MBObjectBase CreatePresumedMBObject(string objectName);

		void RegisterMBObject(MBObjectBase obj, bool presumed, out MBObjectBase registeredObject);

		void RegisterMBObjectWithoutInitialization(MBObjectBase obj);

		void UnregisterMBObject(MBObjectBase obj);

		MBObjectBase GetFirstMBObject();

		MBObjectBase GetMBObject(string objId);

		MBObjectBase GetMBObject(MBGUID objId);

		bool ContainsObject(string objId);

		string DebugDump();

		string DebugBasicDump();

		IEnumerable GetList();

		void PreAfterLoad();

		void AfterLoad();
	}

	internal class ObjectTypeRecord<T> : IObjectTypeRecord, IEnumerable, IEnumerable<T> where T : MBObjectBase
	{
		[CompilerGenerated]
		private sealed class _003CEnumerateElements_003Ed__46 : IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			public ObjectTypeRecord<T> _003C_003E4__this;

			private int _003Ci_003E5__2;

			T IEnumerator<T>.Current
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
			public _003CEnumerateElements_003Ed__46(int _003C_003E1__state)
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
		}

		private readonly bool _autoCreate;

		private readonly string _elementName;

		private readonly string _elementListName;

		private uint _objCount;

		private readonly uint _typeNo;

		private readonly bool _isTemporary;

		private readonly Dictionary<string, T> _registeredObjects;

		private readonly Dictionary<MBGUID, T> _registeredObjectsWithGuid;

		bool IObjectTypeRecord.AutoCreate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		string IObjectTypeRecord.ElementName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		string IObjectTypeRecord.ElementListName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		Type IObjectTypeRecord.ObjectClass
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		uint IObjectTypeRecord.TypeNo
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		bool IObjectTypeRecord.IsTemporary
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		internal MBList<T> RegisteredObjectsList
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal ObjectTypeRecord(uint newTypeNo, string classPrefix, string classListPrefix, bool autoCreate, bool isTemporary)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IObjectTypeRecord.ReInitialize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal MBGUID GetNewId()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		MBObjectBase IObjectTypeRecord.CreatePresumedMBObject(string objectName)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private T CreatePresumedObject(string stringId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		MBObjectBase IObjectTypeRecord.GetMBObject(string objId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		MBObjectBase IObjectTypeRecord.GetFirstMBObject()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal T GetFirstObject()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal T GetObject(string objId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		bool IObjectTypeRecord.ContainsObject(string objId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MBObjectBase GetMBObject(MBGUID objId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IObjectTypeRecord.RegisterMBObjectWithoutInitialization(MBObjectBase mbObject)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IObjectTypeRecord.RegisterMBObject(MBObjectBase obj, bool presumed, out MBObjectBase registeredObject)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void RegisterObject(T obj, bool presumed, out MBObjectBase registeredObject)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private (string str, long number) GetIdParts(string stringId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IObjectTypeRecord.UnregisterMBObject(MBObjectBase obj)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UnregisterObject(T obj)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal MBReadOnlyList<T> GetObjectsList()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		IEnumerable IObjectTypeRecord.GetList()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		string IObjectTypeRecord.DebugDump()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		string IObjectTypeRecord.DebugBasicDump()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(ObjectTypeRecord<>._003CEnumerateElements_003Ed__46))]
		private IEnumerator<T> EnumerateElements()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IObjectTypeRecord.PreAfterLoad()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IObjectTypeRecord.AfterLoad()
		{
			throw null;
		}
	}

	internal List<IObjectTypeRecord> ObjectTypeRecords;

	private List<IObjectManagerHandler> _handlers;

	public static MBObjectManager Instance
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

	public int NumRegisteredTypes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int MaxRegisteredTypes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBObjectManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBObjectManager Init()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Destroy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterType<T>(string classPrefix, string classListPrefix, uint typeId, bool autoCreateInstance = true, bool isTemporary = false) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasType<T>() where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasType(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HasTypeInternal(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string FindRegisteredClassPrefix(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Type FindRegisteredType(string classPrefix)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T RegisterObject<T>(T obj) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T RegisterPresumedObject<T>(T obj) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void TryRegisterObjectWithoutInitialization(MBObjectBase obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterObjectInternalWithoutTypeId<T>(T obj, bool presumed, out MBObjectBase registeredObject) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnregisterObject(MBObjectBase obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AfterUnregisterObject(MBObjectBase obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetObject<T>(Func<T, bool> predicate) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<T> GetObjects<T>(Func<T, bool> predicate) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetObject<T>(string objectName) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetFirstObject<T>() where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsObject<T>(string objectName) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveTemporaryTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreAfterLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AfterLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBObjectBase GetObject(MBGUID objectId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBObjectBase GetObject(string typeName, string objectName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBObjectBase GetPresumedObject(string typeName, string objectName, bool isInitialize = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<T> GetObjectTypeList<T>() where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IList<MBObjectBase> CreateObjectTypeList(Type objectClassType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadXML(string id, bool isDevelopment, string gameType, bool skipXmlFilterForEditor = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool MergeElementAttributes(XElement element1, XElement element2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MergeElements(XElement element1, XElement element2, string xsdPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static XmlDocument GetMergedXmlForManaged(string id, bool skipValidation, bool ignoreGameTypeInclusionCheck = true, string gameType = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static XmlDocument GetMergedXmlForNative(string id, out List<string> usedPaths)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool HandleXsltList(string xslPath, ref List<string> xsltList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static XmlDocument CreateMergedXmlFile(List<Tuple<string, string>> toBeMerged, List<string> xsltList, bool skipValidation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static XmlDocument ApplyXslt(string xsltPath, XmlDocument baseDocument)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static XmlDocument MergeTwoXmls(XmlDocument xmlDocument1, XmlDocument xmlDocument2, string xsdPath, bool keepDuplicates)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static XDocument ToXDocument(XmlDocument xmlDocument)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static XmlDocument ToXmlDocument(XDocument xDocument)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadOneXmlFromFile(string xmlPath, string xsdPath, bool skipValidation = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public XmlDocument LoadXMLFromFileSkipValidation(string xmlPath, string xsdPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void LoadXmlWithValidation(string xmlPath, string xsdPath, XmlDocument xmlDocument)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool HasAttibuteAux(XmlSchemaAttribute schemaAttribute, string localName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool HasAttribute(XmlSchemaComplexType complexType, string localName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void InjectAttribute(XmlSchemaComplexType complexType, XmlQualifiedName qualifiedName, string attributeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void InjectOptionalAttrToAllComplexTypes(XmlSchemaSet set, string type, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void WalkParticle(XmlSchemaParticle particle, XmlQualifiedName xsType, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ValidationEventHandler(object sender, ValidationEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static XmlDocument CreateDocumentFromXmlFile(string xmlPath, string xsdPath, bool forceSkipValidation = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadXml(XmlDocument doc, bool isDevelopment = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBObjectBase CreateObjectFromXmlNode(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBObjectBase CreateObjectFromXmlNode(XmlNode node, string typeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBObjectBase CreateObjectWithoutDeserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnregisterNonReadyObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAllObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAllObjectsWithType(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T ReadObjectReferenceFromXml<T>(string attributeName, XmlNode node) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBObjectBase ReadObjectReferenceFromXml(string attributeName, Type objectType, XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T CreateObject<T>(string stringId) where T : MBObjectBase, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T CreateObject<T>() where T : MBObjectBase, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DebugPrint(PrintOutputDelegate printOutput)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddHandler(IObjectManagerHandler handler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveHandler(IObjectManagerHandler handler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string DebugDump()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetObjectTypeIds()
	{
		throw null;
	}
}
