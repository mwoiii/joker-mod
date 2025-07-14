using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class LilimPersona : PersonaBase {

        public override string personaNameToken => "LILIM";

        public override string personaName => "Lilim";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(BufulaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier3 | JokerCatalog.DropTables.Tier4;

         
    }
}
