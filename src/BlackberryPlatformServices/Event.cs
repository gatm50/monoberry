using System;
using System.Runtime.InteropServices;

namespace BlackberryPlatformServices
{
    public class Event
    {
        #region DllImport

        ///**
        // * @brief Get the domain of an event
        // *
        // * The @c bps_event_get_domain() function gets the domain of a BPS event.  Each
        // * event in BPS is associated with a domain, which represents the service
        // * that generated the event (for example, navigator, network status,
        // * accelerometer, and so on).
        // *
        // * @param event The event to get the domain of.
        // *
        // * @return The domain of the event.
        // */
        //BPS_API int bps_event_get_domain(bps_event_t *event);
        [DllImport("bps")]
        static extern int bps_event_get_domain(IntPtr _event);

        ///**
        // * @brief Get the code of an event
        // *
        // * The @c bps_event_get_code_() function gets the code of a BPS event.  In
        // * addition to being associated with a domain, each event in BPS has a code,
        // * which represents the specific type of event that occurred.  For example,
        // * the virtual keyboard service includes event codes that indicate when the
        // * keyboard becomes visible, when the keyboard becomes hidden, and so on.
        // *
        // * @param event The event to get the code of.
        // *
        // * @return The code of the event.
        // */
        //BPS_API unsigned int bps_event_get_code(bps_event_t *event);
        [DllImport("bps")]
        static extern uint bps_event_get_code(IntPtr handle);


        ///*
        // * The following functions are typically not needed by applications.
        // * Applications that create their own events should use these functions
        // * carefully.
        // */


        ///**
        // * @brief Structure that represents the payload of an event
        // *
        // * The @c bps_event_payload_t structure represents the payload of a BPS event.
        // * Events carry three data members as payload.  These data members may contain
        // * the event's data themselves, or they may be pointers to additional data
        // * pertaining to the event.  In most cases, an application does not need to
        // * use the data members, because a service will provide accessor methods.  An
        // * application may use the @c bps_event_payload_t structure when creating its own
        // * events.
        // *
        // * Note that if an event's payload contains dynamically allocated
        // * resources, they should be freed in the event's destructor function, which
        // * is called by @c bps_event_destroy().
        // */
        struct bps_event_payload_t
        {
            /** Payload data. */
            UIntPtr data1;
            /** Payload data. */
            UIntPtr data2;
            /** Payload data. */
            UIntPtr data3;
        };

        ///**
        // * A data type for the @c struct @c bps_event_payload_t, which stores the
        // * data (payload) sent as part of an event.
        // */
        //typedef struct bps_event_payload_t bps_event_payload_t;

        ///**
        // * @brief Completion function for an event
        // *
        // * An event may have a completion function that will be called by the system
        // * when the event is no longer used.  A completion function may be used by the
        // * originator of the event to free dynamic resources associated with the
        // * event's payload.  When an event's completion function is invoked, the event
        // * may safely be reused by the event's originator or @c bps_event_destroy()
        // * should be invoked.  If @c NULL is set as an event's completion function, the
        // * event is destroyed internally.  An event may be resubmitted to BPS from within
        // * the completion function by using @c bps_push_event().
        // */
        //typedef void (*bps_event_completion_func) (bps_event_t *event);
        public delegate void bps_event_completion_func(ref IntPtr _event);

        ///**
        // * @brief Create an event
        // *
        // * The @c bps_event_create() function creates a @c bps_event_t event.  An
        // * application may create its own event, which may then be passed to
        // * @c bps_push_event().
        // *
        // * @param event The event to be returned.
        // * @param domain The domain of the event.  This value must be no greater than
        // * @c BPS_EVENT_DOMAIN_MAX.  Your event's domain must be a number generated by a
        // * call to @c bps_register_domain() to ensure uniqueness.
        // * @param code The code of the event.  This value may be any number from 0 to UINT16_MAX.
        // * @param payload_ptr A pointer to the event's payload, which will be copied.
        // * @param completion_function An optional completion function that will be invoked
        // * when the system is done with the event.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int bps_event_create(bps_event_t **event, unsigned int domain, unsigned int code, const bps_event_payload_t *payload_ptr, bps_event_completion_func completion_function);
        [DllImport("bps")]
        static extern int bps_event_create(out IntPtr _event, uint domain, uint code, bps_event_payload_t payload_ptr, bps_event_completion_func completion_function);

        ///**
        // * @brief Destroy an event
        // *
        // * The @c bps_event_destroy() function destroys a @c bps_event_t event.  The
        // * event must not be used after this function is invoked.  An application should
        // * rarely call this function.  This function must be called only if an event is
        // * created using @c bps_event_create() @b and the event is not pushed to BPS
        // * using @c bps_push_event().  If @c bps_push_event() is successfully called on
        // * the event, the event will be destroyed by the event's completion function (or
        // * by the library if a completion function is not set).
        // *
        // * @param event The event to destroy.
        // *
        // * @return Nothing.
        // */
        //BPS_API void bps_event_destroy(bps_event_t *event);
        [DllImport("bps")]
        static extern void bps_event_destroy(IntPtr _event);

        ///**
        // * @brief Get a pointer to an event's payload
        // *
        // * The @c bps_event_get_payload() function gets a pointer to the payload of a
        // * @c bps_event_t event.
        // *
        // * @param event The event to get the payload for.
        // *
        // * @return A pointer to the event's payload.
        // */
        //BPS_API bps_event_payload_t* bps_event_get_payload(bps_event_t *event);
        [DllImport("bps")]
        static extern IntPtr bps_event_get_payload(IntPtr _event);
        #endregion

        protected IntPtr _handle;
        private bps_event_payload_t _payload;

        internal Event(IntPtr h)
        {
            _handle = h;
        }

        public Event(bps_event_completion_func completion_function = null)
        {
            if (completion_function == null)
                completion_function = this.CallBackCreateEvent;

            CreateEvent(completion_function);
        }

        public uint Code
        {
            get { return bps_event_get_code(_handle); }
        }

        public int GetDomain()
        {
            return bps_event_get_domain(_handle);
        }

        private void CreateEvent(bps_event_completion_func completion_function)
        {
            uint code = 0;
            uint domain = (uint)PlatformServices.RegisterDomain();
            if (bps_event_create(out _handle, domain, code, _payload, completion_function) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to create event.");
        }

        private void CallBackCreateEvent(ref IntPtr _event)
        {

        }

        public void Dispose()
        {
            bps_event_destroy(_handle);
        }
    }
}
