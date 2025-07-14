using System.Collections.Generic;

namespace JokerMod.Modules.PersonaSkills {
    public static class SkillTypes {
        public enum SkillType {
            Phys,
            Gun,
            Fire,
            Ice,
            Elec,
            Wind,
            Psy,
            Nuke,
            Bless,
            Curse,
            Almighty,
            HealLight,
            HealMedium,
            HealHeavy,
            HealCleanse,
            BuffAtk,
            BuffDef,
            BuffSpd,
            BuffAll,
            DebuffAtk,
            DebuffDef,
            DebuffSpd,
            DebuffAll,
            Sleep,
            Forget,
            Charm,
            Passive,
        }

        private static readonly HashSet<SkillType> SupportTypes = new() {
            SkillType.HealLight,
            SkillType.HealMedium,
            SkillType.HealHeavy,
            SkillType.HealCleanse,
            SkillType.BuffAtk,
            SkillType.BuffDef,
            SkillType.BuffSpd,
            SkillType.BuffAll,
        };

        public static bool IsSupportType(this SkillType type) {
            return SupportTypes.Contains(type);
        }
    }
}
