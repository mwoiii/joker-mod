using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class NigiMitamaPersona : PersonaBase {

        public override string personaNameToken => "NIGIMITAMA";

        public override string personaName => "Nigi Mitama";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MakouhaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier2 | JokerCatalog.DropTables.Tier3;

    }
}
