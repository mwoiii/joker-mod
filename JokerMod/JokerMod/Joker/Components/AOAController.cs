using System;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace JokerMod.Joker.Components {
    public class AOAController : MonoBehaviour {

        public float cooldownThreshold = 25f;

        public float stopwatch;

        public bool IsAvailable => stopwatch >= cooldownThreshold;

        private CharacterBody characterBody;

        private JokerMaster master;

        private const float cooldownMult = 0.85f;

        private const float maskChanceMult = 2.5f;

        public void StartExecution() {
            GlobalEventManager.onCharacterDeathGlobal += AOAOnKill;
            master.maskChance *= maskChanceMult;
            stopwatch = 0f;
        }

        public void StopExecution() {
            GlobalEventManager.onCharacterDeathGlobal -= AOAOnKill;
            master.maskChance /= maskChanceMult;
        }

        private void Start() {
            // Start off cooldown
            characterBody = gameObject.GetComponent<CharacterBody>();
            master = gameObject.GetComponent<JokerMaster>();
            master.aoaBarController.SetMaxStat(cooldownThreshold);
            stopwatch = cooldownThreshold;
        }

        private void FixedUpdate() {
            if (Util.HasEffectiveAuthority(characterBody.networkIdentity)) {
                stopwatch += Time.fixedDeltaTime;
                master.aoaBarController.SetStat(Math.Clamp(stopwatch, 0f, cooldownThreshold));
            }
        }

        private void AOAOnKill(DamageReport damageReport) {
            if (!NetworkServer.active || damageReport == null) {
                return;
            }

            if ((bool)damageReport.attackerBody) {
                if (damageReport.attackerBody == characterBody) {
                    // Reduce cooldown per kill
                    MultiplyCooldown(cooldownMult);
                    // Gain SP per kill
                    master.spController.AOAKillRestoreSP();
                }
            }
        }

        private void MultiplyCooldown(float multiplier) {
            stopwatch = cooldownThreshold - (cooldownThreshold - stopwatch) * multiplier;
        }
    }
}
