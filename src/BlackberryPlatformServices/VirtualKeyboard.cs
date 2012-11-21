using System;
using System.Runtime.InteropServices;

namespace BlackberryPlatformServices
{
    public class VirtualKeyboard
    {
        #region Enumerators
        //        /**
        // * @brief Event codes for virtual keyboard events
        // *
        // * This enumeration defines the event codes for the types of events that the
        // * virtual keyboard service may return.
        // * @anonenum bps_virtualkeyboard_events Virtual keyboard events
        // */
        //enum {
        //    /**
        //     * The virtual keyboard has become visible.
        //     */
        //    VIRTUALKEYBOARD_EVENT_VISIBLE   = 0x01,

        //    /**
        //     * The virtual keyboard has become hidden.
        //     */
        //    VIRTUALKEYBOARD_EVENT_HIDDEN    = 0x02,

        //    /**
        //     * Contains all the information about the current status of the virtual
        //     * keyboard.
        //     */
        //    VIRTUALKEYBOARD_EVENT_INFO      = 0x03
        //};
        [Flags]
        public enum KeyboardEvents
        {
            VIRTUALKEYBOARD_EVENT_VISIBLE = 0x01,
            VIRTUALKEYBOARD_EVENT_HIDDEN = 0x02,
            VIRTUALKEYBOARD_EVENT_INFO = 0x03
        }

        ///**
        // * @brief Virtual keyboard layouts
        // *
        // * This enumeration defines the virtual keyboard layouts that may be displayed.
        // * Possible layouts include those that are designed for typing URLs, email
        // * addresses, symbols, and so on. See the "Virtual keyboards" topic for more
        // * information.
        // */
        //typedef enum {
        //    VIRTUALKEYBOARD_LAYOUT_DEFAULT  = 0,
        //    VIRTUALKEYBOARD_LAYOUT_URL      = 1,
        //    VIRTUALKEYBOARD_LAYOUT_EMAIL    = 2,
        //    VIRTUALKEYBOARD_LAYOUT_WEB      = 3,
        //    VIRTUALKEYBOARD_LAYOUT_NUM_PUNC = 4,
        //    VIRTUALKEYBOARD_LAYOUT_SYMBOL   = 5,
        //    VIRTUALKEYBOARD_LAYOUT_PHONE    = 6,
        //    VIRTUALKEYBOARD_LAYOUT_PIN      = 7,
        //    VIRTUALKEYBOARD_LAYOUT_PASSWORD = 8,
        //} virtualkeyboard_layout_t;
        public enum LayoutType : int
        {
            VIRTUALKEYBOARD_LAYOUT_DEFAULT = 0,
            VIRTUALKEYBOARD_LAYOUT_URL = 1,
            VIRTUALKEYBOARD_LAYOUT_EMAIL = 2,
            VIRTUALKEYBOARD_LAYOUT_WEB = 3,
            VIRTUALKEYBOARD_LAYOUT_NUM_PUNC = 4,
            VIRTUALKEYBOARD_LAYOUT_SYMBOL = 5,
            VIRTUALKEYBOARD_LAYOUT_PHONE = 6,
            VIRTUALKEYBOARD_LAYOUT_PIN = 7,
            VIRTUALKEYBOARD_LAYOUT_PASSWORD = 8,
        }

        ///**
        // * @brief Text for the Enter key on the virtual keyboard
        // *
        // * This enumeration defines the specific text that can appear on the Enter
        // * key of the virtual keyboard. For example, you can configure this key to
        // * display the text "Go", "Send", "Done", and so on. The default text for this
        // * key is "Enter".
        // */
        //typedef enum {
        //    VIRTUALKEYBOARD_ENTER_DEFAULT   = 0,
        //    VIRTUALKEYBOARD_ENTER_GO        = 1,
        //    VIRTUALKEYBOARD_ENTER_JOIN      = 2,
        //    VIRTUALKEYBOARD_ENTER_NEXT      = 3,
        //    VIRTUALKEYBOARD_ENTER_SEARCH    = 4,
        //    VIRTUALKEYBOARD_ENTER_SEND      = 5,
        //    VIRTUALKEYBOARD_ENTER_SUBMIT    = 6,
        //    VIRTUALKEYBOARD_ENTER_DONE      = 7,
        //    VIRTUALKEYBOARD_ENTER_CONNECT   = 8,
        //} virtualkeyboard_enter_t;
        public enum EnterType : int
        {
            VIRTUALKEYBOARD_ENTER_DEFAULT = 0,
            VIRTUALKEYBOARD_ENTER_GO = 1,
            VIRTUALKEYBOARD_ENTER_JOIN = 2,
            VIRTUALKEYBOARD_ENTER_NEXT = 3,
            VIRTUALKEYBOARD_ENTER_SEARCH = 4,
            VIRTUALKEYBOARD_ENTER_SEND = 5,
            VIRTUALKEYBOARD_ENTER_SUBMIT = 6,
            VIRTUALKEYBOARD_ENTER_DONE = 7,
            VIRTUALKEYBOARD_ENTER_CONNECT = 8,
        }
        #endregion
        #region DllImport

        ///**
        // * @brief Display the virtual keyboard
        // *
        // * The @c virtualkeyboard_show() function causes the virtual keyboard to be
        // * displayed (if it is not already visible).  When this function is called, the
        // * @c VIRTUALKEYBOARD_EVENT_VISIBLE event is sent unless the virtual keyboard
        // * was already visible.
        // *
        // * @return Nothing.
        // */
        //BPS_API void virtualkeyboard_show();
        [DllImport("bps")]
        static extern void virtualkeyboard_show();

