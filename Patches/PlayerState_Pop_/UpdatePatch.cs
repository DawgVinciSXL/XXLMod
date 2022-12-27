using HarmonyLib;
using XXLMod.Controller;

namespace XXLMod.Patches.PlayerState_Pop_
{
    [HarmonyPatch(typeof(PlayerState_Pop), "Update")]
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