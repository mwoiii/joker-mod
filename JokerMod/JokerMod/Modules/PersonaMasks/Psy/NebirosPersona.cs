using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class NebirosPersona : PersonaBase {

        public override string personaNameToken => "NEBIROS";

        public override string personaName => "Nebiros";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MapsiodyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier6;

         
    }
}
