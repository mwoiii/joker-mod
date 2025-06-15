using EntityStates;
using RoR2;
using UnityEngine;
using EntityStates.Commando.CommandoWeapon;
using System;
using static UnityEngine.ParticleSystem.PlaybackState;
using RoR2.Projectile;
using R2API;
using SkillTest.DamageTypes;
using RoR2.Skills;

namespace SkillTest.MyEntityStates
{
    public class Eiha : PersonaSkillBase {

        public static SkillDef skillDef;

        public static float BaseDuration = 0.2f;

        public static float BaseDelayDuration = 0f;

        public static float DamageCoefficient = 4f;

        public override float spCost { get; } = 20f;
        
        private static GameObject bombProjectilePrefab => Assets.mainAssetBundle.LoadAsset<GameObject>("CommandoGrenadeProjectile");

        static Eiha() {
            LanguageAPI.Add("JOKER_SPECIAL_EIHA_NAME", "Eiha");
            LanguageAPI.Add("JOKER_SPECIAL_EIHA_DESCRIPTION", $"Cast a detonating curse projectile, dealing <style=cIsDamage>400% damage</style> plus " +
                $"<style=cIsDamage>5% max health damage</style> to all enemies caught in the attack.");

            skillDef = ScriptableObject.CreateInstance<SkillDef>();

            skillDef.activationState = new SerializableEntityStateType(typeof(SkillTest.MyEntityStates.Eiha));
            skillDef.activationStateMachineName = "Weapon";
            skillDef.baseMaxStock = 1;
            skillDef.baseRechargeInterval = 0f;
            skillDef.beginSkillCooldownOnSkillEnd = true;
            skillDef.canceledFromSprinting = false;
            skillDef.cancelSprintingOnActivation = false;
            skillDef.fullRestockOnAssign = true;
            skillDef.interruptPriority = InterruptPriority.Skill;
            skillDef.isCombatSkill = true;
            skillDef.mustKeyPress = true;
            skillDef.rechargeStock = 1;
            skillDef.requiredStock = 1;
            skillDef.stockToConsume = 1;
            skillDef.icon = null;
            skillDef.skillDescriptionToken = "JOKER_SPECIAL_EIHA_DESCRIPTION";
            skillDef.skillName = "JOKER_SPECIAL_EIHA_NAME";
            skillDef.skillNameToken = "JOKER_SPECIAL_EIHA_NAME";

            ContentAddition.AddSkillDef(skillDef);
        }

        public override void OnEnter() {
            skillHandler = base.GetComponent<JokerSkillHandler>();

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

        public override Ray ModifyProjectileAimRay(Ray aimRay) {
            Vector3 direction = aimRay.direction;
            aimRay.origin += new Vector3(-direction.x * 0.5f, 1.5f, -direction.z * 0.5f);

            return base.ModifyProjectileAimRay(aimRay);
        }
    }
}