using SkaterXL.Core;
using UnityEngine;
using XXLMod.Data.Enums;

namespace XXLMod.Controller
{
    public class FlipController : MonoBehaviour
    {
        public static FlipController Instance { get; private set; }

        public bool FlipDetected;

        public bool IsLaidbackFlip;

        public bool IsKickflip;
        public bool IsHeelflip;
        public bool IsBsShuv;
        public bool IsFsShuv;

        public bool IsFlipping()
        {
            return IsKickflip || IsHeelflip;
        }

        public bool IsScooping()
        {
            return IsBsShuv || IsFsShuv;
        }

        private void Awake() => Instance = this;

        public void ResetDetected()
        {
            FlipDetected = false;
            IsLaidbackFlip = false;
            IsKickflip = false;
            IsHeelflip = false;
            IsBsShuv = false;
            IsFsShuv = false;
        }

        public void PressureFlip()
        {
            if (Main.Settings.FlipSettings.PressureFlips)
            {
                if (PlayerController.Instance.inputController.player.GetButton("Left Stick Button"))
                {
                    if (PlayerController.Instance.inputController.LeftStick.rawInput.pos.x >= 0.1f)
                    {
                        if (PlayerController.Instance.boardController.IsBoardBackwards)
                        {
                            PlayerController.Instance.SetRightIKLerpTarget(1f, 0.5f);
                            PlayerController.Instance.SetLeftIKLerpTarget(0.5f, 0f);
                            PlayerController.Instance.boardController.thirdVel = -40f;
                            return;
                        }
                        PlayerController.Instance.SetRightIKLerpTarget(1f, 0.5f);
                        PlayerController.Instance.SetLeftIKLerpTarget(0.5f, 0f);
                        PlayerController.Instance.boardController.thirdVel = 40f;
                        return;
                    }
                    if (PlayerController.Instance.inputController.LeftStick.rawInput.pos.x <= -0.1f)
                    {
                        if (PlayerController.Instance.boardController.IsBoardBackwards)
                        {
                            PlayerController.Instance.SetRightIKLerpTarget(0.8f, 1f);
                            PlayerController.Instance.SetLeftIKLerpTarget(0f, 1f);
                            PlayerController.Instance.boardController.thirdVel = 40f;
                            return;
                        }
                        PlayerController.Instance.SetRightIKLerpTarget(0.8f, 1f);
                        PlayerController.Instance.SetLeftIKLerpTarget(0f, 1f);
                        PlayerController.Instance.boardController.thirdVel = -40f;
                        return;
                    }
                }
                else if (PlayerController.Instance.inputController.player.GetButton("Right Stick Button"))
                {
                    if (PlayerController.Instance.inputController.RightStick.rawInput.pos.x >= 0.1f)
                    {
                        if (PlayerController.Instance.boardController.IsBoardBackwards)
                        {
                            PlayerController.Instance.SetRightIKLerpTarget(0f, 1f);
                            PlayerController.Instance.SetLeftIKLerpTarget(0.8f, 1f);
                            PlayerController.Instance.boardController.thirdVel = -40f;
                            return;
                        }
                        PlayerController.Instance.SetRightIKLerpTarget(0f, 1f);
                        PlayerController.Instance.SetLeftIKLerpTarget(0.8f, 1f);
                        PlayerController.Instance.boardController.thirdVel = 40f;
                        return;
                    }
                    if (PlayerController.Instance.inputController.RightStick.rawInput.pos.x <= -0.1f)
                    {
                        if (PlayerController.Instance.boardController.IsBoardBackwards)
                        {
                            PlayerController.Instance.SetRightIKLerpTarget(0f, 1f);
                            PlayerController.Instance.SetLeftIKLerpTarget(1f, 0.5f);
                            PlayerController.Instance.boardController.thirdVel = 40f;
                            return;
                        }
                        PlayerController.Instance.SetRightIKLerpTarget(0f, 1f);
                        PlayerController.Instance.SetLeftIKLerpTarget(0.8f, 1f);
                        PlayerController.Instance.boardController.thirdVel = -40f;
                    }
                }
            }
        }

