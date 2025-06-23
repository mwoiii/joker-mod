using R2API;
using RoR2;
using UnityEngine;

namespace JokerMod.Modules.Buffs {
    public static class ShockDebuff {

        public static BuffDef buffDef;

        public static void Init() {
            CreateBuff();
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += ShockDebuffMult;
        }

        private static void CreateBuff() {
            buffDef = ScriptableObject.CreateInstance<BuffDef>();
            buffDef.name = "PersonaElecShock";
            buffDef.iconSprite = null;
            buffDef.buffColor = Color.yellow;
            buffDef.canStack = false;
            buffDef.isDebuff = true;
            buffDef.isDOT = false;

            BuffCollection.buffDefs.Add(buffDef);
        }

        private static void ShockDebuffMult(HealthComponent self, DamageInfo damageInfo) {
            if (self.body != null && self.body.GetTimedBuffTotalDurationForIndex(buffDef.buffIndex, out _)) {
                damageInfo.damageColorIndex = Asset.shockColor;
                damageInfo.damage *= 1.25f;
            }
        }
    }
}