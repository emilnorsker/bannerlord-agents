using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.PrefabSystem;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI.CodeGenerator;

public class UICodeGenerationContext
{
	private List<WidgetTemplateGenerateContext> _widgetTemplateGenerateContexts;

	private readonly string _nameSpace;

	private readonly string _outputFolder;

	public ResourceDepot ResourceDepot
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

	public WidgetFactory WidgetFactory
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

	public FontFactory FontFactory
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

	public BrushFactory BrushFactory
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

	public SpriteData SpriteData
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
	public UICodeGenerationContext(string nameSpace, string outputFolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Prepare(IEnumerable<string> resourceLocations, IEnumerable<PrefabExtension> prefabExtensions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPrefabVariant(string prefabName, string variantName, UICodeGenerationVariantExtension variantExtension, Dictionary<string, object> data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ClearFolder(string folderName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Generate()
	{
		throw null;
	}
}
