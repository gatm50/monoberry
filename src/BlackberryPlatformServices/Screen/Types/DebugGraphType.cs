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
    public enum DebugGraphType : int
    {
        SCREEN_DEBUG_GRAPH_FPS = (1 << 0),
        SCREEN_DEBUG_GRAPH_POSTS = (1 << 1),
        SCREEN_DEBUG_GRAPH_BLITS = (1 << 2),
        SCREEN_DEBUG_GRAPH_UPDATES = (1 << 3),
        SCREEN_DEBUG_STATISTICS = (1 << 4)
    }
}
