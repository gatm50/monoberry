using System;

namespace BlackberryPlatformServices.Screen
{
	[Flags]
	public enum Flushing : int {
		SCREEN_WAIT_IDLE = (1 << 0),
		SCREEN_PROTECTED = (1 << 1),
		SCREEN_DONT_FLUSH = (1 << 2),
		SCREEN_POST_RESUME = (1 << 3)   
	}
}

