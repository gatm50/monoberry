using System;

namespace BlackberryPlatformServices
{
    public partial class Navigator
    {
        ///**
        // * @brief The window cover image attribute structure
        // *
        // * Handle to a @c navigator_window_cover_attribute_t struct which is used for
        // * updating the window cover image.
        // */
        //typedef struct navigator_window_cover_attribute_t navigator_window_cover_attribute_t;

        ///**
        // * @brief The window cover text attribute structure
        // *
        // * Handle to a @c navigator_window_cover_label_t struct which is used for
        // * updating window cover text.
        // */
        //typedef struct navigator_window_cover_label_t navigator_window_cover_label_t;

        #region Enumerators Navigator
        ///**
        // * @brief Event codes for navigator service events
        // *
        // * This enumeration defines the event codes for the types of events that the
        // * navigator service may return. Note that a reply is expected when your
        // * application receives a @c NAVIGATOR_ORIENTATION or @c
        // * NAVIGATOR_ORIENTATION_CHECK event. See the @c
        // * navigator_orientation_check_response() and @c navigator_done_orientation()
        // * functions for more information.
        // *
        // * @anonenum bps_navigator_events Navigator events
        // */
        //enum {
        //    /**
        //     * Indicates that the application is a registered URL handler, and the
        //     * navigator is invoking a URL type on the application. For example, a web
        //     * browser might need to handle http://... invoke request from another
        //     * application, and load the website that is associated with the request.
        //     */
        //    NAVIGATOR_INVOKE                      = 0x01,

        //    /**
        //     * Indicates that the user has quit the application, the device is
        //     * rebooting, or some other event has occurred that results in the
        //     * application needing to terminate. After this type of event is received,
        //     * the application has a short amount of time (3 seconds) to terminate
        //     * itself. If the application has not terminated after this time has
        //     * elapsed, the navigator terminates the application.
        //     */
        //    NAVIGATOR_EXIT                        = 0x02,

        //    /**
        //     * Indicates that the state of the application window has changed. For
        //     * example, the application window might have changed to full screen from a
        //     * thumbnail. The @c navigator_window_state_t enumeration defines the
        //     * possible states that an application window can be in.
        //     */
        //    NAVIGATOR_WINDOW_STATE                = 0x03,

        //    /**
        //     * Indicates that the user has performed a downward swipe gesture from the
        //     * top of the device screen. By convention, this gesture displays a menu.
        //     */
        //    NAVIGATOR_SWIPE_DOWN                  = 0x04,

        //    /**
        //     * Indicates that the user has started a swipe gesture. This type of event
        //     * is generated if the application has requested swipe start events by
        //     * calling @c navigator_request_swipe_start(). For example, if an
        //     * application calls @c navigator_request_swipe_start() and the user
        //     * performs a downward swipe gesture from the top of the device screen, the
        //     * application receives a @c NAVIGATOR_SWIPE_START event followed by a
        //     * series of touch events. This functionality can be useful if the
        //     * application wants to respond more appropriately to swipe gestures (for
        //     * example, by displaying the menu in sync with the user's downward swipe
        //     * gesture).
        //     */
        //    NAVIGATOR_SWIPE_START                 = 0x05,

        //    /**
        //     * Indicates that the device is low on memory. To prevent degraded
        //     * performance and a potentially poor user experience, an application should
        //     * respond to this event by freeing any memory that it isn't using.
        //     */
        //    NAVIGATOR_LOW_MEMORY                  = 0x06,

        //    /**
        //     * Indicates that the device has rotated. An application should respond to
        //     * this event by calling @c navigator_orientation_check_response() and
        //     * indicating whether it intends to rotate along with the device rotation.
        //     * If the application indicates that it intends to rotate, the navigator
        //     * sends a follow-up @c NAVIGATOR_ORIENTATION event when it is time for the
        //     * application to resize its screen.
        //     */
        //    NAVIGATOR_ORIENTATION_CHECK           = 0x07,

        //    /**
        //     * Indicates that an application should resize its screen in response to the
        //     * rotation of the device. This event is generated if the application has
        //     * called @c navigator_orientation_check_response() and indicated that it
        //     * intends to rotate. After the application is finished resizing its screen,
        //     * the application should call @c navigator_done_orientation() to let the
        //     * navigator know that the application is finished rotating.
        //     */
        //    NAVIGATOR_ORIENTATION                 = 0x08,

        //    /**
        //     * Indicates that the user has performed a swipe gesture from the bottom
        //     * left of the device screen towards the top right.
        //     */
        //    NAVIGATOR_BACK                        = 0x09,

        //    /**
        //     * Indicates that the application window has become active (for example, if
        //     * the application window changes to full screen from being hidden).
        //     */
        //    NAVIGATOR_WINDOW_ACTIVE               = 0x0a,

        //    /**
        //     * Indicates that the application window has become inactive (for example,
        //     * if the application window changes to hidden from being full screen).
        //     */
        //    NAVIGATOR_WINDOW_INACTIVE             = 0x0b,

        //    /**
        //     * Indicates that the device has finished rotating.
        //     */
        //    NAVIGATOR_ORIENTATION_DONE            = 0x0c,

        //    /**
        //     * Indicates that a request to change the orientation with @c
        //     * navigator_set_orientation() has completed.
        //     */
        //    NAVIGATOR_ORIENTATION_RESULT          = 0x0d,

