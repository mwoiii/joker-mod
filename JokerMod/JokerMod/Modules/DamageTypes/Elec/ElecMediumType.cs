using R2API;
using RoR2;
using JokerMod.Modules.Buffs;

namespace JokerMod.Modules.DamageTypes {
    public static class ElecMediumType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddElecMediumBuff;
        }

        private static void AddElecMediumBuff(HealthComponent self, DamageInfo damageInfo) {
            if (self.body != null && damageInfo.HasModdedDamageType(damageType)) {
                self.body.AddTimedBuff(ShockDebuff.buffDef, 6f, 1);
                SetStateOnHurt stunComponent = self.GetComponent<SetStateOnHurt>();
                if (stunComponent != null && stunComponent.canBeStunned) {
                    stunComponent.SetStun(6f);
                }
            }
        }
    }
}