using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.Engine;

public class PerformanceAnalyzer
{
	private class PerformanceObject
	{
		private string name;

		private int frameCount;

		private float totalMainFps;

		private float totalRendererFps;

		private float totalFps;

		private float AverageMainFps
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private float AverageRendererFps
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private float AverageFps
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddFps(float fps, float main, float renderer)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Write(XmlNode node, XmlDocument document)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PerformanceObject(string objectName)
		{
			throw null;
		}
	}

	private List<PerformanceObject> objects;

	private PerformanceObject currentObject;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PerformanceAnalyzer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Start(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void End()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizeAndWrite(string filePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}
}
