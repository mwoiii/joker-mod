using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class GarudyneState : GaruState {

        public override float baseSPCost { get; } = 12f;

        protected override GameObject projectilePrefab => Asset.garudynePrefab;

        protected override float maxRange => 400f;

        protected override float damage => characterBody.damage;
    }
}
