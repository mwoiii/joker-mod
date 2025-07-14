using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class KingFrostPersona : PersonaBase {

        public override string personaNameToken => "KINGFROST";

        public override string personaName => "King Frost";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(BufudyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier5 | JokerCatalog.DropTables.Tier6;

         
    }
}