        //    /**
        //     * Indicates that the corporate or enterprise application is locked. When
        //     * locked, the window changes to a lock icon and cannot be used. To use the
        //     * window again, the user must unlock it by touching the window and then
        //     * typing a password.
        //     */
        //    NAVIGATOR_WINDOW_LOCK                 = 0x0e,

        //    /**
        //     * Indicates that the corporate or enterprise application is unlocked. When
        //     * an application is first launched, it is considered unlocked. No message
        //     * is sent when the application starts.
        //     */
        //    NAVIGATOR_WINDOW_UNLOCK               = 0x0f,

        //    /**
        //     * Indicates an invocation for the target was received. The application
        //     * should retrieve the invocation properties through the @c
        //     * navigator_invoke_event_get_invocation() function.
        //     */
        //    NAVIGATOR_INVOKE_TARGET               = 0x10,

        //    /**
        //     * Indicates an invocation query result was received. The application should
        //     * retrieve the invocation query result actions through the
        //     * @c navigator_invoke_event_get_query_result_action() and
        //     * @c navigator_invoke_event_get_query_result_action_count() functions.
        //     */
        //    NAVIGATOR_INVOKE_QUERY_RESULT         = 0x11,

        //    /**
        //     * Indicates a viewer invocation was received. The application should
        //     * retrieve the viewer invocation through the
        //     * @c navigator_invoke_event_get_viewer() function.
        //     */
        //    NAVIGATOR_INVOKE_VIEWER               = 0x12,

        //    /**
        //     * Indicates an invocation target response was received. The application
        //     * should retrieve the invocation ID through the
        //     * @c navigator_event_get_id() function and the error through the
        //     * @c navigator_event_get_err() function.
        //     */
        //    NAVIGATOR_INVOKE_TARGET_RESULT        = 0x13,

        //    /**
        //     * Indicates an invocation viewer response was received. The application
        //     * should retrieve the invocation viewer ID through the
        //     * @c navigator_event_get_id() function and the error through the
        //     * @c navigator_event_get_err() function.
        //     */
        //    NAVIGATOR_INVOKE_VIEWER_RESULT        = 0x14,

        //    /**
        //     * If the current process is the parent application of the viewer it
        //     * indicates that the request message from the viewer was received. If the
        //     * current process is the viewer it indicates that the request message from
        //     * the parent application was received. To retrieve the message name use the
        //     * @c navigator_invoke_event_get_viewer_relay_message_name() function. To
        //     * retrieve the data use the
        //     * @c navigator_invoke_event_get_viewer_relay_data() function. To retrieve
        //     * the window ID of the viewer use the
        //     * @c navigator_invoke_event_get_viewer_relay_window_id() function.
        //     */
        //    NAVIGATOR_INVOKE_VIEWER_RELAY         = 0x15,

        //    /**
        //     * Indicates that the invocation viewer has terminated. To retrieve the
        //     * window ID use the @c navigator_invoke_event_get_window_id() function.
        //     */
        //    NAVIGATOR_INVOKE_VIEWER_STOPPED       = 0x16,

        //    /**
        //     * Indicates that the the keyboard has changed state. The @c
        //     * navigator_keyboard_state_t enumeration defines the possible states that
        //     * the keyboard can be in.
        //     */
        //    NAVIGATOR_KEYBOARD_STATE              = 0x17,

        //    /**
        //     * Indicates that the keyboard has changed position.
        //     */
        //    NAVIGATOR_KEYBOARD_POSITION           = 0x18,

        //    /**
        //     * If the current process is the parent application of the viewer it
        //     * indicates that the response message from the viewer was received. If the
        //     * current process is the viewer it indicates that the response message from
        //     * the parent application was received. In case of an error in delivering
        //     * the request message to the peer the event contains an error message. To
        //     * retrieve the error message use @c navigator_event_get_err() function.
        //     * If the error message is NULL in the event the following functions should
        //     * be used to retrieve the message name, the data and the window ID of the
        //     * viewer:
        //     * - @c navigator_invoke_event_get_viewer_relay_message_name()
        //     * - @c navigator_invoke_event_get_viewer_relay_data()
        //     * - @c navigator_invoke_event_get_viewer_relay_window_id()
        //     */
        //    NAVIGATOR_INVOKE_VIEWER_RELAY_RESULT  = 0x19,

        //    /**
        //     * Indicates that the device has been locked or unlocked.
        //     * @c navigator_event_get_device_lock_state()
        //     */
        //    NAVIGATOR_DEVICE_LOCK_STATE           = 0x1a,

        //    /**
        //     * Provide details about the window cover.  Occurs on application startup.
        //     */
        //    NAVIGATOR_WINDOW_COVER                = 0x1b,

        //    /**
        //     * Occurs when navigator displays the application's window cover.
        //     */
        //    NAVIGATOR_WINDOW_COVER_ENTER          = 0x1c,

        //    /**
        //     * Occurs when the navigator removes the application's window cover.
        //     */
        //    NAVIGATOR_WINDOW_COVER_EXIT           = 0x1d,

        //    /**
        //     * Indicates that the card peek action has started. Card peeking is the
        //     * ability to see behind a card using a gesture to drag the card off screen
        //     * to expose the card's parent or root.
        //     */
        //    NAVIGATOR_CARD_PEEK_STARTED           = 0x1e,

        //    /**
        //     * Indicates that the card peek action has stopped. Call the @c
        //     * navigator_event_get_card_peek_stopped_swipe_away function upon receiving
        //     * this event to determine if the peeking action was stopped due to a "swipe
        //     * away" gesture or not.
        //     */
        //    NAVIGATOR_CARD_PEEK_STOPPED           = 0x1f,

