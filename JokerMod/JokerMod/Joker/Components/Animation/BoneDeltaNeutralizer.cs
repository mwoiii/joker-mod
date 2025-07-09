using UnityEngine;

namespace JokerMod.Joker.Components.Animation {
    public class BoneDeltaNeutralizer : MonoBehaviour {

        // for utilising p5s anims:
        // allows transform to start at correct initial position
        // and prevents motion from getting double stacked
        [SerializeField]
        private bool _negateY;

        public bool negateY {
            get {
                return _negateY;
            }
            set {
                if (_negateY == true && _negateY != value) {
                    stopwatch = 0;
                }
                _negateY = value;
            }
        }

        public Transform bone;
        public Transform root;
        private bool initialized = false;

        private Animator animator;
        private int lastStateHash;
        private Vector3 fixedBoneLocation;
        private Vector3 currentBoneLocation;
        private Vector3 startBoneLocation;

        private float stopwatch;
        private const float crossfadeDuration = 1f;

        void Awake() {
            animator = GetComponent<Animator>();
            fixedBoneLocation = bone.localPosition;
        }

        void LateUpdate() {
            stopwatch += Time.deltaTime;

            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
            int currentHash = state.fullPathHash;

            // Detect animation state change
            if (currentHash != lastStateHash) {
                initialized = false;
                lastStateHash = currentHash;
                currentBoneLocation = fixedBoneLocation;
                startBoneLocation = fixedBoneLocation;
            }

            if (!initialized) {
                Vector3 newBoneLocal = bone.localPosition;

                // Offsetting the root transform to be accurate
                Vector3 rootOffsetDelta = bone.TransformVector(fixedBoneLocation - newBoneLocal);
                root.position -= rootOffsetDelta;

                initialized = true;
            }

            if (!negateY) {
                // when toggled during an animation, interpolate between fixed and non-fixed
                float yPos;
                if (stopwatch <= crossfadeDuration) {
                    float offset = (bone.localPosition.y - startBoneLocation.y) * Mathf.InverseLerp(0f, crossfadeDuration, stopwatch);
                    yPos = startBoneLocation.y + offset;
                } else {
                    yPos = bone.localPosition.y;
                }

                bone.localPosition = new Vector3(fixedBoneLocation.x, yPos, fixedBoneLocation.z);
                currentBoneLocation = bone.localPosition;
            } else {
                // when toggled during an animation, maintaining the gained offset
                bone.localPosition = currentBoneLocation;
                startBoneLocation = currentBoneLocation;
            }
        }
    }
}

/*
namespace JokerMod.Joker.Components.Animation {
    using UnityEngine;

    public class BoneDeltaNeutralizer : MonoBehaviour {

        // for utilising p5s anims:
        // allows mesh to start at correct initial position
        // and then prevents motion from getting double stacked

        public Transform bone;
        private Vector3 initialLocalPosition;
        private bool initialized = false;

        private Animator animator;
        private int lastStateHash;

        void Awake() {
            animator = GetComponent<Animator>();
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
                initialLocalPosition = bone.localPosition;
                initialized = true;
                return;
            }

            // Subtract excess motion from bone
            Vector3 delta = bone.localPosition - initialLocalPosition;
            bone.localPosition -= delta;
        }
    }
}
*/