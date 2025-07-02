using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MabufulaState : MabufuState {

        public override float baseSPCost { get; } = 16f;

        protected override GameObject projectilePrefab => Asset.bufulaPrefab;

        protected override float spawnRadius => 30f;

        protected override int projectileQuantity => 25;

        protected override float projectileIntervalLower => 0.03f;

        protected override float projectileIntervalUpper => 0.05f;

        protected override float projectileSpeed => 40f;

    }
}
