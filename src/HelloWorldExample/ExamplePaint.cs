using System;
using BlackberryPlatformServices;
using BlackberryPlatformServices.Screen;
using BlackberryPlatformServices.Screen.Types;
using BlackberryPlatformServices.Dialog;

namespace HelloWorldExample
{
    public class ExamplePaint
    {
        public void Run()
        {
            using (var nav = new Navigator())
            using (var ctx = new Context(ContextType.SCREEN_APPLICATION_CONTEXT))
            using (var win = new Window(ctx))
            {
                win.Usage = UsageFlagType.SCREEN_USAGE_NATIVE;
                win.CreateBuffers(2);
                var bufs = win.Buffers;
                var pic = bufs[0];
                var brush = bufs[1];

                Blits.Fill(ctx, pic, 64441078);
                Blits.Fill(ctx, brush, 0xffff0000 );
                win.Render(pic);

                nav.OnSwipeDown += (() => Dialog.Alert ("#MonoBerry", "Another Event Loop", new Button ("Ack")));
                ctx.OnFingerTouch += (x, y) =>
                {
                    Blits.Blit(ctx, brush, pic, 0, 0, 10, 10, Math.Max(x - 5, 0), Math.Max(y - 5, 0));
                    win.Render(pic);
                };
                ctx.OnFingerMove = ctx.OnFingerTouch;
                ctx.OnFingerRelease = ctx.OnFingerTouch;

                nav.OnExit += () => 
                { 
                    Console.WriteLine("I am asked to shutdown!?!"); 
                    PlatformServices.Shutdown(0); 
                };

                PlatformServices.Run(null);
            }
        }
    }
}
