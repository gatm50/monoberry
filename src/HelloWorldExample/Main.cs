using System;
using System.Threading;
using BlackberryPlatformServices.Camera;
using BlackberryPlatformServices.Dialog;
using HelloWorldExample;

namespace helloworld
{
    class MainClass
    {//--debug \ --debugger-agent=transport=dt_socket,address=192.168.75.135:80,server=y \ 
        public static void Main(string[] args)
        {
            ExampleHelloWorld ex = new ExampleHelloWorld();
            //RotatingSquare ex = new RotatingSquare();
            //ExampleGLCube ex = new ExampleGLCube();
            //ExampleGLTriangle ex = new ExampleGLTriangle();
            //ExamplePaint ex = new ExamplePaint();
            //ExampleBlackberryDocs ex = new ExampleBlackberryDocs();
            //FallingBlocks ex = new FallingBlocks();
            //ExampleAnalogClockGL ex = new ExampleAnalogClockGL();
            ex.Run();
        }

        public static void Timer()
        {
            using (var dlg = new Dialog("OMFG–“UNICODE”", "I'm running MØNØ!!!!1"))
            {
                dlg.Show();
                for (int i = 50; i > 0; i--)
                {
                    dlg.Message = String.Format("Closing in {0:0.00} seconds.", i / 10.0);
                    Thread.Sleep(100);
                }
            }
        }

        public static void Cam()
        {
            using (var c = new Camera(Camera.Unit.Front, Camera.Mode.RW))
            {
                c.TakePhoto();
            }
            Dialog.Alert("OMFG", "I got camera!1!1", new Button("Ok!"));
        }
    }
}
