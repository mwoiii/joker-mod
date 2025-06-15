using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RoR2;
using RoR2.Skills;
using SkillTest.MyEntityStates;
using UnityEngine;
using UnityEngine.Networking;

namespace SkillTest {
    public class JokerSkillHandler : MonoBehaviour {

        public SkillDef skillPrimary;

        public SkillDef skillSecondary;

        public SkillDef skillUtility;

        public SPController spController;

        public bool skillMenuActive;

        public event Action EnemySlainDuringMenu;

        public StatBarController aoaBarController;

        public StatBarController spBarController;

        public StatNumberController spNumController;

        private bool _skillUsed;

        private static GameObject jokerUIPrefab => Assets.mainAssetBundle.LoadAsset<GameObject>("JokerUI");

        public bool skillUsed {
            get {
                return _skillUsed;
            }
            set {
                _skillUsed = value;
                if (_skillUsed) {
                    EntityStateMachine.FindByCustomName(base.gameObject, "Charge").SetNextStateToMain();
                }
            }
        }

        static JokerSkillHandler() {
            SubscribeStaticHooksAndEvents();
        }

        private static void SecondarySkillStock(DamageReport damageReport) {
            // Granting a stock of secondary on kill
            if (!NetworkServer.active || damageReport == null) {
                return;
            }

            if ((bool)damageReport.attackerBody) {
                CharacterBody attackerBody = damageReport.attackerBody;
                if (attackerBody?.skillLocator?.GetSkill(SkillSlot.Secondary)?.activationState.stateType == typeof(SkillTest.MyEntityStates.ChargeSecondary)) {
                    float max = attackerBody.skillLocator.GetSkill(SkillSlot.Secondary).maxStock;
                    float current = attackerBody.skillLocator.GetSkill(SkillSlot.Secondary).stock;
                    JokerSkillHandler skillHandler = attackerBody.GetComponent<JokerSkillHandler>();
                    if (!skillHandler.skillMenuActive) {
                        damageReport.attackerBody.skillLocator.GetSkill(SkillSlot.Secondary).stock = (int)Mathf.Clamp(current + 1, current, max);
                    } else {
                        skillHandler.EnemySlainDuringMenu();
                    }
                }
            }
        }

        private void CreateUI() {
            GameObject jokerUI = UnityEngine.Object.Instantiate(jokerUIPrefab);
            GameObject UI = GameObject.Find("HUDSimple(Clone)/MainContainer/MainUIArea/SpringCanvas/BottomRightCluster");
            jokerUI.transform.SetParent(UI.transform, false);

            aoaBarController = jokerUI.transform.Find("AOABarShadow/AOABar")?.GetComponent<StatBarController>();
            spBarController = jokerUI.transform.Find("SPBarShadow/SPBar")?.GetComponent<StatBarController>();
            spNumController = jokerUI.transform.Find("SPAmount")?.GetComponent<StatNumberController>();
        }

        private void Awake() {
            skillPrimary = Eiha.skillDef;
            skillSecondary = EmptyPersonaSkill.skillDef;
            skillUtility = EmptyPersonaSkill.skillDef;
            CreateUI();

            // spController requires UI to be fully initialised as it wants to instantly access components
            StartCoroutine(OnUIStarted());
        }

        private IEnumerator OnUIStarted() {
            yield return new WaitUntil(() => spNumController.hasStarted);
            spController = new SPController(this);
        }


        private static void SubscribeStaticHooksAndEvents() {
            GlobalEventManager.onCharacterDeathGlobal += SecondarySkillStock;
        }

        private void OnDestroy() {
            spController.UnsubscribeInstanceEvents();
        }
    }
}
