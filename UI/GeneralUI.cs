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