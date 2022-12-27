using System;
using HarmonyLib;
using UnityEngine;
using XXLMod.Controller;
using XXLMod.Data.Enums;

namespace XXLMod.Patches.BoardController_
{
    [HarmonyPatch(typeof(BoardController), "Rotate", new Type[] { typeof(bool), typeof(bool) })]
    class RotatePatch
    {
        public static bool Prefix(ref float ____firstDelta, ref float ____secondDelta, ref float ____thirdDelta, ref float ____flipDelta, ref float ____spinDelta, ref Quaternion ____rotDeltaThisFrame, ref Quaternion ____bufferedRotation, ref Transform ____catchForwardRotation, ref float ____bufferedFlip, ref bool doFlip, ref bool doPop, ref float ____lastuplift)
        {
            if (Main.enabled)
            {
                ____firstDelta = PlayerController.Instance.boardController.firstVel * 500f * Time.deltaTime;
                ____secondDelta = PlayerController.Instance.boardController.secondVel * 20f * Time.deltaTime;
                ____thirdDelta = PlayerController.Instance.boardController.thirdVel * 20f * Time.deltaTime;
                bool flag2 = SettingsManager.Instance.stance == SkaterXL.Core.Stance.Regular;
                if (flag2)
                {
                    ____secondDelta = -____secondDelta;
                }
                bool flag3 = SettingsManager.Instance.controlType == SkaterXL.Core.ControlType.Simple && PlayerController.Instance.IsSwitch;
                if (flag3)
                {
                    ____secondDelta = -____secondDelta;
                }
                ____firstDelta = Mathf.Clamp(____firstDelta, -5f, 5f);
                ____secondDelta = Mathf.Clamp(____secondDelta, -6f, 6f);
                ____thirdDelta = Mathf.Clamp(doFlip ? ____thirdDelta : (____thirdDelta * 0f), -9f, 9f);
                Vector3 vector = SkaterXL.Core.Mathd.LocalAngularVelocity(PlayerController.Instance.skaterController.skaterRigidbody);

                float FlipSpeed = GetFlipSpeed();
                float ScoopSpeed = GetScoopSpeed();

                float num = 0f;
                if (GetDecoupledMode() == DecoupledMode.Simple)
                {
                    num = (Mathf.Abs(____secondDelta) < 1) ? (57.29578f * vector.y * Time.deltaTime) : 0f;
                }
                else if (GetDecoupledMode() == DecoupledMode.Total)
                {
                    num = 0f;
                }
                else
                {
                    num = 57.29578f * vector.y * Time.deltaTime;
                }
                GetShuvDirection(____secondDelta);
                ____rotDeltaThisFrame = Quaternion.Euler(____firstDelta, -____secondDelta * (ScoopSpeed), 0f);
                Quaternion lhs = Quaternion.AngleAxis(num, PlayerController.Instance.skaterController.skaterTransform.up);
                ____bufferedRotation = lhs * ____bufferedRotation * ____rotDeltaThisFrame;
                ____catchForwardRotation.Rotate(PlayerController.Instance.skaterController.transform.up, num);
                PlayerController.Instance.boardController.boardTransform.rotation = ____bufferedRotation;
                ____bufferedFlip += ____thirdDelta;
                PlayerController.Instance.boardController.boardTransform.Rotate(new Vector3(0f, 0f, (____bufferedFlip * (FlipSpeed))));
                bool flag5 = doPop;
                if (flag5)
                {
                    float d = PlayerController.Instance.boardController.popBoardVelAdd * Mathf.Abs(Mathf.Atan(0.0174532924f * ____firstDelta)) - ____lastuplift;
                    PlayerController.Instance.boardController.boardRigidbody.AddForce(PlayerController.Instance.skaterController.skaterTransform.up * d, ForceMode.VelocityChange);
                }
                return false;
            }
            return true;
        }

        public static float GetFlipSpeed()
        {
            return Main.Settings.FlipSettings.FlipSpeed;
        }

        public static float GetScoopSpeed()
        {
            return Main.Settings.FlipSettings.ScoopSpeed;
        }

        public static DecoupledMode GetDecoupledMode()
        {
            return Main.Settings.FlipSettings.DecoupledMode;
        }

        public static void GetShuvDirection(float f)
        {
            if (f > 1f)
            {
                FlipController.Instance.IsFsShuv = false;
                FlipController.Instance.IsBsShuv = true;
            }

            if (f < -1f)
            {
                FlipController.Instance.IsBsShuv = false;
                FlipController.Instance.IsFsShuv = true;
            }
        }
    }
}