
namespace BlackberryPlatformServices.Screen.Types
{
    public enum SensitivityMask
    {
        SCREEN_SENSITIVITY_MASK_ALWAYS = (1 << 0),
        SCREEN_SENSITIVITY_MASK_NEVER = (2 << 0),
        SCREEN_SENSITIVITY_MASK_NO_FOCUS = (1 << 3),
        SCREEN_SENSITIVITY_MASK_FULLSCREEN = (1 << 4),
        SCREEN_SENSITIVITY_MASK_CONTINUE = (1 << 5),
        SCREEN_SENSITIVITY_MASK_STOP = (2 << 5),
        SCREEN_SENSITIVITY_MASK_POINTER_BRUSH = (1 << 7),
        SCREEN_SENSITIVITY_MASK_FINGER_BRUSH = (1 << 8),
        SCREEN_SENSITIVITY_MASK_STYLUS_BRUSH = (1 << 9),
        SCREEN_SENSITIVITY_MASK_OVERDRIVE = (1 << 10),
    }
}
