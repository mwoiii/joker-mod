using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class YamatanoOrochiPersona : PersonaBase {

        public override string personaNameToken => "YAMATANOOROCHI";

        public override string personaName => "Yamata-no-Orochi";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MabufudyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier6;

        public override string calloutString => "Play_Joker_Voice_YamataNoOrochi";
    }
}
