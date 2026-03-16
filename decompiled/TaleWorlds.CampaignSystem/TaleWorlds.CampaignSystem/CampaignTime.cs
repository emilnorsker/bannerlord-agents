using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem;

public struct CampaignTime : IComparable<CampaignTime>
{
	public enum Seasons
	{
		Spring,
		Summer,
		Autumn,
		Winter
	}

	public static int SunRise;

	public static int SunSet;

	public static int MillisecondInSecond;

	public static int SecondsInMinute;

	public static int MinutesInHour;

	public static int HoursInDay;

	public static int DaysInWeek;

	public static int WeeksInSeason;

	public static int SeasonsInYear;

	internal static long TimeTicksPerMillisecond;

	internal static long TimeTicksPerSecond;

	internal static long TimeTicksPerMinute;

	internal static long TimeTicksPerHour;

	internal static long TimeTicksPerDay;

	internal static long TimeTicksPerWeek;

	internal static long TimeTicksPerSeason;

	internal static long TimeTicksPerYear;

	[SaveableField(2)]
	private readonly long _numTicks;

	public static int DaysInSeason
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static int DaysInYear
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal long NumTicks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static long CurrentTicks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static CampaignTime DeltaTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static long DeltaTimeInTicks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static CampaignTime Now
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static CampaignTime Never
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsFuture
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsPast
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsDayTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CurrentHourInDay
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsNightTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float ElapsedMillisecondsUntilNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float ElapsedSecondsUntilNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float ElapsedHoursUntilNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float ElapsedDaysUntilNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float ElapsedWeeksUntilNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float ElapsedSeasonsUntilNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float ElapsedYearsUntilNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RemainingMillisecondsFromNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RemainingSecondsFromNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RemainingHoursFromNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RemainingDaysFromNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RemainingWeeksFromNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RemainingSeasonsFromNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RemainingYearsFromNow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public double ToMilliseconds
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public double ToSeconds
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public double ToMinutes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public double ToHours
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public double ToDays
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public double ToWeeks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public double ToSeasons
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public double ToYears
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int GetHourOfDay
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int GetDayOfWeek
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int GetDayOfSeason
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int GetDayOfYear
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int GetWeekOfSeason
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Seasons GetSeasonOfYear
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int GetYear
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static CampaignTime Zero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AutoGeneratedStaticCollectObjectsCampaignTime(object o, List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_numTicks(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal CampaignTime(long numTicks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Equals(CampaignTime other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CompareTo(CampaignTime other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator <(CampaignTime x, CampaignTime y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator >(CampaignTime x, CampaignTime y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(CampaignTime x, CampaignTime y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(CampaignTime x, CampaignTime y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator <=(CampaignTime x, CampaignTime y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator >=(CampaignTime x, CampaignTime y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime Milliseconds(long valueInMilliseconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime MillisecondsFromNow(long valueInMilliseconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime Seconds(long valueInSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime SecondsFromNow(long valueInSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime Minutes(long valueInMinutes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime MinutesFromNow(long valueInMinutes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime Hours(float valueInHours)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime HoursFromNow(float valueInHours)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime Days(float valueInDays)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime DaysFromNow(float valueInDays)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime Weeks(float valueInWeeks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime WeeksFromNow(float valueInWeeks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime Years(float valueInYears)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime YearsFromNow(float valueInYears)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime operator +(CampaignTime g1, CampaignTime g2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime operator -(CampaignTime g1, CampaignTime g2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool StringSameAs(CampaignTime otherTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}
}
