using RapidGUI;
using UnityEngine;
using XXLMod.Controller;
using XXLMod.Data.Enums;

namespace XXLMod.UI
{
    public static class FlipUI
    {
        public static bool showMenu;
        public static Rect rect = new Rect(1, 1, 100, 100);

        public static void Window(int windowID)
        {
            GUI.backgroundColor = Color.black;
            GUI.DragWindow(new Rect(0, 0, 10000, 20));

            Title();

            GUILayout.BeginVertical("Box");
            Main.Settings.FlipSettings.FlipMode = RGUI.Field(Main.Settings.FlipSettings.FlipMode, "Flip Mode");
            GUILayout.EndVertical();

            DrawSettings();

            GUILayout.BeginVertical("Box");
            DoDecoupledModeTab();

            Main.Settings.FlipSettings.PopKickLeft = RGUI.SliderFloat(Main.Settings.FlipSettings.PopKickLeft, -5f, 5f, -0.7f, "Pop Kick Left");
            Main.Settings.FlipSettings.PopKickRight = RGUI.SliderFloat(Main.Settings.FlipSettings.PopKickRight, -5f, 5f, 0.7f, "Pop Kick Right");

            if (RGUI.Button(Main.Settings.FlipSettings.PressureFlips, "Pressure Flips"))
            {
                Main.Settings.FlipSettings.PressureFlips = !Main.Settings.FlipSettings.PressureFlips;
            }

            DoVerticalModeTab();
            GUILayout.EndVertical();
        }

        private static void DrawSettings()
        {
            switch (Main.Settings.FlipSettings.FlipMode)
            {
                case FlipMode.Simple:
                    SimpleSettings();
                    break;
                case FlipMode.Expert:
                    break;
            }
        }

        private static void SimpleSettings()
        {
            GUILayout.BeginVertical("Box");
            Main.Settings.FlipSettings.FlipBoardOffset = RGUI.SliderFloat(Main.Settings.FlipSettings.FlipBoardOffset, -0.2f, 0.3f, 0f, "Board Offset");
            Main.Settings.FlipSettings.FlipSpeed = RGUI.SliderFloat(Main.Settings.FlipSettings.FlipSpeed, 0f, 2.5f, 1f, "Flip Speed");

            DoLaidbackModeTab();

            Main.Settings.FlipSettings.ScoopSpeed = RGUI.SliderFloat(Main.Settings.FlipSettings.ScoopSpeed, 0f, 2.5f, 1f, "Scoop Speed");
            Main.Settings.FlipSettings.Verticality = RGUI.SliderFloat(Main.Settings.FlipSettings.Verticality, -2f, 2f, 1f, "Verticality");
            GUILayout.EndVertical();
        }

        private static void DoDecoupledModeTab()
        {
            GUILayout.BeginHorizontal();
            Main.Settings.FlipSettings.DecoupledMode = RGUI.Field(Main.Settings.FlipSettings.DecoupledMode, "Decoupled Board", false);
            if (GUILayout.Button("<b><</b>", GUILayout.Width(30f), GUILayout.Height(21f)))
            {
                switch (Main.Settings.FlipSettings.DecoupledMode)
                {
                    case DecoupledMode.Off:
                        Main.Settings.FlipSettings.DecoupledMode = DecoupledMode.Total;
                        break;
                    case DecoupledMode.Simple:
                        Main.Settings.FlipSettings.DecoupledMode = DecoupledMode.Off;
                        break;
                    case DecoupledMode.Total:
                        Main.Settings.FlipSettings.DecoupledMode = DecoupledMode.Simple;
                        break;
                }
            }
            if (GUILayout.Button("<b>></b>", GUILayout.Width(30f), GUILayout.Height(21f)))
            {
                switch (Main.Settings.FlipSettings.DecoupledMode)
                {
                    case DecoupledMode.Off:
                        Main.Settings.FlipSettings.DecoupledMode = DecoupledMode.Simple;
                        break;
                    case DecoupledMode.Simple:
                        Main.Settings.FlipSettings.DecoupledMode = DecoupledMode.Total;
                        break;
                    case DecoupledMode.Total:
                        Main.Settings.FlipSettings.DecoupledMode = DecoupledMode.Off;
                        break;
                }
            }
            GUILayout.EndHorizontal();
        }

