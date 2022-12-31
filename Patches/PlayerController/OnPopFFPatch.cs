using HarmonyLib;
using System;
using UnityEngine;
using XXLMod.Controller;
using XXLMod.Data.Enums;

namespace XXLMod.Patches.PlayerController_
{
    [HarmonyPatch(typeof(PlayerController), "OnPop", new Type[] { typeof(float), typeof(float) })]
    class OnPopFFPatch
    {
        static void Postfix(float p_pop, float p_scoop, ref float ____trajectoryToUp)
        {
            HandleAdvancedPop();
        }

        static void HandleAdvancedPop()
        {
            if (Main.Settings.GeneralSettings.AdvancedPop == AdvancedPopMode.Trigger)
            {
                Vector3 sideway = Vector3.ProjectOnPlane(PlayerController.Instance.skaterController.skaterTransform.right, PlayerController.Instance.skaterController.skaterTransform.up);
                Vector3 forward = Vector3.ProjectOnPlane(PlayerController.Instance.skaterController.skaterTransform.forward, PlayerController.Instance.skaterController.skaterTransform.up);
                if (PlayerController.Instance.inputController.player.GetButton("LT") && !PlayerController.Instance.inputController.player.GetButton("RT"))
                {
                    if (!PlayerController.Instance.IsSwitch)
                    {
                        sideway = -sideway;
                    }
                }
                else if (PlayerController.Instance.inputController.player.GetButton("RT") && !PlayerController.Instance.inputController.player.GetButton("LT"))
                {
                    if (PlayerController.Instance.IsSwitch)
                    {
                        sideway = -sideway;
                    }
                }
                else
                {
                    sideway = Vector3.zero;
                }
                if (PlayerController.Instance.inputController.player.GetButton("RT") && PlayerController.Instance.inputController.player.GetButton("LT"))
                {
                    if (PlayerController.Instance.IsSwitch)
                    {
                        forward = -forward;
                    }
                    PlayerController.Instance.skaterController.skaterRigidbody.AddForce(forward * Main.Settings.GeneralSettings.ForwardPopForce * Time.deltaTime, ForceMode.VelocityChange);
                }
                PlayerController.Instance.skaterController.skaterRigidbody.AddForce(sideway * Main.Settings.GeneralSettings.SidewayPopForce * Time.deltaTime, ForceMode.VelocityChange);
            }
            else if (Main.Settings.GeneralSettings.AdvancedPop == AdvancedPopMode.Bumper || Main.Settings.GeneralSettings.AdvancedPop == AdvancedPopMode.Sticks)
            {
                if (XXLController.Instance.LeftPop)
                {
                    XXLController.Instance.LeftPop = false;
                    Vector3 sideway = Vector3.ProjectOnPlane(PlayerController.Instance.skaterController.skaterTransform.right, PlayerController.Instance.skaterController.skaterTransform.up);
                    if (!PlayerController.Instance.IsSwitch)
                    {
                        sideway = -sideway;
                    }
                    PlayerController.Instance.skaterController.skaterRigidbody.AddForce(sideway * Main.Settings.GeneralSettings.SidewayPopForce * Time.deltaTime, ForceMode.VelocityChange);
                }
                else if (XXLController.Instance.RightPop)
                {
                    XXLController.Instance.RightPop = false;
                    Vector3 sideway = Vector3.ProjectOnPlane(PlayerController.Instance.skaterController.skaterTransform.right, PlayerController.Instance.skaterController.skaterTransform.up);
                    if (PlayerController.Instance.IsSwitch)
                    {
                        sideway = -sideway;
                    }
                    PlayerController.Instance.skaterController.skaterRigidbody.AddForce(sideway * Main.Settings.GeneralSettings.SidewayPopForce * Time.deltaTime, ForceMode.VelocityChange);
                }

                if (PlayerController.Instance.inputController.player.GetButton("RT") && PlayerController.Instance.inputController.player.GetButton("LT"))
                {
                    Vector3 forward = Vector3.ProjectOnPlane(PlayerController.Instance.skaterController.skaterTransform.forward, PlayerController.Instance.skaterController.skaterTransform.up);

                    if (PlayerController.Instance.IsSwitch)
                    {
                        forward = -forward;
                    }
                    PlayerController.Instance.skaterController.skaterRigidbody.AddForce(forward * Main.Settings.GeneralSettings.ForwardPopForce * Time.deltaTime, ForceMode.VelocityChange);
                }
            }
        }
    }
}
