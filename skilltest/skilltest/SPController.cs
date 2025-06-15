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
    public class SPController {

        private JokerSkillHandler skillHandler;

        private float _maxSP = 50f;

        public event Action<float> MaxSPUpdate;

        public event Action<float> SPUpdate;

        public float maxSP {
            get {
                return _maxSP;
            }
            private set {
                _maxSP = value;
                MaxSPUpdate(_maxSP);
            }
        }

        private float _currentSP;

        public float currentSP {
            get {
                return _currentSP;
            }
            set {
                _currentSP = Math.Clamp(value, 0, maxSP);
                SPUpdate(_currentSP);
                Log.Info(currentSP);
            }
        }

        private float _spLevel = 1f;

        private float spLevel {
            get {
                return _spLevel;
            }
            set {
                float newMaxSP = 406f - (384f / (float)Math.Pow(2f, value / 11f));
                float difference = newMaxSP - maxSP;
                maxSP = newMaxSP;
                currentSP += difference;
                _spLevel = value;
                onHitSP = 0.2f * _spLevel;
                onKillSP = 2f * _spLevel;
            }
        }

        public float onHitSP = 0.2f;

        public float onKillSP = 2f;

        public SPController(JokerSkillHandler skillHandler) {
            this.skillHandler = skillHandler;
            SubscribeInstanceEvents();
            SetStartSP();
            currentSP = maxSP;
        }

        ~SPController() {
            UnsubscribeInstanceEvents();
        }

        public void AOAKillRestoreSP() {
            currentSP += onKillSP;
        }

        private void SetStartSP() {
            spLevel = skillHandler.GetComponent<CharacterBody>().level;
        }

        private static void SPUpgradeOnLevelUp(CharacterBody self) {
            if ((bool)self.gameObject.GetComponent<JokerSkillHandler>()) {
                JokerSkillHandler skillHandler = self.gameObject.GetComponent<JokerSkillHandler>();
                skillHandler.spController.spLevel = self.level;
            }
        }

        private void SPOnHit(DamageReport damageReport) {
            if ((bool)damageReport.attacker && damageReport.attacker == skillHandler.gameObject) {
                currentSP += damageReport.damageInfo.procCoefficient * onHitSP;
            }
        }

        public static void SubscribeStaticHooksAndEvents() {
            Hooks.Handle_CharacterBodyOnLevelUp_Actions += SPUpgradeOnLevelUp;
        }

        private void SubscribeInstanceEvents() {
            GlobalEventManager.onServerDamageDealt += SPOnHit;
            MaxSPUpdate += skillHandler.spBarController.SetMaxStat;
            SPUpdate += skillHandler.spBarController.SetStat;
            SPUpdate += skillHandler.spNumController.SetStat;
        }

        public void UnsubscribeInstanceEvents() {
            GlobalEventManager.onServerDamageDealt -= SPOnHit;
            MaxSPUpdate -= skillHandler.spBarController.SetMaxStat;
            SPUpdate -= skillHandler.spBarController.SetStat;
            SPUpdate -= skillHandler.spNumController.SetStat;
        }
    }
}
