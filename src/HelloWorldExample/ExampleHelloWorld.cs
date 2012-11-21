using System;
using BlackberryPlatformServices;
using BlackberryPlatformServices.Dialog;
using BlackberryPlatformServices.Screen;
using BlackberryPlatformServices.Screen.Types;

namespace HelloWorldExample
{
    public class ExampleHelloWorld
    {
        public void Run()
        {
            using (var nav = new Navigator())
            using (var ctx = new Context(ContextType.SCREEN_APPLICATION_CONTEXT))
            using (var win = new Window(ctx, WindowType.SCREEN_APPLICATION_WINDOW))
            {
                string groupName = "TheTeam";
                win.CreateWindowGroup(groupName);

                win.CreateBuffers(10);
                win.Identifier = "parent";

                var r = new Random();
                foreach (var b in win.Buffers)
                {
                    Blits.Fill(ctx, b, (uint)r.Next());
                    win.Render(b);
                    System.Threading.Thread.Sleep(200);
                }

                Window childWindow = new Window(ctx, WindowType.SCREEN_CHILD_WINDOW);
                childWindow.JoinWindowGroup(groupName);
                childWindow.CreateBuffer();
                childWindow.Identifier = "child";

                Blits.Fill(ctx, childWindow.Buffers[0], 50);
                childWindow.Render(childWindow.Buffers[0]);

                SoundPlayer sp = new SoundPlayer(SoundPlayer.SystemSounds.EventDeviceUntether);
                sp.PlaySound();
                VirtualKeyboard kb = new VirtualKeyboard();
                Orientation or= new Orientation();
                var run = true;
                string message=string.Format("Monoberry Runtime!. BPS Version: {0} Direction: {1}",PlatformServices.GetVersionBPS().ToString(), or.CurrentDirection.ToString());
                while (run)
                {
                    Dialog.Alert("CLOSE ME!", message,
                        //new Button ("Timer", Timer),
                        //new Button ("Camera", Cam),
                        //new Button ("Messages", () => nav.Invoke ("messages://")),
                                  //new Button("Show Keyboard", () => kb.Show()),
                                  new Button("Play Random Sound", () => this.PlaySound(sp, r)),
                                  new Button("Badge", () => nav.HasBadge = true),
                                  new Button("Browser", () => nav.Invoke("http://www.bing.com/")),
                                  new Button("Close", () => run = false));
                }
            }
        }
        private void PlaySound(SoundPlayer sp, Random r)
        {
            sp.FileName = (SoundPlayer.SystemSounds)r.Next(15);
            sp.PlaySound();
        }
    }
}
