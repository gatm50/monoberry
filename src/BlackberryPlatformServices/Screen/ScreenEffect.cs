using System;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace BlackberryPlatformServices.Screen
{
    public class ScreenEffect
    {
        public enum EffectType
        {
            SCREEN_NO_EFFECT = 0,    /**< No Effect */
            SCREEN_FLIP_EFFECT = 1,    /**< Flip Effect */
            SCREEN_ROTATE_EFFECT = 2,    /**< Rotate Effect */
            SCREEN_PAGE_CURL_EFFECT = 3,    /**< Curl Effect */
            SCREEN_REVEAL_EFFECT = 4,    /**< Reveal Effect */
        };

        #region DllImport
        //*   @brief Prepares the specified window for an effect.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_apply_execution.xml">Apply Execution</a>
        //*
        //*   This function .
        //*
        //*   @param  win The window that is to be prepared for an effect.
        //*   @param  effect The effect to be prepared on the window.
        //*
        //*   @return @c 0 upon a successful preparation of the effect,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_prepare_effect(screen_window_t win, int effect);
        [DllImport("screen")]
        static extern int screen_prepare_effect(IntPtr win, EffectType effect);

        ///**
        //*   @brief Sets the value of the specified effect property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a effect property from a user-provided array.
        //*
        //*   The values of the following properties can be set using this function:
        //*   - @c SCREEN_FLIP_AXIS
        //*   - @c SCREEN_FLIP_DIRECTION
        //*   - @c SCREEN_ROTATE_DIRECTION
        //*   - @c SCREEN_PAGE_CURL_ORIGIN
        //*   - @c SCREEN_PAGE_CURL_POSITION
        //*   - @c SCREEN_REVEAL_ORIGIN
        //*   - @c SCREEN_REVEAL_POSITION
        //*
        //*   @param  win The handle of the window whose effect property is to be set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type Screen_Effect_Property_Types.
        //*   @param  param A pointer to a buffer containing the new value(s).  This
        //*           buffer should be of type integer.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_effect_property_iv(screen_window_t win, int pname, const int *param);
        [DllImport("screen")]
        static extern int screen_set_effect_property_iv(IntPtr win, PropertyType pname, int[] param);

        ///**
        //*   @brief Sets the value of the specified effect property.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function sets the value of a effect property from a user-provided array.
        //*
        //*   Currently there are no effect properties that can be set using this
        //*   function.
        //*
        //*   @param  win The handle of the window whose effect property is to be set.
        //*   @param  pname The name of the property whose value is being set. The
        //*           properties available for setting are of type Screen_Effect_Property_Types.
        //*   @param  param A pointer to a buffer containing the new value(s).  This
        //*           buffer should be of type float.
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_set_effect_property_fv(screen_window_t win, int pname, const float *param);
        [DllImport("screen")]
        static extern int screen_set_effect_property_fv(IntPtr win, PropertyType pname, float[] param);

        ///**
        //*   @brief Starts the effect on the specified window.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function starts the effect on a window for a specified duration.
        //*
        //*   @param  win The handle of the window whose effect property is to be started.
        //*   @param  duration The duration that the effect will be in place.
        //*   @param  notify A flag to indicate whether or not a
        //*           @c SCREEN_EVENT_EFFECT_COMPLETE event is to be sent upon completion
        //*           of screen_start_effect(). @c 1 indicates that a
        //*           @c SCREEN_EVENT_EFFECT_COMPLETE is to be sent and @c 0 indicates
        //*           that no event is sent upon completion of screen_start_effect().
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_start_effect(screen_window_t win, float duration, int notify);
        [DllImport("screen")]
        static extern int screen_start_effect(IntPtr win, float duration, int notify);

        ///**
        //*   @brief Stops the effect on the specified window.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
        //*
        //*   This function stops the effect on a window for a specified duration.
        //*
        //*   Currently there are no effect properties that can be set using this
        //*   function.
        //*
        //*   @param  win The handle of the window whose effect property is to be stopped.
        //*   @param  duration The duration is not used in screen_stop_effect().
        //*   @param  notify A flag to indicate whether or not a
        //*           @c SCREEN_EVENT_EFFECT_COMPLETE event is to be sent upon completion
        //*           of screen_start_effect(). @c 1 indicates that a
        //*           @c SCREEN_EVENT_EFFECT_COMPLETE is to be sent and @c 0 indicates
        //*           that no event is sent upon completion of screen_start_effect().
        //*
        //*   @return @c 0 upon the value(s) of the property being set to new value(s),
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_stop_effect(screen_window_t win, float duration, int notify);
        [DllImport("screen")]
        static extern int screen_stop_effect(IntPtr win, float duration, int notify);
        #endregion

        private Window _window;
        public Window Window
        {
            get
            {
                return _window;
            }
        }

        public ScreenEffect(Window win)
        {
            _window = win;
        }

        public void PrepareEffect(EffectType effect)
        {
            if (screen_prepare_effect(_window.Handle, effect) != 0)
                throw new Exception("Unable to prepare effect.");
        }

        public void StartEffect(float duration, bool notifyEndEffect = true)
        {
            if (screen_start_effect(_window.Handle, duration, notifyEndEffect ? 1 : 0) != 0)
                throw new Exception("Unable to start effect.");
        }

        public void StopEffect(float duration, bool notifyEndEffect = true)
        {
            if (screen_stop_effect(_window.Handle, duration, notifyEndEffect ? 1 : 0) != 0)
                throw new Exception("Unable to stop effect.");
        }

        public void SetIntProperty(PropertyType p, int[] val)
        {
            if (screen_set_effect_property_iv(_window.Handle, p, val) != 0)
                throw new Exception("Unable to set effect property " + p);
        }

        public void SetFloatProperty(PropertyType p, float[] val)
        {
            if (screen_set_effect_property_fv(_window.Handle, p, val) != 0)
                throw new Exception("Unable to set effect property " + p);
        }
    }
}