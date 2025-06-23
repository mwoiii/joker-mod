using System;
using System.Collections.Generic;
using System.Text;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Joker.SkillStates;
using RoR2;
using JokerMod.Modules.Buffs;
using R2API;
using JokerMod.Modules.DamageTypes;

namespace JokerMod.Modules {
    public static class DamageTypeCollection {
        internal static List<DamageAPI.ModdedDamageType> damageTypes = new List<DamageAPI.ModdedDamageType>();

        public static void Init() {
            // Curse
            CurseLightType.Init();

            // Elec
            ElecLightType.Init();
            ElecMediumType.Init();
            ElecHeavyType.Init();

            // Psy
            PsyLightType.Init();
            PsyMediumType.Init();
            PsyHeavyType.Init();
        }
    }
}
