using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace BlackberryPlatformServices.Screen
{
    public class Window : IDisposable
    {
        #region DllImports
        ///**
        //*   @brief Associates an externally allocated buffer with a window.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function can be used by drivers and other middleware components that
        //*   must allocate their own buffers. The client must ensure that all usage
        //*   constraints are met when allocating the buffers. Failure to do so may
        //*   prevent the buffers from being successfully attached, or may result in
        //*   artifacts and system instability. Calling screen_attach_window_buffers()
        //*   and screen_create_window_buffers() is not permitted.
        //*
        //*   @param  win The handle of a window that does not already share a buffer with
        //*           another window nor have one or more buffers created
        //*           created or associated to it.
        //*   @param  count The number of buffers to be attached.
        //*   @param  buf An array of @c count buffers to be attached that was allocated
        //*           by the application.
        //*
        //*   @return @c 0 upon the buffers being used by the specified window,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_attach_window_buffers(screen_window_t win, int count, screen_buffer_t *buf);//*buf ==> out IntPtr[] buffers
        [DllImport("screen")]
        static extern int screen_attach_window_buffers(IntPtr win, int count, out IntPtr buf);

        ///**
        //*   @brief Creates a window that can be used to make graphical content visible
        //*   on a display.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function creates a window object. The window size defaults to full
        //*   screen when it is created. This is equivalent to calling
        //*   screen_create_window_type() with the type as @c SCREEN_APPLICATION_WINDOW.
        //*
        //*   @param  pwin An address where the function can store the handle to the
        //*           newly created native window.
        //*   @param  ctx The connection to the composition manager. This context should
        //*           have been created with screen_create_context().
        //*
        //*   @return @c 0 upon creation of a new window,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_create_window(screen_window_t *pwin, screen_context_t ctx);
        [DllImport("screen")]
        static extern int screen_create_window(out IntPtr pwin, IntPtr ctx);

        ///**
        //*   @brief Creates a new window of a specified type.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function creates a window object of the specified type.
        //*
        //*   @param  pwin An address where the function can store the handle to the
        //*           newly created native window.
        //*   @param  ctx The connection to the composition manager to be used to create
        //*           the window. This context should have been created with
        //*           screen_create_context().
        //*   @param  type The type of window to be created. @c type must be of type
        //*           Screen_Window_Types.
        //*
        //*   @return @c 0 upon creation of a new window,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_create_window_type(screen_window_t *pwin, screen_context_t ctx, int type);
        [DllImport("screen")]
        static extern int screen_create_window_type(out IntPtr pwin, IntPtr ctx, WindowType type);

        ///**
        //*   @brief Sends a request to the composition manager to add new buffers to a
        //*   window.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function adds buffers to a window. Windows need at least one
        //*   buffer to be visible. Buffers cannot be created using
        //*   screen_create_window_buffers() if at some point prior, buffers were attached
        //*   to this window using screen_attach_window_buffers().
        //*
        //*   @param  win The handle of the window for which the new buffers must be
        //*           allocated.
        //*   @param  count The number of buffers to be created for this window.
        //*
        //*   @return @c 0 upon creation of new buffers for specified window,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_create_window_buffers(screen_window_t win, int count);
        [DllImport("screen")]
        static extern int screen_create_window_buffers(IntPtr win, int count);

        ///**
        //*   @brief Creates a window group that other windows can join.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function creates a window group and assigns it to the specified window.
        //*   The group is identified by the name string - which must be unique. The
        //*   request will fail if another group was previously created with the same
        //*   name. Windows can parent only one group. Therefore,
        //*   screen_create_window_group() can only be called successfully once for any
        //*   given window. Additionally, only windows of certain types can parent a
        //*   group of windows. Windows with a type of @c SCREEN_APPLICATION_WINDOW
        //*   can parent windows of type @c SCREEN_CHILD_WINDOW and
        //*   @c SCREEN_EMBEDDED_WINDOW. Windows with a type of
        //*   @c SCREEN_CHILD_WINDOW can also create a group and
        //*   parent windows of type @c SCREEN_EMBEDDED_WINDOW. Once a group is
        //*   created, it exists until the window that parents the group is destroyed. When a
        //*   parent window is destroyed, all children are orphaned and made invisible.
        //*   Destroying a child has no effect on the group other than removing the window
        //*   from the group. Group owners have privileged access to the windows that they
        //*   parent. When windows join the group, the parent will receive a create group
        //*   event that contains a handle to the child window that can be used by the
        //*   parent to set properties or send events. Conversely, the parent gets
        //*   notified when a child window gets destroyed. The parent window is expected
        //*   to destroy its local copy of the window handle when one of its children is
        //*   destroyed.
        //*
        //*   @param  win The handle of the window for which the group is created. This
        //*           window must have been created with screen_create_window_type() with
        //*           a type of @c SCREEN_APPLICATION_WINDOW or @c SCREEN_CHILD_WINDOW.
        //*   @param  name A unique string that will be used to identify the window group.
        //*           Other than uniqueness, there are no other constraints on this name
        //*           (for example, lower case and special characters are permitted). This
        //*           string must be communicated to any window wishing to join the group
        //*           as a child of @c win.
        //*
        //*   @return @c 0 upon request for the new window group being queued,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_create_window_group(screen_window_t win, const char *name);
        [DllImport("screen")]
        static extern int screen_create_window_group(IntPtr win, char[] name);

        ///**
        //*   @brief Destroys a window and frees associated resources.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function destroys the window associated with the window handle. If the
        //*   window is visible, it is removed from the display. Any resources or buffers
        //*   created for this window, both locally, and by the composition manager, are
        //*   released. The window handle can no longer be used as argument to subsequent
        //*   screen calls. Buffers that are not created by the composition manager and
        //*   registered with screen_attach_window_buffer() are not freed by this
        //*   operation. The application is responsible for releasing its own external
        //*   buffers. Any window that shares buffers with the window is also destroyed.
        //*   screen_destroy_window() should be used to free windows that were
        //*   obtained by querying context or event properties. In this case, the
        //*   window is not removed from its display and destroyed. Only the local state
        //*   associated with the external window is released.
        //*
        //*   @param  win The handle of the window that should be destroyed. This should
        //*           have been created with screen_create_window().
        //*
        //*   @return @c 0 upon the specified window being destroyed,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_destroy_window(screen_window_t win);
        [DllImport("screen")]
        static extern int screen_destroy_window(IntPtr win);

        ///**
        //*   @brief Sends a request to the composition manager to destory the buffer of
        //*   the specified window.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function releases the buffer that was allocated for a window, without
        //*   destroying the window. If the buffer was created with
        //*   screen_create_window_buffer(), the memory is released and can be used for
        //*   other window or pixmap buffers. If the buffer was attached using
        //*   screen_attach_window_buffer(), the buffer is destroyed but no memory is
        //*   actually released. In this case the application is responsible for freeing
        //*   the memory after calling screen_destroy_window_buffer(). Once a window
        //*   buffer has been destroyed, you can change the format, the usage and the
        //*   buffer size before creating a new buffer again.
        //*   The memory that is released by this call is not reserved and can be used for
        //*   any subsequent buffer allocation by the windowing system.
        //*
        //*   @param  win The handle of the window whose buffer(s) will be destroyed.
        //*
        //*   @return @c 0 upon the memory used by the window buffer being freed,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_destroy_window_buffers(screen_window_t win);
        [DllImport("screen")]
        static extern int screen_destroy_window_buffers(IntPtr win);

        ///**
        //*   @brief Discards the specified window regions.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function is a hole-punching API. Use this function to specify window
        //*   regions you want to discard. The regions behave as if they were transparent,
        //*   or as if there were no transparency on the window. When you call this
        //*   function, it invalidates any regions you might have defined previously. You
        //*   can call the function with count set to 0 to remove discarded regions.
        //*
        //*   @param  win The handle of the window in which you want to specify regions
        //*           to discard.
        //*   @param  count The number of rectangles (retangular regions) you want to
        //*           discard, specified in the @c rects argument. The value of @c count
        //*           can be @c 0.
        //*   @param  rects An array of integers containing the x, y, width and height
        //*           coordinates of rectangles that bound areas in the window you want to
        //*           discard. The @c rects argument must provide at least 4 times @c count
        //*           integers - quadruples of x, y, width and height.
        //*
        //*   @return @c 0 upon the request for discarding window regions have been queued,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_discard_window_regions(screen_window_t win, int count, const int *rects);
        [DllImport("screen")]
        static extern int screen_discard_window_regions(IntPtr win, int count, ref int[] rects);

        ///**
        //*   @brief Retrieves the current value of the specified window property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function retrieves the value of window property from a user-provided
        //*   array.
        //*   The values of the following properties can be queried using this function:
        //*   - @c SCREEN_PROPERTY_CLASS
        //*   - @c SCREEN_PROPERTY_ID_STRING
        //*   - @c SCREEN_PROPERTY_GROUP
        //*
        //*   @param  win The handle of the window whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for querying are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  len The maximum number of bytes that can be written to @c param
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type char with a maximum length of @c len.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_window_property_cv(screen_window_t win, int pname, int len, char *param);
        [DllImport("screen")]
        static extern int screen_get_window_property_cv(IntPtr win, PropertyType pname, int len, [Out] char[] param);

        ///**
        //*   @brief Retrieves the current value of the specified window property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function retrieves the value of window property from a user-provided
        //*   array.
        //*   The values of the following properties can be queried using this function:
        //*   - @c SCREEN_PROPERTY_ALPHA_MODE
        //*   - @c SCREEN_PROPERTY_BUFFER_COUNT
        //*   - @c SCREEN_PROPERTY_COLOR_SPACE
        //*   - @c SCREEN_PROPERTY_FORMAT
        //*   - @c SCREEN_PROPERTY_OWNER_PID
        //*   - @c SCREEN_PROPERTY_RENDER_BUFFER_COUNT
        //*   - @c SCREEN_PROPERTY_SIZE
        //*   - @c SCREEN_PROPERTY_SWAP_INTERVAL
        //*   - @c SCREEN_PROPERTY_USAGE
        //*   - @c SCREEN_PROPERTY_BRIGHTNESS:
        //*   - @c SCREEN_PROPERTY_CBABC_MODE:
        //*   - @c SCREEN_PROPERTY_CONTRAST:
        //*   - @c SCREEN_PROPERTY_DEBUG:
        //*   - @c SCREEN_PROPERTY_FLIP:
        //*   - @c SCREEN_PROPERTY_FLOATING:
        //*   - @c SCREEN_PROPERTY_GLOBAL_ALPHA:
        //*   - @c SCREEN_PROPERTY_HUE:
        //*   - @c SCREEN_PROPERTY_IDLE_MODE:
        //*   - @c SCREEN_PROPERTY_KEYBOARD_FOCUS:
        //*   - @c SCREEN_PROPERTY_MIRROR:
        //*   - @c SCREEN_PROPERTY_PIPELINE:
        //*   - @c SCREEN_PROPERTY_PROTECTION_ENABLE:
        //*   - @c SCREEN_PROPERTY_ROTATION:
        //*   - @c SCREEN_PROPERTY_SATURATION:
        //*   - @c SCREEN_PROPERTY_SCALE_QUALITY:
        //*   - @c SCREEN_PROPERTY_SELF_LAYOUT:
        //*   - @c SCREEN_PROPERTY_SENSITIVITY:
        //*   - @c SCREEN_PROPERTY_STATIC:
        //*   - @c SCREEN_PROPERTY_TRANSPARENCY:
        //*   - @c SCREEN_PROPERTY_TYPE:
        //*   - @c SCREEN_PROPERTY_VISIBLE:
        //*   - @c SCREEN_PROPERTY_ZORDER:
        //*   - @c SCREEN_PROPERTY_BUFFER_SIZE:
        //*   - @c SCREEN_PROPERTY_CLIP_POSITION:
        //*   - @c SCREEN_PROPERTY_CLIP_SIZE:
        //*   - @c SCREEN_PROPERTY_POSITION:
        //*   - @c SCREEN_PROPERTY_SOURCE_CLIP_POSITION
        //*   - @c SCREEN_PROPERTY_SOURCE_CLIP_SIZE
        //*   - @c SCREEN_PROPERTY_SOURCE_POSITION
        //*   - @c SCREEN_PROPERTY_SOURCE_SIZE
        //*   - @c SCREEN_PROPERTY_VIEWPORT_POSITION
        //*   - @c SCREEN_PROPERTY_VIEWPORT_SIZE
        //*   - @c SCREEN_PROPERTY_METRIC_COUNT
        //*
        //*   @param  win The handle of the window whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for querying are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type integer.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_window_property_iv(screen_window_t win, int pname, int *param);
        [DllImport("screen")]
        static extern int screen_get_window_property_iv(IntPtr win, PropertyType pname, [Out] int[] param);

        ///**
        //*   @brief Retrieves the current value of the specified window property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function retrieves the value of a window property from a user-provided
        //*   array.
        //*   The values of the following properties can be queried using this function:
        //*    - @c SCREEN_PROPERTY_METRICS
        //*
        //*   @param  win handle of the window whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for querying are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type long long integer.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_window_property_llv(screen_window_t win, int pname, long long *param);
        [DllImport("screen")]
        static extern int screen_get_window_property_llv(IntPtr win, PropertyType pname, [Out] int[] param);

        ///**
        //*   @brief Retrieves the current value of the specified window property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function retrieves the value of a window property from a user-provided
        //*   array.
        //*   The values of the following properties can be queried using this function:
        //*   - @c SCREEN_PROPERTY_ALTERNATE_WINDOW
        //*   - @c SCREEN_PROPERTY_CONTEXT
        //*   - @c SCREEN_PROPERTY_DISPLAY
        //*   - @c SCREEN_PROPERTY_FRONT_BUFFER
        //*   - @c SCREEN_PROPERTY_GROUP
        //*   - @c SCREEN_PROPERTY_RENDER_BUFFERS
        //*   - @c SCREEN_PROPERTY_USER_HANDLE
        //*
        //*   @param  win handle of the window whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for querying are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type void.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_window_property_pv(screen_window_t win, int pname, void **param);
        [DllImport("screen")]
        static extern int screen_get_window_property_pv(IntPtr win, PropertyType pname, [Out] IntPtr[] param);

        ///**
        //*   @brief Causes a window to join a window group
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function is used to add a window to a group. Child and embedded windows
        //*   will remain invisible until they are properly parented. Until the window
        //*   joins a group, a window of any type behaves like an application window.
        //*   The window's positioning and visibility are not relative to any other window
        //*   on the screen. In order to join a group parented by an application window,
        //*   a window must have a type of @c SCREEN_CHILD_WINDOW or
        //*   @c SCREEN_EMBEDDED_WINDOW. Windows with a type of
        //*   @c SCREEN_EMBEDDED_WINDOW can join only groups parented
        //*   by windows of type @c SCREEN_CHILD_WINDOW. Once a window
        //*   successfully joins a group, its position on the screen will be relative to the
        //*   parent. The type of the window determines exactly how the window will be
        //*   positioned. Child windows are positioned relative to their parent (i.e. their window
        //*   position is added to the parent's window position. Embedded windows are
        //*   positioned relative to the source viewport of the parent. Windows in a group
        //*   inherit the visibility and the global transparency of their parent.
        //*
        //*   @param  win The handle for the window that is to join the group. This window
        //*           must have been created with screen_create_window_type() with a type
        //*           of either @c SCREEN_CHILD_WINDOW or @c SCREEN_EMBEDDED_WINDOW.
        //*   @param  name A unique string that identifies the group. This string must
        //*           have been communicated down from the parent window.
        //*
        //*   @return @c 0 upon request for window joining the specified group being
        //*           queued, otherwise @c -1 and @c errno is set
        //*/
        //int screen_join_window_group(screen_window_t win, const char *name);
        [DllImport("screen")]
        static extern int screen_join_window_group(IntPtr win, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string name);

        ///**
        //*   @brief Causes a window to leave a window group
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function removes a window from a window group. The window will no
        //*   longer be part of the window group.
        //*
        //*   @param  win The handle for the window that is to leave the group. This window
        //*           must have been created with screen_create_window_type() with a type
        //*           of either @c SCREEN_CHILD_WINDOW or @c SCREEN_EMBEDDED_WINDOW.
        //*
        //*   @return @c 0 upon request for window leaving its group being
        //*           queued, otherwise @c -1 and @c errno is set
        //*/
        //int screen_leave_window_group(screen_window_t win);
        [DllImport("screen")]
        static extern int screen_leave_window_group(IntPtr win);

        ///**
        //*   @brief Adds a wait for a post on a window.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This call blocks until there is a post event for the window you are waiting on.
        //*   This function is typically used in conjunction with screen_share_display_buffers()
        //*   and/or screen_share_window_buffers().
        //*
        //*   @param  win The handle for the window whose post you are waiting on.
        //*   @param  flags A bitmask that can be used to alter the default posting
        //*           behaviour. Valid flags are of type
        //*           <a href="screen_8h_1Screen_Flushing_Types.xml">Screen flushing types</a>.
        //*
        //*   @return @c 0 upon adding a wait for a post on the specified window,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_wait_post(screen_window_t win, int flags);
        [DllImport("screen")]
        static extern int screen_wait_post(IntPtr win, FlushingType flags);

        ///**
        //*   @brief Takes a screenshot of the window and stores the resulting image in
        //*   the specified buffer.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_apply_execution.xml">Apply Execution</a>
        //*
        //*   This function takes a screenshot of a window and stores the result in a
        //*   user-provided buffer. The buffer can be a pixmap buffer or a window buffer.
        //*   The buffer must have been created with the usage flag @c SCREEN_USAGE_NATIVE
        //*   in order for the operation to succeed. The call blocks until the operation
        //*   is completed. If count is 0 and read_rects is NULL, the entire window is
        //*   grabbed. Otherwise, read_rects must point to count * 4 integers defining
        //*   rectangles in screen coordinates that need to be grabbed. Note that the
        //*   buffer size does not have to match the window size. Scaling will be applied
        //*   to make the screenshot fit into the buffer provided.
        //*
        //*   @param  win The handle of the window that is the target of the screenshot.
        //*   @param  buf The buffer where the pixel data will be copied to.
        //*   @param  count The number of rectables supplied in the @c read_rects
        //*           argument.
        //*   @param  save_rects A pointer to (@c count * 4) integers that define the
        //*           areas of the window that need to be grabbed for the screenshot.
        //*   @param  flags The mutex flags; must be set to 0.
        //*
        //*   @return @c 0 upon a successful operation and pixels are written to @c buf,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_read_window(screen_window_t win, screen_buffer_t buf, int count, const int *save_rects, int flags);
        [DllImport("screen")]
        static extern int screen_read_window(IntPtr win, IntPtr buf, int count, ref int[] save_rects, int flags);

        ///**
        //*   @brief Creates a reference to a window.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function creates a reference to a window. This function can be used by
        //*   window managers and group parents to prevent a window from disappearing,
        //*   even when the process that originally created the window terminates
        //*   abnormally. At such a point, ownership of the window is transferred to the
        //*   window manager or group parent. The restrictions imposed on buffers still
        //*   exist. The contents of the buffers cannot be changed. The buffers cannot be
        //*   destroyed until the window is unreferenced. When the original process owner
        //*   is no longer a client of the windowing system, the window will be destroyed
        //*   when screen_destroy_window() is called by the reference owner.
        //*
        //*   @param  win The handle of the window for which the reference is to be
        //*           created.
        //*
        //*   @return @c 0 upon a reference to the specified window being created,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_ref_window(screen_window_t win);
        [DllImport("screen")]
        static extern int screen_ref_window(IntPtr win);

        ///**
        //*   @brief Sets the value of the specified window property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a window property from a user-provided array.
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_CLASS
        //*   - @c SCREEN_PROPERTY_ID_STRING
        //*
        //*   @param  win handle of the window whose property is being set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  len The maximum number of bytes that can be written to @c param
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type char with a maximum length of @c len.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_window_property_cv(screen_window_t win, int pname, int len, const char *param);
        [DllImport("screen")]
        static extern int screen_set_window_property_cv(IntPtr win, PropertyType pname, int len, char[] param);

        ///**
        //*   @brief Sets the value of the specified window property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a window property from a user-provided array.
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_ALPHA_MODE
        //*   - @c SCREEN_PROPERTY_BRIGHTNESS
        //*   - @c SCREEN_PROPERTY_CBABC_MODE
        //*   - @c SCREEN_PROPERTY_COLOR
        //*   - @c SCREEN_PROPERTY_COLOR_SPACE
        //*   - @c SCREEN_PROPERTY_CONTRAST
        //*   - @c SCREEN_PROPERTY_DEBUG
        //*   - @c SCREEN_PROPERTY_FLIP
        //*   - @c SCREEN_PROPERTY_FLOATING
        //*   - @c SCREEN_PROPERTY_GLOBAL_ALPHA
        //*   - @c SCREEN_PROPERTY_HUE
        //*   - @c SCREEN_PROPERTY_IDLE_MODE
        //*   - @c SCREEN_PROPERTY_MIRROR
        //*   - @c SCREEN_PROPERTY_PIPELINE
        //*   - @c SCREEN_PROPERTY_PROTECTION_ENABLE
        //*   - @c SCREEN_PROPERTY_ROTATION
        //*   - @c SCREEN_PROPERTY_SATURATION
        //*   - @c SCREEN_PROPERTY_SCALE_QUALITY
        //*   - @c SCREEN_PROPERTY_SELF_LAYOUT
        //*   - @c SCREEN_PROPERTY_SENSITIVITY
        //*   - @c SCREEN_PROPERTY_STATIC
        //*   - @c SCREEN_PROPERTY_SWAP_INTERVAL
        //*   - @c SCREEN_PROPERTY_TRANSPARENCY
        //*   - @c SCREEN_PROPERTY_VISIBLE
        //*   - @c SCREEN_PROPERTY_ZORDER
        //*   - @c SCREEN_PROPERTY_BUFFER_SIZE
        //*   - @c SCREEN_PROPERTY_FORMAT
        //*   - @c SCREEN_PROPERTY_USAGE
        //*   - @c SCREEN_PROPERTY_CLIP_POSITION
        //*   - @c SCREEN_PROPERTY_CLIP_SIZE
        //*   - @c SCREEN_PROPERTY_POSITION
        //*   - @c SCREEN_PROPERTY_SIZE
        //*   - @c SCREEN_PROPERTY_SOURCE_CLIP_POSITION
        //*   - @c SCREEN_PROPERTY_SOURCE_CLIP_SIZE
        //*   - @c SCREEN_PROPERTY_SOURCE_POSITION
        //*   - @c SCREEN_PROPERTY_SOURCE_SIZE
        //*   - @c SCREEN_PROPERTY_VIEWPORT_POSITION
        //*   - @c SCREEN_PROPERTY_VIEWPORT_SIZE
        //*
        //*   @param  win handle of the window whose property is being set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type integer.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_window_property_iv(screen_window_t win, int pname, const int *param);
        [DllImport("screen")]
        static extern int screen_set_window_property_iv(IntPtr win, PropertyType pname, int[] param);

        ///**
        //*   @brief Sets value of the specified window property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a window property from a user-provided array.
        //*   The values of the following properties can be set using this function:
        //*   - @c #SCREEN_PROPERTY_TIMESTAMP
        //*
        //*   @param  win handle of the window whose property is being set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type long long integer.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_window_property_llv(screen_window_t win, int pname, const long long *param);
        [DllImport("screen")]
        static extern int screen_set_window_property_llv(IntPtr win, PropertyType pname, int[] param);

        ///**
        //*   @brief Sets the value of the specified window property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a window property from a user-provided array.
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_ALTERNATE_WINDOW
        //*   - @c SCREEN_PROPERTY_DISPLAY
        //*   - @c SCREEN_PROPERTY_USER_HANDLE
        //*
        //*   @param  win handle of the window whose property is being set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type void.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_window_property_pv(screen_window_t win, int pname, void **param);
        [DllImport("screen")]
        static extern int screen_set_window_property_pv(IntPtr win, PropertyType pname, IntPtr[] param);

        ///**
        //*   @brief Causes a window to share buffers which have been created for or
        //*   attached to another window.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function is used when a window needs to share the same buffers created
        //*   for, or attached to, another window. For this operation to be successful,
        //*   the window that is the owner of the buffer(s) to be shared must have at
        //*   least one buffer that was created with screen_create_window_buffers() or
        //*   attached with screen_attach_window_buffer(). Buffers cannot be created or
        //*   attached to any window that is sharing the buffers owned by another window.
        //*   Updates can only be posted using the window that is the owner of the buffers
        //*   (i.e. the window whose handle is identified as @c share). Any window that is
        //*   sharing buffers with another window is orphaned from the buffers and made
        //*   invisible when the window who owns the buffer(s) is destroyed. At this time,
        //*   that status of each orphaned window is such that a new buffer can be created
        //*   for it, or screen_share_window_buffers() can be called again. You can use the
        //*   screen_share_window_buffers() function to improve performance by reducing
        //*   the amount of blending on the screen. For example, a window might be
        //*   entirely transparent except for a watermark that needs to be blended in a
        //*   corner. Blending the entire window is costly and can be avoided by setting
        //*   the transparency of this window to @c SCREEN_TRANSPARENCY_DISCARD. To keep the
        //*   watermark visible, another window can be created and made to share buffers
        //*   with the main window. This way, most of the window is discarded and a much
        //*   smaller area is actually blended.
        //*   @attention Any window property, such as @c SCREEN_PROPERTY_FORMAT,
        //*   @c SCREEN_PROPERTY_USAGE, and @c SCREEN_PROPERTY_BUFFER_SIZE,
        //*   which was set prior to calling screen_share_window_buffers(), is ignored
        //*   and reset to the  values of the parent window.
        //*
        //*
        //*   @param  win The handle of the window who will be sharing the buffer(s) owned
        //*           by another window.
        //*   @param  share The handle of the window whose buffer(s) is to be shared.
        //*
        //*   @return @c 0 upon the windows sharing buffers,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_share_window_buffers(screen_window_t win, screen_window_t share);
        [DllImport("screen")]
        static extern int screen_share_window_buffers(IntPtr win, IntPtr share);

        ///**
        //*   @brief Removes a reference from a specified window.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function removes a reference to a window. When a window is being referenced,
        //*   its buffers cannot be destroyed until all references to that window have been
        //*   removed.
        //*
        //*   @param  win The handle of the window for which the reference is to be
        //*           removed.
        //*
        //*   @return @c 0 upon a reference to the specified window being removed,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_unref_window(screen_window_t win);
        [DllImport("screen")]
        static extern int screen_unref_window(IntPtr win);

        ///**
        //*   @brief Makes window content updates visible on the display
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_apply_execution.xml">Apply Execution</a>
        //*
        //*   This function makes some pixels in a rendering buffer visible. The pixels to
        //*   be posted are defined by the dirty rectangles contained in the
        //*   @c dirty_rects argument. The function may cause the
        //*   @c SCREEN_PROPERTY_RENDER_BUFFERS of the window to change.
        //*   The presentation of new content may result in a copy or a buffer flip, depending
        //*   on how the composited windowing system chooses to perform the operation.
        //*   At a minimum, this function will block until another buffer becomes available.
        //*   If @c SCREEN_WAIT_IDLE is set in the flags, the function will return only when
        //*   the contents of the display have been updated. Note that a window will not
        //*   be made visible until screen_post_window() has been called at least once. If
        //*   the window is currently locked, posting updates has the effect of flushing
        //*   all pending property changes and blocks until all other locked windows have
        //*   released the lock or posted updates of their own. In this case, the window
        //*   remains locked when screen_post_window() returns, and any subsequent
        //*   property change is delayed until the window lock is released or another
        //*   frame is posted. If count is @c 0, the buffer is discarded and a new set of
        //*   rendering buffers is returned. The current front buffer remains unchanged
        //*   and the contents of the screen will not be updated.
        //*
        //*   @param  win The handle for the window whose content has changed.
        //*   @param  buf The rendering buffer of the window that contains the changes
        //*           needed to be made visible.
        //*   @param  count The number of rectangles provided in the @c dirty_rects
        //*           argument.
        //*   @param  dirty_rects An array of integers containing the x1, y1, x2 and y2
        //*           coordinates of a rectangle that bounds the area of the rendering
        //*           buffer that has changed since the last posting of the window. The
        //*           @c dirty_rects argument must provide at least @c count * 4 integers.
        //*   @param  flags A bitmask that can be used to alter the default posting
        //*           behaviour. Valid flags are of type Screen_Flushing_Types.
        //*
        //*   @return @c 0 upon the area of the rendering buffer that is marked dirty has
        //*           updated on the screen and a new set of rendering buffers is
        //*           returned. This new set of buffers can be used for the next updates.
        //*           queued, otherwise @c -1 and @c errno is set
        //*/
        //int screen_post_window(screen_window_t win, screen_buffer_t buf, int count, const int *dirty_rects, int flags);
        [DllImport("screen", SetLastError = true)]
        static extern int screen_post_window(IntPtr win, IntPtr buf, int count, [In] int[] dirty_rects, FlushingType flags);
        #endregion

        Context _context;
        IntPtr _handle;
        IntPtr _buffer;

        #region Properties
        public Action OnClose { get; set; }
        public Action OnCreate { get; set; }

        public IntPtr Handle { get { return _handle; } }

        internal bool HandleEvent(ScreenEvent ev)
        {
            Debug.Print("Window  XX {0}: Shall handle {1} event.", Handle, ev.Type);
            switch (ev.Type)
            {
                case EventType.SCREEN_EVENT_CLOSE:
                    if (OnClose != null)
                    {
                        OnClose();
                        return true;
                    }
                    break;
                case EventType.SCREEN_EVENT_CREATE:
                    if (OnCreate != null)
                    {
                        OnCreate();
                        return true;
                    }
                    break;
            }

            return false;
        }

        public UsageFlagType Usage
        {
            get
            {
                return (UsageFlagType)GetIntProperty(PropertyType.SCREEN_PROPERTY_USAGE);
            }

            set
            {
                SetIntProperty(PropertyType.SCREEN_PROPERTY_USAGE, new int[] { (int)value });
            }
        }

        public TransparencyTypes Transparency
        {
            get
            {
                return (TransparencyTypes)GetIntProperty(PropertyType.SCREEN_PROPERTY_TRANSPARENCY);
            }

            set
            {
                SetIntProperty(PropertyType.SCREEN_PROPERTY_TRANSPARENCY, new int[] { (int)value });
            }
        }

        public PixelFormatType PixelFormat
        {
            get
            {
                return (PixelFormatType)GetIntProperty(PropertyType.SCREEN_PROPERTY_FORMAT);
            }

            set
            {
                SetIntProperty(PropertyType.SCREEN_PROPERTY_FORMAT, new int[] { (int)value });
            }
        }

        public bool IsVisible
        {
            get
            {
                return GetIntProperty(PropertyType.SCREEN_PROPERTY_VISIBLE) == 1;
            }
            set
            {
                if (value)
                    SetIntProperty(PropertyType.SCREEN_PROPERTY_VISIBLE, new int[] { 1 });
                else
                    SetIntProperty(PropertyType.SCREEN_PROPERTY_VISIBLE, new int[] { 0 });
            }
        }

        public List<Buffer> Buffers
        {
            get
            {
                int count = GetIntProperty(PropertyType.SCREEN_PROPERTY_RENDER_BUFFER_COUNT);
                if (count == 0)
                    return new List<Buffer>();

                var bufs = new IntPtr[count];
                this.GetVoidProperty(PropertyType.SCREEN_PROPERTY_RENDER_BUFFERS, ref bufs);
                var list = new List<Buffer>();

                foreach (var i in bufs)
                    list.Add(new Buffer(_context, i));

                return list;
            }
        }

        public int Width
        {
            get
            {
                var rect = new int[2];
                screen_get_window_property_iv(_handle, PropertyType.SCREEN_PROPERTY_BUFFER_SIZE, rect);
                return rect[0];
            }
        }

        public int Height
        {
            get
            {
                var rect = new int[2];
                screen_get_window_property_iv(_handle, PropertyType.SCREEN_PROPERTY_BUFFER_SIZE, rect);
                return rect[1];
            }
        }

        public string Identifier
        {
            get
            {
                //TODO: Resolve len parameters, it must not be hard coded.
                string res = new string(this.GetCharProperty(PropertyType.SCREEN_PROPERTY_ID_STRING, 10));
                return res;
            }
            set
            {
                char[] chars = value.ToCharArray();
                this.SetCharProperty(PropertyType.SCREEN_PROPERTY_ID_STRING, chars);
            }
        }

        public int Color
        {
            set { this.SetIntProperty(PropertyType.SCREEN_PROPERTY_COLOR, new int[] { (int)value }); }
        }

        #endregion

        public Window(Context ctx, WindowType type = WindowType.SCREEN_APPLICATION_WINDOW)
        {
            _context = ctx;

            if (type == WindowType.SCREEN_APPLICATION_WINDOW)
                this.CreateWindow();
            else
                this.CreateWindowType(type);
        }

        public Window(Context ctx, IntPtr hnd)
        {
            _context = ctx;
            _handle = hnd;
        }

        public void AttachWindowBuffer(int buffersToAttach)
        {
            if (screen_attach_window_buffers(_handle, buffersToAttach, out _buffer) != 0)
                throw new Exception("Unable to attach window buffers.");
        }

        private void CreateWindow()
        {
            if (screen_create_window(out _handle, _context.Handle) != 0)
                throw new Exception("Unable to create window");
        }

        private void CreateWindowType(WindowType type)
        {
            if (screen_create_window_type(out _handle, _context.Handle, type) != 0)
                throw new Exception("Unable to create window");
        }

        public void CreateBuffer()
        {
            CreateBuffers(1);
        }

        public void CreateBuffers(int count)
        {
            if (screen_create_window_buffers(_handle, count) != 0)
                throw new Exception("Unable to create buffers.");
        }

        public void CreateWindowGroup(string name = "")
        {
            if (name == string.Empty)
                name = _handle.ToString();

            char[] chars = name.ToCharArray();

            if (screen_create_window_group(_handle, chars) != 0)
                throw new Exception("Unable to create window group");
        }

        public void Dispose()
        {
            if (screen_destroy_window(_handle) != 0)
                throw new Exception("Unable to destroy window");
        }

        public void DestroyWindowBuffers()
        {
            if (screen_destroy_window_buffers(_handle) != 0)
                throw new Exception("Unable to destroy window buffers.");
        }

        public void DiscardWindowRegion(int count, params int[] rects)
        {
            if ((rects.Length % 4) != 0)
                throw new Exception("The params must be quadruples, x, y, width and height ");

            if (screen_discard_window_regions(_handle, count, ref rects) != 0)
                throw new Exception("Unable to discard window regions");
        }

        public void JoinWindowGroup(string name = "")
        {
            if (name == string.Empty)
                name = _handle.ToString();

            if (screen_join_window_group(_handle, name) != 0)
                throw new Exception("Unable to join window to group.");
        }

        #region Get-Set Properties
        public int GetIntProperty(PropertyType p)
        {
            var result = new int[] { 0 };

            if (screen_get_window_property_iv(_handle, p, result) != 0)
                throw new Exception("Unable to read window property " + p);

            return result[0];
        }

        public void SetIntProperty(PropertyType p, int[] val)
        {
            if (screen_set_window_property_iv(_handle, p, val) != 0)
                throw new Exception("Unable to set window property " + p);
        }

        public char[] GetCharProperty(PropertyType p, int len)
        {
            var result = new char[len];

            if (screen_get_window_property_cv(_handle, p, len, result) != 0)
                throw new Exception("Unable to read window property " + p);

            return result;
        }

        public void SetCharProperty(PropertyType p, char[] val)
        {
            if (screen_set_window_property_cv(_handle, p, val.Length, val) != 0)
                throw new Exception("Unable to set window property " + p);
        }

        public int GetLongProperty(PropertyType p)
        {
            var result = new int[] { 0 };

            if (screen_get_window_property_llv(_handle, p, result) != 0)
                throw new Exception("Unable to read window property " + p);

            return result[0];
        }

        public void SetLongProperty(PropertyType p, int[] val)
        {
            if (screen_set_window_property_llv(_handle, p, val) != 0)
                throw new Exception("Unable to set window property " + p);
        }

        public void GetVoidProperty(PropertyType p, ref IntPtr[] val)
        {
            if (screen_get_window_property_pv(_handle, p, val) != 0)
                throw new Exception("Unable to read window property " + p);
        }

        public void SetVoidProperty(PropertyType p, IntPtr[] val)
        {
            if (screen_set_window_property_pv(_handle, p, val) != 0)
                throw new Exception("Unable to set window property " + p);
        }
        #endregion

        public void LeaveWindowGroup()
        {
            if (screen_leave_window_group(_handle) != 0)
                throw new Exception("Unable to leave window group.");
        }

        public void WaitPost(FlushingType flag)
        {
            if (screen_wait_post(_handle, flag) != 0)
                throw new Exception("Unable to wait post.");
        }

        public void ReadWindow(IntPtr buf, int count, int[] saveRects)
        {
            if (buf == IntPtr.Zero)
                buf = _buffer;
            if ((saveRects.Length % 4 != 0))
                throw new Exception("The params must be quadruples, x, y, width and height.");

            if (screen_read_window(_handle, buf, count, ref saveRects, 0) != 0)
                throw new Exception("Unable to read window.");
        }

        public void CreateReferenceToWindow()
        {
            if (screen_ref_window(_handle) != 0)
                throw new Exception("Unable to reference the window.");
        }

        public void ShareWindowBuffer(IntPtr windowHandle)
        {
            if (screen_share_window_buffers(windowHandle, _handle) != 0)
                throw new Exception("Unable to share the window buffer.");
        }

        public void DisposeReferenceWindow()
        {
            if (screen_unref_window(_handle) != 0)
                throw new Exception("Unable to dispose the window reference.");
        }

        public void Render(Buffer buffer)
        {
            var dirty = new int[] { 0, 0, Width, Height };
            // Flushing.SCREEN_WAIT_IDLE bombs on the PlayBook, lets use 0 (undefined, but used in samples!) for now.
            if (screen_post_window(_handle, buffer.Handle, 1, dirty, 0) != 0)
                throw new Exception("Unable to render buffer to window!!");
        }

        public void Render(Buffer buf, Rectangle rect, FlushingType flush)
        {
            Console.WriteLine("Rendering {0}", rect);
            var dirty = new int[] { rect.Left, rect.Top, rect.Width, rect.Height };
            if (screen_post_window(_handle, buf.Handle, 1, dirty, flush) != 0)
            {
                throw new Exception("Unable to render buffer to window!!");
            }
        }

        public void SetDimensions(int width, int height)
        {
            var values = new int[2] { width, height };
            this.SetIntProperty(PropertyType.SCREEN_PROPERTY_BUFFER_SIZE, values);
        }
    }
}