using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class LeananSidhePersona : PersonaBase {

        public override string personaNameToken => "LEANANSIDHE";

        public override string personaName => "Leanan Sidhe";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(EigaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier3 | JokerCatalog.DropTables.Tier4;

         
    }
}
