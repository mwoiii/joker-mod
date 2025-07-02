using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MaeigaState : MaeihaState {

        public override float baseSPCost { get; } = 16f;

        protected override GameObject projectilePrefab => Asset.eigaPrefab;

    }
}