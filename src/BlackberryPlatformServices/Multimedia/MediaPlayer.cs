using System;

namespace BlackberryPlatformServices
{
    public class MediaPlayer
    {
        #region Enumerators
        /**
 * @brief Media player events
 *
 * This enumeration defines the available Media player events.
 * @anonenum bps_mediaplayer_events Media player events
 */
        public enum MediaPlayerButton
        {
            /**
             * An acquired request has been processed.
             */
            MEDIAPLAYER_ACQUIRE_RESULT = 1,

            /**
             * The player's state as the active media player in the
             * system is being revoked. The player should immediately stop playback and
             * free up multimedia resources.
             */
            MEDIAPLAYER_REVOKE = 2,

            /**
             * Requests the media player to handle a command.
             */
            MEDIAPLAYER_COMMAND = 3,

            /**
             * A button has been pressed.
             */
            MEDIAPLAYER_BUTTON = 4,

            /**
             * A release request has been processed.
             */
            MEDIAPLAYER_RELEASE_RESULT = 5,

            /**
             * A register request has been processed.
             */
            MEDIAPLAYER_REGISTER_RESULT = 6,

            /**
             * A button registration request has been processed.
             */
            MEDIAPLAYER_BUTTON_RESULT = 7,
        };
        #endregion

        #region DllImport
        /**
         * A data type that represents the structure for storing metadata for media.
         */
        //typedef struct mediaplayer_metadata_t mediaplayer_metadata_t;

        /**
         * @brief Start receiving Media player events
         *
         * The @c mediaplayer_request_events() function starts to deliver Media player
         * events to your application using BlackBerry Platform Services (BPS). Events
         * will be posted to the currently active channel.
         *
         * @param flags Additional flags that are reserved for future use. Set this
         *              value to 0 to request all Media player events.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_request_events(int flags);

        /**
         * @brief Stop receiving Media player events
         *
         * The @c mediaplayer_stop_events() function stops Media player events from
         * being delivered to your application using BlackBerry Platform Services (BPS).
         *
         * @param flags Additional flags that are reserved for future use. Set this
         *              value to 0 to stop Media player events from being delivered to
         *              your application.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_stop_events(int flags);

        /**
         * @brief Retrieve the unique domain ID for the Media Player service
         *
         * The @c mediaplayer_get_domain() function gets the unique domain ID for the
         * Media Player service. You can use this function in your application to
         * determine whether an event that you retrieve using the @c bps_get_event()
         * function is a Media player event, and respond accordingly.
         *
         * @return The domain ID for the Media Player service.
         */
        public static extern int mediaplayer_get_domain();

