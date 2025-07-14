using JokerMod.Modules;
using JokerMod.Modules.PersonaSkills;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class EigaonState : EihaState {

        public override SkillTypes.SkillType skillType => SkillTypes.SkillType.Curse;

        public override float baseSPCost { get; } = 12f;

        protected override GameObject projectilePrefab => Asset.eigaonPrefab;

    }
}