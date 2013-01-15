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
    public enum FlushingType : int
    {
        SCREEN_WAIT_IDLE = (1 << 0),
        SCREEN_PROTECTED = (1 << 1),
        SCREEN_DONT_FLUSH = (1 << 2),
        SCREEN_POST_RESUME = (1 << 3)
    }
}

