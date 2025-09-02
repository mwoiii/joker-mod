using RoR2;
using UnityEngine;

namespace JokerMod.Modules.Buffs {
    public static class HallowedDebuff {

        public static BuffDef buffDef;

        public static void Init() {
            CreateBuff();
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += HallowedDebuffHeal;
        }

        private static void CreateBuff() {
            buffDef = ScriptableObject.CreateInstance<BuffDef>();
            buffDef.name = "PersonaBlessHallowed";
            buffDef.iconSprite = Asset.blessDebuffIcon;
            buffDef.buffColor = new Color(1f, 1f, 0.62f);
            buffDef.canStack = false;
            buffDef.isDebuff = true;
            buffDef.isDOT = false;

            Content.AddBuffDef(buffDef);
        }

        private static void HallowedDebuffHeal(HealthComponent self, DamageInfo damageInfo) {
            if (self.body != null && self.body.GetTimedBuffTotalDurationForIndex(buffDef.buffIndex, out _)) {
                HealthComponent attackerHealth = damageInfo.attacker?.GetComponent<HealthComponent>();
                if (attackerHealth != null) {
                    attackerHealth.Heal(damageInfo.damage * 0.1f, default(ProcChainMask));
                }
            }
        }
    }
}