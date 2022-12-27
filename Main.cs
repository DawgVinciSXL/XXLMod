using HarmonyLib;
using RapidGUI;
using System;
using System.Reflection;
using UnityEngine;
using UnityModManagerNet;

namespace XXLMod
{
    public class Main
    {
        public static string Version = "";

        public static Harmony HarmonyInstance;
        public static UnityModManager.ModEntry.ModLogger Logger;
        public static Settings Settings;
        public static UnityModManager.ModEntry modEntry;

        public static bool enabled;

        private static bool Load(UnityModManager.ModEntry modEntry)
        {
            Settings = UnityModManager.ModSettings.Load<Settings>(modEntry);
            modEntry.OnGUI = OnGUI;
            modEntry.OnSaveGUI = new Action<UnityModManager.ModEntry>(OnSaveGUI);
            modEntry.OnToggle = new Func<UnityModManager.ModEntry, bool, bool>(OnToggle);
            Main.modEntry = modEntry;
            return true;
        }

        private static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            GUILayout.Box("<b>Background Color</b>", GUILayout.Height(21f));
            Settings.BGColor.r = RGUI.SliderFloat(Settings.BGColor.r, 0f, 1f, 0f, "Red");
            Settings.BGColor.g = RGUI.SliderFloat(Settings.BGColor.g, 0f, 1f, 0f, "Green");
            Settings.BGColor.b = RGUI.SliderFloat(Settings.BGColor.b, 0f, 1f, 0f, "Blue");
            GUILayout.Box("<b>Hotkeys</b>", GUILayout.Height(21f));
            Settings.Draw(modEntry);
        }

        private static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            Settings.Save(modEntry);
        }

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if (value == enabled)
            {
                return true;
            }

            enabled = value;

            if (enabled)
            {
                HarmonyInstance = new Harmony(modEntry.Info.Id);
                HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());

            }
            else
            {
                HarmonyInstance.UnpatchAll(HarmonyInstance.Id);
                ResetToDefault();
            }
            return true;
        }

        private static void ResetToDefault()
        {
        }
    }
}