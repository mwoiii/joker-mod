using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks
{
    public class ShikiOujiPersona : PersonaBase {

        public override string personaNameToken => "SHIKIOUJI";

        public override string personaName => "Shiki-Ouji";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MapsioState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier4 | JokerCatalog.DropTables.Tier5;

    }
}
