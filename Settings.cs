using System;
using UnityEngine;
using UnityModManagerNet;
using XXLMod.Data.Settings;

namespace XXLMod
{
    [Serializable]
    public class Settings : UnityModManager.ModSettings, IDrawable
    {
        [Draw(DrawType.KeyBinding)] public KeyBinding MainMenu = new KeyBinding { keyCode = KeyCode.F7 };

        public float NotificationTimer = 2f;
        public bool Experimental = false;
        public bool Debugging = false;
        public Color BGColor = new Color(0f, 0f, 0f);

        public GeneralSettings GeneralSettings = new GeneralSettings();
        public FlipSettings FlipSettings = new FlipSettings();

        public void OnChange()
        {
            throw new NotImplementedException();
        }

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save<Settings>(this, modEntry);
        }
    }
}