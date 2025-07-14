using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class OrthrusPersona : PersonaBase {

        public override string personaNameToken => "ORTHRUS";

        public override string personaName => "Orthrus";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(AgilaoState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier3 | JokerCatalog.DropTables.Tier4;

         
    }
}
