using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class BufudyneState : BufuState {

        public override float baseSPCost { get; } = 12f;

        protected override GameObject projectilePrefab => Asset.bufudynePrefab;

        protected override float spawnRadius => 8f;

        protected override int projectileQuantity => 8;

        protected override float projectileIntervalLower => 0.09f;

        protected override float projectileIntervalUpper => 0.16f;

        protected override float projectileSpeed => 30f;

    }
}
