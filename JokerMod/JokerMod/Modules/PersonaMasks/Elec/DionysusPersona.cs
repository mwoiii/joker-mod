using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class DionysusPersona : PersonaBase {

        public override string personaNameToken => "DIONYSUS";

        public override string personaName => "Dionysus";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MaziodyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier6;

         
    }
}
