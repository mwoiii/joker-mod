using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class ForneusPersona : PersonaBase {

        public override string personaNameToken => "FORNEUS";

        public override string personaName => "Forneus";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(PsiodyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier5 | JokerCatalog.DropTables.Tier6;

         
    }
}
