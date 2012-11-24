
namespace BlackberryPlatformServices
{
    public class MediaCommonEnumerators
    {
        /**
 * @brief Media commands
 *
 * This enumeration defines the available media commands.
 */
        public enum MediaCommandType
        {
            /**
             * An unrecognized media command (not one listed below).
             */
            MEDIA_COMMAND_UNRECOGNIZED = 0,

            /**
             * Request to play the current track.
             */
            MEDIA_COMMAND_PLAY = 1,

            /**
             * Request to pause the current track.
             */
            MEDIA_COMMAND_PAUSE = 2,

            /**
             * Request to stop the current track.
             */
            MEDIA_COMMAND_STOP = 3,

            /**
             * Request to skip to the next track.
             */
            MEDIA_COMMAND_NEXT_TRACK = 4,

            /**
             * Request to skip to the beginning of the current track,
             * or to the previous track.
             */
            MEDIA_COMMAND_PREVIOUS_TRACK = 5,

            /**
             * Request to start or resume sending metadata updates.
             */
            MEDIA_COMMAND_SEND_DATA = 6,

            /**
             * Request to stop sending metadata updates.
             */
            MEDIA_COMMAND_HOLD_DATA = 7,

            /**
             * Request to enter fast forward mode.
             */
            MEDIA_COMMAND_FAST_FORWARD = 8,

            /**
             * Request to enter rewind mode.
             */
            MEDIA_COMMAND_REWIND = 9,
        };

        /**
         * @brief Media states
         *
         * This enumeration defines the available media states.
         */
        public enum MediaStateType
        {
            /**
             * An unrecognized media state (not one listed below).
             */
            MEDIA_STATE_UNRECOGNIZED = 0,

            /**
             * The media is stopped.
             */
            MEDIA_STATE_STOPPED = 1,

            /**
             * The media is paused.
             */
            MEDIA_STATE_PAUSED = 2,

            /**
             * The media is playing.
             */
            MEDIA_STATE_PLAYING = 3,

            /**
             * The media has changed track.
             */
            MEDIA_STATE_TRACK_CHANGE = 4,
        } ;

        /**
         * @brief Media priorities
         *
         * This enumeration defines the available media priorities.
         */
        public enum MediaPriorityType
        {
            /**
             * The media has low priority.
             */
            MEDIA_PRIORITY_LOW = 0,

            /**
             * The media has high priority. Only phone or VoIP applications should use
             * a high priority.
             */
            MEDIA_PRIORITY_HIGH = 1,
        } ;

        /**
         * @brief Media audio types
         *
         * This enumeration defines the available media audio types.
         */
        public enum MediaAudioType
        {
            /**
             * The media is a general audio type.
             */
            MEDIA_AUDIO_TYPE_GENERAL = 0,

            /**
             * The media is a voice audio type.  Only phone or VoIP applications should
             * use the voice audio type.
             */
            MEDIA_AUDIO_TYPE_VOICE = 1,
        } ;

        /**
         * @brief Media volume overlays
         *
         * This enumeration defines the available media volume overlays.
         */
        public enum MediaVolumeOverlayType
        {
            /**
             * The plain volume overlay.
             */
            MEDIA_VOLUME_OVERLAY_PLAIN = 0,

            /**
             * The fancy volume overlay, which has next and previous buttons.
             */
            MEDIA_VOLUME_OVERLAY_FANCY = 1,
        } ;

        /**
         * @brief Media buttons
         *
         * This enumeration defines the available media buttons.
         */
        public enum MediaButtonType
        {
            /**
             * No button.
             */
            MEDIA_BUTTON_NONE = 0,

            /**
             * Plus button.
             */
            MEDIA_BUTTON_PLUS = 1,

            /**
             * Minus button.
             */
            MEDIA_BUTTON_MINUS = 2,

            /**
             * Volume up button.
             */
            MEDIA_BUTTON_VOLUME_UP = 3,

            /**
             * Volume down button.
             */
            MEDIA_BUTTON_VOLUME_DOWN = 4,

            /**
             * Play button.
             */
            MEDIA_BUTTON_PLAY = 5,

            /**
             * Pause button.
             */
            MEDIA_BUTTON_PAUSE = 6,

            /**
             * Play/Pause button.
             */
            MEDIA_BUTTON_PLAY_PAUSE = 7,

            /**
             * Stop button.
             */
            MEDIA_BUTTON_STOP = 8,

            /**
             * Forward button.
             */
            MEDIA_BUTTON_FORWARD = 9,

            /**
             * Rewind button.
             */
            MEDIA_BUTTON_REWIND = 10,
        } ;

        /**
         * @brief Timeframes a media button is held down for
         *
         * This enumeration defines the length of time a media button can be held down
         * for.
         */
        public enum MediaButtonLengthType
        {
            /**
             * An unrecognized length (not one listed below).
             */
            MEDIA_BUTTON_LENGTH_UNRECOGNIZED = 0,

            /**
             * The button is held for a short length of time (less than 350 ms).
             */
            MEDIA_BUTTON_LENGTH_SHORT = 1,

            /**
             * The button is held for a medium length of time (more than 350 ms but less
             * than 700 ms).
             */
            MEDIA_BUTTON_LENGTH_MEDIUM = 2,

            /**
             * The button is held for a long length of time (more than 700 ms).
             */
            MEDIA_BUTTON_LENGTH_LONG = 3,
        } ;

        /**
         * @brief Media actions
         *
         * This enumeration defines the available actions for a button press.
         */
        public enum MediaActionType
        {
            /**
             * A launch action.
             */
            MEDIA_ACTION_LAUNCH = 0,

            /**
             * A forwarding action.
             */
            MEDIA_ACTION_FORWARD = 1,
        } ;
    }
}
