using System;

namespace AIInfluence;

public static class GetQuestsRelatedToSettlement_NullGuard
{
	public static Exception Finalizer(Exception __exception)
	{
		if (__exception is NullReferenceException)
		{
			return null;
		}
		return __exception;
	}
}