        public void VerticalScoop()
        {
            if (!IsScooping())
            {
                return;
            }

            bool reverse = XXLController.PopType == XXLPopType.Nollie || XXLController.PopType == XXLPopType.Switch;

            float verticality = 0f;

            verticality = Main.Settings.FlipSettings.Verticality;

            switch (Main.Settings.FlipSettings.VerticalScoopMode)
            {
                case VerticalScoopMode.Off:
                    return;
                case VerticalScoopMode.Auto:
                    if (SettingsManager.Instance.stance == Stance.Goofy)
                    {
                        if (PlayerController.Instance.boardController.IsBoardBackwards)
                        {
                            PlayerController.Instance.boardController.firstVel = reverse ? -verticality : verticality;
                            return;
                        }
                        PlayerController.Instance.boardController.firstVel = reverse ? verticality : -verticality;
                        return;
                    }

                    if (PlayerController.Instance.boardController.IsBoardBackwards)
                    {
                        PlayerController.Instance.boardController.firstVel = reverse ? -verticality : verticality;
                        return;
                    }
                    PlayerController.Instance.boardController.firstVel = reverse ? verticality : -verticality;
                    break;
                case VerticalScoopMode.LB:
                    if (PlayerController.Instance.inputController.player.GetButton("LB") && !PlayerController.Instance.inputController.player.GetButton("RB"))
                    {
                        if (SettingsManager.Instance.stance == Stance.Goofy)
                        {
                            if (PlayerController.Instance.boardController.IsBoardBackwards)
                            {
                                PlayerController.Instance.boardController.firstVel = reverse ? -verticality : verticality;
                                return;
                            }
                            PlayerController.Instance.boardController.firstVel = reverse ? verticality : -verticality;
                            return;
                        }

                        if (PlayerController.Instance.boardController.IsBoardBackwards)
                        {
                            PlayerController.Instance.boardController.firstVel = reverse ? -verticality : verticality;
                            return;
                        }
                        PlayerController.Instance.boardController.firstVel = reverse ? verticality : -verticality;
                        return;
                    }
                    break;
                case VerticalScoopMode.RB:
                    if (PlayerController.Instance.inputController.player.GetButton("RB") && !PlayerController.Instance.inputController.player.GetButton("LB"))
                    {
                        if (SettingsManager.Instance.stance == Stance.Goofy)
                        {
                            if (PlayerController.Instance.boardController.IsBoardBackwards)
                            {
                                PlayerController.Instance.boardController.firstVel = reverse ? -verticality : verticality;
                                return;
                            }
                            PlayerController.Instance.boardController.firstVel = reverse ? verticality : -verticality;
                            return;
                        }

                        if (PlayerController.Instance.boardController.IsBoardBackwards)
                        {
                            PlayerController.Instance.boardController.firstVel = reverse ? -verticality : verticality;
                            return;
                        }
                        PlayerController.Instance.boardController.firstVel = reverse ? verticality : -verticality;
                        return;
                    }
                    break;
                case VerticalScoopMode.XXL2:
                    if (SettingsManager.Instance.stance == Stance.Goofy)
                    {
                        if (PlayerController.Instance.inputController.player.GetButton("RB") && !PlayerController.Instance.inputController.player.GetButton("LB"))
                        {
                            if (PlayerController.Instance.boardController.IsBoardBackwards)
                            {
                                PlayerController.Instance.boardController.firstVel = verticality;
                                return;
                            }
                            PlayerController.Instance.boardController.firstVel = -verticality;
                        }
                        else if (PlayerController.Instance.inputController.player.GetButton("LB") && !PlayerController.Instance.inputController.player.GetButton("RB"))
                        {
                            if (PlayerController.Instance.boardController.IsBoardBackwards)
                            {
                                PlayerController.Instance.boardController.firstVel = -verticality;
                                return;
                            }
                            PlayerController.Instance.boardController.firstVel = verticality;
                            return;
                        }
                    }
                    else
                    {
                        if (PlayerController.Instance.inputController.player.GetButton("LB") && !PlayerController.Instance.inputController.player.GetButton("RB"))
                        {
                            if (PlayerController.Instance.boardController.IsBoardBackwards)
                            {
                                PlayerController.Instance.boardController.firstVel = -verticality;
                                return;
                            }
                            PlayerController.Instance.boardController.firstVel = verticality;
                            return;
                        }
                        else if (PlayerController.Instance.inputController.player.GetButton("RB") && !PlayerController.Instance.inputController.player.GetButton("LB"))
                        {
                            if (PlayerController.Instance.boardController.IsBoardBackwards)
                            {
                                PlayerController.Instance.boardController.firstVel = verticality;
                                return;
                            }
                            PlayerController.Instance.boardController.firstVel = -verticality;
                        }
                    }
                    break;
            }
        }
    }
}