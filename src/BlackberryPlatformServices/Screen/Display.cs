using System;
using System.Drawing;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace BlackberryPlatformServices.Screen
{
	public class Display
	{
		[DllImport ("screen")]
		static extern int screen_get_display_property_iv (IntPtr handle, PropertyType prop, out int val);
		
		[DllImport ("screen")]
        static extern int screen_get_display_property_iv(IntPtr handle, PropertyType prop, [Out] int[] vals);
		
		[DllImport ("screen")]
        static extern int screen_set_display_property_iv(IntPtr handle, PropertyType prop, ref int val);

		IntPtr handle;

		public Display (IntPtr hnd) {
			handle = hnd;
		}

		public Size Size {
			get {
				var rect = new int [2];
                screen_get_display_property_iv(handle, PropertyType.SCREEN_PROPERTY_SIZE, rect);
				return new Size (rect[0], rect[1]);
			}
		}

		public DisplayType Type {
			get {
                return (DisplayType)GetIntProperty(PropertyType.SCREEN_PROPERTY_TYPE);
			}
		}

        int GetIntProperty(PropertyType p)
		{
			int result;
			if (screen_get_display_property_iv (handle, p, out result) != 0) {
				throw new Exception ("Unable to read display property " + p);
			}
			return result;
		}

        void SetIntProperty(PropertyType p, int val)
		{
			if (screen_set_display_property_iv (handle, p, ref val) != 0) {
				throw new Exception ("Unable to set display property " + p);
			}
		}

	}
}


///*
// * Displays
// */
///**
//*   @ingroup screen_displays
//*   @{
//*/

///**
//*   @brief Retrieves the current value of the specified display property.
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
//*
//*   This function stores the current value of a display property in a
//*   user-provided array. No more than @c len bytes of the specified type will be
//*   written.
//*
//*   The values of the following properties can be retrieved using this function:
//*   - @c SCREEN_PROPERTY_ID_STRING
//*   - @c SCREEN_PROPERTY_VENDOR
//*   - @c SCREEN_PROPERTY_PRODUCT
//*
//*   @param  disp The handle of the display whose property is being queried.
//*   @param  pname The name of the property whose value is being queried. The
//*           properties available for query are of type
//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
//*   @param  len The maximum number of bytes that can be written to @c param
//*   @param  param The buffer where the retrieved values will be stored. This
//*           buffer should be of type char with a maximum length of @c len.
//*
//*   @return @c 0 upon a successful query and the value(s) of the property are
//*           stored in @c param, otherwise @c -1 and @c errno is set
//*/
//int screen_get_display_property_cv(screen_display_t disp, int pname, int len, char *param);

///**
//*   @brief Retrieves the current value of the specified display property.
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
//*
//*   This function stores the current value of a display property in a
//*   user-provided array.
//*
//*   The values of the following properties can be retrieved using this function:
//*   - @c SCREEN_PROPERTY_ID
//*   - @c SCREEN_PROPERTY_ATTACHED
//*   - @c SCREEN_PROPERTY_DETACHABLE
//*   - @c SCREEN_PROPERTY_FORMAT_COUNT
//*   - @c SCREEN_PROPERTY_GAMMA
//*   - @c SCREEN_PROPERTY_IDLE_STATE
//*   - @c SCREEN_PROPERTY_KEEP_AWAKES
//*   - @c SCREEN_PROPERTY_MIRROR_MODE
//*   - @c SCREEN_PROPERTY_MODE_COUNT
//*   - @c SCREEN_PROPERTY_POWER_MODE
//*   - @c SCREEN_PROPERTY_PROTECTION_ENABLE
//*   - @c SCREEN_PROPERTY_ROTATION
//*   - @c SCREEN_PROPERTY_TRANSPARENCY
//*   - @c SCREEN_PROPERTY_TYPE
//*   - @c SCREEN_PROPERTY_DPI
//*   - @c SCREEN_PROPERTY_NATIVE_RESOLUTION
//*   - @c SCREEN_PROPERTY_PHYSICAL_SIZE
//*   - @c SCREEN_PROPERTY_SIZE
//*   - @c SCREEN_PROPERTY_FORMATS
//*   - @c SCREEN_PROPERTY_VIEWPORT_POSITION
//*   - @c SCREEN_PROPERTY_VIEWPORT_SIZE
//*   - @c SCREEN_PROPERTY_METRIC_COUNT
//*
//*   @param  disp The handle of the display whose property is being queried.
//*   @param  pname The name of the property whose value is being queried. The
//*           properties available for query are of type
//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
//*   @param  param The buffer where the retrieved values will be stored. This
//*           buffer should be of type integer.
//*
//*   @return @c 0 upon a successful query and the value(s) of the property are
//*           stored in @c param, otherwise @c -1 and @c errno is set
//*/
//int screen_get_display_property_iv(screen_display_t disp, int pname, int *param);

