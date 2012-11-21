using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace BlackberryPlatformServices.Screen
{
    public class ScreenGroup
    {
        #region DllImport
        ///**
        //*   @brief Creates a window group. You can use groups in order to organize
        //*   application windows.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function creates a window group given a group object and a context. The
        //*   context is shared by all windows in this group.
        //*
        //*   @param  pgrp The handle of the group.
        //*   @param  ctx The connection to the composition manager. This context should
        //*           have been created with screen_create_context().
        //*
        //*   @return @c 0 upon the creation of a new window group,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_create_group(screen_group_t *pgrp, screen_context_t ctx);
        [DllImport("screen")]
        static extern int screen_create_group(out IntPtr pgrp, IntPtr ctx);

        ///**
        //*   @brief Destroys a window group.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function destroys a window group given a screen_group_t instance. When
        //*   a window group is destroyed, all windows that belonged to the group are no
        //*   longer associated with the group. You should destroy each screen_group_t
        //*   after it is no longer needed.
        //*
        //*   @param  grp The window group to be destroyed. The group must have been
        //*           created with screen_create_group().
        //*
        //*   @return @c 0 upon the window group being destroyed,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_destroy_group(screen_group_t grp);
        [DllImport("screen")]
        static extern int screen_destroy_group(IntPtr pgrp);

        ///**
        //*   @brief Retrieves the current value of the specified group property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of group property in a
        //*   user-provided array. No more than @c len bytes of the specified type will be
        //*   written.
        //*
        //*   The values of the following properties can be retrieved using this function:
        //*   - @c SCREEN_PROPERTY_NAME
        //*
        //*   @param  grp The handle of the group whose property is being queried.
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
        //int screen_get_group_property_cv(screen_group_t grp, int pname, int len, char *param);
        [DllImport("screen")]
        static extern int screen_get_group_property_cv(IntPtr grp, PropertyType pname, int len, [Out] char[] param);

        ///**
        //*   @brief Retrieves the current value of the specified group property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of group property in a
        //*   user-provided array.
        //*
        //*   The values of the following properties can be retrieved using this function:
        //*
        //*   - @c SCREEN_PROPERTY_BUFFER_POOL
        //*   - @c SCREEN_PROPERTY_IDLE_STATE
        //*
        //*   @param  grp The handle of the group whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type integer.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_group_property_iv(screen_group_t grp, int pname, int *param);
        [DllImport("screen")]
        static extern int screen_get_group_property_iv(IntPtr grp, PropertyType pname, [Out] int[] param);

        ///**
        //*   @brief Retrieves the current value of the specified group property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of group property in a
        //*   user-provided array.
        //*
        //*   The values of the following properties can be retrieved using this function:
        //*   - @c SCREEN_PROPERTY_IDLE_TIMEOUT
        //*
        //*   @param  grp The handle of the group whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type long long integer.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_group_property_llv(screen_group_t grp, int pname, long long *param);
        [DllImport("screen")]
        static extern int screen_get_group_property_llv(IntPtr grp, PropertyType pname, [Out] int[] param);

        ///**
        //*   @brief Retrieves the current value of the specified group property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of group property in a
        //*   user-provided array.
        //*
        //*   The values of the following properties can be retrieved using this function:
        //*   - @c SCREEN_PROPERTY_CONTEXT
        //*   - @c SCREEN_PROPERTY_KEYBOARD_FOCUS
        //*   - @c SCREEN_PROPERTY_MTOUCH_FOCUS
        //*   - @c SCREEN_PROPERTY_POINTER_FOCUS
        //*   - @c SCREEN_PROPERTY_USER_HANDLE
        //*
        //*   @param  grp The handle of the group whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type void.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_group_property_pv(screen_group_t grp, int pname, void **param);
        [DllImport("screen")]
        static extern int screen_get_group_property_pv(IntPtr grp, PropertyType pname, [Out] IntPtr[] param);

        ///**
        //*   @brief Sets the value of the specified group property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a group property from a user-provided array.
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_NAME
        //*
        //*   @param  grp The handle of the group whose property is being set.
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
        //int screen_set_group_property_cv(screen_group_t grp, int pname, int len, const char *param);
        [DllImport("screen")]
        static extern int screen_set_group_property_cv(IntPtr grp, PropertyType pname, int len, char[] param);

        ///**
        //*   @brief Sets the value of the specified group property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a group property from a user-provided array.
        //*   The values of the following properties can be set using this function:
        //*
        //*   - @c SCREEN_PROPERTY_BUFFER_POOL
        //*
        //*   @param  grp The handle of the group whose property is being set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type integer.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_group_property_iv(screen_group_t grp, int pname, const int *param);
        [DllImport("screen")]
        static extern int screen_set_group_property_iv(IntPtr grp, PropertyType pname, int[] param);

        ///**
        //*   @brief Sets the value of the specified group property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a group property from a user-provided array.
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_IDLE_TIMEOUT
        //*
        //*   @param  grp The handle of the group whose property is being set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*            <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type long long integer.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_group_property_llv(screen_group_t grp, int pname, const long long *param);
        [DllImport("screen")]
        static extern int screen_set_group_property_llv(IntPtr grp, PropertyType pname, int[] param);

        ///**
        //*   @brief Sets the value of the specified group property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a group property from a user-provided array.
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_KEYBOARD_FOCUS
        //*   - @c SCREEN_PROPERTY_MTOUCH_FOCUS
        //*   - @c SCREEN_PROPERTY_POINTER_FOCUS
        //*   - @c SCREEN_PROPERTY_USER_HANDLE
        //*
        //*   @param  grp The handle of the group whose property is being set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s). This
        //*           buffer should be of type void.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_group_property_pv(screen_group_t grp, int pname, void **param);
        [DllImport("screen")]
        static extern int screen_set_group_property_pv(IntPtr grp, PropertyType pname, IntPtr[] param);
        #endregion

        private IntPtr _handle;
        internal IntPtr Handle
        {
            get { return _handle; }
        }

        Context _context;

        public ScreenGroup(Context ctx, IntPtr buf)
        {
            _context = ctx;
            _handle = buf;
        }

        public ScreenGroup(Context ctx)
        {
            _context = ctx;
            if (screen_create_group(out _handle, _context.Handle) != 0)
                throw new Exception("Unable to create group!!");
        }

        public void Dispose()
        {
            if (screen_destroy_group(_handle) != 0)
                throw new Exception("Unable to dispose group!!");
        }

        #region Get-Set Properties
        public int[] GetIntProperty(PropertyType p)
        {
            var result = new int[] { 0 };

            if (screen_get_group_property_iv(_handle, p, result) != 0)
                throw new Exception("Unable to read group property " + p);

            return result;
        }

        public void SetIntProperty(PropertyType p, int[] val)
        {
            if (screen_set_group_property_iv(_handle, p, val) != 0)
                throw new Exception("Unable to set group property " + p);
        }

        public char[] GetCharProperty(PropertyType p, int len)
        {
            var result = new char[len];

            if (screen_get_group_property_cv(_handle, p, len, result) != 0)
                throw new Exception("Unable to read group property " + p);

            return result;
        }

        public void SetCharProperty(PropertyType p, char[] val)
        {
            if (screen_set_group_property_cv(_handle, p, val.Length, val) != 0)
                throw new Exception("Unable to set group property " + p);
        }

        public int[] GetLongProperty(PropertyType p)
        {
            var result = new int[] { 0 };

            if (screen_get_group_property_llv(_handle, p, result) != 0)
                throw new Exception("Unable to read group property " + p);

            return result;
        }

        public void SetLongProperty(PropertyType p, int[] val)
        {
            if (screen_set_group_property_llv(_handle, p, val) != 0)
                throw new Exception("Unable to set group property " + p);
        }

        public void GetVoidProperty(PropertyType p, ref IntPtr[] val)
        {
            if (screen_get_group_property_pv(_handle, p, val) != 0)
                throw new Exception("Unable to read group property " + p);
        }

        public void SetVoidProperty(PropertyType p, IntPtr[] val)
        {
            if (screen_set_group_property_pv(_handle, p, val) != 0)
                throw new Exception("Unable to set group property " + p);
        }
        #endregion
    }
}
