using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackberryPlatformServices.Screen;
using BlackberryPlatformServices;
using OpenTKBlackberry.Platform.Egl;
using OpenTKBlackberry.Graphics.ES20;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace HelloWorldExample
{
    public class FallingBlocks
    {
        BBUtil _util;
        float[] vertices = new float[9];
        int _program;
        Context _ctx;

        public void Run()
        {
            _ctx = new Context(BlackberryPlatformServices.Screen.Types.ContextType.SCREEN_APPLICATION_CONTEXT);
            PlatformServices.Initialize();
            using (var win = new Window(_ctx, WindowType.SCREEN_APPLICATION_WINDOW))
            {
                _util = new BBUtil(_ctx);
                this.Initialize();
                string groupName = "TheTeam";
                win.CreateWindowGroup(groupName);
                win.CreateBuffer();
                while (true)
                {
                    this.Draw();
                }
            }
        }

        private int LoadShader(ShaderType type, string[] shaderSrc)
        {
            int shader;
            int compiled;
            shader = GL.CreateShader(type);

            if (shader == 0)
                return 0;

            int length = 0;
            GL.ShaderSource(shader, 1, shaderSrc, ref length);
            GL.CompileShader(shader);

            GL.GetShader(shader, ShaderParameter.CompileStatus, out compiled);

            return shader;
        }

        private void Initialize()
        {
            // Create shaders
            string[] vSource = new string[]{
                    "attribute vec4 vPosition;    \n",
                    "void main()                  \n" ,
                    "{                            \n" ,
                    "   gl_Position = vPosition;  \n" ,
                    "}                            \n"
            };

            string[] fSource = new string[]{
                "precision mediump float;\n" +
                "void main()                                  \n" +
                "{                                            \n" +
                "  gl_FragColor = vec4 ( 1.0, 0.0, 0.0, 1.0 );\n" +
                "}"
            };

            int vertexShader;
            int fragmentShader;
            int linked;

            //Load vertex/fragment shaders
            vertexShader = this.LoadShader(ShaderType.VertexShader, vSource);
            fragmentShader = this.LoadShader(ShaderType.FragmentShader, fSource);

            _program = GL.CreateProgram();
            GL.AttachShader(_program, vertexShader);
            GL.AttachShader(_program, fragmentShader);
            GL.BindAttribLocation(_program, 0, "vPosition");

            GL.LinkProgram(_program);
            GL.GetProgram(_program, ProgramParameter.LinkStatus, out linked);
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }

        private void Draw()
        {
            vertices[0] = 0.0f;
            vertices[1] = 0.5f;
            vertices[2] = 0.0f;
            vertices[3] = -0.5f;
            vertices[4] = -0.5f;
            vertices[5] = 0.0f;
            vertices[6] = 0.5f;
            vertices[7] = -0.5f;
            vertices[8] = 0.0f;

            ////Query width and height of the window surface created by utility code
            int surface_width, surface_height;

            Egl.QuerySurface(_util.Display, _util.Surface, Egl.WIDTH, out surface_width);
            Egl.QuerySurface(_util.Display, _util.Surface, Egl.HEIGHT, out surface_height);

            GL.Viewport(0, 0, surface_width, surface_height);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.UseProgram(_program);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, (IntPtr)(vertices.Length * sizeof(float)));
            GL.EnableVertexAttribArray(0);

            GL.DrawArrays(BeginMode.Triangles, 0, 3);
            _util.Swap();
        }
    }
}
