using JokerMod.Modules.Buffs;
using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class ElecLightWeakType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddElecLightWeakBuff;
        }

        private static void AddElecLightWeakBuff(HealthComponent self, DamageInfo damageInfo) {
            if (self?.body != null && damageInfo.HasModdedDamageType(damageType)) {
                self.body.AddTimedBuff(ShockDebuff.buffDef, 2f, 1);
                SetStateOnHurt stunComponent = self.GetComponent<SetStateOnHurt>();
                if (stunComponent != null && stunComponent.canBeStunned) {
                    stunComponent.SetStun(1f);
                }
            }
        }
    }
}