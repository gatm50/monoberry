using System;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace BlackberryPlatformServices.Screen
{
	public class ScreenEvent
	{
		[DllImport ("screen")]
		static extern IntPtr screen_event_get_event (IntPtr bps_event);

		[DllImport ("screen")]
		static extern int screen_get_event_property_iv (IntPtr handle, PropertyType prop, out int val);

		[DllImport ("screen")]
        static extern int screen_get_event_property_pv(IntPtr handle, PropertyType prop, out IntPtr val);

		[DllImport ("screen")]
        static extern int screen_get_event_property_iv(IntPtr handle, PropertyType prop, int[] vals);

		IntPtr handle;

		public ScreenEvent (IntPtr e)
		{
			handle = e;
		}

		public static ScreenEvent FromEventHandle (IntPtr e)
		{
			return new ScreenEvent (screen_event_get_event (e));
		}

        public int GetIntProperty(PropertyType property)
		{
			int val;
			screen_get_event_property_iv (handle, property, out val);
			return val;
		}

        public IntPtr GetIntPtrProperty(PropertyType property)
		{
			IntPtr val;
			screen_get_event_property_pv (handle, property, out val);
			return val;
		}

		public int X {
			get {
				var ints = new int[2];
                if (screen_get_event_property_iv(handle, PropertyType.SCREEN_PROPERTY_POSITION, ints) != 0)
                {
					throw new Exception("Unable to read X position.");
				}
				return ints[0];
			}
		}

		public int Y {
			get {
				var ints = new int[2];
                if (screen_get_event_property_iv(handle, PropertyType.SCREEN_PROPERTY_POSITION, ints) != 0)
                {
					throw new Exception("Unable to read Y position.");
				}
				return ints[1];
			}
		}

		public EventType Type {
			get {
                return (EventType)GetIntProperty(PropertyType.SCREEN_PROPERTY_TYPE);
			}
		}
	}
}

