using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class QuetzalcoatlPersona : PersonaBase {

        public override string personaNameToken => "QUETZALCOATL";

        public override string personaName => "Quetzalcoatl";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MagarudyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier6;

         
    }
}