        //    /**
        //     * Indicates that the card application should resize its buffer and call the
        //     * @c navigator_card_resized() function when finished. When this event is
        //     * triggered, the Navigator delivers a message to the card containing the
        //     * resize data, which the card extracts and uses to execute the
        //     * transformation.
        //     *
        //     * The members contained in the message and the functions the card
        //     * application must use to retrive them are as follows:
        //     *     - @b Event @b ID: the ID of the message to identify the event
        //     *                     (@c navigator_event_get_id())
        //     *     - @b Width: the new width of the card
        //     *                     (@c navigator_event_get_card_width())
        //     *     - @b Height: the new height of the card
        //     *                     (@c navigator_event_get_card_height())
        //     *     - @b Device @b orientation @b type: the orientation of the device
        //     *                     (either portrait or landscape)
        //     *                     (@c navigator_event_get_card_orientation())
        //     *     - @b Card @b edge: the orientation of the card relative to the
        //     *                     device (@c navigator_event_get_card_edge())
        //     */
        //    NAVIGATOR_CARD_RESIZE                 = 0x20,

        //    /**
        //     * Indicates to the parent of a card application that the child card has
        //     * been closed. When this event is triggered, the Navigator delivers a
        //     * message to the parent of the closed child card containing information
        //     * about the closure as well as any response data sent by the card (if the
        //     * card requested the closure).
        //     *
        //     * The members contained in the message and the functions the parent
        //     * application must use to retrieve them are as follows:
        //     *     - @b Reason: the reason why the child card closed
        //     *                    (@c navigator_event_get_card_closed_reason())
        //     *     - @b Data @b type: the MIME type of the data sent by the child card
        //     *                    (@c navigator_event_get_card_closed_data_type())
        //     *     - @b Data: the data sent by the child card
        //     *                    (@c navigator_event_get_card_closed_data())
        //     */
        //    NAVIGATOR_CHILD_CARD_CLOSED           = 0x21,

        //    /**
        //     * Indicates that the card has been closed and is being pooled. Pooling is a
        //     * feature that allows a card of a certain type to be opened multiple times
        //     * in quick sucession, such as when viewing a series of emails one after the
        //     * other. This event informs the card that it should clean-up its state
        //     * and listen for further invocations. When a card receives the event it
        //     * should assume that its child card is also closed. A card may retrieve the
        //     * reason for its closure by calling the @c
        //     * navigator_event_get_card_closed_reason() function.
        //     */
        //    NAVIGATOR_CARD_CLOSED                 = 0x22,

        //    /**
        //     * Indicates a get invoke target filters result was received. The
        //     * application should retrieve the get invoke target filters result filters
        //     * through @c navigator_invoke_get_filters()
        //     * function.
        //     */
        //    NAVIGATOR_INVOKE_GET_FILTERS_RESULT   = 0x23,

        //    /**
        //     * Occurs when the Adaptive Partition Scheduler will move the application
        //     * to a different partition (background, foreground, or stopped).
        //     */
        //    NAVIGATOR_APP_STATE                   = 0x24,

        //    /*
        //     * Indicates a set invoke target filters result was received. The
        //     * application should retrieve the ID through @c navigator_event_get_id()
        //     * function and any error message through @c navigator_event_get_err()
        //     * function.
        //     */
        //    NAVIGATOR_INVOKE_SET_FILTERS_RESULT   = 0x25,

        //    /**
        //     * Indicates that the peek action of this card has started. Card peeking
        //     * is the ability to see behind a card using a gesture to drag the card off
        //     * screen to expose the card's parent or root.
        //     */
        //    NAVIGATOR_PEEK_STARTED                = 0x26,

        //    /**
        //     * Indicates that the peek action of this card has stopped. Call the @c
        //     * navigator_event_get_peek_stopped_swipe_away function upon receiving
        //     * this event to determine if the peeking action was stopped due to a "swipe
        //     * away" gesture or not.
        //     */
        //    NAVIGATOR_PEEK_STOPPED                = 0x27,

        //    /**
        //     * Indicates that the Navigator is ready to display the card's window.
        //     * Call @c navigator_card_send_card_ready() to notify the navigator
        //     * when the card is ready to be shown.
        //     */
        //    NAVIGATOR_CARD_READY_CHECK            = 0x28,

        //    /**
        //     * Indicates that the event is not any of the above event types.  It could
        //     * be a custom event.
        //     */
        //    NAVIGATOR_OTHER                       = 0xff
        //};
        [Flags]
        public enum EventType
        {
            NAVIGATOR_INVOKE = 0x01,
            NAVIGATOR_EXIT = 0x02,
            NAVIGATOR_WINDOW_STATE = 0x03,
            NAVIGATOR_SWIPE_DOWN = 0x04,
            NAVIGATOR_SWIPE_START = 0x05,
            NAVIGATOR_LOW_MEMORY = 0x06,
            NAVIGATOR_ORIENTATION_CHECK = 0x07,
            NAVIGATOR_ORIENTATION = 0x08,
            NAVIGATOR_BACK = 0x09,
            NAVIGATOR_WINDOW_ACTIVE = 0x0a,
            NAVIGATOR_WINDOW_INACTIVE = 0x0b,
            NAVIGATOR_ORIENTATION_DONE = 0x0c,
            NAVIGATOR_ORIENTATION_RESULT = 0x0d,
            NAVIGATOR_WINDOW_LOCK = 0x0e,
            NAVIGATOR_WINDOW_UNLOCK = 0x0f,
            NAVIGATOR_INVOKE_TARGET = 0x10,
            NAVIGATOR_INVOKE_QUERY_RESULT = 0x11,
            NAVIGATOR_INVOKE_VIEWER = 0x12,
            NAVIGATOR_OTHER = 0xff
        }

