﻿using SkaterXL.Core;
using UnityEngine;
using XXLMod.Data.Enums;

namespace XXLMod.Controller
{
    public class FlipController : MonoBehaviour
    {
        public static FlipController Instance { get; private set; }

        public bool FlipDetected;

        public bool IsKickflip;
        public bool IsHeelflip;
        public bool IsBsShuv;
        public bool IsFsShuv;

        public bool IsScooping()
        {
            return IsBsShuv || IsFsShuv;
        }

        private void Awake() => Instance = this;

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