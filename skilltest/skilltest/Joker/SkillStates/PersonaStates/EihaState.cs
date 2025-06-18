using EntityStates;
using RoR2;
using UnityEngine;
using EntityStates.Commando.CommandoWeapon;
using System;
using static UnityEngine.ParticleSystem.PlaybackState;
using RoR2.Projectile;
using R2API;
using RoR2.Skills;
using JokerMod.Joker.Components;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using JokerMod.Modules.DamageTypes;

namespace JokerMod.Joker.SkillStates.PersonaStates
{
    public class EihaState : PersonaSkillStateBase
    {

        public static float BaseDuration = 0.2f;

        public static float BaseDelayDuration = 0f;

        public static float DamageCoefficient = 4f;

        public override float spCost { get; } = 20f;

        private static GameObject bombProjectilePrefab => Asset.mainAssetBundle.LoadAsset<GameObject>("CommandoGrenadeProjectile");

        public override void OnEnter() {

            projectilePrefab = bombProjectilePrefab;
            //base.effectPrefab = Modules.Assets.SomeMuzzleEffect;
            //targetmuzzle = "muzzleThrow"

            // attackSoundString = "HenryBombThrow";

            baseDuration = BaseDuration;
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