using System;
using System.Runtime.InteropServices;

namespace BlackberryPlatformServices
{
    public class AudioMixer
    {
        #region Enumerators
        ///**
        // * @brief Output channels
        // * 
        // * This enumeration defines the different output channels that can be available.  
        // * Only one output channel can be available at a time, and you can determine
        // * the available output channel by calling @c audiomixer_event_get_available().
        // */
        //typedef enum {
        //    /**
        //     * The default output channel.
        //     */
        //    AUDIOMIXER_OUTPUT_DEFAULT   = 0,

        //    /**
        //     * The internal speaker.
        //     */
        //    AUDIOMIXER_OUTPUT_SPEAKER   = 1,

        //    /**
        //     * The headphone jack.
        //     */
        //    AUDIOMIXER_OUTPUT_HEADPHONE = 2,

        //    /**
        //     * A headset with microphone input.
        //     */
        //    AUDIOMIXER_OUTPUT_HEADSET   = 3,

        //    /**
        //     * The phone receiver on the device.
        //     */
        //    AUDIOMIXER_OUTPUT_HANDSET   = 4,

        //    /**
        //     * A Bluetooth Advanced Audio Distribution Profile (A2DP) connection.
        //     */
        //    AUDIOMIXER_OUTPUT_A2DP      = 5,

        //    /**
        //     * A Bluetooth Synchronous Connection Oriented/Hands-Free Profile (SCO/HFP)
        //     * connection.
        //     */
        //    AUDIOMIXER_OUTPUT_BTSCO     = 6,

        //    /**
        //     * A Hearing Aid Compatibility (HAC) coil used for hearing aids.
        //     */
        //    AUDIOMIXER_OUTPUT_HAC       = 7,

        //    /**
        //     * The HDMI audio channel.
        //     */
        //    AUDIOMIXER_OUTPUT_HDMI      = 8,

        //    /**
        //     * A TOSLINK optical audio cable connection.
        //     */
        //    AUDIOMIXER_OUTPUT_TOSLINK   = 9,

        //    /**
        //     * A TTY telecommunication device for the hearing impaired (connected
        //     * through the headphone jack).
        //     */
        //    AUDIOMIXER_OUTPUT_TTY       = 10,

        //    /**
        //     * A device connected through the headset jack.
        //     */
        //    AUDIOMIXER_OUTPUT_LINEOUT   = 11,
        //} audiomixer_output_t;
        public enum OutputType : int
        {
            AUDIOMIXER_OUTPUT_DEFAULT = 0,
            AUDIOMIXER_OUTPUT_SPEAKER = 1,
            AUDIOMIXER_OUTPUT_HEADPHONE = 2,
            AUDIOMIXER_OUTPUT_HEADSET = 3,
            AUDIOMIXER_OUTPUT_HANDSET = 4,
            AUDIOMIXER_OUTPUT_A2DP = 5,
            AUDIOMIXER_OUTPUT_BTSCO = 6,
            AUDIOMIXER_OUTPUT_HAC = 7,
            AUDIOMIXER_OUTPUT_HDMI = 8,
            AUDIOMIXER_OUTPUT_TOSLINK = 9,
            AUDIOMIXER_OUTPUT_TTY = 10,
            AUDIOMIXER_OUTPUT_LINEOUT = 11,
        }

        ///**
        // * @brief Input channels
        // * 
        // * This enumeration defines the different input channels that are available.
        // * Note that some input channels are simply aliases for the default input
        // * channel @c AUDIOMIXER_INPUT_DEFAULT.
        // */
        //typedef enum {
        //    /**
        //     * The default input channel.
        //     */
        //    AUDIOMIXER_INPUT_DEFAULT    = AUDIOMIXER_OUTPUT_DEFAULT,

        //    /**
        //     * The default input channel, for backwards compatibility.
        //     */
        //    AUDIOMIXER_INPUT            = AUDIOMIXER_OUTPUT_DEFAULT,

        //    /**
        //     * The internal speaker.
        //     *
        //     * If this channel is specified, the default input channel is used.
        //     */
        //    AUDIOMIXER_INPUT_SPEAKER    = AUDIOMIXER_OUTPUT_SPEAKER,

