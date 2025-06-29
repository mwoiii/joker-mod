using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class FreilaState : PersonaSkillProjectileBaseState {

        public override float spCost { get; } = 8f;

        protected override void ActivateSkill() {
            damageCoefficient = 1f;
            projectilePrefab = Asset.freilaPrefab;
            recoilAmplitude = 0f;
        }
    }
}