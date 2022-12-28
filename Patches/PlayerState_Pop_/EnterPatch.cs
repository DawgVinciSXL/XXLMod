using HarmonyLib;
using XXLMod.Controller;

namespace XXLMod.Patches.PlayerState_Pop_
{
    [HarmonyPatch(typeof(PlayerState_Pop), "Enter")]
    class EnterPatch
    {
        static void Postfix()
        {
            FlipController.Instance.VerticalScoop();
        }
    }
}