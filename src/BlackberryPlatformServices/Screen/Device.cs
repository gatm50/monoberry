﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace BlackberryPlatformServices.Screen
{
    public class Device
    {
        #region DllImport
        ///**
        //*   @brief Creates a device of specified type to be associated with a context
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   The screen_create_device_type() function creates a input device object to
        //*   be associated with a context. Note that you need to be within a privileged
        //*   context to call this function.
        //*   The following are valid input devices which can be created:
        //*   - @c SCREEN_EVENT_KEYBOARD
        //*   - @c SCREEN_EVENT_POINTER
        //*   - @c SCREEN_EVENT_JOYSTICK
        //*   - @c SCREEN_EVENT_GAMEPAD
        //*   - @c SCREEN_EVENT_MTOUCH_TOUCH
        //*   Applications should use screen_destroy_device() when a device is no longer
        //*   used.
        //*
        //*
        //*   @param  pdev A pointer to a @c screen_device_t where a handle for the new
        //*           input device can be stored.
        //*   @param  ctx The handle of the context in which the input device is to be
        //*           created. This context must have been created with the context type
        //*           of @c SCREEN_INPUT_PROVIDER_CONTEXT using screen_create_context().
        //*   @param  type The type of input device to be created.
        //*
        //*   @return @c 0 upon the input device being created,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_create_device_type(screen_device_t *pdev, screen_context_t ctx, int type);
        [DllImport("screen")]
        static extern int screen_create_device_type(out IntPtr pdev, IntPtr ctx, EventType type);

        ///**
        //*   @brief Destroys a input device and frees associated resources
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function destroys the a input device object associated with the device
        //*   handle. Any resources created for this input device will be released.
        //*   Input devices created with screen_create_device_type() should be destroyed
        //*   with this function.
        //*
        //*   This function is of type flushing execution because should there be any entries
        //*   in the command buffer that have reference to this device, the entries will be
        //*   flushed and processed before destroying the device.
        //*
        //*   @param  dev The handle of the input device that you want to destroy.
        //*
        //*   @return @c 0 upon the input device being destroyed,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_destroy_device(screen_device_t dev);
        [DllImport("screen")]
        static extern int screen_destroy_device(IntPtr dev);

        ///**
        //*   @brief Retrieves the current value of the specified device property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of a device property in a
        //*   user-provided array. No more than @c len bytes of the specified type will be
        //*   written.
        //*
        //*   The values of the following properties can be retrieved using this function:
        //*   - @c SCREEN_PROPERTY_KEYMAP
        //*   - @c SCREEN_PROPERTY_ID_STRING
        //*   - @c SCREEN_PROPERTY_VENDOR
        //*   - @c SCREEN_PROPERTY_PRODUCT
        //*
        //*   @param  dev The handle of the device whose property is being queried.
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
        //int screen_get_device_property_cv(screen_device_t dev, int pname, int len, char *param);
        [DllImport("screen")]
        static extern int screen_get_device_property_cv(IntPtr dev, PropertyType pname, int len, [Out] char[] param);

        ///**
        //*   @brief Retrieves the current value of the specified device property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of a device property in a
        //*   user-provided array.
        //*
        //*   The values of the following properties can be retrieved using this function:
        //*   - @c SCREEN_PROPERTY_POWER_MODE
        //*   - @c SCREEN_PROPERTY_TYPE
        //*   - @c SCREEN_PROPERTY_METRIC_COUNT
        //*   - @c SCREEN_PROPERTY_BUTTON_COUNT
        //*
        //*   @param  dev The handle of the device whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type integer.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_device_property_iv(screen_device_t dev, int pname, int *param);
        [DllImport("screen")]
        static extern int screen_get_device_property_iv(IntPtr dev, PropertyType pname, [Out] int[] param);

        ///**
        //*   @brief Retrieves the current value of the specified device property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of a device property in a
        //*   user-provided array.
        //*   The values of the following properties can be queried using this function:
        //*    - @c SCREEN_PROPERTY_METRICS
        //*
        //*   @param  dev The handle of the device whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type long long integer.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_device_property_llv(screen_device_t dev, int pname, long long *param);
        [DllImport("screen")]
        static extern int screen_get_device_property_llv(IntPtr dev, PropertyType pname, [Out] int[] param);

        ///**
        //*   @brief Retrieves the current value of the specified device property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
        //*
        //*   This function stores the current value of a device property in a
        //*   user-provided array.
        //*
        //*   The values of the following properties can be retrieved using this function:
        //*   - @c SCREEN_PROPERTY_CONTEXT
        //*   - @c SCREEN_PROPERTY_DISPLAY
        //*   - @c SCREEN_PROPERTY_USER_HANDLE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   @param  dev The handle of the device whose property is being queried.
        //*   @param  pname The name of the property whose value is being queried. The
        //*           properties available for query are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param The buffer where the retrieved values will be stored. This
        //*           buffer should be of type void.
        //*
        //*   @return @c 0 upon a successful query and the value(s) of the property are
        //*           stored in @c param, otherwise @c -1 and @c errno is set
        //*/
        //int screen_get_device_property_pv(screen_device_t dev, int pname, void **param);
        [DllImport("screen")]
        static extern int screen_get_device_property_pv(IntPtr dev, PropertyType pname, [Out] IntPtr[] param);

        ///**
        //*   @brief Sets the value of the specified device property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a device property from a user-provided array.
        //*   No more than @c len bytes will be read from @c param.
        //*
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_KEYMAP
        //*   - @c SCREEN_PROPERTY_ID_STRING
        //*
        //*   @param  dev The handle of the device whose property is to be set.
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
        //int screen_set_device_property_cv(screen_device_t dev, int pname, int len, const char *param);
        [DllImport("screen")]
        static extern int screen_set_device_property_cv(IntPtr dev, PropertyType pname, int len, char[] param);

        ///**
        //*   @brief Sets the value of the specified device property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a device property from a user-provided array.
        //*
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_POWER_MODE
        //*   - @c SCREEN_PROPERTY_BUTTON_COUNT
        //*
        //*   @param  dev The handle of the device whose property is to be set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s).  This
        //*           buffer should be of type integer.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_device_property_iv(screen_device_t dev, int pname, const int *param);
        [DllImport("screen")]
        static extern int screen_set_device_property_iv(IntPtr dev, PropertyType pname, int[] param);

        ///**
        //*   @brief Sets the value of the specified device property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a device property from a user-provided array.
        //*
        //*   Currently there are no device properties which can be set using
        //*   this function.
        //*
        //*   @param  dev The handle of the device whose property is to be set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s).  This
        //*           buffer should be of type long long integer.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_device_property_llv(screen_device_t dev, int pname, const long long *param);
        [DllImport("screen")]
        static extern int screen_set_device_property_llv(IntPtr dev, PropertyType pname, int[] param);

        ///**
        //*   @brief Sets the value of the specified device property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a device property from a user-provided array.
        //*
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_PROPERTY_DISPLAY
        //*   - @c SCREEN_PROPERTY_USER_HANDLE
        //*   - @c SCREEN_PROPERTY_WINDOW
        //*
        //*   @param  dev The handle of the device whose property is to be set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type
        //*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
        //*   @param  param A pointer to a buffer containing the new value(s).  This
        //*           buffer should be of type void.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_device_property_pv(screen_device_t dev, int pname, void **param);
        [DllImport("screen")]
        static extern int screen_set_device_property_pv(IntPtr dev, PropertyType pname, IntPtr[] param);
        #endregion

        private IntPtr _handle;
        public IntPtr Handle
        {
            get { return _handle; }
        }
        private Context _ctx;

        public Device(Context ctx, EventType type)
        {
            _ctx = ctx;
            if(screen_create_device_type(out _handle, ctx.Handle, type)!=0)
                throw new Exception("Unable to create device!!");
        }

        public Device(Context ctx, IntPtr dev)
        {
            _ctx = ctx;
            _handle = dev;
        }

        public void Dispose()
        {
            screen_destroy_device(_handle);
        }

        #region Get-Set Properties
        public int[] GetIntProperty(PropertyType p)
        {
            var result = new int[] { 0 };

            if (screen_get_device_property_iv(_handle, p, result) != 0)
                throw new Exception("Unable to read device property " + p);

            return result;
        }

        public void SetIntProperty(PropertyType p, int[] val)
        {
            if (screen_set_device_property_iv(_handle, p, val) != 0)
                throw new Exception("Unable to set device property " + p);
        }

        public char[] GetCharProperty(PropertyType p, int len)
        {
            var result = new char[len];

            if (screen_get_device_property_cv(_handle, p, len, result) != 0)
                throw new Exception("Unable to read device property " + p);

            return result;
        }

        public void SetCharProperty(PropertyType p, char[] val)
        {
            if (screen_set_device_property_cv(_handle, p, val.Length, val) != 0)
                throw new Exception("Unable to set device property " + p);
        }

        public int[] GetLongProperty(PropertyType p)
        {
            var result = new int[] { 0 };

            if (screen_get_device_property_llv(_handle, p, result) != 0)
                throw new Exception("Unable to read device property " + p);

            return result;
        }

        public void SetLongProperty(PropertyType p, int[] val)
        {
            if (screen_set_device_property_llv(_handle, p, val) != 0)
                throw new Exception("Unable to set device property " + p);
        }

        public void GetVoidProperty(PropertyType p, ref IntPtr[] val)
        {
            if (screen_get_device_property_pv(_handle, p, val) != 0)
                throw new Exception("Unable to read device property " + p);
        }

        public void SetVoidProperty(PropertyType p, IntPtr[] val)
        {
            if (screen_set_device_property_pv(_handle, p, val) != 0)
                throw new Exception("Unable to set device property " + p);
        }
        #endregion
    }
}