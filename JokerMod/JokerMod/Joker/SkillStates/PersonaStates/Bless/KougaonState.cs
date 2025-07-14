using JokerMod.Modules;
using JokerMod.Modules.PersonaSkills;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class KougaonState : KouhaState {

        public override SkillTypes.SkillType skillType => SkillTypes.SkillType.Bless;

        public override float baseSPCost { get; } = 12f;

        protected override GameObject projectilePrefab => Asset.kougaonPrefab;


    }
}