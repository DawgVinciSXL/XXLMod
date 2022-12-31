using UnityEngine;
using XXLMod.Data.Enums;

namespace XXLMod.Controller
{
    public class XXLController : MonoBehaviour
    {
        public static XXLController Instance { get; private set; }

        public static XXLPopType PopType;

        public bool LeftPop;
        public bool RightPop;

        private void Awake() => Instance = this;

        private void Start()
        {
        }

        private void Update()
        {
        }

        private void LateUpdate()
        {
            Physics.gravity = new Vector3(0, Main.Settings.GeneralSettings.Gravity, 0);
        }

        public void AdvancedPop()
        {
            if (Main.enabled && Main.Settings.GeneralSettings.AdvancedPop == AdvancedPopMode.Bumper)
            {
                if (PlayerController.Instance.inputController.player.GetButtonDown("LB") && !PlayerController.Instance.inputController.player.GetButtonDown("RB"))
                {
                    LeftPop = !LeftPop;
                    RightPop = false;
                }
                else if (PlayerController.Instance.inputController.player.GetButtonDown("RB") && !PlayerController.Instance.inputController.player.GetButtonDown("LB"))
                {
                    RightPop = !RightPop;
                    LeftPop = false;
                }
            }

            if (Main.enabled && Main.Settings.GeneralSettings.AdvancedPop == AdvancedPopMode.Sticks)
            {
                if (PlayerController.Instance.inputController.player.GetButtonDown("Left Stick Button") && !PlayerController.Instance.inputController.player.GetButtonDown("Right Stick Button"))
                {
                    LeftPop = !LeftPop;
                    RightPop = false;
                }
                else if (PlayerController.Instance.inputController.player.GetButtonDown("Right Stick Button") && !PlayerController.Instance.inputController.player.GetButtonDown("Left Stick Button"))
                {
                    RightPop = !RightPop;
                    LeftPop = false;
                }
            }
        }

        public void ResetAdvancedPop()
        {
            LeftPop = false;
            RightPop = false;
        }

        public float GetPopForce(bool forwardLoad)
        {
            if (Main.Settings.GeneralSettings.IndividualPopForce)
            {
                if (!PlayerController.Instance.IsSwitch)
                {
                    if (!forwardLoad)
                    {
                        return Main.Settings.GeneralSettings.DefaultPopForce;
                    }
                    else
                    {
                        return Main.Settings.GeneralSettings.NolliePopForce;
                    }
                }
                else if (!forwardLoad)
                {
                    return Main.Settings.GeneralSettings.FakiePopForce;
                }
                else
                {
                    return Main.Settings.GeneralSettings.SwitchPopForce;
                }
            }
            else
            {
                return Main.Settings.GeneralSettings.DefaultPopForce;
            }
        }

        public float GetHighPopForceMultiplier(bool forwardLoad)
        {
            if (Main.Settings.GeneralSettings.IndividualPopForce)
            {
                if (!PlayerController.Instance.IsSwitch)
                {
                    if (!forwardLoad)
                    {
                        return Main.Settings.GeneralSettings.DefaultHighPopForceMult;
                    }
                    else
                    {
                        return Main.Settings.GeneralSettings.NollieHighPopForceMult;
                    }
                }
                else if (!forwardLoad)
                {
                    return Main.Settings.GeneralSettings.FakieHighPopForceMult;
                }
                else
                {
                    return Main.Settings.GeneralSettings.SwitchHighPopForceMult;
                }
            }
            else
            {
                return Main.Settings.GeneralSettings.DefaultHighPopForceMult;
            }
        }
    }
}