        /**
         * @brief Acquire the status of active media player in the system
         *
         * The @c mediaplayer_acquire() function requests that the system establish the
         * calling player as the active media player in the system.  The previous active
         * media player (if any) will have its active state revoked.  To support the
         * cooperative rules of engagement, media players must send acquire before they
         * begin media playback, to allow other players to stop playback.  Media players
         * should only do this on an explicit action by the user (the user pressed the
         * play button or just launched the player).
         *
         * @param id If not @c NULL, the ID used in the acquire request will be returned
         *           in @c id.  The caller must free this buffer using @c bps_free().
         *           This same ID will be delivered in the corresponding @c
         *           MEDIAPLAYER_ACQUIRE_RESULT event.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_acquire(ref IntPtr id);

        /**
         * @brief Release the status of the active media player in the system
         *
         * The @c mediaplayer_release() function notifies the system that the calling
         * player is relinquishing its status as the active media player in the system.
         * If the calling player is a higher priority player than any previously active
         * media player that is currently paused, then the higher priority player is
         * acquired and given active status.
         *
         * @param id If not @c NULL, the ID used in the release request will be returned
         *           in @c id.  The caller must free this buffer using @c bps_free().
         *           This same ID will be delivered in the corresponding @c
         *           MEDIAPLAYER_RELEASE_RESULT event.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_release(ref IntPtr id);

        /**
         * @brief Register the media player
         *
         * The @c mediaplayer_register() function registers the media player.
         *
         * @param name The descriptive name.
         * @param priority The priority, one of the values of the @c media_priority_t
         *                 enumeration.
         * @param audio_type The audio type, one of the values of the @c
         *                   media_audio_type_t enumeration.
         * @param volume_overlay The volume overlay, one of the values of the @c
         *                       media_volume_overlay_t enumeration.
         * @param id If not @c NULL, the ID used in the register request is returned in
         *           the @c id argument. The caller must free this buffer using the @c
         *           bps_free() function.  This same ID will be delivered in the
         *           corresponding @c MEDIAPLAYER_REGISTER_RESULT event.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_register(char[] name, int priority, int audio_type, int volume_overlay, ref IntPtr id);

        /**
         * @brief Register a button to an invocation framework target or a forwarding
         *        action.
         *
         * The @c mediaplayer_button() function registers a button to an invocation
         * framework target or a forwarding action.
         *
         * @param button1 The first button, must be one of the values of the @c
         *                media_button_t enumeration. This value cannot be @c
         *                MEDIA_BUTTON_NONE.
         * @param button2 The optional second button, must be one of the values of the
         *                @c media_button_t enumeration. If the value is not @c
         *                MEDIA_BUTTON_NONE, the function registers the action to be
         *                taken when the user presses @c button1 and @c button2
         *                simultaneously.
         * @param length The length of the button press. Use one of the values of
         *               the @c media_button_length_t enumeration.
         * @param action The action. Use one of the values of the @c media_action_t
         *               enumeration. If you use @c MEDIA_ACTION_LAUNCH, the button is
         *               registered as an invocation framework target, and requires that
         *               you specify a value for the @c path argument. If you use a
         *               value of @c MEDIA_ACTION_FORWARD, the button notifications are
         *               forwarded to the application as @c
         *               MEDIA_BUTTON events and the @c path argument should not be
         *               specified.
         * @param path The path, which is only required when @c action is @c
         *             MEDIA_ACTION_LAUNCH, not required otherwise.
         * @param id When this is not a @c NULL value, the ID used in the button request
         *           is returned when the function completes. The caller must free this
         *           buffer using the @c bps_free() function. The same ID is also
         *           delivered in the corresponding @c MEDIAPLAYER_BUTTON_RESULT event.
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_button(int button1, int button2, int length, int action, char[] path, ref IntPtr id);

        /**
         * @brief Set the state of the media player
         *
         * The @c mediaplayer_set_state() function sets the state of the media player to
         * a given state.
         *
         * @param state The state to set the media player to, must be one of the value
         *              of the @c media_state_t enumeration.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_set_state(int state);

        /**
         * @brief Create a metadata structure
         *
         * The @c mediaplayer_metadata_create() function creates a metadata structure.
         *
         * @param metadata The @c mediaplayer_metadata_t structure to populate.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_metadata_create(out IntPtr metadata);

        /**
         * @brief Destroy a metadata structure
         *
         * The @c mediaplayer_metadata_destroy() function destroys a metadata structure.
         *
         * @param metadata The @c mediaplayer_metadata_t structure to destroy.
         */
        public static extern void mediaplayer_metadata_destroy(out IntPtr metadata);

