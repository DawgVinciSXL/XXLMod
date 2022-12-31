using HarmonyLib;
using XXLMod.Data.Enums;
using XXLMod.Controller;

namespace XXLMod.Patches.PlayerState_BeginPop_
{
    [HarmonyPatch(typeof(PlayerState_BeginPop), "Enter")]
    class EnterPatch
    {
        static void Postfix(ref bool ____wasGrinding, ref bool ____forwardLoad, ref bool ____wasGrindingBackwards)
        {
            bool flag;
            if (____wasGrinding)
            {
                flag = ____wasGrindingBackwards;
            }
            else
            {
                flag = PlayerController.Instance.IsSwitch;
            }
            if (!flag)
            {
                if (!____forwardLoad)
                {
                    XXLController.PopType = XXLPopType.Ollie;
                }
                else
                {
                    XXLController.PopType = XXLPopType.Nollie;
                }
            }
            else if (!____forwardLoad)
            {
                XXLController.PopType = XXLPopType.Fakie;
            }
            else
            {
                XXLController.PopType = XXLPopType.Switch;
            }

            FlipController.Instance.PressureFlip();
            FlipController.Instance.VerticalScoop();
        }
    }
}