        ///**
        // * @brief Navigator window states
        // *
        // * This enumeration defines the different states that an application window can
        // * be in.
        // */
        //typedef enum {
        //    /**
        //     * The application occupies the full display and should be operating
        //     * normally.
        //     */
        //    NAVIGATOR_WINDOW_FULLSCREEN   = 0,

        //    /**
        //     * The application is reduced to a thumbnail as the user switches
        //     * applications.
        //     */
        //    NAVIGATOR_WINDOW_THUMBNAIL    = 1,

        //    /**
        //     * The application is no longer visible to the user, for any reason.
        //     */
        //    NAVIGATOR_WINDOW_INVISIBLE    = 2
        //} navigator_window_state_t;
        public enum WindowState
        {
            NAVIGATOR_WINDOW_FULLSCREEN = 0,
            NAVIGATOR_WINDOW_THUMBNAIL = 1,
            NAVIGATOR_WINDOW_INVISIBLE = 2
        }

        ///**
        // * @brief The different run partitions an application can be placed into.
        // *
        // * This enumeration defines the different run partitions that an application
        // * can be placed into.  Use @c navigator_event_get_app_state() to retrieve the
        // * navigator_app_state_t from a @c NAVIGATOR_APP_STATE event.
        // */
        //typedef enum {
        //    /**
        //     * The application is placed into the foreground partition.
        //     */
        //    NAVIGATOR_APP_FOREGROUND      = 0,

        //    /**
        //     * The application is placed into the background partition.
        //     */
        //    NAVIGATOR_APP_BACKGROUND      = 1,

        //    /**
        //     * The application will shortly be placed into the stopped partition.
        //     */
        //    NAVIGATOR_APP_STOPPING        = 2
        //} navigator_app_state_t;
        public enum ApplicationState
        {
            NAVIGATOR_APP_FOREGROUND = 0,
            NAVIGATOR_APP_BACKGROUND = 1,
            NAVIGATOR_APP_STOPPING = 2
        }

        ///**
        // * @brief Extended data enabling
        // *
        // * This enumeration defines whether extended data is enabled when events are
        // * requested by the @c navigator_request_events() function.
        // *
        // * @anonenum bps_navigator_extendeddata Navigator extended data
        // */
        //enum {
        //    /**
        //     * Enables extended data.
        //     */
        //    NAVIGATOR_EXTENDED_DATA           = 0x01

        //};
        [Flags]
        public enum ExtendedData
        {
            NAVIGATOR_EXTENDED_DATA = 0x01
        }

        ///**
        // * @brief Navigator card peeking types
        // *
        // * This enumeration defines the type of peek that is executed when a card peek
        // * action is called. Peeking is the ability to see behind a card using a gesture
        // * to drag the card off screen and expose the card's parent or root (depending
        // * on the type of peek action). This determines if the peek applies to only
        // * the single parent of the card or to the entire stack.
        // */
        //typedef enum {
        //    /**
        //     * Indicates that the peek action is to the bottom of the card stack. The
        //     * root of the selected card is revealed.
        //     */
        //    NAVIGATOR_PEEK_ROOT             = 0,

        //    /**
        //     * Indicates that the peek action is to the previous card. The parent of the
        //     * selected card is revealed.
        //     */
        //    NAVIGATOR_PEEK_PARENT         = 1
        //} navigator_peek_type_t;
        public enum PeekType
        {
            NAVIGATOR_PEEK_ROOT = 0,
            NAVIGATOR_PEEK_PARENT = 1
        }

        ///**
        // * @brief Screen orientation modes
        // *
        // * This enumeration defines the different orientation modes that the screen of
        // * the device can be in.
        // *
        // * @anonenum bps_navigator_orientation_screen Navigator screen orientation
        // */
        //enum {
        //    /**
        //     * Indicates that the screen is in landscape mode (the longer sides of the
        //     * device are positioned at the bottom and top while the shorter sides are
        //     * on the sides).
        //     */
        //    NAVIGATOR_LANDSCAPE             = 0,

        //    /**
        //     * Indicates that the screen is in portrait mode. (the shorter sides of the
        //     * device are positioned at the bottom and top while the longer sides are
        //     * on the sides).
        //     */
        //    NAVIGATOR_PORTRAIT              = 1
        //};
        public enum OrientationScreen
        {
            NAVIGATOR_LANDSCAPE = 0,
            NAVIGATOR_PORTRAIT = 1
        }

        ///**
        // * @brief Application orientations
        // *
        // * This enumeration defines the different orentations that the application can
        // * be in relative to the screen of the device.
        // *
        // * @anonenum bps_navigator_orientation_application Navigator application
        // *           orientation
        // */
        //enum {
        //    /**
        //     * Indicate that the "top" edge of the application is facing up on the
        //     * screen (the application appears to be correctly oriented).
        //     */
        //    NAVIGATOR_TOP_UP                = 0,

