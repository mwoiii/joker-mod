using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace SkillTest {
    public class AOAController : MonoBehaviour {

        public float cooldownThreshold = 25f;

        public float stopwatch;

        public bool IsAvailable => stopwatch >= cooldownThreshold;
 
        private CharacterBody characterBody;

        private JokerSkillHandler skillHandler;

        private const float standardCDMultiplier = 0.85f;

        public void StartExecution() {
            GlobalEventManager.onCharacterDeathGlobal += AOAOnKill;
            stopwatch = 0f;
        }

        public void StopExecution() {
            GlobalEventManager.onCharacterDeathGlobal -= AOAOnKill;
        }

        private void Start() {
            // Start off cooldown
            characterBody = gameObject.GetComponent<CharacterBody>();
            skillHandler = gameObject.GetComponent<JokerSkillHandler>();
            skillHandler.aoaBarController.SetMaxStat(cooldownThreshold);
            stopwatch = cooldownThreshold;
        }

        private void FixedUpdate() {
            stopwatch += Time.fixedDeltaTime;
            skillHandler.aoaBarController.SetStat(Math.Clamp(stopwatch, 0f, cooldownThreshold));
        }

        private void AOAOnKill(DamageReport damageReport) {
            if (!NetworkServer.active || damageReport == null) {
                return;
            }

            if ((bool)damageReport.attackerBody) {
                if (damageReport.attackerBody == characterBody) {
                    // Reduce cooldown per kill
                    MultiplyCooldown(standardCDMultiplier);
                    // Gain SP per kill
                    skillHandler.spController.AOAKillRestoreSP();
                }
            }
        }

        private void MultiplyCooldown(float multiplier) {
            stopwatch = cooldownThreshold - (cooldownThreshold - stopwatch) * multiplier;
            Log.Info(stopwatch);
        }
    }
}
