using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class GarulaState : GaruState {

        public override float baseSPCost { get; } = 8f;

        protected override GameObject projectilePrefab => Asset.garulaPrefab;

        protected override float maxRange => 300f;

        protected override float damage => characterBody.damage;
    }
}
