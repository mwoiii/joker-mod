using System;
using System.Linq;
using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class PsyLightWeakType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddLightWeakPsyBuffs;
        }

        private static int minBuffs = 1;

        private static int maxBuffs = 4;

        private static float buffDuration = 4f;

        private static void AddLightWeakPsyBuffs(HealthComponent self, DamageInfo damageInfo) {
            if (damageInfo.HasModdedDamageType(damageType)) {
                if (self.body != null) {
                    CharacterBody? attackerBody = damageInfo.attacker?.GetComponent<CharacterBody>();
                    int quantityRoll = Utils.rand.Next(minBuffs, maxBuffs + 1);

                    for (int i = 0; i < quantityRoll; i++) {

                        if (Util.CheckRoll(80f, attackerBody.master)) {
                            BuffDef buffDef = (BuffDef)Utils.RandomChoice(PsyUtils.debuffList);

                            if (buffDef.isDOT) {
                                DotController.InflictDot(self.gameObject, damageInfo.attacker, DotController.GetDotDefIndex(buffDef), buffDuration * damageInfo.procCoefficient, 1.5f);
                            } else if (PsyUtils.untimedDebuffList.Contains(buffDef)) {
                                self.body?.AddBuff(buffDef);
                            } else {
                                self.body?.AddTimedBuff(buffDef, buffDuration);
                            }

                        } else {
                            BuffDef buffDef = (BuffDef)Utils.RandomChoice(PsyUtils.buffList);
                            self.body?.AddTimedBuff(buffDef, buffDuration);
                        }
                    }
                }
            }
        }
    }
}
