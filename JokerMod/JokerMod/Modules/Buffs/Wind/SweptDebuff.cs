using RoR2;
using UnityEngine;

namespace JokerMod.Modules.Buffs {
    public static class SweptDebuff {

        public static BuffDef buffDef;

        public static void Init() {
            CreateBuff();
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += SweptDebuffMult;
            Hooks.Handle_CharacterMotorOnLanded_Actions += RemoveDebuff;
        }

        private static void CreateBuff() {
            buffDef = ScriptableObject.CreateInstance<BuffDef>();
            buffDef.name = "PersonaWindSwept";
            buffDef.iconSprite = null;
            buffDef.buffColor = Color.green;
            buffDef.canStack = false;
            buffDef.isDebuff = true;
            buffDef.isDOT = false;

            BuffCollection.buffDefs.Add(buffDef);
        }

        private static void SweptDebuffMult(HealthComponent self, DamageInfo damageInfo) {
            if (self.body != null && self.body.GetTimedBuffTotalDurationForIndex(buffDef.buffIndex, out _)) {
                damageInfo.damageColorIndex = Asset.sweptColor;
                damageInfo.damage *= 1.5f;
            }
        }

        private static void RemoveDebuff(CharacterMotor self) {
            if (self.body != null && self.body.GetTimedBuffTotalDurationForIndex(buffDef.buffIndex, out _)) {
                self.body.RemoveOldestTimedBuff(buffDef.buffIndex);
            }
        }
    }
}