        //    /**
        //     * The headphone jack.
        //     *
        //     * If this channel is specified, the default input channel is used.
        //     */
        //    AUDIOMIXER_INPUT_HEADPHONE  = AUDIOMIXER_OUTPUT_HEADPHONE,

        //    /**
        //     * A headset with microphone input.
        //     */
        //    AUDIOMIXER_INPUT_HEADSET    = AUDIOMIXER_OUTPUT_HEADSET,

        //    /**
        //     * The phone receiver on the device.
        //     */
        //    AUDIOMIXER_INPUT_HANDSET    = AUDIOMIXER_OUTPUT_HANDSET,

        //    /**
        //     * A Bluetooth Advanced Audio Distribution Profile (A2DP) connection.
        //     *
        //     * If this channel is specified, the default input channel is used.
        //     */
        //    AUDIOMIXER_INPUT_A2DP       = AUDIOMIXER_OUTPUT_A2DP,

        //    /**
        //     * A Bluetooth Synchronous Connection Oriented/Hands-Free Profile (SCO/HFP)
        //     * connection.
        //     */
        //    AUDIOMIXER_INPUT_BTSCO      = AUDIOMIXER_OUTPUT_BTSCO,

        //    /**
        //     * A Hearing Aid Compatibility (HAC) coil used for hearing aids.
        //     *
        //     * If this channel is specified, the default input channel is used.
        //     */
        //    AUDIOMIXER_INPUT_HAC        = AUDIOMIXER_OUTPUT_HAC,

        //    /**
        //     * The HDMI audio channel.
        //     *
        //     * If this channel is specified, the default input channel is used.
        //     */
        //    AUDIOMIXER_INPUT_HDMI       = AUDIOMIXER_OUTPUT_HDMI,

        //    /**
        //     * A TOSLINK optical audio cable connection.
        //     *
        //     * If this channel is specified, the default input channel is used.
        //     */
        //    AUDIOMIXER_INPUT_TOSLINK    = AUDIOMIXER_OUTPUT_TOSLINK,

        //    /**
        //     * A TTY telecommunication device for the hearing impaired (connected
        //     * through the headphone jack).
        //     */
        //    AUDIOMIXER_INPUT_TTY        = AUDIOMIXER_OUTPUT_TTY,

        //    /**
        //     * A device connected through the headset jack.
        //     *
        //     * If this channel is specified, the default input channel is used.
        //     */
        //    AUDIOMIXER_INPUT_LINEOUT    = AUDIOMIXER_OUTPUT_LINEOUT,
        //} audiomixer_input_t;
        public enum InputType : int
        {
            AUDIOMIXER_INPUT_DEFAULT = OutputType.AUDIOMIXER_OUTPUT_DEFAULT,
            AUDIOMIXER_INPUT = OutputType.AUDIOMIXER_OUTPUT_DEFAULT,
            AUDIOMIXER_INPUT_SPEAKER = OutputType.AUDIOMIXER_OUTPUT_SPEAKER,
            AUDIOMIXER_INPUT_HEADPHONE = OutputType.AUDIOMIXER_OUTPUT_HEADPHONE,
            AUDIOMIXER_INPUT_HEADSET = OutputType.AUDIOMIXER_OUTPUT_HEADSET,
            AUDIOMIXER_INPUT_HANDSET = OutputType.AUDIOMIXER_OUTPUT_HANDSET,
            AUDIOMIXER_INPUT_A2DP = OutputType.AUDIOMIXER_OUTPUT_A2DP,
            AUDIOMIXER_INPUT_BTSCO = OutputType.AUDIOMIXER_OUTPUT_BTSCO,
            AUDIOMIXER_INPUT_HAC = OutputType.AUDIOMIXER_OUTPUT_HAC,
            AUDIOMIXER_INPUT_HDMI = OutputType.AUDIOMIXER_OUTPUT_HDMI,
            AUDIOMIXER_INPUT_TOSLINK = OutputType.AUDIOMIXER_OUTPUT_TOSLINK,
            AUDIOMIXER_INPUT_TTY = OutputType.AUDIOMIXER_OUTPUT_TTY,
            AUDIOMIXER_INPUT_LINEOUT = OutputType.AUDIOMIXER_OUTPUT_LINEOUT,
        }

