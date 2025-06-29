using UnityEngine;

namespace JokerMod.Joker.Components.SkillHelpers {
    public class RadiusOverTime : MonoBehaviour {

        // increase the x,y,z of local scale of a gameobject by a fixed amount each fixed update

        public float linearRadiusAddition;

        public GameObject objectToScale;

        private void FixedUpdate() {
            objectToScale.transform.localScale += Vector3.one * linearRadiusAddition;
        }
    }
}
