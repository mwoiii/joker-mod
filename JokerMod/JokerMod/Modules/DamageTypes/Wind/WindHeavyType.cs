using JokerMod.Modules.Buffs;
using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class WindHeavyType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddHeavyWindDamage;
        }

        private static void AddHeavyWindDamage(HealthComponent self, DamageInfo damageInfo) {
            if (damageInfo?.attacker != null) {
                CharacterBody attackerBody = damageInfo?.attacker?.GetComponent<CharacterBody>();
                if (self?.body?.teamComponent?.teamIndex != null && attackerBody?.teamComponent?.teamIndex != null && damageInfo.HasModdedDamageType(damageType)) {
                    bool sameTeam = self.body.teamComponent.teamIndex == attackerBody.teamComponent.teamIndex;
                    bool isFriendlyFire = FriendlyFireManager.friendlyFireMode != FriendlyFireManager.FriendlyFireMode.Off;
                    bool isNoTeam = attackerBody.teamComponent.teamIndex == TeamIndex.None;

                    if (!sameTeam || isFriendlyFire || isNoTeam) {
                        self.body.AddTimedBuff(SweptDebuff.buffDef, 12f, 1);
                        damageInfo.damage += attackerBody.damage * 8f;
                        damageInfo.procCoefficient = 1f;
                    }

                    // always pushing up on joker to prevent jank
                    if (self.body == attackerBody) {
                        if (attackerBody.characterMotor.velocity.y < 0f) {
                            attackerBody.characterMotor.velocity.y = 0f;
                        }
                    }
                }
            }
        }
    }
}