        ///**
        // * @brief Audio modes
        // *
        // * This enumeration defines the different audio modes that may be active.
        // */
        //typedef enum {
        //    /**
        //     * An unrecognized mode (not one listed below).
        //     */
        //    AUDIOMIXER_MODE_UNRECOGNIZED = 0,

        //    /**
        //     * The audio audio mode.
        //     */
        //    AUDIOMIXER_MODE_AUDIO        = 1,

        //    /**
        //     * The video audio mode.
        //     */
        //    AUDIOMIXER_MODE_VIDEO        = 2,

        //    /**
        //     * The record audio mode.
        //     */
        //    AUDIOMIXER_MODE_RECORD       = 3,

        //    /**
        //     * The voice audio mode.
        //     */
        //    AUDIOMIXER_MODE_VOICE        = 4,
        //} audiomixer_mode_t;
        public enum ModeType : int
        {
            AUDIOMIXER_MODE_UNRECOGNIZED = 0,
            AUDIOMIXER_MODE_AUDIO = 1,
            AUDIOMIXER_MODE_VIDEO = 2,
            AUDIOMIXER_MODE_RECORD = 3,
            AUDIOMIXER_MODE_VOICE = 4,
        }
        #endregion

        #region DllImport
        ///**
        // * @brief Start receiving audio mixer events
        // * 
        // * The @c audiomixer_request_events() function starts to deliver audio mixer
        // * events to the application using BPS.  Events will be posted to the currently
        // * active channel.
        // * 
        // * @param flags The types of events to deliver. A value of zero indicates that
        // * all events are requested. The meaning of non-zero values is reserved for
        // * future use.
        // * 
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int audiomixer_request_events(int flags);
        [DllImport("bps")]
        static extern int audiomixer_request_events(int flags);

        ///**
        // * @brief Stop receiving audio mixer events
        // *
        // * The @c audiomixer_stop_events() function stops audio mixer events from being
        // * delivered to the application using BPS.
        // *
        // * @param flags The types of events to stop. A value of zero indicates that all
        // * events are stopped. The meaning of non-zero values is reserved for future
        // * use.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int audiomixer_stop_events(int flags);
        [DllImport("bps")]
        static extern int audiomixer_stop_events(int flags);

        ///**
        // * @brief Get the unique domain ID for the audio mixer service
        // * 
        // * The @c audiomixer_get_domain() function gets the unique domain ID for the
        // * audio mixer service.  You can use this function in your application
        // * to test whether an event that you retrieve using @c bps_get_event() is an
        // * audio mixer event, and respond accordingly.
        // *
        // * @return The domain ID for the audio mixer service.
        // */
        //BPS_API int audiomixer_get_domain(void);
        [DllImport("bps")]
        static extern int audiomixer_get_domain();

        //// Set messages

        ///**
        // * @brief Set an output channel's volume
        // * 
        // * The @c audiomixer_set_output_level() function sets the volume of the
        // * specified output channel to the specified level.  This function can only be
        // * used for audio devices that have full volume control.
        // * 
        // * @param channel The output channel to set the volume for.
        // * @param level The new volume for the output channel.  This value must be
        // * between 0.0 and 100.0.
        // * 
        // * @return @c BPS_SUCCESS if the volume was set successfully, @c BPS_FAILURE
        // * with @c errno set otherwise.
        // */
        //BPS_API int audiomixer_set_output_level(audiomixer_output_t channel, float level);
        [DllImport("bps")]
        static extern int audiomixer_set_output_level(OutputType channel, float level);

