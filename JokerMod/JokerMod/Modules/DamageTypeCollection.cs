using System.Collections.Generic;
using JokerMod.Modules.DamageTypes;
using R2API;

namespace JokerMod.Modules {
    public static class DamageTypeCollection {
        internal static List<DamageAPI.ModdedDamageType> damageTypes = new List<DamageAPI.ModdedDamageType>();

        public static void Init() {
            // Bless
            BlessLightWeakType.Init();
            BlessLightType.Init();
            BlessMediumWeakType.Init();
            BlessMediumType.Init();
            BlessHeavyWeakType.Init();
            BlessHeavyType.Init();

            // Curse
            CurseLightWeakType.Init();
            CurseLightType.Init();
            CurseMediumType.Init();
            CurseHeavyType.Init();

            // Fire
            FireLightWeakType.Init();

            // Ice
            IceLightType.Init();
            IceMediumType.Init();

            // Wind
            WindLightType.Init();
            WindMediumType.Init();
            WindHeavyType.Init();
            IgnoreMassType.Init();

            // Elec
            ElecLightWeakType.Init();
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
            PsyLightWeakType.Init();
            PsyLightType.Init();
            PsyMediumType.Init();
            PsyHeavyType.Init();
        }
    }
}
