using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RoR2;
using RoR2.Skills;
using JokerMod.Joker.Components.UI;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Modules;
using UnityEngine;
using UnityEngine.Networking;
using JokerMod.Modules.PersonaSkills;

namespace JokerMod.Joker.Components
{
    public class JokerMaster : MonoBehaviour
    {

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

        public void ReceivePersona(ItemDef itemDef) {
            return;
        }

        public bool skillUsed
        {
            get
            {
                return _skillUsed;
            }
            set
            {
                _skillUsed = value;
                if (_skillUsed)
                {
                    EntityStateMachine.FindByCustomName(gameObject, "Charge").SetNextStateToMain();
                }
            }
        }

        private void SecondarySkillStock(DamageReport damageReport)
        {
            // Granting a stock of secondary on kill
            if (!NetworkServer.active || damageReport == null)
            {
                return;
            }

            if ((bool)damageReport.attackerBody)
            {
                CharacterBody attackerBody = damageReport.attackerBody;
                if (attackerBody == GetComponent<CharacterBody>())
                {
                    float max = attackerBody.skillLocator.GetSkill(SkillSlot.Secondary).maxStock;
                    float current = attackerBody.skillLocator.GetSkill(SkillSlot.Secondary).stock;
                    JokerMaster master = attackerBody.GetComponent<JokerMaster>();
                    if (!master.skillMenuActive)
                    {
                        damageReport.attackerBody.skillLocator.GetSkill(SkillSlot.Secondary).stock = (int)Mathf.Clamp(current + 1, current, max);
                    }
                    else
                    {
                        master.EnemySlainDuringMenu();
                    }
                }
            }
        }


        private void Awake()
        {
            skillPrimary = JokerCatalog.GetSkillDefFromType(typeof(EihaState));
            skillSecondary = JokerCatalog.GetSkillDefFromType(typeof(EmptyState));
            skillUtility = JokerCatalog.GetSkillDefFromType(typeof(EmptyState));
            GlobalEventManager.onCharacterDeathGlobal += SecondarySkillStock;
            CreateUI();

            // spController requires UI to be fully initialised as it wants to instantly access components
            StartCoroutine(OnUIStarted());
        }

        private void CreateUI() {
            GameObject jokerUI = Instantiate(Asset.jokerUIPrefab);
            GameObject UI = GameObject.Find("HUDSimple(Clone)/MainContainer/MainUIArea/SpringCanvas/BottomRightCluster");
            jokerUI.transform.SetParent(UI.transform, false);

            aoaBarController = jokerUI.transform.Find("AOABarShadow/AOABar")?.GetComponent<StatBarController>();
            spBarController = jokerUI.transform.Find("SPBarShadow/SPBar")?.GetComponent<StatBarController>();
            spNumController = jokerUI.transform.Find("SPAmount")?.GetComponent<StatNumberController>();
        }

        private IEnumerator OnUIStarted()
        {
            yield return new WaitUntil(() => spNumController.hasStarted);
            spController = new SPController(this);
        }

        private void OnDestroy()
        {
            spController.UnsubscribeInstanceEvents();
            GlobalEventManager.onCharacterDeathGlobal -= SecondarySkillStock;
        }
    }
}