///**
//*   @brief Retrieves the current value of the specified display property.
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
//*
//*   This function stores the current value of a display property in a
//*   user-provided array.
//*
//*   The values of the following properties can be retrieved using this function:
//*   - @c SCREEN_PROPERTY_IDLE_TIMEOUT
//*   - @c SCREEN_PROPERTY_METRICS
//*
//*   @param  disp The handle of the device whose property is being queried.
//*   @param  pname The name of the property whose value is being queried. The
//*           properties available for query are of type
//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
//*   @param  param The buffer where the retrieved values will be stored. This
//*           buffer should be of type long long integer.
//*
//*   @return @c 0 upon a successful query and the value(s) of the property are
//*           stored in @c param, otherwise @c -1 and @c errno is set
//*/
//int screen_get_display_property_llv(screen_display_t disp, int pname, long long *param);

///**
//*   @brief Retrieves the current value of the specified display property.
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
//*
//*   This function stores the current value of a display property in a
//*   user-provided array.
//*
//*   The values of the following properties can be retrieved using this function:
//*   - @c SCREEN_PROPERTY_CONTEXT
//*   - @c SCREEN_PROPERTY_MODE
//*   - @c SCREEN_PROPERTY_KEYBOARD_FOCUS
//*   - @c SCREEN_PROPERTY_MTOUCH_FOCUS
//*   - @c SCREEN_PROPERTY_MTOUCH_FOCUS
//*
//*   @param  disp The handle of the display whose property is being queried.
//*   @param  pname The name of the property whose value is being queried. The
//*           properties available for query are of type
//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
//*   @param  param The buffer where the retrieved values will be stored. This
//*           buffer should be of type void.
//*
//*   @return @c 0 upon a successful query and the value(s) of the property are
//*           stored in @c param, otherwise @c -1 and @c errno is set
//*/
//int screen_get_display_property_pv(screen_display_t disp, int pname, void **param);

///**
//*   @brief Sets the value of the specified display property.
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
//*
//*   This function sets the value of a display property from a user-provided array.
//*   No more than @c len bytes will be read from @c param.
//*
//*   Currently there are no display properties that can be queried using this
//*   function.
//*
//*   @param  disp The handle of the display whose property is to be set.
//*   @param  pname The name of the property whose value is being set. The
//*           properties available for setting are of type
//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
//*   @param  len The maximum number of bytes that can will be read from @c param
//*   @param  param A pointer to a buffer containing the new value(s).  This
//*           buffer should be of type char with a maximum length of @c len.
//*
//*   @return @c 0 upon the value(s) of the property being set to new value(s),
//*           otherwise @c -1 and @c errno is set
//*/
//int screen_set_display_property_cv(screen_display_t disp, int pname, int len, const char *param);

///**
//*   @brief Sets the value of the specified display property.
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
//*
//*   This function sets the value of a display property from a user-provided array.
//*
//*   The values of the following properties can be set using this function:
//*   - @c SCREEN_PROPERTY_GAMMA
//*   - @c SCREEN_PROPERTY_MIRROR_MODE
//*   - @c SCREEN_PROPERTY_MODE
//*   - @c SCREEN_PROPERTY_POWER_MODE
//*   - @c SCREEN_PROPERTY_PROTECTION_ENABLE
//*   - @c SCREEN_PROPERTY_ROTATION
//*   - @c SCREEN_PROPERTY_VIEWPORT_POSITION
//*   - @c SCREEN_PROPERTY_VIEWPORT_SIZE
//*
//*   @param  disp The handle of the display whose property is to be set.
//*   @param  pname The name of the property whose value is being set. The
//*           properties available for setting are of type
//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
//*   @param  param A pointer to a buffer containing the new value(s).  This
//*           buffer should be of type integer.
//*
//*   @return @c 0 upon the value(s) of the property being set to new value(s),
//*           otherwise @c -1 and @c errno is set
//*/
//int screen_set_display_property_iv(screen_display_t disp, int pname, const int *param);

///**
//*   @brief Sets the value of the specified display property.
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
//*
//*   This function sets the value of a display property from a user-provided array.
//*
//*   The values of the following properties can be set using this function:
//*   - @c SCREEN_PROPERTY_IDLE_TIMEOUT
//*
//*   @param  disp The handle of the display whose property is to be set.
//*   @param  pname The name of the property whose value is being set. The
//*           properties available for setting are of type
//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
//*   @param  param A pointer to a buffer containing the new value(s).  This
//*           buffer should be of type long long integer.
//*
//*   @return @c 0 upon the value(s) of the property being set to new value(s),
//*           otherwise @c -1 and @c errno is set
//*/
//int screen_set_display_property_llv(screen_display_t disp, int pname, const long long *param);

