using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class MakougaState : MakouhaState {

        public override float baseSPCost { get; } = 10f;

        protected override GameObject projectilePrefab => Asset.kougaPrefab;
    }
}