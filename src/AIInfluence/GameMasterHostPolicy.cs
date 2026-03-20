using System;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

/// <summary>Slice 22: host allowlist before enqueue (prefix, length, rate, queue depth).</summary>
public static class GameMasterHostPolicy
{
	private static DateTime _rateWindowStartUtc = DateTime.MinValue;

	private static int _plansInRateWindow;

	private static int _lastCampaignDayInt = int.MinValue;

	private static int _plansOnCampaignDay;

	public static bool TryAcceptPlan(string serializedLine, out string rejectionReason, int extraPendingSlots = 0)
	{
		rejectionReason = null;
		ModSettings s = GlobalSettings<ModSettings>.Instance;
		if (s == null || !s.GameMasterHostPolicyEnabled)
		{
			return true;
		}
		if (string.IsNullOrWhiteSpace(serializedLine))
		{
			rejectionReason = "[GM_POLICY] empty line";
			return false;
		}
		string t = serializedLine.TrimStart();
		if (!t.StartsWith("gm.", StringComparison.OrdinalIgnoreCase))
		{
			rejectionReason = "[GM_POLICY] line must start with gm.";
			return false;
		}
		int maxLen = (s.GameMasterMaxSerializedLineLength > 0) ? s.GameMasterMaxSerializedLineLength : 1024;
		if (serializedLine.Length > maxLen)
		{
			rejectionReason = "[GM_POLICY] line exceeds max length (" + maxLen + ")";
			return false;
		}
		int maxDepth = s.GameMasterMaxGmQueueDepth > 0 ? s.GameMasterMaxGmQueueDepth : 50;
		int need = 1 + Math.Max(0, extraPendingSlots);
		if (GameMasterPocQueue.Queue.Count + need > maxDepth)
		{
			rejectionReason = "[GM_POLICY] GM queue would exceed max depth (" + maxDepth + ")";
			return false;
		}
		int maxPerDay = s.GameMasterMaxPlansPerCampaignDay;
		if (maxPerDay > 0 && Campaign.Current != null)
		{
			int day = (int)(CampaignTime.Now).ToDays;
			if (day != _lastCampaignDayInt)
			{
				_lastCampaignDayInt = day;
				_plansOnCampaignDay = 0;
			}
			if (_plansOnCampaignDay >= maxPerDay)
			{
				rejectionReason = "[GM_POLICY] max GM plans per campaign day (" + maxPerDay + ")";
				return false;
			}
		}
		if (s.GameMasterRateLimitSeconds > 0 && s.GameMasterMaxPlansPerRateWindow > 0)
		{
			DateTime now = DateTime.UtcNow;
			if (_rateWindowStartUtc == DateTime.MinValue || (now - _rateWindowStartUtc).TotalSeconds > (double)s.GameMasterRateLimitSeconds)
			{
				_rateWindowStartUtc = now;
				_plansInRateWindow = 0;
			}
			if (_plansInRateWindow >= s.GameMasterMaxPlansPerRateWindow)
			{
				rejectionReason = "[GM_POLICY] rate limit (max " + s.GameMasterMaxPlansPerRateWindow + " per " + s.GameMasterRateLimitSeconds + "s)";
				return false;
			}
		}
		return true;
	}

	public static void RegisterPlanAccepted()
	{
		ModSettings s = GlobalSettings<ModSettings>.Instance;
		if (s == null || !s.GameMasterHostPolicyEnabled)
		{
			return;
		}
		int maxPerDay = s.GameMasterMaxPlansPerCampaignDay;
		if (maxPerDay > 0 && Campaign.Current != null)
		{
			int day = (int)(CampaignTime.Now).ToDays;
			if (day != _lastCampaignDayInt)
			{
				_lastCampaignDayInt = day;
				_plansOnCampaignDay = 0;
			}
			_plansOnCampaignDay++;
		}
		if (s.GameMasterRateLimitSeconds > 0 && s.GameMasterMaxPlansPerRateWindow > 0)
		{
			DateTime now = DateTime.UtcNow;
			if (_rateWindowStartUtc == DateTime.MinValue || (now - _rateWindowStartUtc).TotalSeconds > (double)s.GameMasterRateLimitSeconds)
			{
				_rateWindowStartUtc = now;
				_plansInRateWindow = 0;
			}
			_plansInRateWindow++;
		}
	}

	public static void ResetCountersForTests()
	{
		_rateWindowStartUtc = DateTime.MinValue;
		_plansInRateWindow = 0;
		_lastCampaignDayInt = int.MinValue;
		_plansOnCampaignDay = 0;
	}
}