        ///**
        // * @brief Set an input channel's gain
        // * 
        // * The @c audiomixer_set_input_level() function sets the gain of the specified
        // * input channel to the specified level.  This function can only be used for
        // * audio devices that have full volume control.
        // * 
        // * @param channel The input channel to set the gain for.
        // * @param level The new gain for the input channel.  This value must be between
        // * 0.0 and 100.0.
        // * 
        // * @return @c BPS_SUCCESS if the gain was set successfully, @c BPS_FAILURE with
        // * @c errno set otherwise.
        // */
        //BPS_API int audiomixer_set_input_level(audiomixer_input_t channel, float level);
        [DllImport("bps")]
        static extern int audiomixer_set_input_level(InputType channel, float level);

        ///**
        // * @brief Adjust an output channel's volume
        // * 
        // * The @c audiomixer_adjust_output_level() function adjusts the volume of the
        // * specified output channel by the specified amount.  This function can only be
        // * used for audio devices that have full volume control.
        // * 
        // * @param channel The output channel to adjust the volume for.
        // * @param level The amount to adjust the channel's volume.  Final level will
        // *              not exceed the range of 0.0 to 100.0.
        // * 
        // * @return @c BPS_SUCCESS if the volume was adjusted successfully,
        // * @c BPS_FAILURE with @c errno set otherwise.
        // */
        //BPS_API int audiomixer_adjust_output_level(audiomixer_output_t channel, float level);
        [DllImport("bps")]
        static extern int audiomixer_adjust_output_level(OutputType channel, float level);

        ///**
        // * @brief Adjust an input channel's gain
        // * 
        // * The @c audiomixer_adjust_input_level() function adjusts the gain of the
        // * specified input channel by the specified amount.  This function can only be
        // * used for audio devices that have full volume control.
        // * 
        // * @param channel The input channel to adjust the gain for.
        // * @param level The amount to adjust the channel's gain.  Final level will not
        // *              exceed the range of 0.0 to 100.0.
        // * 
        // * @return @c BPS_SUCCESS if the gain was adjusted successfully, @c BPS_FAILURE
        // * with @c errno set otherwise.
        // */
        //BPS_API int audiomixer_adjust_input_level(audiomixer_input_t channel, float level);
        [DllImport("bps")]
        static extern int audiomixer_adjust_input_level(InputType channel, float level);

        ///**
        // * @brief Mute or un-mute an output channel
        // * 
        // * The @c audiomixer_set_output_mute() function mutes or un-mutes the specified
        // * output channel.  This function can only be used for audio devices that have
        // * full volume control.
        // * 
        // * @param channel The output channel to mute or un-mute.
        // * @param is_mute If @c true the output channel is muted, if @c false the
        // * output channel is un-muted.
        // * 
        // * @return @c BPS_SUCCESS if the channel was muted or un-muted successfully,
        // * @c BPS_FAILURE with @c errno set otherwise.
        // */
        //BPS_API int audiomixer_set_output_mute(audiomixer_output_t channel, bool is_mute);
        [DllImport("bps")]
        static extern int audiomixer_set_output_mute(OutputType channel, bool is_mute);

        ///**
        // * @brief Mute or un-mute an input channel
        // * 
        // * The @c audiomixer_set_input_mute() function mutes or un-mutes the specified
        // * input channel.  This function can only be used for audio devices that have
        // * full volume control.
        // * 
        // * @param channel The input channel to mute or un-mute.
        // * @param is_mute If @c true the input channel is muted, if @c false the
        // * input channel is un-muted.
        // *
        // * @return @c BPS_SUCCESS if the channel was muted or un-muted successfully,
        // * @c BPS_FAILURE with @c errno set otherwise.
        // */
        //BPS_API int audiomixer_set_input_mute(audiomixer_input_t channel, bool is_mute);
        [DllImport("bps")]
        static extern int audiomixer_set_input_mute(InputType channel, bool is_mute);

        ///**
        // * @brief Toggle an output channel's mute setting
        // * 
        // * The @c audiomixer_toggle_output_mute() function toggles the mute setting of
        // * the specified output channel.  This function can only be used for audio
        // * devices that have full volume control.
        // * 
        // * @param channel The output channel to toggle the mute setting for.
        // * 
        // * @return @c BPS_SUCCESS if the mute setting was toggled successfully,
        // * @c BPS_FAILURE with @c errno set otherwise.
        // */
        //BPS_API int audiomixer_toggle_output_mute(audiomixer_output_t channel);
        [DllImport("bps")]
        static extern int audiomixer_toggle_output_mute(OutputType channel);

