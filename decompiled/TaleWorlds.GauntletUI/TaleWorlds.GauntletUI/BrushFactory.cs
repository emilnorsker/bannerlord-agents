using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public class BrushFactory
{
	private readonly struct BrushOverrideInfo
	{
		public readonly string OriginalBrushName;

		public readonly Brush OverrideBrush;

		public readonly Dictionary<string, string> OverrideBrushAttributes;

		public readonly XmlNode OverrideBrushNode;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BrushOverrideInfo(string originalBrushName, Brush overrideBrush, Dictionary<string, string> overrideBrushAttributes, XmlNode overrideBrushNode)
		{
			throw null;
		}
	}

	private Dictionary<string, BrushOverrideInfo> _overriddenBrushes;

	private Dictionary<string, Brush> _brushes;

	private Dictionary<string, string> _brushCategories;

	private ResourceDepot _resourceDepot;

	private readonly string _resourceFolder;

	private Dictionary<string, DateTime> _lastWriteTimes;

	private SpriteData _spriteData;

	private FontFactory _fontFactory;

	public IEnumerable<Brush> Brushes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Brush DefaultBrush
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event Action BrushChange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BrushFactory(ResourceDepot resourceDepot, string resourceFolder, SpriteData spriteData, FontFactory fontFactory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnResourceChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BrushAnimation LoadBrushAnimationFrom(XmlNode animationNode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadBrushLayerInto(XmlNode styleSpriteNode, IBrushLayerData brushLayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadStyleInto(XmlNode styleNode, Style style)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadSoundPropertiesInto(XmlNode soundPropertiesNode, SoundProperties soundProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Brush LoadBrushFrom(XmlNode brushNode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyBrushAttributesFrom(Brush brush, XmlNode brushNode, Dictionary<string, string> brushAttributes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SaveBrushTo(XmlNode brushNode, Brush brush)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAttributeTo(PropertyInfo targetPropertyInfo, object targetPropertyValue, Dictionary<string, string> attributePairs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadBrushes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadBrushFile(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadBrushFromFileAux(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Brush GetBrush(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SaveBrushAs(string name, Brush brush)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<string> GetBrushesNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckForUpdates()
	{
		throw null;
	}
}
