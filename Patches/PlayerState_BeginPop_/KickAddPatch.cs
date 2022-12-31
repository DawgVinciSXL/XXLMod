using HarmonyLib;
using UnityEngine;

namespace XXLMod.Patches.PlayerState_BeginPop_
{
    [HarmonyPatch(typeof(PlayerState_BeginPop), "KickAdd")]
    class KickAddPatch
    {
        static bool Prefix(ref bool ____wasGrinding, ref float ____popVel, ref float ____kickAddSoFar, ref bool ____forwardLoad)
        {
            if (Main.enabled)
            {
                float num = 5f;
                float num2 = Mathf.Clamp(Mathf.Abs(____popVel) / num, Main.Settings.FlipSettings.PopKickLeft, Main.Settings.FlipSettings.PopKickRight);
                float num3 = 1.1f;
                if (____wasGrinding)
                {
                    num3 *= 0.5f;
                }
                float num4 = num3 - num3 * num2 - ____kickAddSoFar;
                ____kickAddSoFar += num4;
                PlayerController.Instance.DoKick(____forwardLoad, num4);
                return false;
            }

            return true;
        }
    }
}
