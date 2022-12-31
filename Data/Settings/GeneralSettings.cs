using System;
using XXLMod.Data.Enums;

namespace XXLMod.Data.Settings
{
    [Serializable]
    public class GeneralSettings
    {
        public float Gravity = -9.807f;
        public AdvancedPopMode AdvancedPop = AdvancedPopMode.Off;
        public float ForwardPopForce = 100f;
        public float SidewayPopForce = 100f;
        public bool IndividualPopForce = false;
        public float DefaultPopForce = 3f;
        public float NolliePopForce = 3f;
        public float SwitchPopForce = 3f;
        public float FakiePopForce = 3f;
        public float DefaultHighPopForceMult = 0.5f;
        public float NollieHighPopForceMult = 0.5f;
        public float SwitchHighPopForceMult = 0.5f;
        public float FakieHighPopForceMult = 0.5f;

        public GeneralSettings()
        {
        }

        public GeneralSettings(float gravity)
        {
            Gravity = gravity;
        }
    }
}