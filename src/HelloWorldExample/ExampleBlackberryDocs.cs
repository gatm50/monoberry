//
//// Authors:
//   Gustavo Torrico (gatm50@gmail.com)
//// Licensed under the terms of the Microsoft Public License (MS-PL)
//// Copyright 2012 Cup-Coffee, ( http://cup-coffe.blogspot.com )
//

using BlackberryPlatformServices.Dialog;
using BlackberryPlatformServices.Screen;
using BlackberryPlatformServices.Screen.Types;

namespace HelloWorldExample
{
    public class ExampleBlackberryDocs
    {
        public void Run()
        {
            using (Context ctx = new Context())
            {
                Window wind = this.CreateBackgroundWindow("TheTeam", ctx);
                for (int i = 0; i < 15; i++)
                {
                    wind.Buffers[0].Fill(68199896);
                    wind.Render(wind.Buffers[0]);
                    System.Threading.Thread.Sleep(200);
                }

                var run = true;
                while (run)
                {
                    Dialog.Alert("CLOSE ME!", "Monoberry Runtime XDD",
                                  new Button("Close", () => run = false));
                }
                wind.Dispose();
            }
        }

        private Window CreateBackgroundWindow(string groupName, Context ctx)
        {
            Window wind = new Window(ctx);
            wind.CreateWindowGroup(groupName);
            wind.IsVisible = false;

            int color = unchecked((int)13493586);
            wind.Color = color;
            
            wind.CreateBuffer();
            wind.SetDimensions(700, 500);

            wind.Identifier = "ID500";

            return wind;
        }
    }
}
