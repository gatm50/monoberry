using System;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace BlackberryPlatformServices.Screen
{
    public class ScreenEvent
    {
        #region DllImport
        ///**
        //*   @brief Creates an event that can later be filled with event data.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function creates an event object. This event can be used to store
        //*   events from the process's event queue using screen_get_event(). Event data
        //*   can also be filled in with the screen_set_event_property() functions and
        //*   sent to other applications using screen_inject_event() or
        //*   screen_send_event(). Events are opaque handles. screen_get_event_property()
        //*   functions must be used to get information from the event. You should destroy
        //*   event objects when you no longer need them by using screen_destroy_event().
        //*
        //*   @param  pev An address where the function can store a handle to the native
        //*           event.
        //*
        //*   @return @c 0 upon the creation of a new event,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_create_event(screen_event_t *pev);
        [DllImport("screen")]
        static extern int screen_create_event(out IntPtr pev);

        ///**
        //*   @brief Destroys an event and free associated memory.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function frees the memory allocated to hold an event. The event can no
        //*   longer be used as an argument in subsequent screen calls.
        //*
        //*   @param  ev The handle of the event to destroy. This event must have been
        //*           created with screen_create_event().
        //*
        //*   @return @c 0 upon the event being destroyed,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_destroy_event(screen_event_t ev);
        [DllImport("screen")]
        static extern int screen_destroy_event(IntPtr ev);

        ///**
        //*   @brief Waits for a screen event.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>

        //*   This function gets the next event associated with the given context. If no
        //*   events have been queued, the function will wait up to the specified amount
        //*   of time for an event to occur. If the function times out before an event
        //*   becomes available, an event with a @c SCREEN_EVENT_NONE type will be returned.
        //*
        //*   @param  ctx The context to retrieve events from. This context must have been
        //*           created using screen_create_context().
        //*   @param  ev An event previously allocated with screen_create_event(). Any
        //*           contents in this event will be replaced with the next event.
        //*   @param  timeout The maximum time to wait for an event to occur if one has
        //*           not been queued up already. @c 0 indicates that the call should not
        //*           wait at all if there are no events associated with the specified
        //*           context. @c -1 indicates that the call should not return until an
        //*           event is ready.
        //*
        //*   @return @c 0 upon the event being destroyed,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_event(screen_context_t ctx, screen_event_t ev, uint64_t timeout);
        [DllImport("screen")]
        static extern int screen_get_event(IntPtr ctx, IntPtr ev, long timeout);

        ///**
        //*   @brief Retrieves the current value of the specified event property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function stores the current value of an event property in a
        //*   user-provided array. No more than @c len bytes of the specified type will be
        //*   written.
        //*   The list of properties that can be queried per event type are listed as
        //*   follows:
        //*
        //*   - @c SCREEN_EVENT_CREATE
        //*   - @c SCREEN_PROPERTY_GROUP
        //*
        //*   @param  ev The handle of the event whose property is being queried.
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
        //int screen_get_event_property_cv(screen_event_t ev, int pname, int len, char *param);
        [DllImport("screen")]
        static extern int screen_get_event_property_cv(IntPtr ev, PropertyType pname, int len, [Out] char[] param);

        ///**
        //*   @brief Retrieves the current value of the specified event property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function stores the current value of an event property in a
        //*   user-provided array.
        //*   The list of properties that can be queried per event type are listed as
        //*   follows:
        //*
        //*   Event Type: Any
        //*   - @c SCREEN_PROPERTY_TYPE
        //*   - @c SCREEN_PROPERTY_SCALE_FACTOR
        //*
        //*   Event Type: @c SCREEN_EVENT_DISPLAY
        //*   - @c SCREEN_PROPERTY_ATTACHED
        //*   - @c SCREEN_PROPERTY_MIRROR_MODE
        //*   - @c SCREEN_PROPERTY_MODE
        //*   - @c SCREEN_PROPERTY_PROTECTION_ENABLE
        //*
        //*   Event Type: @c SCREEN_EVENT_EFFECT_COMPLETE
        //*    - @c SCREEN_PROPERTY_EFFECT
        // *
        //*   Event Type: @c SCREEN_EVENT_GAMEPAD
        //*   - @c SCREEN_PROPERTY_BUTTONS
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_POSITION
        //*   - @c SCREEN_PROPERTY_ROTATION
        //*
        //*   Event Type: @c SCREEN_EVENT_IDLE
        //*    - @c SCREEN_PROPERTY_IDLE_STATE
        //*    - @c SCREEN_PROPERTY_OBJECT_TYPE
        //*
        //*   Event Type: @c SCREEN_EVENT_INPUT
        //*    - @c SCREEN_PROPERTY_DEVICE
        //*    - @c SCREEN_PROPERTY_INPUT_VALUE
        //*
        //*   Event Type: @c SCREEN_EVENT_JOG
        //*    - @c SCREEN_PROPERTY_DEVICE
        //*    - @c SCREEN_PROPERTY_JOG_COUNT
        //*
        //*   Event Type: @c SCREEN_EVENT_JOYSTICK
        //*   - @c SCREEN_PROPERTY_BUTTONS
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_POSITION
        //*
        //*   Event Type: @c SCREEN_EVENT_KEYBOARD
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_KEY_CAP
        //*   - @c SCREEN_PROPERTY_KEY_FLAGS
        //*   - @c SCREEN_PROPERTY_KEY_MODIFIERS
        //*   - @c SCREEN_PROPERTY_KEY_SCAN
        //*   - @c SCREEN_PROPERTY_KEY_SYM
        //*   - @c SCREEN_PROPERTY_SEQUENCE_ID
        //*
        //*   Event Types: @c SCREEN_EVENT_MTOUCH_TOUCH, @c SCREEN_EVENT_MTOUCH_MOVE,
        //*                @c SCREEN_EVENT_MTOUCH_RELEASE
        //*   - @c SCREEN_PROPERTY_BUTTONS
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_POSITION
        //*   - @c SCREEN_PROPERTY_SEQUENCE_ID
        //*   - @c SCREEN_PROPERTY_SIZE
        //*   - @c SCREEN_PROPERTY_SOURCE_POSITION
        //*   - @c SCREEN_PROPERTY_SOURCE_SIZE
        //*   - @c SCREEN_PROPERTY_TOUCH_ID
        //*   - @c SCREEN_PROPERTY_TOUCH_ORIENTATION
        //*   - @c SCREEN_PROPERTY_TOUCH_PRESSURE
        //*   - @c SCREEN_PROPERTY_TOUCH_TYPE
        //*
        //*   Event Type: @c SCREEN_EVENT_POINTER
        //*   - @c SCREEN_PROPERTY_BUTTONS
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_MOUSE_HORIZONTAL_WHEEL
        //*   - @c SCREEN_PROPERTY_MOUSE_WHEEL
        //*   - @c SCREEN_PROPERTY_POSITION
        //*   - @c SCREEN_PROPERTY_SOURCE_POSITION
        //*
        //*   Event Type: @c SCREEN_EVENT_PROPERTY
        //*    - @c SCREEN_PROPERTY_NAME
        //*    - @c SCREEN_PROPERTY_OBJECT_TYPE
        //*
        //*   Event Type: @c SCREEN_EVENT_USER
        //*    - @c SCREEN_PROPERTY_USER_DATA
        //*
        //*   @param  ev The handle of the event whose property is being queried. The
        //*           event must have an event type of
        //*           <a href="group__screen__events_1Screen_Event_Types.xml">Screen event types</a>.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type integer.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_event_property_iv(screen_event_t ev, int pname, int *param);
        [DllImport("screen")]
        static extern int screen_get_event_property_iv(IntPtr ev, PropertyType pname, [Out] int[] param);

        ///**
        //*   @brief Retrieves the current value of the specified event property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function stores the current value of an event property in a
        //*   user-provided array.
        //*
        //*   Event Type: Any
        //*    - @c SCREEN_PROPERTY_TIMESTAMP
        //*
        //*   @param  ev The handle of the event whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of long long integer.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_event_property_llv(screen_event_t ev, int pname, long long *param);
        [DllImport("screen")]
        static extern int screen_get_event_property_llv(IntPtr ev, PropertyType pname, [Out] int[] param);

        ///**
        //*   @brief Retrieves the current value of the specified event property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function stores the current value of an event property in a
        //*   user-provided array. The list of properties that can be queried per event
        //*   type are listed as follows:
        //*
        //*   Event Type: @c SCREEN_EVENT_CLOSE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_CREATE
        //*   - @c SCREEN_PROPERTY_WINDOW
        // *
        //*   Event Type: @c SCREEN_EVENT_DISPLAY
        //*   - @c SCREEN_PROPERTY_DISPLAY
        //*
        //*   Event Type: @c SCREEN_EVENT_GAMEPAD
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_IDLE
        //*    - @c SCREEN_PROPERTY_DISPLAY
        //*    - @c SCREEN_PROPERTY_GROUP
        //*
        //*   Event Type: @c SCREEN_EVENT_INPUT
        //*    - @c SCREEN_PROPERTY_DEVICE
        //*
        //*   Event Type: @c SCREEN_EVENT_JOG
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*
        //*   Event Type: @c SCREEN_EVENT_JOYSTICK
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_KEYBOARD
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Types: @c SCREEN_EVENT_MTOUCH_TOUCH, @c SCREEN_EVENT_MTOUCH_MOVE,
        //*                @c SCREEN_EVENT_MTOUCH_RELEASE
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_POINTER
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_POST
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_PROPERTY
        //*   - @c SCREEN_PROPERTY_GROUP
        //*   - @c SCREEN_PROPERTY_DISPLAY
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_UNREALIZE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   @param  ev The handle of the event whose property is being queried. The
        //*           event must have an event type of
        //*           <a href="group__screen__events_1Screen_Event_Types.xml">Screen event types</a>.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type void.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_event_property_pv(screen_event_t ev, int pname, void **param);
        [DllImport("screen")]
        static extern int screen_get_event_property_pv(IntPtr ev, PropertyType pname, [Out] IntPtr[] param);

        ///**
        //*   @brief Sends an input event to the window that has input focus on a
        //*          given display.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   A window manager and an input provider can use this function when they need
        //*   to inject an event in the system. You need to be within a privileged context
        //*   to be able to inject input events. You can create a privileged context by
        //*   calling the function screen_create_context() with a context type of
        //*   @c SCREEN_WINDOW_MANAGER_CONTEXT or @c SCREEN_INPUT_PROVIDER_CONTEXT.
        //*   Prior to calling screen_inject_event(), you must have set all relevant event
        //*   properties to valid values - especially the event type property.
        //*   When using screen_inject_event(), the event will be sent to the window that
        //*   has input focus on the specified display. If you want to send an event to a
        //*   particular window other than the one who has input focus, then use
        //*   screen_send_event().
        //*
        //*   @param  disp The display into which the event will be injected. You can
        //*           obtain a handle to the display by either screen_get_context_property()
        //*           or screen_get_window_property() functions.
        //*   @param  ev An event handle that was created with screen_create_event(). This
        //*           event must contain all the relevant event data pertaining to its type
        //*           when injected into the system.
        //*
        //*   @return @c 0 upon the event being sent to the window that has input focus on
        //*           the display, otherwise @c -1 and @c errno is set
        //*/
        //int screen_inject_event(screen_display_t disp, screen_event_t ev);
        [DllImport("screen")]
        static extern int screen_inject_event(IntPtr disp, IntPtr ev);

        ///**
        //*   @brief Sends an input event to a process.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   A window manager and an input provider can use this function when they need
        //*   to inject an event in the system. You need to be within a privileged context
        //*   to be able to inject input events. You can create a privileged context by
        //*   calling the function screen_create_context() with a context type of
        //*   @c SCREEN_WINDOW_MANAGER_CONTEXT or @c SCREEN_INPUT_PROVIDER_CONTEXT.
        //*   Prior to calling screen_inject_event(), you must have set all relevant event
        //*   properties to valid values - especially the event type property.
        //*   When using screen_inject_event(), the event will be sent to the window that
        //*   has input focus on the specified display. If you want to send an event to a
        //*   particular window other than the one who has input focus, then use
        //*   screen_send_event().
        //*
        //*   @param  ctx A context within the UI Framework that was created with
        //*           screen_create_context().
        //*   @param  ev An event handle that was created with screen_create_event(). This
        //*           event must contain all the relevant event data pertaining to its type
        //*           when injected into the system.
        //*   @param  pid The process the event is to be sent to.
        //*
        //*   @return @c 0 upon the event being sent to the specified process,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_send_event(screen_context_t ctx, screen_event_t ev, pid_t pid);
        [DllImport("screen")]
        static extern int screen_send_event(IntPtr ctx, IntPtr ev, IntPtr pid);

        ///**
        //*   @brief Sets the value of the specified event property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function sets the value of an event property from a user-provided array.
        //*   No more than @c len bytes of the specified type will be written.
        //*   The list of properties that can be set per event type are listed as follows:
        //*
        //*   Event Type: @c SCREEN_EVENT_CREATE
        //*   - @c SCREEN_PROPERTY_GROUP
        //*
        //*   @param  ev The handle of the event whose property is being set.
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
        //int screen_set_event_property_cv(screen_event_t ev, int pname, int len, const char *param);
        [DllImport("screen")]
        static extern int screen_set_event_property_cv(IntPtr ev, PropertyType pname, int len, char[] param);

        ///**
        //*   @brief Sets the value of the specified event property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function sets the value of an event property from a user-provided array.
        //*   The list of properties that can be set per event type are listed as follows:
        //*
        //*   Event Type: Any
        //*   - @c SCREEN_PROPERTY_TYPE
        //*   - @c SCREEN_PROPERTY_SCALE_FACTOR
        //*
        //*   Event Type: @c SCREEN_EVENT_DISPLAY
        //*   - @c SCREEN_PROPERTY_ATTACHED
        //*   - @c SCREEN_PROPERTY_DISPLAY
        //*   - @c SCREEN_PROPERTY_MIRROR_MODE
        //*   - @c SCREEN_PROPERTY_MODE
        //*   - @c SCREEN_PROPERTY_PROTECTION_ENABLE
        //*
        //*   Event Type: @c SCREEN_EVENT_EFFECT_COMPLETE
        //*    - @c SCREEN_PROPERTY_EFFECT
        //*
        //*   Event Type: @c SCREEN_EVENT_GAMEPAD
        //*   - @c SCREEN_PROPERTY_BUTTONS
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_POSITION
        //*   - @c SCREEN_PROPERTY_ROTATION
        //*
        //*   Event Type: @c SCREEN_EVENT_IDLE
        //*    - @c SCREEN_PROPERTY_IDLE_STATE
        //*
        //*   Event Type: @c SCREEN_EVENT_INPUT
        //*    - @c SCREEN_PROPERTY_DEVICE
        //*    - @c SCREEN_PROPERTY_INPUT_VALUE
        //*
        //*   Event Type: @c SCREEN_EVENT_JOG
        //*    - @c SCREEN_PROPERTY_DEVICE
        //*    - @c SCREEN_PROPERTY_JOG_COUNT
        //*
        //*   Event Type: @c SCREEN_EVENT_JOYSTICK
        //*   - @c SCREEN_PROPERTY_BUTTONS
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_POSITION
        //*
        //*   Event Type: @c SCREEN_EVENT_KEYBOARD
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_KEY_CAP
        //*   - @c SCREEN_PROPERTY_KEY_FLAGS
        //*   - @c SCREEN_PROPERTY_KEY_MODIFIERS
        //*   - @c SCREEN_PROPERTY_KEY_SCAN
        //*   - @c SCREEN_PROPERTY_KEY_SYM
        //*   - @c SCREEN_PROPERTY_SEQUENCE_ID
        //*
        //*   Event Types: @c SCREEN_EVENT_MTOUCH_TOUCH, @c SCREEN_EVENT_MTOUCH_MOVE,
        //*                @c SCREEN_EVENT_MTOUCH_RELEASE
        //*   - @c SCREEN_PROPERTY_BUTTONS
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_POSITION
        //*   - @c SCREEN_PROPERTY_SEQUENCE_ID
        //*   - @c SCREEN_PROPERTY_SIZE
        //*   - @c SCREEN_PROPERTY_SOURCE_POSITION
        //*   - @c SCREEN_PROPERTY_SOURCE_SIZE
        //*   - @c SCREEN_PROPERTY_TOUCH_ID
        //*   - @c SCREEN_PROPERTY_TOUCH_ORIENTATION
        //*   - @c SCREEN_PROPERTY_TOUCH_PRESSURE
        //*   - @c SCREEN_PROPERTY_TOUCH_TYPE
        //*
        //*   Event Type: @c SCREEN_EVENT_POINTER
        //*   - @c SCREEN_PROPERTY_BUTTONS
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_MOUSE_HORIZONTAL_WHEEL
        //*   - @c SCREEN_PROPERTY_MOUSE_WHEEL
        //*   - @c SCREEN_PROPERTY_POSITION
        //*   - @c SCREEN_PROPERTY_SOURCE_POSITION
        //*
        //*   Event Type: @c SCREEN_EVENT_PROPERTY
        //*    - @c SCREEN_PROPERTY_NAME
        //*
        //*   Event Type: @c SCREEN_EVENT_USER
        //*    - @c SCREEN_PROPERTY_USER_DATA
        //*
        //*   @param  ev The handle of the event whose property is being set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type integer.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_event_property_iv(screen_event_t ev, int pname, const int *param);
        [DllImport("screen")]
        static extern int screen_set_event_property_iv(IntPtr ev, PropertyType pname, int[] param);

        ///**
        //*   @brief Sets the current value of the specified event property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function sets the value of an event property from a user-provided
        //*   array.
        //*
        //*   Currently, there are no event properties that can be set using this
        //*   function.
        //*
        //*   @param  ev The handle of the event whose property is being set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type long long integer.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_event_property_llv(screen_event_t ev, int pname, const long long *param);
        [DllImport("screen")]
        static extern int screen_set_event_property_llv(IntPtr ev, PropertyType pname, int[] param);

        ///**
        //*   @brief Sets the value of the specified event property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function sets the value of an event property from a user-provided
        //*   array.
        //*   The list of properties that can be set per event type are listed as follows:
        //*
        //*   Event Type: @c SCREEN_EVENT_CREATE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_DISPLAY
        //*   - @c SCREEN_PROPERTY_DISPLAY
        //*
        //*   Event Type: @c SCREEN_EVENT_GAMEPAD
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_IDLE
        //*    - @c SCREEN_PROPERTY_DISPLAY
        //*    - @c SCREEN_PROPERTY_GROUP
        //*
        //*   Event Type: @c SCREEN_EVENT_INPUT
        //*    - @c SCREEN_PROPERTY_DEVICE
        //*
        //*   Event Type: @c SCREEN_EVENT_JOG
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*
        //*   Event Type: @c SCREEN_EVENT_JOYSTICK
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_KEYBOARD
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Types: @c SCREEN_EVENT_MTOUCH_TOUCH, @c SCREEN_EVENT_MTOUCH_MOVE,
        //*                @c SCREEN_EVENT_MTOUCH_RELEASE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_POINTER
        //*   - @c SCREEN_PROPERTY_DEVICE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_POST
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_PROPERTY
        //*   - @c SCREEN_PROPERTY_GROUP
        //*   - @c SCREEN_PROPERTY_DISPLAY
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   Event Type: @c SCREEN_EVENT_UNREALIZE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   @param  ev The handle of the event whose property is being set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type void.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_event_property_pv(screen_event_t ev, int pname, void **param);
        [DllImport("screen")]
        static extern int screen_set_event_property_pv(IntPtr ev, PropertyType pname, IntPtr[] param);
        #endregion
        [DllImport("screen")]
        static extern IntPtr screen_event_get_event(IntPtr bps_event);

        IntPtr _handle;

        public ScreenEvent(IntPtr evenT)
        {
            _handle = evenT;
        }

        public static ScreenEvent FromEventHandle(IntPtr e)
        {
            return new ScreenEvent(screen_event_get_event(e));
        }

        public int X
        {
            get
            {
                var ints = new int[2];
                if (screen_get_event_property_iv(_handle, PropertyType.SCREEN_PROPERTY_POSITION, ints) != 0)
                {
                    throw new Exception("Unable to read X position.");
                }
                return ints[0];
            }
        }

        public int Y
        {
            get
            {
                var ints = new int[2];
                if (screen_get_event_property_iv(_handle, PropertyType.SCREEN_PROPERTY_POSITION, ints) != 0)
                {
                    throw new Exception("Unable to read Y position.");
                }
                return ints[1];
            }
        }

        public EventType Type
        {
            get
            {
                return (EventType)GetIntProperty(PropertyType.SCREEN_PROPERTY_TYPE)[0];
            }
        }

        #region Get-Set Properties
        public int[] GetIntProperty(PropertyType p)
        {
            var result = new int[] { 0 };

            if (screen_get_event_property_iv(_handle, p, result) != 0)
                throw new Exception("Unable to event buffer property " + p);

            return result;
        }

        public void SetIntProperty(PropertyType p, int[] val)
        {
            if (screen_set_event_property_iv(_handle, p, val) != 0)
                throw new Exception("Unable to set event property " + p);
        }

        public char[] GetCharProperty(PropertyType p, int len)
        {
            var result = new char[len];

            if (screen_get_event_property_cv(_handle, p, len, result) != 0)
                throw new Exception("Unable to read event property " + p);

            return result;
        }

        public void SetCharProperty(PropertyType p, char[] val)
        {
            if (screen_set_event_property_cv(_handle, p, val.Length, val) != 0)
                throw new Exception("Unable to set event property " + p);
        }

        public int[] GetLongProperty(PropertyType p)
        {
            var result = new int[] { 0 };

            if (screen_get_event_property_llv(_handle, p, result) != 0)
                throw new Exception("Unable to read event property " + p);

            return result;
        }

        public void SetLongProperty(PropertyType p, int[] val)
        {
            if (screen_set_event_property_llv(_handle, p, val) != 0)
                throw new Exception("Unable to set event property " + p);
        }

        public void GetVoidProperty(PropertyType p, ref IntPtr[] val)
        {
            if (screen_get_event_property_pv(_handle, p, val) != 0)
                throw new Exception("Unable to read event property " + p);
        }

        public void SetVoidProperty(PropertyType p, IntPtr[] val)
        {
            if (screen_set_event_property_pv(_handle, p, val) != 0)
                throw new Exception("Unable to set event property " + p);
        }
        #endregion
    }
}