        private static void DoLaidbackModeTab()
        {
            GUILayout.BeginHorizontal();
            Main.Settings.FlipSettings.LaidbackMode = RGUI.Field(Main.Settings.FlipSettings.LaidbackMode, "Laidback Mode", false);
            if (GUILayout.Button("<b><</b>", GUILayout.Width(30f), GUILayout.Height(21f)))
            {
                switch (Main.Settings.FlipSettings.LaidbackMode)
                {
                    case LaidbackMode.Off:
                        Main.Settings.FlipSettings.LaidbackMode = LaidbackMode.Always;
                        break;
                    case LaidbackMode.Auto:
                        Main.Settings.FlipSettings.LaidbackMode = LaidbackMode.Off;
                        break;
                    case LaidbackMode.Bumper:
                        Main.Settings.FlipSettings.LaidbackMode = LaidbackMode.Auto;
                        break;
                    case LaidbackMode.Sticks:
                        Main.Settings.FlipSettings.LaidbackMode = LaidbackMode.Bumper;
                        break;
                    case LaidbackMode.Always:
                        Main.Settings.FlipSettings.LaidbackMode = LaidbackMode.Sticks;
                        break;
                }
            }
            if (GUILayout.Button("<b>></b>", GUILayout.Width(30f), GUILayout.Height(21f)))
            {
                switch (Main.Settings.FlipSettings.LaidbackMode)
                {
                    case LaidbackMode.Off:
                        Main.Settings.FlipSettings.LaidbackMode = LaidbackMode.Auto;
                        break;
                    case LaidbackMode.Auto:
                        Main.Settings.FlipSettings.LaidbackMode = LaidbackMode.Bumper;
                        break;
                    case LaidbackMode.Bumper:
                        Main.Settings.FlipSettings.LaidbackMode = LaidbackMode.Sticks;
                        break;
                    case LaidbackMode.Sticks:
                        Main.Settings.FlipSettings.LaidbackMode = LaidbackMode.Always;
                        break;
                    case LaidbackMode.Always:
                        Main.Settings.FlipSettings.LaidbackMode = LaidbackMode.Off;
                        break;
                }
            }
            GUILayout.EndHorizontal();
        }

        private static void DoVerticalModeTab()
        {
            GUILayout.BeginHorizontal();
            Main.Settings.FlipSettings.VerticalScoopMode = RGUI.Field(Main.Settings.FlipSettings.VerticalScoopMode, "Vertical Scoop", false);
            if (GUILayout.Button("<b><</b>", GUILayout.Width(30f), GUILayout.Height(21f)))
            {
                switch (Main.Settings.FlipSettings.VerticalScoopMode)
                {
                    case VerticalScoopMode.Off:
                        Main.Settings.FlipSettings.VerticalScoopMode = VerticalScoopMode.XXL2;
                        break;
                    case VerticalScoopMode.Auto:
                        Main.Settings.FlipSettings.VerticalScoopMode = VerticalScoopMode.Off;
                        break;
                    case VerticalScoopMode.LB:
                        Main.Settings.FlipSettings.VerticalScoopMode = VerticalScoopMode.Auto;
                        break;
                    case VerticalScoopMode.RB:
                        Main.Settings.FlipSettings.VerticalScoopMode = VerticalScoopMode.LB;
                        break;
                    case VerticalScoopMode.XXL2:
                        Main.Settings.FlipSettings.VerticalScoopMode = VerticalScoopMode.RB;
                        break;
                }
            }
            if (GUILayout.Button("<b>></b>", GUILayout.Width(30f), GUILayout.Height(21f)))
            {
                switch (Main.Settings.FlipSettings.VerticalScoopMode)
                {
                    case VerticalScoopMode.Off:
                        Main.Settings.FlipSettings.VerticalScoopMode = VerticalScoopMode.Auto;
                        break;
                    case VerticalScoopMode.Auto:
                        Main.Settings.FlipSettings.VerticalScoopMode = VerticalScoopMode.LB;
                        break;
                    case VerticalScoopMode.LB:
                        Main.Settings.FlipSettings.VerticalScoopMode = VerticalScoopMode.RB;
                        break;
                    case VerticalScoopMode.RB:
                        Main.Settings.FlipSettings.VerticalScoopMode = VerticalScoopMode.XXL2;
                        break;
                    case VerticalScoopMode.XXL2:
                        Main.Settings.FlipSettings.VerticalScoopMode = VerticalScoopMode.Off;
                        break;
                }
            }
            GUILayout.EndHorizontal();
        }

        private static void Title()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("<b>FLIP SETTINGS</b>", GUILayout.Height(21f));
            if (GUILayout.Button("<b>X</b>", GUILayout.Height(19f), GUILayout.Width(32f)))
            {
                UIController.Instance.MenuTab = MenuTab.Off;
            }
            GUILayout.EndHorizontal();
        }
    }
}