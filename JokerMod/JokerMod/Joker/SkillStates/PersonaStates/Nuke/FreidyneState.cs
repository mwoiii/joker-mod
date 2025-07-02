using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class FreidyneState : FreiState {

        public override float baseSPCost { get; } = 12f;

        protected override GameObject projectilePrefab => Asset.freidynePrefab;
    }
}