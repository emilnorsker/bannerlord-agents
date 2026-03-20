namespace AIInfluence;

/// <summary>Slice 13: correlation carried through queue drain for gm_audit.log rows; slices 21/28: observation bucket + story intent.</summary>
public readonly struct GameMasterGmJobAuditInfo
{
	public string CompletionPath { get; }

	public string CorrelationId { get; }

	public string PlanJson { get; }

	/// <summary>Key for <see cref="GameMasterObservationStore"/> (e.g. path|correlation).</summary>
	public string ObservationBucketKey { get; }

	public string StoryIntent { get; }

	public GameMasterGmJobAuditInfo(string completionPath, string correlationId, string planJson, string observationBucketKey = null, string storyIntent = null)
	{
		CompletionPath = completionPath;
		CorrelationId = correlationId;
		PlanJson = planJson;
		ObservationBucketKey = observationBucketKey;
		StoryIntent = storyIntent;
	}
}
