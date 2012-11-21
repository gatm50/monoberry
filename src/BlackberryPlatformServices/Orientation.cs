using System;
using System.Runtime.InteropServices;

namespace BlackberryPlatformServices
{
    public class Orientation
    {
        #region Enumerators
        // /**
        // * @brief Possible orientation events
        // *  
        // * This enumeration defines the possible orientation events.  Currently, there
        // * is only one event.
        // * @anonenum bps_orientation_events Orientation Events 
        // */
        //enum {
        //    /**
        //     * The single orientation event, which contains all the information about
        //     * the current orientation of the device.
        //     */
        //    ORIENTATION_INFO        = 0x01
        //};

        ///**
        // * @brief Possible orientation directions
        // * 
        // * This enumeration defines the possible directions that the device is being
        // * held in.
        // */
        //typedef enum {
        //    ORIENTATION_FACE_UP     = 0,
        //    ORIENTATION_TOP_UP      = 1,
        //    ORIENTATION_BOTTOM_UP   = 2,
        //    ORIENTATION_LEFT_UP     = 3,
        //    ORIENTATION_RIGHT_UP    = 4,
        //    ORIENTATION_FACE_DOWN   = 5,
        //} orientation_direction_t;

        public enum Direction
        {
            ORIENTATION_FACE_UP = 0,
            ORIENTATION_TOP_UP = 1,
            ORIENTATION_BOTTOM_UP = 2,
            ORIENTATION_LEFT_UP = 3,
            ORIENTATION_RIGHT_UP = 4,
            ORIENTATION_FACE_DOWN = 5,
        }
        #endregion

        #region DllImport
        ///**
        // * @brief Start receiving orientation events 
        // * 
        // * The @c orientation_request_events() function starts to deliver orientation
        // * change events to your application using BPS.  Events will be posted to the
        // * currently active channel.
        // *
        // * @param flags The types of events to deliver.  A value of zero indicates that
        // * all events are requested. The meaning of non-zero values is reserved for
        // * future use.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int orientation_request_events(int flags);
        [DllImport("bps")]
        static extern int orientation_request_events(int flags);

        ///**
        // * @brief Stop receiving orientation change events
        // *
        // * The @c orientation_stop_events() function stops orientation change events
        // * from being delivered to the application using BPS.
        // *
        // * @param flags The types of events to stop. A value of zero indicates that all
        // * events are stopped. The meaning of non-zero values is reserved for future
        // * use.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int orientation_stop_events(int flags);
        [DllImport("bps")]
        static extern int orientation_stop_events(int flags);

        ///**
        // * @brief Get the unique domain ID for the orientation service
        // * 
        // * The @c orientation_get_domain() function gets the unique domain ID for the
        // * orientation service.  You can use this function in your application
        // * to test whether an event that you retrieve using @c bps_get_event() is an
        // * orientation change event, and respond accordingly.
        // *
        // * @return The domain ID for the orientation service.
        // */
        //BPS_API int orientation_get_domain();
        [DllImport("bps")]
        static extern int orientation_get_domain();

        ///**
        // * @brief Get the current orientation direction and angle
        // * 
        // * The @c orientation_get() function gets the current orientation direction and
        // * angle of the device.
        // * 
        // * @param direction The orientation direction.
        // * @param angle The orientation angle (in degrees).
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int orientation_get(orientation_direction_t *direction, int *angle);
        [DllImport("bps")]
        static extern int orientation_get(out Direction direction, out int angle);

        ///**
        // * @brief Get the curent direction that the device is being held in
        // * 
        // * The @c orientation_event_get_direction() function gets the current direction
        // * that the device is being held in from an @c ORIENTATION_INFO event.
        // *
        // * @param event The event to get the direction from.
        // *
        // * @return The current direction.
        // */
        //BPS_API orientation_direction_t orientation_event_get_direction(bps_event_t *event);
        [DllImport("bps")]
        static extern Direction orientation_event_get_direction(IntPtr _event);

        ///**
        // * @brief Get the current angle of the device
        // * 
        // * The @c orientation_event_get_angle() function gets the current angle of the
        // * device from an @c ORIENTATION_INFO event. For example, possible angles of the
        // * BlackBerry PlayBook tablet include the following:
        // *
        // * <ul>
        // *    <li>An angle of 0 is normal landscape mode, with the BlackBerry logo along
        // *        the bottom and the camera at the top.</li>
        // *    <li>An angle of 180 is the reverse of an angle of 0, with the BlackBerry
        // *        logo along the top and the camera at the bottom.</li>
        // *    <li>Angles of 90 and 270 are portrait modes.</li>
        // * </ul>
        // *
        // * @param event The event to get the angle from.
        // *
        // * @return The current angle (in degrees).
        // */
        //BPS_API int orientation_event_get_angle(bps_event_t *event);
        [DllImport("bps")]
        static extern int orientation_event_get_angle(IntPtr _event);
        #endregion

        public Orientation()
        { }

        private int _angle;
        public int Angle
        {
            get { orientation_get(out _direction, out _angle); return _angle; }
        }

        private Direction _direction;
        public Direction CurrentDirection
        {
            get { orientation_get(out _direction, out _angle); return _direction; }
        }

        public Direction GetDirectionByEvent(IntPtr _event)
        {
            return orientation_event_get_direction(_event);
        }

        public int  GetAngleByEvent(IntPtr _event)
        {
            return orientation_event_get_angle(_event);
        }
    }
}
