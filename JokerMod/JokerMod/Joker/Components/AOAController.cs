using System;
using JokerMod.Modules;
using R2API.Networking;
using R2API.Networking.Interfaces;
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

        public bool aoaKillDidOccur;

        private CharacterBody characterBody;

        private JokerMaster master;

        public const float cooldownMult = 0.85f;

        private const float maskChanceMult = 2.5f;

        public const float maxStrongCharge = 100f;

        private const float onHitStrongCharge = 0.5f;

        private const float onKillStrongCharge = 2f;

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
            characterBody = gameObject.GetComponent<CharacterBody>();
            master = gameObject.GetComponent<JokerMaster>();
            stopwatch = cooldownThreshold;
        }

        private void FixedUpdate() {
            if (Util.HasEffectiveAuthority(characterBody.networkIdentity)) {
                stopwatch += Time.fixedDeltaTime;
                if (master.aoaBarController != null) {
                    master.aoaBarController.SetStat(Math.Clamp(stopwatch, 0f, cooldownThreshold));
                }
            }
        }

        private void AOAOnKill(DamageReport damageReport) {
            if (!NetworkServer.active || damageReport == null) {
                return;
            }

            if ((bool)damageReport.attackerBody) {
                if (damageReport.attackerBody == characterBody) {
                    new SyncJokerAOAHitEvent(characterBody.netIdentity.netId, currentStrongCharge + onKillStrongCharge, true).Send(NetworkDestination.Clients);
                }
            }
        }

        private void AOAChargeOnHit(DamageReport damageReport) {
            if ((bool)damageReport.attacker && damageReport.attacker == master.gameObject) {
                new SyncJokerAOAHitEvent(characterBody.netIdentity.netId, currentStrongCharge + onHitStrongCharge * damageReport.damageInfo.procCoefficient).Send(NetworkDestination.Clients);
            }
        }

        public void MultiplyCooldown(float multiplier) {
            stopwatch = cooldownThreshold - (cooldownThreshold - stopwatch) * multiplier;
        }
    }

    public class SyncJokerAOAHitEvent : INetMessage {

        NetworkInstanceId bodyNetId;
        float strongCharge;
        bool didKill;

        public SyncJokerAOAHitEvent() {
        }

        public SyncJokerAOAHitEvent(NetworkInstanceId bodyNetId, float strongCharge, bool didKill = false) {
            this.bodyNetId = bodyNetId;
            this.strongCharge = strongCharge;
            this.didKill = didKill;
        }

        public void Serialize(NetworkWriter writer) {
            writer.Write(bodyNetId);
            writer.Write(strongCharge);
            writer.Write(didKill);
        }

        public void Deserialize(NetworkReader reader) {
            bodyNetId = reader.ReadNetworkId();
            strongCharge = reader.ReadSingle();
            didKill = reader.ReadBoolean();
        }

        public void OnReceived() {
            JokerMaster master = Util.FindNetworkObject(bodyNetId)?.GetComponent<JokerMaster>();
            if (master != null) {
                master.aoaController.currentStrongCharge = strongCharge;

                if (didKill) {
                    master.aoaController.MultiplyCooldown(AOAController.cooldownMult);
                    master.spController.AOAKillRestoreSP();
                    master.aoaController.aoaKillDidOccur = true;
                }

                if (master.aoaBarController != null) {
                    master.aoaStrongBarController.SetStat(Math.Clamp(strongCharge, 0f, AOAController.maxStrongCharge));
                }
            }
        }
    }
}
