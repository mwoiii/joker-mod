using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class EihaState : PersonaSkillProjectileBaseState {

        public override float spCost { get; } = 4f;

        protected override void ActivateSkill() {
            damageCoefficient = 3f;
            projectilePrefab = Asset.eihaPrefab;
            recoilAmplitude = 0f;
            // baseDelayBeforeFiringProjectile = 0f;
            // force = 80f;
            // base.effectPrefab = Modules.Assets.SomeMuzzleEffect;
            // targetmuzzle = "muzzleThrow"
            // attackSoundString = "HenryBombThrow";
            // base.projectilePitchBonus = 0;
            // base.minSpread = 0;
            // base.maxSpread = 0;
            // bloom = 10;
        }
    }
}