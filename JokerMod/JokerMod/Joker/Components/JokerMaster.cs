using System;
using System.Collections;
using JokerMod.Joker.Components.UI;
using JokerMod.Joker.SkillStates;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using RoR2.Skills;
using UnityEngine;
using UnityEngine.Networking;

namespace JokerMod.Joker.Components {

    /// <summary>
    /// Initialises all the custom mechanisms for the Joker survivor, and also
    /// acts as a point of communication for the different components.
    /// </summary>
    /// <remarks>
    /// A new JokerMaster component is generated each stage - use PersonaStatController
    /// for data that needs to persist between stages.
    /// </remarks>
    public class JokerMaster : MonoBehaviour {

        public SPController spController;

        public AOAController aoaController;

        public bool skillMenuActive;

        public event Action EnemySlainDuringMenu;

        public StatBarController aoaBarController;

        public StatBarController aoaStrongBarController;

        public StatBarController spBarController;

        public StatNumberController spNumController;

        public StatNumberController skill1CostController;

        public StatNumberController skill2CostController;

        public StatNumberController skill3CostController;

        public JokerStatController statController;

        public CharacterBody characterBody;

        public VoiceController voiceController;

        public GameObject jokerUI;

        public bool primaryResetTimerActive {
            get {
                SteppedSkillDef steppedSkillDef = characterBody?.skillLocator?.primary?.skillDef as SteppedSkillDef;
                if (steppedSkillDef != null) {
                    return steppedSkillDef.stepResetTimer < steppedSkillDef.stepGraceDuration;
                }
                return false;
            }
        }

        private bool _skillUsed;

        public float maskChance = 2f;

        public float testRadius = 11f;

        public bool skillUsed {
            get {
                return _skillUsed;
            }
            set {
                _skillUsed = value;
                if (_skillUsed) {
                    EntityStateMachine.FindByCustomName(gameObject, "Charge").SetNextStateToMain();
                }
            }
        }

        private void JokerOnKills(DamageReport damageReport) {
            // Granting a stock of secondary on kill
            // And having a chance to drop a persona
            if (!NetworkServer.active || damageReport == null) {
                return;
            }

            if ((bool)damageReport.attackerBody) {
                CharacterBody attackerBody = damageReport.attackerBody;
                if (attackerBody == GetComponent<CharacterBody>()) {
                    JokerMaster master = attackerBody.GetComponent<JokerMaster>();

                    // bullet restock
                    float max = attackerBody.skillLocator.GetSkill(SkillSlot.Secondary).maxStock;
                    float current = attackerBody.skillLocator.GetSkill(SkillSlot.Secondary).stock;
                    if (!master.skillMenuActive) {
                        damageReport.attackerBody.skillLocator.GetSkill(SkillSlot.Secondary).stock = (int)Mathf.Clamp(current + 1, current, max);
                    } else {
                        master.EnemySlainDuringMenu();
                    }

                    // mask item dropping
                    if (damageReport.victimBody != null && RoR2.Util.CheckRoll(maskChance, attackerBody.master)) {
                        Items.CreateRandomMaskDroplet(attackerBody.level, damageReport.victimBody.transform.position);
                    }
                }
            }
        }

        private void Awake() {
            GlobalEventManager.onCharacterDeathGlobal += JokerOnKills;
            GlobalEventManager.onServerDamageDealt += VoicelineOnHeavyDamge;
        }

        private void VoicelineOnHeavyDamge(DamageReport damageReport) {
            if (damageReport?.victim == characterBody?.healthComponent) {
                bool isKillAttack = damageReport.combinedHealthBeforeDamage - damageReport.damageDealt <= 0f;
                bool passesDamageThreshold = damageReport.damageDealt >= damageReport.victim.fullCombinedHealth * 0.4f;
                if (!isKillAttack && passesDamageThreshold) {
                    VoiceController.PlayRandomNetworkedSound(JokerAssets.hurtSoundEvents, characterBody.gameObject);
                }
            }
        }

