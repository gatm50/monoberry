using System;
using System.Runtime.InteropServices;

namespace BlackberryPlatformServices
{
    public class MediaController
    {
        #region Enumerators
        /**
         * @brief Media Controller events
         *
         * This enumeration defines the available Media Controller events.
         * @anonenum bps_mediacontroller_events Media controller events
         */
        public enum MediaControllerEvents
        {

            /**
             * The active player's state has changed.
             */
            MEDIACONTROLLER_STATE = 1,
            /**
             * The active player's metadata has changed.
             */
            MEDIACONTROLLER_METADATA = 2,
        };
        #endregion

        #region DllImport
        /**
         * @brief Start receiving Media Controller events
         *
         * The @c mediacontroller_request_events() function starts to deliver Media
         * Controller events to your application using BlackBerry Platform Services
         * (BPS). Events are posted to the currently active channel.
         *
         * @param flags Additional flags that are reserved for future use. Set this
         *              value to 0 to request all Media Controller events.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_request_events(int flags);

        /**
         * @brief Stop receiving Media Controller events
         *
         * The @c mediacontroller_stop_events() function stops Media Controller events
         * from being delivered to your application using BlackBerry Platform Services
         * (BPS).
         *
         * @param flags Additional flags that are reserved for future use. Set this
         *              value to 0 to stop Media Controller events from being delivered
         *              to your application.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_stop_events(int flags);

        /**
         * @brief Retrieve the unique domain ID for the Media Controller service
         *
         * The @c mediacontroller_get_domain() function gets the unique domain ID for
         * the Media Controller service.  You can use this function in your application
         * to determine whether an event that you receive using the @c bps_get_event()
         * function is a Media Controller event, and respond accordingly.
         *
         * @return The domain ID for the Media Controller service.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_get_domain();

        /**
         * @brief Set the volume level
         *
         * The @c mediacontroller_volume_set_level() function sets the volume to the
         * given level.
         *
         * @param level The level to set the volume to. You specify the level as a
         *              percentage value, such as 50 or 75.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_volume_set_level(float level);

        /**
         * @brief Increase the volume level
         *
         * The @c mediacontroller_volume_up() function increases the volume level.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_volume_up();

        /**
         * @brief Decrease the volume level
         *
         * The @c mediacontroller_volume_down() function decreases the volume level.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_volume_down();

        /**
         * @brief Set the volume mute state
         *
         * The @c mediacontroller_volume_set_mute() function sets the volume mute state
         * to the given mute state.
         *
         * @param mute The state to set the volume mute to.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_volume_set_mute(bool mute);

        /**
         * @brief Play the current media content
         *
         * The @c mediacontroller_play() function directs the connected media player to
         * play its content.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_play();

        /**
         * @brief Pause the current media content
         *
         * The @c mediacontroller_pause() function directs the connected media player to
         * pause playing content.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_pause();

        /**
         * @brief Play or pause the current media content
         *
         * The @c mediacontroller_play() function directs the connected media player to
         * play or pause its content accordingly.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_play_pause();

        /**
         * @brief Stop the current media content
         *
         * The @c mediacontroller_stop() function directs the connected media player to
         * stop playing content.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_stop();

        /**
         * @brief Skip to the next track
         *
         * The @c mediacontroller_next_track() function directs the connected media
         * player to skip to the next track.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_next_track();

        /**
         * @brief Skip to the beginning of the current track, or to the previous track
         *
         * The @c mediacontroller_previous_track() function directs the connected media
         * player to skip to the beginning of the current track, or to the previous
         * track.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_previous_track();

        /**
         * @brief Fast-forward the media
         *
         * The @c mediacontroller_fast_forward() function directs the connected media
         * player to enter fast forward mode.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_fast_forward();

        /**
         * @brief Rewind the media
         *
         * The @c mediacontroller_rewind() function directs the connected media player
         * to enter rewind mode.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_rewind();

        /**
         * @brief Send a button-down message
         *
         * The @c mediacontroller_button_down() function sends a button down message to
         * the connected media player.
         *
         * @param button The button for which the button down message is sent, must be
         *               one of the values of the @c media_button_t enum, not including
         *               @c MEDIA_BUTTON_NONE nor @c MEDIA_BUTTON_HOOK_SWITCH.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_button_down(int button);

        /**
         * @brief Send a button-up message
         *
         * The @c mediacontroller_button_up() function sends a button up message to the
         * connected media player.
         *
         * @param button The button for which the button up message is sent, must be one
         *               of the values of the @c media_button_t enum, not including @c
         *               MEDIA_BUTTON_NONE nor @c MEDIA_BUTTON_HOOK_SWITCH.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_button_up(int button);

        /**
         * @brief Retrieve the state of the Media Controller from the @c
         *        MEDIACONTROLLER_STATE event
         *
         * The @c mediacontroller_event_get_state() function extracts the current state
         * from the specified @c MEDIACONTROLLER_STATE event.
         *
         * @param event The @c MEDIACONTROLLER_STATE event to extract the current state
         *              from. The state will be one of the values from the @c
         *              media_state_t enumeration.
         *
         * @return The current state.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_event_get_state(IntPtr _event);

        /**
         * @brief Retrieve the artist from the @c MEDIACONTROLLER_METADATA event
         *
         * The @c mediacontroller_event_get_metadata_artist() function extracts the
         * artist from the specified @c MEDIACONTROLLER_METADATA event.
         *
         * @param event The @c MEDIACONTROLLER_METADATA event to extract the artist
         *              from.
         *
         * @return The string representing an artist, or @c a NULL value if the artist
         *         was not available or specified.
         */
        [DllImport("bps")]
        public static extern char[] mediacontroller_event_get_metadata_artist(IntPtr _event);

