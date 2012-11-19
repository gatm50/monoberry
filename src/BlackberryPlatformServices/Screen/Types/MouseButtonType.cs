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
    public enum MouseButtonType : int
    {
        SCREEN_LEFT_MOUSE_BUTTON = (1 << 0),
        SCREEN_MIDDLE_MOUSE_BUTTON = (1 << 1),
        SCREEN_RIGHT_MOUSE_BUTTON = (1 << 2)
    }
}
