using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class ThunderbirdPersona : PersonaBase {

        public override string personaNameToken => "THUNDERBIRD";

        public override string personaName => "Thunderbird";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MaziongaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier4 | JokerCatalog.DropTables.Tier5;

    }
}
