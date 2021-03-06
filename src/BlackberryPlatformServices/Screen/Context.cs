using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace BlackberryPlatformServices.Screen
{
    public class Context : IDisposable
    {
        #region DllImport
        ///**
        //*   @brief Establishes a connection with the composited windowing system
        //*
        //*   <b>Function type:</b> <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   The @c screen_create_context() function tries to establish communication
        //*   with the composited windowing system resource manager (UI Framework).
        //*   To do this, the function opens /dev/screen and sends the proper connect
        //*   sequence. If the call succeeds, memory is allocated to store context state.
        //*   The composition manager then creates an event queue and associates it with
        //*   the connecting process.
        //*
        //*   @param  pctx A pointer to a @c screen_context_t where a handle for the new
        //*           context can be stored.
        //*   @param  flags The type of context to be created. The value must
        //*           be of type Screen_Context_Types.
        //*
        //*   @return @c 0 upon the context being created,
        //*               otherwise @c -1 and @c errno is set
        //*/
        //int screen_create_context(screen_context_t *pctx, int flags);
        [DllImport("screen")]
        static extern int screen_create_context(out IntPtr pctx, ContextType flags);

        ///**
        //*   @brief Terminates a connection with the composited windowing system
        //*
        //*   <b>Function type:</b> <a href="manual/rscreen_apply_execution.xml">Apply Execution</a>
        //*
        //*   This function closes an existing connection with the composited windowing
        //*   system resource manager. If the call succeeds, the context is freed and can
        //*   no longer be used. All windows and pixmaps associated with this connection
        //*   will be destroyed. All events waiting in the event queue will be discarded.
        //*   This operation does not flush the command buffer. Any pending asynchronous
        //*   command is discarded.
        //*
        //*   @param  ctx The connection to the composition manager that is to be
        //*           terminated. This context should have been created with
        //*           screen_create_context().
        //*
        //*   @return @c 0 upon the context being destroyed,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_destroy_context(screen_context_t ctx);
        [DllImport("screen")]
        static extern int screen_destroy_context(IntPtr ctx);

        ///**
        //*   @brief Flushes a context, given a context and a set of flags.
        //*
        //*   <b>Function type:</b>	 <a href="manual/rscreen_apply_execution.xml">Apply Execution</a>
        //*
        //*   This function flushes any delayed command and causes the contents of
        //*   displays to be updated, when applicable. If @c SCREEN_WAIT_IDLE is specified,
        //*   the function will not return until the contents of all affected displays
        //*   have been updated. Passing no flags causes the function to return
        //*   immediately.
        //*
        //*   If debugging, you can call this function after all delayed function calls
        //*   as a way to determine the exact function call which may have caused an error.
        //*
        //*   @param  ctx The connection to the composition manager that is to be
        //*           flushed. This context should have been created with
        //*           screen_create_context().
        //*   @param  flags The flag to indicate whether or not to wait until contents
        //*           of all displays have been updated or to execute immediately.
        //*
        //*   @return @c 0 upon the context being flushed,
        //*           otherwise @c -1 and @c errno is set; The error could have been caused
        //*           by any delayed function that just got flushed.
        //*/
        //int screen_flush_context(screen_context_t ctx, int flags);
        [DllImport("screen")]
        static extern int screen_flush_context(IntPtr ctx, FlushingType flags);

        ///**
        //*   @brief Retrieves the current value of the specified context property.
        //*
        //*   <b>Function Type:</b> <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of a context property in a
        //*   user-provided array. No more than @c len bytes of the specified type will be
        //*   written.
        //*
        //*   The values of the following properties can be retrieved using this function:
        //*   - @c SCREEN_PROPERTY_KEYMAP
        //*
        //*   @param  ctx The handle of the context whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type
        //*            <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  len The maximum number of bytes that can be written to @c param
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type char with a maximum length of @c len.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_context_property_cv(screen_context_t ctx, int pname, int len, char *param);
        [DllImport("screen")]
        static extern int screen_get_context_property_cv(IntPtr ctx, PropertyType property, int len, [Out] char[] param);

        ///**
        //*   @brief Retrieves the current value of the specified context property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of a context property in a
        //*   user-provided array.
        //*
        //*   The values of the following properties can be retrieved using this function:
        //*   - @c SCREEN_PROPERTY_DEVICE_COUNT
        //*   - @c SCREEN_PROPERTY_DISPLAY_COUNT
        //*   - @c SCREEN_PROPERTY_GROUP_COUNT
        //*   - @c SCREEN_PROPERTY_IDLE_STATE
        //*   - @c SCREEN_PROPERTY_PIXMAP_COUNT
        //*   - @c SCREEN_PROPERTY_WINDOW_COUNT
        //*
        //*   @param  ctx The handle of the context whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type
        //*            <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type integer.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_context_property_iv(screen_context_t ctx, int pname, int *param);
        [DllImport("screen")]
        static extern int screen_get_context_property_iv(IntPtr ctx, PropertyType property, [Out] int[] param);

        ///**
        //*   @brief Retrieves the current value of the specified context property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of a context property in a
        //*   user-provided array.
        //*
        //*   The values of the following properties can be retrieved using this function:
        //*   - @c SCREEN_PROPERTY_IDLE_TIMEOUT
        //*
        //*   @param  ctx The handle of the context whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type
        //*            <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type long long integer.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_context_property_llv(screen_context_t ctx, int pname, long long *param);
        [DllImport("screen")]
        static extern int screen_get_context_property_llv(IntPtr ctx, PropertyType property, [Out] int[] param);

        ///**
        //*   @brief Retrieves the current value of the specified context property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of a context property in a
        //*   user-provided array.
        //*
        //*   The values of the following properties can be retrieved using this function:
        //*   - @c SCREEN_PROPERTY_DEVICES
        //*   - @c SCREEN_PROPERTY_DISPLAYS
        //*   - @c SCREEN_PROPERTY_GROUPS
        //*   - @c SCREEN_PROPERTY_KEYBOARD_FOCUS
        //*   - @c SCREEN_PROPERTY_MTOUCH_FOCUS
        //*   - @c SCREEN_PROPERTY_POINTER_FOCUS
        //*   - @c SCREEN_PROPERTY_PIXMAPS
        //*   - @c SCREEN_PROPERTY_WINDOWS
        //*
        //*   @param  ctx The handle of the context whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type void.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_context_property_pv(screen_context_t ctx, int pname, void **param);
        [DllImport("screen")]
        static extern int screen_get_context_property_pv(IntPtr ctx, PropertyType property, [Out] IntPtr[] param);

        ///**
        //*   @brief Sets the value of the specified context property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a context property from a user-provided array.
        //*   No more than @c len bytes will be read from @c param.
        //*
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_KEYMAP
        //*
        //*   @param  ctx The handle of the context whose property is to be set.
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
        //int screen_set_context_property_cv(screen_context_t ctx, int pname, int len, const char *param);
        [DllImport("screen")]
        static extern int screen_set_context_property_cv(IntPtr ctx, PropertyType pname, int len, char[] param);

        ///**
        //*   @brief Sets the value of the specified context property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a context property from a user-provided array.
        //*
        //*   Currently, there are no context properties which can be set using this
        //*   function.
        //*
        //*   @param  ctx The handle of the context whose property is to be set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s).  This
        //*           buffer should be of type integer.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_context_property_iv(screen_context_t ctx, int pname, const int *param);
        [DllImport("screen")]
        static extern int screen_set_context_property_iv(IntPtr ctx, PropertyType pname, int[] param);

        ///**
        //*   @brief Sets the value of the specified context property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a context property from a user-provided array.
        //*
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_IDLE_TIMEOUT
        //*
        //*   @param  ctx The handle of the context whose property is to be set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s).  This
        //*           buffer should be of type long long integer.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_context_property_llv(screen_context_t ctx, int pname, const long long *param);
        [DllImport("screen")]
        static extern int screen_set_context_property_llv(IntPtr ctx, PropertyType pname, int[] param);

        ///**
        //*   @brief Sets the value of the specified context property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a context property from a user-provided array.
        //*
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_KEYBOARD_FOCUS
        //*   - @c SCREEN_PROPERTY_MTOUCH_FOCUS
        //*   - @c SCREEN_PROPERTY_POINTER_FOCUS
        //*
        //*   @param  ctx The handle of the context whose property is to be set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s).  This
        //*           buffer should be of type void.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_context_property_pv(screen_context_t ctx, int pname, void **param);
        [DllImport("screen")]
        static extern int screen_set_context_property_pv(IntPtr ctx, PropertyType pname, IntPtr[] param);

        //[DllImport("screen")]
        //static extern int screen_get_domain();
        #endregion

        IntPtr _handle;
        public IntPtr Handle { get { return _handle; } }
        int _eventDomain;
        bool _disposed = false;
        ContextType _type;

        public Action<ScreenEvent> OnCloseWindow { get; set; }
        public Action<ScreenEvent> OnCreateWindow { get; set; }
        public Action<int, int> OnFingerTouch { get; set; }
        public Action<int, int> OnFingerMove { get; set; }
        public Action<int, int> OnFingerRelease { get; set; }

        private static IDictionary<ContextType, Context> _instances = new Dictionary<ContextType, Context>();
        IDictionary<IntPtr, Window> _windows = new Dictionary<IntPtr, Window>();

        public static Context GetInstance(ContextType type)
        {
            lock (typeof(Context))
            {
                Context ctx;
                if (!_instances.TryGetValue(type, out ctx))
                {
                    ctx = new Context(type);
                    _instances.Add(type, ctx);
                }
                return ctx;
            }
        }

        static void RemoveInstance(ContextType type)
        {
            lock (typeof(Context))
            {
                if (_instances.ContainsKey(type))
                {
                    _instances.Remove(type);
                }
            }
        }

        public Context(ContextType type)
        {
            _type = type;
            if (screen_create_context(out _handle, type) != 0)
            {
                // TODO: read errno to describe problem
                throw new Exception("Unable to create screen context");
            }
            PlatformServices.Initialize();
            Screen.RequestEvent(this);

            _eventDomain = Screen.GetDomain();
            PlatformServices.AddEventHandler(_eventDomain, HandleEvent);
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            PlatformServices.RemoveEventHandler(_eventDomain);
            Screen.StopEventFromContext(this);
            screen_destroy_context(_handle);
            RemoveInstance(_type);

            _disposed = true;
        }

        internal void RegisterWindow(Window win)
        {
            _windows.Add(win.Handle, win);
        }

        internal void UnregisterWindow(Window win)
        {
            _windows.Remove(win.Handle);
        }

        bool HandleWindowEvent(ScreenEvent ev)
        {
            IntPtr handle = IntPtr.Zero; ;
            var res=new IntPtr[] { handle };
            ev.GetVoidProperty(PropertyType.SCREEN_PROPERTY_WINDOW, ref res);
            handle = res[0];

            if (!_windows.ContainsKey(handle))
            {
                return false;
            }
            _windows[handle].HandleEvent(ev);
            return true;
        }

        void HandleEvent(IntPtr eventHandle)
        {
            var e = ScreenEvent.FromEventHandle(eventHandle);

            if (e.Type == EventType.SCREEN_EVENT_CLOSE ||
                e.Type == EventType.SCREEN_EVENT_CREATE)
            {
                if (HandleWindowEvent(e))
                {
                    return;
                }
            }

            switch (e.Type)
            {
                case EventType.SCREEN_EVENT_CLOSE:
                    if (OnCloseWindow != null)
                    {
                        OnCloseWindow(e);
                    }
                    break;
                case EventType.SCREEN_EVENT_CREATE:
                    if (OnCreateWindow != null)
                    {
                        OnCreateWindow(e);
                    }
                    break;
                case EventType.SCREEN_EVENT_MTOUCH_TOUCH:
                    if (OnFingerTouch != null)
                    {
                        OnFingerTouch(e.X, e.Y);
                    }
                    break;
                case EventType.SCREEN_EVENT_MTOUCH_MOVE:
                    if (OnFingerMove != null)
                    {
                        OnFingerMove(e.X, e.Y);
                    }
                    break;
                case EventType.SCREEN_EVENT_MTOUCH_RELEASE:
                    if (OnFingerRelease != null)
                    {
                        OnFingerRelease(e.X, e.Y);
                    }
                    break;
                default:
                    Console.WriteLine("UNHANDLED SCREEN EVENT, TYPE: {0}", e.Type);
                    if (e.Type == EventType.SCREEN_EVENT_PROPERTY)
                    {
                        Console.WriteLine(" - Name: {0}", (PropertyType)e.GetIntProperty(PropertyType.SCREEN_PROPERTY_NAME)[0]);
                    }
                    break;
            }

        }

        public void Flush()
        {
            if (screen_flush_context(_handle, 0) != 0)
            {
                throw new Exception("Unable to flush context");
            }
        }

        public List<Display> Displays
        {
            get
            {
                int count;
                var res = GetIntProperty(PropertyType.SCREEN_PROPERTY_DISPLAY_COUNT);

                if (res.Length > 0)
                    throw new Exception("The screen does not contains displays");

                count = res[0];
                var handles = new IntPtr[count];
                screen_get_context_property_pv(_handle, PropertyType.SCREEN_PROPERTY_DISPLAYS, handles);
                var displays = new List<Display>();

                foreach (var i in handles)
                    displays.Add(new Display(i));

                return displays;
            }
        }

        #region Get-Set Properties
        public int[] GetIntProperty(PropertyType p)
        {
            var result = new int[] { 0 };

            if (screen_get_context_property_iv(_handle, p, result) != 0)
                throw new Exception("Unable to read context property " + p);

            return result;
        }

        public void SetIntProperty(PropertyType p, int[] val)
        {
            if (screen_set_context_property_iv(_handle, p, val) != 0)
                throw new Exception("Unable to set context property " + p);
        }

        public char[] GetCharProperty(PropertyType p, int len)
        {
            var result = new char[len];

            if (screen_get_context_property_cv(_handle, p, len, result) != 0)
                throw new Exception("Unable to read context property " + p);

            return result;
        }

        public void SetCharProperty(PropertyType p, char[] val)
        {
            if (screen_set_context_property_cv(_handle, p, val.Length, val) != 0)
                throw new Exception("Unable to set context property " + p);
        }

        public int[] GetLongProperty(PropertyType p)
        {
            var result = new int[] { 0 };

            if (screen_get_context_property_llv(_handle, p, result) != 0)
                throw new Exception("Unable to read context property " + p);

            return result;
        }

        public void SetLongProperty(PropertyType p, int[] val)
        {
            if (screen_set_context_property_llv(_handle, p, val) != 0)
                throw new Exception("Unable to set context property " + p);
        }

        public void GetVoidProperty(PropertyType p, ref IntPtr[] val)
        {
            if (screen_get_context_property_pv(_handle, p, val) != 0)
                throw new Exception("Unable to read context property " + p);
        }

        public void SetVoidProperty(PropertyType p, IntPtr[] val)
        {
            if (screen_set_context_property_pv(_handle, p, val) != 0)
                throw new Exception("Unable to set context property " + p);
        }
        #endregion
    }
}
