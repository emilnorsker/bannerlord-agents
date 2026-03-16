using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace TaleWorlds.Core;

public class ShipPhysicsReference : MBObjectBase
{
	public static readonly ShipPhysicsReference Default;

	public static readonly ShipPhysicsReference DefaultDebris;

	public LinearFrictionTerm LinearDragTerm
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

	public LinearFrictionTerm LinearDampingTerm
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

	public LinearFrictionTerm ConstantLinearDampingTerm
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
	static ShipPhysicsReference()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipPhysicsReference()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipPhysicsReference(string stringId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Deserialize(MBObjectManager objectManager, XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PostProcessPhysicsReference()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDefaultWaterDensity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T DeserializeScalarAttribute<T>(XmlNode node, string attributeName, bool isRequiredAttribute, out bool isAttributeValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 DeserializeVectorElement(XmlNode node, string elementName, bool isRequiredElement, out bool isElementValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LinearFrictionTerm DeserializeDragTermElement(XmlNode node, string elementName, out bool isElementValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AssertFieldValidity(bool assert, string fieldName)
	{
		throw null;
	}
}
