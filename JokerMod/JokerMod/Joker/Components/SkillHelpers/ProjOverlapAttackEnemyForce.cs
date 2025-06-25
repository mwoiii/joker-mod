using System.Collections;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.Components.SkillHelpers {
    public class ProjOverlapAttackEnemyForce : MonoBehaviour {

        // projectileoverlapattack doesn't let you set pushawayforce for some reason
        // so this component ensures the attack exists before assigning pushawayforce directly

        public float force;

        [SerializeField]
        private bool shouldAbsY;  // whether or not the force shouldn't push downwards

        [SerializeField]
        private bool shouldPushAllies;  // whether or not the force should affect allies

        private WindForceInfo forceInfo;

        private ProjectileOverlapAttack projOverlapAttack;

        private void Start() {
            projOverlapAttack = GetComponent<ProjectileOverlapAttack>();
            forceInfo = GetComponent<WindForceInfo>();
            if (projOverlapAttack != null) {
                StartCoroutine(WaitForOverlapAttack());
            } else {
                Log.Warning("ProjOverlapAttackEnemyForce attached to body without vital component! Destroying...");
                Destroy(this);
            }
        }

        private IEnumerator WaitForOverlapAttack() {
            yield return new WaitUntil(() => projOverlapAttack.attack != null);
            projOverlapAttack.attack.pushAwayForce = force;
            forceInfo.shouldAbsY = shouldAbsY;
            forceInfo.shouldPushAllies = shouldPushAllies;
        }
    }
}
