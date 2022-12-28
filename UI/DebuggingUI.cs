using UnityEngine;
using XXLMod.Controller;

namespace XXLMod.UI
{
    public static class DebuggingUI
    {
        public static bool showMenu;
        public static Rect rect = new Rect(20f, Screen.currentResolution.height - 370.5f, 300, 100);

        public static void Window(int windowID)
        {
            GUI.backgroundColor = Color.black;
            GUI.DragWindow(new Rect(0, 0, 10000, 20));

            GUILayout.BeginVertical("Box");
            GUILayout.Label($"<b>Board Backwards: {PlayerController.Instance.boardController.IsBoardBackwards}</b>");
            GUILayout.Label($"<b>Board Velocity: {PlayerController.Instance.boardController.boardRigidbody.velocity}</b>");
            GUILayout.Label($"<b>Board Velocity Mag: {PlayerController.Instance.boardController.boardRigidbody.velocity.magnitude}</b>");
            GUILayout.Label($"<b>Gravity: {Physics.gravity.y}</b>");
            GUILayout.Label($"<b>Is Scooping: {FlipController.Instance.IsScooping()}</b>");
            GUILayout.Label($"<b>Skater Velocity: {PlayerController.Instance.skaterController.skaterRigidbody.velocity}</b>");
            GUILayout.Label($"<b>Skater Velocity Mag: {PlayerController.Instance.skaterController.skaterRigidbody.velocity.magnitude}</b>");
            GUILayout.Label($"<b>Trick Detected: {FlipController.Instance.FlipDetected}</b>");
            GUILayout.Label($"<b>Kickflip: {FlipController.Instance.IsKickflip}</b>");
            GUILayout.Label($"<b>Heelflip: {FlipController.Instance.IsHeelflip}</b>");
            GUILayout.Label($"<b>BsShuv: {FlipController.Instance.IsBsShuv}</b>");
            GUILayout.Label($"<b>FsShuv: {FlipController.Instance.IsFsShuv}</b>");
            GUILayout.Label($"<b>PopType: {XXLController.PopType}</b>");

            GUILayout.EndVertical();

            //GUILayout.Label("X: " + UIController.Instance.TabMenuRect.size.x.ToString() + " Y: " + UIController.Instance.TabMenuRect.size.y.ToString());
            //GUILayout.Label("X: " + UIController.Instance.MainMenuRect.size.x.ToString() + " Y: " + UIController.Instance.MainMenuRect.size.y.ToString());
            //GUILayout.Label("X: " + PresetUI.Rect.size.x.ToString() + " Y: " + PresetUI.Rect.size.y.ToString());
        }

        private static void Title()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("<b>DEBUGGING</b>", GUILayout.Height(21f));
            if (GUILayout.Button("<b>X</b>", GUILayout.Height(19f), GUILayout.Width(32f)))
            {
                showMenu = !showMenu;
            }
            GUILayout.EndHorizontal();
        }
    }
}