using System;
using JokerMod.Modules;
using RoR2;

namespace JokerMod.Joker.Components {
    public class SPController {

        private JokerMaster master;

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
            }
        }

        private float _spLevel = 1f;

        private float spLevel {
            get {
                return _spLevel;
            }
            set {
                float newMaxSP = 406f - 384f / (float)Math.Pow(2f, value / 11f);
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

        public SPController(JokerMaster master) {
            this.master = master;
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
            spLevel = master.GetComponent<CharacterBody>().level;
        }

        private static void SPUpgradeOnLevelUp(CharacterBody self) {
            if ((bool)self.gameObject.GetComponent<JokerMaster>()) {
                JokerMaster master = self.gameObject.GetComponent<JokerMaster>();
                master.spController.spLevel = self.level;
            }
        }

        private void SPOnHit(DamageReport damageReport) {
            if ((bool)damageReport.attacker && damageReport.attacker == master.gameObject) {
                currentSP += damageReport.damageInfo.procCoefficient * onHitSP;
            }
        }

        public static void SubscribeStaticHooksAndEvents() {
            Hooks.Handle_CharacterBodyOnLevelUp_Actions += SPUpgradeOnLevelUp;
        }

        private void SubscribeInstanceEvents() {
            GlobalEventManager.onServerDamageDealt += SPOnHit;
            MaxSPUpdate += master.spBarController.SetMaxStat;
            SPUpdate += master.spBarController.SetStat;
            SPUpdate += master.spNumController.SetStat;
        }

        public void UnsubscribeInstanceEvents() {
            GlobalEventManager.onServerDamageDealt -= SPOnHit;
            MaxSPUpdate -= master.spBarController.SetMaxStat;
            SPUpdate -= master.spBarController.SetStat;
            SPUpdate -= master.spNumController.SetStat;
        }
    }
}
