using JokerMod.Joker.Components.SkillHelpers;
using JokerMod.Modules;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates
{
    public class MaeigaState : MaeihaState {

        public override float spCost { get; } = 16f;

        protected override void ActivateSkill() {
            damageCoefficient = 5f;
            recoilAmplitude = 0f;
            projectilePrefab = Object.Instantiate(Asset.eigaPrefab);
            spiralMovement = projectilePrefab.AddComponent<SpiralMovement>();
        }
    }
}