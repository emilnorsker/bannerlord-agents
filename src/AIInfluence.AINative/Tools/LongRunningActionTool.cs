namespace AIInfluence.AINative.Tools;

public abstract class LongRunningActionTool : IAINativeTool
{
	public abstract string Name { get; }

	public bool IsLongRunning => true;

	public void Execute(AINativeToolContext context, AINativeQueue queue)
	{
		queue.Enqueue(new AINativeEvent(AINativeEventType.ActionStarted, context.CorrelationId, context.NpcId, Name, string.Empty));
	}
}

