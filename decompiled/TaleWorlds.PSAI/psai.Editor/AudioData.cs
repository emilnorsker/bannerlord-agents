using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using psai.net;

namespace psai.Editor;

[Serializable]
public class AudioData : ICloneable
{
	private string _filePathRelativeToProjectDir;

	public int _prebeatLengthInSamplesEnteredManually;

	public int _postbeatLengthInSamplesEnteredManually;

	[XmlElement("Path")]
	public string FilePathRelativeToProjectDir
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[XmlIgnore]
	public string ModuleID
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[XmlIgnore]
	public string FilePathRelativeToProjectDirForCurrentSystem
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Bpm
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float PreBeats
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float PostBeats
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public bool CalculatePostAndPrebeatLengthBasedOnBeats
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public int PreBeatLengthInSamples
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public int PostBeatLengthInSamples
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public int TotalLengthInSamples
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public int SampleRate
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[XmlIgnore]
	public int BitsPerSample
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[XmlIgnore]
	public int ChannelCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[XmlIgnore]
	public long ByteIndexOfWaveformDataWithinAudioFile
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[XmlIgnore]
	public int LengthOfWaveformDataInBytes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AudioData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public psai.net.AudioData CreatePsaiDotNetVersion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMillisecondsFromSampleCount(int sampleCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSampleCountFromMilliseconds(int durationMs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetLengthInSamplesBasedOnBeats(float bpm, float beats)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPostbeatLengthInSamplesBasedOnBeats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPrebeatLengthInSamplesBasedOnBeats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CalculateTotalLengthInSamples(int lengthOfWaveformDataInBytes, int bitsPerSample, int channelCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoUpdateMembersBasedOnWaveHeader(string fullPathToAudioFile, out string errorMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SeekChunkInWaveHeader(ref BinaryReader reader, string chunk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PsaiResult ReadWaveHeader(Stream stream, out int outChannelCount, out int outSampleRate, out int outBitsPerSample, out int outLengthOfWaveformDatablockInBytes, out long outBytePositionOfWaveformData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] LoadWaveformDataToByteArray(string fullFilePath, long byteIndexOfWaveformDataWithinAudioFile, int lengthOfWaveformDataInBytes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Clone()
	{
		throw null;
	}
}
