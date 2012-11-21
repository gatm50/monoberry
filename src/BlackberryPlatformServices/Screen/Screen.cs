using System;
using System.Runtime.InteropServices;

namespace BlackberryPlatformServices.Screen
{
    public class Screen
    {
        #region DllImport

        // /**
        // * @brief Event code for libscreen events
        // *
        // * This enumeration defines the event code for the BPS event that wraps all
        // * libscreen events.
        // * @anonenum bps_screen_anon_events Screen Events
        // */
        //enum {
        //    BPS_SCREEN_EVENT       = 0x01
        //};

        ///**
        // * @brief Start receiving libscreen events
        // *
        // * The @c screen_request_events() function starts to deliver libscreen events
        // * to an application using BPS.  An application must not invoke libscreen's @c
        // * get_screen_event() function if it is receiving screen events through BPS.
        // * The @c screen_request_events() function should not be called multiple times
        // * before calling @c screen_stop_events().  An application may only request
        // * events for a single @c screen_context_t at one time, and only for a single
        // * thread.
        // *
        // * @param context The libscreen context to use for event retrieval.
        // * 
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int screen_request_events(screen_context_t context);
        [DllImport("bps")]
        static extern int screen_request_events(IntPtr context);


        ///**
        // * @brief Get the unique domain ID for the screen
        // * 
        // * The @c screen_get_domain() function gets the unique domain ID for the screen.
        // * You can use this function in your application to test whether an event that
        // * you retrieve using @c bps_get_event() is a screen event, and respond
        // * accordingly.
        // *
        // * @return The domain ID for the screen.
        // */
        //BPS_API int screen_get_domain();
        [DllImport("bps")]
        static extern int screen_get_domain();

        ///**
        // * @brief Stop receiving libscreen events
        // *
        // * The @c screen_stop_events() function stops libscreen events from being
        // * delivered to the application using BPS.  You should call this function after
        // * you call @c screen_request_events() for the first time, and before you call
        // * @c screen_request_events() again.
        // * 
        // * @param context The libscreen context that was passed to
        // * @c screen_request_events().
        // * 
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int screen_stop_events(screen_context_t context);
        [DllImport("bps", EntryPoint = "screen_stop_events")]
        static extern int screen_stop_events_from_context(IntPtr context);

        ///**
        // * @brief Get the libscreen event from a BPS event
        // * 
        // * The @c screen_event_get_event() function extracts the libscreen
        // * @c screen_event_t that is stored within a BPS event.  Note that the
        // * @c screen_event_t is valid for the same period as the @c bps_event_t;
        // * that is, until @c bps_get_event() is called again.  An application must
        // * not call @c screen_destroy_event() on the @c screen_event_t that is extracted
        // * from the BPS event.
        // *
        // * The event must be of the same domain type as the domain that is returned from
        // * @c screen_get_domain().
        // *
        // * @param event The event to extract the libscreen @c screen_event_t from.
        // *
        // * @return The libscreen @c screen_event_t.
        // */
        //BPS_API screen_event_t screen_event_get_event(bps_event_t *event);
        [DllImport("bps", EntryPoint = "screen_stop_events")]
        static extern int screen_stop_events(IntPtr _event);
        #endregion

        public static void RequestEvent(Context ctx)
        {
            if (screen_request_events(ctx.Handle) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to request events from context.");
        }

        public static int GetDomain()
        {
            return screen_get_domain();
        }

        public static void StopEvent(IntPtr _event)
        {
            if (screen_stop_events(_event) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to stop events.");
        }

        public static void StopEventFromContext(Context ctx)
        {
            if (screen_stop_events_from_context(ctx.Handle) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to stop events from context.");
        }
    }
}
