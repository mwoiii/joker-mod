using System.Collections;
using UnityEngine;

namespace JokerMod.Joker.Components.Animation {
    public class ScaledRootMotion : MonoBehaviour {

        // for utilising p5s anims:
        // units are incorrect when applying to transform
        // need to scale down only what gets added to the transform - not the whole animation

        // ratio: 1:88.5 (approx 0.0113)
        public float rootMotionScale = 0.0113f;

        private Animator animator;

        void Start() {
            StartCoroutine(WaitForAnimator());
        }

        private IEnumerator WaitForAnimator() {
            yield return new WaitUntil(() => GetComponent<Animator>() != null);
            animator = GetComponent<Animator>();
        }

        void OnAnimatorMove() {
            if (animator == null) {
                return;
            }
            Vector3 scaledDelta = animator.deltaPosition * rootMotionScale;
            Quaternion deltaRotation = animator.deltaRotation;

            transform.position += scaledDelta;
            transform.rotation *= deltaRotation;
        }
    }
}