        ///**
        // * @brief Hide the virtual keyboard
        // *
        // * The @c virtualkeyboard_hide() function hides the virtual keyboard (if it is
        // * not already hidden).  When this function is called, the
        // * @c VIRTUALKEYBOARD_EVENT_HIDDEN event is sent unless the virtual keyboard was
        // * already hidden.
        // *
        // * @return Nothing.
        // */
        //BPS_API void virtualkeyboard_hide();
        [DllImport("bps")]
        static extern void virtualkeyboard_hide();

        ///**
        // * @brief Change the virtual keyboard layout and Enter key options
        // *
        // * The @c virtualkeyboard_change_options() function changes the virtual keyboard
        // * layout and Enter key options, using values that are defined in the
        // * @c virtualkeyboard_layout_t and @c virtualkeyboard_enter_t enumerations.
        // *
        // * @param layout The virtual keyboard layout to set.
        // * @param enter The Enter key text to set.
        // *
        // * @return Nothing.
        // */
        //BPS_API void virtualkeyboard_change_options(virtualkeyboard_layout_t layout, virtualkeyboard_enter_t enter);
        [DllImport("bps")]
        static extern void virtualkeyboard_change_options(LayoutType layout, EnterType enter);

        ///**
        // * @brief Get the height of the virtual keyboard
        // *
        // * The @c virtualkeyboard_get_height() function gets the height of the virtual
        // * keyboard.
        // *
        // * @param pixels The height of the virtual keyboard (in pixels).
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int virtualkeyboard_get_height(int *pixels);
        [DllImport("bps")]
        static extern int virtualkeyboard_get_height(out int pixels);

        ///**
        // * @brief Start receiving virtual keyboard events
        // *
        // * The @c virtualkeyboard_request_events() function starts to deliver virtual
        // * keyboard events to the application using BPS.
        // *
        // * @param flags The types of events to deliver. A value of zero indicates that
        // * all events are requested. The meaning of non-zero values is reserved for
        // * future use.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int virtualkeyboard_request_events(int flags);
        [DllImport("bps")]
        static extern int virtualkeyboard_request_events(int flags);

        ///**
        // * @brief Stop receiving virtual keyboard events
        // *
        // * The @c virtualkeyboard_stop_events() function stops virtual keyboard events
        // * from being delivered to the application using BPS.
        // *
        // * @param flags The types of events to stop. A value of zero indicates that all
        // * events are stopped. The meaning of non-zero values is reserved for future
        // * use.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int virtualkeyboard_stop_events(int flags);
        [DllImport("bps")]
        static extern int virtualkeyboard_stop_events(int flags);

        ///**
        // * @brief Get the unique domain ID for the virtual keyboard service
        // *
        // * The @c virtualkeyboard_get_domain() function gets the unique domain ID for
        // * the virtual keyboard service.  You can use this function in your application
        // * to test whether an event that you retrieve using @c bps_get_event() is a
        // * virtual keyboard event, and respond accordingly.
        // *
        // * @return The domain ID for the virtual keyboard service.
        // */
        //BPS_API int virtualkeyboard_get_domain();
        [DllImport("bps")]
        static extern int virtualkeyboard_get_domain();

        ///**
        // * @brief Get the virtual keyboard height
        // *
        // * The @c virtualkeyboard_event_get_height() function gets the keyboard height
        // * from a @c VIRTUALKEYBOARD_EVENT_INFO event.  The keyboard height is dynamic
        // * and varies depending on whether the device is in portrait or landscape mode.
        // *
        // * @param event The event to get the virtual keyboard height from.
        // *
        // * @return The virtual keyboard height (in pixels).
        // */
        //BPS_API int virtualkeyboard_event_get_height(bps_event_t *event);
        [DllImport("bps")]
        static extern int virtualkeyboard_event_get_height(IntPtr _event);
        #endregion

        private LayoutType _layout;
        public LayoutType Layout
        {
            get { return _layout; }
            set { _layout = value; virtualkeyboard_change_options(_layout, _enter); }
        }

        private EnterType _enter;
        public EnterType Enter
        {
            get { return _enter; }
            set { _enter = value; virtualkeyboard_change_options(_layout, _enter);}
        }

        private int _heigth;
        public int Height
        {
            get 
            {
                if (virtualkeyboard_get_height(out _heigth) != (int)BPSResponse.BPS_SUCCESS)
                    throw new Exception("Unable to get height of virtual keyboard.");
                return _heigth;
            }
        }

        public VirtualKeyboard(LayoutType layout=LayoutType.VIRTUALKEYBOARD_LAYOUT_DEFAULT, 
                                EnterType enter=EnterType.VIRTUALKEYBOARD_ENTER_DEFAULT)
        {
            _layout = layout;
            _enter = enter;
        }

        public void Show()
        {
            virtualkeyboard_show();
        }

        public void Hide()
        {
            virtualkeyboard_hide();
        }

        public void RequestEvents()
        {
            if(virtualkeyboard_request_events(0)!=(int) BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to request events for virtual keyboard.");
        }

        public void StopEvents()
        {
            if (virtualkeyboard_stop_events(0) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to stop events for virtual keyboard.");
        }

        public int GetDomain()
        {
            return virtualkeyboard_get_domain();
        }

        public int GetHeightByEvent(IntPtr _event)
        {
            return virtualkeyboard_event_get_height(_event);
        }
    }
}