        //    /**
        //     * Indicate that the "right" edge of the application is facing up on the
        //     * screen (the application appears to be lying on its left side).
        //     */
        //    NAVIGATOR_RIGHT_UP              = 90,

        //    /**
        //     * Indicate that the "bottom" edge of the application is facing up on the
        //     * screen (the application appears to be upside-down).
        //     */
        //    NAVIGATOR_BOTTOM_UP             = 180,

        //    /**
        //     * Indicate that the "left" edge of the application is facing up on the
        //     * screen (the application appears to be lying on its right side).
        //     */
        //    NAVIGATOR_LEFT_UP               = 270
        //};
        public enum OrientationApplication
        {
            NAVIGATOR_TOP_UP = 0,
            NAVIGATOR_RIGHT_UP = 90,
            NAVIGATOR_BOTTOM_UP = 180,
            NAVIGATOR_LEFT_UP = 270
        }

        ///**
        // * @brief Keyboard state
        // *
        // * This enumeration defines the different states the keyboard can be in.
        // */
        //typedef enum {
        //    /**
        //     * Indicates that the keyboard is in an unrecognized state (not one of the
        //     * states below).
        //     */
        //    NAVIGATOR_KEYBOARD_UNRECOGNIZED = 0,

        //    /**
        //     * Indicates that the keyboard is opening.
        //     */
        //    NAVIGATOR_KEYBOARD_OPENING      = 1,

        //    /**
        //     * Indicates that the keyboard is opened.
        //     */
        //    NAVIGATOR_KEYBOARD_OPENED       = 2,

        //    /**
        //     * Indicates that the keyboard is closing.
        //     */
        //    NAVIGATOR_KEYBOARD_CLOSING      = 3,

        //    /**
        //     * Indicates that the keyboard is closed.
        //     */
        //    NAVIGATOR_KEYBOARD_CLOSED       = 4,
        //} navigator_keyboard_state_t;
        public enum KeyboardState
        {
            NAVIGATOR_KEYBOARD_UNRECOGNIZED = 0,
            NAVIGATOR_KEYBOARD_OPENING = 1,
            NAVIGATOR_KEYBOARD_OPENED = 2,
            NAVIGATOR_KEYBOARD_CLOSING = 3,
            NAVIGATOR_KEYBOARD_CLOSED = 4,
        }

        ///**
        // * @brief Navigator window and icon badges
        // *
        // * This enumeration defines the different badges that can be applied to an
        // * application window and icon.
        // */
        //typedef enum {
        //    /**
        //     * Indicates that the badge is a splat. A splat appears as a white star in a
        //     * red circle.
        //     */
        //    NAVIGATOR_BADGE_SPLAT = 0
        //} navigator_badge_t;
        public enum BadgeType
        {
            Splat = 0
        }

        ///**
        // * @brief Device lock states
        // *
        // * This enumeration defines the different lock states that a device can be in.
        // */
        //typedef enum {
        //    /**
        //     * The device is unlocked.
        //     */
        //    NAVIGATOR_DEVICE_LOCK_STATE_UNLOCKED            = 0,

        //    /**
        //     * The device is locked.
        //     */
        //    NAVIGATOR_DEVICE_LOCK_STATE_SCREEN_LOCKED       = 1,

        //    /**
        //     * The device is locked, and a password is required to unlock.
        //     */
        //    NAVIGATOR_DEVICE_LOCK_STATE_PASSWORD_LOCKED     = 2,
        //} navigator_device_lock_state_t;
        public enum DeviceLockState
        {
            NAVIGATOR_DEVICE_LOCK_STATE_UNLOCKED = 0,
            NAVIGATOR_DEVICE_LOCK_STATE_SCREEN_LOCKED = 1,
            NAVIGATOR_DEVICE_LOCK_STATE_PASSWORD_LOCKED = 2,
        }

        ///**
        // * @brief Window cover transitions
        // *
        // * This enumeration defines the different transition effects that a window can
        // * perform when drawing the cover.
        // */
        //typedef enum {
        //    /**
        //     * Use the default effect when drawing the cover.
        //     */
        //    NAVIGATOR_WINDOW_COVER_TRANSITION_DEFAULT   = 0,

        //    /**
        //     * Don't use a transition effect when drawing the cover.
        //     */
        //    NAVIGATOR_WINDOW_COVER_TRANSITION_NONE      = 1,

        //    /**
        //     * Use a slide effect when drawing the cover.
        //     */
        //    NAVIGATOR_WINDOW_COVER_TRANSITION_SLIDE     = 2,

        //    /**
        //     * Use a fade effect when drawing the cover.
        //     */
        //    NAVIGATOR_WINDOW_COVER_TRANSITION_FADE      = 3,
        //} navigator_window_cover_transition_t;
        public enum WindowCoverTransition
        {
            NAVIGATOR_WINDOW_COVER_TRANSITION_DEFAULT = 0,
            NAVIGATOR_WINDOW_COVER_TRANSITION_NONE = 1,
            NAVIGATOR_WINDOW_COVER_TRANSITION_SLIDE = 2,
            NAVIGATOR_WINDOW_COVER_TRANSITION_FADE = 3,
        }
        #endregion