        ///**
        // * @brief Toggle an input channel's mute setting
        // * 
        // * The @c audiomixer_toggle_input_mute() function toggles the mute setting of
        // * the specified input channel.  This function can only be used for audio
        // * devices that have full volume control.
        // * 
        // * @param channel The input channel to toggle the mute setting for.
        // * 
        // * @return @c BPS_SUCCESS if the mute setting was toggled successfully,
        // * @c BPS_FAILURE with @c errno set otherwise.
        // */
        //BPS_API int audiomixer_toggle_input_mute(audiomixer_input_t channel);
        [DllImport("bps")]
        static extern int audiomixer_toggle_input_mute(InputType channel);

        //// Get messages

        ///**
        // * @brief Get an output channel's volume
        // *
        // * The @c audiomixer_get_output_level() function gets the volume of the
        // * specified output channel.  This function can only be used for audio devices
        // * that have full volume control.
        // *
        // * @param channel The output channel to get the volume for.
        // * @param level The output channel's current volume.  This value is between 0.0
        // * and 100.0.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int audiomixer_get_output_level(audiomixer_output_t channel, float* level);
        [DllImport("bps")]
        static extern int audiomixer_get_output_level(OutputType channel, out float level);

        ///**
        // * @brief Get an input channel's gain
        // * 
        // * The @c audiomixer_get_input_level() function gets the gain of the specified
        // * input channel.  This function can only be used for audio devices that have
        // * full volume control.
        // *
        // * @param channel The input channel to get the gain for.
        // * @param level The input channel's current gain.  This value is between 0.0 and
        // * 100.0.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int audiomixer_get_input_level(audiomixer_input_t channel, float* level);
        [DllImport("bps")]
        static extern int audiomixer_get_input_level(InputType channel, out float level);

        ///**
        // * @brief Get an output channel's mute status
        // *
        // * The @c audiomixer_get_output_mute() function gets the mute status of the
        // * specified output channel.  This function can only be used for audio devices
        // * that have full volume control.
        // *
        // * @param channel The output channel to get the mute status for.
        // * @param is_mute If @c true the output channel is muted, if @c false the
        // * output channel is not muted.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int audiomixer_get_output_mute(audiomixer_output_t channel, bool *is_mute);
        [DllImport("bps")]
        static extern int audiomixer_get_output_mute(OutputType channel, out bool is_mute);

        ///**
        // * @brief Get an input channel's mute status
        // *
        // * The @c audiomixer_get_input_mute() function gets the mute status of the
        // * specified input channel.  This function can only be used for audio devices
        // * that have full volume control.
        // *
        // * @param channel The input channel to get the mute status for.
        // * @param is_mute If @c true the input channel is muted, if @c false the input
        // * channel is not muted.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int audiomixer_get_input_mute(audiomixer_input_t channel, bool* is_mute);
        [DllImport("bps")]
        static extern int audiomixer_get_input_mute(InputType channel, out bool is_mute);

        ///**
        // * @brief Increase an output channel's volume
        // * 
        // * The @c audiomixer_increase_output_level() function increases the volume of
        // * the specified output channel by an unspecified amount.  This function can be
        // * used for audio devices that have simple or full volume control.
        // * 
        // * @param channel The output channel to increase the volume for.
        // * 
        // * @return @c BPS_SUCCESS if the volume was increased successfully,
        // * @c BPS_FAILURE with @c errno set otherwise.
        // */
        //BPS_API int audiomixer_increase_output_level(audiomixer_output_t channel);
        [DllImport("bps")]
        static extern int audiomixer_increase_output_level(OutputType channel);

        ///**
        // * @brief Decrease an output channel's volume
        // * 
        // * The @c audiomixer_decrease_output_level() function decreases the volume of
        // * the specified output channel by an unspecified amount.  This function can be
        // * used for audio devices that have simple or full volume control.
        // * 
        // * @param channel The output channel to decrease the volume for.
        // * 
        // * @return @c BPS_SUCCESS if the volume was decreased successfully,
        // * @c BPS_FAILURE with @c errno set otherwise.
        // */
        //BPS_API int audiomixer_decrease_output_level(audiomixer_output_t channel);
        [DllImport("bps")]
        static extern int audiomixer_decrease_output_level(OutputType channel);

