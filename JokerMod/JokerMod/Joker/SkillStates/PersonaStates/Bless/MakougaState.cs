using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class MakougaState : MakouhaState {

        public override float spCost { get; } = 10f;

        protected override GameObject projectilePrefab => Asset.kougaPrefab;
    }
}