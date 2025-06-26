using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class MolochPersona : PersonaBase {

        public override string personaNameToken => "MOLOCH";

        public override string personaName => "Moloch";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MaragidyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier6;

    }
}
