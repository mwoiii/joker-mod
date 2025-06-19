using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class EihaState : PersonaSkillProjectileBaseState {

        public override float spCost { get; } = 20f;

        private static GameObject bombProjectilePrefab => Asset.mainAssetBundle.LoadAsset<GameObject>("CommandoGrenadeProjectile");

        protected override void ActivateSkill() {
            projectilePrefab = bombProjectilePrefab;

            //base.effectPrefab = Modules.Assets.SomeMuzzleEffect;
            //targetmuzzle = "muzzleThrow"

            // attackSoundString = "HenryBombThrow";

            baseDelayBeforeFiringProjectile = 0f;

            damageCoefficient = 3f;

            //proc coefficient is set on the components of the projectile prefab

            projectilePrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(CurseLight.damageType);
            force = 80f;

            //base.projectilePitchBonus = 0;
            //base.minSpread = 0;
            //base.maxSpread = 0;

            recoilAmplitude = 0.1f;
            bloom = 10;
        }
    }
}