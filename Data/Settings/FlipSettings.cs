using System;
using XXLMod.Data.Enums;

namespace XXLMod.Data.Settings
{
    [Serializable]
    public class FlipSettings
    {
        public FlipMode FlipMode = FlipMode.Simple;
        public float FlipAnimationSpeed = 1f;
        public float FlipBoardOffset = 0f;
        public DecoupledMode DecoupledMode = DecoupledMode.Off;
        public float FlipSpeed = 1f;
        public float FlipStrength = 1f;
        public bool LaidbackFlips = false;
        public LaidbackMode LaidbackMode = LaidbackMode.Off;
        public bool MidAirFlip = true;
        public bool MidFlipShuv = true;
        public float PopKickLeft = -0.7f;
        public float PopKickRight = 0.7f;
        public float ScoopSpeed = 1f;
        public bool PressureFlips = false;
        public VerticalScoopMode VerticalScoopMode = VerticalScoopMode.Off;
        public float Verticality = 1f;

        public FlipSettings()
        {

        }

        public FlipSettings(FlipMode flipMode, float flipAnimationSpeed, float flipBoardOffset, DecoupledMode decoupledMode, float flipSpeed, float flipStrength, bool laidbackFlips, LaidbackMode laidbackMode, bool midAirFlip, bool midFlipShuv, float popKickLeft, float popKickRight, float scoopSpeed, bool pressureFlips, VerticalScoopMode verticalScoopMode, float verticality)
        {
            FlipMode = flipMode;
            FlipAnimationSpeed = flipAnimationSpeed;
            FlipBoardOffset = flipBoardOffset;
            DecoupledMode = decoupledMode;
            FlipSpeed = flipSpeed;
            FlipStrength = flipStrength;
            LaidbackFlips = laidbackFlips;
            LaidbackMode = laidbackMode;
            MidAirFlip = midAirFlip;
            MidFlipShuv = midFlipShuv;
            PopKickLeft = popKickLeft;
            PopKickRight = popKickRight;
            ScoopSpeed = scoopSpeed;
            PressureFlips = pressureFlips;
            VerticalScoopMode = verticalScoopMode;
            Verticality = verticality;
        }
    }
}