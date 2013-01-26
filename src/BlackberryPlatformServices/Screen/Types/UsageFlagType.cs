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
    public enum UsageFlagType : int
    {
        SCREEN_USAGE_DISPLAY = (1 << 0),
        SCREEN_USAGE_READ = (1 << 1),
        SCREEN_USAGE_WRITE = (1 << 2),
        SCREEN_USAGE_NATIVE = (1 << 3),
        SCREEN_USAGE_OPENGL_ES1 = (1 << 4),
        SCREEN_USAGE_OPENGL_ES2 = (1 << 5),
        SCREEN_USAGE_OPENVG = (1 << 6),
        SCREEN_USAGE_VIDEO = (1 << 7),
        SCREEN_USAGE_CAPTURE = (1 << 8),
        SCREEN_USAGE_ROTATION = (1 << 9),
        SCREEN_USAGE_OVERLAY = (1 << 10)
    }
}