///**
//*   @brief Sets the value of the specified display property.
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
//*
//*   This function sets the value of a display property from a user-provided array.
//*
//*   The values of the following properties can be set using this function:
//*   - @c SCREEN_PROPERTY_KEYBOARD_FOCUS
//*   - @c SCREEN_PROPERTY_MTOUCH_FOCUS
//*   - @c SCREEN_PROPERTY_POINTER_FOCUS
//*
//*   @param  disp The handle of the display whose property is to be set.
//*   @param  pname The name of the property whose value is being set. The
//*           properties available for setting are of type
//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
//*   @param  param A pointer to a buffer containing the new value(s).  This
//*           buffer should be of type void.
//*
//*   @return @c 0 upon the value(s) of the property being set to new value(s),
//*           otherwise @c -1 and @c errno is set
//*/
//int screen_set_display_property_pv(screen_display_t disp, int pname, void **param);

///**
//*   @brief Retrieves the display modes supported by a specified display.
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
//*
//*   This function returns the video modes that are supported by a display. All
//*   elements in the list are unique. Note that several modes can have identical
//*   resolutions and differ only in refresh rate or aspect ratio. You can obtain
//*   the number of modes supported by querying the @c SCREEN_PROPERTY_MODE_COUNT
//*   property. No more than @c max modes will be stored.
//*
//*   @param  display The handle of the display whose display modes are being
//*           queried.
//*   @param  max The maximum number of display modes that can be written to the
//*           array of modes pointed to by @c param.
//*   @param  param The buffer where the retrieved display modes will be stored.
//*
//*   @return @c 0 upon a successful query and the value(s) of the property are
//*           stored in @c param, otherwise @c -1 and @c errno is set
//*/
//int screen_get_display_modes(screen_display_t display, int max, screen_display_mode_t *param);

///**
//*   @brief Takes a screenshot of the display and stores the resulting image in
//*   the specified buffer.
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
//*
//*   This function takes a screenshot of a display and stores the result in a
//*   user-provided buffer. The buffer can be a pixmap buffer or a window buffer.
//*   The buffer must have been created with the usage flag @c SCREEN_USAGE_NATIVE
//*   in order for the operation to succeed. You need to be working within a
//*   privileged context so that you have full access to the display properties of
//*   the system. Therefore, a context which was created with the type
//*   @c SCREEN_DISPLAY_MANAGER_CONTEXT must be used. When capturing screenshots of
//*   multiple displays, you will need to make one screen_read_display() function
//*   call per display. The call blocks until the operation is completed. If count
//*   is 0 and read_rects is NULL, the entire display is grabbed. Otherwise,
//*   read_rects must point to count * 4 integers defining rectangles in screen
//*   coordinates that need to be grabbed. Note that the buffer size does not have
//*   to match the display size. Scaling will be applied to make the screenshot
//*   fit into the buffer provided.
//*
//*   @param  disp The handle of the display that is the target of the screenshot.
//*   @param  buf The buffer where the resulting image will be stored.
//*   @param  count The number of rectables supplied in the @c read_rects
//*           argument.
//*   @param  read_rects A pointer to (@c count * 4) integers that define the
//*           areas of display that need to be grabbed for the screenshot.
//*   @param  flags The mutex flags; must be set to 0.
//*
//*   @return @c 0 upon a successful operation and pixels are written to @c buf,
//*           otherwise @c -1 and @c errno is set
//*/
//int screen_read_display(screen_display_t disp, screen_buffer_t buf, int count, const int *read_rects, int flags);

///**
//*   @brief Causes a window to share its buffers with a display
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
//*
//*   This function creates a @c count number of buffers with the size defined by the
//*   @c SCREEN_PROPERTY_BUFFER_SIZE window property of @c win. These buffers
//*   are rendered by the windowing system. The display will be used to generate
//*   content for the (window) buffers. Once there is a post for the window @c win,
//*   the content of the buffers will be displayed on the display @c share.
//*
//*   If the display has a framebuffer, then screen_share_display_buffers() is similar
//*   to screen_share_window_buffers().
//*
//*   @param  win The handle of the window who will be sharing its buffer(s).
//*   @param  share The handle of the display who is sharing buffer(s).
//*   @param  count The number of buffer st that is shared by the window to the display.
//*           A value of @c 0 will default to the UI Framework (Screen)services
//*           to select the appropriate values for properties such as @c SCREEN_PROPERTY_FORMAT,
//*           @c SCREEN_PROPERTY_USAGE and @c SCREEN_PROPERTY_BUFFER_SIZE.
//*
//*   @return @c 0 upon the windows sharing buffers,
//*           otherwise @c -1 and @c errno is set
//*/
//int screen_share_display_buffers(screen_window_t win, screen_display_t share, int count);

///**
//*   @brief Blocks the calling thread until the next vsync happens on the
//*   specified display.
//*
//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
//*
//*   This function blocks the calling thread and returns when the next vsync
//*   operation occurs on the specified display.
//*
//*   @param  display An instance of the display on which to perform the the
//*           vsync operation.
//*
//*   @return @c 0 upon a vsync operation occurance,
//*           otherwise @c -1 and @c errno is set
//*/
//int screen_wait_vsync(screen_display_t display);
///** @} */   /* end of ingroup screen_displays */