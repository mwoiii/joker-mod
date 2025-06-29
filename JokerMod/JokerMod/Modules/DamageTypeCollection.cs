using System.Collections.Generic;
using JokerMod.Modules.DamageTypes;
using R2API;

namespace JokerMod.Modules {
    public static class DamageTypeCollection {
        internal static List<DamageAPI.ModdedDamageType> damageTypes = new List<DamageAPI.ModdedDamageType>();

        public static void Init() {
            // Curse
            CurseLightType.Init();
            CurseMediumType.Init();
            CurseHeavyType.Init();

            // Wind
            WindLightType.Init();
            WindMediumType.Init();
            WindHeavyType.Init();
            IgnoreMassType.Init();

            // Elec
            ElecLightType.Init();
            ElecMediumType.Init();
            ElecHeavyType.Init();

            // Nuke
            NukeLightWeakType.Init();
            NukeLightType.Init();
            NukeMediumType.Init();
            NukeHeavyWeakType.Init();
            NukeHeavyType.Init();

            // Psy
            PsyLightType.Init();
            PsyMediumType.Init();
            PsyHeavyType.Init();
        }
    }
}
