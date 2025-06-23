using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class EihaState : PersonaSkillProjectileBaseState {

        public override float spCost { get; } = 4f;

        protected override void ActivateSkill() {
            damageCoefficient = 3f;

            projectilePrefab = Asset.eihaPrefab;

            //base.effectPrefab = Modules.Assets.SomeMuzzleEffect;
            //targetmuzzle = "muzzleThrow"

            // attackSoundString = "HenryBombThrow";

            baseDelayBeforeFiringProjectile = 0f;

            //proc coefficient is set on the components of the projectile prefab

            projectilePrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(CurseLightType.damageType);
            force = 80f;

            //base.projectilePitchBonus = 0;
            //base.minSpread = 0;
            //base.maxSpread = 0;

            recoilAmplitude = 0.1f;
            bloom = 10;
        }
    }
}