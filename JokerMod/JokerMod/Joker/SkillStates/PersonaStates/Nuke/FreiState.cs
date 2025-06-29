using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class FreiState : PersonaSkillProjectileBaseState {

        public override float spCost { get; } = 4f;

        protected override void ActivateSkill() {
            damageCoefficient = 1f;
            projectilePrefab = Asset.freiPrefab;
            recoilAmplitude = 0f;
        }
    }
}