        /**
         * @brief Set the artist in a metadata structure.
         *
         * The @c mediaplayer_metadata_set_artist() function sets the artist in the
         * given metadata structure.
         *
         * @param metadata The @c mediaplayer_metadata_t structure to update.
         *
         * @param artist The artist.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_metadata_set_artist(IntPtr metadata, char[] artist);

        /**
         * @brief Set the album in a metadata structure.
         *
         * The @c mediaplayer_metadata_set_album() function sets the album in the given
         * metadata structure.
         *
         * @param metadata The @c mediaplayer_metadata_t structure to update.
         *
         * @param album The album.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_metadata_set_album(IntPtr metadata, char[] album);

        /**
         * @brief Set the track in a metadata structure.
         *
         * The @c mediaplayer_metadata_set_track() function sets the track in the given
         * metadata structure.
         *
         * @param metadata The @c mediaplayer_metadata_t structure to update.
         *
         * @param track The track.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_metadata_set_track(IntPtr metadata, char[] track);

        /**
         * @brief Set the position in a metadata structure.
         *
         * The @c mediaplayer_metadata_set_position() function sets the position in the
         * given metadata structure.
         *
         * @param metadata The @c mediaplayer_metadata_t structure to update.
         *
         * @param position The position.  Use a negative number to leave position
         *                 unspecified.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_metadata_set_position(IntPtr metadata, int position);

        /**
         * @brief Set the duration in a metadata structure.
         *
         * The @c mediaplayer_metadata_set_duration() function sets the duration in the
         * given metadata structure.
         *
         * @param metadata The @c mediaplayer_metadata_t structure to update.
         *
         * @param duration The duration.  Use a negative number to leave duration
         *                 unspecified.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_metadata_set_duration(IntPtr metadata, int duration);

        /**
         * @brief Set the album artwork in a metadata structure.
         *
         * The @c mediaplayer_metadata_set_album_artwork() function sets the album
         * artwork in the given metadata structure.
         *
         * @param metadata The @c mediaplayer_metadata_t structure to update.
         *
         * @param album_artwork The album artwork.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        public static extern int mediaplayer_metadata_set_album_artwork(IntPtr metadata, char[] album_artwork);

        /**
         * @brief Sets the metadata of the currently playing track.
         *
         * The @c mediaplayer_set_metadata() function sets the metadata of the currently
         * playing track.
         *
         * @param metadata The metadata of the currently playing track.
         *
         * @return @c BPS_SUCCESS when the function completes successfully, @c
         *         BPS_FAILURE with @c errno value set otherwise.
         */
        public static extern int mediaplayer_set_metadata(IntPtr metadata);

        /**
         * @brief Retrieve the ID from a Media player event
         *
         * The @c mediaplayer_event_get_id() function extracts the ID from the specified
         * Media player event.
         *
         * @param event The Media player event to extract the ID from.
         * @return The ID of the Media player event.
         */
        public static extern char[] mediaplayer_event_get_id(IntPtr _event);

        /**
         * @brief Retrieve the command from the @c MEDIAPLAYER_COMMAND event
         *
         * The @c mediaplayer_event_get_command() function extracts the command from the
         * specified @c MEDIAPLAYER_COMMAND event.
         *
         * @param event The @c MEDIAPLAYER_COMMAND event to extract the command from.
         *
         * @return The command, one of the values of the @c media_command_t enumeration,
         *         or @c BPS_FAILURE with @c errno value set on error.
         */
        public static extern int mediaplayer_event_get_command(IntPtr _event);

        /**
         * @brief Retrieve the first button from the @c MEDIAPLAYER_BUTTON event
         *
         * The @c mediaplayer_event_get_button1() function extracts the first button
         * from the specified @c MEDIAPLAYER_BUTTON event.
         *
         * @param event The @c MEDIAPLAYER_BUTTON event to extract the button from.
         *
         * @return The first button, one of the values of the @c media_button_t
         *         enumeration, or @c BPS_FAILURE with @c errno value set on error.
         */
        public static extern int mediaplayer_event_get_button1(IntPtr _event);

        /**
         * @brief Retrieve the second button from the @c MEDIAPLAYER_BUTTON event
         *
         * The @c mediaplayer_event_get_button2() function extracts the second button
         * from the specified @c MEDIAPLAYER_BUTTON event.
         *
         * @param event The @c MEDIAPLAYER_BUTTON event to extract the button from.
         *
         * @return The second button, one of the values of the @c media_button_t
         *         enumeration, or @c BPS_FAILURE with @c errno value set on error.
         */
        public static extern int mediaplayer_event_get_button2(IntPtr _event);

        /**
         * @brief Retrieve the button length of time a button was held down from the
         *        @c MEDIAPLAYER_BUTTON event
         *
         * The @c mediaplayer_event_get_button_length() function extracts the length of
         * time the button was held down from the specified @c MEDIAPLAYER_BUTTON event.
         *
         * @param event The @c MEDIAPLAYER_BUTTON event to extract the length from.
         *
         * @return The length, one of the values of the @c media_button_length_t
         *         enumeration, or @c BPS_FAILURE with @c errno value set on error.
         */
        public static extern int mediaplayer_event_get_button_length(IntPtr _event);
        #endregion
    }
}
