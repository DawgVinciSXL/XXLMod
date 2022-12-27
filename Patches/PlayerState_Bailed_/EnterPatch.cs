using HarmonyLib;
using XXLMod.Controller;

namespace XXLMod.Patches.PlayerState_Bailed_
{
    [HarmonyPatch(typeof(PlayerState_Bailed), "Enter")]
    class EnterPatch
    {
        static void Prefix()
        {
            FlipController.Instance.FlipDetected = false;
        }
    }
}