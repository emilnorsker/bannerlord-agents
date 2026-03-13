using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

public class LeadershipChange
{
	private CampaignTime _changeDate;

	private string _changeDateString;

	[JsonProperty("PreviousLeaderId")]
	public string PreviousLeaderId { get; set; }

	[JsonProperty("PreviousLeaderName")]
	public string PreviousLeaderName { get; set; }

	[JsonProperty("PreviousLeaderClanId")]
	public string PreviousLeaderClanId { get; set; }

	[JsonProperty("PreviousLeaderClanName")]
	public string PreviousLeaderClanName { get; set; }

	[JsonProperty("NewLeaderId")]
	public string NewLeaderId { get; set; }

	[JsonProperty("NewLeaderName")]
	public string NewLeaderName { get; set; }

	[JsonProperty("NewLeaderClanId")]
	public string NewLeaderClanId { get; set; }

	[JsonProperty("NewLeaderClanName")]
	public string NewLeaderClanName { get; set; }

	[JsonIgnore]
	public CampaignTime ChangeDate
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			if (_changeDate == CampaignTime.Never && !string.IsNullOrEmpty(_changeDateString))
			{
				_changeDate = CampaignTime.Now;
			}
			return (_changeDate == CampaignTime.Never) ? CampaignTime.Now : _changeDate;
		}
		set
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			_changeDate = value;
			UpdateChangeDateString();
		}
	}

	[JsonProperty("ChangeDate")]
	public string ChangeDateString
	{
		get
		{
			return _changeDateString;
		}
		set
		{
			_changeDateString = value;
		}
	}

	[JsonProperty("ChangeReason")]
	public string ChangeReason { get; set; }

	[JsonProperty("KillerId")]
	public string KillerId { get; set; }

	[JsonProperty("KillerName")]
	public string KillerName { get; set; }

	public void UpdateChangeDateString()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		if (_changeDate != CampaignTime.Never)
		{
			_ = _changeDate;
			if (true)
			{
				_changeDateString = $"{((CampaignTime)(ref _changeDate)).GetYear}.{(object)(Seasons)(((CampaignTime)(ref _changeDate)).GetSeasonOfYear + 1)}.{((CampaignTime)(ref _changeDate)).GetDayOfSeason + 1}";
				return;
			}
		}
		_changeDateString = null;
	}
}
