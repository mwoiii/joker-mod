using UnityEngine;

namespace JokerMod.Joker.Components.SkillHelpers {
    public class VelocityOverTime : MonoBehaviour {

        // simple exponential speed multiplier
        // regular velocity over time in projectile simple doesn't work properly for bouncing projectiles
        // model with: initalVelocity * fixedUpdateMultiplier ^ (62.5 * x)

        public float fixedUpdateMultiplier = 1f;

        private Rigidbody rigidbody;

        private void Start() {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            rigidbody.velocity *= fixedUpdateMultiplier;
        }
    }
}
