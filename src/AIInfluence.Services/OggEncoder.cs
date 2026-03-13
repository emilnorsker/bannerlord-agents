using System;
using System.IO;
using OggVorbisEncoder;

namespace AIInfluence.Services;

internal static class OggEncoder
{
	private const int WriteBufferSize = 512;

	private const int MaxDurationSeconds = 300;

	public static byte[] PcmToOgg(byte[] pcmBytes, int sampleRate = 24000, int channels = 1, float gain = 1f)
	{
		if (pcmBytes == null || pcmBytes.Length < 2)
		{
			return null;
		}
		if (sampleRate < 8000 || sampleRate > 192000 || channels < 1 || channels > 2)
		{
			return null;
		}
		return Pcm16ToOgg(pcmBytes, sampleRate, channels, gain);
	}

	public static byte[] WavToOgg(byte[] wavBytes)
	{
		if (wavBytes == null || wavBytes.Length < 44)
		{
			return null;
		}
		if (!ParseWav(wavBytes, out var sampleRate, out var channels, out var pcm))
		{
			return null;
		}
		if (sampleRate < 8000 || sampleRate > 192000 || channels < 1 || channels > 2)
		{
			return null;
		}
		return Pcm16ToOgg(pcm, sampleRate, channels);
	}

	private static bool ParseWav(byte[] wav, out int sampleRate, out int channels, out byte[] pcm)
	{
		sampleRate = 44100;
		channels = 1;
		pcm = null;
		if (wav.Length < 12)
		{
			return false;
		}
		if (BitConverter.ToInt32(wav, 0) != 1179011410)
		{
			return false;
		}
		if (BitConverter.ToInt32(wav, 8) != 1163280727)
		{
			return false;
		}
		int num3;
		int num;
		for (num = 12; num + 8 <= wav.Length; num += num3)
		{
			int num2 = BitConverter.ToInt32(wav, num);
			num3 = BitConverter.ToInt32(wav, num + 4);
			num += 8;
			if (num + num3 > wav.Length)
			{
				break;
			}
			switch (num2)
			{
			case 544501094:
				if (num3 >= 16)
				{
					int num4 = BitConverter.ToInt16(wav, num);
					if (num4 != 1)
					{
						return false;
					}
					channels = BitConverter.ToInt16(wav, num + 2);
					sampleRate = BitConverter.ToInt32(wav, num + 4);
				}
				continue;
			case 1635017060:
				break;
			default:
				continue;
			}
			int num5 = num3;
			if (num3 <= 0 || num3 > wav.Length - num)
			{
				num5 = wav.Length - num;
			}
			if (num5 > 0)
			{
				pcm = new byte[num5];
				Buffer.BlockCopy(wav, num, pcm, 0, num5);
			}
			break;
		}
		return pcm != null && pcm.Length != 0;
	}

	private static byte[] Pcm16ToOgg(byte[] pcmBytes, int sampleRate, int channels, float gain = 1f)
	{
		int num = 2;
		int num2 = pcmBytes.Length / num / channels;
		if (num2 <= 0)
		{
			return null;
		}
		int num3 = 300 * sampleRate;
		if (num2 > num3)
		{
			num2 = num3;
		}
		int num4 = num2;
		float[][] array = new float[channels][];
		for (int i = 0; i < channels; i++)
		{
			array[i] = new float[num4];
		}
		bool flag = Math.Abs(gain - 1f) > 0.001f;
		for (int j = 0; j < num4; j++)
		{
			for (int k = 0; k < channels; k++)
			{
				int num5 = (j * channels + k) * num;
				if (num5 + 1 >= pcmBytes.Length)
				{
					break;
				}
				short num6 = (short)(pcmBytes[num5] | (pcmBytes[num5 + 1] << 8));
				float num7 = (float)num6 / 32768f;
				if (flag)
				{
					num7 *= gain;
					if (num7 > 1f)
					{
						num7 = 1f;
					}
					else if (num7 < -1f)
					{
						num7 = -1f;
					}
				}
				array[k][j] = num7;
			}
		}
		return GenerateOgg(array, sampleRate, channels);
	}

	private static byte[] GenerateOgg(float[][] floatSamples, int sampleRate, int channelCount)
	{
		using MemoryStream memoryStream = new MemoryStream();
		VorbisInfo info = VorbisInfo.InitVariableBitRate(channelCount, sampleRate, 0.5f);
		OggStream oggStream = new OggStream(new Random().Next());
		Comments comments = new Comments();
		OggPacket packet = HeaderPacketBuilder.BuildInfoPacket(info);
		OggPacket packet2 = HeaderPacketBuilder.BuildCommentsPacket(comments);
		OggPacket packet3 = HeaderPacketBuilder.BuildBooksPacket(info);
		oggStream.PacketIn(packet);
		oggStream.PacketIn(packet2);
		oggStream.PacketIn(packet3);
		FlushPages(oggStream, memoryStream, force: true);
		ProcessingState processingState = ProcessingState.Create(info);
		for (int i = 0; i < floatSamples[0].Length; i += 512)
		{
			int length = Math.Min(512, floatSamples[0].Length - i);
			processingState.WriteData(floatSamples, length, i);
			OggPacket packet4;
			while (!oggStream.Finished && processingState.PacketOut(out packet4))
			{
				oggStream.PacketIn(packet4);
				FlushPages(oggStream, memoryStream, force: false);
			}
		}
		processingState.WriteEndOfStream();
		OggPacket packet5;
		while (!oggStream.Finished && processingState.PacketOut(out packet5))
		{
			oggStream.PacketIn(packet5);
			FlushPages(oggStream, memoryStream, force: false);
		}
		FlushPages(oggStream, memoryStream, force: true);
		return memoryStream.ToArray();
	}

	private static void FlushPages(OggStream oggStream, Stream output, bool force)
	{
		OggPage page;
		while (oggStream.PageOut(out page, force))
		{
			output.Write(page.Header, 0, page.Header.Length);
			output.Write(page.Body, 0, page.Body.Length);
		}
	}
}
