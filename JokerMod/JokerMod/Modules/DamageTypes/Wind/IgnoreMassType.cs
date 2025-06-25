using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class IgnoreMassType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageForceDamageInfoBoolBool_Actions += IgnoreMass;
        }

        private static void IgnoreMass(On.RoR2.HealthComponent.orig_TakeDamageForce_DamageInfo_bool_bool orig, HealthComponent self, DamageInfo damageInfo, bool alwaysApply, bool disableAirControlUntilCollision) {
            if (damageInfo.HasModdedDamageType(damageType) && self?.body?.characterMotor?.mass != null) {
                float holdMass = self.body.characterMotor.mass;
                self.body.characterMotor.mass = 150f;
                orig(self, damageInfo, alwaysApply, disableAirControlUntilCollision);
                self.body.characterMotor.mass = holdMass;
            } else {
                orig(self, damageInfo, alwaysApply, disableAirControlUntilCollision);
            }
        }
    }
}