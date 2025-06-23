using System;
using System.Collections;
using JokerMod.Joker.Components.UI;
using JokerMod.Joker.SkillStates;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Modules;
using JokerMod.Modules.PersonaMasks;
using RoR2;
using RoR2.Projectile;
using UnityEngine;
using UnityEngine.Networking;

namespace JokerMod.Joker.Components {
    public class JokerMaster : MonoBehaviour {
        public SPController spController;

        public bool skillMenuActive;

        public event Action EnemySlainDuringMenu;

        public StatBarController aoaBarController;

        public StatBarController spBarController;

        public StatNumberController spNumController;

        public PersonaStatController statController;

        private bool _skillUsed;

        public float maskChance = 2f;

        [SerializeField]
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
                        GenericPickupController.CreatePickupInfo pickupInfo = default(GenericPickupController.CreatePickupInfo);
                        pickupInfo.pickupIndex = PickupCatalog.FindPickupIndex(JokerCatalog.RollForMask(attackerBody.level).itemDef.itemIndex);
                        pickupInfo.position = damageReport.victimBody.transform.position;
                        PickupDropletController.CreatePickupDroplet(pickupInfo, damageReport.victimBody.transform.position, Vector3.zero);
                    }
                }
            }
        }


        private void Awake() {
            GlobalEventManager.onCharacterDeathGlobal += JokerOnKills;
            CreateUI();

            // spController requires UI to be fully initialised as it wants to instantly access components
            StartCoroutine(OnUIStarted());
        }

        private void Start() {
            PersonaStatController checkStatController = GetComponent<CharacterBody>().master.GetComponent<PersonaStatController>();
            if (checkStatController == null) {
                statController = GetComponent<CharacterBody>().master.gameObject.AddComponent<PersonaStatController>();
            } else {
                statController = checkStatController;
            }
            statController.master = this;
        }

        private void CreateUI() {
            GameObject jokerUI = Instantiate(Asset.jokerUIPrefab);
            GameObject UI = GameObject.Find("HUDSimple(Clone)/MainContainer/MainUIArea/SpringCanvas/BottomRightCluster");
            jokerUI.transform.SetParent(UI.transform, false);

            aoaBarController = jokerUI.transform.Find("AOABarShadow/AOABar")?.GetComponent<StatBarController>();
            spBarController = jokerUI.transform.Find("SPBarShadow/SPBar")?.GetComponent<StatBarController>();
            spNumController = jokerUI.transform.Find("SPAmount")?.GetComponent<StatNumberController>();
        }

        private IEnumerator OnUIStarted() {
            yield return new WaitUntil(() => spNumController.hasStarted);
            spController = new SPController(this);
        }

        private void OnDestroy() {
            spController.UnsubscribeInstanceEvents();
            GlobalEventManager.onCharacterDeathGlobal -= JokerOnKills;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.F2)) {
                // you WON!! THE [free] TEST EIHA
                Log.Info($"CONGRATS!!!");
                var freeState = new EihaState();
                Asset.eihaPrefab.GetComponent<ProjectileImpactExplosion>().blastRadius = testRadius;
                EntityStateMachine.FindByCustomName(GetComponent<CharacterBody>().gameObject, "Weapon").SetNextState(new EihaState());
            }
        }
    }
}
