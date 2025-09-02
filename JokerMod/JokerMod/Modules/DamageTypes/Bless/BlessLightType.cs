using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class BlessLightType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddLightBlessBuffs;
        }

        private static float buffDuration = 8f;

        private static void AddLightBlessBuffs(HealthComponent self, DamageInfo damageInfo) {
            if (damageInfo.HasModdedDamageType(damageType)) {
                CharacterBody attackerBody = damageInfo.attacker?.GetComponent<CharacterBody>();
                if (attackerBody != null) {
                    BuffDef buffDef = (BuffDef)Utils.RandomChoice(BlessUtils.buffList);
                    attackerBody.AddTimedBuff(buffDef, buffDuration);
                }
            }
        }
    }
}
