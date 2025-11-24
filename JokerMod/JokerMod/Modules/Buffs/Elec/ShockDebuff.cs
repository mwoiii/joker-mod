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
            buffDef.iconSprite = Asset.elecDebuffIcon;
            buffDef.buffColor = new Color(0.98f, 1f, 0.21f);
            buffDef.canStack = false;
            buffDef.isDebuff = true;
            buffDef.isDOT = false;

            Content.AddBuffDef(buffDef);
        }

        private static void ShockDebuffMult(HealthComponent self, DamageInfo damageInfo) {
            if (self?.body != null && self.body.HasBuff(buffDef.buffIndex)) {
                damageInfo.damageColorIndex = Asset.shockColor;
                damageInfo.damage *= 1.3f;
            }
        }
    }
}