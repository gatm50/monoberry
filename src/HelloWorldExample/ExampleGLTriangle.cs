using System;
using System.Text;
using BlackberryPlatformServices;
using BlackberryPlatformServices.Screen;
using BlackberryPlatformServices.Screen.Types;
using OpenTKBlackberry.Graphics.ES20;
using OpenTKBlackberry.Platform.Egl;

namespace HelloWorldExample
{
	class ExampleGLTriangle
	{
		float[] vertices;
		int program;
		int viewportWidth, viewportHeight;

		public void Run()
		{
			BBUtil _util;
			using (var nav = new Navigator())
			using (var ctx = new Context(ContextType.SCREEN_APPLICATION_CONTEXT))
			using (var win = new Window(ctx))
			{
				_util = new BBUtil(ctx);

				Egl.QuerySurface(_util.Display, _util.Surface, Egl.WIDTH, out viewportWidth);
				Egl.QuerySurface(_util.Display, _util.Surface, Egl.HEIGHT, out viewportHeight);

				Console.WriteLine("viewportWidth: " + viewportWidth);
				Console.WriteLine("viewportHeight: " + viewportHeight);

				this.OnLoad(_util);

				nav.OnExit += () =>
				{
					Console.WriteLine("I am asked to shutdown!?!");
					PlatformServices.Shutdown(0);
				};

				PlatformServices.Run(null);
			}
		}

		void OnLoad(BBUtil util)
		{

			// Vertex and fragment shaders
			string vertexShaderSrc = "attribute vec4 vPosition;    \n" +
							  "void main()                  \n" +
							  "{                            \n" +
							  "   gl_Position = vPosition;  \n" +
							  "}                            \n";

			string fragmentShaderSrc = "precision mediump float;\n" +
								   "void main()                                  \n" +
								   "{                                            \n" +
								   "  gl_FragColor = vec4 (1.0, 0.0, 0.0, 1.0);  \n" +
								   "}                                            \n";

			int vertexShader = LoadShader(ShaderType.VertexShader, vertexShaderSrc);
			int fragmentShader = LoadShader(ShaderType.FragmentShader, fragmentShaderSrc);
			program = GL.CreateProgram();
			if (program == 0)
				throw new InvalidOperationException("Unable to create program");

			GL.AttachShader(program, vertexShader);
			GL.AttachShader(program, fragmentShader);

			GL.BindAttribLocation(program, 0, "vPosition");
			GL.LinkProgram(program);

			int linked = 0;
			GL.GetProgram(program, ProgramParameter.LinkStatus, out linked);
			if (linked == 0)
			{
				// link failed
				int length = 0;
				GL.GetProgram(program, ProgramParameter.InfoLogLength, out length);
				if (length > 0)
				{
					var log = new StringBuilder(length);
					GL.GetProgramInfoLog(program, length, out length, log);
					Console.WriteLine("Couldn't link program: " + log.ToString());
				}

				GL.DeleteProgram(program);
				throw new InvalidOperationException("Unable to link program");
			}

			RenderTriangle(util);
		}

		void RenderTriangle(BBUtil util)
		{
			vertices = new float[] {
					0.0f, 0.5f, 0.0f,
					-0.5f, -0.5f, 0.0f,
					0.5f, -0.5f, 0.0f
				};

			GL.ClearColor(0.7f, 0.7f, 0.7f, 1);
			GL.Clear(ClearBufferMask.ColorBufferBit);

			GL.Viewport(0, 0, viewportWidth, viewportHeight);
			GL.UseProgram(program);

			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, vertices);
			GL.EnableVertexAttribArray(0);

			GL.DrawArrays(BeginMode.Triangles, 0, 3);

			util.Swap();
		}

		int LoadShader(ShaderType type, string source)
		{
			int shader = GL.CreateShader(type);
			if (shader == 0)
				throw new InvalidOperationException("Unable to create shader");

			int length = 0;
			GL.ShaderSource(shader, 1, new string[] { source }, (int[])null);
			GL.CompileShader(shader);

			int compiled = 0;
			GL.GetShader(shader, ShaderParameter.CompileStatus, out compiled);
			if (compiled == 0)
			{
				length = 0;
				GL.GetShader(shader, ShaderParameter.InfoLogLength, out length);
				if (length > 0)
				{
					var log = new StringBuilder(length);
					GL.GetShaderInfoLog(shader, length, out length, log);
					Console.WriteLine("Couldn't compile shader: " + log.ToString());
				}

				GL.DeleteShader(shader);
				throw new InvalidOperationException("Unable to compile shader of type : " + type.ToString());
			}

			return shader;
		}
	}
}
