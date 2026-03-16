using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade;

public class MPPerkSelectionManager
{
	public struct MPPerkSelection
	{
		public readonly int Index;

		public readonly int ListIndex;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MPPerkSelection(int index, int listIndex)
		{
			throw null;
		}
	}

	private static MPPerkSelectionManager _instance;

	public Action OnAfterResetPendingChanges;

	private Dictionary<MultiplayerClassDivisions.MPHeroClass, List<MPPerkSelection>> _selections;

	private Dictionary<MultiplayerClassDivisions.MPHeroClass, List<MPPerkSelection>> _pendingChanges;

	private PlatformFilePath _xmlPath;

	private PlayerId _playerIdOfSelectionsOwner;

	public static MPPerkSelectionManager Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FreeInstance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeForUser(string username, PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetPendingChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TryToApplyAndSavePendingChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<MPPerkSelection> GetSelectionsForHeroClass(MultiplayerClassDivisions.MPHeroClass currentHeroClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSelectionsForHeroClassTemporarily(MultiplayerClassDivisions.MPHeroClass currentHeroClass, List<MPPerkSelection> perkChoices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<MultiplayerClassDivisions.MPHeroClass, List<MPPerkSelection>> LoadSelectionsForUserFromXML()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SaveAsXML(List<KeyValuePair<MultiplayerClassDivisions.MPHeroClass, List<MPPerkSelection>>> selections)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MPPerkSelectionManager()
	{
		throw null;
	}
}
