using System;
using JokerMod.Modules;
using RoR2;

namespace JokerMod.Joker.Components {

    /// <summary>
    /// Handles the gaining, progression, and usage of the SP resource.
    /// </summary>
    /// <remarks>
    /// Max SP is stored in JokerStatController, as it is information that needs to
    /// be stored across stages.
    /// </remarks>
    public class SPController {

        private JokerMaster master;

        private JokerStatController statController;

        public event Action<float> SPUpdate;

        private float _currentSP;

        public float currentSP {
            get {
                return _currentSP;
            }
            set {
                _currentSP = Math.Clamp(value, 0, statController.maxSP);
                SPUpdate(_currentSP);
            }
        }

        private float _spLevel = 1f;

        public float onHitSP;

        public float onKillSP;

        private float spLevel {
            get {
                return _spLevel;
            }
            set {
                // splevel+1 so that thresholds are for new level rather than current level
                // current level would be weird
                for (float inc = _spLevel + 1; inc <= value; inc++) {
                    float spIncrease = 0;
                    switch (inc) {
                        case <= JokerCatalog.tier1End:
                            spIncrease = 4f / 3f;
                            break;

                        case <= JokerCatalog.tier2End:
                            spIncrease = 1f;
                            break;

                        case <= JokerCatalog.tier3End:
                            spIncrease = 4f / 3f;
                            break;

                        case <= JokerCatalog.tier4End:
                            spIncrease = 8f / 3f;
                            break;

                        case <= JokerCatalog.tier5End:
                            spIncrease = 16f / 3f;
                            break;

                        case <= JokerCatalog.tier6End:
                            spIncrease = 8f / 3f;
                            break;

                        case <= JokerCatalog.tier7End:
                            spIncrease = 6f;
                            break;

                        default:
                            spIncrease = 1.3f;
                            break;
                    }
                    statController.maxSP += spIncrease;
                    currentSP += spIncrease;
                }
                _spLevel = value;
                onHitSP = 0.005f * statController.maxSP;
                onKillSP = 0.05f * statController.maxSP;
            }
        }


        public SPController(JokerMaster master) {
            this.master = master;
            this.statController = master.statController;

            SubscribeInstanceEvents();
            // important so that setter is not called
            _spLevel = master.GetComponent<CharacterBody>().level;

            statController.ForceMaxSPUpdate();
            currentSP = statController.maxSP;

        }

        ~SPController() {
            UnsubscribeInstanceEvents();
        }

        public void AOAKillRestoreSP() {
            currentSP += onKillSP;
        }

        private static void SPUpgradeOnLevelUp(CharacterBody self) {
            if (self?.gameObject != null) {
                JokerMaster master = self.gameObject.GetComponent<JokerMaster>();
                if (master != null) {
                    master.spController.spLevel = self.level;
                }
            }
        }

        private void SPOnHit(DamageReport damageReport) {
            if ((bool)damageReport.attacker && damageReport.attacker == master.gameObject) {
                currentSP += onHitSP * damageReport.damageInfo.procCoefficient;
            }
        }

        public static void SubscribeStaticHooksAndEvents() {
            Hooks.Handle_CharacterBodyOnLevelUp_Actions += SPUpgradeOnLevelUp;
        }

        private void SubscribeInstanceEvents() {
            GlobalEventManager.onServerDamageDealt += SPOnHit;
            statController.MaxSPUpdate += master.spBarController.SetMaxStat;
            SPUpdate += master.spBarController.SetStat;
            SPUpdate += master.spNumController.SetStat;
        }

        public void UnsubscribeInstanceEvents() {
            GlobalEventManager.onServerDamageDealt -= SPOnHit;
            statController.MaxSPUpdate -= master.spBarController.SetMaxStat;
            SPUpdate -= master.spBarController.SetStat;
            SPUpdate -= master.spNumController.SetStat;
        }
    }
}
