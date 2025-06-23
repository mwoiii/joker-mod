using System;
using System.Linq;
using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class PsyLightType {

        public static DamageAPI.ModdedDamageType damageType;

        public static BuffDef[] debuffList = [
            RoR2Content.Buffs.BeetleJuice,
            RoR2Content.Buffs.Bleeding,
            RoR2Content.Buffs.OnFire,
            DLC1Content.Buffs.Fracture,
            RoR2Content.Buffs.SuperBleed,
            RoR2Content.Buffs.LunarSecondaryRoot,
            DLC2Content.Buffs.lunarruin,
            DLC1Content.Buffs.PermanentDebuff,
            RoR2Content.Buffs.PermanentCurse,
        ];

        public static BuffDef[] buffList = [
            DLC2Content.Buffs.IncreaseDamageBuff,
            RoR2Content.Buffs.AttackSpeedOnCrit,
            DLC2Content.Buffs.ElusiveAntlersBuff,
        ];

        // unfortunately I can't find a way to distinguish otherwise
        public static BuffDef[] untimedDebuffList = [
            DLC1Content.Buffs.PermanentDebuff,
            RoR2Content.Buffs.PermanentCurse,
        ];

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddLightPsyBuffs;
        }

        private static int minDebuffs = 3;

        private static int maxDebuffs = 8;

        private static int minBuffs = 1;

        private static int maxBuffs = 3;

        private static float buffDuration = 5f;

        private static void AddLightPsyBuffs(HealthComponent self, DamageInfo damageInfo) {
            if (damageInfo.HasModdedDamageType(damageType)) {
                if (self.body != null) {
                    CharacterBody? attackerBody = damageInfo.attacker?.GetComponent<CharacterBody>();
                    if (Util.CheckRoll(80f, attackerBody.master)) {
                        int debuffRoll = Utils.rand.Next(minDebuffs, maxDebuffs + 1);

                        for (int i = 0; i < debuffRoll; i++) {
                            BuffDef buffDef = (BuffDef)Utils.RandomChoice(debuffList);

                            if (buffDef.isDOT) {
                                DotController.InflictDot(self.gameObject, damageInfo.attacker, DotController.GetDotDefIndex(buffDef), buffDuration * damageInfo.procCoefficient, 1f);
                            } else if (untimedDebuffList.Contains(buffDef)) {
                                self.body?.AddBuff(buffDef);
                            } else {
                                self.body?.AddTimedBuff(buffDef, buffDuration);
                            }
                        }

                    } else {
                        int buffRoll = Utils.rand.Next(minBuffs, maxBuffs + 1);
                        for (int i = 0; i < buffRoll; i++) {
                            BuffDef buffDef = (BuffDef)Utils.RandomChoice(buffList);

                            self.body?.AddTimedBuff(buffDef, buffDuration);
                        }
                    }
                }
            }
        }
    }
}
