using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension.Standalone.Native.OpenGL;

internal static class Opengl32ARB
{
	public delegate void BlendFuncSeparateDelegate(BlendingSourceFactor srcRGB, BlendingDestinationFactor dstRGB, BlendingSourceFactor srcAlpha, BlendingDestinationFactor dstAlpha);

	public delegate void ActiveTextureDelegate(TextureUnit textureUnit);

	public delegate void BindVertexArrayDelegate(uint buffer);

	public delegate void GenVertexArraysDelegate(int size, uint[] buffers);

	public delegate void VertexAttribPointerDelegate(uint index, int size, DataType type, byte normalized, int stride, IntPtr pointer);

	public delegate void EnableVertexAttribArrayDelegate(uint index);

	public delegate void DisableVertexAttribArrayDelegate(int index);

	public delegate void GenBuffersDelegate(int size, uint[] buffers);

	public delegate void BindBufferDelegate(BufferBindingTarget target, uint buffer);

	public delegate void BufferDataDelegate(BufferBindingTarget target, int size, IntPtr data, int usage);

	public delegate void BufferSubDataDelegate(BufferBindingTarget target, int offset, int size, IntPtr data);

	public delegate void DetachShaderDelegate(int program, int shader);

	public delegate int DeleteShaderDelegate(int shader);

	private delegate int GetUniformLocationDelegate(int program, byte[] parameter);

	public delegate void GetProgramInfoLogDelegate(int shader, int maxLength, out int length, byte[] output);

	public delegate void GetShaderInfoLogDelegate(int shader, int maxLength, out int length, byte[] output);

	public delegate void GetProgramivDelegate(int program, int paremeterName, out int returnValue);

	public delegate void GetShaderivDelegate(int shader, int paremeterName, out int returnValue);

	private delegate void UniformMatrix4fvDelegate(int location, int count, byte isTranspose, float[] matrix);

	public delegate void Uniform4fDelegate(int location, float f1, float f2, float f3, float f4);

	public delegate void Uniform1iDelegate(int location, int i);

	public delegate void Uniform1fDelegate(int location, float f);

	public delegate void Uniform2fDelegate(int location, float f1, float f2);

	public delegate void UseProgramDelegate(int program);

	public delegate void DeleteProgramDelegate(int program);

	public delegate void LinkProgramDelegate(int program);

	public delegate void AttachShaderDelegate(int program, int shader);

	private delegate void ShaderSourceDelegate(int shader, int count, IntPtr[] shaderSource, int[] length);

	public delegate int CompileShaderDelegate(int shader);

	public delegate int CreateProgramObjectDelegate();

	public delegate int CreateShaderObjectDelegate(ShaderType shaderType);

	public delegate IntPtr wglCreateContextAttribsDelegate(IntPtr hDC, IntPtr hShareContext, int[] attribList);

	private static bool _extensionsLoaded;

	public static BlendFuncSeparateDelegate BlendFuncSeparate;

	public static ActiveTextureDelegate ActiveTexture;

	public static BindVertexArrayDelegate BindVertexArray;

	public static GenVertexArraysDelegate GenVertexArrays;

	public static VertexAttribPointerDelegate VertexAttribPointer;

	public static EnableVertexAttribArrayDelegate EnableVertexAttribArray;

	public static DisableVertexAttribArrayDelegate DisableVertexAttribArray;

	public static GenBuffersDelegate GenBuffers;

	public static BindBufferDelegate BindBuffer;

	public static BufferDataDelegate BufferData;

	public static BufferSubDataDelegate BufferSubData;

	public static DetachShaderDelegate DetachShader;

	public static DeleteShaderDelegate DeleteShader;

	private static GetUniformLocationDelegate GetUniformLocationInternal;

	public static GetProgramInfoLogDelegate GetProgramInfoLog;

	public static GetShaderInfoLogDelegate GetShaderInfoLog;

	public static GetProgramivDelegate GetProgramiv;

	public static GetShaderivDelegate GetShaderiv;

	private static UniformMatrix4fvDelegate UniformMatrix4fvInternal;

	public static Uniform4fDelegate Uniform4f;

	public static Uniform1iDelegate Uniform1i;

	public static Uniform1fDelegate Uniform1f;

	public static Uniform2fDelegate Uniform2f;

	public static UseProgramDelegate UseProgram;

	public static DeleteProgramDelegate DeleteProgram;

	public static LinkProgramDelegate LinkProgram;

	public static AttachShaderDelegate AttachShader;

	private static ShaderSourceDelegate ShaderSourceInternal;

	public static CompileShaderDelegate CompileShader;

	public static CreateProgramObjectDelegate CreateProgramObject;

	public static CreateShaderObjectDelegate CreateShaderObject;

	public static wglCreateContextAttribsDelegate wglCreateContextAttribs;

	public const int GL_COMPILE_STATUS = 35713;

	public const int GL_LINK_STATUS = 35714;

	public const int GL_INFO_LOG_LENGTH = 35716;

	public const int StaticDraw = 35044;

	public const int DynamicDraw = 35048;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LoadContextExtension(IntPtr hdc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LoadExtensions(IntPtr hdc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static T LoadFunction<T>(string name) where T : class
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ShaderSource(int shader, string shaderSource)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetUniformLocation(int program, string parameter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UniformMatrix4fv(int location, int count, bool isTranspose, Matrix4x4 matrix)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Opengl32ARB()
	{
		throw null;
	}
}
