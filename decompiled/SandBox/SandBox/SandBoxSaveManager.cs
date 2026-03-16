using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;

namespace SandBox;

public class SandBoxSaveManager : ISaveManager
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAutoSaveInterval()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAutoSaveDisabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSaveOver(bool isSuccessful, string newSaveGameName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandBoxSaveManager()
	{
		throw null;
	}
}
