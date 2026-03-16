using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.TwoDimension.Standalone;

public class Shader
{
	private GraphicsContext _graphicsContext;

	private int _program;

	private int _currentTextureUnit;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Shader(GraphicsContext graphicsContext, int program)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Shader CreateShader(GraphicsContext graphicsContext, string vertexShaderCode, string fragmentShaderCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CompileShaders(string vertexShaderCode, string fragmentShaderCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTexture(string name, OpenGLTexture texture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetColor(string name, Color color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Use()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopUsing()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMatrix(string name, Matrix4x4 matrix)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBoolean(string name, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFloat(string name, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVector2(string name, Vector2 value)
	{
		throw null;
	}
}
