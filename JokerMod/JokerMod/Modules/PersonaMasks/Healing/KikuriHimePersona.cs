using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class KikuriHimePersona : PersonaBase {

        public override string personaNameToken => "KIKURIHIME";

        public override string personaName => "Kikuri-Hime";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MediaramaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier4 | JokerCatalog.DropTables.Tier5;

         

    }
}
