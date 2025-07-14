using System.Collections;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.Components.Animation {
    public class JokerFootstepHandler : MonoBehaviour {

        FootstepHandler footstepHandler;

        JokerStatController statController;

        CharacterBody characterBody;

        public void Start() {
            footstepHandler = GetComponent<FootstepHandler>();
            StartCoroutine(WaitForComponents());
        }

        private IEnumerator WaitForComponents() {
            while (characterBody == null) {
                characterBody = GetComponent<CharacterModel>()?.body;
                yield return null;
            }

            while (statController == null) {
                statController = characterBody?.master?.GetComponent<JokerStatController>();
                yield return null;
            }
        }

        public void BodyFootstep(AnimationEvent animationEvent) {
            if (statController != null && !statController.isUsingPrimary) {
                footstepHandler.Footstep(animationEvent);
            }
        }

        public void AttackFootstep(AnimationEvent animationEvent) {
            if (characterBody?.characterMotor != null && characterBody.characterMotor.isGrounded) {
                footstepHandler.Footstep(animationEvent);
            }
        }
    }
}
