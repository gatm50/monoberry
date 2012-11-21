using System;
using System.Runtime.InteropServices;

namespace BlackberryPlatformServices
{
    public class SoundPlayer
    {
        #region DllImport
        //        /**
        // * @brief Prepare a system sound to be played
        // * 
        // * The @c soundplayer_prepare_sound() function prepares the specified system
        // * sound to be played.
        // * 
        // * Calling this function is optional, but may greatly improve the response time
        // * of @c soundplayer_play_sound().
        // *
        // * @param name The name of the system sound to be prepared.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int soundplayer_prepare_sound( const char *name );
        [DllImport("bps")]
        static extern int soundplayer_prepare_sound(char[] name);

        ///**
        // * @brief Play a system sound
        // * 
        // * The @c soundplayer_play_sound() function plays the specified system sound.
        // *
        // * @param name The name of the system sound.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int soundplayer_play_sound( const char *name );
        [DllImport("bps")]
        static extern int soundplayer_play_sound(char[] name);
        #endregion

        private string _fileName;

        public SystemSounds FileName
        {
            set { _fileName = this.GetNameFromSystemSound(value); }
        }

        public enum SystemSounds : int
        {
            InputKeypress = 1,
            NotificationGeneral = 2,
            NotificationSapphire = 3,
            AlarmBattery = 4,
            EventBrowserStart = 5,
            EventCameraShutter = 6,
            EventRecordingStart = 7,
            EventRecordingStop = 8,
            EventDeviceLock = 9,
            EventDeviceUnlock = 10,
            EventDeviceTether = 11,
            EventDeviceUntether = 12,
            EventVideoCall = 13,
            EventVideoCallOutgoing = 14,
            SystemMasterVolumeReference = 15
        }

        private string GetNameFromSystemSound(SystemSounds sound)
        {
            string name = string.Empty;
            switch (sound)
            {
                case SystemSounds.InputKeypress:
                    name = "input_keypress";
                    break;
                case SystemSounds.NotificationGeneral:
                    name = "notification_general";
                    break;
                case SystemSounds.NotificationSapphire:
                    name = "notification_sapphire";
                    break;
                case SystemSounds.AlarmBattery:
                    name = "alarm_battery";
                    break;
                case SystemSounds.EventBrowserStart:
                    name = "event_browser_start";
                    break;
                case SystemSounds.EventCameraShutter:
                    name = "event_camera_shutter";
                    break;
                case SystemSounds.EventRecordingStart:
                    name = "event_recording_start";
                    break;
                case SystemSounds.EventRecordingStop:
                    name = "event_recording_stop";
                    break;
                case SystemSounds.EventDeviceLock:
                    name = "event_device_lock";
                    break;
                case SystemSounds.EventDeviceUnlock:
                    name = "event_device_unlock";
                    break;
                case SystemSounds.EventDeviceTether:
                    name = "event_device_tether";
                    break;
                case SystemSounds.EventDeviceUntether:
                    name = "event_device_untether";
                    break;
                case SystemSounds.EventVideoCall:
                    name = "event_video_call";
                    break;
                case SystemSounds.EventVideoCallOutgoing:
                    name = "event_video_call_outgoing";
                    break;
                case SystemSounds.SystemMasterVolumeReference:
                    name = "system_master_volume_reference";
                    break;
                default:
                    name = "notification_general";
                    break;
            }
            return name;
        }

        public SoundPlayer(SystemSounds fileName)
        {
            _fileName = this.GetNameFromSystemSound(fileName);
        }

        public void PlaySound()
        {
            if (string.IsNullOrEmpty(_fileName))
                throw new Exception("The file name cannot be null or empty");

            if (soundplayer_prepare_sound(_fileName.ToCharArray()) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to load sound file.");
            if (soundplayer_play_sound(_fileName.ToCharArray()) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to play sound file.");
        }
    }
}
