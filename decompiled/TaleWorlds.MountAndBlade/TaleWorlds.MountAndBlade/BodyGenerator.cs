using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class BodyGenerator
{
	public const string FaceGenTeethAnimationName = "facegen_teeth";

	public BodyProperties CurrentBodyProperties;

	public BodyProperties BodyPropertiesMin;

	public BodyProperties BodyPropertiesMax;

	public int Race;

	public bool IsFemale;

	public BasicCharacterObject Character
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
	public BodyGenerator(BasicCharacterObject troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FaceGenerationParams InitBodyGenerator(bool isDressed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshFace(FaceGenerationParams faceGenerationParams, bool hasEquipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveCurrentCharacter()
	{
		throw null;
	}
}
