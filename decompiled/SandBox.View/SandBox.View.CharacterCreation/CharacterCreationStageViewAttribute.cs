using System;
using System.Runtime.CompilerServices;

namespace SandBox.View.CharacterCreation;

public sealed class CharacterCreationStageViewAttribute : Attribute
{
	public readonly Type StageType;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CharacterCreationStageViewAttribute(Type stageType)
	{
		throw null;
	}
}
