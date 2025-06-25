using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MagarulaState : MagaruState {

        public override float spCost { get; } = 16f;

        protected override GameObject projectilePrefab => Asset.garulaPrefab;

        protected override float damage => characterBody.damage;

    }
}
