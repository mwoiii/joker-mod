using R2API;
using RoR2;
using JokerMod.Modules.Buffs;

namespace JokerMod.Modules.DamageTypes {
    public static class ElecLightType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddElecLightBuff;
        }

        private static void AddElecLightBuff(HealthComponent self, DamageInfo damageInfo) {
            if (self.body != null && damageInfo.HasModdedDamageType(damageType)) {
                self.body.AddTimedBuff(ShockDebuff.buffDef, 4f, 1);
                SetStateOnHurt stunComponent = self.GetComponent<SetStateOnHurt>();
                if (stunComponent != null && stunComponent.canBeStunned) {
                    stunComponent.SetStun(4f);
                }
            }
        }
    }
}