using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class EigaonState : EihaState {

        public override float baseSPCost { get; } = 12f;

        protected override GameObject projectilePrefab => Asset.eigaonPrefab;

    }
}