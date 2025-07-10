using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class KurumaTenguPersona : PersonaBase {

        public override string personaNameToken => "KURUMATENGU";

        public override string personaName => "Kuruma Tengu";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MagarulaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier4 | JokerCatalog.DropTables.Tier5;

        public override PersonaDef.SkillType skillType => PersonaDef.SkillType.Wind;
    }
}
