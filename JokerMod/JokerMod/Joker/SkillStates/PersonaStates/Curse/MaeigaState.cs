using JokerMod.Modules;
using JokerMod.Modules.PersonaSkills;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MaeigaState : MaeihaState {

        public override SkillTypes.SkillType skillType => SkillTypes.SkillType.Curse;

        public override float baseSPCost { get; } = 16f;

        protected override GameObject projectilePrefab => Asset.eigaPrefab;

    }
}