        // /**
        // * @brief The opaque invocation argument type
        // *
        // * This type defines the @c navigator_invoke_invocation_t structure used by
        // * several functions in the invocation framework. Use this to create and control
        // * invocations. The @c navigator_invoke_invocation_t structure is opaque, but
        // * includes the following members:
        // *     - @b ID: the ID used to identify the invocation
        // *              (@c navigator_invoke_invocation_set_id())
        // *     - @b Target: the target to which the invocation is sent
        // *              (@c navigator_invoke_invocation_set_target())
        // *     - @b Source: the location where response messages to the invocation
        // *              should be sent (@c navigator_invoke_invocation_set_source())
        // *     - @b Action: the action the invoked target should perform
        // *              (@c navigator_invoke_invocation_set_action())
        // *     - @b Type: the MIME type of the data the invoked target should act on
        // *              (@c navigator_invoke_invocation_set_type())
        // *     - @b URI: the URI to the data the invoked target should act on
        // *              (@c navigator_invoke_invocation_set_uri())
        // *     - @b Transfer @b mode: the transfer mode for the URI file
        // *              (@c navigator_invoke_invocation_set_file_transfer_mode())
        // *     - @b Data: the data the invoked target should act on
        // *              (@c navigator_invoke_invocation_set_data())
        // *     - @b Data @b length: the length of the data the invoked target should act
        // *              on (@c navigator_invoke_invocation_set_data())
        // *     - @b Perimeter: the perimeter the target should be invoked in
        // *              (@c navigator_invoke_invocation_set_perimeter())
        // *
        // * To perform an invocation, you must:
        // *     1. Instantiate a @c navigator_invoke_invocation_t structure with the @c
        // *        navigator_invoke_invocation_create() function.
        // *     2. Set all desired members with the @c
        // *        navigator_invoke_invocation_set_*() functions to match the purpose of
        // *        the @c invocation. A minimum of either a @c target, @c action, or @c
        // *        type member is required for the @c invocation to be recognised by the
        // *        framework (though further members may be required for more specific
        // *        invocations, such as including a @c uri or @c data member for
        // *        invocations that require input data to be successfully performed.)
        // *     3. Send the @c invocation with the @c navigator_invoke_invocation_send()
        // *        function. Depending on the members you set to the @c
        // *        navigator_invoke_invocation_t structure, the invocation is sent
        // *        either directly to a target handler or the brokering system to
        // *        determine which target to use based on the provided information.
        // *     4. Retrieve the data from an @c invocation in an event handler by using
        // *        the navigator_invoke_invocation_get_*() functions.
        // *     5. Deallocate the memory reserved for the @c
        // *        navigator_invoke_invocation_t structure with the @c
        // *        navigator_invoke_invocation_destroy() function.
        // */
        //typedef struct navigator_invoke_invocation_t navigator_invoke_invocation_t;

        ///**
        // * @brief The opaque query argument type
        // *
        // * This type defines the @c navigator_invoke_query_t structure used by several
        // * functions in the invocation framework. Use this to create and control
        // * queries. The @c navigator_invoke_query_t structure is opaque, but includes
        // * the following members:
        // *     - @b ID: the ID used to identify the query
        // *              (@c navigator_invoke_query_set_id())
        // *     - @b Action: the action query results should be able to perform
        // *              (@c navigator_invoke_query_set_action())
        // *     - @b Type: the MIME type the query results should be able to act on
        // *              (@c navigator_invoke_query_set_type())
        // *     - @b File @b URI: the URI to the type interface the query results should
        // *              be able to act on (@c navigator_invoke_query_get_file_uri())
        // *     - @b Target @b type: the type of targets the query should filter for
        // *              (@c navigator_invoke_query_set_target_type_mask())
        // *     - @b Action @b type: the type of actions the query should filter for
        // *              (@c navigator_invoke_query_set_action_type())
        // *     - @b Brokering @b mode: the brokering preferences of the query
        // *              (@c navigator_invoke_query_get_brokering_mode())
        // *     - @b Perimeter: the perimeter the query results should be invoked in
        // *              (@c navigator_invoke_query_set_perimeter())
        // *
        // * To perform an invocation query, you must:
        // *     1. Instantiate a @c navigator_invoke_query_t structure with the @c
        // *        navigator_invoke_query_create() function.
        // *     2. Set all desired members with the @c navigator_invoke_query_set_*()
        // *        functions to match the purpose of the @c query.
        // *     3. Send the @c query with the @c navigator_invoke_query_send()
        // *        function. The query is sent to the brokering system, which returns a
        // *        set of results that correspond to the @c navigator_invoke_query_t
        // *        structure parameters.
        // *     4. Deallocate the memory reserved for the @c navigator_invoke_query_t
        // *        structure with the @c navigator_invoke_query_destroy() function.
        // */
        //typedef struct navigator_invoke_query_t navigator_invoke_query_t;

        ///**
        // * @brief The opaque query result action argument type
        // *
        // * This type defines the @c navigator_invoke_query_result_action_t structure
        // * used by several functions in the invocation framework. Use this to retrieve
        // * actions returned from invocation query results. The @c
        // * navigator_invoke_query_result_action_t structure is opaque, but includes the
        // * following members:
        // *     - @b Name: the name of the action
        // *                (@c navigator_invoke_query_result_action_get_name())
        // *     - @b Icon: an image associated with the action
        // *                (@c navigator_invoke_query_result_action_get_icon())
        // *     - @b Label: the label or name associated with the action
        // *                (@c navigator_invoke_query_result_action_get_label())
        // *     - @b Default @b target: the target that will provide this action by
        // *                default
        // *                (@c navigator_invoke_query_result_action_get_default_target())
        // *     - @b Target @b count: the number of viable targets that can perform the
        // *                action (@c navigator_invoke_query_result_action_get_target())
        // *     - @b Targets: an array of all viable targets that can perform the
        // *                action (@c navigator_invoke_query_result_action_get_target())
        // *
        // * The @c navigator_invoke_query_result_action_t structure is returned by an
        // * invocation query. Extract values from this structure using the @c
        // * navigator_invoke_query_result_action_get_*() functions.
        // */
        //typedef struct navigator_invoke_query_result_action_t navigator_invoke_query_result_action_t;