        private void Start() {
            characterBody = GetComponent<CharacterBody>();

            SetupStatController();

            voiceController = statController.voiceController;

            spController = new SPController(this);
            aoaController = gameObject.AddComponent<AOAController>();

            StartCoroutine(CreateUIIfLocal());

            CharacterDeathBehavior characterDeathBehavour = GetComponent<CharacterDeathBehavior>();
            characterDeathBehavour.deathState = new EntityStates.SerializableEntityStateType(typeof(CollapseDeathState));
            characterDeathBehavour.deathStateMachine = EntityStateMachine.FindByCustomName(gameObject, "Body");
        }

        private void SetupStatController() {
            JokerStatController checkStatController = characterBody.master.GetComponent<JokerStatController>();
            if (checkStatController == null) {
                statController = characterBody.master.gameObject.AddComponent<JokerStatController>();
            } else {
                statController = checkStatController;
            }
            statController.master = this;
            characterBody.onSkillActivatedServer += statController.StoreLastSkillUsed;
        }

        private IEnumerator CreateUIIfLocal() {
            yield return new WaitUntil(() => LocalUserManager.GetFirstLocalUser()?.cachedBody != null);
            if (LocalUserManager.GetFirstLocalUser()?.cachedBody != characterBody) {
                yield break;
            }

            jokerUI = Instantiate(Asset.jokerUIPrefab);
            GameObject UI = GameObject.Find("HUDSimple(Clone)/MainContainer/MainUIArea/SpringCanvas/BottomRightCluster");
            jokerUI.transform.SetParent(UI.transform, false);

            aoaBarController = jokerUI.transform.Find("AOABarShadow/AOABar").GetComponent<StatBarController>();
            aoaStrongBarController = jokerUI.transform.Find("AOABarShadow/StrongAOABar").GetComponent<StatBarController>();
            spBarController = jokerUI.transform.Find("SPBarShadow/SPBar").GetComponent<StatBarController>();
            spNumController = jokerUI.transform.Find("SPAmount").GetComponent<StatNumberController>();

            skill1CostController = jokerUI.transform.Find("SPCosts/Skill1").GetComponent<StatNumberController>();
            skill2CostController = jokerUI.transform.Find("SPCosts/Skill2").GetComponent<StatNumberController>();
            skill3CostController = jokerUI.transform.Find("SPCosts/Skill3").GetComponent<StatNumberController>();

            ConnectUI();
        }

        private void ConnectUI() {
            // listen to relevant events
            statController.MaxSPUpdate += spBarController.SetMaxStat;
            spController.SPUpdate += spBarController.SetStat;
            spController.SPUpdate += spNumController.SetStat;

            // set defaults
            spBarController.SetMaxStat(statController.maxSP);
            spBarController.SetStat(statController.maxSP);
            spNumController.SetStat(spController.currentSP);

            aoaBarController.SetMaxStat(aoaController.cooldownThreshold);
            aoaStrongBarController.SetMaxStat(AOAController.maxStrongCharge);
            aoaStrongBarController.SetStat(0f);
        }

        private void OnDestroy() {
            spController.UnsubscribeInstanceEvents();
            GlobalEventManager.onCharacterDeathGlobal -= JokerOnKills;
        }

        private void Update() {
            bool triedActivateFinisher = characterBody != null && characterBody.inputBank.activateEquipment.justPressed && primaryResetTimerActive;
            if (triedActivateFinisher) {
                SteppedSkillDef.InstanceData instanceData = (SteppedSkillDef.InstanceData)characterBody?.skillLocator?.primary?.skillInstanceData;
                if (instanceData != null) {
                    if (instanceData.step > 0 && instanceData.step <= 5) {
                        instanceData.step += 5;
                        characterBody.skillLocator.primary.skillInstanceData = instanceData;
                        characterBody.skillLocator.primary.ExecuteIfReady();
                    }
                } else {
                    Log.Warning("instanceData was null! Couldn't access current step..");
                }
            }

            voiceController.UnpausedUpdate();

            if (Input.GetKeyDown(KeyCode.F2)) {
                // you WON!! THE [free] TEST EIHA
                Log.Info($"CONGRATS!!!");
                var freeState = new EihaState();
                Asset.eihaPrefab.GetComponent<ProjectileImpactExplosion>().blastRadius = testRadius;
                EntityStateMachine.FindByCustomName(characterBody.gameObject, "Weapon").SetNextState(new EihaState());
            }
        }
    }
}
