using HarmonyLib;
using XXLMod.Controller;
using XXLMod.Data.Enums;

namespace XXLMod.Patches.PlayerState_Pop_
{
    [HarmonyPatch(typeof(PlayerState_Pop), "Update")]
    class UpdatePatch
    {
        static void Postfix(ref bool ____flipDetected)
        {
            if (PlayerController.Instance.GetAnimReleased())
            {
                FlipController.Instance.FlipDetected = true;
            }

			HandleLaidback(____flipDetected);
        }

        static void HandleLaidback(bool flipDetected)
        {
            if(Main.Settings.FlipSettings.LaidbackMode != LaidbackMode.Off)
            {
				switch (Main.Settings.FlipSettings.LaidbackMode)
				{
					case LaidbackMode.Off:
						break;
					case LaidbackMode.Auto:
						if (flipDetected && !PlayerController.Instance.IsCurrentAnimationPlaying("Extend"))
						{
							if (PlayerController.Instance.inputController.LeftStick.IsCentered && PlayerController.Instance.inputController.RightStick.IsCentered)
							{
								FlipController.Instance.IsLaidbackFlip = true;
								PlayerController.Instance.CrossFadeAnimation("Extend", 0.3f);
							}
						}
						break;
					case LaidbackMode.Bumper:
						if (PlayerController.Instance.inputController.player.GetButton("RB") && PlayerController.Instance.inputController.player.GetButton("LB"))
						{
							PlayerController.Instance.SetRightIKLerpTarget(1f, 1f);
							PlayerController.Instance.SetRightSteezeWeight(1f);
							PlayerController.Instance.SetMaxSteezeRight(1f);
							PlayerController.Instance.SetRightKneeIKTargetWeight(1f);
							PlayerController.Instance.SetRightIKWeight(1f);
							PlayerController.Instance.SetRightKneeBendWeight(1f);
							PlayerController.Instance.SetRightKneeBendWeightManually(1f);

							PlayerController.Instance.SetLeftIKLerpTarget(1f, 1f);
							PlayerController.Instance.SetLeftSteezeWeight(1f);
							PlayerController.Instance.SetMaxSteezeLeft(1f);
							PlayerController.Instance.SetLeftKneeIKTargetWeight(1f);
							PlayerController.Instance.SetLeftIKWeight(1f);
							PlayerController.Instance.SetLeftKneeBendWeight(1f);
							PlayerController.Instance.SetLeftKneeBendWeightManually(1f);

							FlipController.Instance.IsLaidbackFlip = true;
							PlayerController.Instance.CrossFadeAnimation("Extend", 0.15f);
						}
						break;
					case LaidbackMode.Sticks:
						if (PlayerController.Instance.inputController.player.GetButton("Left Stick Button") && PlayerController.Instance.inputController.player.GetButton("Right Stick Button"))
						{
							PlayerController.Instance.SetRightIKLerpTarget(1f, 1f);
							PlayerController.Instance.SetRightSteezeWeight(1f);
							PlayerController.Instance.SetMaxSteezeRight(1f);
							PlayerController.Instance.SetRightKneeIKTargetWeight(1f);
							PlayerController.Instance.SetRightIKWeight(1f);
							PlayerController.Instance.SetRightKneeBendWeight(1f);
							PlayerController.Instance.SetRightKneeBendWeightManually(1f);

							PlayerController.Instance.SetLeftIKLerpTarget(1f, 1f);
							PlayerController.Instance.SetLeftSteezeWeight(1f);
							PlayerController.Instance.SetMaxSteezeLeft(1f);
							PlayerController.Instance.SetLeftKneeIKTargetWeight(1f);
							PlayerController.Instance.SetLeftIKWeight(1f);
							PlayerController.Instance.SetLeftKneeBendWeight(1f);
							PlayerController.Instance.SetLeftKneeBendWeightManually(1f);

							FlipController.Instance.IsLaidbackFlip = true;
							PlayerController.Instance.CrossFadeAnimation("Extend", 0.15f);
						}
						break;
					case LaidbackMode.Always:
						if (flipDetected && !PlayerController.Instance.IsCurrentAnimationPlaying("Extend"))
						{
							FlipController.Instance.IsLaidbackFlip = true;
							PlayerController.Instance.CrossFadeAnimation("Extend", 0.3f);
						}
						break;
				}
			}
        }
    }
}