        ///**
        // * @brief Get the currently active audio mode from an @c AUDIOMIXER_INFO event
        // *
        // * The @c audiomixer_event_get_mode() function extracts the audio mode currently
        // * active from an @c AUDIOMIXER_INFO event.
        // *
        // * @param event The @c AUDIOMIXER_INFO event to extract the mode from.
        // *
        // * @return The currently active audio mode.
        // */
        //BPS_API audiomixer_mode_t audiomixer_event_get_mode(bps_event_t *event);
        [DllImport("bps")]
        static extern ModeType audiomixer_event_get_mode(IntPtr _event);

        ///**
        // * @brief Get an output channel's volume from an @c AUDIOMIXER_INFO event
        // *
        // * The @c audiomixer_event_get_output_level() function extracts the volume of
        // * the specified output channel from an @c AUDIOMIXER_INFO event.  This function
        // * can only be used for audio devices that have full volume control.
        // *
        // * @param event The @c AUDIOMIXER_INFO event to extract the volume from.
        // * @param channel The output channel to get the volume for.
        // *
        // * @return The output channel's volume.  This value is between 0.0 and 100.0.
        // */
        //BPS_API float audiomixer_event_get_output_level(bps_event_t *event, audiomixer_output_t channel);
        [DllImport("bps")]
        static extern float audiomixer_event_get_output_level(IntPtr _event, OutputType channel);

        ///**
        // * @brief Get an input channel's gain from an @c AUDIOMIXER_INFO event
        // *
        // * The @c audiomixer_event_get_input_level() function extracts the gain of the
        // * specified input channel from an @c AUDIOMIXER_INFO event.  This function can
        // * only be used for audio devices that have full volume control.
        // *
        // * @param event The @c AUDIOMIXER_INFO event to extract the gain from.
        // * @param channel The input channel to get the gain for.
        // *
        // * @return The input channel's gain.  This value is between 0.0 to 100.0.
        // */
        //BPS_API float audiomixer_event_get_input_level(bps_event_t *event, audiomixer_input_t channel);
        [DllImport("bps")]
        static extern float audiomixer_event_get_input_level(IntPtr _event, InputType channel);

        ///**
        // * @brief Get an output channel's mute status from an @c AUDIOMIXER_INFO event
        // *
        // * The @c audiomixer_event_get_output_mute() function extracts the mute status
        // * of the specified output channel from an @c AUDIOMIXER_INFO event.  This
        // * function can only be used for audio devices that have full volume control.
        // *
        // * @param event The @c AUDIOMIXER_INFO event to extract the mute status from.
        // * @param channel The output channel to get the mute status for.
        // *
        // * @return @c true if the output channel is muted, @c false otherwise.
        // */
        //BPS_API bool audiomixer_event_get_output_mute(bps_event_t *event, audiomixer_output_t channel);
        [DllImport("bps")]
        static extern bool audiomixer_event_get_output_mute(IntPtr _event, OutputType channel);

        ///**
        // * @brief Get an input channel's mute status from an @c AUDIOMIXER_INFO event
        // *
        // * The @c audiomixer_event_get_input_mute() function extracts the mute status of
        // * the specified input channel from an @c AUDIOMIXER_INFO event.  This function
        // * can only be used for audio devices that have full volume control.
        // *
        // * @param event The @c AUDIOMIXER_INFO event to extract the mute status from.
        // * @param channel The input channel to get the mute status for.
        // *
        // * @return @c true if the input channel is muted, @c false otherwise.
        // */
        //BPS_API bool audiomixer_event_get_input_mute(bps_event_t *event, audiomixer_input_t channel);
        [DllImport("bps")]
        static extern bool audiomixer_event_get_input_mute(IntPtr _event, InputType channel);

