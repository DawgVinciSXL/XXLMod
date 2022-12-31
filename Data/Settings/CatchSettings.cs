using XXLMod.Data.Enums;

namespace XXLMod.Data.Settings
{
    public class CatchSettings
    {

        public CatchStyle CatchMode = CatchStyle.Auto;

        public CatchSettings()
        {

        }

        public CatchSettings(CatchStyle catchMode)
        {

            CatchMode = catchMode;
        }
    }
}