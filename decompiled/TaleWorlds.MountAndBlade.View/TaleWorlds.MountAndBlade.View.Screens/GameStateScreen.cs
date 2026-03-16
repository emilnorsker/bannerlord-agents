using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.View.Screens;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class GameStateScreen : Attribute
{
	public Type GameStateType
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
	public GameStateScreen(Type gameStateType)
	{
		throw null;
	}
}
