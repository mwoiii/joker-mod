using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class EigaonState : PersonaSkillProjectileBaseState {

        public override float spCost { get; } = 12f;

        protected override void ActivateSkill() {
            damageCoefficient = 8f;
            projectilePrefab = Asset.eigaonPrefab;
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