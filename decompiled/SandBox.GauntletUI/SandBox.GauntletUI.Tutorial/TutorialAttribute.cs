using System;
using System.Runtime.CompilerServices;

namespace SandBox.GauntletUI.Tutorial;

public class TutorialAttribute : Attribute
{
	public readonly string TutorialIdentifier;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TutorialAttribute(string tutorialIdentifier)
	{
		throw null;
	}
}
