using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class BufulaState : BufuState {

        public override float spCost { get; } = 8f;

        protected override GameObject projectilePrefab => Asset.bufulaPrefab;

        protected override float spawnRadius => 13f;

        protected override int projectileQuantity => 10;

        protected override float projectileIntervalLower => 0.07f;

        protected override float projectileIntervalUpper => 0.12f;

        protected override float projectileSpeed => 40f;

        protected override float spawnHeight => 8f;

    }
}
