using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class FaceGenHistory
{
	public readonly List<UndoRedoKey> UndoCommands;

	public readonly List<UndoRedoKey> RedoCommands;

	public readonly Dictionary<string, float> InitialValues;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FaceGenHistory(List<UndoRedoKey> undoCommands, List<UndoRedoKey> redoCommands, Dictionary<string, float> initialValues)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearHistory()
	{
		throw null;
	}
}
