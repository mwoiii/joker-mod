using JokerMod.Modules.PersonaSkills;

namespace JokerMod.Joker.SkillStates {
    public class MakouhaState : KouhaState {

        public override SkillTypes.SkillType skillType => SkillTypes.SkillType.Bless;

        public override float baseSPCost { get; } = 10f;

        protected override int startPitch => -22;

        protected override int incPitch => 22;

        protected override int maxPitch => 66;

        protected override int startYaw => 0;

        protected override int incYaw => 60;

        protected override int maxYaw => 300;

        protected override float fixedDistance => 25f;

        protected override bool ignoreY => true;
    }
}