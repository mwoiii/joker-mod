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
    public class PersonaSkillBase : GenericProjectileBaseState {

        protected JokerSkillHandler skillHandler;

        public virtual float spCost { get; }

        private bool canFire;
        
        public override void OnEnter() {
            // need to declare at the start anyway hmm negative cook
            // skillHandler = base.GetComponent<JokerSkillHandler>();
            if (skillHandler.spController.currentSP >= spCost) {
                skillHandler.skillUsed = true;
                skillHandler.spController.currentSP -= spCost;
                canFire = true;
                Log.Info(skillHandler.spController.currentSP);
            }
            base.OnEnter();
        }

        public override void FireProjectile() {
            if (canFire) {
                base.FireProjectile();
            }
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            if (base.fixedAge >= this.duration && base.isAuthority) {
                base.outer.SetNextStateToMain();
                return;
            }
        }

        //GetMinimumInterruptPriority() returns the InterruptPriority required to interrupt this skill
        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Frozen;
        }
    }
}