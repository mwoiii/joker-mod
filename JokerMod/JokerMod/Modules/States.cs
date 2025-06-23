using System;
using System.Collections.Generic;
using JokerMod.Joker.SkillStates;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Joker.SkillStates.PersonaStates;

namespace JokerMod.Modules {
    public static class States {
        internal static List<Type> entityStates = new List<Type>();

        public static void Register() {
            entityStates.Add(typeof(ChargeBase));
            entityStates.Add(typeof(PersonaSkillBaseState));
            entityStates.Add(typeof(PersonaSkillProjectileBaseState));
            entityStates.Add(typeof(EihaState));
            entityStates.Add(typeof(MaeihaState));
            entityStates.Add(typeof(EigaState));
            entityStates.Add(typeof(MaeigaState));
            entityStates.Add(typeof(EigaonState));
            entityStates.Add(typeof(MaeigaonState));
            entityStates.Add(typeof(ZioState));
            entityStates.Add(typeof(MazioState));
            entityStates.Add(typeof(ZiongaState));
            entityStates.Add(typeof(MaziongaState));
            entityStates.Add(typeof(ZiodyneState));
            entityStates.Add(typeof(MaziodyneState));
            entityStates.Add(typeof(DiaState));
            entityStates.Add(typeof(DiaramaState));
            entityStates.Add(typeof(DiarahanState));
            entityStates.Add(typeof(PsiState));
            entityStates.Add(typeof(MapsiState));
            entityStates.Add(typeof(PsioState));
            entityStates.Add(typeof(MapsioState));
            entityStates.Add(typeof(PsiodyneState));
            entityStates.Add(typeof(MapsiodyneState));
            entityStates.Add(typeof(CancelState));
            entityStates.Add(typeof(EmptyState));
            entityStates.Add(typeof(AOA));
            entityStates.Add(typeof(AOADash));
            entityStates.Add(typeof(ChargeSecondary));
            entityStates.Add(typeof(ChargeUtility));
            entityStates.Add(typeof(Fire));
            entityStates.Add(typeof(FireBurst));
            entityStates.Add(typeof(LockedState));
            entityStates.Add(typeof(OverrideMenu));
            entityStates.Add(typeof(PhantomDash));
            entityStates.Add(typeof(SlashFlurry));
            entityStates.Add(typeof(SwapPersonaSkill));
            entityStates.Add(typeof(WaitForReleaseOverrideState));
            entityStates.Add(typeof(WaitForReleaseState));
        }
    }
}
