using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class KougaonState : KouhaState {

        public override float spCost { get; } = 12f;

        protected override GameObject projectilePrefab => Asset.kougaonPrefab;


    }
}