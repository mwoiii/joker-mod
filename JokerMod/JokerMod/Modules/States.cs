using JokerMod.Joker.SkillStates;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Joker.SkillStates.PersonaStates;

namespace JokerMod.Modules {
    public static class States {

        public static void Register() {
            Content.AddEntityState(typeof(ChargeBase));
            Content.AddEntityState(typeof(PersonaSkillBaseState));
            Content.AddEntityState(typeof(CancelState));
            Content.AddEntityState(typeof(EmptyState));
            Content.AddEntityState(typeof(AOA));
            Content.AddEntityState(typeof(AOADash));
            Content.AddEntityState(typeof(ChargeSecondary));
            Content.AddEntityState(typeof(ChargeUtility));
            Content.AddEntityState(typeof(ChargeSpecial));
            Content.AddEntityState(typeof(Fire));
            Content.AddEntityState(typeof(FireBurst));
            Content.AddEntityState(typeof(LockedState));
            Content.AddEntityState(typeof(OverrideMenu));
            Content.AddEntityState(typeof(PhantomDash));
            Content.AddEntityState(typeof(SlashFlurry));
            Content.AddEntityState(typeof(OverstockMenu));
            Content.AddEntityState(typeof(WaitForReleaseOverrideState));
            Content.AddEntityState(typeof(WaitForReleaseState));
            Content.AddEntityState(typeof(SwapSlotMenu));
            Content.AddEntityState(typeof(CollapseDeathState));

            Content.AddEntityState(typeof(KouhaState));
            Content.AddEntityState(typeof(MakouhaState));
            Content.AddEntityState(typeof(KougaState));
            Content.AddEntityState(typeof(MakougaState));
            Content.AddEntityState(typeof(KougaonState));
            Content.AddEntityState(typeof(MakougaonState));

            Content.AddEntityState(typeof(EihaState));
            Content.AddEntityState(typeof(MaeihaState));
            Content.AddEntityState(typeof(EigaState));
            Content.AddEntityState(typeof(MaeigaState));
            Content.AddEntityState(typeof(EigaonState));
            Content.AddEntityState(typeof(MaeigaonState));

            Content.AddEntityState(typeof(AgiState));
            Content.AddEntityState(typeof(MaragiState));
            Content.AddEntityState(typeof(AgilaoState));
            Content.AddEntityState(typeof(MaragionState));
            Content.AddEntityState(typeof(AgidyneState));
            Content.AddEntityState(typeof(MaragidyneState));

            Content.AddEntityState(typeof(BufuState));
            Content.AddEntityState(typeof(MabufuState));
            Content.AddEntityState(typeof(BufulaState));
            Content.AddEntityState(typeof(MabufulaState));
            Content.AddEntityState(typeof(BufudyneState));
            Content.AddEntityState(typeof(MabufudyneState));

            Content.AddEntityState(typeof(GaruState));
            Content.AddEntityState(typeof(MagaruState));
            Content.AddEntityState(typeof(GarulaState));
            Content.AddEntityState(typeof(MagarulaState));
            Content.AddEntityState(typeof(GarudyneState));
            Content.AddEntityState(typeof(MagarudyneState));

            Content.AddEntityState(typeof(ZioState));
            Content.AddEntityState(typeof(MazioState));
            Content.AddEntityState(typeof(ZiongaState));
            Content.AddEntityState(typeof(MaziongaState));
            Content.AddEntityState(typeof(ZiodyneState));
            Content.AddEntityState(typeof(MaziodyneState));

            Content.AddEntityState(typeof(DiaState));
            Content.AddEntityState(typeof(MediaState));
            Content.AddEntityState(typeof(DiaramaState));
            Content.AddEntityState(typeof(MediaramaState));
            Content.AddEntityState(typeof(DiarahanState));
            Content.AddEntityState(typeof(MediarahanState));

            Content.AddEntityState(typeof(FreiState));
            Content.AddEntityState(typeof(MafreiState));
            Content.AddEntityState(typeof(FreilaState));
            Content.AddEntityState(typeof(MafreilaState));
            Content.AddEntityState(typeof(FreidyneState));
            Content.AddEntityState(typeof(MafreidyneState));

            Content.AddEntityState(typeof(PsiState));
            Content.AddEntityState(typeof(MapsiState));
            Content.AddEntityState(typeof(PsioState));
            Content.AddEntityState(typeof(MapsioState));
            Content.AddEntityState(typeof(PsiodyneState));
            Content.AddEntityState(typeof(MapsiodyneState));
        }
    }
}