        ///**
        // * @brief The opaque query result target argument type
        // *
        // * This type defines the @c navigator_invoke_query_result_target_t structure
        // * used by several functions in the invocation framework. Use this to retrieve
        // * targets returned from invocation query results, and contained within @c
        // * navigator_invoke_query_result_action_t structures. The @c
        // * navigator_invoke_query_result_target_t structure is opaque, but includes the
        // * following members:
        // *     - @b Key: the name of the target
        // *               (@c navigator_invoke_query_result_target_get_key())
        // *     - @b Icon: an image associated with the target
        // *               (@c navigator_invoke_query_result_target_get_icon())
        // *     - @b Splash: an image to be displayed by a target when loading
        // *               (@c navigator_invoke_query_result_target_get_splash())
        // *     - @b Label: the label or name associated with the target
        // *               (@c navigator_invoke_query_result_target_get_label())
        // *     - @b Type: the target's type
        // *               (@c navigator_invoke_query_result_target_get_type())
        // *     - @b Perimeter: the perimeter in which the target should reside
        // *               (@c navigator_invoke_query_result_target_get_perimeter())
        // *
        // * The @c navigator_invoke_query_result_target_t structures are contained within
        // * @c navigator_invoke_query_result_action_t structures that are returned by an
        // * invocation query. Extract values from this structure using the @c
        // * navigator_invoke_query_result_target_get_*() functions.
        // */
        //typedef struct navigator_invoke_query_result_target_t navigator_invoke_query_result_target_t;

        ///**
        // * @brief The opaque viewer argument type
        // *
        // * This type defines the @c navigator_invoke_viewer_t structure used by several
        // * functions in the invocation framework. Use this to create and control
        // * viewers. The @c navigator_invoke_viewer_t structure is opaque, but includes
        // * the following members:
        // *     - @b Invocation: the invocation associated with the viewer
        // *                 (@c navigator_invoke_viewer_create())
        // *     - @b Window @b ID: the ID used to identify the viewer
        // *                 (@c navigator_invoke_viewer_set_window_id())
        // *     - @b Width: the width of the viewer
        // *                 (@c navigator_invoke_viewer_set_width())
        // *     - @b Height: the height of the viewer
        // *                 (@c navigator_invoke_viewer_set_height())
        // *
        // * To create an invocation viewer, you must:
        // *     1. Instantiate a @c navigator_invoke_viewer_t structure with the @c
        // *        navigator_invoke_viewer_create() function.
        // *     2. Set all desired members with the @c navigator_invoke_viewer_set_*()
        // *        functions to match the purpose of the @c viewer.
        // *     3. Send the @c viewer with the @c navigator_invoke_viewer_send()
        // *        function. The invocation is sent to an event handler, triggering the
        // *        NAVIGATOR_INVOKE_VIEWER event.
        // *     4. Retrieve the data from a @c viewer in an event handler by using
        // *        the navigator_invoke_viewer_get_*() functions, within this, further
        // *        data from the invocation can be retrieved through the @c
        // *        navigator_invoke_invocation_t structure using the @c
        // *        navigator_invoke_viewer_get_invocation() function followed by the @c
        // *        navigator_invoke_invocation_get_*() functions.
        // *     5. Deallocate the memory reserved for the @c navigator_invoke_viewer_t
        // *        with the @c navigator_invoke_viewer_destroy() function.
        // */
        //typedef struct navigator_invoke_viewer_t navigator_invoke_viewer_t;

        #region Enumerators Invoke
        ///**
        // * @brief The possible invocation target types
        // *
        // * This enumeration defines the possible types of targets to query for with the
        // * @c navigator_invoke_query_t structure. This is used by the brokering system
        // * to filter for targets that are of the given type.
        // */
        //typedef enum {
        //    /**
        //     * Indicates that the target type is unspecified.
        //     */
        //    NAVIGATOR_INVOKE_TARGET_TYPE_UNSPECIFIED = 0x00,
        //    /**
        //     * Indicates that the target is an application. Applications are software
        //     * designed to perform specific tasks.
        //     */
        //    NAVIGATOR_INVOKE_TARGET_TYPE_APPLICATION = 0x01,
        //    /**
        //    * Indicates that the target is a card. Cards are compact windows that allow
        //    * an application to expose functionality so that it can be imported in to
        //    * the flow of another application. Cards may be stacked multiple layers
        //    * when one card uses another. However, each layer of the stack can stack
        //    * only one child card at a time. For example, the Universal Inbox list may
        //    * stack a card to preview an email message. The message card may in turn
        //    * stack a card to preview an image attachment. The attachment card may
        //    * then also stack a card to share the image, and so on. The peeking
        //    * feature exclusive to cards allows users to "peek" back behind the current
        //    * card to reveal its parent's content using a swipe gesture. Peeking is
        //    * handled in the Navigator API.
        //    */
        //   NAVIGATOR_INVOKE_TARGET_TYPE_CARD        = 0x02,
        //   /**
        //    * Indicates that the target is a viewer. Viewers are embedded applications
        //    * that can render a certain content type (images for example). They appear
        //    * as part of the root application rather than as a separate application.
        //    */
        //    NAVIGATOR_INVOKE_TARGET_TYPE_VIEWER      = 0x04,
        //    /**
        //     * Indicates that the target is a service. The meaning of a service value is
        //     * reserved for future use.
        //     */
        //    NAVIGATOR_INVOKE_TARGET_TYPE_SERVICE     = 0x08
        //} navigator_invoke_target_type_t;
        [Flags]
        public enum TargetType
        {
            NAVIGATOR_INVOKE_TARGET_TYPE_UNSPECIFIED = 0x00,
            NAVIGATOR_INVOKE_TARGET_TYPE_APPLICATION = 0x01,
            NAVIGATOR_INVOKE_TARGET_TYPE_CARD = 0x02,
            NAVIGATOR_INVOKE_TARGET_TYPE_VIEWER = 0x04,
            NAVIGATOR_INVOKE_TARGET_TYPE_SERVICE = 0x08
        }

