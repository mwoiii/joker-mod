using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class EigaState : EihaState {

        public override float baseSPCost { get; } = 8f;

        protected override GameObject projectilePrefab => Asset.eigaPrefab;

    }
}