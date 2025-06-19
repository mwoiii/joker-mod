using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class EihaState : PersonaSkillStateBase {
        public static float BaseDelayDuration = 0f;

        public static float DamageCoefficient = 3f;

        public override float spCost { get; } = 20f;

        private static GameObject bombProjectilePrefab => Asset.mainAssetBundle.LoadAsset<GameObject>("CommandoGrenadeProjectile");

        public override void OnEnter() {

            projectilePrefab = bombProjectilePrefab;
            //base.effectPrefab = Modules.Assets.SomeMuzzleEffect;
            //targetmuzzle = "muzzleThrow"

            // attackSoundString = "HenryBombThrow";

            baseDelayBeforeFiringProjectile = BaseDelayDuration;

            damageCoefficient = DamageCoefficient;

            //proc coefficient is set on the components of the projectile prefab
            projectilePrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(CurseLight.damageType);
            force = 80f;

            //base.projectilePitchBonus = 0;
            //base.minSpread = 0;
            //base.maxSpread = 0;

            recoilAmplitude = 0.1f;
            bloom = 10;
            base.OnEnter();
        }

        /*
        public override Ray ModifyProjectileAimRay(Ray aimRay)
        {
            Vector3 direction = aimRay.direction;
            aimRay.origin += new Vector3(-direction.x * 0.5f, 1.5f, -direction.z * 0.5f);

            return base.ModifyProjectileAimRay(aimRay);
        }
        */
    }
}