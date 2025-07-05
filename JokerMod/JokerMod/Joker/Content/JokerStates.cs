using JokerMod.Joker.SkillStates;

namespace JokerMod.Joker {
    public static class JokerStates {
        public static void Init() {
            Modules.Content.AddEntityState(typeof(SlashFlurry));

            Modules.Content.AddEntityState(typeof(ChargeSecondary));

            Modules.Content.AddEntityState(typeof(ChargeUtility));

            Modules.Content.AddEntityState(typeof(ChargeSpecial));
        }
    }
}
