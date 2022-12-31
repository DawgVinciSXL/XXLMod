using HarmonyLib;
using XXLMod.Controller;

namespace XXLMod.Patches.PlayerState_Setup_
{
    [HarmonyPatch(typeof(PlayerState_Setup), "Update")]
    class UpdatePatch
    {
        static void Prefix(ref bool ____forwardLoad)
        {
            PlayerController.Instance.popForce = XXLController.Instance.GetPopForce(____forwardLoad);
            PlayerController.Instance.highPopForce = PlayerController.Instance.popForce * (XXLController.Instance.GetHighPopForceMultiplier(____forwardLoad) + 0.65f);
            XXLController.Instance.AdvancedPop();
        }
    }
}
