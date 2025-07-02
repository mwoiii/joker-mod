using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class KougaState : KouhaState {

        public override float baseSPCost { get; } = 8f;

        protected override GameObject projectilePrefab => Asset.kougaPrefab;
    }
}