        /**
         * @brief Retrieve the album from the @c MEDIACONTROLLER_METADATA event
         *
         * The @c mediacontroller_event_get_metadata_album() function extracts the album
         * from the specified @c MEDIACONTROLLER_METADATA event.
         *
         * @param event The @c MEDIACONTROLLER_METADATA event to extract the album from.
         *
         * @return The string representing an album, or @c a NULL value if the album
         *         was not available or specified.
         */
        [DllImport("bps")]
        public static extern char[] mediacontroller_event_get_metadata_album(IntPtr _event);

        /**
         * @brief Retrieve the track from the @c MEDIACONTROLLER_METADATA event
         *
         * The @c mediacontroller_event_get_metadata_track() function extracts the track
         * from the specified @c MEDIACONTROLLER_METADATA event.
         *
         * @param event The @c MEDIACONTROLLER_METADATA event to extract the track from.
         *
         * @return The string representing an track, or @c a NULL value if the track
         *         was not available or specified.
         */
        [DllImport("bps")]
        public static extern char[] mediacontroller_event_get_metadata_track(IntPtr _event);

        /**
         * @brief Retrieve the current position in the track from the @c
         *        MEDIACONTROLLER_METADATA event
         *
         * The @c mediacontroller_event_get_metadata_position() function extracts the
         * position in the track from the specified @c MEDIACONTROLLER_METADATA event.
         *
         * @param event The @c MEDIACONTROLLER_METADATA event to extract the position
         *              from.
         *
         * @return The position of the track (in milliseconds), a negative number
         *         indicates position was not specified.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_event_get_metadata_position(IntPtr _event);

        /**
         * @brief Retrieve the duration from the @c MEDIACONTROLLER_METADATA event
         *
         * The @c mediacontroller_event_get_metadata_duration() function extracts the
         * duration from the specified @c MEDIACONTROLLER_METADATA event.
         *
         * @param event The @c MEDIACONTROLLER_METADATA event to extract the duration
         *              from.
         *
         * @return The duration  of the track (in milliseconds), a negative number
         *         indicates duration was not specified.
         */
        [DllImport("bps")]
        public static extern int mediacontroller_event_get_metadata_duration(IntPtr _event);

        /**
         * @brief Retrieve the path to the album artwork from the @c
         *        MEDIACONTROLLER_METADATA event
         *
         * The @c mediacontroller_event_get_metadata_album_artwork() function extracts
         * the path to the album artwork from the specified @c MEDIACONTROLLER_METADATA
         * event.
         *
         * @param event The @c MEDIACONTROLLER_METADATA event to extract the path to the
         *              album artwork from.
         *
         * @return The string representing the path to the album artwork, or @c a NULL
         *         value if the album artwork was not available.
         */
        [DllImport("bps")]
        public static extern char[] mediacontroller_event_get_metadata_album_artwork(IntPtr _event);
        #endregion
    }
}
