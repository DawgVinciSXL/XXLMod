using UnityEngine;
using XXLMod.Data.Enums;
using XXLMod.UI;

namespace XXLMod.Controller
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance { get; private set; }

        public Rect MainMenuRect;
        public Rect TabMenuRect;

        public bool setupGUI;
        public bool showMainMenu;

        private string Title = "";

        public MenuTab MenuTab = MenuTab.Off;

        private void Awake() => Instance = this;

        private void Start()
        {
            Title = $"XXLMod {Main.Version}";
            MainMenuRect = new Rect(15f, Screen.currentResolution.height / 2 - 370.5f, 100f, 200f);
            TabMenuRect = new Rect(225f, Screen.currentResolution.height / 2 - 370.5f, 100f, 200f);
        }

        private void Update()
        {
            if (Input.GetKeyDown(Main.Settings.MainMenu.keyCode))
            {
                if (!showMainMenu)
                {
                    Open();
                    return;
                }
                Close();
            }
        }

        private void Open()
        {
            showMainMenu = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        private void Close()
        {
            showMainMenu = false;
            Cursor.visible = false;
        }

        private void OnGUI()
        {
            if (showMainMenu)
            {
                GUI.backgroundColor = Main.Settings.BGColor;
                MainMenuRect = GUILayout.Window(9000, MainMenuRect, MainMenu, "<b>XXLMOD3</b>");

                switch (MenuTab)
                {
                    case MenuTab.General:
                        TabMenuRect = GUI.Window(9001, new Rect(TabMenuRect.position, new Vector2(444f, 664f)), GeneralUI.Window, $"<b>{Title}</b>");
                        break;
                }
            }
        }

        private void MainMenu(int windowID)
        {
            GUI.backgroundColor = Color.black;
            GUI.DragWindow(new Rect(0, 0, 10000, 20));

            if (GUILayout.Button("<b>GENERAL/POP</b>", GUILayout.Height(21f)))
            {
                MenuTab = (MenuTab == MenuTab.General) ? MenuTab.Off : MenuTab.General;
            }
        }

        private void OnApplicationQuit()
        {
            Main.Settings.Save(Main.modEntry);
        }
    }
}