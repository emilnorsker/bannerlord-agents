namespace AIInfluence.AINative;

public interface IAINativeTool
{
	string Name { get; }

	bool IsLongRunning { get; }

	void Execute(AINativeToolContext context, AINativeQueue queue);
}

