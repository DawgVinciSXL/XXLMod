using System;
using UnityEngine;
using UnityModManagerNet;

namespace XXLMod
{
    [Serializable]
    public class Settings : UnityModManager.ModSettings, IDrawable
    {
        [Draw(DrawType.KeyBinding)] public KeyBinding MainMenu = new KeyBinding { keyCode = KeyCode.F7 };
        [Draw(DrawType.KeyBinding)] public KeyBinding StanceCustomizer = new KeyBinding { keyCode = KeyCode.U };
        [Draw(DrawType.KeyBinding)] public KeyBinding SteezeCustomizer = new KeyBinding { keyCode = KeyCode.I };
        [Draw(DrawType.KeyBinding)] public KeyBinding GrabCustomizer = new KeyBinding { keyCode = KeyCode.O };
        [Draw(DrawType.KeyBinding)] public KeyBinding Presets = new KeyBinding { keyCode = KeyCode.P };
        [Draw(DrawType.KeyBinding)] public KeyBinding PinManager = new KeyBinding { keyCode = KeyCode.Space };

        public float NotificationTimer = 2f;
        public bool Experimental = false;
        public bool Debugging = false;
        public Color BGColor = new Color(0f, 0f, 0f);

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