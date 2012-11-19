using System;
using System.Threading;
using BlackberryPlatformServices;
using BlackberryPlatformServices.Camera;
using BlackberryPlatformServices.Dialog;
using BlackberryPlatformServices.Screen;
using BlackberryPlatformServices.Screen.Types;
using HelloWorldExample;

namespace helloworld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //ExampleHelloWorld ex = new ExampleHelloWorld();
            ExampleBlackberryDocs ex = new ExampleBlackberryDocs();
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
