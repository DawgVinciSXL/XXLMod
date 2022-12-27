using System;

namespace XXLMod.Data.Settings
{
    [Serializable]
    public class GeneralSettings
    {
        public float Gravity = -9.807f;

        public GeneralSettings()
        {
        }

        public GeneralSettings(float gravity)
        {
            Gravity = gravity;
        }
    }
}