namespace AIInfluence;

/// <summary>Slice 19: clear pending GM work when the game session ends (no save persistence yet).</summary>
public static class GameMasterLifecycle
{
	public static void OnGameEnd()
	{
		GameMasterPocQueue.ClearQueueForLifecycle();
		GameMasterObservationStore.ClearAll();
		GameMasterHostPolicy.ResetCountersForTests();
	}
}
