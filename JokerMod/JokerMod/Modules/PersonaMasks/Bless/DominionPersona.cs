using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class DominionPersona : PersonaBase {

        public override string personaNameToken => "DOMINION";

        public override string personaName => "Dominion";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MakougaonState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier6;

        public override PersonaDef.SkillType skillType => PersonaDef.SkillType.Bless;

    }
}
