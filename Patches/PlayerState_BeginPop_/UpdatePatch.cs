using HarmonyLib;
using XXLMod.Controller;

namespace XXLMod.Patches.PlayerState_BeginPop_
{
    [HarmonyPatch(typeof(PlayerState_BeginPop), "Update")]
    class UpdatePatch
    {
        static void Postfix()
        {
            if (PlayerController.Instance.GetAnimReleased())
            {
                FlipController.Instance.FlipDetected = true;
            }
        }
    }
}