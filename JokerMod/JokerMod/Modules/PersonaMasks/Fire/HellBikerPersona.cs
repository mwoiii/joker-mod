using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class HellBikerPersona : PersonaBase {

        public override string personaNameToken => "HELLBIKER";

        public override string personaName => "Hell Biker";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MaragionState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier4 | JokerCatalog.DropTables.Tier5;

         

    }
}
