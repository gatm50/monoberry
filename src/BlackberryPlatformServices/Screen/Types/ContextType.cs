//
//// Authors:
//   Gustavo Torrico (gatm50@gmail.com)
//// Licensed under the terms of the Microsoft Public License (MS-PL)
//// Copyright 2012 Cup-Coffee, ( http://cup-coffe.blogspot.com )
//

using System;

namespace BlackberryPlatformServices.Screen.Types
{
    [Flags]
    public enum ContextType : int
    {
        SCREEN_APPLICATION_CONTEXT = 0,
        SCREEN_WINDOW_MANAGER_CONTEXT = (1 << 0),
        SCREEN_INPUT_PROVIDER_CONTEXT = (1 << 1),
        SCREEN_POWER_MANAGER_CONTEXT = (1 << 2),
        SCREEN_DISPLAY_MANAGER_CONTEXT = (1 << 3)
    }
}
