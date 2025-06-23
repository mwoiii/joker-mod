using System;
using System.Linq;
using R2API;
using RoR2;
using JokerMod.Modules;

namespace JokerMod.Modules.DamageTypes {
    public static class PsyHeavyType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddHeavyPsyBuffs;
        }

        private static int minDebuffs = 8;

        private static int maxDebuffs = 15;

        private static int minBuffs = 3;

        private static int maxBuffs = 5;

        private static float buffDuration = 15f;

        private static void AddHeavyPsyBuffs(HealthComponent self, DamageInfo damageInfo) {
            if (damageInfo.HasModdedDamageType(damageType)) {
                if (self.body != null) {
                    CharacterBody? attackerBody = damageInfo.attacker?.GetComponent<CharacterBody>();
                    if (Util.CheckRoll(80f, attackerBody.master)) {
                        int debuffRoll = Utils.rand.Next(minDebuffs, maxDebuffs + 1);

                        for (int i = 0; i < debuffRoll; i++) {
                            BuffDef buffDef = (BuffDef)Utils.RandomChoice(PsyLightType.debuffList);

                            if (buffDef.isDOT) {
                                DotController.InflictDot(self.gameObject, damageInfo.attacker, DotController.GetDotDefIndex(buffDef), buffDuration * damageInfo.procCoefficient, 1f);
                            } else if (PsyLightType.untimedDebuffList.Contains(buffDef)) {
                                self.body?.AddBuff(buffDef);
                            } else {
                                self.body?.AddTimedBuff(buffDef, buffDuration);
                            }
                        }

                    } else {
                        int buffRoll = Utils.rand.Next(minBuffs, maxBuffs + 1);
                        for (int i = 0; i < buffRoll; i++) {
                            BuffDef buffDef = (BuffDef)Utils.RandomChoice(PsyLightType.buffList);

                            self.body?.AddTimedBuff(buffDef, buffDuration);
                        }
                    }
                }
            }
        }
    }
}
