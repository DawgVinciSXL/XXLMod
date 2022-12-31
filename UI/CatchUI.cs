using RapidGUI;
using UnityEngine;
using XXLMod.Controller;
using XXLMod.Data.Enums;

namespace XXLMod.UI
{
    public static class CatchUI
    {
        public static bool showMenu;
        public static Rect rect = new Rect(1, 1, 100, 100);

        public static void Window(int windowID)
        {
            GUI.backgroundColor = Color.black;
            GUI.DragWindow(new Rect(0, 0, 10000, 20));

            Title();

            GUILayout.BeginVertical("Box");
            DoCatchModeTab();
            GUILayout.EndVertical();
        }

        private static void DoCatchModeTab()
        {
            GUILayout.BeginHorizontal();
            Main.Settings.CatchSettings.CatchMode = RGUI.Field(Main.Settings.CatchSettings.CatchMode, "Catch Mode", false);
            if (GUILayout.Button("<b><</b>", GUILayout.Width(30f), GUILayout.Height(21f)))
            {
                switch (Main.Settings.CatchSettings.CatchMode)
                {
                    case CatchStyle.Auto:
                        Main.Settings.CatchSettings.CatchMode = CatchStyle.Realistic;
                        break;
                    case CatchStyle.Manual:
                        Main.Settings.CatchSettings.CatchMode = CatchStyle.Auto;
                        break;
                    case CatchStyle.Realistic:
                        Main.Settings.CatchSettings.CatchMode = CatchStyle.Manual;
                        break;
                }
            }
            if (GUILayout.Button("<b>></b>", GUILayout.Width(30f), GUILayout.Height(21f)))
            {
                switch (Main.Settings.CatchSettings.CatchMode)
                {
                    case CatchStyle.Auto:
                        Main.Settings.CatchSettings.CatchMode = CatchStyle.Manual;
                        break;
                    case CatchStyle.Manual:
                        Main.Settings.CatchSettings.CatchMode = CatchStyle.Realistic;
                        break;
                    case CatchStyle.Realistic:
                        Main.Settings.CatchSettings.CatchMode = CatchStyle.Auto;
                        break;
                }
            }
            GUILayout.EndHorizontal();
        }

        private static void Title()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("<b>CATCH SETTINGS</b>", GUILayout.Height(21f));
            if (GUILayout.Button("<b>X</b>", GUILayout.Height(19f), GUILayout.Width(32f)))
            {
                UIController.Instance.MenuTab = MenuTab.Off;
            }
            GUILayout.EndHorizontal();
        }
    }
}