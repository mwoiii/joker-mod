using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class MafreilaState : MafreiState {

        public override float baseSPCost { get; } = 16f;

        protected override GameObject projectilePrefab => Asset.freilaPrefab;
    }
}