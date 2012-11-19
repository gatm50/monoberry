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
    public enum StylusButtonType : int
    {
        SCREEN_LOWER_STYLUS_BUTTON = (1 << 0),
        SCREEN_UPPER_STYLUS_BUTTON = (1 << 1)
    }
}
