using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class PsyUtils {
        public static BuffDef[] debuffList = [
            RoR2Content.Buffs.BeetleJuice,
            RoR2Content.Buffs.Bleeding,
            RoR2Content.Buffs.OnFire,
            DLC1Content.Buffs.Fracture,
            RoR2Content.Buffs.SuperBleed,
            RoR2Content.Buffs.LunarSecondaryRoot,
            DLC2Content.Buffs.lunarruin,
            DLC1Content.Buffs.PermanentDebuff,
            RoR2Content.Buffs.PermanentCurse,
        ];

        public static BuffDef[] buffList = [
            DLC2Content.Buffs.IncreaseDamageBuff,
            RoR2Content.Buffs.AttackSpeedOnCrit,
            DLC2Content.Buffs.ElusiveAntlersBuff,
        ];

        // unfortunately I can't find a way to distinguish otherwise
        public static BuffDef[] untimedDebuffList = [
            DLC1Content.Buffs.PermanentDebuff,
            RoR2Content.Buffs.PermanentCurse,
        ];
    }
}
