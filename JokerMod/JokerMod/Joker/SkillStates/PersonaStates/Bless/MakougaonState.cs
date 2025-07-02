using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class MakougaonState : MakouhaState {

        public override float baseSPCost { get; } = 22f;

        protected override GameObject projectilePrefab => Asset.kougaonPrefab;
    }
}