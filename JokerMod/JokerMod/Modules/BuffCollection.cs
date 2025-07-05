using JokerMod.Modules.Buffs;

namespace JokerMod.Modules {
    public static class BuffCollection {
        public static void Init() {
            HallowedDebuff.Init();
            SweptDebuff.Init();
            ShockDebuff.Init();
            IrradiatedDebuff.Init();
        }
    }
}
