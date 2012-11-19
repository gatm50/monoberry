//
//// Authors:
//   Gustavo Torrico (gatm50@gmail.com)
//// Licensed under the terms of the Microsoft Public License (MS-PL)
//// Copyright 2012 Cup-Coffee, ( http://cup-coffe.blogspot.com )
//

namespace BlackberryPlatformServices.Screen.Types
{
    public enum PacketType : int
    {
        SCREEN_REQUEST_PACKET = 0,
        SCREEN_BLIT_PACKET = 1,
        SCREEN_INPUT_PACKET = 2,
        SCREEN_EVENT_PACKET = 3
    }
}
