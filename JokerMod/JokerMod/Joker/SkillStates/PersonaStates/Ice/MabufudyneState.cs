using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MabufudyneState : MabufuState {

        public override float baseSPCost { get; } = 22f;

        protected override GameObject projectilePrefab => Asset.bufudynePrefab;

        protected override float spawnRadius => 30f;

        protected override int projectileQuantity => 20;

        protected override float projectileIntervalLower => 0.04f;

        protected override float projectileIntervalUpper => 0.07f;

        protected override float projectileSpeed => 30f;

    }
}
