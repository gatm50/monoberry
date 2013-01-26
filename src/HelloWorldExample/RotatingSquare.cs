using System;
using BlackberryPlatformServices;
using BlackberryPlatformServices.Screen;
using OpenTKBlackberry.Graphics.ES20;
using OpenTKBlackberry.Platform.Egl;
using BlackberryPlatformServices.Screen.Types;

namespace HelloWorldExample
{
    public class RotatingSquare
    {
        BBUtil _util;
        float[] vertices = new float[8];
        float[] colors = new float[16];
        float[] matrix = new float[16] { 
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1 
        };
        int _positionLoc;
        int _vertexID;
        int _colorLoc;
        int _colorID;
        int _transformLoc;
        int _program;

        public RotatingSquare()
        {
        }

        public void Run()
        {
            using (var nav = new Navigator())
            using (var ctx = new Context(ContextType.SCREEN_APPLICATION_CONTEXT))
            using (var win = new Window(ctx))
            {
                _util = new BBUtil(ctx);

                this.Initialize();
                nav.RotationLock = false;
                bool exit_application = false;

                nav.OnExit = () =>
                {
                    Console.WriteLine("I am asked to shutdown!?!");
                    PlatformServices.Shutdown(0);
                    exit_application = true;
                };
                
                //while (!exit_application)
                //{
                    //Event e = null;
                    //for (; ; )
                    //{
                    //    PlatformServices.GetEvent(out e, 0);
                    //    if (e != null)
                    //    {
                    //        int domain = PlatformServices.GetDomainByEvent(e.Handle);

                    //        if (domain == Screen.GetDomain())
                    //            this.handleScreenEvent(e);
                    //        else if (domain == nav.Domain && (int)e.Code == (int)Navigator.EventType.NAVIGATOR_EXIT)
                    //            exit_application = true;
                    //    }
                    //    else
                    //        break;
                    //}

                    this.Render();
                //}
                PlatformServices.Run(this.Render);
                _util.Dispose();
            }
        }

        private void handleScreenEvent(Event _event)
        {
            ScreenEvent screenevent = ScreenEvent.FromEventHandle(_event.Handle);
            int screen_val = screenevent.GetIntProperty(PropertyType.SCREEN_PROPERTY_TYPE)[0];

            switch ((EventType)screen_val)
            {
                case EventType.SCREEN_EVENT_MTOUCH_TOUCH:
                case EventType.SCREEN_EVENT_MTOUCH_MOVE:
                case EventType.SCREEN_EVENT_MTOUCH_RELEASE:
                    break;
            }
        }

        private void Initialize()
        {
            //Initialize vertex and color data
            vertices[0] = -0.25f;
            vertices[1] = -0.25f;

            vertices[2] = 0.25f;
            vertices[3] = -0.25f;

            vertices[4] = -0.25f;
            vertices[5] = 0.25f;

            vertices[6] = 0.25f;
            vertices[7] = 0.25f;

            colors[0] = 1.0f;
            colors[1] = 0.0f;
            colors[2] = 1.0f;
            colors[3] = 1.0f;

            colors[4] = 1.0f;
            colors[5] = 1.0f;
            colors[6] = 0.0f;
            colors[7] = 1.0f;

            colors[8] = 0.0f;
            colors[9] = 1.0f;
            colors[10] = 1.0f;
            colors[11] = 1.0f;

            colors[12] = 0.0f;
            colors[13] = 1.0f;
            colors[14] = 1.0f;
            colors[15] = 1.0f;

            ////Query width and height of the window surface created by utility code
            int surface_width, surface_height;

            Egl.QuerySurface(_util.Display, _util.Surface, Egl.WIDTH, out surface_width);
            Egl.QuerySurface(_util.Display, _util.Surface, Egl.HEIGHT, out surface_height);

            // Create shaders
            string vSource =
                    "precision mediump float;" +
                    "uniform mat4 u_projection;" +
                    "uniform mat4 u_transform;" +
                    "attribute vec4 a_position;" +
                    "attribute vec4 a_color;" +
                    "varying vec4 v_color;" +
                    "void main()" +
                    "{" +
                    "    gl_Position = u_projection * u_transform * a_position;" +
                    "    v_color = a_color;" +
                    "}";

            string fSource =
                    "varying lowp vec4 v_color;" +
                    "void main()" +
                    "{" +
                    "    gl_FragColor = v_color;" +
                    "}";

            int status;

            // Compile the vertex shader
            int vs = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vs, vSource);
            GL.CompileShader(vs);
            GL.GetShader(vs, ShaderParameter.CompileStatus, out status);
            if (status == 0)
                GL.DeleteShader(vs);

