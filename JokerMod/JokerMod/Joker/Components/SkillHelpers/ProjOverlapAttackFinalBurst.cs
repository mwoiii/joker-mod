using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.Components.SkillHelpers {
    public class ProjOverlapAttackFinalBurst : MonoBehaviour {

        // changing specific projectileoverlapattack properties once lifetime stopwatch reaches a high enough threshold
        // for garula and higher

        public float timeLeftThreshold;

        public float overridePushAwayForce;

        public float overrideYForce;

        public float overrideDamageCoefficient;

        public float overrideProcCoeff;

        public bool overideShouldAbsY;

        public bool overrideShouldPushAllies;

        public int addWindDamageType = -1;

        private ProjectileOverlapAttack projOverlapAttack;

        private WindForceInfo forceInfo;

        private ProjectileSimple projSimple;

        private void Start() {
            projOverlapAttack = GetComponent<ProjectileOverlapAttack>();
            forceInfo = GetComponent<WindForceInfo>();
            projSimple = GetComponent<ProjectileSimple>();
            if (projOverlapAttack == null || forceInfo == null || projSimple == null) {
                Log.Warning("ProjOverlapAttackChangeForce attached to body without vital components! Destroying...");
                Destroy(this);
            }
        }

        private void FixedUpdate() {
            if (projSimple.lifetime - projSimple.stopwatch <= timeLeftThreshold) {
                projOverlapAttack.resetInterval = -1f;
                projOverlapAttack.attack.ResetIgnoredHealthComponents();

                projOverlapAttack.attack.pushAwayForce = overridePushAwayForce;

                projOverlapAttack.forceVector.y = overrideYForce;
                projOverlapAttack.attack.forceVector.y = overrideYForce;

                projOverlapAttack.damageCoefficient = overrideDamageCoefficient;
                projOverlapAttack.attack.damage = overrideDamageCoefficient * projOverlapAttack.projectileDamage.damage;

                projOverlapAttack.overlapProcCoefficient = overrideProcCoeff;
                projOverlapAttack.attack.procCoefficient = overrideProcCoeff;

                forceInfo.shouldAbsY = overideShouldAbsY;

                forceInfo.shouldPushAllies = overrideShouldPushAllies;

                switch (addWindDamageType) {
                    case 0:
                        projOverlapAttack.attack.damageType.AddModdedDamageType(WindLightType.damageType);
                        break;
                    case 1:
                        projOverlapAttack.attack.damageType.AddModdedDamageType(WindMediumType.damageType);
                        break;
                    case 2:
                        projOverlapAttack.attack.damageType.AddModdedDamageType(WindHeavyType.damageType);
                        break;
                }

                projOverlapAttack.attack.Fire();
                Destroy(this);
            }
        }
    }
}
