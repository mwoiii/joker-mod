using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class MafreidyneState : MafreiState {

        public override float baseSPCost { get; } = 22f;

        protected override GameObject projectilePrefab => Asset.freidynePrefab;
    }
}