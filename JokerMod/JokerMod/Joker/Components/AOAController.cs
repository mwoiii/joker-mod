using System;
using JokerMod.Modules;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace JokerMod.Joker.Components {

    /// <summary>
    /// Holds stats related to All-Out Attacks, such as the different charge levels
    /// and subscribing/unsubscribing events for unique behaviour during the attack.
    /// </summary>
    public class AOAController : MonoBehaviour {

        public float cooldownThreshold = 25f;

        public float stopwatch;

        public float currentStrongCharge;

        public bool StandardIsAvailable => stopwatch >= cooldownThreshold;

        public bool StrongIsAvailable => currentStrongCharge >= maxStrongCharge;

        private bool executingStrong;

        private bool aoaKillDidOccur;

        private CharacterBody characterBody;

        private JokerMaster master;

        private const float cooldownMult = 0.85f;

        private const float maskChanceMult = 2.5f;

        private const float maxStrongCharge = 100f;

        private const float onHitStrongCharge = 0.5f;

        public void StartExecution(bool isStrong = false) {
            GlobalEventManager.onCharacterDeathGlobal += AOAOnKill;
            GlobalEventManager.onServerDamageDealt += AOAChargeOnHit;
            master.maskChance *= maskChanceMult;
            stopwatch = 0f;

            if (isStrong) {
                executingStrong = true;
                currentStrongCharge = 0f;
            }
        }

        public void StopExecution() {
            GlobalEventManager.onCharacterDeathGlobal -= AOAOnKill;
            GlobalEventManager.onServerDamageDealt -= AOAChargeOnHit;
            master.maskChance /= maskChanceMult;

            if (executingStrong) {
                executingStrong = false;
                if (aoaKillDidOccur) {
                    Items.CreateRandomMaskDroplet(characterBody.level, characterBody.transform.position);
                }
            }

            aoaKillDidOccur = false;
        }

        private void Start() {
            // Start off cooldown
            characterBody = gameObject.GetComponent<CharacterBody>();
            master = gameObject.GetComponent<JokerMaster>();
            master.aoaBarController.SetMaxStat(cooldownThreshold);
            stopwatch = cooldownThreshold;

            // apart from you
            // idiot
            master.aoaStrongBarController.SetMaxStat(maxStrongCharge);
            master.aoaStrongBarController.SetStat(0f);
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
                    MultiplyCooldown(cooldownMult);
                    master.spController.AOAKillRestoreSP();
                    currentStrongCharge += 2f;
                    master.aoaStrongBarController.SetStat(Math.Clamp(currentStrongCharge, 0f, maxStrongCharge));
                    aoaKillDidOccur = true;
                }
            }
        }

        private void AOAChargeOnHit(DamageReport damageReport) {
            if ((bool)damageReport.attacker && damageReport.attacker == master.gameObject) {
                currentStrongCharge += onHitStrongCharge * damageReport.damageInfo.procCoefficient;
                master.aoaStrongBarController.SetStat(Math.Clamp(currentStrongCharge, 0f, maxStrongCharge));
            }
        }

        private void MultiplyCooldown(float multiplier) {
            stopwatch = cooldownThreshold - (cooldownThreshold - stopwatch) * multiplier;
        }
    }
}
