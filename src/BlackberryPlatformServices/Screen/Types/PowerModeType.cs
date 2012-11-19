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
    public enum PowerModeType : int
    {
        SCREEN_POWER_MODE_OFF = 0x7680,
        SCREEN_POWER_MODE_SUSPEND = 0x7681,
        SCREEN_POWER_MODE_LIMITED_USE = 0x7682,
        SCREEN_POWER_MODE_ON = 0x7683
    }
}
