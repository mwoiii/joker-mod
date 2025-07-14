using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class MithraPersona : PersonaBase {

        public override string personaNameToken => "MITHRA";

        public override string personaName => "Mithra";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(KougaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier3 | JokerCatalog.DropTables.Tier4;

    }
}
