using System;

namespace BlackberryPlatformServices.Screen
{
	[Flags]
	public enum ContextType : int {
		SCREEN_APPLICATION_CONTEXT = 0,
		SCREEN_WINDOW_MANAGER_CONTEXT = (1 << 0),
		SCREEN_INPUT_PROVIDER_CONTEXT = (1 << 1),  
		SCREEN_POWER_MANAGER_CONTEXT = (1 << 2), 
		SCREEN_DISPLAY_MANAGER_CONTEXT = (1 << 3)
	}

}