        ///**
        // * @brief The possible invocation query action type values
        // *
        // * This enumeration defines the possible types of actions to query for with the
        // * @c navigator_invoke_query_t structure. This is used by the brokering system
        // * to filter for targets that use the given action type.
        // */
        //typedef enum {
        //    /**
        //     * Indicates that the query action type is unspecified.
        //     */
        //    NAVIGATOR_INVOKE_QUERY_ACTION_TYPE_UNSPECIFIED = 0,
        //    /**
        //     * Indicates that the query results are filtered to only include those
        //     * that support menu actions. Menu actions have a defined icon and label
        //     * associated with them.
        //     */
        //    NAVIGATOR_INVOKE_QUERY_ACTION_TYPE_MENU        = 1,
        //    /**
        //     * Indicates that the query results include all viable targets regardless of
        //     * their action type(s).
        //     */
        //    NAVIGATOR_INVOKE_QUERY_ACTION_TYPE_ALL         = 2
        //} navigator_invoke_query_action_type_t;
        public enum QueryActionType
        {
            NAVIGATOR_INVOKE_QUERY_ACTION_TYPE_UNSPECIFIED = 0,
            NAVIGATOR_INVOKE_QUERY_ACTION_TYPE_MENU = 1,
            NAVIGATOR_INVOKE_QUERY_ACTION_TYPE_ALL = 2
        }

        ///**
        // * The possible application perimeter type values
        // *
        // * This enumeration defines the possible types of perimeters in which a targeted
        // * or queried application can reside. This is used to determine where a target
        // * application should invoke, primarily in cases where the application is a
        // * "hybrid" that can run in both enterprise and personal perimeters.
        // */
        //typedef enum {
        //    /**
        //     * Indicates that the perimeter type is unspecified.
        //     */
        //    NAVIGATOR_INVOKE_PERIMETER_TYPE_UNSPECIFIED = 0,
        //    /**
        //     * Indicates that the application should run in the personal perimeter.
        //     */
        //    NAVIGATOR_INVOKE_PERIMETER_TYPE_PERSONAL    = 1,
        //    /**
        //     * Indicates that the application should run in the enterprise perimeter.
        //     */
        //    NAVIGATOR_INVOKE_PERIMETER_TYPE_ENTERPRISE  = 2
        //} navigator_invoke_perimeter_type_t;
        public enum PerimeterType
        {
            NAVIGATOR_INVOKE_PERIMETER_TYPE_UNSPECIFIED = 0,
            NAVIGATOR_INVOKE_PERIMETER_TYPE_PERSONAL = 1,
            NAVIGATOR_INVOKE_PERIMETER_TYPE_ENTERPRISE = 2
        }

        ///**
        // * @brief The possible transfer modes for files specified in invocation requests
        // *
        // * This enumeration defines the supported modes for handling file transfer when
        // * a file:// URI is provided that does not point to a file in the shared area.
        // * Unless @c NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_LINK is specified, file transfer
        // * handling will transfer the file via the target's private inbox.
        // */
        //typedef enum {
        //    /**
        //     * Indicates that the file transfer mode has not been specified and the
        //     * default logic should apply
        //     */
        //    NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_UNSPECIFIED = 0,
        //    /**
        //     * Indicates that the file transfer handling should be skipped and the
        //     * specified file URI should be passed to the target as-is
        //     */
        //    NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_PRESERVE    = 1,
        //    /**
        //     * Indicates that the file should be transfered as a read only copy of the
        //     * file specified in the URI attribute
        //     */
        //    NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_COPY_RO     = 2,
        //    /**
        //     * Indicates that the file should be transfered as a read/write copy of the
        //     * file specified in the URI attribute.
        //     */
        //    NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_COPY_RW     = 3,
        //    /**
        //     * Indicates that the file should be transfered as a link to the file
        //     * specified in the URI attribute. Note that link mode requires that the
        //     * original file support o+r. In addition, if the file has o+w then the
        //     * sender must be the owner of the file.
        //     */
        //    NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_LINK        = 4
        //} navigator_invoke_file_transfer_mode_t;
        public enum FileTransferMode
        {
            NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_UNSPECIFIED = 0,
            NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_PRESERVE = 1,
            NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_COPY_RO = 2,
            NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_COPY_RW = 3,
            NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_LINK = 4
        }
        #endregion
    }
}
