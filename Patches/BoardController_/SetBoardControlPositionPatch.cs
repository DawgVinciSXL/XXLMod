using HarmonyLib;
using UnityEngine;
using XXLMod.Controller;

namespace XXLMod.Patches.BoardController_
{
    [HarmonyPatch(typeof(BoardController), "SetBoardControlPosition")]
    class SetBoardControlPositionPatch
    {
        static bool Prefix(BoardController __instance)
        {
            if (Main.enabled)
            {
                __instance.boardControlTransform.position = PlayerController.Instance.skaterController.skaterTargetTransform.position + new Vector3(0f, GetCurrentOffset(), 0f);
                return false;
            }
            return true;
        }

        static float GetCurrentOffset()
        {
            float offset = 0f;
            if (PlayerController.Instance.currentStateEnum == PlayerController.CurrentState.Pop)
            {
                if (FlipController.Instance.FlipDetected)
                {
                    offset = -Main.Settings.FlipSettings.FlipBoardOffset;
                }
            }
            else
            {
                offset = 0f;
            }

            if (PlayerController.Instance.currentStateEnum == PlayerController.CurrentState.Release)
            {
                if (!FlipController.Instance.FlipDetected)
                {
                    offset = Mathf.MoveTowards(offset, 0f, 5f);
                }
            }

            return offset;
        }
    }
}