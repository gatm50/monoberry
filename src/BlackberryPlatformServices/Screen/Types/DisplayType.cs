﻿//
//// Authors:
//   Gustavo Torrico (gatm50@gmail.com)
//// Licensed under the terms of the Microsoft Public License (MS-PL)
//// Copyright 2012 Cup-Coffee, ( http://cup-coffe.blogspot.com )
//

using System;
namespace BlackberryPlatformServices.Screen.Types
{
    [Flags]
    public enum DisplayType : int
    {
        SCREEN_DISPLAY_TYPE_INTERNAL = 0x7660,
        SCREEN_DISPLAY_TYPE_COMPOSITE = 0x7661,
        SCREEN_DISPLAY_TYPE_SVIDEO = 0x7662,
        SCREEN_DISPLAY_TYPE_COMPONENT_YPbPr = 0x7663,
        SCREEN_DISPLAY_TYPE_COMPONENT_RGB = 0x7664,
        SCREEN_DISPLAY_TYPE_COMPONENT_RGBHV = 0x7665,
        SCREEN_DISPLAY_TYPE_DVI = 0x7666,
        SCREEN_DISPLAY_TYPE_HDMI = 0x7667,
        SCREEN_DISPLAY_TYPE_DISPLAYPORT = 0x7668,
        SCREEN_DISPLAY_TYPE_OTHER = 0x7669
    }
}
