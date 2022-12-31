using ModIO.UI;
using RapidGUI;
using UnityEngine;
using XXLMod.Controller;
using XXLMod.Data.Enums;

namespace XXLMod.UI
{
    public static class GeneralUI
    {
        public static bool showMenu;
        public static Rect rect = new Rect(1, 1, 100, 100);

        public static void Window(int windowID)
        {
            GUI.backgroundColor = Color.black;
            GUI.DragWindow(new Rect(0, 0, 10000, 20));

            Title();

            GUILayout.BeginVertical("Box");
            Main.Settings.GeneralSettings.Gravity = RGUI.SliderFloat(Main.Settings.GeneralSettings.Gravity, -30f, 0f, -9.807f, "Gravity");
            GUILayout.EndVertical();

            GUILayout.BeginVertical("Box");
            if (RGUI.Button(Main.Settings.GeneralSettings.IndividualPopForce, "Individual Pop Force"))
            {
                Main.Settings.GeneralSettings.IndividualPopForce = !Main.Settings.GeneralSettings.IndividualPopForce;
            }
            Main.Settings.GeneralSettings.DefaultPopForce = RGUI.SliderFloat(Main.Settings.GeneralSettings.DefaultPopForce, 0.5f, 5f, 3f, "Default Force");
            Main.Settings.GeneralSettings.DefaultHighPopForceMult = RGUI.SliderFloat(Main.Settings.GeneralSettings.DefaultHighPopForceMult, 0.35f, 1.5f, 0.5f, "Default High Pop Mult");
            Main.Settings.GeneralSettings.NolliePopForce = RGUI.SliderFloat(Main.Settings.GeneralSettings.NolliePopForce, 0.5f, 5f, 3f, "Nollie Force");
            Main.Settings.GeneralSettings.NollieHighPopForceMult = RGUI.SliderFloat(Main.Settings.GeneralSettings.NollieHighPopForceMult, 0.35f, 1.5f, 0.5f, "Nollie High Pop Mult");
            Main.Settings.GeneralSettings.SwitchPopForce = RGUI.SliderFloat(Main.Settings.GeneralSettings.SwitchPopForce, 0.5f, 5f, 3f, "Switch Force");
            Main.Settings.GeneralSettings.SwitchHighPopForceMult = RGUI.SliderFloat(Main.Settings.GeneralSettings.SwitchHighPopForceMult, 0.35f, 1.5f, 0.5f, "Switch High Pop Mult");
            Main.Settings.GeneralSettings.FakiePopForce = RGUI.SliderFloat(Main.Settings.GeneralSettings.FakiePopForce, 0.5f, 5f, 3f, "Fakie Force");
            Main.Settings.GeneralSettings.FakieHighPopForceMult = RGUI.SliderFloat(Main.Settings.GeneralSettings.FakieHighPopForceMult, 0.35f, 1.5f, 0.5f, "Fakie High Pop Mult");
            GUILayout.EndVertical();

            GUILayout.BeginVertical("Box");
            DoAdvancedPopModeTab();
            Main.Settings.GeneralSettings.ForwardPopForce = RGUI.SliderFloat(Main.Settings.GeneralSettings.ForwardPopForce, 0.5f, 500f, 100f, "Forward Force");
            Main.Settings.GeneralSettings.SidewayPopForce = RGUI.SliderFloat(Main.Settings.GeneralSettings.SidewayPopForce, 0.5f, 500f, 100f, "Sideway Force");
            GUILayout.EndVertical();
        }

        private static void DoAdvancedPopModeTab()
        {
            GUILayout.BeginHorizontal();
            Main.Settings.GeneralSettings.AdvancedPop = RGUI.Field(Main.Settings.GeneralSettings.AdvancedPop, "Advanced Pop", false);
            if (GUILayout.Button("<b><</b>", GUILayout.Width(30f), GUILayout.Height(21f)))
            {
                switch (Main.Settings.GeneralSettings.AdvancedPop)
                {
                    case AdvancedPopMode.Off:
                        Main.Settings.GeneralSettings.AdvancedPop = AdvancedPopMode.Trigger;
                        break;
                    case AdvancedPopMode.Bumper:
                        Main.Settings.GeneralSettings.AdvancedPop = AdvancedPopMode.Off;
                        break;
                    case AdvancedPopMode.Sticks:
                        Main.Settings.GeneralSettings.AdvancedPop = AdvancedPopMode.Bumper;
                        break;
                    case AdvancedPopMode.Trigger:
                        Main.Settings.GeneralSettings.AdvancedPop = AdvancedPopMode.Sticks;
                        break;
                }
            }
            if (GUILayout.Button("<b>></b>", GUILayout.Width(30f), GUILayout.Height(21f)))
            {
                switch (Main.Settings.GeneralSettings.AdvancedPop)
                {
                    case AdvancedPopMode.Off:
                        Main.Settings.GeneralSettings.AdvancedPop = AdvancedPopMode.Bumper;
                        break;
                    case AdvancedPopMode.Bumper:
                        Main.Settings.GeneralSettings.AdvancedPop = AdvancedPopMode.Sticks;
                        break;
                    case AdvancedPopMode.Sticks:
                        Main.Settings.GeneralSettings.AdvancedPop = AdvancedPopMode.Trigger;
                        break;
                    case AdvancedPopMode.Trigger:
                        Main.Settings.GeneralSettings.AdvancedPop = AdvancedPopMode.Off;
                        break;
                }
            }
            GUILayout.EndHorizontal();
        }

        private static void Title()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("<b>GENERAL/POP SETTINGS</b>", GUILayout.Height(21f));
            if (GUILayout.Button("<b>X</b>", GUILayout.Height(19f), GUILayout.Width(32f)))
            {
                UIController.Instance.MenuTab = MenuTab.Off;
            }
            GUILayout.EndHorizontal();
        }
    }
}