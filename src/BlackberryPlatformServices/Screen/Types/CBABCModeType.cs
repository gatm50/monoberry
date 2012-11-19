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
    public enum CBABCModeType : int
    {
        SCREEN_CBABC_MODE_NONE = 0x7671,
        SCREEN_CBABC_MODE_VIDEO = 0x7672,
        SCREEN_CBABC_MODE_UI = 0x7673,
        SCREEN_CBABC_MODE_PHOTO = 0x7674
    }
}
