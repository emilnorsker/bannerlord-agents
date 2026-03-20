namespace AIInfluence;

/// <summary>Slice 13: correlation carried through queue drain for gm_audit.log rows.</summary>
public readonly struct GameMasterGmJobAuditInfo
{
	public string CompletionPath { get; }

	public string CorrelationId { get; }

	public string PlanJson { get; }

	public GameMasterGmJobAuditInfo(string completionPath, string correlationId, string planJson)
	{
		CompletionPath = completionPath;
		CorrelationId = correlationId;
		PlanJson = planJson;
	}
}
