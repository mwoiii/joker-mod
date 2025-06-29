using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class FreidyneState : PersonaSkillProjectileBaseState {

        public override float spCost { get; } = 12f;

        protected override void ActivateSkill() {
            damageCoefficient = 1f;
            projectilePrefab = Asset.freidynePrefab;
            recoilAmplitude = 0f;
        }
    }
}