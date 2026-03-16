using System.Runtime.CompilerServices;
using TaleWorlds.SaveSystem.Definition;

namespace TaleWorlds.SaveSystem.Save;

internal abstract class MemberSaveData : VariableSaveData
{
	public ObjectSaveData ObjectSaveData
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
	protected MemberSaveData(ObjectSaveData objectSaveData)
	{
		throw null;
	}

	public abstract void Initialize(TypeDefinitionBase typeDefinition);

	public abstract void InitializeAsCustomStruct(int structId);
}
