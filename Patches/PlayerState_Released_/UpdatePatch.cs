using HarmonyLib;
using UnityEngine;
using XXLMod.Controller;
using XXLMod.Data.Enums;

namespace XXLMod.Patches.PlayerState_Released_
{
    [HarmonyPatch(typeof(PlayerState_Released), "Update")]
    class UpdatePatch
    {
        static bool Prefix(ref bool ____caught, ref bool ____bothCaught, ref bool ____caughtLeft, ref bool ____caughtRight, ref bool ____caughtThisIteration)
        {
            if (Main.enabled)
            {
                if (____caught || ____bothCaught || ____caughtLeft || ____caughtRight)
                {
                    FlipController.Instance.ResetDetected();
                    XXLController.Instance.ResetAdvancedPop();
                }

                if (FlipController.Instance.IsLaidbackFlip && !____caught)
                {
                    PlayerController.Instance.SetRightIKLerpTarget(1f, 1f);
                    PlayerController.Instance.SetRightSteezeWeight(0f);
                    PlayerController.Instance.SetMaxSteezeRight(0f);
                    PlayerController.Instance.SetRightKneeIKTargetWeight(1f);
                    PlayerController.Instance.SetRightIKWeight(1f);
                    PlayerController.Instance.SetRightKneeBendWeight(1f);
                    PlayerController.Instance.SetRightKneeBendWeightManually(1f);
                    PlayerController.Instance.SetLeftIKLerpTarget(1f, 1f);
                    PlayerController.Instance.SetLeftSteezeWeight(0f);
                    PlayerController.Instance.SetMaxSteezeLeft(0f);
                    PlayerController.Instance.SetLeftKneeIKTargetWeight(1f);
                    PlayerController.Instance.SetLeftIKWeight(1f);
                    PlayerController.Instance.SetLeftKneeBendWeight(1f);
                    PlayerController.Instance.SetLeftKneeBendWeightManually(1f);
                    PlayerController.Instance.animationController.skaterAnim.SetBool("Released", true);
                    PlayerController.Instance.CrossFadeAnimation("Extend", 0.1f);
                }

                if (Main.Settings.CatchSettings.CatchMode == CatchStyle.Manual || Main.Settings.CatchSettings.CatchMode == CatchStyle.Realistic)
                {

                    if (Main.Settings.CatchSettings.CatchMode == CatchStyle.Realistic)
                    {
                        if (PlayerController.Instance.inputController.player.GetButtonDown("Left Stick Button") || PlayerController.Instance.inputController.player.GetButtonDown("Right Stick Button"))
                        {
                            if (!CatchUpRealisticAngleCheck())
                            {
                                PlayerController.Instance.CrossFadeAnimation("Fall", 0.2f);
                                PlayerController.Instance.ForceBail();
                            }
                        }
                    }
                    if (!____caughtThisIteration && (____caught || ____bothCaught || ____caughtLeft || ____caughtRight))
                    {
                        ____caughtThisIteration = true;
                        PlayerController.Instance.ToggleFlipColliders(false);
                    }
                    return false;
                }

                return true;
            }
            return true;
        }

        private static bool CatchUpRealisticAngleCheck()
        {
            return Vector3.Angle(Vector3.ProjectOnPlane(PlayerController.Instance.boardController.boardTransform.up, PlayerController.Instance.skaterController.skaterTransform.forward), PlayerController.Instance.skaterController.skaterTransform.up) < 90f;
        }
    }
}