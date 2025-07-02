using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MagarudyneState : MagaruState {

        public override float baseSPCost { get; } = 22f;

        protected override GameObject projectilePrefab => Asset.garudynePrefab;

        protected override float damage => characterBody.damage;
    }
}
