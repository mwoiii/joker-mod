using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using JokerMod.Modules.PersonaSkills;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class EihaState : PersonaSkillBaseState {

        public override SkillTypes.SkillType skillType => SkillTypes.SkillType.Curse;

        public override float baseSPCost { get; } = 4f;

        protected virtual GameObject projectilePrefab => Asset.eihaPrefab;

        protected override void ActivateSkill() {
            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);

            ProjectileManager.instance.FireProjectile(new FireProjectileInfo {
                damage = characterBody.damage,
                crit = RollCrit(),
                position = aimRay.origin,
                rotation = Quaternion.LookRotation(aimRay.direction),
                procChainMask = default(ProcChainMask),
                owner = gameObject,
                projectilePrefab = projectilePrefab
            });
        }
    }
}