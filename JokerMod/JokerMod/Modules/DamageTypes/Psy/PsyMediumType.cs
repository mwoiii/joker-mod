using System;
using System.Linq;
using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class PsyMediumType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddMediumPsyBuffs;
        }

        private static int minDebuffs = 5;

        private static int maxDebuffs = 10;

        private static int minBuffs = 2;

        private static int maxBuffs = 4;

        private static float buffDuration = 10f;

        private static void AddMediumPsyBuffs(HealthComponent self, DamageInfo damageInfo) {
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
