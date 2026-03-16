using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.TwoDimension.Standalone;

public class GraphicsContext
{
	public const int MaxFrameRate = 60;

	public readonly int MaxTimeToRenderOneFrame;

	private IntPtr _handleDeviceContext;

	private IntPtr _handleRenderContext;

	private int[] _scissorParameters;

	private Matrix4x4 _projectionMatrix;

	private Matrix4x4 _modelMatrix;

	private Matrix4x4 _viewMatrix;

	private Matrix4x4 _modelViewMatrix;

	private Stopwatch _stopwatch;

	private Dictionary<string, Shader> _loadedShaders;

	private VertexArrayObject _simpleVAO;

	private VertexArrayObject _textureVAO;

	private int _screenWidth;

	private int _screenHeight;

	private int _failedRenderFrames;

	private bool _anyInvalidMatricesThisFrame;

	private ResourceDepot _resourceDepot;

	private bool _blendingMode;

	private bool _vertexArrayClientState;

	private bool _textureCoordArrayClientState;

	internal WindowsForm Control
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

	public static GraphicsContext Active
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	internal Dictionary<string, OpenGLTexture> LoadedTextures
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public Matrix4x4 ProjectionMatrix
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

	public Matrix4x4 ViewMatrix
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

	public Matrix4x4 ModelMatrix
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

	public bool IsActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GraphicsContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateContext(ResourceDepot resourceDepot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginFrame(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwapBuffers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DestroyContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScissor(ScissorTestInfo scissorTestInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetScissor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Shader GetOrLoadShader(string shaderName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrawImage(SimpleMaterial material, in ImageDrawObject drawObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrawText(TextMaterial material, in TextDrawObject drawObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrawPolygon(PrimitivePolygonMaterial material, in ImageDrawObject drawObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Shader PrepareRender(Material material, in Rectangle2D rect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsValidMatrixFrame(in MatrixFrame matrixFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DrawImageAux(Shader shader, SimpleMaterial material, in ImageDrawObject drawObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DrawTextAux(Shader shader, TextMaterial textMaterial, in TextDrawObject drawObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DrawPolygonAux(Shader shader, PrimitivePolygonMaterial material, in ImageDrawObject drawObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DrawElements(uint[] indices, bool blending)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Resize(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadTextureUsing(OpenGLTexture texture, ResourceDepot resourceDepot, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OpenGLTexture LoadTexture(ResourceDepot resourceDepot, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OpenGLTexture GetTexture(string textureName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBlending(bool enable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVertexArrayClientState(bool enable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTextureCoordArrayClientState(bool enable)
	{
		throw null;
	}
}
