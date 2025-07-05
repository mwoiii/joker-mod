using UnityEngine;


namespace JokerMod.Joker.Components.Animation {

    // for utilising p5s anims:
    // fixes hurtbox to be sized between two specific bones
    // allows dynamic hurtbox size
    // but mainly so that animations look right

    public class FlexibleCollider : MonoBehaviour {

        [SerializeField]
        private Transform bone1;

        [SerializeField]
        private Transform bone2;

        [SerializeField]
        private Transform mainHurtbox;

        private Vector3 initialScale;

        private float initialDifference;

        public void Awake() {
            initialScale = mainHurtbox.localScale;
            initialDifference = bone1.position.y - bone2.position.y;
            if (Mathf.Approximately(initialDifference, 0f)) {
                Destroy(this);
            };
        }

        public void Update() {
            float yScale = Mathf.Lerp(0f, initialScale.y, (bone1.position.y - bone2.position.y) / initialDifference);
            mainHurtbox.localScale = new Vector3(initialScale.x, yScale, initialScale.z);
        }
    }
}
