using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.PrefabSystem;
using TaleWorlds.Library;
using TaleWorlds.Library.CodeGeneration;

namespace TaleWorlds.GauntletUI.CodeGenerator;

public class UICodeGenerationDatabindingVariantExtension : UICodeGenerationVariantExtension
{
	private WidgetTemplateGenerateContext _widgetTemplateGenerateContext;

	private Type _dataSourceType;

	private List<WidgetCodeGenerationInfoDatabindingExtension> _extensions;

	private Dictionary<BindingPath, List<WidgetCodeGenerationInfoDatabindingExtension>> _extensionsWithPath;

	private List<BindingPathTargetDetails> _bindingPathTargetDetailsList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PrefabExtension GetPrefabExtension()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AddExtensionVariables(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Initialize(WidgetTemplateGenerateContext widgetTemplateGenerateContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Type GetAttributeType(WidgetAttributeTemplate widgetAttributeTemplate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetDatasourceVariableNameOfPath(BindingPath bindingPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetViewModelCodeWriteableTypeAtPath(BindingPath bindingPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillDataSourceVariables(BindingPathTargetDetails bindingPathTargetDetails, ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateSetDataSourceVariables(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateSetDataSourceMethod(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetGenericTypeCodeFileName(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateDestroyDataSourceyMethod(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateRefreshBindingWithChildrenMethod(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillRefreshDataSourceMethodClearSection(BindingPathTargetDetails bindingPathTargetDetails, MethodCode methodCode, bool forDestroy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddDataSourcePropertyChangedMethod(MethodCode methodCode, string dataSourceVariableName, string typeModifier, bool add)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBindingListItemCreationItemMethodsSection(MethodCode methodCode, WidgetCodeGenerationInfoDatabindingExtension extension, string variableName, string dataSourceVariableName, string childIndexVariableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBindingListItemCreationSection(MethodCode methodCode, WidgetCodeGenerationInfoDatabindingExtension extension, string dataSourceVariableName, string childIndexVariableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBindingListItemCreationSectionForPopulate(MethodCode methodCode, WidgetCodeGenerationInfoDatabindingExtension extension, string dataSourceVariableName, string childIndexVariableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBindingListItemDeletionSection(MethodCode methodCode, WidgetCodeGenerationInfoDatabindingExtension extension, string childIndexVariableName, bool forDestroy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBindingListItemBeforeDeletionSection(MethodCode methodCode, WidgetCodeGenerationInfoDatabindingExtension extension, string childIndexVariableName, bool forDestroy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillRefreshDataSourceMethodAssignSection(BindingPathTargetDetails bindingPathTargetDetails, MethodCode methodCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillRefreshDataSourceMethod(BindingPathTargetDetails bindingPathTargetDetails, MethodCode methodCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateRefreshDataSourceMethod(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string[] CreateAssignmentLines(string sourceVariable, Type sourceType, string targetVariable, Type targetType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateEventMethods(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateWidgetPropertyChangedMethods(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateViewModelPropertyChangedMethods(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddPropertyChangedWithValueVariant(ClassCode classCode, string dataSourceVariableName, string typeVariant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateListChangedMethods(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BindingPathTargetDetails GetRootBindingPathTargetDetails()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BindingPathTargetDetails GetBindingPathTargetDetails(BindingPath bindingPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FindBindingPathTargetDetails()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DoExtraCodeGeneration(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AddExtrasToCreatorMethod(MethodCode methodCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override WidgetCodeGenerationInfoExtension CreateWidgetCodeGenerationInfoExtension(WidgetCodeGenerationInfo widgetCodeGenerationInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddWidgetPropertyChangedWithValueVariant(ClassCode classCode, string widgetName, string typeVariant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddPropertyChangedMethod(MethodCode methodCode, WidgetCodeGenerationInfoDatabindingExtension extension, string typeName, bool add)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UICodeGenerationDatabindingVariantExtension()
	{
		throw null;
	}
}
