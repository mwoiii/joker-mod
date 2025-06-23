using System;
using System.Collections.Generic;
using System.Text;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Joker.SkillStates;
using RoR2;
using JokerMod.Modules.Buffs;

namespace JokerMod.Modules {
    public static class BuffCollection {
        internal static List<BuffDef> buffDefs = new List<BuffDef>();

        public static void Init() {
            ShockDebuff.Init();
        }
    }
}