        ///**
        // * @brief Get the available output channel
        // * 
        // * The @c audiomixer_event_get_available() function extracts the available output
        // * channel from an @c AUDIOMIXER_INFO event.
        // *
        // * @param event The @c AUDIOMIXER_INFO event to extract the available output
        // * channel from.
        // * 
        // * @return The available output channel.
        // */
        //BPS_API audiomixer_output_t audiomixer_event_get_available(bps_event_t *event);
        [DllImport("bps")]
        static extern OutputType audiomixer_event_get_available(IntPtr _event);
        #endregion

        public AudioMixer()
        {
            this.RequestEvents();
        }

        public void Dispose()
        {
            this.StopEvents();
        }

        public void RequestEvents()
        {
            if (audiomixer_request_events(0) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to request events for AudioMixer.");
        }

        public void StopEvents()
        {
            if (audiomixer_stop_events(0) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to stop events for AudioMixer.");
        }

        public int GetDomain()
        {
            return audiomixer_get_domain();
        }

        public void SetOutputLevel(OutputType channel, float level)
        {
            if (audiomixer_set_output_level(channel, level) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to set Output level for channel.");
        }

        public void SetInputLevel(InputType channel, float level)
        {
            if (audiomixer_set_input_level(channel, level) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to set Input level for channel.");
        }

        public void AdjustOutputLevel(OutputType channel, float level)
        {
            if (audiomixer_adjust_output_level(channel, level) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to adjust Output level for channel.");
        }

        public void AdjustInputLevel(InputType channel, float level)
        {
            if (audiomixer_adjust_input_level(channel, level) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to adjust Input level for channel.");
        }

        public void SetOutputMute(OutputType channel, bool mute)
        {
            if (audiomixer_set_output_mute(channel, mute) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to set mute for channel.");
        }

        public void SetInputMute(InputType channel, bool mute)
        {
            if (audiomixer_set_input_mute(channel, mute) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to set mute for channel.");
        }

        public void ToggleOutputMute(OutputType channel)
        {
            if (audiomixer_toggle_output_mute(channel) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to toggle mute for channel.");
        }

        public void ToggleInputMute(InputType channel)
        {
            if (audiomixer_toggle_input_mute(channel) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to toggle mute for channel.");
        }

        public float GetOutputLevel(OutputType channel)
        {
            float level = 0.0f;

            if (audiomixer_get_output_level(channel, out level) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to get Input level for channel.");

            return level;
        }

        public float GetInputLevel(InputType channel)
        {
            float level = 0.0f;

            if (audiomixer_get_input_level(channel, out level) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to get Input level for channel.");

            return level;
        }

        public bool GetOutputMute(OutputType channel)
        {
            bool mute = false;

            if (audiomixer_get_output_mute(channel, out mute) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to get Input level for channel.");

            return mute;
        }

        public bool GetInputMute(InputType channel)
        {
            bool mute = false;

            if (audiomixer_get_input_mute(channel, out mute) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to get Input level for channel.");

            return mute;
        }

        public void IncreaseVolume(OutputType channel)
        {
            if (audiomixer_increase_output_level(channel) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to increase output volume for channel.");
        }

        public void DecreaseVolume(OutputType channel)
        {
            if (audiomixer_decrease_output_level(channel) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to decreaser output volume for channel.");
        }

        public ModeType GetMode(IntPtr _event)
        {
            return audiomixer_event_get_mode(_event);
        }

        public float GetOutputLevelForEvent(OutputType channel, IntPtr _event)
        {
            return audiomixer_event_get_output_level(_event, channel);
        }

        public float GetInputLevelForEvent(InputType channel, IntPtr _event)
        {
            return audiomixer_event_get_input_level(_event, channel);
        }

        public bool GetOutputMuteForEvent(OutputType channel, IntPtr _event)
        {
            return audiomixer_event_get_output_mute(_event, channel);
        }

        public bool GetInputMuteForEvent(InputType channel, IntPtr _event)
        {
            return audiomixer_event_get_input_mute(_event, channel);
        }

        public OutputType GetAvalibleOutput(IntPtr _event)
        {
            return audiomixer_event_get_available(_event);
        }
    }
}
