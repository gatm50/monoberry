//
//// Authors:
//   Gustavo Torrico (gatm50@gmail.com)
//// Licensed under the terms of the Microsoft Public License (MS-PL)
//// Copyright 2012 Cup-Coffee, ( http://cup-coffe.blogspot.com )
//

namespace BlackberryPlatformServices.Screen.Types
{
	public enum EventType
	{
		SCREEN_EVENT_NONE                      = 0,
		SCREEN_EVENT_CREATE                    = 1,
		SCREEN_EVENT_PROPERTY                  = 2,
		SCREEN_EVENT_CLOSE                     = 3,
		SCREEN_EVENT_INPUT                     = 4,
		SCREEN_EVENT_JOG                       = 5,
		SCREEN_EVENT_POINTER                   = 6,
		SCREEN_EVENT_KEYBOARD                  = 7,
		SCREEN_EVENT_USER                      = 8,
		SCREEN_EVENT_POST                      = 9,
		SCREEN_EVENT_EFFECT_COMPLETE           = 10,
		SCREEN_EVENT_DISPLAY                   = 11,
		SCREEN_EVENT_IDLE                      = 12,
		SCREEN_EVENT_UNREALIZE                 = 13,
		SCREEN_EVENT_GAMEPAD                   = 14,
		SCREEN_EVENT_JOYSTICK                  = 15,

		SCREEN_EVENT_MTOUCH_TOUCH              = 100,
		SCREEN_EVENT_MTOUCH_MOVE               = 101,
		SCREEN_EVENT_MTOUCH_RELEASE            = 102
	}
}

