using System;
using TaleWorlds.SaveSystem;
using TaleWorlds.SaveSystem.Resolvers;

namespace AIInfluence;

public class SaveableAIInfluenceTypeDefiner : SaveableTypeDefiner
{
	public SaveableAIInfluenceTypeDefiner()
		: base(4190117)
	{
	}

	protected override void DefineClassTypes()
	{
		base.AddClassDefinition(typeof(AIGeneratedQuest), 1, (IObjectResolver)null);
	}

	protected override void DefineStructTypes()
	{
	}

	protected override void DefineEnumTypes()
	{
	}

	protected override void DefineInterfaceTypes()
	{
	}

	protected override void DefineRootClassTypes()
	{
	}

	protected override void DefineGenericClassDefinitions()
	{
	}

	protected override void DefineGenericStructDefinitions()
	{
	}

	protected override void DefineContainerDefinitions()
	{
	}
}
