using EntityStates.Merc;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class AOADash : PhantomDash {

        public static float overlapSphereRadius = EvisDash.overlapSphereRadius;

        private const float lollypopFactor = 2.5f;

        public bool isStrong;

        public override void FixedUpdate() {
            base.FixedUpdate();

            // If AOA triggered, checking for nearby hitboxes
            Collider[] colliders;
            int num = HGPhysics.OverlapSphere(out colliders, transform.position, characterBody.radius + overlapSphereRadius * (exceededDuration ? lollypopFactor : 1f), LayerIndex.entityPrecise.mask);
            for (int i = 0; i < num; i++) {
                HurtBox component = colliders[i].GetComponent<HurtBox>();
                if ((bool)component && component.healthComponent != healthComponent && component.teamIndex != teamComponent.teamIndex) {
                    if (isStrong) {
                        AOAStrong nextState = new AOAStrong();
                        outer.SetNextState(nextState);
                    } else {
                        AOA nextState = new AOA();
                        outer.SetNextState(nextState);
                    }
                }
            }
            HGPhysics.ReturnResults(colliders);
        }
    }
}