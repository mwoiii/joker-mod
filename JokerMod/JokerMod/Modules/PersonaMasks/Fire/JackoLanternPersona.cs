using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class JackoLanternPersona : PersonaBase {

        public override string personaNameToken => "JACKOLANTERN";

        public override string personaName => "Jack-o'-Lantern";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(AgiState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier1 | JokerCatalog.DropTables.Tier2;

    }
}
