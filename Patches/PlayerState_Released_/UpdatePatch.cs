using HarmonyLib;
using XXLMod.Controller;

namespace XXLMod.Patches.PlayerState_Released_
{
    [HarmonyPatch(typeof(PlayerState_Released), "Update")]
    class UpdatePatch
    {
        static void Postfix(ref bool ____caught, ref bool ____bothCaught, ref bool ____caughtLeft, ref bool ____caughtRight)
        {
            if (____caught || ____bothCaught || ____caughtLeft || ____caughtRight)
            {
                FlipController.Instance.FlipDetected = false;
            }
        }
    }
}