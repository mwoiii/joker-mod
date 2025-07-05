namespace JokerMod.Joker.Components.Animation {
    using UnityEngine;

    public class BoneDeltaNeutralizer : MonoBehaviour {

        // for utilising p5s anims:
        // allows transform to start at correct initial position
        // and prevents motion from getting double stacked

        public Transform bone;
        public Transform root;
        private bool initialized = false;

        private Animator animator;
        private int lastStateHash;
        private Vector3 fixedBoneLocation;

        void Awake() {
            animator = GetComponent<Animator>();
            fixedBoneLocation = bone.localPosition;
        }

        void LateUpdate() {
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
            int currentHash = state.fullPathHash;

            // Detect animation state change
            if (currentHash != lastStateHash) {
                initialized = false;
                lastStateHash = currentHash;
            }

            if (!initialized) {
                Vector3 newBoneLocal = bone.localPosition;

                // Offsetting the root transform to be accurate
                Vector3 rootOffsetDelta = bone.TransformVector(fixedBoneLocation - newBoneLocal);
                root.position -= rootOffsetDelta;

                initialized = true;
            }

            // Fix bone in place
            bone.localPosition = fixedBoneLocation;
            //Vector3 boneNegationDelta = bone.localPosition - initialLocalPosition;
            //bone.localPosition -= boneNegationDelta;
        }
    }
}
