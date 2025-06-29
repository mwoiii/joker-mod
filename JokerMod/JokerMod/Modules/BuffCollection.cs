using System.Collections.Generic;
using JokerMod.Modules.Buffs;
using RoR2;

namespace JokerMod.Modules {
    public static class BuffCollection {
        internal static List<BuffDef> buffDefs = new List<BuffDef>();

        public static void Init() {
            HallowedDebuff.Init();
            SweptDebuff.Init();
            ShockDebuff.Init();
            IrradiatedDebuff.Init();
        }
    }
}
