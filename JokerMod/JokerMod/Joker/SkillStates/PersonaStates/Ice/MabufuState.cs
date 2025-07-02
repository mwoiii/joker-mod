using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MabufuState : BufuState {

        public override float baseSPCost { get; } = 10f;

        protected override GameObject projectilePrefab => Asset.bufuPrefab;

        protected override float spawnRadius => 30f;

        protected override int projectileQuantity => 30;

        protected override float projectileIntervalLower => 0.02f;

        protected override float projectileIntervalUpper => 0.04f;

        protected override float projectileSpeed => 55f;

        protected override float spawnHeight => 10f;

        protected override float forwardDirectionMult => 0f;

    }
}