            // Compile the fragment shader
            int fs = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fs, fSource);
            GL.CompileShader(fs);
            GL.GetShader(fs, ShaderParameter.CompileStatus, out status);
            if (status == 0)
            {
                GL.DeleteShader(vs);
                GL.DeleteShader(fs);
            }
                
            _program = GL.CreateProgram();
            GL.AttachShader(_program, vs);
            GL.AttachShader(_program, fs);
            GL.LinkProgram(_program);
          
            GL.GetProgram(_program, ProgramParameter.LinkStatus, out status);
            GL.UseProgram(_program);

            // Set up the orthographic projection - equivalent to glOrtho in GLES1
            int projectionLoc = GL.GetUniformLocation(_program, "u_projection");
            {
                float left = 0.0f;
                float right = (float)(surface_width) / (float)(surface_height);
                float bottom = 0.0f;
                float top = 1.0f;
                float zNear = -1.0f;
                float zFar = 1.0f;
                float[] ortho = new float[16] 
                                    {(float)2.0 / (right-left), 0, 0, 0,
                                    0,(float) 2.0 / (top-bottom), 0, 0,
                                    0, 0,(float) -2.0 / (zFar - zNear), 0,
                                    -(right+left)/(right-left), -(top+bottom)/(top-bottom), -(zFar+zNear)/(zFar-zNear), 1};
                GL.UniformMatrix4(projectionLoc, 1, false, ortho);
            }

            _transformLoc = GL.GetUniformLocation(_program, "u_transform");
            _positionLoc = GL.GetAttribLocation(_program, "a_position");
            _colorLoc = GL.GetAttribLocation(_program, "a_color");

            //// We don't need the shaders anymore - the program is enough
            GL.DeleteShader(fs);
            GL.DeleteShader(vs);

            //// Generate vertex and color buffers and fill with data
            GL.GenBuffers(1, out _vertexID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexID);
            //GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * sizeof(float)), vertices, BufferUsage.StaticDraw);

            GL.GenBuffers(1, out _colorID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _colorID);
            //GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)(colors.Length * sizeof(float)), colors, BufferUsage.StaticDraw);

            // Perform the same translation as the GLES1 version
            matrix[12] = (float)(surface_width) / (float)(surface_height) / 2;
            matrix[13] = 0.5f;
            GL.UniformMatrix4(_transformLoc, 1, false, matrix);
        }

        private int Render()
        {
            // Increment the angle by 0.5 degrees
            float angle = 0.0f;
            angle += 0.5f * OpenTKBlackberry.Math.MathHelper.Pi / 180.0f;

            //Typical render pass
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Enable and bind the vertex information
            GL.EnableVertexAttribArray(_positionLoc);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexID);
            GL.VertexAttribPointer(_positionLoc, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);

            // Enable and bind the color information
            GL.EnableVertexAttribArray(_colorLoc);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _colorID);
            GL.VertexAttribPointer(_colorLoc, 4, VertexAttribPointerType.Float, false, 4 * sizeof(float), 0);

            // Effectively apply a rotation of angle about the y-axis.
            matrix[0] = (float)Math.Cos(angle);
            matrix[2] = (float)-Math.Sin(angle);
            matrix[8] = (float)Math.Sin(angle);
            matrix[10] = (float)Math.Cos(angle);
            GL.UniformMatrix4(_transformLoc, 1, false, matrix);

            // Same draw call as in GLES1.
            GL.DrawArrays(BeginMode.TriangleStrip, 0, 4);
            
            // Disable attribute arrays
            GL.DisableVertexAttribArray(_positionLoc);
            GL.DisableVertexAttribArray(_colorLoc);

            //Egl.SwapBuffers(_util.Display, _util.Surface);
            _util.Swap();//previously commented

            return 1;
        }
    }
}
